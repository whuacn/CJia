using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class MyPatientsPageModel : ModelBase, IModel
    {
        /// <summary>
        /// 获取医生已在设备的病人列表（在DoctorPatients表中）
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public List<Patient> QueryLocalDoctorPatientList(string DoctorID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select p.* From [Patient] p Where p.[BedDoctor]=? And p.[InhosStatus]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DoctorID, "正住院");
                var Result = cmd.ExecuteQuery<Patient>();
                return Result;
            }
        }
        /// <summary>
        /// 获取本地科室病人
        /// </summary>
        /// <param name="OfficeID"></param>
        /// <returns></returns>
        public List<Patient> QueryLocalOfficePatientList(string OfficeID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select p.* From [Patient] p Where p.[OfficeID]=? And p.[InhosStatus]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, OfficeID, "正住院");
                var Result = cmd.ExecuteQuery<Patient>();
                return Result;
            }
        }
        /// <summary>
        /// 获取本地值班病人
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public List<Patient> QueryLocalDutyPatientList(string DoctorID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [Patient] p Where Exists (Select 1 From [DoctorPatients] dp Where dp.[DoctorID]=? And dp.[InhosID] = p.[InhosID] And dp.[DPType] = ?)";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DoctorID, "值班病人");
                var Result = cmd.ExecuteQuery<Patient>();
                return Result;
            }
        }
        /// <summary>
        /// 获取本地值班病人
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public List<Patient> QueryLocalTodayPatientList(string DoctorID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [Patient] p Where Exists (Select 1 From [DoctorPatients] dp Where dp.[DoctorID]=? And dp.[InhosID] = p.[InhosID] And dp.[DPType] = ? And dp.[CreateDate]=?)";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DoctorID, "近期病人", iCommon.Today);
                var Result = cmd.ExecuteQuery<Patient>();
                return Result;
            }
        }
        /// <summary>
        /// 获取本地科室病人
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public List<Patient> QueryLocalHistoryPatientList(string DoctorID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [Patient] p Where p.[BedDoctor]=? And p.[InhosStatus]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DoctorID, "已出院");
                var Result = cmd.ExecuteQuery<Patient>();
                return Result;
            }
        }
        /// <summary>
        /// 获取病情正住院病人列表
        /// </summary>
        /// <param name="IllfieldID"></param>
        /// <returns></returns>
        public async Task<List<Patient>> QueryIllfieldPatientList(string IllfieldID)
        {
            object Result = await RemoteExcute(new object[] { IllfieldID });
            List<Patient> DataList = Deserialize<Patient>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 获取设备对应科室已出院病人列表
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public async Task<List<Patient>> QueryLeavehosPatient(string DeviceID)
        {
            object Result = await RemoteExcute(new object[] { DeviceID });
            List<Patient> DataList = Deserialize<Patient>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 获取医生值班病区列表
        /// </summary>
        /// <param name="IllfieldID"></param>
        /// <returns></returns>
        public async Task<List<DoctorIllfield>> QueryDoctorDutyIllfield(string DoctorID)
        {
            object Result = await RemoteExcute(new object[] { DoctorID });
            List<DoctorIllfield> DataList = Deserialize<Data.DoctorIllfield>(Result as byte[]);
            return DataList;
        }

        /// <summary>
        /// 保存值班病人到医生病人表中
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="NewPatientList"></param>
        public void SaveDutyPatientToLocal(string DoctorID, List<Patient> PatientList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (Patient patient in PatientList)
                {
                    Data.DoctorPatients dp = new DoctorPatients();
                    dp.DPID = DoctorID + patient.InhosID;
                    dp.DoctorID = DoctorID;
                    dp.InhosID = patient.InhosID;
                    dp.DPType = "值班病人";
                    dp.CreateDate = iCommon.DateNow;

                    var dps = conn.Table<DoctorPatients>().Where(p => p.DPID == dp.DPID).SingleOrDefault();
                    if (dps == null)
                    {
                        conn.Insert(dp);
                    }
                    else
                    {
                        conn.Update(dp);
                    }
                }
                conn.Commit();
            }
        }
    }
}
