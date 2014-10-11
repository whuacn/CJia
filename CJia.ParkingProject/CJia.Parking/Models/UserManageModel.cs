using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class UserManageModel : CJia.Parking.Tools.Model
    {
        #region 【角色】
        /// <summary>
        /// 查询角色信息表有效数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRole()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectRole);
        }

        /// <summary>
        /// 查询是否存在相同角色名
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public DataTable QueryIsExistSameRoleName(string roleName)
        {
            object[] sqlParams = new object[] { roleName };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameRoleName,sqlParams);
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="createBy">创建者</param>
        /// <returns></returns>
        public bool InsertRole(string roleName, long createBy)
        {
            object[] sqlParams = new object[] { roleName, createBy };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertRole,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改角色表
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="createBy">创建者</param>
        /// <returns></returns>
        public bool UpdateRole(string roleName, long createBy , long roleId)
        {
            object[] sqlParams = new object[] { roleName, createBy, roleId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateRole, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除时角色时查询用户角色关联表中是否有存在正在使用的角色流水号
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable QueryIsExistUsingRoleIdWhenDelete(long roleId)
        {
            object[] sqlParams = new object[] { roleId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistUsingRoleIdWhenDelete,sqlParams);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="updateBy">修改人</param>
        /// <param name="roleId">所要修改角色流水号</param>
        /// <returns></returns>
        public bool DeleteRole(long updateBy, long roleId)
        {
            object[] sqlParams = new object[] { updateBy, roleId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteRole, sqlParams) > 0 ? true : false;
        }
        #endregion

        #region【用户】
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUser()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectUser);
        }

        /// <summary>
        /// 查询是否存在相同用户工号
        /// </summary>
        /// <param name="userNo">用户工号</param>
        /// <returns></returns>
        public DataTable QueryIsExistSameUserNo(string userNo)
        {
            object[] sqlParams = new object[] { userNo };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameUserNo,sqlParams);
        }

        /// <summary>
        /// 查询user表下一个Sequence
        /// </summary>
        /// <returns></returns>
        public long QueryUserSeq()
        {
            return Convert.ToInt64(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectUserSeq));
        }

        /// <summary>
        /// 插入用户表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="userNo">用户工号</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertUser(long userId,string userName,string userNo,long createBy)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(userId);
            sqlParams.Add(userName);
            sqlParams.Add(userNo);
            sqlParams.Add(createBy);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertUser,sqlParams) > 0  ? true : false;
        }

        /// <summary>
        /// 插入用户角色关联表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertUserRole(long userId,long roleId,long createBy)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(userId);
            sqlParams.Add(roleId);
            sqlParams.Add(createBy);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertUserRole,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除用户角色表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUserRole(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteUserRole,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改用户表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="userNo">用户工号</param>
        /// <param name="userPwd">用户登录密码</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool UpdateUser(string userName, string userNo, string userPwd, long createBy,long userId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(userName);
            sqlParams.Add(userNo);
            sqlParams.Add(userPwd);
            sqlParams.Add(createBy);
            sqlParams.Add(userId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateUser, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteUser,sqlParams) > 0  ? true : false;
        }

        /// <summary>
        /// 根据用户ID查询此用户的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable QueryUserRoleByUserId(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectUserRoleByUserId,sqlParams);
        }
        #endregion
    }
}
