using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface ILoginView : CJia.Editors.IView
    {
        /// <summary>
        /// 登录事件
        /// </summary>
        event EventHandler<LoginArgs> OnLogin;
        /// <summary>
        /// 登录
        /// </summary>
        void ExeLogin(DataTable Userdata, DataTable LoginTime);
        /// <summary>
        /// 工号输入框获得焦点
        /// </summary>
        void TxtUserNOFocus();
    }
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginArgs : EventArgs
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string UserNO = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password = "";
    }

}
