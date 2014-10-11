using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class ChangePwdModel :CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="password">新密码</param>
        /// <param name="updateBy">修改人</param>
        /// <param name="userId">所要修改用户ID</param>
        /// <returns></returns>
        public bool UpdateUserPwd(string password, long updateBy, long userId)
        {
            object[] sqlParams = new object[] { password,updateBy,userId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateUserPassword,sqlParams) > 0 ? true : false;
        }
    }
}
