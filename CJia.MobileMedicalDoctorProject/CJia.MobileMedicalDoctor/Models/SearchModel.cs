using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class SearchModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地数据（超级搜索）
        /// </summary>
        /// <param name="QueryText">查询文本</param>
        public List<Data.SearchResults> QueryLocalData(string QueryText, out List<Data.SearchTypes> ListTypes)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                List<Data.SearchResults> ResultList = new List<SearchResults>();
                ListTypes = new List<SearchTypes>();
                Data.SearchTypes stAll = new SearchTypes("All", "全部", 0);
                ListTypes.Add(stAll);
                //搜索本地病人
                Data.SearchTypes stPatient = QueryLocalPatient(conn, QueryText, ref ResultList);
                stAll.ResultsCount += stPatient.ResultsCount;
                ListTypes.Add(stPatient);
                //搜索病人医嘱
                Data.SearchTypes stAdvice = QueryLocalPatientAdvice(conn, QueryText, ref ResultList);
                stAll.ResultsCount += stAdvice.ResultsCount;
                ListTypes.Add(stAdvice);
                //搜索查房日志
                Data.SearchTypes stCheckLog = QueryLocalPatientCheckLog(conn, QueryText, ref ResultList);
                stAll.ResultsCount += stCheckLog.ResultsCount;
                ListTypes.Add(stCheckLog);


                return ResultList;
            }
        }

        Data.SearchTypes QueryLocalPatient(SQLite.SQLiteConnection conn, string QueryText, ref List<Data.SearchResults> ResultList)
        {
            Data.SearchTypes st = new SearchTypes("Patient", "住院病人", 0);
            if (QueryText.Length == 0) return st;

            string SqlQuery = @"Select 'Patient' As [DataType], [PatientName] as [Title],
       [OfficeName] as [DataText1],[BedName] as [DataText2], [IllcaseNo] as [DataText3],
       [InhosID] as [DataCode1],'' as [DataCode2],'' as [DataCode3] 
From [Patient] Where [PatientName] Like '%'||@1||'%' Or [BedName] Like '%'||@1||'%' Or [IllcaseNo] Like '%'||@1||'%' Or [PatientCode] Like '%'||@1||'%'";
            SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlQuery, QueryText);
            var QueryResult = cmd.ExecuteQuery<Data.SearchResults>();
            ResultList.AddRange(QueryResult);
            st.ResultsCount = QueryResult.Count;
            return st;
        }
        Data.SearchTypes QueryLocalPatientAdvice(SQLite.SQLiteConnection conn, string QueryText, ref List<Data.SearchResults> ResultList)
        {
            Data.SearchTypes st = new SearchTypes("PatientAdvices", "病人医嘱", 0);

            if (QueryText.Length == 0) return st;

            string SqlQuery = @"Select 'PatientAdvices' As [DataType], [AdviceName] as [Title],
       [AdviceType] as [DataText1],[ListDoctor] as [DataText2], [ListDate] as [DataText3],
       [InhosID] as [DataCode1],[PAID] as [DataCode2],'' as [DataCode3] 
From [PatientAdvices] Where [AdviceName] Like '%'||@1||'%'";
            SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlQuery, QueryText);
            var QueryResult = cmd.ExecuteQuery<Data.SearchResults>();
            ResultList.AddRange(QueryResult);
            st.ResultsCount = QueryResult.Count;
            return st;
        }
        Data.SearchTypes QueryLocalPatientCheckLog(SQLite.SQLiteConnection conn, string QueryText, ref List<Data.SearchResults> ResultList)
        {
            Data.SearchTypes st = new SearchTypes("CheckLog", "查房日志", 0);
            if (QueryText.Length == 0) return st;

            string SqlQuery = @"Select 'CheckLog' As [DataType], p.[PatientName] as [Title],
       p.[BedName] as [DataText1],d.[CheckDate] as [DataText2], d.[CheckLog] as [DataText3],
       d.[InhosID] as [DataCode1],d.[DCLID] as [DataCode2],'' as [DataCode3]
From [Patient] p,[DoctorCheckLog] d 
Where p.[InhosID] = d.[InhosID]
And d.[CheckLog] Like '%'||@1||'%'";
            SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlQuery, QueryText);
            var QueryResult = cmd.ExecuteQuery<Data.SearchResults>();
            ResultList.AddRange(QueryResult);
            st.ResultsCount = QueryResult.Count;
            return st;
        }
        /// <summary>
        /// 查询服务器数据（超级搜索）
        /// </summary>
        /// <param name="QueryText">查询文本</param>
        public async Task<List<Data.SearchResults>> QueryServerData(string QueryText)
        {
            object Result = await RemoteExcute(new object[] { QueryText });
            List<SearchResults> DataList = Deserialize<SearchResults>(Result as byte[]);
            return DataList;
        }
    }
}
