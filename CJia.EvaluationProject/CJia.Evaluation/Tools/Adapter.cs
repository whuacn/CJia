using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using CJia.Evaluation.Tools;

/// <summary>
/// Adapter 的摘要说明
/// </summary>
public class Adapter : IDisposable
{
    public string Cnn = ConfigHelper.GetAppStrings("conn");
    OleDbConnection dbConn = new OleDbConnection();
    OleDbCommand dbCmd = new OleDbCommand();
    public Adapter(string ConntionString)
    {
        dbConn.ConnectionString = ConntionString;
        dbCmd.Connection = dbConn;
        dbConn.Open();
    }
    public Adapter()
    {
        dbConn.ConnectionString = Cnn;
        dbCmd.Connection = dbConn;
        dbConn.Open();
    }
    /// <summary>
    /// 生成SQL参数
    /// </summary>
    /// <param name="SqlParams"></param>
    /// <param name="cmd"></param>
    private void BuildCmdParams(OleDbCommand cmd, object[] SqlParams)
    {
        if ((SqlParams == null) || (SqlParams.Length == 0)) return;
        cmd.Parameters.Clear();
        for (int i = 0; i < SqlParams.Length; i++)
        {
            OleDbParameter oraParam = new OleDbParameter((i + 1).ToString(), SqlParams[i]);
            oraParam.Size = 4000;
            cmd.Parameters.Add(oraParam);
        }
    }
    /// <summary>
    /// 执行非查询Sql
    /// </summary>
    /// <param name="SqlText">SQL文本</param>
    /// <param name="Params">SQL参数</param>
    public int Execute(string SqlText, object[] Params)
    {
        dbCmd.CommandType = CommandType.Text;
        dbCmd.CommandText = SqlText;
        BuildCmdParams(dbCmd, Params);
        return dbCmd.ExecuteNonQuery();
    }
    /// <summary>
    /// 执行查询SQL，仅返回第一行第一列值
    /// </summary>
    /// <param name="SqlText">SQL文本</param>
    /// <param name="Params">SQL参数</param>
    /// <returns>第一行第一列值</returns>
    public string QueryScalar(string SqlText, object[] Params)
    {
        dbCmd.CommandType = CommandType.Text;
        dbCmd.CommandText = SqlText;
        BuildCmdParams(dbCmd, Params);
        object value = dbCmd.ExecuteScalar();
        if (value != null)
        {
            return value.ToString();
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 执行查询SQL
    /// </summary>
    /// <param name="dsResult">类型化数据集</param>
    /// <param name="TableName">表名</param>
    /// <param name="SqlText">SQL文本</param>
    /// <param name="Params">SQL参数</param>
    /// <returns>查询结果</returns>
    public DataTable Query(string SqlText, object[] Params)
    {
        dbCmd.CommandType = CommandType.Text;
        dbCmd.CommandText = SqlText;
        BuildCmdParams(dbCmd, Params);
        using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCmd))
        {
            DataSet dsResult = new DataSet();
            dbAdapter.Fill(dsResult);
            return dsResult.Tables[0];
        }
    }

    #region//事务操作数据库
    /// <summary>
    /// 执行两个非查询语句
    /// </summary>
    /// <param name="sql1"></param>
    /// <param name="Params1"></param>
    /// <param name="sql2"></param>
    /// <param name="Params2"></param>
    /// <returns></returns>
    public int ExeTransaction(string sql1, object[] Params1, string sql2, object[] Params2)
    {
        OleDbTransaction m_OraTrans = dbConn.BeginTransaction();//创建事务对象
        dbCmd.Transaction = m_OraTrans;
        int influenceRowCount = 0;
        try
        {
            dbCmd.CommandType = CommandType.Text;
            dbCmd.CommandText = sql1;
            BuildCmdParams(dbCmd, Params1);
            influenceRowCount += dbCmd.ExecuteNonQuery();
         
            dbCmd.CommandType = CommandType.Text;
            dbCmd.CommandText = sql2;
            BuildCmdParams(dbCmd, Params2);
            influenceRowCount += dbCmd.ExecuteNonQuery();
        
            m_OraTrans.Commit();
            return influenceRowCount;
        }
        catch (OleDbException ex)
        {
            m_OraTrans.Rollback();
            throw ex;
        }
    }

