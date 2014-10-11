using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using CJia.Health.Tools;




namespace Web
{
    public partial class CheckCode : System.Web.UI.Page
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                    string userName = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_userName"));
                    string password = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_password"));
                    string uri = host + "/" + id.Replace('\\', '/');
                    GetImage(uri, userName, password);
                }
            }
        }

        private void GetImage(string url, string userName, string password)
        {
            Bitmap image = (Bitmap)CJia.Health.Tools.Help.GetImageByUri(url, userName, password);
            if (image != null)
            {
                try
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Response.ClearContent();
                    Response.ContentType = "image/JPEG";
                    Response.BinaryWrite(ms.ToArray());
                }
                finally
                {
                    image.Dispose();
                }
            }
        }
    }
}
