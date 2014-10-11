using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;

namespace CJia.Uremia.Web
{
    public partial class Default :CJia.Uremia.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    tbt_Clock.Text = DateTime.Now.ToString();
                    tbt_Info.Text = "【用户：" + (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString() + "】";
                    btn_ChangePassword.OnClientClick = this.win_ChangePassword.GetShowReference();
                    btn_EndLogin.Click+=btn_EndLogin_Click;
                }
            }
        }

        protected override object CreatePresenter()
        {
            return null;
        }
        
        #region Events事件

        protected void btn_EndLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginView.aspx");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Ok", "top.location='LoginView.aspx';", true);
            //Response.Write("  <script type='text/javascript'>alert('123')</script>");
        }
        protected void btn_ReloadMenu_Click(object sender, EventArgs e)
        {
           
        }
        protected void btn_Reload_Click(object sender, EventArgs e)
        {
            
        }
        protected void tir_Main_Tick(object sender, EventArgs e)
        {
            
        }
     
        #endregion

        #region【自定义方法】

        #endregion

        #region【接口事件】

        #endregion

    }
}