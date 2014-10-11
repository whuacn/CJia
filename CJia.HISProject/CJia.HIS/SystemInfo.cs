using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HIS
{
    public class SystemInfo
    {

        private static bool isLoginSucceed = false;
        /// <summary>
        /// 表示系统是否登录成功
        /// </summary>
        public static bool IsLoginSucceed
        {
            set
            {
                if(IsLoginSucceed != value)
                {
                    isLoginSucceed = value;
                    if(ChangeLoginStateEven != null)
                    {
                        ChangeLoginStateEven(null, null);
                    }
                }
            }
            get
            {
                return isLoginSucceed;
            }
        }
        /// <summary>
        /// 登陆信息发生更改
        /// </summary>
        public static event EventHandler ChangeLoginStateEven;



        private static DataRow user = null;
        /// <summary>
        /// 存储当前登录用户信息
        /// </summary>
        public static DataRow User
        {
            set
            {
                string oldUserId = user == null ? "" : user["USER_ID"].ToString();
                string newUserId = value == null ? "" : value["USER_ID"].ToString();
                if( oldUserId != newUserId)
                {
                    if(newUserId != "")
                    {
                        user = value;
                        if(ChangeUserEven != null)
                        {
                            ChangeUserEven(null, null);
                        }
                    }
                    else
                    {
                        IsLoginSucceed = false;
                    }
                }
            }
            get
            {
                return user;
            }
        }
        /// <summary>
        /// user改变事件
        /// </summary>
        public static event EventHandler ChangeUserEven;


        /// <summary>
        /// 存储当前登录系统信息
        /// </summary>
        public static DataRow loginSystem = null;


        /// <summary>
        /// 系统模块对应菜单快捷栏信息
        /// </summary>
        public static DataTable SysModMenuTool = null;

    }
}
