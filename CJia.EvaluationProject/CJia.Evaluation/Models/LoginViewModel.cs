using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models
{
    public class LoginViewModel : CJia.Evaluation.Tools.Model
    {
        public DataTable GetUser(string userName,string pwd)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { userName, pwd };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryUserByNOAndPwd, sqlparams);
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
}
