using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryExeTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据关键字查询执行任务
        /// </summary>
        /// <param name="OrganId"></param>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public DataTable QueryExeTaskByKeyWord(long OrganId,string Keyword)
        {
            object[] ob = new object[] { OrganId, "%" + Keyword + "%", "%" + Keyword + "%" };
            DataTable dtExetask = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExeTaskByKeyWord, ob);
            return dtExetask;
        }
    }
}
