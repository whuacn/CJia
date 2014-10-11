using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    #region【Login】
    [WebMethod(Description = "登录")]
    public string GetUser(string userCode, string pwd)
    {
        string sql = @"select * from User where code=:1 and password=:2";
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", userCode);
        sqlpar[1] = new SQLiteParameter("2", pwd);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(sql, sqlpar);
            string str = TypeChange.DataTableToXml(dt);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【MainPage】

    [WebMethod(Description = "查询病人个数")]
    public string QueryLoaclDataCount()
    {
        string SqlText = @"Select Count(1) LoacalDataCount From [Patient]";
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlText);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询某医生下(正住院/出院)的病人个数
    /// </summary>
    /// <param name="DoctorID">医生ID</param>
    /// <param name="InhosStatus">住院出院类型</param>
    /// <returns></returns>
    [WebMethod (Description="查询某医生下(正住院/出院)的病人个数")]
    public string QueryMyPatientCount(string DoctorID, string InhosStatus)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DoctorID);
        sqlpar[1] = new SQLiteParameter("2", InhosStatus);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryMyPatientCount, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询某科室下(正住院，出院)的病人个数
    /// </summary>
    /// <param name="DeptId">科室ID</param>
    /// <param name="InhosStatus">住院出院类型</param>
    /// <returns></returns>
    [WebMethod(Description="查询某科室下(正住院，出院)的病人个数")]
    public string QueryDeptPatientCount(string DeptId, string InhosStatus)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DeptId);
        sqlpar[1] = new SQLiteParameter("2", InhosStatus);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryDeptPatientCount, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询某医生下(值班。近期)病人个数"
    /// </summary>
    /// <param name="DoctorID">医生Id</param>
    /// <param name="DPType">值班。近期类型</param>
    /// <returns></returns>
    [WebMethod (Description="查询某医生下(值班。近期)病人个数")]
    public string QueryDoctorPatientCount(string DoctorID, string DPType)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DoctorID);
        sqlpar[1] = new SQLiteParameter("2", DPType);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryDoctorPatientCount, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询医嘱类型不是中药、草药、中成药的医嘱的个数
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description = "查询医嘱类型不是中药、草药、中成药的医嘱的个数")]
    public string NoPharmAdviceCount()
    {
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryNoPharmAdviceCount);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询医嘱类型是中药、草药、中成药的医嘱的个数
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description = "查询医嘱类型是中药、草药、中成药的医嘱的个数")]
    public string PharmAdviceCount()
    {
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryPharmAdviceCount);
            return TypeChange.DataTableToXml(dt);
        }
    }

    //public string GetPatientCount(string DoctorID, string DeptId, string InhosStatus)
    //{
    //    DataTable dt = new DataTable();
    //    dt.Rows.Add(QueryMyPatientCount(DoctorID,InhosStatus).
    //}
    #endregion

    #region【病人列表】
    /// <summary>
    /// 获取医生正在住院/出院的病人列表（在DoctorPatients表中）
    /// </summary>
    /// <param name="DoctorID">医生ID</param>
    /// <param name="InhosStatus">住院/出院</param>
    /// <returns></returns>
    [WebMethod(Description = "获取医生正在住院/出院的病人列表（在DoctorPatients表中）")]
    public string QueryMyPatientList(string DoctorID, string InhosStatus)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DoctorID);
        sqlpar[1] = new SQLiteParameter("2", InhosStatus);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryMyPatient, sqlpar);
            string str = TypeChange.DataTableToXml(dt);
            return str;
        }
    }

    /// <summary>
    /// 查询科室下病人
    /// </summary>
    /// <param name="DeptId">科室ID</param>
    /// <param name="InhosStatus">入院 出院类型</param>
    /// <returns></returns>
    [WebMethod (Description="查询科室病人")]
    public string QueryDeptPatientsList(string DeptId, string InhosStatus)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DeptId);
        sqlpar[1] = new SQLiteParameter("2", InhosStatus);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryDeptPatient,sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询某医生下值班/近期病人信息
    /// </summary>
    /// <param name="DoctorID">医生ID</param>
    /// <param name="DPTypes">值班/近期类型</param>
    /// <returns></returns>
    [WebMethod(Description="查询某医生下值班/近期病人信息")]
    public string QueryDutyResentPatientList(string DoctorID, string DPTypes)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", DoctorID);
        sqlpar[1] = new SQLiteParameter("2", DPTypes);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryDutyResentPatientList, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询医生近期病人信息
    /// </summary>
    /// <param name="DoctorID"></param>
    /// <param name="DPTypes">近期/值班类型</param>
    /// <param name="Date">时间</param>
    /// <returns></returns>
    [WebMethod(Description = "查询医生近期病人信息")]
    public string QueryResentPatientList(string DoctorID, string DPTypes, string Date)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[3];
        sqlpar[0] = new SQLiteParameter("1", DoctorID);
        sqlpar[1] = new SQLiteParameter("2", DPTypes);
        sqlpar[2] = new SQLiteParameter("3", Date);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryResentPatientList, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【PatientCheckPage】
    /// <summary>
    /// 查询近期病人个数
    /// </summary>
    /// <param name="DPID"></param>
    /// <param name="CreateDate"></param>
    /// <param name="DPType"></param>
    /// <returns></returns>
    [WebMethod(Description="查询近期病人个数")]
    public string QueryResentPatientCount(string DPID, string CreateDate, string DPType)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[3];
        sqlpar[0] = new SQLiteParameter("1", DPID);
        sqlpar[1] = new SQLiteParameter("2", CreateDate);
        sqlpar[2] = new SQLiteParameter("3", DPType);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            string str = sqldb.QueryScalar(SqlTools.SqlQueryRecentPatientCount, sqlpar).ToString();
            return TypeChange.StringToXml("RecentPatientCount",str);
        }
    }
    
    
    [WebMethod(Description="插入一条近期病人/值班病人数据")]
    public string InsertDoctorPatients(string DPID, string DoctorID, string InhosID, string DPType, string CreateDate)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[5];
        sqlpar[0] = new SQLiteParameter("1", DPID);
        sqlpar[1] = new SQLiteParameter("2", DoctorID);
        sqlpar[2] = new SQLiteParameter("3", InhosID);
        sqlpar[3] = new SQLiteParameter("4", DPType);
        sqlpar[4] = new SQLiteParameter("5", CreateDate);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            string str = sqldb.Execute(SqlTools.SqlInsertDoctorPatients, sqlpar) > 0 ? "true" : "false";
            //string a = TypeChange.StringToXml("isInsert", str);
            return TypeChange.StringToXml("isInsert",str);
        }
    }
    #endregion

    #region【AdciceLisetPage】
    /// <summary>
    /// 查询病人医嘱类型下的医嘱个数
    /// </summary>
    /// <param name="InhosID">住院ID</param>
    /// <param name="StandingFlag">医嘱类型（长期 临时）</param>
    /// <returns></returns>
    [WebMethod(Description = "查询病人医嘱类型下的医嘱个数")]
    public string QueryAdviceCount(string InhosID, string StandingFlag)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[4];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        sqlpar[1] = new SQLiteParameter("2", StandingFlag);
        sqlpar[2] = new SQLiteParameter("3", InhosID);
        sqlpar[3] = new SQLiteParameter("4", StandingFlag);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryAdviceCount, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    
    /// <summary>
    /// 查询病人信息
    /// </summary>
    /// <param name="InhosID">住院ID</param>
    /// <returns></returns>
    [WebMethod(Description="查询病人信息")]
    public string QueryAdvice(string InhosID)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryAdvice, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【MedicRecord】
    /// <summary>
    /// 查询病历文书标题
    /// </summary>
    /// <param name="InhosID">住院ID</param>
    /// <returns></returns>
    [WebMethod(Description="查询病历文书标题")]
    public string QueryEmrDocHeader(string InhosID)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryEmrDocHeader, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询病历文书详细信息
    /// </summary>
    /// <param name="InhosID"></param>
    /// <param name="SectionNo"></param>
    /// <returns></returns>
    [WebMethod (Description="查询病历文书详细信息")]
    public string QueryPatientEmrDocDetail(string InhosID, string SectionNo)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        sqlpar[1] = new SQLiteParameter("2", SectionNo);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryPatientEmrDocDetail, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【CheckRecord】
    /// <summary>
    /// 查询检查申请
    /// </summary>
    /// <param name="InhosID"></param>
    /// <returns></returns>
    [WebMethod(Description="查询检查申请")]
    public string QueryCheckApply(string InhosID)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryCheckApply, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询检查结果
    /// </summary>
    /// <param name="InhosID"></param>
    /// <returns></returns>
    [WebMethod(Description="查询检查结果")]
    public string QueryCheckResult(string InhosID)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryCheckResult, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【iCode】
    /// <summary>
    /// 查询代码信息
    /// </summary>
    /// <param name="GroupName">代码类型</param>
    /// <returns></returns>
    [WebMethod(Description = "查询代码信息")]
    public string QueryCodeListByGroup(string GroupName)
    { 
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", GroupName);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryCodeListByGroup, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【LisResultpage】
    /// <summary>
    /// 查询病人LIS结果
    /// </summary>
    /// <param name="IllcaseNo">住院号</param>
    /// <returns></returns>
    [WebMethod(Description = "查询病人LIS结果")]
    public string QueryLisResult(string IllcaseNo)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[1];
        sqlpar[0] = new SQLiteParameter("1", IllcaseNo);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryLisResult, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【AdviceInputPage】
    /// <summary>
    /// 查询用法
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description="查询用法")]
    public string QueryUsage()
    {
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryUsage);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询频率
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description = "查询频率")]
    public string QueryFrequence()
    {
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryFrequence);
            return TypeChange.DataTableToXml(dt);
        }
    }

    /// <summary>
    /// 查询医嘱
    /// </summary>
    /// <param name="AdviceType"></param>
    /// <param name="AdviceFilter"></param>
    /// <param name="StandingType"></param>
    /// <returns></returns>
    [WebMethod (Description="查询医嘱")]
    public string QueryAdviceByLike(string AdviceType, string AdviceFilter, string StandingType)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[3];
        sqlpar[0] = new SQLiteParameter("1", AdviceType);
        sqlpar[1] = new SQLiteParameter("2", "%"+AdviceFilter+"%");
        sqlpar[2] = new SQLiteParameter("3", StandingType);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryAdviceByLike, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

    #region【CheckLogLogDetailPage】
    /// <summary>
    /// 查询查房日志
    /// </summary>
    /// <param name="InhosID"></param>
    /// <param name="LogType"></param>
    /// <returns></returns>
    [WebMethod (Description="查询查房日志")]
    public string QueryCheckLogDetail(string InhosID, string LogType)
    {
        SQLiteParameter[] sqlpar = new SQLiteParameter[2];
        sqlpar[0] = new SQLiteParameter("1", InhosID);
        sqlpar[1] = new SQLiteParameter("2", LogType);
        using (SqliteDBHelper sqldb = new SqliteDBHelper())
        {
            DataTable dt = sqldb.Query(SqlTools.SqlQueryCheckLogDetail, sqlpar);
            return TypeChange.DataTableToXml(dt);
        }
    }
    #endregion

}
