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
            string[] ips = Tools.Help.GetAddressIP();
            if (ips.Length > 0)
            {
                foreach (string ip in ips)
                {
                    DataTable ipData = Model.GetIP(ip);
                    if (ipData.Rows.Count > 0)
                    {
                        View.ShowMessage("你的IP地址限制登陆病案借阅系统，请与管理员联系！");
                        return;
                    }
                }
            }
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
