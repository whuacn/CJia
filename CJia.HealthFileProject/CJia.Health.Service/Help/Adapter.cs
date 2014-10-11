using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;

/// <summary>
/// Adapter 的摘要说明
/// </summary>
public class Adapter : IDisposable
{
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
        dbConn.ConnectionString = "Data Source=JJCJ_JJFB; User Id=mhis; Password=mhis;Provider=MSDAORA;Persist Security Info=True;";
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
