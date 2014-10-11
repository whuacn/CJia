using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;
using System.Collections.ObjectModel;

namespace CJia.MobileMedicalDoctor.Models
{
    public class AdviceInputModel : ModelBase, IModel
    {
        #region 查询本地医嘱类别
        /// <summary>
        /// 查询本地医嘱类别
        /// </summary>
        public List<Data.iCode> QueryLocalAdviceType()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iCode] Where [GroupName]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, "医嘱类别");
                var Result = cmd.ExecuteQuery<iCode>();
                return Result;
            }
        }

        /// <summary>
        /// 将服务器最新医嘱类别至本地
        /// </summary>
        /// <param name="AdviceTypeList"></param>
        /// <returns></returns>
        public bool SyncAdviceTypeToLocal(List<Data.iCode> AdviceTypeList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (iCode i in AdviceTypeList)
                {
                    var result = conn.Table<iCode>().Where(ic => ic.Code == i.Code).SingleOrDefault();
                    if (result == null)
                    {
                        conn.Insert(i);
                    }
                    else
                    {
                        conn.Update(i);
                    }
                }
                conn.Commit();
            }
            return true;
        }
        #endregion

        #region 查询本地医嘱子类别
        /// <summary>
        /// 查询本地医嘱子类别
        /// </summary>
        public List<Data.iType2> QueryLocalSubType(string AdviceTypeID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iType2] Where [AdviceTypeID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, AdviceTypeID);
                var Result = cmd.ExecuteQuery<iType2>();
                return Result;
            }
        }
        #endregion

        /// <summary>
        /// 查询本地医嘱子类别
        /// </summary>
        public List<Data.iAdvice> QueryLocalAdvice(string StandingFlag, string AdviceTypeID, string AdviceFilter)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iAdvice] Where [AdviceType]=? And [AdviceFilter] Like '%'||?||'%' And ([StandingType]='" + StandingFlag + "' Or [StandingType]='9')";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, AdviceTypeID, AdviceFilter);

                var Result = cmd.ExecuteQuery<iAdvice>();
                return Result;
            }
        }

        /// <summary>
        /// 查询本地用法
        /// </summary>
        public List<Data.iUsage> QueryLocalUsage()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                return conn.Query<Data.iUsage>("Select * From [iUsage]");
            }
        }
        /// <summary>
        /// 查询本地频率
        /// </summary>
        public List<Data.iFrequency> QueryLocalFrequence()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                return conn.Query<Data.iFrequency>("Select * From [iFrequency]");
            }
        }

        public bool SaveAdvice(ObservableCollection<Data.PadAdvice> ListNewAdvice, ref string exMsg)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                try
                {
                    conn.BeginTransaction();
                    foreach (Data.PadAdvice advice in ListNewAdvice)
                    {
                        conn.Insert(advice);
                        Data.SyncLog slLog = new SyncLog()
                        {
                            LogID = Guid.NewGuid().ToString(),
                            TableName = "[PadAdvice]",
                            KeyField = "PAID",
                            KeyValue = advice.PAID,
                            ChangeType = "INSERT",
                            ChangeDate = iCommon.DateNow
                        };
                        conn.Insert(slLog);
                    }
                    conn.Commit();
                }
                catch (Exception ex)
                {
                    exMsg = ex.Message;
                    return false;
                }
            }
            return true;
        }
    }
}
