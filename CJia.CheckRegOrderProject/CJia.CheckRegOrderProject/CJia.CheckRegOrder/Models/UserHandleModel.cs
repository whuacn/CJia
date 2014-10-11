using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class UserHandleModel
    {
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userNO">用户编号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="userType">用户类型 是否管理员</param>
        /// <param name="updateBy">修改人id</param>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public bool ModifyUserByID(string userNO,string userName,bool userType,int updateBy,int userID)
        {
            List<object> sqlParam = new List<object>();
            sqlParam.Add(userNO);
            sqlParam.Add(userName);
            sqlParam.Add(updateBy);
            if (userType == true)
            {
                sqlParam.Add("1");
            }
            else
            {
                sqlParam.Add("0");
            }
            sqlParam.Add(userID);
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateUserByID,sqlParam) > 0 ? true : false;
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="userNO">用户工号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="userType">是否管理员</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool AddUser(string userNO, string userName, bool userType, int createBy)
        {
            List<object> sqlParam = new List<object>();
            sqlParam.Add(userNO);
            sqlParam.Add(userName);
            if (userType == true)
            {
                sqlParam.Add("1");
            }
            else
            {
                sqlParam.Add("0");
            }
            sqlParam.Add(createBy);
            return CJia.DefaultSQL.Execute(SqlTools.sqlInsertUser, sqlParam) > 0 ? true : false;
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
    }
}
