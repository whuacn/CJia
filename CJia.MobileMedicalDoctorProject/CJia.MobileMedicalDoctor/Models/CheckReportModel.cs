using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class CheckReportModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地检查申请
        /// </summary>
        /// <param name="InhosID"></param>
        public List<Data.CheckApply> QueryLocalCheckApply(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [CheckApply] Where [InhosID]=? Order By [ReportDate] Desc";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<CheckApply>();
                return Result;
            }
        }
        /// <summary>
        /// 查询本地检查结果
        /// </summary>
        public List<Data.CheckResult> QueryLocalCheckResult(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select cr.* From [CheckApply] ca,[CheckResult] cr Where ca.[InhosID] = @1 and ca.[ApplyNo] = cr.[ApplyNo] Order By [SerialNo]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<CheckResult>();
                return Result;
            }
        }
    }
}
