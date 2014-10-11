using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class TextEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CJia.Evaluation.Models.Backstage.DataInput a = new Models.Backstage.DataInput();
            a.QueryUser();
            int b = 1;
            //HtmlEditor1.Text = "<h1>1234</h1>";
            //message.InnerHtml = "<h1>1234</h1>";
            pre.InnerHtml = "<p><img alt='' src='/ckfinder/userfiles/images/318.jpg' style='height:316px; width:550px' /></p>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strHtml = HttpUtility.UrlDecode(CKEditorControl1.Text);
            string strReplaceFile = strHtml.Replace(">/ckfinder/userfiles/files/", ">");
            Alert.ShowInTop(HttpUtility.UrlDecode(CKEditorControl1.Text));
        }
    }
}