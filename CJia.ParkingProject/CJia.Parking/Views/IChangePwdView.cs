using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IChangePwdView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 保存更改密码
        /// </summary>
        event EventHandler<Views.ChangePwdArgs> OnSavePwd;
    }

    public class ChangePwdArgs : EventArgs
    {
        /// <summary>
        /// 用户新密码
        /// </summary>
        public string NewPassword;
    }
}
