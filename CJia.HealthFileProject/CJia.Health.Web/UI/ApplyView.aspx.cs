using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class ApplyView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IApplyView
    {
        /// <summary>
        ///查询出的病案信息
        /// </summary>
        private DataTable RecordData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Web.ApplyPresenter(this);
        }
        /// <summary>
        /// 申请参数
        /// </summary>
        Views.Web.ApplyEventArgs applyEventArgs = new Views.Web.ApplyEventArgs();

        #region IApplyView成员
        public event EventHandler<Views.Web.ApplyEventArgs> OnSelectRecord;
        public event EventHandler<Views.Web.ApplyEventArgs> OnApply;
        public void ExeBindRecord(DataTable data)
        {
            RecordData = data;
            RecordGridView.DataSource = data;
            RecordGridView.DataBind();
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 校验查询条件不能为空
        /// </summary>
        /// <returns></returns>
        public bool isRightInput()
        {
            if (txtPatientName.Text.Trim().Length > 0)
            {
                lblMessage.Text = "";
                return true;
            }
            else
            {
                lblMessage.Text = "请输入病人信息查询";
                return false;
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void FillData()
        {
            if (RecordData != null)
            {
                RecordGridView.DataSource = RecordData;
                RecordGridView.DataBind();
            }
        }
        #endregion

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RecordGridView.PageIndex = e.NewPageIndex;
            FillData();
        }

        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MyApply" && OnApply != null)
            {
                string recordNO = e.CommandArgument.ToString();
                applyEventArgs.RecordNO = recordNO;
                applyEventArgs.UserData = Session["User"] as DataTable;
                OnApply(sender, applyEventArgs);
                btnSelect_Click(null, null);
            }
        }

        protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentColor=this.style.backgroundColor;this.style.backgroundColor='#6ed0ff';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentColor;");
            }
        }
        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (OnSelectRecord != null)
            {
                if (!isRightInput()) return;
                applyEventArgs.PatientName = txtPatientName.Text.Trim();
                applyEventArgs.UserData = Session["User"] as DataTable;
                OnSelectRecord(sender, applyEventArgs);
            }
        }


    }
}