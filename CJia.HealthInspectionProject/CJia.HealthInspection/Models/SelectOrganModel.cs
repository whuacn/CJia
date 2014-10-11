using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class SelectOrganModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据所输内容查询组织信息
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataTable QueryOrganBySearchKeyWord(string keyWord)
        {
            string sql = "";
            if (keyWord != "")
            {
                sql = SqlTools.SqlQueryAllOrgan + " and (organ_no like '%" + keyWord + "%' or organ_name like '%" + keyWord + "%')";
            }
            else
            {
                sql = SqlTools.SqlQueryAllOrgan;
            }
            return CJia.DefaultOleDb.Query(sql);
        }

        /// <summary>
        /// 根据组织ID查询组织名称
        /// </summary>
        /// <param name="organId"></param>
        /// <returns></returns>
        public string QueryOrganNameById(string organId)
        {
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryOrganNameById,sqlParams);
        }
    }
}
