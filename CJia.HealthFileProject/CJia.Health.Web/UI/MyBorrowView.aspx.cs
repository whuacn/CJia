using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class MyBorrowView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyBorrowView
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
            if (data != null)
            {
                BorrowListGridView.DataSource = data;
                BorrowListGridView.DataBind();
                lblMsg.Visible = false;
            }
            else
            {
                lblMsg.Visible = true;
            }
        }
        public void ExeDetail(DataTable data)
        {
            if (data != null)
            {
                Session["BorrowDetailData"] = new DataTable();
                Session["BorrowDetailData"] = data;
                Response.Redirect("MyBorrowDetailView.aspx");
            }
        }
        #endregion

        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MyApplyDetail")
            {
                string listID = e.CommandArgument.ToString();
                if (OnDetail != null)
                {
                    myBorrowArgs.ListID = listID;
                    OnDetail(sender, myBorrowArgs);
                }
            }
        }

        protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentColor=this.style.backgroundColor;this.style.backgroundColor='#FFE4B5';");//FFE4B5 6ed0ff
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentColor;");
            }
        }
    }
}