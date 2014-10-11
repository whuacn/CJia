using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Task
{
    public partial class QueryTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IQueryTask
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                queryTaskArgs.User = (DataTable)Session["User"];
                OnInit(null, queryTaskArgs);
            }
            btnSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryTaskPresenter(this);
        }

        Views.QueryTaskArgs queryTaskArgs = new Views.QueryTaskArgs();

        #region【界面事件】
        // 查询
        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            queryTaskArgs.SelectedTaskTypeId = dropTaskType.SelectedValue;
            queryTaskArgs.SearchKeyWord = btnSearch.Text;
            queryTaskArgs.User = (DataTable)Session["User"];
            OnSearch(null, queryTaskArgs);
        }

        // 删除多条记录
        protected void btnDataBaseDelete_Click(object sender, EventArgs e)
        {
            int[] selectedArr = gridTask.SelectedRowIndexArray;
            if (selectedArr.Length == 0)
            {
                return;
            }
            List<object> idArr = new List<object>();
            for (int i = 0; i < selectedArr.Length; i++)
            {
                idArr.Add(this.gridTask.DataKeys[selectedArr[i]][0]);

            }
            queryTaskArgs.User = (DataTable)Session["User"];
            queryTaskArgs.DeletedTaskArr = idArr;
            OnDeletedTaskArr(null, queryTaskArgs);
            btnSearch_Trigger2Click(null, null);
        }

        // 编辑、删除
        protected void gridTask_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridTask.DataKeys[e.RowIndex];
            queryTaskArgs.User = (DataTable)Session["User"];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditTask.aspx?isEdit=1&EditTaskID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    queryTaskArgs.DeleteTaskId = keys[0].ToString();
                    OnDeleteTaskId(null, queryTaskArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
                case "DownLoadFile":
                    PageContext.RegisterStartupScript(winDownloadFiles.GetShowReference("DownloadFile.aspx?TaskId=" + keys[0].ToString(), "下载文件")); 
                    break;
            }
        }

        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridTask;
            this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        #endregion

        #region 【接口绑定】
        /// <summary>
        /// 绑定界面任务Grid
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeGridTask(DataTable dtTask)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtTask.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridTask.PageSize;
            ps.CurrentPageIndex = gridTask.PageIndex;
            gridTask.RecordCount = dtTask.Rows.Count;
            gridTask.DataSource = dtTask;
            gridTask.DataBind();
            InitGrid(dtTask);
        }

        /// <summary>
        /// 绑定任务类型下拉框
        /// </summary>
        /// <param name="dtTaskType"></param>
        public void ExeDropTaskType(DataTable dtTaskType)
        {
            DataRow dr = dtTaskType.NewRow();
            dr["task_type_id"] = 0;
            dr["task_type_name"] = "全部";
            dtTaskType.Rows.InsertAt(dr, 0);
            dropTaskType.DataSource = dtTaskType;
            dropTaskType.DataTextField = "task_type_name";
            dropTaskType.DataValueField = "task_type_id";
            dropTaskType.DataBind();
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.QueryTaskArgs> OnInit;

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QueryTaskArgs> OnSearch;

        /// <summary>
        /// 删除单个任务事件
        /// </summary>
        public event EventHandler<Views.QueryTaskArgs> OnDeleteTaskId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        public event EventHandler<Views.QueryTaskArgs> OnDeletedTaskArr;

        #endregion
    }
}