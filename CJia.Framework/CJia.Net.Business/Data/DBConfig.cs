using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Net.Data
{
    public class DBConfig
    {
        /// <summary>
        /// 数据库连接配置字典
        /// </summary>
        public static Dictionary<string, Dictionary<string, DBConnection>> dictConfig = new Dictionary<string, Dictionary<string, DBConnection>>();

        /// <summary>
        /// 加载数据库连接配置
        /// 1.允许不同的客户端连接不同的数据库；
        /// 2.允许设置同一客户端连接不同的数据库；
        /// 结构如下：
        /// ClientCode1{DefaultDB；GlobalDB；PharmDB}
        /// ClientCode2{DefaultDB；GlobalDB；PharmDB}
        /// ClientCode = ClientNo+'-'+SystemNo即允许配置不同客户端不同系统登录不同数据库
        /// </summary>
        public static void Load(Dictionary<string, Dictionary<string, DBConnection>> dic)
        {
            dictConfig = dic;
            //Dictionary<string, DBConnection> dictDBConnection = new Dictionary<string, DBConnection>();
            //DBConnection DefaultOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=test; Password=test;");
            //DBConnection DefaultSqlServer = new DBConnection("SQL", "Data Source=192.168.1.204;Initial Catalog=CJia_CheckRegOrder;User Id=shcj;Password=cj123!@#;");
            //DBConnection SqlGoldWayDB = new DBConnection("SQL", "Data Source=192.168.1.202;Initial Catalog=GoldWay;User Id=cjia;Password=cj123!@#;");
            //DBConnection DefaultSQLite = new DBConnection("SQLite", @"Data Source=E:\CJia\CJia.Solution\Database\iMobileMedical.db; Pooling=True;");
            //DBConnection HISOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=cjhis; Password=cjhis;");
            //DBConnection ToolsOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=tools; Password=tools;");
            //dictDBConnection.Add("Default", DefaultOracle);
            //dictDBConnection.Add("OracleDB", DefaultOracle);
            //dictDBConnection.Add("SqlDB", DefaultSqlServer);
            //dictDBConnection.Add("SQLiteDB", DefaultSQLite);
            //dictDBConnection.Add("SqlGoldWayDB", SqlGoldWayDB);
            //dictConfig.Add("CJiaClient-CJiaSystem", dictDBConnection);

            //Dictionary<string, DBConnection> HISDBConnection = new Dictionary<string, DBConnection>();
            //HISDBConnection.Add("Default", HISOracle);
            //dictConfig.Add("CJiaClient-CJiaHISSystem", HISDBConnection);

            //Dictionary<string, DBConnection> ToolsDBConnection = new Dictionary<string, DBConnection>();
            //ToolsDBConnection.Add("Default", ToolsOracle);
            //dictConfig.Add("CJiaToolsClient-CJiaToolsSystem", ToolsDBConnection);
        }
        /// <summary>
        /// 加载数据库连接配置
        /// 1.允许不同的客户端连接不同的数据库；
        /// 2.允许设置同一客户端连接不同的数据库；
        /// 结构如下：
        /// ClientCode1{DefaultDB；GlobalDB；PharmDB}
        /// ClientCode2{DefaultDB；GlobalDB；PharmDB}
        /// ClientCode = ClientNo+'-'+SystemNo即允许配置不同客户端不同系统登录不同数据库
        /// </summary>
        public static void Load()
        {
            Dictionary<string, DBConnection> dictDBConnection = new Dictionary<string, DBConnection>();
            DBConnection DefaultOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=PIVAS; Password=PIVAS;");
            DBConnection DefaultSqlServer = new DBConnection("SQL", "Data Source=192.168.1.204;Initial Catalog=CJia_CheckRegOrder;User Id=shcj;Password=cj123!@#;");
            DBConnection SqlGoldWayDB = new DBConnection("SQL", "Data Source=192.168.1.202;Initial Catalog=GoldWay;User Id=cjia;Password=cj123!@#;");
            DBConnection DefaultSQLite = new DBConnection("SQLite", @"Data Source=E:\CJia\CJia.Solution\Database\iMobileMedical.db; Pooling=True;");
            DBConnection HISOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=CJHIS; Password=CJHIS;");
            DBConnection ToolsOracle = new DBConnection("ORACLE", "Data Source=SHCJ; User Id=tools; Password=tools;");
            DBConnection DefaultPostgre = new DBConnection("Postgre", "server=192.168.1.206;port=5432;user id=icheck;password=icheck;Database=postgres;");
            dictDBConnection.Add("Default", DefaultOracle);
            dictDBConnection.Add("OracleDB", DefaultOracle);
            dictDBConnection.Add("SqlDB", DefaultSqlServer);
            dictDBConnection.Add("SQLiteDB", DefaultSQLite);
            dictDBConnection.Add("SqlGoldWayDB", SqlGoldWayDB);
            dictDBConnection.Add("Postgre", DefaultPostgre);
            dictConfig.Add("CJiaClient-CJiaSystem", dictDBConnection);

            Dictionary<string, DBConnection> HISDBConnection = new Dictionary<string, DBConnection>();
            HISDBConnection.Add("Default", HISOracle);
            dictConfig.Add("CJiaClient-CJiaHISSystem", HISDBConnection);

            Dictionary<string, DBConnection> ToolsDBConnection = new Dictionary<string, DBConnection>();
            ToolsDBConnection.Add("Default", ToolsOracle);
            dictConfig.Add("CJiaToolsClient-CJiaToolsSystem", ToolsDBConnection);

            Dictionary<string, DBConnection> PEISDBConnection = new Dictionary<string, DBConnection>();
            ToolsDBConnection.Add("Postgre", DefaultPostgre);
            dictConfig.Add("CJiaPEISClient-CJiaPEISSystem", ToolsDBConnection);
        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="ClientCode"></param>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public static DBConnection GetDBConnection(string ClientCode, string DbName)
        {
            if(DbName == "pading")//用于分页
                return null;
            Dictionary<string, DBConnection> dictDBConnection = null;
            bool isExists = dictConfig.TryGetValue(ClientCode, out dictDBConnection);
            if (isExists && dictDBConnection != null)
            {
                DBConnection dbConnection = null;
                isExists = dictDBConnection.TryGetValue(DbName, out dbConnection);
                if (isExists && dbConnection != null)
                {
                    return dbConnection;
                }
                else
                {
                    throw new Exception("未配置数据库连接，请与管理员联系。");
                }
            }
            else
            {
                throw new Exception("未找到代码为：" + ClientCode + "的客户端配置。");
            }
        }
    }
}
