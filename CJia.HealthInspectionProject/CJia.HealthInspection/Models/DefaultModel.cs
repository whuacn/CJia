using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class DefaultModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询登录用户不存在的功能
        /// </summary>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public DataTable QueryLoginUserOwnFunction(string loginUserId)
        {
            object[] sqlParams = new object[] { loginUserId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryLoginUserOwnFunction,sqlParams);
        }
    }
}
