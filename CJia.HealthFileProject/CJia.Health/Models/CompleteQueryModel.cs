using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class CompleteQueryModel : CJia.Health.Tools.Model
    {
        //public DataTable QueryUserWorkAll(DateTime beginDate, DateTime endDate, string userNO)
        //{
        //    object[] ob = new object[] { beginDate, endDate, "%" + userNO + "%", "%" + userNO + "%" };
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserWorkAll, ob);
        //}
        //public DataTable QueryUserWorkTotal(DateTime beginDate, DateTime endDate, string userNO)
        //{
        //    object[] ob = new object[] { beginDate, endDate, "%" + userNO + "%", "%" + userNO + "%" };
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserWorkTotal, ob);
        //}
        public DataTable QueryCompleteDate(string completeDate, string recordBegin, string recordEnd)
        {
            object[] ob = new object[] { completeDate, recordBegin, recordEnd, recordBegin, recordEnd };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryCompleteDate, ob);
        }
    }
}
