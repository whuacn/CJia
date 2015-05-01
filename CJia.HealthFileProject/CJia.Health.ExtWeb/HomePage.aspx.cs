using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb
{
    public partial class HomePage : CJia.Health.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    DataTable useData = Session["User"] as DataTable;
                    tbt_Clock.Text = DateTime.Now.ToString();
                    tbt_Info.Text = "欢迎【" + useData.Rows[0]["USER_NAME"].ToString() + "】";
                }
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }
    }
}