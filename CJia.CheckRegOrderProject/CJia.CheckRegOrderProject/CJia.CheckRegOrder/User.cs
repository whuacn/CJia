using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.CheckRegOrder
{
    public static class User
    {
        /// <summary>
        /// 登录用户id
        /// </summary>
        public static int UserID;
        /// <summary>
        /// 登录时间
        /// </summary>
        public static string LoginDateTime;
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName;

        /// <summary>
        /// 阴道镜数据库操作
        /// </summary>
        public static CJia.DataAdapter ada = new CJia.DataAdapter(DbConfigName.SqlGoldWayDB.ToString());
    }
}
