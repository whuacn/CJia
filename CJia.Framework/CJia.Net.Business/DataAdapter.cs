using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.Net;
using System.Data;
using CJia.Net.Service;
using CJia.Net.Threading;
using CJia.Net.Data;
using System.Data.Common;

namespace CJia.Net.Business
{
    /// <summary>
    /// 数据访问组件的接口实现
    /// </summary>
    public class DataAdapter : CJiaService, CJia.Net.Service.IDataAdapter
    {
        /// <summary>
        /// 数据访问组件的接口实现
        /// </summary>
        public DataAdapter()
        {

        }

        OracleAdapter oraClient = null;
        SqlAdapter sqlClient = null;
        SQLiteAdapter sqliteClient = null;
        OleDbAdapter oleDbClient = null;
        PostgreAdapter postgreClient = null;
        IDataClient GetDataClient(string ClientType)
        {
            if(ClientType == "SQL")
            {
                if(sqlClient != null)
                    return sqlClient;
                sqlClient = new SqlAdapter();
                return sqlClient;
            }
            else if(ClientType == "ORACLE")
            {
                if(oraClient != null)
                    return oraClient;
                oraClient = new OracleAdapter();
                return oraClient;
            }
            else if(ClientType == "SQLite")
            {
                if(sqliteClient != null)
                    return sqliteClient;
                sqliteClient = new SQLiteAdapter();
                return sqliteClient;
            }
            else if(ClientType == "OleDb")
            {
                if(oleDbClient != null)
                    return oleDbClient;
                oleDbClient = new OleDbAdapter();
                return oleDbClient;
            }
            else if(ClientType == "Postgre")
            {
                if(postgreClient != null)
                    return postgreClient;
                postgreClient = new PostgreAdapter();
                return postgreClient;
            }
            return null;
        }

        IDataClient GetTransClient(string TransID)
        {
            if(oraClient != null && oraClient.isExistTransaction(TransID))
                return oraClient;
            if(sqlClient != null && sqlClient.isExistTransaction(TransID))
                return sqlClient;
            if(sqliteClient != null && sqliteClient.isExistTransaction(TransID))
                return sqliteClient;
            if(oleDbClient != null && oleDbClient.isExistTransaction(TransID))
                return oleDbClient;
            if(postgreClient != null && postgreClient.isExistTransaction(TransID))
                return postgreClient;
            return null;
        }

        CJia.Net.Threading.ThreadSafeSortedList<long, DataAdapterClient> dictClient = new Threading.ThreadSafeSortedList<long, DataAdapterClient>();

        static int nowPageingId = 0;

        static Dictionary<int, DbDataReader> pagingDic = new Dictionary<int, DbDataReader>();

        public void Init(string ClientCode, string DbName)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            CurrentClient.Disconnected += CurrentClient_Disconnected;
            DataAdapterClient adaClient = new DataAdapterClient(CurrentClient);
            dictClient[CurrentClient.ClientId] = adaClient;
        }

