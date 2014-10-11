using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking
{
    /// <summary>
    /// 用户登录操作信息
    /// </summary>
    public static class User
    {
        private static string userId;
        private static DataTable userData;
        private static DateTime loginTime;
        private static bool isLoginSuccess = false;

        /// <summary>
        /// 用户信息
        /// </summary>
        public static DataTable UserData
        {
            get { return userData; }
            set { userData = value; }
        }
        /// <summary>
        /// 用的登录时间
        /// </summary>
        public static DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }
        /// <summary>
        /// 是否成功登录
        /// </summary>
        public static bool IsLoginSuccess
        {
            get { return isLoginSuccess; }
            set { isLoginSuccess = value; }
        }
        /// <summary>
        /// 保存图片数据源
        /// </summary>
        public static DataTable PictureData
        {
            get;
            set;
        }
    }
}
