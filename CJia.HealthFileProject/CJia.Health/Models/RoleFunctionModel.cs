using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    /// <summary>
    /// 权限维护数据层
    /// </summary>
    public class RoleFunctionModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询用户类型（Web或者客户端）
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserType);
        }

        /// <summary>
        /// 查询角色功能表并关联用户名称
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRoleFunctionUnionUserType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFunctionUnionUserType);
        }

        /// <summary>
        /// 插入时查询表中已存在功能名称
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public DataTable QueryWhenInsertIsExistSameFunctionName(string functionName)
        {
            object[] sqlParams = new object[] { functionName };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryWhenInsertIsExistSameFunctionName,sqlParams);
        }

        /// <summary>
        /// 插入角色功能表
        /// </summary>
        /// <param name="roleFounctionName">角色名称</param>
        /// <param name="userType">用户类型</param>
        /// <returns></returns>
        public bool InsertRoleFunction(string roleFunctionName, long userType)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(roleFunctionName);
            sqlParams.Add(userType);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertFunction, sqlParams) > 0 ? true : false;
        }

        
        /// <summary>
        /// 修改名称时查询是否存在相同名称
        /// </summary>
        /// <param name="functionId">所要修改ID</param>
        /// <param name="functionName">所要修改新名称</param>
        /// <returns></returns>
        public DataTable QueryExistSameFunctionNameWhenUpdate(long functionId, string functionName, long userType)
        {
            object[] sqlParams = new object[] { functionName,functionId,userType };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameFunctionNameWhenUpdate, sqlParams);
        }

        /// <summary>
        /// 修改角色功能表
        /// </summary>
        /// <param name="roleFounctionId">角色功能表ID</param>
        /// <param name="roleFounctionName">角色功能名称</param>
        /// <param name="userType">用户类型</param>
        /// <returns></returns>
        public bool UpdateRoleFounction(long roleFunctionId, string roleFunctionName, long userType)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(roleFunctionName);
            sqlParams.Add(userType);
            sqlParams.Add(User.UserData.Rows[0]["user_id"].ToString());
            sqlParams.Add(roleFunctionId);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateFunction, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除角色表角色
        /// </summary>
        /// <param name="roleFounctionId">角色功能ID</param>
        /// <returns></returns>
        public bool DeleteRoleFounction(long roleFunctionId)
        {
            object[] sqlParams = new object[] { roleFunctionId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteFunction, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataTable QuerySearchFunctionUnionUserType(string keyWord)
        {
            keyWord = "%" + keyWord + "%";
            List<object> sqlParams = new List<object>();
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            return CJia.DefaultOleDb.Query(SqlTools.SqlSearchFunctionUnionUserType,sqlParams);
        }

        
    }
}
