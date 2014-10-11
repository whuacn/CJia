using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class MedicalRecordModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地病人病历文书信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public Data.PatientEmrDoc QueryPatientEmrDocDetail(string InhosID, string SectionNo)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select pa.* From [PatientEmrDoc] pa Where pa.[InhosID]=? And pa.[SectionNo]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID, SectionNo);
                var Result = cmd.ExecuteQuery<PatientEmrDoc>();
                if (Result.Count > 0) return Result[0];
                return null;
            }
        }
        /// <summary>
        /// 查询本地病人病历文书信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public List<Data.PatientEmrDoc> QueryLocalEmrDocHeader(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select [InhosID],[SectionNo],[DocTypeID],[DocTypeName],[Title],[Creator],[CreateDate],[CheckDate] 
                                   From [PatientEmrDoc] pa Where pa.[InhosID]=? Order By [DocTypeID],[CreateDate]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<PatientEmrDoc>();
                return Result;
            }
        }
    }
}
