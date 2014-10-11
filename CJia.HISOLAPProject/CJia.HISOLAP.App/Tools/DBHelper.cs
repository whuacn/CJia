using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.Tools
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
        /// PIVAS数据源
        /// </summary>
        PIVAS
    }

    public static class DBHelper
    {

        /// <summary>
        /// 数据源切换  根据DBType数据源  种类 进行数据源的切换 
        /// </summary>
        /// <param name="dbType"></param>
        public static void DBSwitchover(DBType dbType)
        {
            switch (dbType)
            {
                case DBType.BI:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("BIClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("BISystemNo");
                    break;
                case DBType.DT:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("DTClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("DTSystemNo");
                    break;
                case DBType.PIVAS:
                    CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("JJFB_Host");
                    CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                    CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("PIVASClientNo");
                    CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("PIVASSystemNo");
                    break;
                default:
                    break;
            }
        }
    }


}
