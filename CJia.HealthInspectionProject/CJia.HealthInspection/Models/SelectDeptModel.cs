using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class SelectDeptModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllDept(string organId)
        {
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDeptByOrganId,sqlParams);
        }

       /// <summary>
        /// 根据关键字查询筛选部门信息
       /// </summary>
       /// <param name="keyWord">查询内容</param>
       /// <param name="organId">组织流水号</param>
       /// <returns></returns>
        public DataTable QueryDeptBySearchKeyWord(string keyWord, string organId)
        {
            string sql = "";
            if (keyWord != "")
            {
                sql = SqlTools.SqlQueryDeptByOrganId + " and dept_no like '%" + keyWord + "%' and dept_no like '%" + keyWord + "%'";
            }
            else
            {
                sql = SqlTools.SqlQueryDeptByOrganId;
            }
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.Query(sql,sqlParams);
        }

        /// <summary>
        /// 根据部门ID查询部门名称
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns></returns>
        public string QueryDeptNameById(string deptId)
        {
            object[] sqlParams = new object[] { deptId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryDeptNameById,sqlParams);
        }
    }
}
