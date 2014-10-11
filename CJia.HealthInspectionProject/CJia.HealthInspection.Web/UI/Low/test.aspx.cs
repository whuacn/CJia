using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.Low
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = wordToHtml(File1);
        }

        //上传文件并转换为html wordToHtml(wordFilePath)  
        ///<summary>  
        ///上传文件并转存为html  
        ///</summary>  
        ///<param name="wordFilePath">word文档在客户机的位置</param>  
        ///<returns>上传的html文件的地址</returns>  
        public string wordToHtml(System.Web.UI.HtmlControls.HtmlInputFile wordFilePath)
        {
            Alert.Show("hello");
            //txt_TitleName.Text = "12";
            Microsoft.Office.Interop.Word.ApplicationClass word = new Microsoft.Office.Interop.Word.ApplicationClass();
            Type wordType = word.GetType();
            Microsoft.Office.Interop.Word.Documents docs = word.Documents;
            // 打开文件  
            Type docsType = docs.GetType();
            //应当先把文件上传至服务器然后再解析文件为html  
            string filePath = uploadWord(wordFilePath);
            //判断是否上传文件成功  
            if (filePath == "0")
                return "0";
            //判断是否为word文件  
            if (filePath == "1")
                return "1";
            object fileName = filePath;
            Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)docsType.InvokeMember("Open",
            System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { fileName, true, true });
            // 转换格式，另存为html  
            Type docType = doc.GetType();

            string filename = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() +
            System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();

            // 判断指定目录下是否存在文件夹，如果不存在，则创建  
            string abc = Server.MapPath("~\\html");
            Alert.Show("html文件路径" + abc);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert(" + abc + ")", true);
            if (!Directory.Exists(Server.MapPath("~\\html")))
            {
                // 创建up文件夹  
                Directory.CreateDirectory(Server.MapPath("~\\html"));
            }

            //被转换的html文档保存的位置  
            string ConfigPath = abc + "\\" + filename + ".html";
            object saveFileName = ConfigPath;

            /*下面是Microsoft Word 9 Object Library的写法，如果是10，可能写成： 
         * docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, 
         * null, doc, new object[]{saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML}); 
         * 其它格式： 
         * wdFormatHTML 
         * wdFormatDocument 
         * wdFormatDOSText 
         * wdFormatDOSTextLineBreaks 
         * wdFormatEncodedText 
         * wdFormatRTF 
         * wdFormatTemplate 
         * wdFormatText 
         * wdFormatTextLineBreaks 
         * wdFormatUnicodeText 
         */
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
            null, doc, new object[] { saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML });
            //关闭文档  
            docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod,
            null, doc, new object[] { null, null, null });
            // 退出 Word  
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);
            //转到新生成的页面  
            return ("/" + filename + ".html");
        }

        /// <summary>
        /// 上传word文件到服务器
        /// </summary>
        /// <param name="uploadFiles"></param>
        /// <returns></returns>
        public string uploadWord(System.Web.UI.HtmlControls.HtmlInputFile uploadFiles)
        {
            string FilePath;
            string newName = "";
            if (uploadFiles.PostedFile != null)
            {
                string fileName = uploadFiles.PostedFile.FileName;
                int extendNameIndex = fileName.LastIndexOf(".");
                string extendName = fileName.Substring(extendNameIndex);
                try
                {
                    //验证是否为word格式  
                    if (extendName == ".doc" || extendName == ".docx")
                    {

                        DateTime now = DateTime.Now;
                        newName = now.DayOfYear.ToString() + uploadFiles.PostedFile.ContentLength.ToString();
                        // 判断指定目录下是否存在文件夹，如果不存在，则创建 
                        FilePath = Server.MapPath("~\\wordTmp");
                        if (!Directory.Exists(FilePath))
                        {
                            // 创建up文件夹  
                            Directory.CreateDirectory(Server.MapPath("~\\wordTmp"));
                        }
                        //上传路径 指当前上传页面的同一级的目录下面的wordTmp路径  
                        string str = Server.MapPath("wordTmp/" + newName + extendName);
                        Alert.Show("word路径" + str);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert(" + str + ")", true);
                        uploadFiles.PostedFile.SaveAs(FilePath + "\\" + newName + extendName);
                    }
                    else
                    {
                        return "1";
                    }
                }
                catch
                {
                    return "0";
                }
                //www.2cto.com
                //return "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + "/wordTmp/" + newName + extendName;  
                return FilePath + "\\" + newName + extendName;
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 把word文件转成Html内容
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static string WriteFile(string FilePath)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
            // 读取模板文件   
            //string temp = HttpContext.Current.Server.MapPath(FilePath);
            string str = "";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(FilePath, code);
                str = sr.ReadToEnd(); // 读取文件  
            }
            catch (Exception exp)
            {
                HttpContext.Current.Response.Write(exp.Message);
                HttpContext.Current.Response.End();
                sr.Close();
            }
            finally
            {
                sr.Close();
            }
            return str;
        }
    }
}