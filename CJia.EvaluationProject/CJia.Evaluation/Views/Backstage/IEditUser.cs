using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IEditUser : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<EditUserArgs> OnInitDept;
        event EventHandler<EditUserArgs> OnResetPwd;
        event EventHandler<EditUserArgs> OnEditUser;
        void ExeBindDept(DataTable dtDept);
        void ExeResturnResetMsg(bool bl);
        void ExeResturnEditMsg(bool bl);
    }

    public class EditUserArgs : EventArgs
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName;
        /// <summary>
        /// 科室iD
        /// </summary>
        public string DeptId;
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd;

        /// <summary>
        /// 修改ID
        /// </summary>
        public string userId;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserId;
    }
}
