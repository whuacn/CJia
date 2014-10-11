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
    public partial class QueryCheck : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IQueryCheck
    {
        CJia.HealthInspection.Views.QueryCheckArgs queryCheckArgs = new Views.QueryCheckArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryCheckPresenter(this);
        }

        private void BindGrid(ExtAspNet.Grid grid,DataTable dtResult)
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


        #region【接口实现】
        public event EventHandler<Views.QueryCheckArgs> OnQueryCheckByKey;

        public void ExeBindCheck(System.Data.DataTable dtCheck)
        {
            //InitGrid(dtCheck);
            Session["CheckRecord"] = dtCheck;
            BindGrid(gridCheck, dtCheck);
        }
        #endregion

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            queryCheckArgs.keyWord = txt_Check.Text;
            queryCheckArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            OnQueryCheckByKey(null, queryCheckArgs);
        }

        //分页
        protected void gridCheck_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            DataTable dtCheck = Session["CheckRecord"] as DataTable;
            gridCheck.PageIndex = e.NewPageIndex;
            BindGrid(gridCheck, dtCheck);
        }

        protected void gridCheck_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            if (e.CommandName == "See" )
            {
                object[] keys = gridCheck.DataKeys[e.RowIndex];
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/UI/QueryCheckTask/ReadCheck.aspx?ExeCheckId=" + keys[0], "查看执行监督记录"));
            }
        }

        protected void gridCheck_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["CheckRecord"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gridCheck.DataSource = view1;
            gridCheck.DataBind();
        }
    }
}