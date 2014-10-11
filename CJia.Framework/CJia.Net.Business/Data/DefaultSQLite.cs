using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Net.Data
{
    /// <summary>
    /// 服务器端SQLite数据库访问
    /// </summary>
    public class DefaultSQLite
    {
        static string ClientCode, DbName;
        static SQLiteAdapter DataClient = new SQLiteAdapter();
        static DefaultSQLite()
        {
            ClientCode = "CJiaClient-CJiaSystem";
            DbName = "SQLiteDB";
        }
        /// <summary>
        /// 执行查询SQL语句，返回第一行第一列值
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string SqlText, object[] SqlParams = null, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.QueryScalar(TransID, dbConn.ConnectionString, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static byte[] Query(string SqlText, object[] SqlParams = null, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.Query(TransID, dbConn.ConnectionString, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static DataTable QueryTable(string SqlText, object[] SqlParams = null, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.QueryTable(TransID, dbConn.ConnectionString, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string SqlText, object[] SqlParams = null, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.Execute(TransID, dbConn.ConnectionString, SqlText, SqlParams);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string SqlText, List<object>[] BatchParams, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.BatchExecute(TransID, dbConn.ConnectionString, SqlText, BatchParams);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParam"></param>
        /// <param name="OutputParam"></param>
        /// <param name="TransID"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ExecuteProcedure(string StrConn, string ProcedureName, Dictionary<string, object> Param, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.ExecuteProcedure(TransID, StrConn, ProcedureName, Param);
        }

        /// <summary>
        /// 批量执行存储过程
        /// </summary>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParams"></param>
        /// <param name="OutputParams"></param>
        /// <param name="TransID"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> BatchExecuteProcedure(string StrConn, string ProcedureName, List<Dictionary<string, object>> Param, string TransID = "")
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.BatchExecuteProcedure(TransID, StrConn, ProcedureName, Param);
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        public static string BeginTransaction()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public static void CommitTransaction(string TransID)
        {
            DataClient.CommitTransaction(TransID);
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public static void RollbackTransaction(string TransID)
        {
            DataClient.RollbackTransaction(TransID);
        }
    }
}
