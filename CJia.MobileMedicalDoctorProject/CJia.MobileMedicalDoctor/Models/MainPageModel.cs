using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class MainPageModel : ModelBase, IModel
    {
        public int QueryLoaclDataCount()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select Count(1) From [Patient]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                var Result = cmd.ExecuteScalar<string>();
                return Convert.ToInt32(Result);
            }
        }

        public int[] QueryPatientCount()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select Count(1) From [Patient] p Where p.[BedDoctor]=? And p.[InhosStatus]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, iCommon.DoctorID, "正住院");
                var MyPatientCount = cmd.ExecuteScalar<string>();

                SqlText = @"Select Count(1) From [Patient] p Where p.[OfficeID]=? And p.[InhosStatus]=?";
                cmd.CommandText = SqlText;
                cmd.ClearBindings();
                cmd.Bind(iCommon.DeptID);
                cmd.Bind("正住院");
                var OfficePatientCount = cmd.ExecuteScalar<string>();

                SqlText = @"Select Count(1) From [DoctorPatients] dp Where dp.[DoctorID]=? And dp.[DPType]=?";
                cmd.CommandText = SqlText;
                cmd.ClearBindings();
                cmd.Bind(iCommon.DoctorID);
                cmd.Bind("值班病人");
                var DutyPatientCount = cmd.ExecuteScalar<string>();

                cmd.ClearBindings();
                cmd.Bind(iCommon.DoctorID);
                cmd.Bind("近期病人");
                var TodayPatientCount = cmd.ExecuteScalar<string>();

                SqlText = @"Select Count(1) From [Patient] p Where p.[BedDoctor]=? And p.[InhosStatus]=?";
                cmd.CommandText = SqlText;
                cmd.ClearBindings();
                cmd.Bind(iCommon.DoctorID);
                cmd.Bind("已出院");
                var LeavehosPatientCount = cmd.ExecuteScalar<string>();

                SqlText = @"select count(1) from [iAdvice] ia Where ia.[AdviceType] not in (901001,901002,901003)";
                cmd.ClearBindings();
                cmd.CommandText = SqlText;
                var NoPharmAdviceCount = cmd.ExecuteScalar<string>();

                SqlText = @"select count(1) from [iAdvice] ia Where ia.[AdviceType] in (901001,901002,901003)";
                cmd.CommandText = SqlText;
                var PharmAdviceCount = cmd.ExecuteScalar<string>();

                return new int[] { Convert.ToInt32(MyPatientCount), Convert.ToInt32(OfficePatientCount), Convert.ToInt32(DutyPatientCount), 
                    Convert.ToInt32(TodayPatientCount), Convert.ToInt32(LeavehosPatientCount), Convert.ToInt32(NoPharmAdviceCount), 
                    Convert.ToInt32(PharmAdviceCount) };
            }
        }
    }
}
