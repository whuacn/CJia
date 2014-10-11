using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.Net;
using CJia.Net.Service;
using System.Data;
using System.Diagnostics;

namespace CJia
{
    /// <summary>
    /// 客户端访问数据库适配器
    /// </summary>
    public class DataAdapter : IDisposable
    {
        /// <summary>
        /// 数据访问客户端组件
        /// </summary>
        private IClientApplication<CJia.Net.Service.IDataAdapter> dataClient;
        private CJiaEndPoint netEP;
        string databaseName;
        /// <summary>
        /// 客户端访问数据库适配器
        /// </summary>
        public DataAdapter(string DatabaseName)
        {
            databaseName = DatabaseName;

            Init();
        }

        #region 初始化
        /// <summary>
        /// 初始化数据访问组件
        /// </summary>
        public void Init()
        {
            if (netEP != null && (netEP.IpAddress != ClientConfig.ServerIP || netEP.TcpPort != ClientConfig.ServerPort))
            {
                if (dataClient != null && dataClient.CommunicationState == Net.Communication.CommunicationStates.Connected)
                {
                    dataClient.Disconnect();
                }
            }
            netEP = new CJiaEndPoint(ClientConfig.ServerIP, ClientConfig.ServerPort);
            dataClient = CJiaClientBuilder.CreateClientApplication<CJia.Net.Service.IDataAdapter>(netEP);
            dataClient.Timeout = 6000 * 10;//三分钟超时
            dataClient.AllowAutoPing = false;
            dataClient.PingInterval = 30000;//30秒
            dataClient.Connect();
            dataClient.ServiceProxy.Init(ClientCode, DbName);
        }

        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> QueryDBConfig()
        {
            return ServiceProxy.QueryDBConfig();
        }
        /// <summary>
        /// 客户端代码
        /// </summary>
        string ClientCode
        {
            get
            {
                return ClientConfig.ClientNo + "-" + ClientConfig.SystemNo;
            }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        string DbName
        {
            get
            {
                return databaseName;
            }
        }

        Net.Service.IDataAdapter ServiceProxy
        {
            get
            {
                if (dataClient.CommunicationState == Net.Communication.CommunicationStates.Disconnected)
                {
                    dataClient.Connect();
                    dataClient.ServiceProxy.Init(ClientCode, DbName);
                }
                return dataClient.ServiceProxy;
            }
        }
        #endregion

        #region 无事务操作
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string SqlText)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, "", SqlText, null);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string SqlText, List<object> SqlParams)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, "", SqlText, SqlParams.ToArray());
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string SqlText, object[] SqlParams)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, "", SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string SqlText)
        {
           byte[] tableData = ServiceProxy.Query(ClientCode, DbName, "", SqlText, null);            
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[1];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string SqlText, List<object> SqlParams)
        {
            byte[] tableData = ServiceProxy.Query(ClientCode, DbName, "", SqlText, SqlParams.ToArray());
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string SqlText, object[] SqlParams)
        {
            byte[] tableData = ServiceProxy.Query(ClientCode, DbName, "", SqlText, SqlParams);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryProcedure(string ProcedureName)
        {
            byte[] tableData = ServiceProxy.QueryProcedure(ClientCode, DbName, "", ProcedureName, new Dictionary<string,object>());
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryProcedure(string ProcedureName, Dictionary<string, object> Params)
        {
            byte[] tableData = ServiceProxy.QueryProcedure(ClientCode, DbName, "", ProcedureName, Params);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        #region 分页查询
        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回分页id</returns>
        public int QueryPaging(string SqlText)
        {
            int padingId = ServiceProxy.QueryPaging(ClientCode, DbName, "", SqlText, null);
            return padingId;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回分页id</returns>
        public int QueryPaging(string SqlText, List<object> SqlParams)
        {
            int padingId = ServiceProxy.QueryPaging(ClientCode, DbName, "", SqlText, SqlParams.ToArray());
            return padingId;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回分页id</returns>
        public int QueryPaging(string SqlText, object[] SqlParams)
        {
            int padingId = ServiceProxy.QueryPaging(ClientCode, DbName, "", SqlText, SqlParams);
            return padingId;
        }
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>分页id</returns>
        public int QueryProcedurePaging(string ProcedureName)
        {
            return ServiceProxy.QueryProcedurePaging(ClientCode, DbName, "", ProcedureName, new Dictionary<string, object>());
        }
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>分页id</returns>
        public int QueryProcedurePaging(string ProcedureName, Dictionary<string, object> Params)
        {
            return ServiceProxy.QueryProcedurePaging(ClientCode, DbName, "", ProcedureName, Params);
        }
        // <summary>
        /// 查询该分页接下来的一定行数据
        /// </summary>
        /// <param name="Paging">分页号</param>
        /// <param name="count">接下来的数据行</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryPagingData(int Paging, int count)
        {
            byte[] tableData = ServiceProxy.QueryPagingData(Paging, count);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 删除排序
        /// </summary>
        /// <param name="Paging">排序id</param>
        public void DeletePaging(int Paging)
        {
            ServiceProxy.DeletePaging(Paging);
        }
        #endregion
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string SqlText)
        {
            return ServiceProxy.Execute(ClientCode, DbName, "", SqlText, null);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string SqlText, List<object> SqlParams)
        {
            return ServiceProxy.Execute(ClientCode, DbName, "", SqlText, SqlParams.ToArray());
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string SqlText, object[] SqlParams)
        {
            return ServiceProxy.Execute(ClientCode, DbName, "", SqlText, SqlParams);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string SqlText, List<object> BatchParam1)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, "", SqlText, new List<object>[] { BatchParam1 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string SqlText, List<object> BatchParam1, List<object> BatchParam2)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, "", SqlText, new List<object>[] { BatchParam1, BatchParam2 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <param name="BatchParam3">第3个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string SqlText, List<object> BatchParam1, List<object> BatchParam2, List<object> BatchParam3)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, "", SqlText, new List<object>[] { BatchParam1, BatchParam2, BatchParam3 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string SqlText, List<object>[] BatchParams)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, "", SqlText, BatchParams);
        }

        /// <summary>
        /// 执行存储过程 不带参数
        /// </summary>
        /// <param name="ProcedureName"></param>
        public void ExecuteProcedure(string ProcedureName)
        {
            ServiceProxy.ExecuteProcedure(ClientCode, DbName, "", ProcedureName, null);
        }

        /// <summary>
        /// 执行存储过程 参数
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParam"></param>
        public void ExecuteProcedure(string ProcedureName, ref Dictionary<string, object> Param)
        {
            Param = ServiceProxy.ExecuteProcedure(ClientCode, DbName, "", ProcedureName, Param);
        }

        /// <summary>
        /// 批量执行存储过程 带输入参数不带输出参数
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParams"></param>
        /// <param name="InputParams"></param>
        public void BatchExecuteProcedure(string ProcedureName,ref List<Dictionary<string, object>> Params)
        {
            Params = ServiceProxy.BatchExecuteProcedure(ClientCode, DbName, "", ProcedureName, Params);
        }
        #endregion

        #region 有事务操作
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string TransID, string SqlText)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, TransID, SqlText, null);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string TransID, string SqlText, List<object> SqlParams)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, TransID, SqlText, SqlParams.ToArray());
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string TransID, string SqlText, object[] SqlParams)
        {
            return ServiceProxy.QueryScalar(ClientCode, DbName, TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string TransID, string SqlText)
        {
            byte[] tableData = ServiceProxy.Query(ClientCode, DbName, TransID, SqlText, null);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[1];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string TransID, string SqlText, List<object> SqlParams)
        {
            byte[] tableData = ServiceProxy.Query(ClientCode, DbName, TransID, SqlText, SqlParams.ToArray());
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable Query(string TransID, string SqlText, object[] SqlParams)
        {
            byte[] tableData = ServiceProxy.Query(ClientCode, DbName, TransID, SqlText, SqlParams);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryProcedure(string TransID, string ProcedureName)
        {
            byte[] tableData = ServiceProxy.QueryProcedure(ClientCode, DbName, TransID, ProcedureName, new Dictionary<string, object>());
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryProcedure(string TransID, string ProcedureName, Dictionary<string, object> Params)
        {
            byte[] tableData = ServiceProxy.QueryProcedure(ClientCode, DbName, TransID, ProcedureName, Params);
            DataTable dtResult = DeserializeTable(tableData);
            tableData = new byte[0];
            tableData = null;
            return dtResult;
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string TransID, string SqlText)
        {
            return ServiceProxy.Execute(ClientCode, DbName, TransID, SqlText, null);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string TransID, string SqlText, List<object> SqlParams)
        {
            return ServiceProxy.Execute(ClientCode, DbName, TransID, SqlText, SqlParams.ToArray());
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int Execute(string TransID, string SqlText, object[] SqlParams)
        {
            return ServiceProxy.Execute(ClientCode, DbName, TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string TransID, string SqlText, List<object> BatchParam1)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, TransID, SqlText, new List<object>[] { BatchParam1 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string TransID, string SqlText, List<object> BatchParam1, List<object> BatchParam2)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, TransID, SqlText, new List<object>[] { BatchParam1, BatchParam2 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <param name="BatchParam3">第3个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string TransID, string SqlText, List<object> BatchParam1, List<object> BatchParam2, List<object> BatchParam3)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, TransID, SqlText, new List<object>[] { BatchParam1, BatchParam2, BatchParam3 });
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public int BatchExecute(string TransID, string SqlText, List<object>[] BatchParams)
        {
            return ServiceProxy.BatchExecute(ClientCode, DbName, TransID, SqlText, BatchParams);
        }


        /// <summary>
        /// 执行存储过程 不带参数
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="ProcedureName"></param>
        public void ExecuteProcedure(string TransID, string ProcedureName)
        {
            ServiceProxy.ExecuteProcedure(ClientCode, DbName, TransID, ProcedureName, null );
        }

        /// <summary>
        /// 执行存储过程 带输出参数
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Param"></param>
        public void ExecuteProcedure(string TransID, string ProcedureName, ref Dictionary<string, object> Param)
        {
            Param = ServiceProxy.ExecuteProcedure(ClientCode, DbName, TransID, ProcedureName, Param);
        }

        /// <summary>
        /// 批量执行存储过程 带输入输出参数
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Params"></param>
        public void BatchExecuteProcedure(string TransID, string ProcedureName, ref List<Dictionary<string, object>> Params)
        {
            Params = ServiceProxy.BatchExecuteProcedure(ClientCode, DbName, TransID, ProcedureName, Params);
        }
    
        #endregion

        #region 事务处理
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void CommitTransaction(string TransID)
        {
            ServiceProxy.CommitTransaction(TransID);
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void RollbackTransaction(string TransID)
        {
            ServiceProxy.RollbackTransaction(TransID);
        }
        #endregion

        #region 反序列化
        /// <summary>
        /// 将byte[]反序列化DataTable
        /// </summary>
        /// <param name="TableData"></param>
        /// <returns></returns>
        DataTable DeserializeTable(byte[] TableData)
        {
            if (TableData == null) return null;
            using (CJia.Net.Serialization.SerializationReader sr = new Net.Serialization.SerializationReader(TableData))
            {
                DataTable dtData = BuildDataTable(sr);
                dtData.BeginLoadData();
                while (sr.BytesRemaining != 0)
                {
                    dtData.LoadDataRow(sr.ReadOptimizedObjectArray(), true);
                }
                dtData.EndLoadData();
                return dtData;
            }
        }
        /// <summary>
        /// 根据表结构创建数据表
        /// </summary>
        /// <param name="sr">反序列化工具</param>
        /// <returns></returns>
        DataTable BuildDataTable(CJia.Net.Serialization.SerializationReader sr)
        {
            string colName, colType, tableName = "";
            DataTable dtData = new DataTable();
            string[] arySchema;
            int rowsCount = sr.ReadOptimizedInt32();
            int colsCount = 0;
            Dictionary<string, int> listColumn = new Dictionary<string, int>(rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                arySchema = sr.ReadOptimizedStringArray();
                tableName = arySchema[0];
                colName = arySchema[1];
                colType = arySchema[2];

                if (!listColumn.TryGetValue(colName, out colsCount))
                {
                    listColumn.Add(colName, 1);
                }
                else
                {
                    listColumn[colName] = colsCount + 1;
                    colName = colName + "_" + colsCount.ToString();
                }

                dtData.Columns.Add(colName, Type.GetType(colType));
            }
            listColumn.Clear();
            listColumn = null;
            dtData.TableName = tableName;
            return dtData;
        }
        #endregion

        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            dataClient.Disconnect();
        }
    }
}
