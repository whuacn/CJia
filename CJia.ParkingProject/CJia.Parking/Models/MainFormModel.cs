using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class MainFormModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 查询登录用户所拥有权限
        /// </summary>
        /// <param name="userId">登录用户ID</param>
        /// <returns></returns>
        public DataTable QueryLogionUserRoles(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlQueryLoginUserRoles,sqlParams);
        }
    }
}
