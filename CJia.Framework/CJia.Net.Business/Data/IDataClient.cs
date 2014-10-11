using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CJia.Net.Data
{
    /// <summary>
    /// 数据访问客户端
    /// </summary>
    interface IDataClient
    {
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        string QueryScalar(string TransID, string StrConn, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        byte[] Query(string TransID, string StrConn, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        DataTable QueryTable(string TransID, string StrConn, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        byte[] QueryProcedure(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params);
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        DataTable QueryProcedureTable(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params);
        /// <summary>
        /// 执行非查询SQL
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>影响的数据行数</returns>
        int Execute(string TransID, string StrConn, string SqlText, object[] SqlParams);
        /// <summary>
        /// 批量执行非查询SQL
        /// </summary>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组</param>
        /// <returns>影响的数据行数</returns>
        int BatchExecute(string TransID, string StrConn, string SqlText, System.Collections.Generic.List<object>[] BatchParams);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        Dictionary<string, object> ExecuteProcedure(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Param);
        /// <summary>
        /// 批量执行存储过程 
        /// </summary>
        /// <param name="TransID"></param>
        /// <param name="StrConn"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> BatchExecuteProcedure(string TransID, string StrConn, string ProcedureName, List<Dictionary<string, object>> Params);
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="TransID">事务ID</</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        DbDataReader QueryPaging(string TransID, string StrConn, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行查询存储过程返回结果集的分页
        /// </summary>
        /// <param name="TransID">连接字符串</param>
        /// <param name="StrConn">连接字符串</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        DbDataReader QueryProcedurePaging(string TransID, string StrConn, string ProcedureName, Dictionary<string, object> Params); 
        /// <summary>
        /// 判断是否存在某事务
        /// </summary>
        /// <param name="TransID"></param>
        /// <returns></returns>
        bool isExistTransaction(string TransID);
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        void CommitTransaction(string TransID);
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        void RollbackTransaction(string TransID);
    }
}
