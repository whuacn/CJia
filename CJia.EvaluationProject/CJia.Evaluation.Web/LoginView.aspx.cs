using CJia.Evaluation.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web
{
    public partial class LoginView : CJia.Evaluation.Tools.OnPreLoadPage, CJia.Evaluation.Views.ILoginView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                username.Text = "008";
                password.Attributes.Add("value", "8888");
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.LoginViewPresenter(this);
        }
        public event EventHandler<LoginViewArgs> OnLogin;
        public void ExeBindUserData(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                Session["User"] = new DataTable();
                Session["User"] = data;
                Session.Timeout = int.Parse(ConfigHelper.GetAppStrings("SessionTimeOut"));
                if (userType.SelectedValue == "0")
                {
                    Response.Redirect("~/FrontStage/HomePage.aspx");
                }
                else
                {
                    Response.Redirect("~/BackHomePage.aspx");
                }
            }
            else
            {
                signin_error.Text = "用户名或密码错误！";
            }
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            if (OnLogin != null)
            {
                if (!isRightUser()) return;
                if (Session["ValidateCode"] != null)
                {
                    //if (CheckCode.Text.ToLower() == Session["ValidateCode"].ToString().ToLower())
                    //{
                    LoginViewArgs loginEventArgs = new Views.LoginViewArgs();
                    loginEventArgs.UserNO = this.username.Text;
                    loginEventArgs.Password = Help.PwdHelp.EncryptString(this.password.Text);
                    this.OnLogin(null, loginEventArgs);
                    return;
                    //}
                }
                signin_error.Text = "验证码错误！";
            }
        }
        public bool isRightUser()
        {
            if (username.Text.Length == 0)
            {
                username.Focus();
                return false;
            }
            if (password.Text.Length == 0)
            {
                password.Focus();
                return false;
            }
            Session["Old_UserName"] = username.Text;
            Session["Old_Pwd"] = password.Text;//修改密码时 用到
            return true;
        }
    }
}