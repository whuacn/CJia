using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia
{
    /// <summary>
    /// 远程数据库配置名称，不同配置对应不同数据库连接字符串
    /// </summary>
    public enum DbConfigName
    {
        /// <summary>
        /// 缺省数据库配置
        /// </summary>
        Default,
        /// <summary>
        /// 全局数据库配置
        /// </summary>
        Global,
        /// <summary>
        /// Sql Server数据库
        /// </summary>
        SqlDB,
        /// <summary>
        /// OleDb 连接数据库
        /// </summary>
        OleDb,
        /// <summary>
        /// 阴道镜数据库
        /// </summary>
        SqlGoldWayDB,
        /// <summary>
        /// sqlite数据库
        /// </summary>
        SQLite,
        /// <summary>
        /// Postgre数据库
        /// </summary>
        Postgre
    }
    /// <summary>
    /// 客户端配置
    /// </summary>
    public class ClientConfig
    {
        /// <summary>
        /// 服务器IP，默认为：127.0.0.1
        /// </summary>
        public static string ServerIP = "127.0.0.1";
        /// <summary>
        /// 服务器端口，默认为：10920
        /// </summary>
        public static int ServerPort = 10920;
        /// <summary>
        /// 默认为CJClient
        /// </summary>
        public static string ClientNo = "CJiaClient";
        /// <summary>
        /// 默认为CJSystem
        /// </summary>
        public static string SystemNo = "CJiaSystem";
        /// <summary>
        /// 默认为缺省数据库配置
        /// </summary>
        public static DbConfigName DefaultDbName = DbConfigName.Default;
    }
}
