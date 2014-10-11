using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryOrganModel : CJia.HealthInspection.Tools.Model
    {
        ///// <summary>
        ///// 查询所有组织
        ///// </summary>
        ///// <returns></returns>
        //public DataTable QueryAllOrgan()
        //{
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllOrgan);
        //}

        /// <summary>
        /// 页面查询组织信息
        /// </summary>
        /// <param name="keyWord">搜索内容</param>
        /// <returns></returns>
        public DataTable QueryOrganBySearch(string keyWord)
        {
            string sql = "";
            if (keyWord != "")
            {
                sql = SqlTools.SqlQueryAllOrgan + " and (gor.organ_no like '%" + keyWord + "%' or gor.organ_name like '%" + keyWord + "%' or ga.area_code like '%" + keyWord + "%' or ga.area_name like '%" + keyWord + "%')";
            }
            else
            {
                sql = SqlTools.SqlQueryAllOrgan;
            }
            return CJia.DefaultOleDb.Query(sql);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="updateBy"></param>
        /// <param name="deletedOrganId">所要删除组织ID</param>
        /// <returns></returns>
        public bool DeleteOrganById(string updateBy, string deletedOrganId)
        {
            object[] sqlParams = new object[] { updateBy, deletedOrganId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteOrganById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除组织（事务）
        /// </summary>
        /// <param name="updateBy"></param>
        /// <param name="deletedOrganId">所要删除组织ID</param>
        /// <returns></returns>
        public bool DeleteOrganById(string trans, string updateBy, string deletedOrganId)
        {
            object[] sqlParams = new object[] { updateBy, deletedOrganId };
            return CJia.DefaultOleDb.Execute(trans, SqlTools.SqlDeleteOrganById, sqlParams) > 0 ? true : false;
        }
    }
}
