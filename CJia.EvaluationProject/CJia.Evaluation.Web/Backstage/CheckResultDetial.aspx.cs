using CJia.Evaluation.Views.Backstage;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class CheckResultDetial : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.ICheckSubmit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnReadDetail != null && Request.QueryString["ID"] != null)
                {
                    checkSubmitArgs.CheckID = Request.QueryString["ID"].ToString();
                    OnReadDetail(null, checkSubmitArgs);
                }
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.CheckSubmitPresenter(this);
        }
        CheckSubmit checkSubmitArgs = new CheckSubmit();
        public event EventHandler OnInitPage;
        public event EventHandler<CheckSubmit> OnIndexChange;
        public event EventHandler<CheckSubmit> OnSubmit;
        public event EventHandler<CheckSubmit> OnReadDetail;
        public event EventHandler<CheckSubmit> OnSaveCheck;
        public void ExeBindIsSuccessCheck(bool bol)
        {

        }
        public void ExeBindCheckDetail(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                treeName.Text = data.Rows[0]["TREE_NAME"].ToString();
                maosu.Text = data.Rows[0]["DESCRIPTION"].ToString();
                zerenren.Text = data.Rows[0]["RESPONSIBLE_NAME"].ToString();
                baoshensj.Text = data.Rows[0]["SUBMIT_DATE"].ToString();
                pingshenren.Text = data.Rows[0]["CHECK_USER_NAME"].ToString();
                pingshensj.Text = data.Rows[0]["CHECK_DATE"].ToString();
                pingshenzhuangt.Text = data.Rows[0]["STATE_NAME"].ToString();
                pingshenjieguo.Text = data.Rows[0]["RESULT_NAME"].ToString();
                cishu.Text = data.Rows[0]["TIMES"].ToString();
                jiezhisj.Text = data.Rows[0]["END_DATE"].ToString();
                psyijian.Text = data.Rows[0]["CHECK_ADVICE"].ToString();
                zgyijian.Text = data.Rows[0]["RECTIFICATION"].ToString();
            }
        }
        public void ExeBindPage(DataTable stateData, DataTable resultData) { }
        public void ExeBindCheckData(DataTable data) { }
        public void ExeBindIsSuccessSubmit(bool bol) { }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}