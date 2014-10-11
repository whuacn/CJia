using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Views
{
    public interface ILoginView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 登录事件
        /// </summary>
        event EventHandler<Views.LoginArgs> OnLogin;

        /// <summary>
        /// 用户名获得焦点
        /// </summary>
        void TxtUserNOFocus();
    }

    public class LoginArgs : EventArgs
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassword;
    }
}
 
