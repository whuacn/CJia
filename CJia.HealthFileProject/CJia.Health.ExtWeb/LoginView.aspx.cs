using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb
{
    public partial class LoginView : CJia.Health.Tools.OnPreLoadPage, CJia.Health.Views.Web.ILoginView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                SystemInitConfig();//连接数据库
            }
        }
        public static bool SystemInitConfig()
        {
            try
            {
                CJia.ClientConfig.ServerIP = CJia.Health.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("SystemNo");
                if (CJia.DefaultOleDb.QueryScalar("select 1 from dual") == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.LoginPresenter(this);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (OnLogin != null)
            {
                if (!isRightUser()) return;
                CJia.Health.Views.Web.LoginEventArgs loginEventArgs = new Views.Web.LoginEventArgs();
                loginEventArgs.UserAccount = this.signup_name.Value;
                loginEventArgs.UserPassword = this.signup_password.Value;
                this.OnLogin(null, loginEventArgs);
            }
        }

        #region ILoginView 成员

        public event EventHandler<Views.Web.LoginEventArgs> OnLogin;
        public void ExeBindUserSession(DataTable data)
        {
            Session["User"] = new DataTable();
            Session["User"] = data;
            Session.Timeout = int.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("SessionTimeOut"));
            Response.Redirect("~/HomePage.aspx");
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
            if (signup_password.Value.Length == 0)
            {
                signup_password.Focus();
                return false;
            }
            return true;
        }
        #endregion
    }
}