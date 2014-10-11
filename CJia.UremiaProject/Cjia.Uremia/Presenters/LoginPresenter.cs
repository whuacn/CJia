using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Uremia.Presenters
{
    public class LoginPresenter : CJia.Uremia.Tools.PresenterPage<Models.LoginModel, Views.ILoginView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            this.View.OnLogin += View_OnLogin;
        }

        void View_OnLogin(object sender, Views.LoginEventArgs e)
        {
            DataTable data= this.Model.GetUserByNOAndPwd( e.UserAccount,e.UserPassword);
            if (data == null)
            {
                View.ShowMessage("用户名或密码错误");
            }
            else
            {
                View.ExeBindUserSession(data);
            }
        }
    }
}
