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
    public partial class MyBorrow : CJia.Health.Tools.Page, CJia.Health.Views.Web.IReadBorrowView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (OnLoadBorrow != null)
                    {
                        readBorrowArgs.UserData = Session["User"] as DataTable;
                        OnLoadBorrow(null, readBorrowArgs);
                    }
                    win_Image.Width = int.Parse(Request["w"].ToString());
                    win_Image.Height = int.Parse(Request["h"].ToString());
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.ReadBorrowPresenter(this);
        }
        Views.Web.ReadBorrowArgs readBorrowArgs = new Views.Web.ReadBorrowArgs();
        public event EventHandler<Views.Web.ReadBorrowArgs> OnLoadBorrow;

        public void ExeBindBorrow(DataTable data)
        {
            Session["MyBorrow"] = new DataTable();
            Session["MyBorrow"] = data;
            InitGrid(data, gr_detail);
        }
        public void InitGrid(DataTable data, Grid grid)
        {
            if (data != null)
            {
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = data.DefaultView;
                ps.AllowPaging = true;
                ps.PageSize = grid.PageSize;
                ps.CurrentPageIndex = grid.PageIndex;
                grid.RecordCount = data.Rows.Count;
                grid.DataSource = ps;
                grid.DataBind();
            }
        }
        protected void gr_detail_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["MyBorrow"] != null)
            {
                this.gr_detail.PageIndex = e.NewPageIndex;
                DataTable dt = Session["MyBorrow"] as DataTable;
                this.InitGrid(dt, gr_detail);
            }

        }

        protected void gr_detail_RowCommand(object sender, GridCommandEventArgs e)
        {
            string w = Request["w"].ToString();
            string h = Request["h"].ToString();
            object[] keys = this.gr_detail.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Details":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("PatientInfoView.aspx?ID=" + keys[0].ToString(), "基本信息"));
                    break;
                case "Image":
                    PageContext.RegisterStartupScript(win_Image.GetShowReference("PhotoView.aspx?ID=" + keys[0].ToString() + "&w=" + w + "&h=" + h, "图片浏览"));
                    break;
            }
        }
    }
}