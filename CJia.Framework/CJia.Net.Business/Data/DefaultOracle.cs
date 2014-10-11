using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace CJia.Net.Data
{
    /// <summary>
    /// 服务器端Oracle数据库访问
    /// </summary>
    public class DefaultOracle
    {
        public static string ClientCode, DbName;
        static OracleAdapter DataClient = new OracleAdapter();
        static DefaultOracle()
        {
            ClientCode = "CJiaClient-CJiaSystem";
            DbName = "OracleDB";
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
        public static Dictionary<string, object> ExecuteProcedure(string StrConn, string ProcedureName, Dictionary<string, object> Param,string TransID = "")
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
        /// <summary>
        /// 创建监听
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="SqlText">监听Sql</param>
        /// <returns></returns>
        public static OracleDependency CreateDependency(string SqlText)
        {
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            return DataClient.CreateDependency(dbConn.ConnectionString, SqlText);
        }
        /// <summary>
        /// 监听数据的最后一次变化时间
        /// </summary>
        public static Dictionary<string, string> DictListen = new Dictionary<string,string>();
        /// <summary>
        /// 开始监听
        /// </summary>
        public static string StartListen(string SqlText)
        {
            if (DictListen == null)
                DictListen = new Dictionary<string, string>();
            DBConnection dbConn = DBConfig.GetDBConnection(ClientCode, DbName);
            OracleDependency dep = DataClient.CreateDependency(dbConn.ConnectionString, SqlText);
            dep.OnChange += new OnChangeEventHandler(Data_OnChange);
            DictListen.Add(dep.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DataClient.BeginListen(dep.Id);
            return dep.Id;
        }
        
        /// <summary>
        /// 停止监听
        /// </summary>
        public static void StopListen(string ListenID)
        {
            OracleDependency dep = DataClient.GetDependencyByID(ListenID);
            dep.OnChange -= new OnChangeEventHandler(Data_OnChange);
            DataClient.RemoveDependency(ListenID);
            DictListen.Remove(ListenID);
        }
        /// <summary>
        /// 停止所有监听
        /// </summary>
        public static void StopListen()
        {
            foreach (string ListenID in DictListen.Keys)
            {
                OracleDependency dep = DataClient.GetDependencyByID(ListenID);
                dep.OnChange -= new OnChangeEventHandler(Data_OnChange);
                DataClient.RemoveDependency(ListenID);
            }
            DictListen.Clear();
        }
        static object lockObject = new object();
        /// <summary>
        /// 监听数据改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        static void Data_OnChange(object sender, OracleNotificationEventArgs eventArgs)
        {
            lock (lockObject)
            {
                DictListen[(sender as OracleDependency).Id] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 最后一次变化时间
        /// </summary>
        /// <param name="ListenID"></param>
        /// <returns></returns>
        public static string LastDatetime(string ListenID)
        {
            return DictListen[ListenID];
        }
    }
}
