using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class UserSelectModel
    {
        /// <summary>
        /// 查询出所有用户
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUser()
        {
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectAllUser);
            if (data != null && data.Rows.Count > 0)
            {
                return ChangeData(data);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户id查询用户
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public DataTable GetUserByID(int userID)
        {
            object[] sqlParam = new object[] { userID };
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectUserByID, sqlParam);
            if (data != null && data.Rows.Count > 0)
            {
                return ChangeData1(data);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户编号查询用户
        /// </summary>
        /// <param name="userNO">用户编号</param>
        /// <returns></returns>
        public DataTable GetUserByNO(string userNO)
        {
            object[] sqlParam = new object[] { userNO };
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectUserByNO, sqlParam);
            if (data != null && data.Rows.Count > 0)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户姓名查询用户
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>
        public DataTable GetUserByName(string userName)
        {
            object[] sqlParam = new object[] { userName };
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectUserByName, sqlParam);
            if (data != null && data.Rows.Count > 0)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="updateBy">修改人</param>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public bool ResetPswdByID(int updateBy, int userID)
        {
            object[] sqlParams = new object[] { updateBy, userID };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateUserPswdByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="updateBy">修改人</param>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public bool DeleteUserByID(int updateBy, int userID)
        {
            object[] sqlParams = new object[] { updateBy, userID };
            return CJia.DefaultSQL.Execute(SqlTools.sqlDeleteUserByID, sqlParams) > 0 ? true : false;
        }


        #region 内部调用方法
        /// <summary>
        /// 字段值转换
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ChangeData(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["user_type"].ToString() == "1")
                {
                    dr["user_type"] = "管理员";
                }
                else
                {
                    dr["user_type"] = "普通用户";
                }
            }
            return data;
        }
        public DataTable ChangeData1(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["user_type"].ToString() == "1")
                {
                    dr["user_type"] = true;
                }
                else
                {
                    dr["user_type"] = false;
                }
            }
            return data;
        }
        #endregion
    }
}
