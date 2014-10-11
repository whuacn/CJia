using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CJia.Net;

namespace CJia.Net.Service
{
    /// <summary>
    /// 数据访问接口
    /// </summary>
    [CJiaService(Version = "1.0.0.0")]
    public interface IDataAdapter
    {
        void Init(string ClientCode, string DbName);
        /// <summary>
        /// 执行查询SQL语句，返回第一行第一列值
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        string QueryScalar(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        byte[] Query(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams);
        /// <summary>
        /// 执行分页查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        int QueryPaging(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams);
        // <summary>
        /// 查询该分页接下来的一定行数据
        /// </summary>
        /// <param name="Paging">分页号</param>
        /// <param name="count">接下来的数据行</param>
        /// <returns>返回数据集</returns>
        byte[] QueryPagingData(int Paging, int count);
        /// <summary>
        /// 删除分页
        /// </summary>
        /// <param name="Paging"></param>
        void DeletePaging(int Paging);
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        int Execute(string ClientCode, string DbName, string TransID, string SqlText, object[] SqlParams);
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        int BatchExecute(string ClientCode, string DbName, string TransID, string SqlText, List<object>[] BatchParams);
        /// <summary>
        /// 执行查询存储过程返回结果集
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">Sql 文本</param>
        /// <param name="Params">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回结果集</returns>
        byte[] QueryProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Params);
        /// <summary>
        /// 执行查询存储过程返回结果集的分页
        /// </summary>
        /// <param name="ClientCode">客户端代码</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="TransID">事务ID</param>
        /// <param name="ProcedureName">Sql 文本</param>
        /// <param name="Params">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回分页id</returns>
        int QueryProcedurePaging(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Params); 
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ClientCode"></param>
        /// <param name="DbName"></param>
        /// <param name="TransID"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        Dictionary<string, object> ExecuteProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, Dictionary<string, object> Params);
        /// <summary>
        /// 批量执行存储过程 
        /// </summary>
        /// <param name="ClientCode"></param>
        /// <param name="DbName"></param>
        /// <param name="TransID"></param>
        /// <param name="ProcedureName"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> BatchExecuteProcedure(string ClientCode, string DbName, string TransID, string ProcedureName, List<Dictionary<string, object>> Params);
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

        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<string>> QueryDBConfig();
    }
}
