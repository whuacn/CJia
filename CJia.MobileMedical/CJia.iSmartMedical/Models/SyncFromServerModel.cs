using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class SyncFromServerModel : ModelBase, IModel
    {
        #region 1.同步病人
        /// <summary>
        /// 获取当前设备最新的住院病人信息
        /// 1.根据在设备启用时设定的所属科室，将该科室所有住院病人加入到iDevicePatient表中
        /// 2.同时从iDevicePatient表中移除已出院的病人
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        async Task<List<Patient>> SyncDevicePatientsFromServer()
        {
            object Result = await RemoteExcute(new object[] { iCommon.DeviceID });
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
                    conn.Insert(advice);
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
                    conn.Insert(doc);
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
                    conn.Insert(checkLog);
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
                    conn.Insert(fee);
                }
                foreach (PatientPrepay prepay in prepayList)
                {
                    conn.Insert(prepay);
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

        #region 9.同步病人数据
        /// <summary>
        /// 同步设备病人数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SyncDeviceDataFromServer()
        {
            return await QueryDeviceChangeTable();
        }
        /// <summary>
        /// 查询有变化的数据表
        /// </summary>
        /// <returns></returns>
        private async Task<bool> QueryDeviceChangeTable()
        {
            string isInitData;
            List<string> TableList = new List<string>();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDeviceTableChange]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                List<Data.iDeviceTableChange> TableChangeList = cmd.ExecuteQuery<Data.iDeviceTableChange>();
                foreach (Data.iDeviceTableChange itc in TableChangeList)
                {
                    TableList.Add(itc.TableName + "|" + itc.LastChangeDate);
                }
                isInitData = TableChangeList.Count == 0 ? "0" : "1"; //0:表示初始数据（新安装）1：表示正常数据同步
            }

            object Result = await RemoteExcute(new object[] { iCommon.DeviceID, TableList.ToArray() });
            List<Data.iDeviceTableChange> ChangeTableList = Deserialize<Data.iDeviceTableChange>(Result as byte[]);
            if (ChangeTableList == null) return false;

            return await SyncDeviceDataFromServer(ChangeTableList, isInitData);
        }
        /// <summary>
        /// 从服务器同步有变化的数据到本地
        /// </summary>
        /// <param name="ChangeTableList"></param>
        /// <returns></returns>
        private async Task<bool> SyncDeviceDataFromServer(List<Data.iDeviceTableChange> ChangeTableList, string IsInitData)
        {
            CheckLogSyncEventArgs CheckLogArg = null;
            foreach (Data.iDeviceTableChange itc in ChangeTableList)
            {
                object Result = await RemoteExcute(new object[] { iCommon.DeviceID, itc.TableName, itc.PrimaryKey, IsInitData });
                if (Result == null) continue;
                List<Data.DataObject> DataList = Deserialize<Data.DataObject>(Result as byte[]);
                if (DataList == null || DataList.Count == 0)
                {
                    if (IsInitData == "0")
                    {
                        using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
                        {
                            conn.Insert(itc);
                        }
                    }
                    continue; 
                }

                string[] SqlSyncToLocal = BuildSyncScript(itc.TableName, itc.PrimaryKey, DataList);

                await SyncDataToLocal(SqlSyncToLocal[0], SqlSyncToLocal[1], DataList, itc);
            }
            return true;
        }

        private async Task<bool> SyncDataToLocal(string SqlDelete, string SqlInsert, List<Data.DataObject> DataList, Data.iDeviceTableChange itc)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                try
                {
                    EventArgs Arg = UpdateLocalData(conn, SqlDelete, SqlInsert, DataList, itc.TableName, itc.PrimaryKey);
                    conn.Delete(itc); conn.Insert(itc);
                    //更新服务器上该设备的同步日志，确保下次不再同步
                    bool isSaveSuccess = await SaveDeviceSyncLog(iCommon.DeviceID, itc.TableName, itc.LastChangeDate);
                    if (isSaveSuccess)
                    {
                        conn.Commit();
                        if (itc.TableName == "DoctorCheckLog")
                        {
                            iCommon.OnCheckLogSyncComplet(Arg);
                        }
                    }
                    else
                    {
                        conn.Rollback();
                        return false;
                    }
                }
                catch
                {
                    conn.Rollback();
                    return false;
                }
            }
            return true;
        }

        private EventArgs UpdateLocalData(SQLite.SQLiteConnection conn, string SqlDelete, string SqlInsert, List<Data.DataObject> DataList, string TableName, string PrimaryKey)
        {
            SQLite.SQLiteCommand cmdDelete = conn.CreateCommand(SqlDelete);
            SQLite.SQLiteCommand cmdInsert = conn.CreateCommand(SqlInsert);
            dynamic arg = null;
            if (TableName == "DoctorCheckLog") arg = new CheckLogSyncEventArgs();
            foreach (Data.DataObject data in DataList)
            {
                cmdDelete.ClearBindings();
                cmdInsert.ClearBindings();
                cmdDelete.Bind(data.GetExtValue(PrimaryKey));
                cmdDelete.ExecuteNonQuery();
                if (data.GetExtValue("ChangeType") != "DELETE")
                {
                    for (int d = 0; d < data.Data.Length - 1; d++)
                    {
                        cmdInsert.Bind(data.Data[d]);
                    }
                    cmdInsert.ExecuteNonQuery();
                }
                if (TableName == "DoctorCheckLog")
                {
                    arg.DCLID.Add(data.GetExtValue(PrimaryKey));
                    arg.InhosID.Add(data.GetExtValue("InhosID"));
                    arg.ChangeType.Add(data.GetExtValue("ChangeType"));
                    arg.MedicalLog.Add(data.GetExtBytes("MedicalLog"));
                    arg.PhotoLog.Add(data.GetExtBytes("Photo"));
                }
            }
            return arg;
        }

        private string[] BuildSyncScript(string TableName, string PrimaryKey, List<Data.DataObject> DataList)
        {
            string SqlDelete = String.Format(@"Delete From {0} Where {1}=?", TableName, PrimaryKey);
            Data.DataObject bo = DataList[0];
            string[] Fields = bo.FieldArray;
            string SqlInsert = "Insert Into " + TableName + " (";
            string txtParams = " (";
            for (int i = 0; i < Fields.Length - 1; i++)
            {
                SqlInsert += Fields[i] + ",";
                txtParams += "?,";
            }
            SqlInsert = SqlInsert.TrimEnd(',');
            txtParams = txtParams.TrimEnd(',');
            SqlInsert = SqlInsert + ") Values " + txtParams + ")";
            return new string[] { SqlDelete, SqlInsert };
        }

        private async Task<bool> SaveDeviceSyncLog(string DeviceID, string TableName, string LastChangeDate)
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
            var ServerPatientList = await SyncDevicePatientsFromServer();
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
