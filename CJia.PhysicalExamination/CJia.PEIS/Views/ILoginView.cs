using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Views
{
    /// <summary>
    /// 登录View层
    /// </summary>
    public interface ILoginView:CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 登录事件
        /// </summary>
        event EventHandler<LoginEventArgs> OnLogin;
        /// <summary>
        /// 工号输入框获得焦点
        /// </summary>
        void TxtUserNOFocus();
    }
    /// <summary>
    /// 登录页面参数类
    /// </summary>
    public class LoginEventArgs : EventArgs
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        public string UserNo;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password;
    }
}
