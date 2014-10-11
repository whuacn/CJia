using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class LoginModel : CJia.Parking.Tools.Model
    {
       /// <summary>
       /// 查询用户信息
       /// </summary>
       /// <param name="userNo"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        public DataTable QueryUser(string userNo, string password)
        {
            object[] sqlParams = new object[] { userNo,password };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectLoginUser, sqlParams);
        }

    }
}
