using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryRoleModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据所输内容查询某组织所拥有角色
        /// </summary>
        /// <param name="keyWords">所输查询内容</param>
        /// <param name="organId">登录用户所属组织</param>
        /// <returns></returns>
        public DataTable QueryRoleByOrganAndSearch(string keyWords, string organId)
        {
            string sql = "";
            object[] sqlParams = new object[] { organId };
            if (keyWords != "")
            {
                sql = SqlTools.SqlQueryRoleByOrganId + " and role_name like '%" + keyWords + "%'";
            }
            else
            {
                sql = SqlTools.SqlQueryRoleByOrganId;
            }
            return CJia.DefaultOleDb.Query(sql,sqlParams);
        }

        /// <summary>
        /// 根据角色ID删除此角色权限关联表数据
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">所要删除角色ID</param>
        /// <param name="updateBy">修改人</param>
        /// <returns></returns>
        public bool DeleteRoleFunctionByRoleId(string transId, string updateBy, string roleId)
        {
            object[] sqlParams = new object[] { updateBy, roleId };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlDeleteRoleFunctionByRoleId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="updateBy">修改人</param>
        /// <param name="roleId">所要删除ID</param>
        /// <returns></returns>
        public bool DeleteRoleById(string transId, string updateBy, string roleId)
        {
            object[] sqlParams = new object[] { updateBy,roleId };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlDeleteRoleById,sqlParams) > 0 ? true : false;
        }
    }
}
