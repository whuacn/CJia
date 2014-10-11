using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditRoleModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询某个角色ID所拥有权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable QueryRoleFunctionByRoleId(string roleId)
        {
            object[] sqlParams = new object[] { roleId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleFunctionByRoleId, sqlParams);
        }

        /// <summary>
        /// 根据角色ID查找角色名称
        /// </summary>
        /// <param name="roleId">所要查询ID</param>
        /// <returns></returns>
        public string QueryRoleNameById(string roleId)
        {
            object[] sqlParams = new object[] { roleId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryRoleNameById,sqlParams);
        }

        ///// <summary>
        ///// 查询所有功能
        ///// </summary>
        ///// <returns></returns>
        //public DataTable QueryAllFunction()
        //{
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllFunction);
        //}

        /// <summary>
        /// 查询某个用户所拥有的功能
        /// </summary>
        /// <param name="userId">所要查询的用户</param>
        /// <returns></returns>
        public DataTable QueryUserIdOwnFunction(string userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserIdOwnFunction, sqlParams);
        }

        /// <summary>
        /// 修改角色名称时查询是否存在相同角色名
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <param name="organId">该角色所属组织</param>
        /// <returns></returns>
        public bool QueryExistSameRoleNameWhenUpdate(string roleId, string roleName,string organId)
        {
            object[] sqlParams = new object[]{ roleId,roleName,organId };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameRoleNameWhenUpdate, sqlParams);
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
        /// 修改角色表信息
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleName">修改后的权限名称</param>
        /// <param name="updateBy">修改人</param>
        /// <param name="roleId">所要修改的权限ID</param>
        /// <returns></returns>
        public bool UpdateRole(string transId, string roleName, string updateBy, string roleId)
        {
            object[] sqlParams = new object[] { roleName,updateBy,roleId };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlUpdateRoleById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据角色ID删除此角色权限关联表数据
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">所要删除角色ID</param>
        /// <param name="updateBy">修改人</param>
        /// <returns></returns>
        public bool DeleteRoleFunctionByRoleId(string transId, string roleId, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, roleId };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlDeleteRoleFunctionByRoleId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 插入角色功能表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="functionId">功能ID</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertRoleFunction(string transId,string roleId, List<string> functionId, string createBy)
        {
            bool isSuccess = false;
            object[] sqlParams;
            for (int i = 0; i < functionId.Count; i++)
            {
                sqlParams = new object[] { roleId, functionId[i], createBy };
                isSuccess = CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInsertRoleFunction, sqlParams) > 0 ? true : false;
            }
            return isSuccess;
        }
    }
}
