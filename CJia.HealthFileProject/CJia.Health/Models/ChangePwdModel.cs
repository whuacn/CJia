using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class ChangePwdModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 验证旧密码是否正确
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OldPwd"></param>
        /// <returns></returns>
        public bool CheckOldPwd(string UserID, string OldPwd)
        {
            object[] ob = new object[] { User.UserData.Rows[0]["USER_ID"].ToString(), OldPwd };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckOldPwd, ob).ToString()) == 1 ? true : false;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="NewPwd"></param>
        /// <param name="UserId"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool UpdatePwd(string NewPwd,string UserId)
        {
            object[] ob=new object[]{NewPwd,UserId,UserId};
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdatePwd, ob) > 0 ? true : false;
        }
    }
}
