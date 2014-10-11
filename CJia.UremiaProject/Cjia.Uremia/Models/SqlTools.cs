using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Uremia.Models
{
    /// <summary>
    /// Sql语句定义
    /// </summary>
    public class SqlTools
    {
        #region【登录用户】
        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        public static string SqlQueryLoginUser
        {
            get
            {
                return @"select * from gm_user gu 
                         where gu.user_no=? and gu.user_pwd=? and status='1'";
            }
        }
        #endregion
    }
}
