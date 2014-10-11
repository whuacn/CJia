using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryDeptModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据关键字查询筛选部门信息
        /// </summary>
        /// <param name="keyWord">查询内容</param>
        /// <param name="organId">组织流水号</param>
        /// <returns></returns>
        public DataTable QueryDeptBySearch(string keyWord,string organId)
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
            return CJia.DefaultOleDb.Query(sql, sqlParams);
        }

        /// <summary>
        /// 根据ID删除组织
        /// </summary>
        /// <param name="updateBy">删除人</param>
        /// <param name="organId">组织流水号</param>
        /// <returns></returns>
        public bool DeleteDeptById(string updateBy, string organId)
        {
            object[] sqlParams = new object[] { updateBy,organId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteDeptById,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 事物根据ID删除组织
        /// </summary>
        /// <param name="trans">事物ID</param>
        /// <param name="updateBy">删除人</param>
        /// <param name="organId">组织流水号</param>
        /// <returns></returns>
        public bool DeleteDeptById(string trans,string updateBy, string organId)
        {
            object[] sqlParams = new object[] { updateBy, organId };
            return CJia.DefaultOleDb.Execute(trans,SqlTools.SqlDeleteDeptById, sqlParams) > 0 ? true : false;
        }
    }
}
