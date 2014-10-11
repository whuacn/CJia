using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AddSuperviseModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 是否存在相同用户编号
        /// </summary>
        /// <param name="userNo">所要插入用户编号</param>
        /// <returns>true：存在相同编号；false：不存在相同编号</returns>
        public bool QueryIsExistSameUserNo(string userNo)
        {
            object[] sqlParams = new object[] { userNo };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameUserNoWhenAdd, sqlParams);
            if (dt == null || dt.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查询用户表Sequence
        /// </summary>
        /// <returns></returns>
        public string QueryUserSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryUserSeq);
        }

        /// <summary>
        /// 插入用户表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="sqlParams">插入参数</param>
        /// <returns></returns>
        public bool InsertUser(string transId,List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlInsertUser,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 是否存在超级管理员角色
        /// </summary>
        /// <returns>true：存在；false：不存在</returns>
        public bool QueryExistSuperRole()
        {
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSuperRole);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 插入用户角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertUserRole(string transId,string userId,string roleId,string createBy)
        {
            object[] sqlParams = new object[] { userId,roleId,createBy };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlInsertUserRole,sqlParams) > 0 ? true : false;
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
        /// 查询角色表Sequence
        /// </summary>
        /// <returns></returns>
        public string QueryRoleSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryRoleSeq);
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="roleId">角色流水号</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="createBy">创建人</param>
        /// <param name="organId">角色所属组织</param>
        /// <returns></returns>
        public bool InsertRole(string transId, string roleId, string roleName, string createBy,string organId,string roleType)
        {
            object[] sqlParams = new object[] { roleId, roleName, createBy,organId,roleType };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInsertRole, sqlParams) > 0 ? true : false;
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
