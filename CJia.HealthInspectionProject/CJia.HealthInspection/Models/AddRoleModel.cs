using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AddRoleModel : CJia.HealthInspection.Tools.Model
    {
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
        /// 查询角色表Sequence
        /// </summary>
        /// <returns></returns>
        public string QueryRoleSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryRoleSeq);
        }

        /// <summary>
        /// 查询某组织下角色类型为“组织管理员添加”是否存在相同角色名
        /// </summary>
        /// <param name="roleName">新角色名称</param>
        /// <param name="organId">所属组织</param>
        /// <returns>true：存在相同角色名；false：不存在相同角色名</returns>
        public bool QueryExistSameRoleName(string roleName,string organId)
        {
            object[] sqlParams = new object[] { roleName,organId };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameRoleNameByOrganIdAndRoleType, sqlParams);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">角色流水号</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="createBy">创建人</param>
        /// <param name="organId">所属组织</param>
        /// <param name="roleType">0代表超级管理员所拥有角色；1代表超级管理员（为组织管理员）所建角色；2代表组织管理员（为普通用户）所建角色</param>
        /// <returns></returns>
        public bool InsertRole(string transId,string roleId, string roleName, string createBy,string organId,string roleType)
        {
            object[] sqlParams = new object[] { roleId,roleName,createBy,organId,roleType };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlInsertRole, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 插入角色功能表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="functionId">功能ID</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertRoleFunction(string transId, string roleId, List<string> functionId, string createBy)
        {
            bool isSuccess = false;
            object[] sqlParams;
            for (int i = 0; i < functionId.Count; i++ )
            {
                sqlParams = new object[] { roleId,functionId[i],createBy };
                isSuccess = CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInsertRoleFunction, sqlParams) > 0 ? true : false;
            }
            return isSuccess;
        }

    }
}
