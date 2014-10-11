using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ExtAspNet;
using System.Text;

namespace CJia.HealthInspection.Web.UI.Low
{
    public partial class UpLoadLowFile : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IUpLoadLowFile
    {
        string htmlPath;
        string wordPath;
        string wordFileName;
        string htmlFileName;
        string htmlFilePath;
        CJia.HealthInspection.Views.UpLoadLowFileArgs uploadLowFileArgs = new Views.UpLoadLowFileArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnInit != null)
                {
                    OnInit(null, null);
                }
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.UpLoadLowFilePresenter(this);
        }

        protected void ddl_Big_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //上传  
                //uploadWord(File1);  
                //转换  
                //File1.PostedFile = LowFile.PostedFile.FileName;
                string str = wordToHtml(LowFile.PostedFile);
                if (str == "1")
                {
                    Alert.ShowInTop("请上传word文档");
                    return;
                }
                if (str == "0")
                {
                    Alert.ShowInTop("上传失败");
                    return;
                }
                //string str = WriteFile(htmlPath);
                uploadLowFileArgs.LowName = txt_LowName.Text;
                uploadLowFileArgs.LowTypeId = Convert.ToInt32(ddl_Low.SelectedValue);
                //uploadLowFileArgs.LowContent = WriteFile(htmlPath);
                uploadLowFileArgs.WordFilepath = wordPath;
                uploadLowFileArgs.WordFileName = wordFileName;
                uploadLowFileArgs.HtmlFileName = htmlFileName;
                uploadLowFileArgs.HtmlFilepath = htmlFilePath;
                OnInsertLowFile(null, uploadLowFileArgs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Alert.Show("恭喜，转换成功！");
            } 
        }

        #region【内部方法】
        //上传文件并转换为html wordToHtml(wordFilePath)  
        ///<summary>  
        ///上传文件并转存为html  
        ///</summary>  
        ///<param name="wordFilePath">word文档在客户机的位置</param>  
        ///<returns>上传的html文件的地址</returns>  
        public string wordToHtml(HttpPostedFile wordFilePath)
        {
            //Alert.Show("hello");
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

            //string filename = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() +
            //System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();

            byte[] buffer = Guid.NewGuid().ToByteArray();
            int extendNameIndex = wordFilePath.FileName.LastIndexOf(".");
            string filename = wordFilePath.FileName.Substring(0,extendNameIndex) + BitConverter.ToInt64(buffer, 0).ToString().PadLeft(19,'0');

            // 判断指定目录下是否存在文件夹，如果不存在，则创建  
            string abc = Server.MapPath("~\\html");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert(" + abc + ")", true);
            if (!Directory.Exists(Server.MapPath("~\\html")))
            {
                // 创建up文件夹  
                Directory.CreateDirectory(Server.MapPath("~\\html"));
            }

            //被转换的html文档保存的位置  
            string ConfigPath = abc + "\\"+filename + ".html";
            object saveFileName = ConfigPath;
            htmlFileName = filename + ".html";
            htmlPath = ConfigPath;
            htmlFilePath = "html/" + filename + ".html"; 
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


        public string uploadWord(HttpPostedFile uploadFiles)
        {
            string FilePath;
            string newName = "";
            if (uploadFiles != null)
            {
                string fileName = uploadFiles.FileName;
                int extendNameIndex = fileName.LastIndexOf(".");
                string extendName = fileName.Substring(extendNameIndex);
                try
                {
                    //验证是否为word格式  
                    if (extendName == ".doc" || extendName == ".docx")
                    {
                        byte[] buffer = Guid.NewGuid().ToByteArray();
                        long ruant = BitConverter.ToInt64(buffer, 0);
                        newName = fileName.Substring(0, extendNameIndex) + ruant.ToString().PadLeft(19, '0');
                        // 判断指定目录下是否存在文件夹，如果不存在，则创建 
                        FilePath=Server.MapPath("~\\wordTmp");
                        if (!Directory.Exists(FilePath))
                        {
                            // 创建up文件夹  
                            Directory.CreateDirectory(Server.MapPath("~\\wordTmp"));
                        }
                        //上传路径 指当前上传页面的同一级的目录下面的wordTmp路径  
                        //string str = Server.MapPath("wordTmp/" + newName + extendName);
                        //Alert.Show("word路径"+str);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert(" + str + ")", true);
                        //wordPath = FilePath + "\\" + newName + extendName;
                        wordFileName = newName + extendName;
                        wordPath = "wordTmp/" + newName + extendName; 
                        uploadFiles.SaveAs(FilePath + "\\" + newName + extendName);
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
                //"http://" + HttpContext.Current.Request.Url.Authority +
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
            Encoding code = Encoding.GetEncoding("gb2312");
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
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                //HttpContext.Current.Response.End();
                sr.Close();
            }
            finally
            {
                sr.Close();
            }
            return str;
        }
        #endregion

        #region【实现接口】
        public new event EventHandler<Views.UpLoadLowFileArgs> OnInit;

        public event EventHandler<Views.UpLoadLowFileArgs> OnLowTempChange;

        public event EventHandler<Views.UpLoadLowFileArgs> OnInsertLowFile;

        public void ExeShowLowIsInsert(bool Isinsert)
        {
            if (Isinsert)
            {
                Alert.Show("文件添加成功");
            }
            else
            {
                Alert.Show("文件添加失败，请重新添加");
            }
        }

        public void ExeBindLowTemp(DataTable data)
        {
            ddl_Low.DataSource = data;
            ddl_Low.DataTextField = "LOW_TYPE_NAME";
            ddl_Low.DataValueField = "LOW_TYPE_ID";
            ddl_Low.DataBind();
        }
        #endregion




        
    }
}