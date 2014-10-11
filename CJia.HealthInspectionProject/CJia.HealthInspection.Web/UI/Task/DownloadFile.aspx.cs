using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Task
{
    public partial class DownloadFile : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IDownloadFile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                downArgs.TaskId = Request.QueryString["TaskId"];
                OnQueryTaskByTaskId(null,downArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DownloadFilePresenter(this);
        }

        Views.DownloadFileArgs downArgs = new Views.DownloadFileArgs();

        #region【虚方法实现】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridFiles;
            return true;
        }
        #endregion

        #region【界面事件】
        // 下载选择文件
        protected void gridFiles_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gridFiles.DataKeys[e.RowIndex];
            string filePath = "http://" + HttpContext.Current.Request.Url.Authority + "/" + keys[1].ToString();
            switch (e.CommandName)
            {
                case "Download":
                    PageContext.RegisterStartupScript("downloadFile('" + filePath + "')");
                    break;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定Grid文件
        /// </summary>
        /// <param name="dtFiles"></param>
        public void ExeGridFile(DataTable dtFiles)
        {
            InitGrid(dtFiles);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 根据任务ID查询所属文件
        /// </summary>
        public event EventHandler<Views.DownloadFileArgs> OnQueryTaskByTaskId;
        #endregion
    }
}