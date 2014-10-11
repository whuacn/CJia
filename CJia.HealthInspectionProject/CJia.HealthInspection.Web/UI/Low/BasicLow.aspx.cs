using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Low
{
    public partial class BasicLow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_DownLoad_Click(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>downloadFile('http://localhost:9216/wordTmp/310797696.doc');</script>", false);
            
            //try
            //{
            //    string fileName = "310454412.doc";//客户端保存的文件名
            //    string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath("wordTmp")))) + "\\wordTmp\\" + fileName;// Server.MapPath("./") + fileName;//路径

            //    FileInfo fileInfo = new FileInfo(filePath);
            //    Response.Clear();
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            //    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            //    Response.AddHeader("Content-Transfer-Encoding", "binary");
            //    Response.ContentType = "application/octet-stream";
            //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            //    Response.WriteFile(fileInfo.FullName);
            //    Response.Flush();
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();

            //    //Response.End();
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script language = javascript>alert(" + ex.Message + ")</script>");
            //}
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string fileName = "310454412.doc";//客户端保存的文件名
        //        string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath("wordTmp")))) + "\\wordTmp\\" + fileName;// Server.MapPath("./") + fileName;//路径

        //        FileInfo fileInfo = new FileInfo(filePath);
        //        Response.Clear();
        //        Response.ClearContent();
        //        Response.ClearHeaders();
        //        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        //        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        //        Response.AddHeader("Content-Transfer-Encoding", "binary");
        //        Response.ContentType = "application/octet-stream";
        //        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        //        Response.WriteFile(fileInfo.FullName);
        //        Response.Flush();
        //        HttpContext.Current.ApplicationInstance.CompleteRequest();

        //        //Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script language = javascript>alert(" + ex.Message + ")</script>");
        //    }
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string fileName = "310454412.doc";//客户端保存的文件名
        //        string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath("wordTmp")))) + "\\wordTmp\\" + fileName;// Server.MapPath("./") + fileName;//路径

        //        FileInfo fileInfo = new FileInfo(filePath);
        //        Response.Clear();
        //        Response.ClearContent();
        //        Response.ClearHeaders();
        //        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        //        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        //        Response.AddHeader("Content-Transfer-Encoding", "binary");
        //        Response.ContentType = "application/octet-stream";
        //        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        //        Response.WriteFile(fileInfo.FullName);
        //        Response.Flush();
        //        HttpContext.Current.ApplicationInstance.CompleteRequest();

        //        //Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script language = javascript>alert(" + ex.Message + ")</script>");
        //    }
        //}
    }
}