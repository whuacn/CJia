using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditUserModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据Id查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable QueryUserById(string userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserById,sqlParams);
        }

        /// <summary>
        /// 根据所输内容查询某组织所拥有角色
        /// </summary>
        /// <param name="organId">登录用户所属组织</param>
        /// <returns></returns>
        public DataTable QueryRoleByOrganId(string organId)
        {
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleByOrganId, sqlParams);
        }

        /// <summary>
        /// 查询某个普通用户所拥有的角色
        /// </summary>
        /// <param name="userId">所要查询用户</param>
        /// <returns></returns>
        public DataTable QueryUserOwnRoleByUserId(string userId)
        {
            object[] sqlParams = new object[] { userId };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserOwnRoleByUserId, sqlParams); ;
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserOwnRoleByUserId, sqlParams);
        }
        
        /// <summary>
        /// 是否存在相同用户编号
        /// </summary>
        /// <param name="userId">需要修改的用户流水号</param>
        /// <param name="userNo">用户编号</param>
        /// <returns>true：存在相同编号；false：不存在相同编号</returns>
        public bool QueryIsExistSameUserNoUpdate(string userId,string userNo)
        {
            object[] sqlParams = new object[] { userId,userNo };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsExistSameUserNoUpdate, sqlParams);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="sqlParams">修改参数</param>
        /// <returns></returns>
        public bool UpdateUser(string transId, List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlUpdateUserByUserId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户ID删除用户角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="updateBy">修改人</param>
        /// <param name="deletedUserId">所要删除用户ID</param>
        /// <returns></returns>
        public bool DeleteUserRoleByUserId(string transId, string updateBy, string deletedUserId)
        {
            object[] sqlParams = new object[] { updateBy, deletedUserId };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlDeleteUserRoleByUserId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 插入用户角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertUserRole(string transId, string userId, string roleId, string createBy)
        {
            object[] sqlParams = new object[] { userId, roleId, createBy };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInsertUserRole, sqlParams) > 0 ? true : false;
        }
    }
}
