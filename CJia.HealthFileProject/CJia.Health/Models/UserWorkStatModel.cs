using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class UserWorkStatModel:CJia.Health.Tools.Model
    {
        public DataTable QueryUserWorkAll(DateTime beginDate, DateTime endDate, string userNO)
        {
            object[] ob = new object[] { beginDate, endDate, "%" + userNO + "%", "%" + userNO + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserWorkAll, ob);
        }
        public DataTable QueryUserWorkTotal(DateTime beginDate, DateTime endDate, string userNO)
        {
            object[] ob = new object[] { beginDate, endDate, "%" + userNO + "%", "%" + userNO + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserWorkTotal, ob);
        }
    }
}
