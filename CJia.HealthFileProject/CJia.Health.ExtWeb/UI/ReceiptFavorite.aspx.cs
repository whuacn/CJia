using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb.UI
{
    public partial class ReceiptFavorite : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyBorrowView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnLoadBorrow != null && Session["User"] != null)
                {
                    myBorrowArgs.UserData = Session["User"] as DataTable;
                    OnLoadBorrow(null, myBorrowArgs);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.MyBorrowPresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        Views.Web.MyBorrowArgs myBorrowArgs = new Views.Web.MyBorrowArgs();

        #region IMyBorrowView成员
        public event EventHandler<Views.Web.MyBorrowArgs> OnLoadBorrow;
        public event EventHandler<Views.Web.MyBorrowArgs> OnDetail;
        public void ExeInit(DataTable data)
        {
            Session["ReceiptFavorite"] = new DataTable();
            Session["ReceiptFavorite"] = data;
            InitGrid(data, gr_Main);
        }
        public void ExeDetail(DataTable data)
        {
            Session["ReceiptFavorite2"] = new DataTable();
            Session["ReceiptFavorite2"] = data;
            InitGrid(data, gr_detail);
        }
        #endregion
        public void InitGrid(DataTable data, Grid grid)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = data.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = grid.PageSize; //显示的数量
            ps.CurrentPageIndex = grid.PageIndex; //取得当前页的页码
            grid.RecordCount = data.Rows.Count;
            grid.DataSource = ps;
            grid.DataBind();
        }
        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            string listID = keys[0].ToString();
            switch (e.CommandName)
            {
                case "Info":
                    gr_detail.PageIndex = 0;
                    if (OnDetail != null)
                    {
                        myBorrowArgs.ListID = listID;
                        OnDetail(sender, myBorrowArgs);
                    }
                    applyName.Text = keys[1].ToString();
                    applyTime.Text = keys[2].ToString();
                    applyReson.Text = keys[3].ToString();
                    applyReson.ToolTip = keys[3].ToString();
                    lblStart.Text = keys[4].ToString();
                    lblEnd.Text = keys[5].ToString();
                    break;
                case "Resert":
                    break;
            }
        }

        protected void gr_Main_RowClick(object sender, GridRowClickEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object[] keys = this.gr_Main.DataKeys[e.RowIndex];
                applyName.Text = keys[1].ToString();
                applyTime.Text = keys[2].ToString();
                applyReson.Text = keys[3].ToString();
                applyReson.ToolTip = keys[3].ToString();
                lblStart.Text = keys[4].ToString();
                lblEnd.Text = keys[5].ToString();
            }
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["ReceiptFavorite"] != null)
            {
                this.gr_Main.PageIndex = e.NewPageIndex;
                DataTable dt = Session["ReceiptFavorite"] as DataTable;
                this.InitGrid(dt, gr_Main);
            }
        }

        protected void gr_detail_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["ReceiptFavorite2"] != null)
            {
                this.gr_detail.PageIndex = e.NewPageIndex;
                DataTable dt = Session["ReceiptFavorite2"] as DataTable;
                this.InitGrid(dt, gr_detail);
            }

        }

        protected void gr_detail_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gr_detail.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Details":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("PatientInfoView.aspx?ID=" + keys[0].ToString(), "基本信息"));
                    break;
                case "Image":
                    PageContext.RegisterStartupScript(win_Image.GetShowReference("PhotoView.aspx?ID=" + keys[0].ToString(), "图片浏览"));
                    break;
            }
        }
    }
}