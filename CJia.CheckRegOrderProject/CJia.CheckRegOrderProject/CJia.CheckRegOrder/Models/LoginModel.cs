using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CJia.CheckRegOrder.Models
{
    public class LoginModel
    {
        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemDateTime()
        {
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectSystemDateTime);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据工号与密码登陆
        /// </summary>
        /// <param name="userNO">工号</param>
        /// <param name="password">密码</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserByNOAndPassword(string userNO, string password)
        {
            object[] sqlParams = new object[] { userNO, password };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectByUserNOAndPassword, sqlParams);
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
