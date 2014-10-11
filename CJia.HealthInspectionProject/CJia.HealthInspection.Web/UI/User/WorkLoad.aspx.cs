using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.User
{
    public partial class WorkLoad :CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IWorkLoad
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override object CreatePresenter()
        {
            return new Presenters.WorkLoadPresenter(this);
        }

        protected void dropBig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropMiddle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}