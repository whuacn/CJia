using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.HIS.App.Models
{
    public class LoginModel : CJia.HIS.Model
    {
        public DataTable Login(string userNo,string userPwd)
        {
            object[] parameters = new object[]{ userNo,userPwd};
            DataTable result = CJia.DefaultData.Query(SqlModel.loginSqlText, parameters);
            return result;
        }

    }
}

