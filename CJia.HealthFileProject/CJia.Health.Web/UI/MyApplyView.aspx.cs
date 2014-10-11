using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class MyApplyView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyApplyView
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
            if (data != null)
            {
                Session["BorrowDetailData"] = new DataTable();
                Session["BorrowDetailData"] = data;
                Response.Redirect("MyApplyDetailView.aspx");
            }
        }
        public void ExeBindInit(DataTable data)
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
        #endregion

        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MyDelete")
            {
                string listID = e.CommandArgument.ToString();
                if (OnUndo != null && Session["User"] != null)
                {
                    myApplyArgs.ListID = listID;
                    myApplyArgs.UserData = Session["User"] as DataTable;
                    OnUndo(sender, myApplyArgs);
                    Init();
                }
            }
            if (e.CommandName == "MyApplyDetail")
            {
                string listID = e.CommandArgument.ToString();
                if (OnDetail != null)
                {
                    myApplyArgs.ListID = listID;
                    OnDetail(sender, myApplyArgs);
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