using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Net.Data
{
    /// <summary>
    /// 数据库连接信息
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// 数据库连接信息
        /// </summary>
        public DBConnection() { }
        /// <summary>
        /// 数据库连接信息
        /// </summary>
        public DBConnection(string dbType, string connectionString)
        {
            DBType = dbType;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// 数据库类别
        /// </summary>
        public string DBType { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
