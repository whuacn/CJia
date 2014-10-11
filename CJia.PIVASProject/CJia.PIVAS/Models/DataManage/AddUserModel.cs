using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 添加用户的M层
    /// </summary>
    public class AddUserModel : CJia.PIVAS.Tools.Model
    {
        ///// <summary>
        ///// 判断His中是否有当前所填工号  有返回true
        ///// </summary>
        ///// <param name="userNo"></param>
        ///// <returns></returns>
        //public bool IsUserExit(string userNo)
        //{
        //    object[] obUser = new object[] { userNo };
        //    DataTable dtUser = CJia.DefaultOleDb.Query(SqlTools.SqlIsUserExit, obUser);
        //    if (dtUser != null && dtUser.Rows != null && dtUser.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 判断当前工号在用户表中是否有重复  true为有重复  false为无重复
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public bool IsUserRepeat(string userNo)
        {
            object[] obUserNo = new object[] { userNo };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsUserRepeat, obUserNo) == "0" ? false : true;
        }


        /// <summary>
        /// 插入新用户
        /// </summary>
        /// <param name="userNo">用户工号</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pwd">用户密码</param>
        /// <param name="deptId"></param>
        /// <param name="deptName"></param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertUser(string userNo,string userName,string pwd,string deptId,string deptName, long createBy)
        {
            object[] obInsert = new object[] { userNo, userName, pwd,deptId,deptName, createBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertUser, obInsert) > 0 ? true : false;
        }
    }
}