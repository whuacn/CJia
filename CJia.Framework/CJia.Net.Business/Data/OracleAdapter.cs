using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.Diagnostics;
using System.Data.Common;

namespace CJia.Net.Data
{
    /// <summary>
    /// Oracle数据访问组件
    /// </summary>
    public class OracleAdapter : IDataClient
    {
        /// <summary>
        /// Oracle数据访问组件
        /// </summary>
        public OracleAdapter()
        {

        }

        #region Transaction
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void CommitTransaction(string TransID)
        {
            OracleTransaction dbTrans = null;
            bool isExist = dictTransaction.TryGetValue(TransID, out dbTrans);
            if (isExist && dbTrans != null)
            {
                dbTrans.Commit();
                RemoveTransaction(TransID);
            }
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public void RollbackTransaction(string TransID)
        {
            OracleTransaction dbTrans = null;
            bool isExist = dictTransaction.TryGetValue(TransID, out dbTrans);
            if (isExist && dbTrans != null)
            {
                dbTrans.Rollback();
                RemoveTransaction(TransID);
            }
        }
        /// <summary>
        /// 移除事务
        /// </summary>
        /// <param name="TransID"></param>
        void RemoveTransaction(string TransID)
        {
            dictTransaction[TransID] = null;
            //关闭连接
            dictConnection[TransID].Close();
            dictConnection[TransID].Dispose();
            //移除事务
            dictConnection.Remove(TransID);
            dictTransaction.Remove(TransID);
        }
        /// <summary>
        /// 判断是否存在某事务
        /// </summary>
        /// <param name="TransID"></param>
        /// <returns></returns>
        public bool isExistTransaction(string TransID)
        {
            return dictTransaction.ContainsKey(TransID);
        }
        #endregion

        #region Connection
        Dictionary<string, OracleConnection> dictConnection = new Dictionary<string, OracleConnection>();
        Dictionary<string, OracleTransaction> dictTransaction = new Dictionary<string, OracleTransaction>();
        /// <summary>
        /// 获取Oracle连接
        /// </summary>
        /// <param name="TransID">事务ID</param>
        /// <param name="StrConn">连接字符串</param>
        /// <returns></returns>
        OracleConnection GetOracleConnection(string TransID, string StrConn)
        {
            System.Environment.SetEnvironmentVariable("ORA_NCHAR_LITERAL_REPLACE", "TRUE"); //2.26新添加 测试 九江
            if (TransID.Length == 0)
            {
                OracleConnection oraConn = new OracleConnection(StrConn);
                oraConn.Open();
                return oraConn;
            }

            OracleConnection transConn = null;
            bool isExist = dictConnection.TryGetValue(TransID, out transConn);
            if (isExist && transConn != null)
            {
                return transConn;
            }
            else
            {
                transConn = new OracleConnection(StrConn);
                transConn.Open();
                OracleTransaction dbTrans = transConn.BeginTransaction(IsolationLevel.ReadCommitted);
                lock (dictConnection)
                {
                    dictConnection.Add(TransID, transConn);
                    dictTransaction.Add(TransID, dbTrans);
                }
                return transConn;
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="TransID">事务ID</param>
        /// <param name="OraConnection">Oracle连接</param>
        void CloseConnection(string TransID, OracleConnection OraConnection)
        {
            if (TransID.Length == 0 && OraConnection != null)
            {
                OraConnection.Close();
                OraConnection.Dispose();
            }
        }
        #endregion

        #region Query
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public string QueryScalar(string TransID, string StrConn, string SqlText, object[] SqlParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using (OracleCommand oCmd = new OracleCommand(SqlText, oConn))
                {
                    CreateSqlParam(oCmd, SqlParams);
                    object result = oCmd.ExecuteScalar();
                    if (result != null) return result.ToString();
                    return "";
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="strConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public byte[] Query(string TransID, string StrConn, string SqlText, object[] SqlParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using (OracleCommand oCmd = new OracleCommand(SqlText, oConn))
                {
                    CreateSqlParam(oCmd, SqlParams);
                    using (OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        odr.FetchSize = 1000 * oCmd.RowSize;
                        using (DataTable dtSchema = odr.GetSchemaTable())
                        {
                            using (CJia.Net.Serialization.SerializationWriter sw = new Net.Serialization.SerializationWriter())
                            {
                                SerializationSchema(sw, dtSchema);
                                object[] aryValues = new object[odr.FieldCount];
                                while (odr.Read())
                                {
                                    odr.GetValues(aryValues);
                                    sw.WriteOptimized(aryValues);
                                }
                                aryValues = null;
                                return sw.ToArray();
                            }
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="strConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryTable(string TransID, string StrConn, string SqlText, object[] SqlParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using (OracleCommand oCmd = new OracleCommand(SqlText, oConn))
                {
                    CreateSqlParam(oCmd, SqlParams);
                    using (OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        odr.FetchSize = 1000 * oCmd.RowSize;
                        using (DataTable dtSchema = odr.GetSchemaTable())
                        {
                            DataTable dtResult = BuildDataTable(dtSchema);
                            object[] aryValues = new object[odr.FieldCount];
                            dtResult.BeginLoadData();
                            while (odr.Read())
                            {
                                odr.GetValues(aryValues);
                                dtResult.LoadDataRow(aryValues, true);
                            }
                            dtResult.EndLoadData();
                            aryValues = null;
                            return dtResult;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public byte[] QueryProcedure(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using(OracleCommand oCmd = new OracleCommand(ProcedureName, oConn))
                {
                    oCmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter cursor = new OracleParameter();
                    cursor.ParameterName = "C_CURSOR";
                    cursor.OracleDbType = OracleDbType.RefCursor;
                    cursor.Direction = ParameterDirection.Output;
                    oCmd.Parameters.Add(cursor);
                    CreateSqlProcedureParam(oCmd, Params);
                    using(OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        using(DataTable dtSchema = odr.GetSchemaTable())
                        {
                            using(CJia.Net.Serialization.SerializationWriter sw = new Net.Serialization.SerializationWriter())
                            {
                                SerializationSchema(sw, dtSchema);
                                object[] aryValues = new object[odr.FieldCount];
                                while(odr.Read())
                                {
                                    odr.GetValues(aryValues);
                                    sw.WriteOptimized(aryValues);
                                }
                                aryValues = null;
                                return sw.ToArray();
                            }
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DataTable QueryProcedureTable(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using(OracleCommand oCmd = new OracleCommand(ProcedureName, oConn))
                {
                    oCmd.CommandType = CommandType.StoredProcedure;
                    CreateSqlProcedureParam(oCmd, Params);
                    using(OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        using(DataTable dtSchema = odr.GetSchemaTable())
                        {
                            DataTable dtResult = BuildDataTable(dtSchema);
                            object[] aryValues = new object[odr.FieldCount];
                            dtResult.BeginLoadData();
                            while(odr.Read())
                            {
                                odr.GetValues(aryValues);
                                dtResult.LoadDataRow(aryValues, true);
                            }
                            dtResult.EndLoadData();
                            aryValues = null;
                            return dtResult;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 分页查询SQL语句
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="strConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public DbDataReader QueryPaging(string TransID, string StrConn, string SqlText, object[] SqlParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                OracleCommand oCmd = new OracleCommand(SqlText, oConn);
                CreateSqlParam(oCmd, SqlParams);
                OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return odr;
            }
            catch(Exception ex)
            {
                CloseConnection(TransID, oConn);
                throw ex;
            }
        }
        /// <summary>
        /// 分页执行存储过程
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="strConn">连接字符串</param>
        /// <param name="ProcedureName">事务ID</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回Reader</returns>
        public DbDataReader QueryProcedurePaging(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                OracleCommand oCmd = new OracleCommand(ProcedureName, oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                CreateSqlProcedureParam(oCmd, Params);
                OracleDataReader odr = oCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return odr;
            }
            catch(Exception ex)
            {
                CloseConnection(TransID, oConn);
                throw ex;
            }
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
            for (int i = 0; i < dtSchema.Rows.Count; i++)
            {
                drSchema = dtSchema.Rows[i];
                sw.WriteOptimized(new string[] { drSchema["BaseTableName"].ToString(), drSchema["ColumnName"].ToString(), drSchema["DataType"].ToString() });
            }
        }
        /// <summary>
        /// 根据表结构创建数据表
        /// </summary>
        /// <param name="dtSchema">表结构</param>
        /// <returns></returns>
        DataTable BuildDataTable(DataTable dtSchema)
        {
            string colName, colType, tableName = "";
            DataTable dtData = new DataTable();
            int colsCount = 0;
            int rowsCount = dtSchema.Rows.Count;
            Dictionary<string, int> listColumn = new Dictionary<string, int>(rowsCount);
            DataRow drSchema;
            for (int i = 0; i < dtSchema.Rows.Count; i++)
            {
                drSchema = dtSchema.Rows[i];
                tableName = drSchema["BaseTableName"].ToString();
                colName = drSchema["ColumnName"].ToString();
                colType = drSchema["DataType"].ToString();

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

        #region Execute
        /// <summary>
        /// 执行非查询SQL
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>影响的数据行数</returns>
        public int Execute(string TransID, string StrConn, string SqlText, object[] SqlParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using (OracleCommand oCmd = new OracleCommand(SqlText, oConn))
                {
                    CreateSqlParam(oCmd, SqlParams);
                    return oCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }
        /// <summary>
        /// 批量执行非查询SQL
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组</param>
        /// <returns>影响的数据行数</returns>
        public int BatchExecute(string TransID, string StrConn, string SqlText, List<object>[] BatchParams)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using (OracleCommand oCmd = new OracleCommand(SqlText, oConn))
                {
                    if (BatchParams != null && BatchParams.Length > 0 && BatchParams[0].Count > 0)
                    {
                        oCmd.ArrayBindCount = BatchParams[0].Count;
                        oCmd.BindByName = true;
                        for (int i = 0; i < BatchParams.Length; i++)
                        {
                            OracleParameter op = new OracleParameter((i + 1).ToString(), OracleDbType.Varchar2);
                            op.Value = BatchParams[i].ToArray();
                            oCmd.Parameters.Add(op);
                        }
                        return oCmd.ExecuteNonQuery();
                    }
                    return -1;
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }

        /// <summary>
        /// 执行存储过程 
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParams"></param>
        /// <param name="OutputParams"></param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteProcedure(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Param)
        {
            OracleConnection oConn = GetOracleConnection(TransID, StrConn);
            try
            {
                using(OracleCommand oCmd = new OracleCommand(ProcedureName, oConn))
                {
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.BindByName = true;
                    CreateSqlProcedureParam(oCmd, Param);
                    oCmd.ExecuteNonQuery();
                    ReturnSqlProcedureOutputParam(oCmd, ref Param);
                    return Param;
                }
            }
            finally
            {
                CloseConnection(TransID, oConn);
            }
        }

        /// <summary>
        /// 批量执行存储过程 
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="InputParams"></param>
        /// <param name="OutputParams"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> BatchExecuteProcedure(string TransID, string StrConn, string ProcedureName, List<Dictionary<string, object>> Params)
        {
            for(int i = 0; i < Params.Count; i++)
            {
                Params[i] = ExecuteProcedure(TransID, StrConn, ProcedureName, Params[i]);
            }
            return Params;
        }

        #endregion

        #region Params
        /// <summary>
        /// 通过参数数组创建OracleParameter，参数值所在位置必须与参数名一致
        /// </summary>
        /// <param name="oCmd"></param>
        /// <param name="SqlParams"></param>
        private void CreateSqlParam(OracleCommand oCmd, object[] SqlParams)
        {
            if (SqlParams == null || SqlParams.Length == 0) return;
            for (int i = 0; i < SqlParams.Length; i++)
            {
                OracleParameter oParam = new OracleParameter();
                oParam.ParameterName = (i + 1).ToString();
                oParam.Value = SqlParams[i];
                oCmd.Parameters.Add(oParam);
            }
        }

         /// <summary>
        /// 通过字典集合创建OracleParameter
        /// </summary>
        /// <param name="oCmd"></param>
        /// <param name="Params"></param>
        private void CreateSqlProcedureParam(OracleCommand oCmd, Dictionary<string, object> Params)
        {
            if(Params == null || Params.Count == 0)
                return;
            foreach(string key in Params.Keys)
            {
                OracleParameter oParam = new OracleParameter();
                oParam.Direction = GetDirection(key);
                oParam.Size = 4000;
                oParam.ParameterName = key;
                oParam.Value = Params[key];
                oCmd.Parameters.Add(oParam);
            }
        }

        /// <summary>
        /// 返回存储过程的输出参数
        /// </summary>
        /// <param name="oCmd"></param>
        /// <param name="Params"></param>
        private void ReturnSqlProcedureOutputParam(OracleCommand oCmd, ref Dictionary<string, object> Params)
        {
            if(Params == null || Params.Count == 0)
                return;
            string[] keys = Params.Keys.ToArray<string>();
            foreach(string key in keys)
            {
                Params[key] = oCmd.Parameters[key].Value;
            }
        }
        /// <summary>
        /// 根据参数名确定参数类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ParameterDirection GetDirection(string key)
        {
            string[] keys = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            if(keys.Length > 0)
            {
                if(keys[0].ToUpper() == "I")
                {
                    return ParameterDirection.Input;
                }
                else if(keys[0].ToUpper() == "O")
                {
                    return ParameterDirection.Output;
                }
                else if(keys[0].ToUpper() == "IO")
                {
                    return ParameterDirection.InputOutput;
                }
                else
                {
                }
            }
            throw new Exception("数据库 存错过程/函数 参数名称有误！输入参数必须以 'I_' 开头,输出参数必须以 'O_' 开头, 输入输出参数必须以 'IO_' 开头 ");
        }
        #endregion

        #region Dependency
        Dictionary<string, OracleCommand> dictCommand = null;
        Dictionary<string, OracleDependency> dictDependency = null;
        /// <summary>
        /// 创建监听
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="SqlText">监听Sql</param>
        /// <returns></returns>
        public OracleDependency CreateDependency(string StrConn, string SqlText)
        {
            if (dictDependency == null)
            {
                dictDependency = new Dictionary<string, OracleDependency>();
                dictCommand = new Dictionary<string, OracleCommand>();
            }
            else
                CheckListenCmd(StrConn, SqlText);

            OracleConnection oConn = new OracleConnection(StrConn);
            oConn.Open();
            OracleCommand depCmd = new OracleCommand(SqlText, oConn);
            OracleDependency oraDep = new OracleDependency(depCmd, false, 0, false);
            //oraDep.RowidInfo = OracleRowidInfo.Include;//是否包含Rowid
            //oraDep.QueryBasedNotification = true;//true：按指定查询监听false：按数据表监听
            //以下属性可在OracleDependency的构造函数中设定
            //depCmd.Notification.IsPersistent: False表示Notification将被存于内存中，True表示存于数据库中，选择True可以保证即便数据库重启之后，消息仍然不会丢失
            //depCmd.Notification.IsNotifiedOnce = false;是否在一次Notification后立即移除此次注册
            //depCmd.Notification.Timeout = 0;此次注册的超时时间（秒），超过此时间，注册将被自动移除。0表示不超时。

            dictConnection.Add(oraDep.Id, oConn);
            dictDependency.Add(oraDep.Id, oraDep);
            dictCommand.Add(oraDep.Id, depCmd);

            return oraDep;
        }

        void CheckListenCmd(string StrConn, string SqlText)
        {
            string cmdStrConn, cmdSqlText;
            foreach (string key in dictCommand.Keys)
            {
                cmdStrConn = dictCommand[key].Connection.ConnectionString.ToUpper();
                cmdSqlText = dictCommand[key].CommandText.ToUpper();
                if (cmdStrConn == StrConn.ToUpper() && cmdSqlText == SqlText.ToUpper())
                    throw new Exception("该监听已在此连接中注册。\n" + SqlText);
            }
        }
        /// <summary>
        /// 创建之后，可以通过ID获取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public OracleDependency GetDependencyByID(string ID)
        {
            return dictDependency[ID];
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        public void BeginListen(string ListenID)
        {
            dictCommand[ListenID].ExecuteNonQuery();
        }
        /// <summary>
        /// 移除监听
        /// </summary>
        public void RemoveDependency(string ListenID)
        {
            OracleDependency oraDep = dictDependency[ListenID];
            if (oraDep != null)
            {
                OracleConnection oConn = dictConnection[ListenID];
                oraDep.RemoveRegistration(oConn);
                oraDep = null;
                OracleCommand depCmd = dictCommand[ListenID];
                depCmd.Dispose();
                depCmd = null;
                oConn.Close();
                oConn.Dispose();
                oConn = null;

                dictConnection.Remove(ListenID);
                dictCommand.Remove(ListenID);
                dictDependency.Remove(ListenID);
            }
        }
        #endregion
    }
}
