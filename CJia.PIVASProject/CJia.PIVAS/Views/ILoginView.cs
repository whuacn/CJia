using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 登录界面接口层
    /// </summary>
    public interface ILoginView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// 登录
        /// </summary>
        event EventHandler<LoginEventArgs> OnLogin;

        /// <summary>
        /// 登录失败
        /// </summary>
        void ExeLoginFail();

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
