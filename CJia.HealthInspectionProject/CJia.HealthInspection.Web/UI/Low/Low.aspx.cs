using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Low
{
    public partial class Low : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.ILow
    {
        //public string WordFilePath;
        CJia.HealthInspection.Views.LowArgs lowArgs = new Views.LowArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WordFilepaht"] = null;
                if (OnInitTree != null)
                {
                    OnInitTree(null, null);
                }
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.LowPresenter(this);
        }

        protected void tree_Low_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            //ExtAspNet.Alert.Show("1");
            RefreshLow();


        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_FileDown_Click(object sender, EventArgs e)
        {
            if (Session["WordFilepaht"] != null)
            {
                ExtAspNet.PageContext.RegisterStartupScript("downloadFile('" + Session["WordFilepaht"].ToString() + "')");
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("请选择文件");
            }
        }

        #region【内部方法】
        /// <summary>
        /// 初始化TreeList
        /// </summary>
        public void InitTree(DataTable data)
        {
            this.tree_Low.Nodes.Clear();
            //ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            //node.NodeID = "1";
            //node.Text = "全部";
            //node.IconUrl = "~/Icons/package.png";
            //node.EnablePostBack = true;
            //node.Expanded = true;
            //this.tree_Main.Nodes.Add(node);
            if (data != null && data.Rows.Count != 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["PARENTID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                        node.NodeID = dr["ID"].ToString();
                        node.Text = dr["NAME"].ToString();
                        //node.IconUrl =
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        CreateTree(dr["ID"].ToString(), node, data);
                        this.tree_Low.Nodes.Add(node);
                    }
                }
            }
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="featList">数据</param>
        public void CreateTree(string parent, ExtAspNet.TreeNode pnode, DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENTID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["ID"].ToString();
                    //node.IconUrl = 
                    node.Text = dr["NAME"].ToString();
                    node.EnablePostBack = true;
                    CreateTree(dr["ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 查询法律法规文档
        /// </summary>
        public void RefreshLow()
        {
            if (Convert.ToInt64(tree_Low.SelectedNodeID) >= 2000000000)
            {
                if (OnTreeClick != null)
                {
                    lowArgs.LowFileId = Convert.ToInt64(tree_Low.SelectedNodeID);
                    OnTreeClick(null, lowArgs);
                }
            }
        }
        #endregion

        #region【接口实现】
        public event EventHandler<Views.LowArgs> OnInitTree;

        public event EventHandler<Views.LowArgs> OnTreeClick;

        public void ExeShowLowPage(DataTable dt)
        {
            string HtmlFilePath = "http://" + HttpContext.Current.Request.Url.Authority + "/" + dt.Rows[0]["HTML_FILE_PATH"].ToString();
            Session["WordFilepaht"] = "http://" + HttpContext.Current.Request.Url.Authority + "/" + dt.Rows[0]["LOW_FILE_PATH"].ToString();
            LowFile.IFrameUrl = HtmlFilePath;
            LowFile.Title = dt.Rows[0]["LOW_NAME"].ToString();
        }

        public void ExeBindTree(DataTable data)
        {
            InitTree(data);
        }
        #endregion

        #region【下载文件方法】

        //private void FileDownLoad(string filename)
        //{
        //    string a = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath("wordTmp")))) + "\\wordTmp\\310797696.doc";
        //    string destFileName;    // = filename;
        //    destFileName = a;   //Server.MapPath("./") + destFileName;
        //    destFileName = Server.UrlDecode(destFileName);

        //    if (File.Exists(destFileName))
        //    {
        //        FileInfo fi = new FileInfo(filename);
        //        Response.Clear();
        //        Response.ClearHeaders();
        //        Response.Buffer = true;
        //        Response.Charset = "GB2312";

        //        //添加头信息，为 "文件下载/另存为 "对话框指定默认文件名  
        //        Response.AppendHeader("Content-Disposition", "attachment;filename="
        //        + HttpUtility.UrlEncode(Path.GetFileName(destFileName),
        //        System.Text.Encoding.UTF8));
        //        //Response.AppendHeader("Content-Length", fi.Length.ToString());
        //        Response.ContentType = "text/plain";
        //        Response.Filter.Close();
        //        Response.WriteFile(destFileName);
        //        Response.Flush();
        //        HttpContext.Current.ApplicationInstance.CompleteRequest();
        //        //Response.End();
        //    }
        //    else
        //    {
        //        Response.Write("<script language = javascript>alert('下载出错')</script>");
        //    }
        //}

        ///// <summary>
        ///// 下载文件
        ///// </summary>
        ///// <param name="path"></param>
        //public void ResponseFile(string path)
        //{
        //    string fileName = HttpContext.Current.Server.UrlEncode(path.Substring(path.LastIndexOf("/") + 1));
        //    try
        //    {
        //        FileInfo info = new FileInfo(HttpContext.Current.Server.MapPath(path));
        //        long fileSize = info.Length;
        //        Response.Clear();
        //        Response.ContentType = "application/x-zip-compressed";
        //        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        //        //不指明Content-Length用Flush的话不会显示下载进度 
        //        Response.AddHeader("Content-Length", fileSize.ToString());
        //        Response.TransmitFile(path, 0, fileSize);
        //        Response.Flush();
        //        Response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("无法下载文件：" + fileName + ",由于：" + ex.Message + "");
        //    }
        //}

        public void FileDOwn(string fileName,string filePath)
        {
            //fileName = "CodeShark.zip";//客户端保存的文件名
            //filePath = Server.MapPath("DownLoad/CodeShark.zip");//路径
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
            if (fileInfo.Exists == true)
            {
                const long ChunkSize = 102400;//100K 每次读取文件，只读取100Ｋ，这样可以缓解服务器的压力
                byte[] buffer = new byte[ChunkSize];
                Response.Clear();
                System.IO.FileStream iStream = System.IO.File.OpenRead(filePath);
                long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                while (dataLengthToRead > 0 && Response.IsClientConnected)
                {
                    int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                    Response.OutputStream.Write(buffer, 0, lengthRead);
                    Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                Response.Close();
            }
        }

        #endregion

        



    }
}