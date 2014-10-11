using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IChangePwdView : CJia.Health.Tools.IView
    {
        event EventHandler<ChangePwdArgs> OnCheckOldPwd;

        event EventHandler<ChangePwdArgs> OnUpdatePwd;

        void ExeCheckOldPwd(bool bo);
    }

    public class ChangePwdArgs : EventArgs
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId = User.UserData.Rows[0]["USER_ID"].ToString();

        /// <summary>
        /// 原始密码
        /// </summary>
        public string OldPwd;

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPwd;
    }
}
