using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Models
{
    public class SyncToServerModel : ModelBase
    {
        string SqlText = "Select * From {0} Where {1}=?";

        public async Task<bool> SyncLocalDataToServer()
        {
            if (iCommon.LoginUser == null) return false;
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                SQLite.SQLiteCommand cmd = conn.CreateCommand("Select * From [SyncLog]");
                List<Data.SyncLog> listLog = cmd.ExecuteQuery<Data.SyncLog>();
                if (listLog.Count == 0) return false;
                foreach (Data.SyncLog sl in listLog)
                {
                    await SyncLocalData(conn, sl);
                }
                return true;
            }
        }

        private async Task<bool> SyncLocalData(SQLite.SQLiteConnection conn, Data.SyncLog sl)
        {
            SQLite.SQLiteCommand cmd = conn.CreateCommand(String.Format(SqlText, sl.TableName, sl.KeyField), sl.KeyValue);
            dynamic Result;
            switch (sl.TableName)
            {
                case "DoctorCheckLog": Result = cmd.ExecuteQuery<Data.DoctorCheckLog>().SingleOrDefault(); break;
                case "PadAdvice": Result = cmd.ExecuteQuery<Data.PadAdvice>().SingleOrDefault(); break;
                default: return false;
            }
            if (Result != null)
            {
                object[] Data = sl.ChangeType != "DELETE" ? Result.Data : null;
                string[] Fields = Result.FieldArray;
                object SyncResult = await RemoteExcute(new object[] { sl.DeviceID, sl.InhosID, sl.TableName, sl.KeyField, sl.KeyValue, sl.ChangeType, sl.ChangeDate, Fields, Data });
                if (SyncResult != null && (bool)SyncResult)
                {
                    conn.Delete(sl);
                }
            }
            return true;
        }
    }
}
