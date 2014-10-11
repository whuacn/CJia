using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 用户维护的M层
    /// </summary>
    public class UserModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询配置中心所有用户
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllUser()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllUser);
        }

        /// <summary>
        /// 删除用户  把状态改为0
        /// </summary>
        /// <param name="updateBy"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(long updateBy,long userId)
        {
            object[] ob = new object[] { updateBy, userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteUser, ob) > 0 ? true : false;
        }
    }
}