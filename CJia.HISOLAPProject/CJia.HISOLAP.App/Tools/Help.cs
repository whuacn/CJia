using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.Tools
{
    public static class Help
    {

        #region bi过滤语句生成

        /// <summary>
        /// 根据查询时间范围，返回MDX过滤语句
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static string DateFilter(DateTime beginDate, DateTime endDate)
        {
            string sql = @" { [DATE DIM].[时间过滤].[DATE YEAR].&[" + beginDate.Year.ToString() + "].&[" + beginDate.Month.ToString() + "].&[" + beginDate.Day.ToString() +
                                              "]: [DATE DIM].[时间过滤].[DATE YEAR].&[" + endDate.Year.ToString() + "].&[" + endDate.Month.ToString() + "].&[" + endDate.Day.ToString() + "] } ";
            return sql;
        }

        /// <summary>
        /// 根据选择的科室获取科室过滤的sql代码 
        /// </summary>
        /// <param name="selectDept">选择的科室字典</param>
        /// <returns>科室过滤sql</returns>
        public static string DeptFilter(bool isUseDept,bool isSelectAllDept,Dictionary<string, string> selectDept)
        {
            if(isUseDept)
            {
                if(isSelectAllDept)
                {
                    return "";
                }
                else
                {
                    if(selectDept != null && selectDept.Values != null && selectDept.Values.Count > 0)
                    {
                        StringBuilder sql = new StringBuilder(" { ");
                        foreach(string deptId in selectDept.Values)
                        {
                            sql.Append(@" [DEPT DIM].[DEPT ID].&[");
                            sql.Append(deptId);
                            sql.Append("] , ");
                        }
                        sql.Remove(sql.Length - 2, 2);
                        sql.Append(" } ");
                        return sql.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取时间 科室过滤条件
        /// </summary>
        /// <param name="refreshEventArgs"></param>
        /// <returns></returns>
        public static string FilterDataDept(CJia.HISOLAP.App.UI.RefreshEventArgs refreshEventArgs)
        {
            StringBuilder sql = new StringBuilder("");
            sql.Append(" WHERE ( ");
            sql.Append(CJia.HISOLAP.App.Tools.Help.DateFilter(refreshEventArgs.SelectStartDateTime, refreshEventArgs.SelectEndDateTime));
            string deptSql = CJia.HISOLAP.App.Tools.Help.DeptFilter(refreshEventArgs.IsUseDept, refreshEventArgs.IsSelectAllDept, refreshEventArgs.SelectDepts);
            if(deptSql != "")
            {
                sql.Append(" , ");
                sql.Append(deptSql);
            }
            sql.Append(" ) ");
            return sql.ToString();
        }

        #endregion

        #region 科室数据获取

        private static DataTable deptData;
        public static DataTable DeptData
        {
            get
            {
                if(deptData == null)
                {
                    deptData = GetDeptData();
                }
                return deptData;
            }
        }
        /// <summary>
        /// 获取所有科室
        /// </summary>
        /// <returns></returns>
        private static DataTable GetDeptData()
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.DT);
            string selectDept = "select DD.DEPT_ID,DD.DEPT_NAME,DD.UP_DEPT_ID,DD.UP_DEPT_NAME from DEPT_DIM DD ORDER BY DD.DEPT_NAME ";
            DataTable deptData = CJia.DefaultOleDb.Query(selectDept);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            return deptData;
        }

        public static DataTable DeptData_KJ
        {
            get
            {
                if (deptData == null)
                {
                    deptData = GetDeptData_KJ();
                }
                return deptData;
            }
        }
        /// <summary>
        /// 获取所有科室--抗菌药物
        /// </summary>
        /// <returns></returns>
        private static DataTable GetDeptData_KJ()
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.PIVAS);
            string selectDept = @"SELECT 'ALL' DEPT_ID,'全部' DEPT_NAME,'' UP_DEPT_ID,'' UP_DEPT_NAME FROM DUAL
                                                UNION ALL
                                                SELECT DEPT_CODE DEPT_ID, DEPT_NAME, '' UP_DEPT_ID, '' UP_DEPT_NAME
                                                  FROM DEPT_DICT DD
                                                 WHERE NOT EXISTS
                                                 (SELECT 1 FROM DEPT_VS_WARD DVW WHERE DD.DEPT_CODE = DVW.DEPT_CODE)";
            DataTable deptData = CJia.DefaultOleDb.Query(selectDept);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            return deptData;
        }

        public static DataTable ILLFIELDData_KJ
        {
            get
            {
                if (deptData == null)
                {
                    deptData = GetILLFIELDData_KJ();
                }
                return deptData;
            }
        }
        /// <summary>
        /// 获取所有病区--抗菌药物
        /// </summary>
        /// <returns></returns>
        private static DataTable GetILLFIELDData_KJ()
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.PIVAS);
            string selectDept = @"SELECT 'ALL' DEPT_ID,'全部' DEPT_NAME,'' UP_DEPT_ID,'' UP_DEPT_NAME FROM DUAL
                                                UNION ALL
                                                SELECT DEPT_CODE DEPT_ID, DEPT_NAME, '' UP_DEPT_ID, '' UP_DEPT_NAME
                                                  FROM DEPT_DICT DD
                                                 WHERE EXISTS
                                                 (SELECT 1 FROM DEPT_VS_WARD DVW WHERE DD.DEPT_CODE = DVW.DEPT_CODE)";
            DataTable deptData = CJia.DefaultOleDb.Query(selectDept);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            return deptData;
        }
        /// <summary>
        /// 获得医院名称
        /// </summary>
        /// <returns></returns>
        public static string GetHosName()
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.DT);
            string selectHos = "select t.* from GM_PARAMETER t where t.para_code='1002'";
            DataTable hosData = CJia.DefaultOleDb.Query(selectHos);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            return hosData.Rows[0][2].ToString();
        }
        /// <summary>
        /// 获得医院组织代码
        /// </summary>
        /// <returns></returns>
        public static string GetHosCode()
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.DT);
            string selectHos = "select t.* from GM_PARAMETER t where t.para_code='1001'";
            DataTable hosData = CJia.DefaultOleDb.Query(selectHos);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            return hosData.Rows[0][2].ToString();
        }

        /// <summary>
        /// 获得科室/病区多选字符串，以逗号连接
        /// </summary>
        /// <returns></returns>
        public static string GetDeptString(Dictionary<string,string> dictDept)
        {
            if (dictDept.Count > 0)
            {
                string strDeptId = "";
                foreach (string deptId in dictDept.Values)
                {
                    strDeptId += "'" + deptId + "'" + ",";
                }
                string strDeptIdIn = strDeptId.Substring(0, strDeptId.Length - 1);
                return strDeptIdIn;
            }
            else
            {
                //Message.ShowWarning("请选择科室或病区！");
                return "''";
            }
        }
        #endregion

    }
}
