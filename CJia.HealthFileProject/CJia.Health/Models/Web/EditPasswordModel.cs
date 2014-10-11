using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class EditPasswordModel : CJia.Health.Tools.Model
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