        void CurrentClient_Disconnected(object sender, EventArgs e)
        {
            var client = (IServiceClient)sender;
            DataAdapterClient adaClient = dictClient[client.ClientId];
            client.Disconnected -= CurrentClient_Disconnected;
            string TransID;
            for(int i = 0; i < adaClient.TransList.Count; i++)
            {
                TransID = adaClient.TransList[i];
                IDataClient idc = GetTransClient(TransID);
                if(idc != null)
                    idc.RollbackTransaction(TransID);
            }
            dictClient.Remove(client.ClientId);
        }
        void LogClientTransaction(string TransID)
        {
            if(TransID.Length == 0)
                return;
            DataAdapterClient adaClient = dictClient[CurrentClient.ClientId];
            if(!adaClient.TransList.Contains(TransID))
                adaClient.TransList.Add(TransID);
        }
        void RemoveClientTransaction(string TransID)
        {
            dictClient[CurrentClient.ClientId].TransList.Remove(TransID);
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
        public string QueryScalar(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.QueryScalar(TransID, dbConn.ConnectionString, SqlText, SqlParams);
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
        public byte[] Query(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.Query(TransID, dbConn.ConnectionString, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">Sql 文本</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public byte[] QueryProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Params)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.QueryProcedure(TransID, dbConn.ConnectionString, ProcedureName, Params);
        }

        #region 分页查询
        /// <summary>
        /// 执行分页查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public int QueryPaging(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            DbDataReader reader = idc.QueryPaging(TransID, dbConn.ConnectionString, SqlText, SqlParams);
            pagingDic.Add(++nowPageingId, reader);
            return nowPageingId;
        }
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>返回数据集</returns>
        public int QueryProcedurePaging(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Params)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            DbDataReader reader = idc.QueryProcedurePaging(TransID, dbConn.ConnectionString, ProcedureName, Params);
            pagingDic.Add(++nowPageingId, reader);
            return nowPageingId;
        }
        /// <summary>
        /// 查询该分页接下来的一定行数据
        /// </summary>
        /// <param name="Paging">分页号</param>
        /// <param name="count">接下来的数据行</param>
        /// <returns>返回数据集</returns>
        public byte[] QueryPagingData(int Paging, int count)
        {
            DbDataReader odr = pagingDic[Paging];
            using(DataTable dtSchema = odr.GetSchemaTable())
            {
                using(CJia.Net.Serialization.SerializationWriter sw = new Net.Serialization.SerializationWriter())
                {
                    SerializationSchema(sw, dtSchema);
                    object[] aryValues = new object[odr.FieldCount];
                    for(int i = 0; i < count; i++)
                    {
                        if(odr.Read())
                        {
                            odr.GetValues(aryValues);
                            sw.WriteOptimized(aryValues);
                        }
                    }
                    aryValues = null;
                    return sw.ToArray();
                }
            }
        }
        /// <summary>
        /// 删除分页
        /// </summary>
        /// <param name="Paging">分页id</param>
        public void DeletePaging(int Paging)
        {
            pagingDic.Remove(Paging);
        }
        #endregion

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.Execute(TransID, dbConn.ConnectionString, SqlText, SqlParams);
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
        public int BatchExecute(string ClientCode, string DbName, string TransID, string SqlText, List<object>[] BatchParams)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.BatchExecute(TransID, dbConn.ConnectionString, SqlText, BatchParams);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Param">参数字典</param>
        /// <returns>参数字典</returns>
        public Dictionary<string, object> ExecuteProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Param)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.ExecuteProcedure(TransID, dbConn.ConnectionString, ProcedureName, Param);
        }
        /// <summary>
        /// 批量执行存储过程
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数字典</param>
        /// <returns>参数字典</returns>
        public List<Dictionary<string, object>> BatchExecuteProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, List<Dictionary<string, object>> Params)
        {
            Data.DBConnection dbConn = Data.DBConfig.GetDBConnection(ClientCode, DbName);
            LogClientTransaction(TransID);
            IDataClient idc = GetDataClient(dbConn.DBType);
            return idc.BatchExecuteProcedure(TransID, dbConn.ConnectionString, ProcedureName, Params);
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void CommitTransaction(string TransID)
        {
            IDataClient idc = GetTransClient(TransID);
            idc.CommitTransaction(TransID);
            RemoveClientTransaction(TransID);
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void RollbackTransaction(string TransID)
        {
            IDataClient idc = GetTransClient(TransID);
            idc.RollbackTransaction(TransID);
            RemoveClientTransaction(TransID);
        }

        /// <summary>
        /// 数据访问适配器客户端
        /// </summary>
        private sealed class DataAdapterClient
        {
            /// <summary>
            /// 服务客户端
            /// </summary>
            public IServiceClient ServiceClient
            {
                get;
                private set;
            }
            /// <summary>
            /// 事务列表
            /// </summary>
            public List<string> TransList = new List<string>();
            /// <summary>
            /// 数据访问适配器客户端
            /// </summary>
            /// <param name="dataAdapterClient">服务客户端</param>
            public DataAdapterClient(IServiceClient dataAdapterClient)
            {
                ServiceClient = dataAdapterClient;
            }
        }


        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> QueryDBConfig()
        {
            Dictionary<string, List<string>> dicDBConfig = new Dictionary<string, List<string>>();
            if(DBConfig.dictConfig != null)
            {
                foreach(string key in DBConfig.dictConfig.Keys)
                {
                    List<string> values = new List<string>();
                    foreach(string key1 in DBConfig.dictConfig[key].Keys)
                    {
                        values.Add(key1 + "^" + DBConfig.dictConfig[key][key1].DBType + "^" + DBConfig.dictConfig[key][key1].ConnectionString);
                    }
                    dicDBConfig.Add(key, values);
                }
            }
            return dicDBConfig;
        }


        /// <summary>
        /// 序列号Schema数据表
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="dtSchema"></param>
        private void SerializationSchema(CJia.Net.Serialization.SerializationWriter sw, DataTable dtSchema)
        {
            sw.WriteOptimized(dtSchema.Rows.Count);
            DataRow drSchema;
            for(int i = 0; i < dtSchema.Rows.Count; i++)
            {
                drSchema = dtSchema.Rows[i];
                sw.WriteOptimized(new string[] { drSchema["BaseTableName"].ToString(), drSchema["ColumnName"].ToString(), drSchema["DataType"].ToString() });
            }
        }

    }
}
