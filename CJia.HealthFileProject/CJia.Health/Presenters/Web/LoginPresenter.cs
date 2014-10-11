using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class LoginPresenter : CJia.Health.Tools.PresenterPage<Models.Web.LoginModel, Views.Web.ILoginView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public LoginPresenter(Views.Web.ILoginView view)
            : base(view)
        {
            this.View.OnLogin += View_OnLogin;
        }

        void View_OnLogin(object sender, Views.Web.LoginEventArgs e)
        {
            DataTable data= this.Model.GetUserByNOAndPwd( e.UserAccount,e.UserPassword);
            if (data == null)
            {
                View.ShowMessage("用户名或密码错误");
            }
            else
            {
                //User.LoginTime = View.Sysdate;
                //User.UserData = data;
                //View.GoToPage("~/UI/UserIndexView.aspx");
                View.ExeBindUserSession(data);
            }
        }
    }
}
