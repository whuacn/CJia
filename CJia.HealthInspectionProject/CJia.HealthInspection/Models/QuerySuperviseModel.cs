using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QuerySuperviseModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 页面查询用户信息
        /// </summary>
        /// <param name="keyWord">搜索内容</param>
        /// <param name="organId">用户所属组织</param>
        /// <returns></returns>
        public DataTable QueryUserBySearch(string keyWord)
        {
            string sql = "";
            if (keyWord != "")
            {
                sql = SqlTools.SqlQueryAllAdminUser + " and (gu.user_no like '%" + keyWord + "%' or gu.user_name like '%" + keyWord + "%' or gd.dept_no like '%" + keyWord + "%' or gd.dept_name like '%" + keyWord + "%')";
            }
            else
            {
                sql = SqlTools.SqlQueryAllAdminUser;
            }
            return CJia.DefaultOleDb.Query(sql);
        }

        /// <summary>
        /// 根据ID查询用户名
        /// </summary>
        /// <param name="userId">所要查询ID</param>
        /// <returns></returns>
        public string QueryUserNameById(string userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryUserNameById,sqlParams);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="updateBy"></param>
        /// <param name="deletedUserId">所要删除用户ID</param>
        /// <returns></returns>
        public bool DeleteUserById(string trans,string updateBy, string deletedUserId)
        {
            object[] sqlParams = new object[] { updateBy, deletedUserId };
            return CJia.DefaultOleDb.Execute(trans,SqlTools.SqlDeleteUserById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户ID删除用户角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="updateBy"></param>
        /// <param name="deletedUserId">所要删除用户ID</param>
        /// <returns></returns>
        public bool DeleteUserRoleByUserId(string transId, string updateBy, string deletedUserId)
        {
            object[] sqlParams = new object[] { updateBy, deletedUserId };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlDeleteUserRoleByUserId, sqlParams) > 0 ? true : false;
        }
    }
}
