using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class EditUserModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 查询科室
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDept = ad.Query(SqlToos.SqlQueryAllDept, null);
                return dtDept;
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool ResetPwd(string UserId,string Pwd, string UpdateBy)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { Pwd, UpdateBy, UserId };
                bool isReset = ad.Execute(SqlToos.SqlResetPwd, ob) > 0 ? true : false;
                return isReset;
            }
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="DeptId"></param>
        /// <param name="UpdateBy"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool EditUser(string UserName, string DeptId, string UpdateBy, string UserID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserName, DeptId, UpdateBy, UserID };
                bool isEdit = ad.Execute(SqlToos.SqlEditUser, ob) > 0 ? true : false;
                return isEdit;
            }
        }

        
    }
}
