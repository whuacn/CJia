using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 修改个人信息M层
    /// </summary>
    public class EditUserModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 修改个人信息  密码
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <param name="pwd">新密码 经过Md5加密过的密码</param>
        /// <param name="userId">当前登陆用户的Id</param>
        /// <returns></returns>
        public bool UpdateUser(string pwd,long userId)
        {
            object[] ob = new object[] { pwd, userId, userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlChangePwd, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 判断修改密码是输入的旧密码是否正确
        /// </summary>
        /// <param name="userId">当前登录的用户Id</param>
        /// <param name="OldPwd">旧密码</param>
        /// <returns></returns>
        public bool CheckOldPwd(string OldPwd,long userId)
        {
            object[] ob = new object[] { OldPwd, userId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckOldPwd, ob) == "1" ? true : false;
        }
    }
}