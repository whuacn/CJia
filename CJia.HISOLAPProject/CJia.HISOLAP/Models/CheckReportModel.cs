using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HISOLAP.Models
{
    public class CheckReportModel : Tools.Model
    {
        /// <summary>
        /// 获得审核类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckType()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckType);
            return dtResult;
        }
        /// <summary>
        /// 根据入病案时间查询出院病人信息（查询今创数据库视图）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetPatient(DateTime start, DateTime end)
        {
            Tools.DBConnHelper.DBSwitchover(Tools.DBType.JJFBDB);
            object[] sqlParams = new object[] { start, end };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryPatient, sqlParams);
            Tools.DBConnHelper.DBSwitchover(Tools.DBType.HQMSDB);
            return dtResult;
        }
        /// <summary>
        /// 根据入病案时间查询本地数据病人信息
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetMyPatient(DateTime start, DateTime end)
        {
            object[] sqlParams = new object[] { start, end };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryMyPatientByDate, sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 获得有效的审核脚本
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllScript()
        {
            string sql = string.Format(SqlTools.SqlQueryCheckScript, " and t.status='1' ");
            DataTable dtResult = CJia.DefaultOleDb.Query(sql);
            return dtResult;
        }
        /// <summary>
        /// 根据病案号和住院次数在本地库中查询是否有此病人
        /// </summary>
        /// <param name="recordNO"></param>
        /// <param name="inHosTimes"></param>
        /// <returns></returns>
        public DataTable GetMyPatient(string recordNO, string inHosTimes)
        {
            object[] sqlParams = new object[] { recordNO, inHosTimes };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryMyPatient, sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 根据病案号和住院次数在视图中查询是否有此病人
        /// </summary>
        /// <param name="recordNO"></param>
        /// <param name="inHosTimes"></param>
        /// <param name="onther">另外的条件</param>
        /// <returns></returns>
        public DataTable GetPatientInView(string recordNO, string inHosTimes, string onther)
        {
            object[] sqlParams = new object[] { recordNO, inHosTimes };
            if (onther != null && onther.Length > 0)
            {
                onther = " and " + onther;
            }
            else
            {
                onther = "";
            }
            string sql = string.Format(SqlTools.SqlQueryPatientInView, onther);
            DataTable dtResult = CJia.DefaultOleDb.Query(sql, sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 将审核通过的病案插入主表中
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool AddPatient(DataRow dr)
        {
            object[] sqlParams = dr.ItemArray;
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertPatientCheck, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 将上报成功的病案插入主表
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool AddPatient(string transID, DataRow dr)
        {
            object[] sqlParams = dr.ItemArray;
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertPatientReport, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改病人审核状态为审核通过
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="recordNO"></param>
        /// <param name="inHosTimes"></param>
        /// <returns></returns>
        public bool ModifyPatientCheckState(string recordNO, string inHosTimes)
        {
            object[] sqlParams = new object[] { recordNO, inHosTimes };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdatePatientCheckState, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改病人上报状态为上报成功
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="recordNO"></param>
        /// <param name="inHosTimes"></param>
        /// <returns></returns>
        public bool ModifyPatientReportState(string transID, string recordNO, string inHosTimes)
        {
            object[] sqlParams = new object[] { recordNO, inHosTimes };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdatePatientReportState, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除临时表中数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteTable()
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteTable) > 0 ? true : false;
        }
        /// <summary>
        /// 插入临时表
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool AddInToTemp(DataRow dr)
        {
            object[] sqlParams = dr.ItemArray;
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertInTimeTable, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 主表和临时表关联，查出需要审核的病案
        /// </summary>
        /// <returns></returns>
        public DataTable GetTempPatient()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTempData);
            return dtResult;
        }
        public long GetCheckResult(string recordNO, string inHosTimes)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("I_P3", recordNO);
            parms.Add("I_P2", inHosTimes);
            parms.Add("O_FLAG", "");
            CJia.DefaultOleDb.ExecuteProcedure("SP_HQMS_CHECK", ref parms);
            string result = parms["O_FLAG"].ToString();
            return long.Parse(result);
        }
    }
}
