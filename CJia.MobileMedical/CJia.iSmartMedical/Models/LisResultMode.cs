using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class LisResultMode : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地病人LIS医嘱
        /// </summary>
        /// <param name="IllcaseNo">住院号</param>
        public List<Data.LisAdvice> QueryLocalLisAdvice(string IllcaseNo)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [LisAdvice] Where [IllcaseNo]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, IllcaseNo);
                var Result = cmd.ExecuteQuery<LisAdvice>();
                return Result;
            }
        }
        /// <summary>
        /// 查询本地病人LIS结果
        /// </summary>
        /// <param name="SampleNo">样本号</param>
        /// <param name="TestDate">检验日期</param>
        public List<Data.LisResult> QueryLocalLisResult(string IllcaseNo)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [LisResult] Where [IllcaseNo]=? Order By [ReportDate] Desc";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, IllcaseNo);
                var Result = cmd.ExecuteQuery<LisResult>();
                return Result;
            }
        }
    }
}
