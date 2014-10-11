using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class ChangePasswordModel:CJia.HealthInspection.Tools.Model
    {

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ModifyPassword(string userID, string password)
        {
            object[] sqlParams = new object[] { password, userID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdatePassword, sqlParams) > 0 ? true : false;
        }
    }
}
