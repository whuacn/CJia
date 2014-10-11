using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CJia.Net.Service;
using CJia.Net.Threading;
using CJia.Net.Data;
using System.Data;

namespace CJia.Net.Business.MobileMedical
{
    /// <summary>
    /// 医生查房业务实现
    /// </summary>
    public class Doctor : CJiaService, CJia.Net.Service.MobileMedical.IDoctor
    {
        #region 设备相关
        /// <summary>
        /// 从服务器数据库检索当前设备信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryServerDeviceInfo(string DeviceID)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryServerDeviceInfo, new object[] { DeviceID });
        }
        /// <summary>
        /// 从服务器数据库检索当前设备所属科室信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryServerDeviceOfficeInfo(string DeviceID)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryServerDeviceOfficeInfo, new object[] { DeviceID });
        }
        /// <summary>
        /// 保存设备信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="DeviceName"></param>
        /// <param name="Notes"></param>
        /// <param name="Status"></param>
        /// <param name="OfficeIDs"></param>
        /// <returns></returns>
        public bool SaveDeviceInfo(string DeviceID, string DeviceName, string Notes, string Status, string[] OfficeIDs, string[] OfficeNames)
        {
            string Count = CJia.Net.Data.DefaultSQLite.QueryScalar(SqlText.SqlQueryServerDeviceCount, new object[] { DeviceID });
            string TransID = CJia.Net.Data.DefaultSQLite.BeginTransaction();
            try
            {
                if (Count == "0")
                {
                    CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlSaveDeviceInfo, new object[] { DeviceID, DeviceName, Notes, Status, Common.DateNow, Common.DateNow }, TransID);
                }
                else
                {
                    CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlUpdateDeviceInfo, new object[] { DeviceName, Notes, Status, Common.DateNow, DeviceID }, TransID);
                }
                //删除设备所属科室
                CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlDeleteDeviceOffice, new object[] { DeviceID }, TransID);
                //删除设备病人列表
                CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlDeleteDevicePatient, new object[] { DeviceID }, TransID);
                string DOID = ""; string OfficeID, OfficeName;
                for (int i = 0; i < OfficeIDs.Length; i++)
                {
                    DOID = Guid.NewGuid().ToString();
                    OfficeID = OfficeIDs[i];
                    OfficeName = OfficeNames[i];
                    CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlSaveDeviceOffice, new object[] { DOID, DeviceID, OfficeID, OfficeName, Common.DateNow }, TransID);
                    CJia.Net.Data.DefaultSQLite.Execute(SqlText.SqlSaveDevicePatient, new object[] { DeviceID, Common.DateNow, OfficeID }, TransID);
                }
                CJia.Net.Data.DefaultSQLite.CommitTransaction(TransID);
                return true;
            }
            catch
            {
                CJia.Net.Data.DefaultSQLite.RollbackTransaction(TransID);
                return false;
            }
        }
        #endregion

        #region 科室相关
        /// <summary>
        /// 查询科室信息
        /// </summary>
        /// <returns></returns>
        public byte[] QueryServerDept()
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryDept);
        }
        /// <summary>
        /// 查询病区科室关联信息
        /// </summary>
        /// <returns></returns>
        public byte[] QueryServerIllfieldDept()
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryIllfieldDept);
        }
        #endregion

        #region 病人相关
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserCode">工号</param>
        /// <param name="Password">密码</param>
        /// <param name="ClientTag">客户端信息</param>
        public byte[] Login(string UserCode, string Password, string ClientTag)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryUserForLogin, new object[] { UserCode, Password });
        }

        /// <summary>
        /// 获取病区病人列表
        /// </summary>
        /// <param name="IllfieldID"></param>
        /// <returns></returns>
        public byte[] QueryIllfieldPatientList(string IllfieldID)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryIllfieldPatientList, new object[] { IllfieldID });
        }
        /// <summary>
        /// 获取医生值班病区列表
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public byte[] QueryDoctorDutyIllfield(string DoctorID)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryDoctorDutyIllfield, new object[] { DoctorID });
        }
        /// <summary>
        /// 查询服务器上该设备的病人列表（iDevicePatient表中的数据为正住院的病人）
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] SyncDevicePatientsFromServer(string DeviceID)
        {
            byte[] DoctorPatientList = DefaultSQLite.Query(SqlText.SqlQueryDoctorPatientListToSync, new object[] { DeviceID });
            return DoctorPatientList;
        }
        #endregion

        #region 医嘱相关
        /// <summary>
        /// 查询病人住院医嘱信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        /// <returns></returns>
        public byte[] QueryPatientAdvices(string InhosID, string DeviceID)
        {
            if (!String.IsNullOrEmpty(InhosID))
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryPatientAdvices, new object[] { InhosID });
            else
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryDevicePatientAdvices, new object[] { DeviceID });
        }
        #endregion

        #region 查房日志
        /// <summary>
        /// 查询某病人的查房日志
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryDoctorCheckLog(string InhosID, string DeviceID)
        {
            if (String.IsNullOrEmpty(InhosID))
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryDevicePatientCheckLogList, new object[] { DeviceID });
            else
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryPatientCheckLogList, new object[] { InhosID });
        }
        /// <summary>
        /// 查询病人查房影像数据
        /// </summary>
        /// <param name="InhosID"></param>
        /// <returns></returns>
        public byte[] QueryPatientCheckImages(string InhosID)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryPatientCheckImageList, new object[] { InhosID });
        }
        #endregion

        #region 数据同步
        /// <summary>
        /// 同步本地数据到服务器
        /// </summary>
        /// <returns></returns>
        public bool SyncLocalData(string TableName, string KeyField, string KeyValue, string ChangeType, string ChangeDate, string[] Fields, object[] Data)
        {
            string SqlSync = "";
            switch (ChangeType)
            {
                case "INSERT": SqlSync = BuildInsertSyncScript(TableName, Fields); break;
                case "UPDATE": SqlSync = BuildUpdateSyncScript(TableName, KeyField, KeyValue, Fields); break;
                case "DELETE": SqlSync = BuildDeleteSyncScript(TableName, KeyField, KeyValue); break;
                default: return false;
            }
            if (TableName == "[PadAdvice]") Common.PadAdviceLastChangeDate = Common.DateNow;
            CJia.Net.Data.DefaultSQLite.Execute(SqlSync, Data);
            return true;
        }
        string BuildInsertSyncScript(string TableName, string[] Fields)
        {
            string SqlText = "Insert Into {0} ({1}) Values ({2})";
            string field = "", values = "";
            for (int i = 0; i < Fields.Length; i++)
            {
                field += Fields[i] + ",";
                values += "@" + (i + 1).ToString() + ",";
            }
            field = field.TrimEnd(',');
            values = values.TrimEnd(',');
            return String.Format(SqlText, TableName, field, values);
        }
        string BuildUpdateSyncScript(string TableName, string KeyField, string KeyValue, string[] Fields)
        {
            string SqlText = "Update {0} Set {1} Where {2}='{3}'";
            string setScript = "";
            for (int i = 0; i < Fields.Length; i++)
            {
                setScript += Fields[i] + "=@" + (i + 1).ToString() + ",";
            }
            setScript = setScript.TrimEnd(',');
            return String.Format(SqlText, TableName, setScript, KeyField, KeyValue);
        }
        string BuildDeleteSyncScript(string TableName, string KeyField, string KeyValue)
        {
            string SqlText = "Delete From {0} Where {1}='{2}'";

            return String.Format(SqlText, TableName, KeyField, KeyValue);
        }
        #endregion

        #region 病历文书
        /// <summary>
        /// 查询病人的病历文书
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryPatientEmrDoc(string InhosID, string DeviceID)
        {
            if (!String.IsNullOrEmpty(InhosID))
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryPatientEmrDoc, new object[] { InhosID });
            else
                return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryDevicePatientEmrDoc, new object[] { DeviceID });
        }
        #endregion

        #region 代码
        /// <summary>
        /// 查询代码信息
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public byte[] QueryCodeList(string Group)
        {
            return CJia.Net.Data.DefaultSQLite.Query(SqlText.SqlQueryCodeList, new object[] { Group });
        }
        #endregion

        #region LIS结果
        /// <summary>
        /// 查询LIS医嘱信息
        /// </summary>
        /// <param name="IllcaseNo"></param>
        /// <returns></returns>
        public byte[] QueryLisAdvice(string IllcaseNo, string DeviceID)
        {
            if (String.IsNullOrEmpty(IllcaseNo))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDeviceLisAdvice, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryLisAdvice, new object[] { IllcaseNo });
        }
        /// <summary>
        /// 查询LIS结果信息
        /// </summary>
        /// <param name="IllcaseNo"></param>
        /// <returns></returns>
        public byte[] QueryLisResult(string IllcaseNo, string DeviceID)
        {
            if (String.IsNullOrEmpty(IllcaseNo))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDeviceLisResult, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryLisResult, new object[] { IllcaseNo });
        }
        #endregion

        #region 费用信息
        /// <summary>
        /// 查询病人费用信息
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryPatientFee(string InhosID, string DeviceID)
        {
            if (String.IsNullOrEmpty(InhosID))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDevicePatientFee, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryPatientFee, new object[] { InhosID });
        }
        /// <summary>
        /// 查询病人预交款
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryPatientPrepay(string InhosID, string DeviceID)
        {
            if (String.IsNullOrEmpty(InhosID))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDevicePatientPrepay, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryPatientPrepay, new object[] { InhosID });
        }
        #endregion

        #region 医嘱录入
        /// <summary>
        /// 查询医嘱子类别
        /// </summary>
        /// <param name="AdviceTypeID"></param>
        /// <returns></returns>
        public byte[] QuerySubTypeList(string AdviceTypeID)
        {
            return Data.DefaultSQLite.Query(SqlText.SqlQuerySubTypeList, new object[] { AdviceTypeID });
        }
        #endregion

        #region 服务器到Pad同步
        /// <summary>
        /// 查询有变化的数据表
        /// </summary>
        /// <param name="PadTableChangeList"></param>
        /// <returns></returns>
        public byte[] QueryChangeTable(string[] PadTableChangeList)
        {
            DataTable dtChange = Data.DefaultSQLite.QueryTable(SqlText.SqlQueryTableChangeList);
            string TableName, LastChangeDate = "";
            string ChangeTableList = "";
            foreach (DataRow dr in dtChange.Rows)
            {
                TableName = dr["TableName"].ToString();
                LastChangeDate = dr["LastChangeDate"].ToString();
                if (!PadTableChangeList.Contains<string>(TableName + "|" + LastChangeDate))
                {
                    ChangeTableList += "'" + TableName + "',";
                }
            }
            if (ChangeTableList.Length > 0)
            {
                ChangeTableList = ChangeTableList.Substring(0, ChangeTableList.Length - 1);
                return Data.DefaultSQLite.Query(SqlText.SqlQueryTableChangeList + " Where [TableName] In (" + ChangeTableList + ")");
            }
            return null;
        }
        /// <summary>
        /// 从服务器同步数据到Pad
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="IsInitData"></param>
        /// <returns></returns>
        public byte[] SyncDataFromServer(string DeviceID, string TableName, string PrimaryKey, string IsInitData)
        {
            string SqlData = String.Format(SqlText.SqlQueryChangeDataByDevice, TableName, PrimaryKey);
            return Data.DefaultSQLite.Query(SqlData, new object[] { TableName, DeviceID, TableName, IsInitData });
        }
        /// <summary>
        /// 保存Pad同步日志到服务器
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="TableName"></param>
        /// <param name="LastChangeDate"></param>
        /// <returns></returns>
        public bool SavePadSyncLog(string DeviceID, string TableName, string LastChangeDate)
        {
            try
            {
                string SqlSync = String.Format(SqlText.SqlInsertSyncLogFromServer, DeviceID);
                Data.DefaultSQLite.Execute(SqlSync, new object[] { TableName, LastChangeDate });
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 检查报告
        /// <summary>
        /// 查询检查报告
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryCheckApply(string InhosID, string DeviceID)
        {
            if (String.IsNullOrEmpty(InhosID))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDeviceCheckApply, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryCheckApply, new object[] { InhosID });
        }
        /// <summary>
        /// 查询检查报告结果
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public byte[] QueryCheckResult(string InhosID, string DeviceID)
        {
            if (String.IsNullOrEmpty(InhosID))
                return Data.DefaultSQLite.Query(SqlText.SqlQueryDeviceCheckResult, new object[] { DeviceID });
            else
                return Data.DefaultSQLite.Query(SqlText.SqlQueryCheckResult, new object[] { DeviceID });
        }
        #endregion

        #region IDoctor 成员


        public byte[] SyncDevicePatientsFromServer(string DoctorID, string OfficeID, string DeviceID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
