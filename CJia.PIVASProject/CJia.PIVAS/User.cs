using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS
{
    /// <summary>
    /// 当前登录用户类
    /// </summary>
    public static class User
    {
        public static bool isLoginSuccess;
        private static long userId;
        private static string userNo;
        private static string userName;
        private static string deptId;
        private static string deptName;
        private static string pwd;
        private static DateTime logTime;

        /// <summary>
        /// 是否登录成功
        /// </summary>
        public static bool IsLoginSuccess  
        {
            set
            {
                isLoginSuccess=value;
            }
            get
            {
                return isLoginSuccess;
            }
        }

        /// <summary>
        /// 用户ID 配置中心ID
        /// </summary>
        public static long UserId
        {
            set
            {
                userId=value;
            }
            get
            {
                return userId;
            }
        }

        /// <summary>
        /// 用户工号
        /// </summary>
        public static string UserNo 
        {
            set
            {
                userNo=value;
            }
            get
            {
                return userNo;
            }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public static string UserName
        {
            set
            {
                userName=value;
            }
            get
            {
                return userName;
            }
        }

        /// <summary>
        /// 部门Id
        /// </summary>
        public static string DeptId
        {
            set
            {
                deptId=value;
            }
            get
            {
                return deptId;
            }
        }   

        /// <summary>
        /// 部门名称
        /// </summary>
        public static string DeptName
        {
            set
            {
                deptName=value;
            }
            get
            {
                return deptName;
            }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public static string Pwd
        {
            set
            {
                pwd = value;
            }
            get
            {
                return pwd;
            }
        }

        /// <summary>
        /// 当前用户登录时间
        /// </summary>
        public static DateTime LogTime
        {
            set
            {
                logTime = value;
            }
            get
            {
                return logTime;
            }
        }
        
        /// <summary>
        /// 把登录用户信息存起来
        /// </summary>
        /// <param name="isLoginSuccess">是否登录成功</param>
        /// <param name="usreId">用户ID</param>
        /// <param name="userNo">用户工号</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="deptNo">部门编号</param>
        /// <param name="deptName">部门名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="logTime">登录时间</param>
        public static void SetUser(bool isLoginSuccess, long usreId,string userNo, string userName,string deptNo,string deptName,string pwd,string logTime)
        {
            IsLoginSuccess = isLoginSuccess;
            UserId = usreId;
            UserNo = userNo;
            UserName = userName;
            DeptId = deptNo;
            DeptName = deptName;
            Pwd = pwd;
            LogTime = DateTime.Parse(logTime);
        }
    }
}
