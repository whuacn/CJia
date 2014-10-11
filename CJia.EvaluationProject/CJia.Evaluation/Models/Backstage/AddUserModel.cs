using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class AddUserModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <param name="DeptId"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool InsertUser(string UserCode, string UserName, string UserPwd, string DeptId, string UserID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserName, UserPwd, DeptId, UserID, UserCode };
                bool isInsert = ad.Execute(SqlToos.SqlInsertUser, ob) > 0 ? true : false;
                return isInsert;
            }
        }

        /// <summary>
        /// 判断当前用户代码是否存在
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public bool IsHaveUserCode(string UserCode)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserCode };
                DataTable dt = ad.Query(SqlToos.SqlIsHaveUserCode, ob);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
