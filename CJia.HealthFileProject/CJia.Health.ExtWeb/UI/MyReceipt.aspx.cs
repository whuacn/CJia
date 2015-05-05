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
    public partial class MyReceipt : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyApplyView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.MyApplyPresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        CJia.Health.Views.Web.MyApplyArgs myApplyArgs = new Views.Web.MyApplyArgs();

        public void Init()
        {
            if (OnLoadMyApply != null && Session["User"] != null)
            {
                myApplyArgs.UserData = Session["User"] as DataTable;
                OnLoadMyApply(null, myApplyArgs);
            }
        }
        #region IMyApplyView成员
        public event EventHandler<CJia.Health.Views.Web.MyApplyArgs> OnLoadMyApply;
        public event EventHandler<CJia.Health.Views.Web.MyApplyArgs> OnUndo;
        public event EventHandler<CJia.Health.Views.Web.MyApplyArgs> OnDetail;
        public void ExeBindApplyDetail(DataTable data)
        {
            Session["MyReceipt2"] = new DataTable();
            Session["MyReceipt2"] = data;
            InitGrid(data, gr_detail);
        }
        public void ExeBindInit(DataTable data)
        {
            Session["MyReceipt"] = new DataTable();
            Session["MyReceipt"] = data;
            InitGrid(data, gr_Main);
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
            switch (e.CommandName)
            {
                case "Info":
                    string listID = keys[0].ToString();
                    if (OnDetail != null)
                    {
                        myApplyArgs.ListID = listID;
                        OnDetail(sender, myApplyArgs);
                    }
                    applyName.Text = keys[1].ToString();
                    applyTime.Text = keys[2].ToString();
                    applyReson.Text = keys[3].ToString();
                    applyReson.ToolTip = keys[3].ToString();
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
            }
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["MyReceipt"] != null)
            {
                this.gr_Main.PageIndex = e.NewPageIndex;
                DataTable dt = Session["MyReceipt"] as DataTable;
                this.InitGrid(dt, gr_Main);
            }
        }

        protected void gr_detail_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["MyReceipt2"] != null)
            {
                this.gr_detail.PageIndex = e.NewPageIndex;
                DataTable dt = Session["MyReceipt2"] as DataTable;
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
            }
        }


    }
}