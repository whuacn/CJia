using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryUserModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据所输内容查询某组织下所有用户（不包括同级管理员）
        /// </summary>
        /// <param name="keyWord">搜索内容</param>
        /// <param name="organId">用户所属组织</param>
        /// <returns></returns>
        public DataTable QueryNormalUserBySearch(string keyWord, string organId)
        {
            object[] sqlParams = new object[] { organId };
            string sql = "";
            if (keyWord != "")
            {
                sql = SqlTools.SqlQueryNormalUserByOrganId + " and (gu.user_no like '%" + keyWord + "%' or gu.user_name like '%" + keyWord + "%' or gd.dept_no like '%" + keyWord + "%' or gd.dept_name like '%" + keyWord + "%')";
            }
            else
            {
                sql = SqlTools.SqlQueryNormalUserByOrganId;
            }
            return CJia.DefaultOleDb.Query(sql, sqlParams);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="updateBy"></param>
        /// <param name="deletedUserId">所要删除用户ID</param>
        /// <returns></returns>
        public bool DeleteUserById(string transId,string updateBy, string deletedUserId)
        {
            object[] sqlParams = new object[] { updateBy, deletedUserId };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlDeleteUserById,sqlParams) > 0 ? true : false;
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
