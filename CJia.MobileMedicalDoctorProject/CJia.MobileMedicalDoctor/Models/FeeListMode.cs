using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class FeeListMode : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地病人费用信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public List<Data.PatientFee> QueryLocalFee(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [PatientFee] Where [InhosID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<PatientFee>();
                return Result;
            }
        }
        /// <summary>
        /// 查询本地病人预交款
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public List<Data.PatientPrepay> QueryLocalPrepay(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [PatientPrepay] Where [InhosID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<PatientPrepay>();
                return Result;
            }
        }
    }
}
