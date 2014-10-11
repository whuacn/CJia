using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AddUserModel : CJia.HealthInspection.Tools.Model
    {
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

        ///// <summary>
        ///// 查询角色表Sequence
        ///// </summary>
        ///// <returns></returns>
        //public string QueryRoleSeq()
        //{
        //    return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryRoleSeq);
        //}

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
