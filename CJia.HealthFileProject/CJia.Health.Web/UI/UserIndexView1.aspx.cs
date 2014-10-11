using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.SuperAdmin
{
    public partial class SuperAdminindex : CJia.Health.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    DataTable userData = Session["User"] as DataTable;
                    Label1.Text = userData.Rows[0]["USER_NAME"].ToString();
                    Label2.Text = Sysdate.ToString();
                }
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }
        
    }
}