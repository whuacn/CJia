using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CJia.Health.Tools
{
    public class Page : System.Web.UI.Page
    {
        private object _presenter;

        /// <summary>
        /// 用户控件UI层父类构造函数
        /// </summary>
        public Page()
        {
            _presenter = this.CreatePresenter();
        }

        /// <summary>
        /// 常见Presenter虚方法
        /// </summary>
        /// <returns></returns>
        protected virtual object CreatePresenter()
        {
            if(LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} 必须重载 CreatePresenter 方法.", this.GetType().FullName));
            }
        }
        /// <summary>
        /// 显示弹框信息
        /// </summary>
        /// <param name="message">要显示的内容</param>
        public void ShowMessage(string message)
        {
            //Response.Write("  <script type='text/javascript'>alert('" + message + "'); </script>");
            //ClientScript.RegisterClientScriptBlock(typeof(Page), new Guid().ToString(), "alert('" + message + "');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Ok", "alert('" + message + "');", true);
        }

        /// <summary>
        /// 跳转到某一页
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(string page)
        {
            Response.Redirect(page);
        }
        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        public DateTime Sysdate
        {
            get
            {
                return DateTime.Parse(CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            if (Session["User"] == null)
            {
                //Response.Redirect("~/LoginView.aspx");
                Response.Write("  <script type='text/javascript'>top.location='../LoginView.aspx'</script>");
            }
        }
    }
}
