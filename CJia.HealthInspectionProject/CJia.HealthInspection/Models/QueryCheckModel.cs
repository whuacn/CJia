using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryCheckModel :CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根究关键字查询监督记录
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataTable QueryCheckByKey(string keyWord, long OrganId)
        {
            object[] ob = new object[] {OrganId, "%" + keyWord + "%", "%" + keyWord + "%" };
            DataTable dtCheck = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckByKey, ob);
            return dtCheck;
        }
    }
}
