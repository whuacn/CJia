using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    /// <summary>
    /// 根据关键字查询医生信息
    /// </summary>
    public class UserManageModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 初始化绑定部门
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDeptWithUser);
        }

        /// <summary>
        ///  查询医生职称
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDoctorDescript()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDocDes);
        }

        /// <summary>
        /// 查询是否有相同用户号
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public string QueryIsExistSameUserNo(string userNo)
        {
            List<object> sqlParams = new List<object>() { userNo };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryIsExistSameUserNo, sqlParams);
        }

        /// <summary>
        /// 查询科室信息绑到下拉框
        /// </summary>
        /// <param name="KeyWod"></param>
        /// <returns></returns>
        public DataTable QueryDeptBySearch(string KeyWord)
        {
            object[] ob = new object[] { "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDept, ob);
        }

        /// <summary>
        /// 查找用户表数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserByAll()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserByAll);
        }

        /// <summary>
        /// 查询User表下一个Sequence
        /// </summary>
        /// <returns></returns>
        public long QueryNextSequenceFromUser()
        {
            return long.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryNextUserSequence));
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userId">流水号</param>
        /// <param name="userNo">用户编号</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="deptId">部门名称</param>
        /// <param name="doctorDescript">医生职称</param>
        /// <returns></returns>
        public bool AddUser(long userId, string userNo, string userName, string deptId, string doctorDescript)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(userId);
            sqlParams.Add(userNo);
            sqlParams.Add(userName);
            sqlParams.Add(deptId);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(doctorDescript);
            object[] ob = { userId, long.Parse(User.UserData.Rows[0]["user_id"].ToString()) };
            CJia.DefaultOleDb.Execute(SqlTools.SqlInsertFavorites, ob);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertUser, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 添加用户角色表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户名称</param>
        /// <param name="listRoleId">List角色Id</param>
        /// <param name="listRoleName">List角色名称</param>
        /// <returns></returns>
        public bool AddUserRole(long userId, string userName, List<object> listRoleId, List<object> listRoleName)
        {
            bool isSuccess = false;
            List<object> sqlParams = new List<object>();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < listRoleId.Count; i++)
                {
                    sqlParams.Add(userId);
                    sqlParams.Add(userName);
                    sqlParams.Add(listRoleId[i]);
                    sqlParams.Add(listRoleName[i]);
                    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                    isSuccess = CJia.DefaultOleDb.Execute(trans.ID, SqlTools.SqlInsertRoleUser, sqlParams) > 0 ? true : false;
                    sqlParams.Clear();
                }
                trans.Complete();
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除用户角色表
        /// </summary>
        /// <param name="userId">所选用户ID</param>
        /// <returns></returns>
        public bool DeleteUserRole(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteRoleUserByUserId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改用户表
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="deptId">部门名称</param>
        /// <param name="userId">用户表流水号</param>
        /// <param name="doctorDescript">医生职称</param>
        /// <returns></returns>
        public bool UpdateUser(string userNo, string userName, string deptId, long userId, string doctorDescript)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(userNo);
            sqlParams.Add(userName);
            sqlParams.Add(deptId);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(doctorDescript);
            sqlParams.Add(userId);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateUserById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteUserById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询角色类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserRole()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRoleFunction);
        }

        /// <summary>
        /// 根据用户ID查询用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable QueryUserRoleByUserId(long userId)
        {
            object[] sqlParams = new object[] { userId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserRoleFunctionByUserId, sqlParams);
        }

        /// <summary>
        /// 根据用户输入信息搜索Grid
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBySearchGrid(string keyWord)
        {
            keyWord = "%" + keyWord + "%";
            List<object> sqlParams = new List<object>();
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            sqlParams.Add(keyWord);
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUserGridBySearch, sqlParams);
        }
    }
}
