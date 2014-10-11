using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia
{
    /// <summary>
    /// 缺省SQL数据库访问组件
    /// </summary>
    public static class DefaultSQLite
    {
        static DataAdapter ada;
        /// <summary>
        /// 缺省SQL数据访问
        /// </summary>
        public static DataAdapter DefaultAdapter
        {
            get
            {
                return ada;
            }
        }
        /// <summary>
        /// 缺省数据库访问组件
        /// </summary>
        static DefaultSQLite()
        {
            ada = new DataAdapter(DbConfigName.SQLite.ToString());
        }
        #region 无事务操作
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string SqlText)
        {
            return ada.QueryScalar(SqlText);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string SqlText, List<object> SqlParams)
        {
            return ada.QueryScalar(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string SqlText, object[] SqlParams)
        {
            return ada.QueryScalar(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string SqlText)
        {
            return ada.Query(SqlText);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string SqlText, List<object> SqlParams)
        {
            return ada.Query(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string SqlText, object[] SqlParams)
        {
            return ada.Query(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>返回数据集</returns>
        public static DataTable QueryProcedure(string ProcedureName)
        {
            return ada.QueryProcedure(ProcedureName);
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>返回数据集</returns>
        public static DataTable QueryProcedure(string ProcedureName, Dictionary<string, object> Params)
        {
            return ada.QueryProcedure(ProcedureName, Params);
        }
        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回分页id</returns>
        public static int QueryPaging(string SqlText)
        {
            return ada.QueryPaging(SqlText);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回分页id</returns>
        public static int QueryPaging(string SqlText, List<object> SqlParams)
        {
            return ada.QueryPaging(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回分页id</returns>
        public static int QueryPaging(string SqlText, object[] SqlParams)
        {
            return ada.QueryPaging(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>分页id</returns>
        public static int QueryProcedurePaging(string ProcedureName)
        {
            return ada.QueryProcedurePaging(ProcedureName);
        }
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>分页id</returns>
        public static int QueryProcedurePaging(string ProcedureName, Dictionary<string, object> Params)
        {
            return ada.QueryProcedurePaging(ProcedureName, Params);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string SqlText)
        {
            return ada.Execute(SqlText);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string SqlText, List<object> SqlParams)
        {
            return ada.Execute(SqlText, SqlParams);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string SqlText, object[] SqlParams)
        {
            return ada.Execute(SqlText, SqlParams);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string SqlText, List<object> BatchParam1)
        {
            return ada.BatchExecute(SqlText, BatchParam1);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string SqlText, List<object> BatchParam1, List<object> BatchParam2)
        {
            return ada.BatchExecute(SqlText, BatchParam1, BatchParam2);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <param name="BatchParam3">第3个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string SqlText, List<object> BatchParam1, List<object> BatchParam2, List<object> BatchParam3)
        {
            return ada.BatchExecute(SqlText, BatchParam1, BatchParam2, BatchParam3);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string SqlText, List<object>[] BatchParams)
        {
            return ada.BatchExecute(SqlText, BatchParams);
        }

        /// <summary>
        /// 执行存储过程 不带参数
        /// </summary>
        /// <param name="ProcedureName">参数字典</param>
        public static void ExecuteProcedure(string ProcedureName)
        {
            ada.ExecuteProcedure(ProcedureName);
        }

        /// <summary>
        /// 执行存储过程 带输出参数
        /// </summary>
        /// <param name="ProcedureName">存储过程名称</param>
        /// <param name="Param">参数字典</param>
        public static void ExecuteProcedure(string ProcedureName, ref Dictionary<string, object> Param)
        {
            ada.ExecuteProcedure(ProcedureName, ref Param);
        }

        /// <summary>
        /// 批量执行存储过程 带输入参数不带输出参数
        /// </summary>
        /// <param name="ProcedureName">存储过程名称</param>
        /// <param name="Params">参数字典</param>
        public static void BatchExecuteProcedure(string ProcedureName, ref List<Dictionary<string, object>> Params)
        {
            ada.BatchExecuteProcedure(ProcedureName, ref Params);
        }
        #endregion

        #region 有事务操作
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string TransID, string SqlText)
        {
            return ada.QueryScalar(TransID, SqlText);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string TransID, string SqlText, List<object> SqlParams)
        {
            return ada.QueryScalar(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL，仅返回第一行第一列值
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回字符串</returns>
        public static string QueryScalar(string TransID, string SqlText, object[] SqlParams)
        {
            return ada.QueryScalar(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string TransID, string SqlText)
        {
            return ada.Query(TransID, SqlText);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string TransID, string SqlText, List<object> SqlParams)
        {
            return ada.Query(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回数据集</returns>
        public static DataTable Query(string TransID, string SqlText, object[] SqlParams)
        {
            return ada.Query(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>返回数据集</returns>
        public static DataTable QueryProcedure(string TransID, string ProcedureName)
        {
            return ada.QueryProcedure(TransID, ProcedureName);
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Params">参数列表</param>
        /// <returns>返回数据集</returns>
        public static DataTable QueryProcedure(string TransID, string ProcedureName, Dictionary<string, object> Params)
        {
            return ada.QueryProcedure(TransID, ProcedureName, Params);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string TransID, string SqlText)
        {
            return ada.Execute(TransID, SqlText);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string TransID, string SqlText, List<object> SqlParams)
        {
            return ada.Execute(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="SqlParams">Sql 参数，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int Execute(string TransID, string SqlText, object[] SqlParams)
        {
            return ada.Execute(TransID, SqlText, SqlParams);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string TransID, string SqlText, List<object> BatchParam1)
        {
            return ada.BatchExecute(TransID, SqlText, BatchParam1);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParam1">第1个参数组</param>
        /// <param name="BatchParam2">第2个参数组</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string TransID, string SqlText, List<object> BatchParam1, List<object> BatchParam2)
        {
            return ada.BatchExecute(TransID, SqlText, BatchParam1, BatchParam2);
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
        public static int BatchExecute(string TransID, string SqlText, List<object> BatchParam1, List<object> BatchParam2, List<object> BatchParam3)
        {
            return ada.BatchExecute(TransID, SqlText, BatchParam1, BatchParam2, BatchParam3);
        }
        /// <summary>
        /// 批量执行非查询SQL语句
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="SqlText">Sql 文本</param>
        /// <param name="BatchParams">Sql 参数数组，参数值所在位置必须与参数名一致</param>
        /// <returns>返回影响的数据行</returns>
        public static int BatchExecute(string TransID, string SqlText, List<object>[] BatchParams)
        {
            return ada.BatchExecute(TransID, SqlText, BatchParams);
        }

        /// <summary>
        /// 执行存储过程 不带参数
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        public static void ExecuteProcedure(string TransID, string ProcedureName)
        {
            ada.ExecuteProcedure(TransID, ProcedureName);
        }

        /// <summary>
        /// 执行存储过程 带参数
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="Param">参数字典</param>
        /// <returns>参数字典</returns>
        public static void ExecuteProcedure(string TransID, string ProcedureName, ref Dictionary<string, object> Param)
        {
            ada.ExecuteProcedure(TransID, ProcedureName, ref Param);
        }

        /// <summary>
        /// 批量执行存储过程 带输入参数不带输出参数
        /// </summary>
        ///<param name="TransID">事务ID</param>
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="InputParams">输入参数</param>
        public static void BatchExecuteProcedure(string TransID, string ProcedureName, ref List<Dictionary<string, object>> Params)
        {
            ada.BatchExecuteProcedure(TransID, ProcedureName, ref Params);
        }
        #endregion

        #region 事务处理
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public static void CommitTransaction(string TransID)
        {
            ada.CommitTransaction(TransID);
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="TransID">事务ID</param>
        public static void RollbackTransaction(string TransID)
        {
            ada.RollbackTransaction(TransID);
        }
        #endregion
    }
}
