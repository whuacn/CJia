using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Uremia.Web
{
    public partial class LoginView : CJia.Uremia.Tools.OnPreLoadPage, CJia.Uremia.Views.ILoginView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                CJia.Uremia.Tools.Help.SystemInitConfig();//连接数据库
                if (Request.Cookies["UserInfo"] != null)
                {
                    if (Request.Cookies["UserInfo"]["UserName"] != null && Request.Cookies["UserInfo"]["PassWord"] != null)
                    {
                        this.signup_name.Value = Server.HtmlEncode(Request.Cookies["UserInfo"]["UserName"]);
                        string pwd = CJia.Uremia.Tools.Utils.AESDecrypt(Server.HtmlEncode(Request.Cookies["UserInfo"]["PassWord"]));
                        this.signup_password.Attributes.Add("value", pwd);
                        rembMe.Style["background-position"] = "0 0";
                        this.yijizhu.Value = "HaveRemberMe";
                    }
                }
                //Label1.Text = "网站访问总人数：" + Application["total"].ToString() + "  当前在线人数：" + Application["online"].ToString();
            }
           
        }
        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            if (OnLogin != null)
            {
                if (!isRightUser()) return;
                //if (Session["ValidateCode"] != null)
                //{
                    //if (signup_code.Value.ToLower() == Session["ValidateCode"].ToString().ToLower())
                    //{
                        string text = this.yijizhu.Value;
                        if (text == "HaveRemberMe")//记住我
                        {
                            HttpCookie cooks = new HttpCookie("UserInfo");
                            cooks.Values["UserName"] = this.signup_name.Value;
                            cooks.Values["PassWord"] = CJia.Uremia.Tools.Utils.AESEncrypt(this.signup_password.Text);
                            cooks.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(cooks);
                        }
                        else
                        {
                            if (Response.Cookies["UserInfo"] != null)
                                Response.Cookies["UserInfo"].Expires = DateTime.Now;
                        }
                        CJia.Uremia.Views.LoginEventArgs loginEventArgs = new Views.LoginEventArgs();
                        loginEventArgs.UserAccount = this.signup_name.Value;
                        loginEventArgs.UserPassword = this.signup_password.Text;
                        this.OnLogin(null, loginEventArgs);
                        return;
                    //}
                //}
                //esg.Style["display"] = "block";
                Session["IsCode"] = "false";
            }
        }
        #region ILoginView 成员

        public event EventHandler<Views.LoginEventArgs> OnLogin;
        public void ExeBindUserSession(DataTable data)
        {
            Session["User"] = new DataTable();
            Session["User"] = data;
            Session.Timeout = int.Parse(CJia.Uremia.Tools.ConfigHelper.GetAppStrings("SessionTimeOut"));
            Response.Redirect("~/Default.aspx");
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 判断输入用户名和密码
        /// </summary>
        /// <returns></returns>
        public bool isRightUser()
        {
            if (signup_name.Value.Length == 0)
            {
                signup_name.Focus();
                return false;
            }
            if (signup_password.Text.Length == 0)
            {
                signup_password.Focus();
                return false;
            }
            Session["Old_UserName"] = signup_name.Value;
            Session["Old_Pwd"] = signup_password.Text;
            return true;
        }
        public void BindUserInput()
        {
            if (Session["Old_UserName"] != null && Session["Old_Pwd"] != null && Session["IsCode"] != null)
            {
                signup_name.Value = Session["Old_UserName"].ToString();
                signup_password.Text = Session["Old_Pwd"].ToString();
                //esg.Focus();
            }
        }
        #endregion

    }
}