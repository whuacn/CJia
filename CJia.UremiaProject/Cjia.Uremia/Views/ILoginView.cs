using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Uremia.Views
{
    public interface ILoginView : CJia.Uremia.Tools.IPage
    {
       event EventHandler<LoginEventArgs> OnLogin;
       void ExeBindUserSession(DataTable data);
    }
    public  class LoginEventArgs:EventArgs
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserAccount;

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassword;

    }
}
