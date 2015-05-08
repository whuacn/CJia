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
    public partial class MyFavorite : CJia.Health.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (Request["id"] != null)
                    {
                        string favid = Request["id"].ToString();
                        DataTable data = GetfavouriteByID(favid);
                        string sessonID="MyFavorite"+favid;
                        Session[sessonID] = new DataTable();
                        Session[sessonID] = data;
                        InitGrid(data, gr_detail);
                    }
                }
            }
        }
        protected override object CreatePresenter()
        {
            return null;
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
            string favid = Request["id"].ToString();
            string sessonID = "MyFavorite" + favid;
            if (Session[sessonID] != null)
            {
                this.gr_detail.PageIndex = e.NewPageIndex;
                DataTable dt = Session[sessonID] as DataTable;
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
                case "Delete":
                    bool bol = RemoveFavDetail(keys[1].ToString());
                    if (bol)
                        PageContext.Refresh();
                    break;
            }
        }

        protected void btnDeleteFav_Click(object sender, EventArgs e)
        {
            bool bol= RemoveFavName(Request["id"].ToString());
            if (bol)
            {
                Alert.ShowInTop("删除成功");
                PageContext.Refresh();
            }
        }
    }
}