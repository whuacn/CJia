using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class LoginModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询当前登录用户的信息
        /// </summary>
        /// <param name="userNo">用户工号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public DataTable SelectUser( string userNo, string password )
        {
            object[] ob = new object[] { userNo, password };
            return CJia.DefaultOleDb.Query(CJia.PIVAS.Models.DataManage.SqlTools.SqlQueryUser, ob);
        }
    }
}

