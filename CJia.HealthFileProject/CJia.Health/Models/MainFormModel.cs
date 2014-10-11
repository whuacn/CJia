using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class MainFormModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询该登录用户没有的权限功能
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable QueryNoFunction(string UserID)
        { 
            object[] ob=new object[]{UserID};
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryNoFunction, ob);
        }
    }
}
