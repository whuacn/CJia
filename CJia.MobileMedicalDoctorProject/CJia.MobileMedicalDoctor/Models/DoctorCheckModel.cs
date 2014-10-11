using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class DoctorCheckModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询病人的查房日志
        /// </summary>
        /// <param name="InhosID"></param>
        /// <returns></returns>
        public List<DoctorCheckLog> QueryLocalPatientCheckLog(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [DoctorCheckLog] Where[InhosID]=? And [LogType]=? Order By CheckDate||CheckTime Desc";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID, "日志");
                var Result = cmd.ExecuteQuery<DoctorCheckLog>();
                return Result;
            }
        }

        /// <summary>
        /// 查询病人的查房日志
        /// </summary>
        /// <param name="InhosID"></param>
        /// <returns></returns>
        public List<DoctorCheckLog> QueryLocalPatientCheckPhoto(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [DoctorCheckLog] Where[InhosID]=? And [LogType]=? Order By CheckDate||CheckTime Desc";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID, "照片");
                var Result = cmd.ExecuteQuery<DoctorCheckLog>();
                return Result;
            }
        }
        /// <summary>
        /// 保存一个查房日志到本地
        /// </summary>
        /// <param name="CheckLog"></param>
        public void SaveCheckLogToLocal(Data.DoctorCheckLog CheckLog)
        {//To do:修改病人的同步标志，标识需同步查房日志
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlCheckLog = @"Select * From [DoctorCheckLog] Where [DCLID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlCheckLog, CheckLog.DCLID);
                Data.DoctorCheckLog existCheckLog = cmd.ExecuteQuery<DoctorCheckLog>().SingleOrDefault();
                Data.SyncLog slCheckLog = new SyncLog()
                {
                    TableName = "[DoctorCheckLog]",
                    KeyField = "DCLID",
                    KeyValue = CheckLog.DCLID,
                    ChangeType = "INSERT"
                };
                if (existCheckLog == null)
                {
                    conn.Insert(CheckLog);
                }
                else
                {
                    conn.Update(CheckLog);
                    slCheckLog.ChangeType = "UPDATE";
                }
                SaveSyncLog(conn, slCheckLog);
            }
        }
        public void DeleteCheckLog(Data.DoctorCheckLog CheckLog)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlCheckLog = @"Delete From [DoctorCheckLog] Where [DCLID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlCheckLog, CheckLog.DCLID);
                cmd.ExecuteNonQuery();
                Data.SyncLog slCheckLog = new SyncLog()
                {
                    TableName = "[DoctorCheckLog]",
                    KeyField = "DCLID",
                    KeyValue = CheckLog.DCLID,
                    ChangeType = "DELETE"
                };
                
                SaveSyncLog(conn, slCheckLog);
            }
        }
    }
}
