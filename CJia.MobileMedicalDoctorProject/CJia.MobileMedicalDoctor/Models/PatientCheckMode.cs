using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class PatientCheckMode : ModelBase, IModel
    {
        /// <summary>
        /// 保存近期查房记录
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public void SaveTodayCheckPatient(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select Count(1) From [DoctorPatients] Where [DPID]=? And [CreateDate]=? And [DPType]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, iCommon.DoctorID + InhosID, iCommon.Today, "近期病人");
                var Count = cmd.ExecuteScalar<string>();
                if (Count == "0")
                {
                    Data.DoctorPatients dp = new DoctorPatients();
                    dp.DPID = iCommon.DoctorID + InhosID;
                    dp.DoctorID = iCommon.DoctorID;
                    dp.InhosID = InhosID;
                    dp.DPType = "近期病人";
                    dp.CreateDate = iCommon.Today;
                    conn.Insert(dp);
                }
            }
        }
    }
}