    /// <summary>
    /// 执行一组非查询语句
    /// </summary>
    /// <param name="sqlList">sql</param>
    /// <param name="obList">参数</param>
    /// <returns></returns>
    public int ExeTransaction(string sql,List<object[]> obList)
    {
        OleDbTransaction m_OraTrans = dbConn.BeginTransaction();//创建事务对象
        dbCmd.Transaction = m_OraTrans;
        int influenceRowCount = 0;
        try
        {
            for (int i = 0; i < obList.Count; i++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql;
                object[] Params = obList[i];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            m_OraTrans.Commit();
            return influenceRowCount;
        }
        catch (OleDbException ex)
        {
            m_OraTrans.Rollback();
            throw ex;
        }
    }

    /// <summary>
    /// 执行两个非查询语句组
    /// </summary>
    /// <param name="sqlList">sql</param>
    /// <param name="obList">参数</param>
    /// <returns></returns>
    public int ExeTransaction(string sql1, List<object[]> obList1, string sql2, List<object[]> obList2)
    {
        OleDbTransaction m_OraTrans = dbConn.BeginTransaction();//创建事务对象
        dbCmd.Transaction = m_OraTrans;
        int influenceRowCount = 0;
        try
        {
            for (int i = 0; i < obList1.Count; i++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql1;
                object[] Params = obList1[i];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int j = 0; j < obList2.Count; j++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql2;
                object[] Params = obList2[j];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            m_OraTrans.Commit();
            return influenceRowCount;
        }
        catch (OleDbException ex)
        {
            m_OraTrans.Rollback();
            throw ex;
        }
    }

    /// <summary>
    /// 执行三组非查询语句组
    /// </summary>
    /// <param name="sqlList">sql</param>
    /// <param name="obList">参数</param>
    /// <returns></returns>
    public int ExeTransaction(string sql1, List<object[]> obList1, string sql2, List<object[]> obList2, string sql3, List<object[]> obList3)
    {
        OleDbTransaction m_OraTrans = dbConn.BeginTransaction();//创建事务对象
        dbCmd.Transaction = m_OraTrans;
        int influenceRowCount = 0;
        try
        {
            for (int i = 0; i < obList1.Count; i++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql1;
                object[] Params = obList1[i];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int j = 0; j < obList2.Count; j++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql2;
                object[] Params = obList2[j];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int k = 0; k < obList3.Count; k++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql3;
                object[] Params = obList3[k];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            m_OraTrans.Commit();
            return influenceRowCount;
        }
        catch (OleDbException ex)
        {
            m_OraTrans.Rollback();
            throw ex;
        }
    }

    /// <summary>
    /// 执行三组非查询语句组
    /// </summary>
    /// <param name="sqlList">sql</param>
    /// <param name="obList">参数</param>
    /// <returns></returns>
    public int ExeTransaction(string sql1, List<object[]> obList1, string sql2, List<object[]> obList2, string sql3, List<object[]> obList3, string sql4, List<object[]> obList4)
    {
        OleDbTransaction m_OraTrans = dbConn.BeginTransaction();//创建事务对象
        dbCmd.Transaction = m_OraTrans;
        int influenceRowCount = 0;
        try
        {
            for (int i = 0; i < obList1.Count; i++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql1;
                object[] Params = obList1[i];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int j = 0; j < obList2.Count; j++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql2;
                object[] Params = obList2[j];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int k = 0; k < obList3.Count; k++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql3;
                object[] Params = obList3[k];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            for (int m = 0; m < obList4.Count; m++)
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql4;
                object[] Params = obList4[m];
                BuildCmdParams(dbCmd, Params);
                influenceRowCount += dbCmd.ExecuteNonQuery();
            }
            m_OraTrans.Commit();
            return influenceRowCount;
        }
        catch (OleDbException ex)
        {
            m_OraTrans.Rollback();
            throw ex;
        }
    }
    #endregion

    #region IDisposable 成员
    /// <summary>
    ///  清理所有正在使用的资源
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    /// <summary>
    /// 清除托管资源
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (dbCmd != null)
            {
                dbCmd.Dispose();
                dbCmd = null;
            }
            if (dbConn != null)
            {//关闭数据库连接

                dbConn.Close();
                dbConn.Dispose();
            }
        }
    }
    #endregion
}
