using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.Tools
{
    /// <summary>
    /// 数据源  种类
    /// </summary>
    public enum DBType
    {
        /// <summary>
        /// BI数据源
        /// </summary>
        BI,
        /// <summary>
        /// 数据库数据源
        /// </summary>
        DT,
        /// <summary>
        /// 九江妇保 今创病案系统数据库
        /// </summary>
        JJFBDB,
        /// <summary>
        /// 慧软HQMS数据库
        /// </summary>
        HQMSDB
    }
    public class DBConnHelper
    {
        /// <summary>
        /// 数据源切换  根据DBType数据源  种类 进行数据源的切换 
        /// </summary>
        /// <param name="dbType"></param>
        public static void DBSwitchover(DBType dbType)
        {
            CJia.ClientConfig client = new ClientConfig();
            switch (dbType)
            {
                case DBType.BI:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("BIClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("BISystemNo");
                    CJia.DefaultOleDb.DefaultAdapter = new DataAdapter(DbConfigName.OleDb.ToString());
                    break;
                case DBType.DT:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("DTClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("DTSystemNo");
                    CJia.DefaultOleDb.DefaultAdapter = new DataAdapter(DbConfigName.OleDb.ToString());
                    break;
                case DBType.JJFBDB:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("JJFB_Host");//双创佳server
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("JJFBClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("JJFBSystemNo");
                    CJia.DefaultOleDb.DefaultAdapter = new DataAdapter(DbConfigName.OleDb.ToString());
                    break;
                case DBType.HQMSDB:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("HQMSClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("HQMSSystemNo");
                    CJia.DefaultOleDb.DefaultAdapter = new DataAdapter(DbConfigName.OleDb.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
