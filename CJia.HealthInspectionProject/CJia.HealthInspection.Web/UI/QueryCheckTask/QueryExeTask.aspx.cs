using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.QueryCheckTask
{
    public partial class QueryExeTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IQueryExeTask
    {
        CJia.HealthInspection.Views.QueryExeTaskArgs queryExeTaskArgs = new Views.QueryExeTaskArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryExeTaskPresenter(this);
        }

        #region【实现接口】
        public event EventHandler<Views.QueryExeTaskArgs> OnQueryExeTaskByKeyWord;

        public void ExeBindExeTask(System.Data.DataTable dtExeTask)
        {
            Session["ExeTaskRecord"] = dtExeTask;
            BindGrid(gridExeTask, dtExeTask);

        }
        #endregion

        #region【方法】
        private void BindGrid(ExtAspNet.Grid grid, DataTable dtResult)
        {
            // 1.设置总项数
            grid.RecordCount = dtResult.Rows.Count;

            // 2.获取当前分页数据
            DataTable paged = dtResult.Clone();

            int rowbegin = grid.PageIndex * grid.PageSize;
            int rowend = (grid.PageIndex + 1) * grid.PageSize;
            if (rowend > dtResult.Rows.Count)
            {
                rowend = dtResult.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(dtResult.Rows[i]);
            }

            // 3.绑定到Grid
            grid.DataSource = paged;
            grid.DataBind();
        }
        #endregion

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            queryExeTaskArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            queryExeTaskArgs.keyWord = txt_ExeTask.Text;
            OnQueryExeTaskByKeyWord(null, queryExeTaskArgs);
        }

        protected void gridCheck_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            DataTable dtCheck = Session["ExeTaskRecord"] as DataTable;
            gridExeTask.PageIndex = e.NewPageIndex;
            BindGrid(gridExeTask, dtCheck);
        }

        protected void gridCheck_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            if (e.CommandName == "See")
            {
                object[] keys = gridExeTask.DataKeys[e.RowIndex];
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/UI/QueryCheckTask/ReadExeTask.aspx?ExeTaskId=" + keys[0]+"&OrganName=" + keys[1], "查询执行任务记录"));
            }
        }

        protected void gridExeTask_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["ExeTaskRecord"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gridExeTask.DataSource = view1;
            gridExeTask.DataBind();
        }
    }
}