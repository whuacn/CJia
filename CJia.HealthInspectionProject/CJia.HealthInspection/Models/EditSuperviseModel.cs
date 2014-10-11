using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditSuperviseModel : CJia.HealthInspection.Tools.Model
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
        /// 查询所有功能
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllFunctionExceptSup()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllFunctionExceptSup);
        }

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
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool UpdateUser(string transId,List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlUpdateUserByOrganAndUserId, sqlParams) > 0 ? true : false;
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
