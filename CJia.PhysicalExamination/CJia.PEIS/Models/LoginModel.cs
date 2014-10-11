using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Models
{
    public class LoginModel : CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 查询当前登录用户的信息
        /// </summary>
        /// <param name="userNo">用户工号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public DataTable GetUserByNOAndPwd(string userNo, string password)
        {
            object[] sqlParams = new object[] { userNo, password };
            DataTable dtResult = CJia.DefaultPostgre.Query(CJia.PEIS.Models.SqlTools.SqlQueryUser, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
    }
}
