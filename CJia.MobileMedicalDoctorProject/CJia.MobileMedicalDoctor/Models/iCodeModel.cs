using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class iCodeModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地代码信息
        /// </summary>
        /// <param name="Group">组名称</param>
        public List<Data.iCode> QueryLocalCodeListByGroup(string Group)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iCode] Where [GroupName]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, Group);
                var Result = cmd.ExecuteQuery<iCode>();
                return Result;
            }
        }
        /// <summary>
        /// 查询所有本地代码信息
        /// </summary>
        public List<Data.iCode> QueryLocalCodeList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iCode]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                var Result = cmd.ExecuteQuery<iCode>();
                return Result;
            }
        }
    }
}
