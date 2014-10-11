using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.FrontStage
{
    public partial class DownLoad : CJia.Evaluation.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["title"] == null) return;
                if (Request.QueryString["txt"] == null) return;
                if (Request.QueryString["name"] == null) return;
                title.InnerHtml = CJia.Evaluation.Tools.Utils.AESDecrypt(Request.QueryString["title"].Replace(' ', '+'));
                txt.InnerHtml = CJia.Evaluation.Tools.Utils.AESDecrypt(Request.QueryString["txt"].Replace(' ', '+'));
                name.InnerHtml = CJia.Evaluation.Tools.Utils.AESDecrypt(Request.QueryString["name"].Replace(' ', '+'));
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }
    }
}