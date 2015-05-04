using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb.UI
{
    public partial class ReceiptFavorite : CJia.Health.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override object CreatePresenter()
        {
            return null;
        }

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("PhotoView.aspx", "图片浏览"));
                    break;

            }
        }

        protected void btnDataBaseDelete_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("PhotoView.aspx", "图片浏览"));
        }
    }
}