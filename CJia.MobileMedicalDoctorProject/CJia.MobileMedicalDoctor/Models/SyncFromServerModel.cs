using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class SyncFromServerModel : ModelBase, IModel
    {
        #region 1.同步病人
        /// <summary>
        /// 获取医生的最新最全的病人列表(从DevicePatients中同步)包括医生的床位病人及科室病人
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        async Task<List<Patient>> SyncDevicePatientsFromServer(string DoctorID, string OfficeID)
        {
            object Result = await RemoteExcute(new object[] { DoctorID, OfficeID, iCommon.DeviceID });
            List<Patient> DataList = Deserialize<Patient>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 存储医生的病人列表到本地设备，有则更新，无则新增；
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="NewPatientList"></param>
        public void SyncDevicePatientsToLocal(List<Patient> PatientList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (Patient patient in PatientList)
                {
                    var existPatient = conn.Table<Patient>().Where(p => p.InhosID == patient.InhosID).SingleOrDefault();
                    if (existPatient == null)
                    {
                        conn.Insert(patient);
                    }
                    else
                    {
                        conn.Update(patient);
                    }
                }
                conn.Commit();
            }
        }
        #endregion

        #region 2.同步医嘱
        /// <summary>
        /// 查询病人住院医嘱信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        async Task<List<Data.PatientAdvices>> QueryPatientAdvices(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<PatientAdvices> DataList = Deserialize<PatientAdvices>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 将服务器最新医嘱与本地医嘱比较，同步至最新状态
        /// </summary>
        /// <param name="AdviceList"></param>
        /// <returns></returns>
        bool SyncPatientAdvicesToLocal(List<Data.PatientAdvices> AdviceList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (PatientAdvices advice in AdviceList)
                {
                    if (advice.GroupIndex != "0")
                    {
                        List<PatientAdvices> groupList = conn.Query<PatientAdvices>("Select * From [PatientAdvices] Where [InhosID]=? And [GroupIndex]=?", advice.InhosID, advice.GroupIndex);
                        if (groupList.Count == 1)
                        {
                            groupList[0].AdviceShowName += Environment.NewLine + advice.AdviceName + " (" + advice.Spec + ") " + advice.Dosage;
                            conn.Update(groupList[0]);
                            continue;
                        }
                    }
                    var existAdvice = conn.Table<PatientAdvices>().Where(pa => pa.PAID == advice.PAID).SingleOrDefault();
                    if (existAdvice == null)
                    {//判断此医嘱在本地是否存在
                        conn.Insert(advice);
                    }
                    else
                    {
                        conn.Update(advice);
                    }
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 3.同步检查报告
        /// <summary>
        /// 查询检查报告
        /// </summary>
        async Task<List<Data.CheckApply>> QueryCheckApply(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<CheckApply> DataList = Deserialize<CheckApply>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 查询检查报告结果
        /// </summary>
        async Task<List<Data.CheckResult>> QueryCheckResult(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<CheckResult> DataList = Deserialize<CheckResult>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 同步检查报告结果到本地
        /// </summary>
        /// <param name="ApplyList"></param>
        /// <param name="ResultList"></param>
        /// <returns></returns>
        bool SyncCheckReportToLocal(List<Data.CheckApply> ApplyList, List<Data.CheckResult> ResultList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (CheckApply ca in ApplyList)
                {
                    conn.Insert(ca);
                }
                foreach (CheckResult cr in ResultList)
                {
                    conn.Insert(cr);
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 4.同步病历文书
        /// <summary>
        /// 查询病人病历文书信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        async Task<List<Data.PatientEmrDoc>> QueryPatientEmrDoc(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<PatientEmrDoc> DataList = Deserialize<PatientEmrDoc>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 将服务器最新病历文书与本地文书比较，同步至最新状态
        /// </summary>
        /// <param name="AdviceList"></param>
        /// <returns></returns>
        bool SyncPatientEmrDocToLocal(List<Data.PatientEmrDoc> DocList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (PatientEmrDoc doc in DocList)
                {
                    var existDoc = conn.Table<PatientEmrDoc>().Where(ed => ed.InhosID == doc.InhosID && ed.SectionNo == doc.SectionNo).SingleOrDefault();
                    if (existDoc == null)
                    {//判断此文书在本地是否存在
                        conn.Insert(doc);
                    }
                    else
                    {
                        conn.Update(doc);
                    }
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 5.同步化验报告
        /// <summary>
        /// 查询病人LIS医嘱
        /// </summary>
        /// <param name="IllcaseNo">住院号</param>
        async Task<List<Data.LisAdvice>> QueryLisAdvice(string IllcaseNo)
        {
            object Result = await RemoteExcute(new object[] { IllcaseNo, iCommon.DeviceID });
            List<LisAdvice> DataList = Deserialize<LisAdvice>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 查询病人LIS结果
        /// </summary>
        /// <param name="IllcaseNo">住院号</param>
        async Task<List<Data.LisResult>> QueryLisResult(string IllcaseNo)
        {
            object Result = await RemoteExcute(new object[] { IllcaseNo, iCommon.DeviceID });
            List<LisResult> DataList = Deserialize<LisResult>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 将服务器最新Lis医嘱和结果与本地Lis医嘱和结果比较，同步至最新状态
        /// </summary>
        /// <param name="adviceList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        bool SyncPatientLisAdviceResultToLocal(List<LisAdvice> adviceList, List<LisResult> resultList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();

                foreach (LisAdvice advice in adviceList)
                {
                    conn.Insert(advice);
                }

                foreach (LisResult result in resultList)
                {
                    conn.Insert(result);
                }

                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 6.同步查房日志
        /// <summary>
        /// 查询病人的查房日志
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        async Task<List<Data.DoctorCheckLog>> QueryDoctorCheckLog(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<DoctorCheckLog> DataList = Deserialize<DoctorCheckLog>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 同步查房日志及明细到本地
        /// </summary>
        /// <param name="LogList"></param>
        /// <param name="LogDetail"></param>
        /// <returns></returns>
        bool SyncDoctorCheckLogToLocal(List<Data.DoctorCheckLog> LogList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (DoctorCheckLog checkLog in LogList)
                {
                    var existLog = conn.Table<DoctorCheckLog>().Where(dcl => dcl.DCLID == checkLog.DCLID).SingleOrDefault();
                    if (existLog == null)
                    {//判断此日志在本地是否存在
                        conn.Insert(checkLog);
                    }
                    else
                    {
                        conn.Update(checkLog);
                    }
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 7.同步病人费用
        /// <summary>
        /// 查询病人费用信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        async Task<List<Data.PatientFee>> QueryPatientFee(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<PatientFee> DataList = Deserialize<PatientFee>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 查询病人预交款
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        async Task<List<Data.PatientPrepay>> QueryPatientPrepay(string InhosID)
        {
            object Result = await RemoteExcute(new object[] { InhosID, iCommon.DeviceID });
            List<PatientPrepay> DataList = Deserialize<PatientPrepay>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 将服务器最新费用信息与本地数据比较，同步至最新状态
        /// </summary>
        /// <param name="adviceList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        bool SyncDevicePatientFeeToLocal(List<Data.PatientFee> feeList, List<Data.PatientPrepay> prepayList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (PatientFee fee in feeList)
                {
                    var existFee = conn.Table<PatientFee>().Where(f => f.InhosID == fee.InhosID && f.FeeTypeCode == fee.FeeTypeCode).SingleOrDefault();
                    if (existFee == null)
                    {
                        conn.Insert(fee);
                    }
                    else
                    {
                        conn.Update(fee);
                    }
                }
                foreach (PatientPrepay prepay in prepayList)
                {
                    var existPrepay = conn.Table<PatientPrepay>().Where(pp => pp.InhosID == prepay.InhosID && pp.PayDate == prepay.PayDate).SingleOrDefault();
                    if (existPrepay == null)
                    {
                        conn.Insert(prepay);
                    }
                    else
                    {
                        conn.Update(prepay);
                    }
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 8.同步静态数据
        /// <summary>
        /// 同步静态数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SyncStaticDataFromServer()
        {
            return await QueryChangeTable();
        }
        /// <summary>
        /// 查询有变化的数据表
        /// </summary>
        /// <returns></returns>
        private async Task<bool> QueryChangeTable()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iTableChange]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                List<string> TableList = new List<string>();
                List<Data.iTableChange> TableChangeList = cmd.ExecuteQuery<Data.iTableChange>();
                foreach (Data.iTableChange itc in TableChangeList)
                {
                    TableList.Add(itc.TableName + "|" + itc.LastChangeDate);
                }
                string isInitData = TableChangeList.Count == 0 ? "0" : "1"; //0:表示初始数据（新安装）1：表示正常数据同步
                object Result = await RemoteExcute(new object[] { TableList.ToArray() });
                List<Data.iTableChange> ChangeTableList = Deserialize<Data.iTableChange>(Result as byte[]);
                if (ChangeTableList == null) return false;

                return await SyncDataFromServer(ChangeTableList, conn, isInitData);
            }
        }
        /// <summary>
        /// 从服务器同步有变化的数据到本地
        /// </summary>
        /// <param name="ChangeTableList"></param>
        /// <returns></returns>
        private async Task<bool> SyncDataFromServer(List<Data.iTableChange> ChangeTableList, SQLite.SQLiteConnection conn, string IsInitData)
        {
            foreach (Data.iTableChange itc in ChangeTableList)
            {
                object Result = await RemoteExcute(new object[] { iCommon.DeviceID, itc.TableName, itc.PrimaryKey, IsInitData });
                if (Result == null) continue;
                List<Data.DataObject> DataList = Deserialize<Data.DataObject>(Result as byte[]);
                if (DataList == null || DataList.Count == 0) continue;

                string SqlDelete = String.Format(@"Delete From {0} Where {1}=?", itc.TableName, itc.PrimaryKey);
                Data.DataObject bo = DataList[0];
                string[] Fields = bo.FieldArray;
                string SqlInsert = "Insert Into " + itc.TableName + " (";
                string txtParams = " (";
                for (int i = 0; i < Fields.Length - 1; i++)
                {
                    SqlInsert += Fields[i] + ",";
                    txtParams += "?,";
                }
                SqlInsert = SqlInsert.TrimEnd(',');
                txtParams = txtParams.TrimEnd(',');
                SqlInsert = SqlInsert + ") Values " + txtParams + ")";
                conn.BeginTransaction();
                try
                {
                    SQLite.SQLiteCommand cmdDelete = conn.CreateCommand(SqlDelete);
                    SQLite.SQLiteCommand cmdInsert = conn.CreateCommand(SqlInsert);
                    foreach (Data.DataObject data in DataList)
                    {
                        cmdDelete.ClearBindings();
                        cmdInsert.ClearBindings();
                        cmdDelete.Bind(data.GetExtValue(itc.PrimaryKey));
                        cmdDelete.ExecuteNonQuery();
                        if (data.GetExtValue("ChangeType") != "DELETE")
                        {
                            for (int d = 0; d < data.Data.Length - 1; d++)
                            {
                                cmdInsert.Bind(data.Data[d]);
                            }
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                    conn.Delete(itc);
                    conn.Insert(itc);
                    bool isSaveSuccess = await SavePadSyncLog(iCommon.DeviceID, itc.TableName, itc.LastChangeDate);
                    if (isSaveSuccess)
                        conn.Commit();
                    else
                        conn.Rollback();
                }
                catch (Exception ex)
                {
                    conn.Rollback();
                }
            }
            return true;
        }

        private async Task<bool> SavePadSyncLog(string DeviceID, string TableName, string LastChangeDate)
        {
            var Result = await RemoteExcute(new object[] { DeviceID, TableName, LastChangeDate });
            return (bool)Result;
        }
        #endregion

        #region 数据同步
        //同步设备病人
        public async Task<bool> SyncDevicePatients()
        {
            if (!iCommon.IsConnected) return false;
            //网络连通则从服务器同步病人资料，保证本地资料最新
            var ServerPatientList = await SyncDevicePatientsFromServer(iCommon.DoctorID, iCommon.LoginUser.DeptID);
            if (ServerPatientList != null && ServerPatientList.Count > 0)
            {//若有新病人，则同步到设备中
                SyncDevicePatientsToLocal(ServerPatientList);
            }
            return true;
        }
        //同步病人医嘱
        public async Task<bool> SyncDevicePatientAdvice(string InhosID)
        {
            if (!iCommon.IsConnected) return false;
            var ServerDataList = await QueryPatientAdvices(InhosID);
            if (ServerDataList != null && ServerDataList.Count > 0)
            {
                SyncPatientAdvicesToLocal(ServerDataList);
            }
            return true;
        }
        //同步病人检查报告
        public async Task<bool> SyncDevicePatientCheckReport(string InhosID)
        {
            //同步检查报告及结果到本地库
            List<Data.CheckApply> ApplyList = await QueryCheckApply(InhosID);
            List<Data.CheckResult> ResultList = await QueryCheckResult(InhosID);
            SyncCheckReportToLocal(ApplyList, ResultList);
            return true;
        }
        //同步病人医嘱
        public async Task<bool> SyncDevicePatientEmrDoc(string InhosID)
        {
            if (!iCommon.IsConnected) return false;
            var ServerDataList = await QueryPatientEmrDoc(InhosID);
            if (ServerDataList != null && ServerDataList.Count > 0)
            {
                SyncPatientEmrDocToLocal(ServerDataList);
            }
            return true;
        }
        //同步病人化验报告
        public async Task<bool> SyncDevicePatientLisAdviceResult(string IllcaseNo)
        {
            if (!iCommon.IsConnected) return false;
            var LisAdvice = await QueryLisAdvice(IllcaseNo);
            var LisResult = await QueryLisResult(IllcaseNo);
            SyncPatientLisAdviceResultToLocal(LisAdvice, LisResult);
            return true;
        }
        //同步医生查房日志
        public async Task<bool> SyncDeviceDoctorCheckLog(string InhosID)
        {
            if (!iCommon.IsConnected) return false;
            var ServerDataList = await QueryDoctorCheckLog(InhosID);
            if (ServerDataList != null && ServerDataList.Count > 0)
            {
                SyncDoctorCheckLogToLocal(ServerDataList);
            }
            return true;
        }
        //同步病人费用
        public async Task<bool> SyncDevicePatientFee(string InhosID)
        {
            if (!iCommon.IsConnected) return false;
            var FeeList = await QueryPatientFee(InhosID);
            var PrePayList = await QueryPatientPrepay(InhosID);
            SyncDevicePatientFeeToLocal(FeeList, PrePayList);
            return true;
        }
        #endregion
    }
}
