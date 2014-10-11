using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace CJia.Net.Business.MobileMedical
{
    public class SyncHis2Mid : IDisposable
    {
        bool isStopSync = false;
        string LastChangeDateTime = "";
        string TempLastChangeDateTime = "";
        int MaxSyncRecordNum = 1000;
        System.Timers.Timer timeSync;
        string ListenID = "";
        string ListenSqlText = "Select * From CJ_Sync_Data";
        string SqlQuerySyncData = @"Select S_Data.* From (Select Id, Table_Name, Primary_Key, Key_Value, Change_Type From Cj_Sync_Data Where Status = 1 Order By Id) S_Data Where Rownum <= {0}";
        string SqlDeleteSyncData = @"Delete From CJ_Sync_Data Where ID = :1";
        string SqlUpdateSyncData = @"Update CJ_Sync_Data Set STATUS=0, DO_DATE=Sysdate, DO_RESULT=:1 Where ID=:2";
        public SyncHis2Mid()
        {
            timeSync = new System.Timers.Timer(1000);//1秒
            timeSync.Elapsed += new System.Timers.ElapsedEventHandler(timeSync_Elapsed);
            SqlQuerySyncData = String.Format(SqlQuerySyncData, MaxSyncRecordNum);
        }

        public void Start()
        {
            ListenID = CJia.Net.Data.DefaultOracle.StartListen(ListenSqlText);
            timeSync.Enabled = true;
            timeSync.Start();
        }

        public void Stop()
        {
            isStopSync = true;
            timeSync.Stop();
            timeSync.Enabled = false;
            if (ListenID.Length > 0)
                CJia.Net.Data.DefaultOracle.StopListen(ListenID);
        }

        #region 数据同步监听
        void timeSync_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isStopSync)
            {
                timeSync.Stop();
                return;
            }
            TempLastChangeDateTime = CJia.Net.Data.DefaultOracle.LastDatetime(ListenID);
            if (LastChangeDateTime == TempLastChangeDateTime) return;
            timeSync.Stop();
            try
            {
                if (SyncData() < MaxSyncRecordNum)
                    LastChangeDateTime = TempLastChangeDateTime;
            }
            catch (Exception ex)
            {
                string Msg = "【消息】：" + ex.Message + "\n【堆栈】：" + ex.StackTrace;
            }
            finally
            {
                if (!isStopSync)
                    timeSync.Start();
            }
        }

        int SyncData()
        {
            using (DataTable dtSyncData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQuerySyncData))
            {
                int RowCount = dtSyncData.Rows.Count;
                if (RowCount == 0) return 0;
                string TableName, ChangeType, KeyValue;
                object ID;
                List<object> listDeleteID = new List<object>();
                List<object> listUpdateID = new List<object>();
                List<object> listUpdateResult = new List<object>();
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    for (int i = 0; i < dtSyncData.Rows.Count; i++)
                    {
                        DataRow dr = dtSyncData.Rows[i];
                        ID = dr["ID"];
                        TableName = dr["Table_Name"].ToString().ToUpper();
                        ChangeType = dr["Change_Type"].ToString().ToUpper();
                        KeyValue = dr["Key_Value"].ToString();
                        try
                        {
                            switch (TableName)
                            {
                                case "GM_USER": ToMidUser(ChangeType, KeyValue, TransID); break;
                                case "HM_PATIENT": ToMidPatient(ChangeType, KeyValue, TransID); break;
                                case "HT_ADVICE": ToMidPatientAdvices(ChangeType, KeyValue, TransID); break;
                            }
                            listDeleteID.Add(ID);
                        }
                        catch (Exception ex)
                        {
                            listUpdateID.Add(ID);
                            listUpdateResult.Add(ex.Message);
                        }
                    }
                    CJia.Net.Data.DefaultOracle.BatchExecute(SqlUpdateSyncData, new List<object>[] { listUpdateResult, listUpdateID });
                    CJia.Net.Data.DefaultOracle.BatchExecute(SqlDeleteSyncData, new List<object>[] { listDeleteID });
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    listDeleteID.Clear(); listUpdateID.Clear(); listUpdateResult.Clear();
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                }
                return RowCount;
            }
        }
        #endregion

        #region 同步到中间库
        void ToMidUser(string ChangeType, string KeyValue, string TransID)
        {
            DataTable HiSData = null;
            switch (ChangeType)
            {
                case "DELETE":
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [User] Where [ID] = @1", new object[] { KeyValue }, TransID);
                    break;
                case "UPDATE":
                    string SqlQueryUpdateData = String.Format(SqlQueryUser, ",USER_ID");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryUpdateData, new object[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    DataRow Data = HiSData.Rows[0];
                    Data["PASSWORD"] = DecryptString(Data["PASSWORD"].ToString());
                    CJia.Net.Data.DefaultSQLite.Execute(SqlUpdateUser, Data.ItemArray, TransID);
                    break;
                case "INSERT":
                    string SqlQueryInsertData = String.Format(SqlQueryUser, "");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryInsertData, new object[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    DataRow Data2 = HiSData.Rows[0];
                    Data2["PASSWORD"] = DecryptString(Data2["PASSWORD"].ToString());
                    CJia.Net.Data.DefaultSQLite.Execute(SqlInsertUser, Data2.ItemArray, TransID);
                    break;
            }
            ClearTableData(HiSData);
        }

        void ToMidPatient(string ChangeType, string KeyValue, string TransID)
        {
            DataTable HiSData = null;
            switch (ChangeType)
            {
                case "DELETE":
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [Patient] Where [InhosID] = @1", new object[] { KeyValue }, TransID);
                    break;
                case "UPDATE":
                    string SqlQueryUpdateData = String.Format(SqlQueryPatient, ",HP.INHOS_ID AS UPDATE_INHOS_ID");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryUpdateData, new object[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    CJia.Net.Data.DefaultSQLite.Execute(SqlUpdatePatient, HiSData.Rows[0].ItemArray, TransID);
                    break;
                case "INSERT":
                    string SqlQueryInsertData = String.Format(SqlQueryPatient, "");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryInsertData, new object[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    CJia.Net.Data.DefaultSQLite.Execute(SqlInsertPatient, HiSData.Rows[0].ItemArray, TransID);
                    break;
            }
            ClearTableData(HiSData);
        }

        void ToMidPatientAdvices(string ChangeType, string KeyValue, string TransID)
        {
            DataTable HiSData = null;
            switch (ChangeType)
            {
                case "DELETE":
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [PatientAdvices] Where [PAID] = @1", new object[] { KeyValue }, TransID);
                    break;
                case "UPDATE":
                    string SqlQueryUpdateData = String.Format(SqlQueryPatientAdvices, ",HA.HT_ADVICE_ID AS UPDATE_PAID");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryUpdateData, new string[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    CJia.Net.Data.DefaultSQLite.Execute(SqlUpdatePatientAdvices, HiSData.Rows[0].ItemArray, TransID);
                    break;
                case "INSERT":
                    string SqlQueryInsertData = String.Format(SqlQueryPatientAdvices, "");
                    HiSData = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryInsertData, new object[] { KeyValue });
                    if (HiSData.Rows.Count == 0) return;
                    CJia.Net.Data.DefaultSQLite.Execute(SqlInsertPatientAdvices, HiSData.Rows[0].ItemArray, TransID);
                    break;
            }
            ClearTableData(HiSData);
        }

        void ClearTableData(DataTable HiSData)
        {
            if (HiSData != null)
            {
                HiSData.Rows.Clear();
                HiSData.Dispose();
                HiSData = null;
            }
        }
        #endregion

        #region Init Data
        public string InitMidUserFromHiS()
        {
            using (DataTable dtUser = CJia.Net.Data.DefaultOracle.QueryTable("SELECT USER_ID,USER_CODE,USER_NAME,PASSWORD,DEPT_ID,DEPT_NAME,STATUS FROM GM_USER"))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [User]", null, TransID);
                    foreach (DataRow Data in dtUser.Rows)
                    {
                        Data["PASSWORD"] = DecryptString(Data["PASSWORD"].ToString());
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertUser, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }

        public string InitMidPatientFromHiS()
        {
            //AND HP.INHOS_ID=1000117848
            string SqlQueryAllPatient = String.Format(SqlQueryPatient, "").Replace("AND HP.INHOS_ID = :1", "AND HP.INHOS_PATIENT_STATUS = 600011");
            using (DataTable dtPatient = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryAllPatient))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [Patient]", null, TransID);
                    foreach (DataRow Data in dtPatient.Rows)
                    {
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertPatient, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitMidPatientAdviceFromHiS()
        {
            string SqlQueryAllPatientAdvices = String.Format(SqlQueryPatientAdvices, "").Replace("WHERE HA.HT_ADVICE_ID = :1", "WHERE HA.INHOS_ID IN (SELECT HP.INHOS_ID FROM HM_PATIENT HP WHERE HP.INHOS_PATIENT_STATUS = 600011)");
            using (DataTable dtPatientAdvices = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryAllPatientAdvices))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [PatientAdvices]", null, TransID);
                    DataTable dtAddition = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryAdviceAdditionInfo);
                    string AdviceShowName = ""; string SplitChar = "";
                    foreach (DataRow Data in dtPatientAdvices.Rows)
                    {
                        //901010, 901004 膳食  化验
                        if (Data["ADVICETYPE"].ToString() == "膳食" || Data["ADVICETYPE"].ToString() == "化验")
                        {
                            DataRow[] drs = dtAddition.Select("HT_ADVICE_ID=" + Data["PAID"].ToString());
                            if (drs.Length > 0)
                            {
                                SplitChar = Data["ADVICETYPE"].ToString() == "膳食" ? " " : Environment.NewLine;
                                AdviceShowName = Data["ADVICESHOWNAME"].ToString();
                                foreach (DataRow drAddition in drs)
                                {
                                    AdviceShowName += SplitChar + drAddition["INFO_NAME"].ToString();
                                }
                                Data["ADVICESHOWNAME"] = AdviceShowName;
                            }
                        }
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertPatientAdvices, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitMidPatientSingleAdviceFromHiS(string ht_Advice_id)
        {
            using (DataTable dtPatientAdvices = CJia.Net.Data.DefaultOracle.QueryTable(String.Format(SqlQueryPatientAdvices,""), new object[] { ht_Advice_id }))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [PatientAdvices] Where [PAID]=@1", new object[] { ht_Advice_id }, TransID);
                    //DataTable dtAddition = CJia.Net.Data.DefaultOracle.QueryTable(SqlQueryAdviceAdditionInfo);
                    //string AdviceShowName = ""; string SplitChar = "";
                    foreach (DataRow Data in dtPatientAdvices.Rows)
                    {
                        //901010, 901004 膳食  化验
                        //if (Data["ADVICETYPE"].ToString() == "膳食" || Data["ADVICETYPE"].ToString() == "化验")
                        //{
                        //    DataRow[] drs = dtAddition.Select("HT_ADVICE_ID=" + Data["PAID"].ToString());
                        //    if (drs.Length > 0)
                        //    {
                        //        SplitChar = Data["ADVICETYPE"].ToString() == "膳食" ? " " : Environment.NewLine;
                        //        AdviceShowName = Data["ADVICESHOWNAME"].ToString();
                        //        foreach (DataRow drAddition in drs)
                        //        {
                        //            AdviceShowName += SplitChar + drAddition["INFO_NAME"].ToString();
                        //        }
                        //        Data["ADVICESHOWNAME"] = AdviceShowName;
                        //    }
                        //}
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertPatientAdvices, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        
        public string InitEMRPatientID()
        {
            Dictionary<string, string> dicDocType = new Dictionary<string, string>();
            dicDocType.Add("10", "入院记录");
            dicDocType.Add("20", "病程记录");
            dicDocType.Add("30", "手术文书");
            dicDocType.Add("40", "知情同意书");
            dicDocType.Add("50", "麻醉文书");
            dicDocType.Add("60", "出院文书");
            dicDocType.Add("70", "会诊记录");
            dicDocType.Add("80", "讨论记录");
            dicDocType.Add("90", "上报卡");
            dicDocType.Add("100", "其他");
            dicDocType.Add("110", "多学科诊疗");
            dicDocType.Add("200", "护理文书");
            string SqlQueryAllPatient = "Select * From [Patient]";
            using (DataTable dtPatient = CJia.Net.Data.DefaultSQLite.QueryTable(SqlQueryAllPatient))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    string InhosID = "", EMRID = "", Title = ""; int SectionNo;
                    string TypeID, TypeName;
                    EMRService.EmrService emrWebSercice = new EMRService.EmrService();
                    string SqlUpdateEMRID = "Update [Patient] Set EMRID = :1 Where [InhosID]=:2";
                    string SqlInsertEMRDoc = @"Insert Into [PatientEmrDoc] ([InhosID], [SectionNo], [DocTypeID], [DocTypeName],[Title], [DocContent], [Creator], [CreateDate],[CreateTime], [Status], [Checker], [CheckDate], [LastSaveDate]) Values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)";
                    foreach (DataRow Data in dtPatient.Rows)
                    {
                        InhosID = Data["InhosID"].ToString();
                        EMRID = emrWebSercice.GetEmrIdByCureNo(InhosID);
                        if (EMRID.Length > 0)
                        {
                            EMRService.EmrDocSection[] arySection = emrWebSercice.GetEmrDocSectionTitleList(EMRID);
                            foreach (EMRService.EmrDocSection Section in arySection)
                            {
                                SectionNo = Section.SectionNo;
                                TypeID = Section.TypeID.Substring(0,Section.TypeID.IndexOf("."));
                                TypeName = dicDocType[TypeID];
                                Title = Section.Name;
                                EMRService.EmrDocHtml html = emrWebSercice.GetEmrDocHtml(EMRID, SectionNo);
                                object[] InsertDocParams = new object[] { InhosID, SectionNo, TypeID, TypeName, Title, html.HtmlContent, Section.Creator, Section.CreateDate.ToString("yyyy-MM-dd"), Section.CreateDate.ToString("HH:mm:ss"), html.IsDeleted, Section.Checker, Section.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"), Section.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                                CJia.Net.Data.DefaultSQLite.Execute(SqlInsertEMRDoc, InsertDocParams, TransID);
                            }
                        }
                        CJia.Net.Data.DefaultSQLite.Execute(SqlUpdateEMRID, new object[] { EMRID, InhosID }, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitLisResult()
        {
            string SqlQueryAllPatient = "Select * From [Patient]";
            Net.Data.DefaultOracle.DbName = "ETLDB";
            using (DataTable dtPatient = CJia.Net.Data.DefaultSQLite.QueryTable(SqlQueryAllPatient))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    string IllcaseNo = "";
                    string SqlQueryLisAdvice = @"select t.patient_code IllcaseNo, replace(t.advice_code,'XZY','') AdviceID, 
  t.advice_name AdviceName, t.diagnosis Diagnose, t.doctor_name Doctor, 
  to_char(t.require_date,'YYYY-MM-DD HH24:MI:SS') ApplyDate, 
  t.office_name Office, t.reporter_name Reporter, 
  to_char(t.date_report,'YYYY-MM-DD HH24:MI:SS') ReportDate, 
  t.sample_no SampleNo,  to_char(t.date_test,'YYYY-MM-DD HH24:MI:SS') TestDate
from ut_lis_patient_info t where t.patient_code = :1 and t.advice_code is not null";
                    string SqlInsertLISAdvice = @"Insert Into [LisAdvice] ([IllcaseNo], [AdviceID], [AdviceName],[Diagnose], [Doctor], [ApplyDate], [Office], [Reporter],  [ReportDate], [SampleNo],[TestDate]) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";

                    string SqlQueryLisResult = @"select  res.sample_no SampleNo,  to_char(res.date_test,'YYYY-MM-DD HH24:MI:SS') TestDate, res.item_code ItemCode, res.item_name ItemName, 
 res.test_value TestResult, res.text_danwei TestUnit, res.text_range NormalRange, res.text_note TestNote, res.crisis_value CRISISValue
from ut_lis_result res,ut_lis_patient_info pat
where pat.patient_code = :1
and res.sample_no = pat.sample_no
and res.date_test = pat.date_test";
                    string SqlInsertListResult = @"Insert Into [LisResult] ([SampleNo], [TestDate], [ItemCode], [ItemName], [TestResult], [TestUnit], [NormalRange], [TestNote], [CRISISValue]) values (@1,@2,@3,@4,@5,@6,@7,@8,@9)";

                    foreach (DataRow Data in dtPatient.Rows)
                    {
                        IllcaseNo = Data["IllcaseNo"].ToString();
                        using (DataTable dtAdvice = Net.Data.DefaultOracle.QueryTable(SqlQueryLisAdvice, new object[] { IllcaseNo }))
                        {
                            foreach (DataRow drAdvice in dtAdvice.Rows)
                            {
                                Net.Data.DefaultSQLite.Execute(SqlInsertLISAdvice, drAdvice.ItemArray, TransID);
                            }
                        }

                        using (DataTable dtResult = Net.Data.DefaultOracle.QueryTable(SqlQueryLisResult, new object[] { IllcaseNo }))
                        {
                            foreach (DataRow drResult in dtResult.Rows)
                            {
                                Net.Data.DefaultSQLite.Execute(SqlInsertListResult, drResult.ItemArray, TransID);
                            }
                        }
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitCheckResult()
        {
            string SqlQueryAllPatient = "Select * From [Patient]";
            using (DataTable dtPatient = CJia.Net.Data.DefaultSQLite.QueryTable(SqlQueryAllPatient))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    string IllcaseNo = "";
                    string SqlQueryCheckApply = @"SELECT [cureno],[HospitalNo],[PatientName],[PatientClass] ,[ApplyNo],[TechSystem] ,[ReportType] ,[ReportName] ,[ReportDate] ,[SubmissionDate] ,[TechNo] ,[TechMothod], '1' FROM [GetUiSReportOBR] where cureno = @1";
                    string SqlInsertCheckApply = @"INSERT INTO [CheckApply] ([InhosID],[IllcaseNo],[PatientName],[PatientClass],[ApplyNo],[TechSystem],[ReportType],[ReportName],[ReportDate],[SubmissionDate], [TechNo],[TechMothod],[isNew]) Values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)";
                    string SqlQueryCheckResult = @"SELECT [ApplyNo],[TechSystem],[SerialNo],[ItemCode] ,[ItemName],[ItemResult] FROM [GetUisReportOBX] WHERE [ApplyNo]=@1";
                    string SqlInsertCheckResult = @"INSERT INTO [CheckResult] ([ApplyNo],[TechSystem],[SerialNo],[ItemCode],[ItemName],[ItemResult]) Values (@1,@2,@3,@4,@5,@6)";

                    Net.Data.DefaultSQLite.Execute("Delete From [CheckApply]", null, TransID);
                    Net.Data.DefaultSQLite.Execute("Delete From [CheckResult]", null, TransID);
                    DataTable dtResult;

                    foreach (DataRow Data in dtPatient.Rows)
                    {
                        IllcaseNo = Data["InhosID"].ToString();
                        using (DataTable dtAdvice = Net.Data.DefaultSql.QueryTable(SqlQueryCheckApply, new object[] { IllcaseNo }))
                        {
                            foreach (DataRow drAdvice in dtAdvice.Rows)
                            {
                                Net.Data.DefaultSQLite.Execute(SqlInsertCheckApply, drAdvice.ItemArray, TransID);
                                dtResult = Net.Data.DefaultSql.QueryTable(SqlQueryCheckResult, new object[] { drAdvice["ApplyNo"].ToString() });
                                if (dtResult == null || dtResult.Rows.Count == 0) continue;
                                foreach (DataRow drResult in dtResult.Rows)
                                {
                                    Net.Data.DefaultSQLite.Execute(SqlInsertCheckResult, drResult.ItemArray, TransID);
                                }
                            }

                        }
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitPatientFee()
        {
            string SqlQueryAllPatient = "Select * From [Patient]";
            using (DataTable dtPatient = CJia.Net.Data.DefaultSQLite.QueryTable(SqlQueryAllPatient))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    string InhosID = "";
                    string SqlQueryBeginDate = @"SELECT TO_CHAR(NVL(HI.CHARGE_DATE, HP.INHOS_DATE),'YYYY-MM-DD HH24:MI:SS')
    FROM HM_PATIENT HP,
         (SELECT ROW_NUMBER() OVER(ORDER BY HI.END_DATE DESC) R,
                 HI.END_DATE + 1 / 24 / 60 / 60 CHARGE_DATE,
                 HI.INHOS_ID
            FROM HT_INVOICE HI
           WHERE HI.STATUS = '1'
             AND HI.INHOS_ID = :1
             AND HI.INVOICE_TYPE NOT IN (700022, 700025)) HI
   WHERE HP.INHOS_ID = :2
     AND HP.INHOS_ID = HI.INHOS_ID(+)
     AND HI.R(+) = 1";
                    //1:inhos_id;2:BeginDate;3:EndDate;4:BeginDate;5:EndDate;6:EndDate;7:InhosID
                    string SqlQueryPatientFee = @"Select INHOS_ID,MEDICARE_TYPE_CODE, MEDICARE_TYPE_NAME, SUM(FEE_SUM) FEE_SUM
      FROM (SELECT F.*, VMF.I_INHOS_TYPE_CODE MEDICARE_TYPE_CODE,
                   (SELECT GIFT.FEE_TYPE_NAME FROM GM_INTERFACE_FEE_TYPE GIFT WHERE GIFT.FEE_TYPE_CODE = VMF.I_INHOS_TYPE_CODE AND GIFT.INTERFACE_TYPE_CODE = 901201 AND GIFT.FLAG = '2') MEDICARE_TYPE_NAME
              FROM (SELECT HF.INHOS_ID,HF.INTERFACE_FEE_ID, ROUND(HF.FEE_ACCOUNT * HF.PRICE, 2) FEE_SUM
                      FROM HT_FEE HF
                     WHERE HF.STATUS = '1'
                       AND HF.BALANCE_STATUS = '0'
                       AND HF.EXE_STATUS = '1'
                       AND HF.INHOS_ID = :1
                       AND HF.EXE_TIME BETWEEN TO_DATE(:2, 'YYYY-MM-DD HH24:MI:SS') And TO_DATE(:3, 'YYYY-MM-DD HH24:MI:SS')
                       AND HF.INHOS_FEE_SOURCE <> 600064
                    UNION ALL
                    SELECT CP.INHOS_ID,CPD.INTERFACE_FEE_ID, ROUND(CP.FEE_ACCOUNT * CPD.PRICE, 2) FEE_SUM
                      FROM 
                           (SELECT INHOS_ID, CHANGE_ID,
                                   TO_NUMBER(Case WHEN TO_CHAR(E_DATE, 'hh24') < 12 Then TRUNC(E_DATE) Else TRUNC(E_DATE) + 1 / 2 END - 
                                             Case WHEN TO_CHAR(B_DATE, 'hh24') < 12 Then TRUNC(B_DATE) Else TRUNC(B_DATE) + 1 / 2 End) FEE_ACCOUNT
                              FROM (SELECT P.INHOS_ID, P.CHANGE_ID,
                                           GREATEST(P.BEGIN_DATE,TO_DATE(:4, 'YYYY-MM-DD HH24:MI:SS')) B_DATE,
                                           LEAST(NVL(P.END_DATE, TO_DATE(:5, 'YYYY-MM-DD HH24:MI:SS')), TO_DATE(:6, 'YYYY-MM-DD HH24:MI:SS')) E_DATE
                                      FROM HT_PATIENT_COMMON_PRICE P
                                     Where P.INHOS_ID = :7)
                             WHERE E_DATE > B_DATE) CP,
                           HT_PATIENT_COMMON_PRICE_DETAIL CPD
                     WHERE CP.CHANGE_ID = CPD.CHANGE_ID) F,
                   GR_FEE_INTERFACE VMF
             WHERE ABS(F.INTERFACE_FEE_ID) = VMF.INTERFACE_FEE_ID)
     GROUP By INHOS_ID,MEDICARE_TYPE_CODE, MEDICARE_TYPE_NAME";
                    string SqlInsertPatientFee = @"Insert Into [PatientFee] ([InhosID], [FeeTypeCode], [FeeTypeName], [FeeSum]) Values (@1,@2,@3,@4)";
                    string SqlQueryPrepay = @"Select Ha.Inhos_Id,
       Ha.Amount,
       To_Char(Ha.Charge_Date, 'YYYY-MM-DD HH24:MI:SS') As Prepay_Date,
       g.Name As Status,
       To_Char(Ha.Invoice_Date, 'YYYY-MM-DD HH24:MI:SS') As Balance_Date
  From Ht_Advance Ha, Gm_Code g
 Where Ha.Advance_Status = g.Code
   And Ha.Inhos_Id = :1";
                    string SqlInsertPrepay = @"Insert Into [PatientPrepay] ([InhosID], [Prepay], [PayDate], [Status], [BalanceDate]) Values (@1,@2,@3,@4,@5)";
                    string BeginDate, EndDate;
                    EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    object[] patParams;
                    foreach (DataRow Data in dtPatient.Rows)
                    {
                        InhosID = Data["InhosID"].ToString();
                        patParams = new object[] { InhosID };
                        BeginDate = Net.Data.DefaultOracle.QueryScalar(SqlQueryBeginDate, new object[] { InhosID, InhosID });
                        //1:inhos_id;2:BeginDate;3:EndDate;4:BeginDate;5:EndDate;6:EndDate;7:InhosID
                        //CJia.Net.Data.DefaultSQLite.Execute(SqlDeletePatientFee, patParams);
                        //CJia.Net.Data.DefaultSQLite.Execute(SqlDeletePrepay, patParams);
                        object[] aryFee = new object[] { InhosID, BeginDate, EndDate, BeginDate, EndDate, EndDate, InhosID };
                        using (DataTable dtFee = Net.Data.DefaultOracle.QueryTable(SqlQueryPatientFee, aryFee))
                        {
                            foreach (DataRow drFee in dtFee.Rows)
                            {
                                Net.Data.DefaultSQLite.Execute(SqlInsertPatientFee, drFee.ItemArray, TransID);
                            }
                        }

                        using (DataTable dtPrepay = Net.Data.DefaultOracle.QueryTable(SqlQueryPrepay, patParams))
                        {
                            foreach (DataRow drPay in dtPrepay.Rows)
                            {
                                Net.Data.DefaultSQLite.Execute(SqlInsertPrepay, drPay.ItemArray, TransID);
                            }
                        }
                        //修改病人资料中的费用总额和预交款字段
                        string PrepaySum = Net.Data.DefaultSQLite.QueryScalar("select sum(prepay) from PatientPrepay t where t.status = '正常' and t.inhosID =@1", patParams, TransID).Trim();
                        string FeeSum = Net.Data.DefaultSQLite.QueryScalar("select sum(FeeSum) from PatientFee t where t.inhosID =@1", patParams, TransID).Trim();
                        string isOwe = "0";
                        if (Data["PatientType"].ToString().IndexOf("自费") > 0)
                        {
                            if (PrepaySum.Length > 0 && FeeSum.Length > 0)
                            {
                                isOwe = Convert.ToDecimal(PrepaySum) < Convert.ToDecimal(FeeSum) ? "1" : "0";
                            }
                            else if (PrepaySum.Length == 0 && FeeSum.Length > 0)
                            {
                                isOwe = "1";
                            }
                        }

                        Net.Data.DefaultSQLite.Execute("update [Patient] Set Prepay=@1,FeeSum=@2,IsOweFee=@3 Where InhosID=@4", new object[] { PrepaySum.Length == 0 ? "0" : PrepaySum, FeeSum.Length == 0 ? "0" : FeeSum, isOwe, InhosID }, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InitAdvice()
        {
            string SqlPharmAdvice = @"Select '' As Aid,
       Gp.Pharm_Id As Adviceid,
       Gp.Advice_Type_Code As Advicetype,'9' As StandingType,
       Gp.Pharm_Code As Advicecode,
       Gp.Pharm_Name As Advicename,
       Gp.Common_Name As Commonname,
       Gp.Filter As Advicefilter,
       Gp.Spec As Spec,
       Gp.Inhos_Price As Price,
       Gp.Inhos_Unit As Unit,
       Gf.Factory_Name As Factory,
       '' As Notes,
       Gp.Default_Dosage As Defaultdosage,
       Gp.Default_Usage_Id As Defaultusage,
       Gp.Default_Frequency_Id As Defaultfrequency,
       Gp.Default_Pharm_Type As Defaultpharmtype
  From Gm_Pharm Gp, Gm_Factory Gf
 Where Gp.Status = '1'
   And Gp.Factory = Gf.Factory_Id(+)";
            string SqlHerbalAdvice = @"Select '' As Aid,
       Gp.Herbal_Id As Adviceid,
       Gp.Advice_Type_Code As Advicetype,'9' As StandingType,
       Gp.Herbal_Code As Advicecode,
       Gp.Herbal_Name As Advicename,
       Gp.Common_Name As Commonname,
       Gp.Filter As Advicefilter,
       Gp.Spec As Spec,
       Gp.Price As Price,
       Gp.Unit As Unit,
       Gf.Factory_Name As Factory,
       '' As Notes,
       '' As Defaultdosage,
       '' As Defaultusage,
       '' As Defaultfrequency,
       '' As Defaultpharmtype
  From Gm_Herbal Gp, Gm_Factory Gf
 Where Gp.Status = '1'
   And Gp.Factory = Gf.Factory_Id(+)";
            string SqlAdvice = @"Select '' As Aid,
       Gp.Advice_Id As Adviceid,
       Gp.Advice_Type_Code As Advicetype,
       Decode(gp.standing_code,0,'9',901102,'0',901101,'1','9') As StandingType,
       gp.ud_code As Advicecode,
       Gp.Advice_Name As Advicename,
       Gp.Common_Name As Commonname,
       Gp.Filter As Advicefilter,
       Gp.Spec As Spec,
       Gp.Price As Price,
       Gp.Unit As Unit,
       '' As Factory,
       '' As Notes,
       '' As Defaultdosage,
       '' As Defaultusage,
       '' As Defaultfrequency,
       '' As Defaultpharmtype
  From Gm_Advice GP
 Where Gp.Status = '1'
 And gp.use_flag Like '%1'";
            string SqlInsertAdvice = @"Insert Into [iAdvice] ( [AID], [AdviceID], [AdviceType], [StandingType], [AdviceCode], [AdviceName], [CommonName], [AdviceFilter], [Spec], [Price], [Unit], [Factory], [Notes], [DefaultDosage], [DefaultUsage], [DefaultFrequency], [DefaultPharmType]) 
 Values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)";
            using (DataTable dtPharm = CJia.Net.Data.DefaultOracle.QueryTable(SqlPharmAdvice))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [iAdvice]", null, TransID);
                    foreach (DataRow Data in dtPharm.Rows)
                    {
                        Data["AID"] = Guid.NewGuid().ToString();
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertAdvice, Data.ItemArray, TransID);
                    }
                    DataTable dtHerbal = CJia.Net.Data.DefaultOracle.QueryTable(SqlHerbalAdvice);
                    foreach (DataRow Data in dtHerbal.Rows)
                    {
                        Data["AID"] = Guid.NewGuid().ToString();
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertAdvice, Data.ItemArray, TransID);
                    }
                    DataTable dtAdvice = CJia.Net.Data.DefaultOracle.QueryTable(SqlAdvice);
                    foreach (DataRow Data in dtAdvice.Rows)
                    {
                        Data["AID"] = Guid.NewGuid().ToString();
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertAdvice, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitFrequency()
        {
            string SqlFrequency = @"Select Gf.Frequency_Id As Frequencyid,
       Gf.Frequency_Name As Frequencyname,
       Gf.Filter As Frequencyfilter,
       Decode(Gf.Freq_Flag, '01', '0', '10', '1', '11', '9') As Standingflag,
       '' As Useflag,
       '' As Orderseq,
       Gf.Memo As Notes
  From Gm_Frequency Gf
 Where Gf.Use_Occasion_Flag Like '%1'
   And Gf.Freq_Flag <> '00'";
            string SqlInsertFrequency = @"Insert into [iFrequency] ([FrequencyID],[FrequencyName],[FrequencyFilter],[StandingFlag],[UseFlag],[OrderSeq],[Notes])
Values (@1,@2,@3,@4,@5,@6,@7)";
            using (DataTable dtFrequency = CJia.Net.Data.DefaultOracle.QueryTable(SqlFrequency))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [iFrequency]", null, TransID);
                    foreach (DataRow Data in dtFrequency.Rows)
                    {
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertFrequency, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        public string InitUsage()
        {
            string SqlUsage = @"Select g.Usage_Id        As Usageid,
       g.Usage_Name      As Usagename,
       g.Usage_Type_Code As Usagetypecode,
       g.Filter          As Usagefilter,
       g.Ud_Name         As Notes
  From Gm_Usage g";
            string SqlInsertUsage = @"Insert into [iUsage] ([UsageID],[UsageName],[UsageTypeCode],[UsageFilter],[Notes])
Values (@1,@2,@3,@4,@5)";
            using (DataTable dtUsage = CJia.Net.Data.DefaultOracle.QueryTable(SqlUsage))
            {
                string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
                try
                {
                    CJia.Net.Data.DefaultSQLite.Execute("Delete From [iUsage]", null, TransID);
                    foreach (DataRow Data in dtUsage.Rows)
                    {
                        CJia.Net.Data.DefaultSQLite.Execute(SqlInsertUsage, Data.ItemArray, TransID);
                    }
                    CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                    return "OK";
                }
                catch (Exception ex)
                {
                    CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                    return ex.Message;
                }
            }
        }
        #endregion

        #region 加、解密
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">要解密的字符串</param>
        /// <returns></returns>
        public static string DecryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            }

            byte[] byKey = { 0x13, 0x28, 0x35, 0x4E, 0x59, 0x65, 0x71, 0x8F };
            byte[] IV = { 0xFE, 0xDC, 0xCA, 0xB8, 0xA6, 0x04, 0x92, 0x80 };
            byte[] inputByteArray = new Byte[input.Length];
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns></returns>
        public static string EncryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            }

            byte[] byKey = { 0x13, 0x28, 0x35, 0x4E, 0x59, 0x65, 0x71, 0x8F };
            byte[] IV = { 0xFE, 0xDC, 0xCA, 0xB8, 0xA6, 0x04, 0x92, 0x80 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        #endregion

        #region SQL User
        /// <summary>
        /// 更新用户资料
        /// </summary>
        string SqlUpdateUser = @"Update [User] Set [ID]=@1,[Code]=@2,[Name]=@3,[Password]=@4,[DeptID]=@5,[DeptName]=@6,[Status]=@7 Where [ID]=@8";
        /// <summary>
        /// 新增用户资料
        /// </summary>
        string SqlInsertUser = @"Insert Into [User] ([ID],[Code],[Name],[Password],[DeptID],[DeptName],[Status]) Values (@1,@2,@3,@4,@5,@6,@7)";
        /// <summary>
        /// 查询HIS用户资料
        /// </summary>
        string SqlQueryUser = "SELECT USER_ID,USER_CODE,USER_NAME,PASSWORD,DEPT_ID,DEPT_NAME,STATUS{0} FROM GM_USER WHERE USER_ID = :1";
        #endregion

        #region SQL Patient
        /// <summary>
        /// 新增中间库病人资料
        /// </summary>
        string SqlInsertPatient = @"Insert Into [Patient] ([InhosID],[PatientID],[PatientCode],[PatientName],[PatientType],[IDCardNo],[Gender],[Age],[IllcaseNo],[InhosDate],
[InhosType],[InhosStatus],[IllfieldID],[IllfieldName],[OfficeID],[OfficeName],[BedID], [BedName], [BedDoctor], [GradeName], 
[FoodName],[IllnessState],[AllergicHistory],[DiagnoseName],[LeaveHosDate],[LeaveHosState]) Values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26)";
        /// <summary>
        /// 更新中间库病人资料
        /// </summary>
        string SqlUpdatePatient = @"Update [Patient] Set [InhosID]=@1,[PatientID]=@2,[PatientCode]=@3,[PatientName]=@4,[PatientType]=@5,[IDCardNo]=@6,[Gender]=@7,[Age]=@8,[IllcaseNo]=@9,[InhosDate]=@10,
[InhosType]=@11,[InhosStatus]=@12,[IllfieldID]=@13,[IllfieldName]=@14,[OfficeID]=@15,[OfficeName]=@16,[BedID]=@17,[BedName]=@18,[BedDoctor]=@19,[GradeName]=@20,[FoodName]=@21,
[IllnessState]=@22,[AllergicHistory]=@23,[DiagnoseName]=@24,[LeaveHosDate]=@25,[LeaveHosState]=@26 Where [InhosID]=@27";
        /// <summary>
        /// 查询HIS住院病人资料
        /// </summary>
        public string SqlQueryPatient = @"
 SELECT HP.INHOS_ID,HP.PATIENT_ID,HP.PATIENT_NO,HP.PATIENT_NAME,GPST.SUB_TYPE_NAME,
       HP.ID_CARD_NO,HP.GENDER,GET_AGE(HP.BIRTHDAY) AS AGE,HP.ILLCASE_NO,
       TO_CHAR(HP.INHOS_DATE,'YYYY-MM-DD HH24:MI:SS') AS INHOS_DATE,
       (SELECT NAME FROM GM_CODE WHERE CODE = HP.INHOS_PATIENT_TYPE) AS INHOS_TYPE,
       (SELECT NAME FROM GM_CODE WHERE CODE = HP.INHOS_PATIENT_STATUS) AS INHOS_STATUS,
       HP.ILLFIELD_ID,HP.ILLFIELD_NAME,HP.OFFICE_ID,HP.OFFICE_NAME,
       (CASE WHEN BED.STATUS = '1' OR (BED.STATUS = '2' AND HP.INHOS_PATIENT_STATUS = 600013) THEN BED.TYPE_ID ELSE NULL END) BED_ID,
       (CASE WHEN BED.STATUS = '1' OR (BED.STATUS = '2' AND HP.INHOS_PATIENT_STATUS= 600013) THEN BED.TYPE_NAME ELSE NULL END) BED_NAME,
       (CASE WHEN BED.STATUS = '1' OR (BED.STATUS = '2' AND HP.INHOS_PATIENT_STATUS = 600013) THEN (SELECT B.DOCTOR FROM GM_BED B WHERE B.ID=BED.TYPE_ID) ELSE NULL END) BED_DOCTOR,
       (CASE WHEN GRADE.STATUS = '1' OR (GRADE.STATUS = '2' AND HP.INHOS_PATIENT_STATUS= 600013) THEN GRADE.TYPE_NAME ELSE NULL END) GRADE_NAME,
       (CASE WHEN FOOD.STATUS = '1' OR (FOOD.STATUS = '2' AND HP.INHOS_PATIENT_STATUS = 600013) THEN FOOD.TYPE_NAME ELSE NULL END) FOOD_NAME,
       HP.ILL_STATUS_NAME,'' AS ALLERGICHISTORY,'' AS DIAGNOSENAME,
       TO_CHAR(HP.LEAVEHOS_DATE,'YYYY-MM-DD HH24:MI:SS') AS LEAVEHOS_DATE,
       HP.LVHOS_STATE_NAME {0}
 FROM HM_PATIENT HP, GM_PATIENT_SUB_TYPE GPST,
      (SELECT HP.TYPE_ID, HP.TYPE_NAME, HP.INHOS_ID,HP.STATUS FROM HT_PATIENT_COMMON_PRICE HP WHERE HP.STATUS IN ('1','2','3') AND HP.FEE_TYPE = 600302) BED,
      (SELECT HP.TYPE_ID, HP.TYPE_NAME, HP.INHOS_ID,HP.STATUS FROM HT_PATIENT_COMMON_PRICE HP WHERE HP.STATUS IN ('1','2','3') AND HP.FEE_TYPE = 600301) GRADE,
      (SELECT HP.TYPE_ID, HP.TYPE_NAME, HP.INHOS_ID,HP.STATUS FROM HT_PATIENT_COMMON_PRICE HP WHERE HP.STATUS IN ('1','2','3') AND HP.FEE_TYPE = 600303) FOOD
 WHERE HP.INHOS_ID = BED.INHOS_ID(+)
   AND HP.INHOS_ID = GRADE.INHOS_ID(+)
   AND HP.INHOS_ID = FOOD.INHOS_ID(+)
   AND HP.SUB_TYPE_ID = GPST.SUB_TYPE_ID
   AND HP.INHOS_ID = :1";
        #endregion

        #region SQL Patient Advice
        /// <summary>
        /// 新增中间库病人医嘱资料
        /// </summary>
        string SqlInsertPatientAdvices = @"INSERT INTO [PatientAdvices] ([PAID],[InhosID],[AdviceID],[PatientIllfield],[PatientOffice],[StandingFlag],[AdviceType],[AdviceName],[CommonName],[AdviceShowName],[ViewGroup],
[GroupIndex],[Spec],[Dosage],[UsageName],[Frequence],[Memo],[ListDoctor],[ListDoctorOffice],[ListDate],[PreStartDate],[PreStopDate],[StopDoctor],[StopDate],[AuditNurse],[AuditDate],[StopAuditNurse],[StopAuditDate],[AdviceStatus])
VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29)";
        /// <summary>
        /// 更新中间库病人医嘱资料
        /// </summary>
        string SqlUpdatePatientAdvices = @"Update [PatientAdvices] Set [PAID]=@1,[InhosID]=@2,[AdviceID]=@3,[PatientIllfield]=@4,[PatientOffice]=@5,[StandingFlag]=@6,[AdviceType]=@7,[AdviceName]=@8,[CommonName]=@9,[AdviceShowName]=@10,
[ViewGroup]=@11,[GroupIndex]=@12,[Spec]=@13,[Dosage]=@14,[UsageName]=@15,[Frequence]=@16,[Memo]=@17,[ListDoctor]=@18,[ListDoctorOffice]=@19,[ListDate]=@20,[PreStartDate]=@21,[PreStopDate]=@22,[StopDoctor]=@23,[StopDate]=@24,[AuditNurse]=@25,[AuditDate]=@26,[StopAuditNurse]=@27,[StopAuditDate]=@28,[AdviceStatus]=@29 
Where [PAID]=@30";
        /// <summary>
        /// 查询HIS住院病人医嘱资料
        /// </summary>
        public string SqlQueryPatientAdvices = @"
SELECT HA.HT_ADVICE_ID AS PAID,
 HA.INHOS_ID AS INHOSID,
 HA.GM_ADVICE_ID AS ADVICEID,
 HA.PATIENT_ILLFILED_NAME AS PATIENTILLFIELD,
 HA.PATIENT_OFFICE_NAME AS PATIENTOFFICE,
 (SELECT GC.NAME FROM GM_CODE GC WHERE GC.CODE = HA.STANDING_FLAG) AS STANDINGFLAG,
 (SELECT GC.NAME FROM GM_CODE GC WHERE GC.CODE = HA.ADVICE_TYPE_CODE) AS ADVICETYPE,
 HA.ADVICE_NAME AS ADVICENAME,
 HA.COMMON_NAME AS COMMONNAME,
 HA.ADVICE_SHOW_NAME AS ADVICESHOWNAME,
 HA.GROUP_INDEX AS VIEWGROUP,
 HA.GROUP_INDEX AS GROUPINDEX,
 HA.SPEC AS SPEC,
 NVL2(HA.DOSAGE, HA.DOSAGE||HA.DOSAGE_UNIT,'') AS DOSAGE,
 HA.USAGE_NAME AS USAGE,
 HA.FREQUENCY_NAME AS FREQUENCE,
 HA.MEMO AS MEMO,
 HA.LIST_DOCTOR_NAME AS LISTDOCTOR,
 HA.LIST_OFFICE_NAME AS LISTDOCTOROFFICE,
 TO_CHAR(HA.LIST_DATE,'YYYY-MM-DD HH24:MI:SS') AS LISTDATE,
 TO_CHAR(HA.PRE_START_TIME,'YYYY-MM-DD HH24:MI:SS') AS PRESTARTDATE,
 TO_CHAR(HA.PRE_START_TIME,'YYYY-MM-DD HH24:MI:SS') AS PRESTOPDATE,
 HA.STOP_DOCTOR_NAME AS STOPDOCTOR,
 TO_CHAR(HA.STOP_DATE,'YYYY-MM-DD HH24:MI:SS') AS STOPDATE,
 HA.AUDIT_NURSE_NAME AS AUDITNURSE,
 TO_CHAR(HA.AUDIT_TIME,'YYYY-MM-DD HH24:MI:SS') AS AUDITDATE,
 HA.STOP_AUDIT_NURSE_NAME  AS STOPAUDITNURSE,
 TO_CHAR(HA.STOP_AUDIT_TIME,'YYYY-MM-DD HH24:MI:SS') AS STOPAUDITDATE,
 (SELECT GC.NAME FROM GM_CODE GC WHERE GC.CODE = HA.ADVICE_STATUS) AS ADVICESTATUS {0}
FROM HT_ADVICE HA
WHERE HA.HT_ADVICE_ID = :1";
        /// <summary>
        /// 膳食化验附加信息
        /// </summary>
        string SqlQueryAdviceAdditionInfo = @"SELECT HA.HT_ADVICE_ID, HA.ADVICE_TYPE_CODE, HAI.INFO_NAME
  FROM HT_ADVICE HA, HT_ADVICE_ADDITIONAL_INFO HAI, HM_PATIENT HP
 WHERE HA.INHOS_ID = HP.INHOS_ID
   AND HP.INHOS_PATIENT_STATUS = 600011
   AND HA.ADVICE_TYPE_CODE IN (901010, 901004)
   AND HA.HT_ADVICE_ID = HAI.HT_ADVICE_ID";
        #endregion

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
    }
}
