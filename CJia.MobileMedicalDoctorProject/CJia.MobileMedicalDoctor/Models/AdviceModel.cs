using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class AdviceModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地病人住院医嘱信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public List<Data.PatientAdvices> QueryLocalPatientAdvices(string InhosID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select pa.* From [PatientAdvices] pa Where pa.[InhosID]=? Order By [ListDate]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID);
                var Result = cmd.ExecuteQuery<PatientAdvices>();
                return Result;
            }
        }
        /// <summary>
        /// 查询病人住院医嘱类别分组信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        public List<Data.AdviceTypeGroup> QueryPatientAdvicesTypeList(string InhosID,string StandingFlag)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select [AdviceType],Count(1) As GroupCount From [PatientAdvices] pa Where pa.[InhosID]=? And pa.[StandingFlag]=? Group By [AdviceType]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, InhosID,StandingFlag);
                var DataList = cmd.ExecuteQuery<AdviceTypeGroup>();
                DataList.Insert(0, new AdviceTypeGroup() { AdviceType = "全部", GroupCount = "0" });
                SqlText = @"Select Count(1) As GroupCount From [PatientAdvices] pa Where pa.[InhosID]=? And pa.[StandingFlag]=?";
                cmd.CommandText = SqlText;
                var Result = cmd.ExecuteScalar<string>();
                DataList[0].GroupCount = Result;
                return DataList;
            }
        }
    }
}
