using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    /// <summary>
    /// 角色维护数据层
    /// </summary>
    public class RoleManageModel:CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询角色表数据绑定Grid
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRoleBindGrid()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleUnionFunction);
        }

        /// <summary>
        /// 查询角色并关联用户名称
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRoleFuncUserType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleFuncUnionRole);
        }

        /// <summary>
        /// 所要添加的角色名称是否存在相同的功能角色
        /// </summary>
        /// <param name="roleName">所要添加的名称</param>
        /// <returns></returns>
        public DataTable IsExistSameRole(string roleName)
        {
            object[] sqlParams = new object[] { roleName };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsExistSameRole, sqlParams);
        }

        /// <summary>
        /// 查询tm_role下一个Squence
        /// </summary>
        /// <returns></returns>
        public long QueryNextRoleSeq()
        {
            return long.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryNextRoleSeq));
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        /// <param name="roleId">所查询下一个Squence</param>
        /// <param name="roleName">界面所填名称</param>
        /// <returns></returns>
        public bool InsertRole(long roleId,string roleName)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(roleId);
            sqlParams.Add(roleName);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertRole,sqlParams) > 0 ? true : false;
        }

        ///// <summary>
        ///// 插入角色功能表
        ///// </summary>
        ///// <param name="roleName">角色名称</param>
        ///// <param name="listFunctionId">功能角色ID</param>
        ///// <returns></returns>
        //public bool InsertRoleFunction(string roleFunctionName,List<long> listFunctionId)
        //{
        //    bool isSuccess = false;
        //    List<object> sqlParams = new List<object>();
        //    using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
        //    {
        //        for (int i = 0; i < listFunctionId.Count; i++)
        //        {
        //            sqlParams.Add(roleFunctionName);
        //            sqlParams.Add(listFunctionId[i]);
        //            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
        //            isSuccess = CJia.DefaultOleDb.Execute(trans.ID, SqlTools.SqlInsertRoleFunction, sqlParams) > 0 ? true : false;
        //            sqlParams.Clear();
        //        }
        //        trans.Complete();
        //    }
        //    return isSuccess;
        //}

        /// <summary>
        /// 插入角色功能表
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="listFunctionId">功能角色ID</param>
        /// <returns></returns>
        public bool InsertRoleFunction(long roleId,string roleName,List<long> listFunctionId)
        {
            bool isSuccess = false;
            List<object> sqlParams = new List<object>();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < listFunctionId.Count; i++)
                {
                    sqlParams.Add(roleId);
                    sqlParams.Add(roleName);
                    sqlParams.Add(listFunctionId[i]);
                    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                    isSuccess = CJia.DefaultOleDb.Execute(trans.ID, SqlTools.SqlInsertRoleFunction, sqlParams) > 0 ? true : false;
                    sqlParams.Clear();
                }
                trans.Complete();
            }
            return isSuccess;
        }

        /// <summary>
        /// 修改角色表查询所要修改的名字在库中是否存在
        /// </summary>
        /// <param name="roleId">所要修改的ID</param>
        /// <param name="roleName">所要修改的名称</param>
        /// <returns></returns>
        public DataTable QueryIsExistSameRoleNameWhenUpdateRole(long roleId, string roleName)
        {
            object[] sqlParams = new object[] { roleName,roleId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsExistSameRoleNameWhenUpdateRole,sqlParams);
        }

        /// <summary>
        /// 修改角色表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="roleName">用户类型</param>
        /// <returns></returns>
        public bool UpdateRoleByRoleId(long roleId, string roleName)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(roleName);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(roleId);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateRoleByRoleId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据角色Id删除所选中用户所有功能角色表数据（删除多条）
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public bool DeleteRoleFunctionByRoleId(long roleId)
        {
            object[] sqlParams = new object[] { roleId};
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteRoleFounctionByRoleId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除时查询该角色数据
        /// </summary>
        /// <param name="roleId">所选角色</param>
        /// <returns></returns>
        public DataTable QueryRoleFunction(long roleId)
        {
            object[] sqlParams = new object[] { roleId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleFunctionByRoleId,sqlParams);
        }

        /// <summary>
        /// 根据功能角色Id删除选中行（单条）
        /// </summary>
        /// <returns></returns>
        public bool DeleteRoleFunctionByRoleFunctionId(long roleFunctionId)
        {
            object[] sqlParams = new object[] { roleFunctionId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteRoleFunctionByRoleFunctionId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 当该选中角色在功能角色表还剩一条数据时删除tm_role中role_id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteRoleByRoleId(long roleId)
        {
            object[] sqlParams = new object[] { roleId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteRoleByRoleId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询界面Grid所点击角色所拥有功能角色,绑定到编辑选择框
        /// </summary>
        /// <param name="roleId">所选中角色</param>
        /// <returns></returns>
        public DataTable QueryRoleExistFunctionId(string roleName)
        {
            object[] sqlParams = new object[] { roleName };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleFunctionByFunctionId,sqlParams);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataTable QuerySearchRoleByKeyWord(string keyWord)
        {
            keyWord = "%" + keyWord + "%";
            List<object> sqlParams = new List<object>();
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            return CJia.DefaultOleDb.Query(SqlTools.SqlQuerySearchRoleByKeyWord,sqlParams);
        }
    }
}
