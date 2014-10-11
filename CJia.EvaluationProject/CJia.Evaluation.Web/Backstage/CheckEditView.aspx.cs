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
    public partial class CheckEditView : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.ICheckSubmit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnInitPage != null)
                {
                    OnInitPage(null, null);
                }
                if (Request.QueryString["ID"] != null)
                {
                    checkSubmitArgs.CheckID = Request.QueryString["ID"].ToString();
                    OnReadDetail(null, checkSubmitArgs);
                    ddl_state_SelectedIndexChanged(null, null);
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
            if (bol)
            {
                Alert.ShowInTop("评审成功", "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("评审失败，请与管理员联系……");
            }
        }
        public void ExeBindCheckDetail(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                treeName.Text = data.Rows[0]["TREE_NAME"].ToString();
                maosu.Text = data.Rows[0]["DESCRIPTION"].ToString();
                ddl_state.SelectedValue = data.Rows[0]["CHECK_STATE"].ToString();
                ddl_result.SelectedValue = data.Rows[0]["CHECK_RESULT"].ToString();
                txt_advice.Text = data.Rows[0]["CHECK_ADVICE"].ToString();
                txt_zhenggai.Text = data.Rows[0]["RECTIFICATION"].ToString();
                txt_cishu.Text = data.Rows[0]["TIMES"].ToString();
                if (data.Rows[0]["END_DATE"].ToString().Length != 0)
                    zhenggai_date.SelectedDate = DateTime.Parse(data.Rows[0]["END_DATE"].ToString());
                else
                    zhenggai_date.SelectedDate = null;
                txt_zerenren.Text = data.Rows[0]["RESPONSIBLE_NAME"].ToString();
                if (data.Rows[0]["SUBMIT_DATE"].ToString().Length != 0)
                    txt_baoshenriqi.Text = (DateTime.Parse(data.Rows[0]["SUBMIT_DATE"].ToString())).ToString("yyyy-MM-dd HH:mm:ss");
                else
                    txt_baoshenriqi.Text = "";
                txt_pingshenren.Text = data.Rows[0]["CHECK_USER_NAME"].ToString();
                //if (data.Rows[0]["CHECK_DATE"].ToString().Length != 0)
                //    pingshen_date.SelectedDate = DateTime.Parse((data.Rows[0]["CHECK_DATE"].ToString()));
                //else
                pingshen_date.SelectedDate = Sysdate;
            }
        }
        public void ExeBindPage(DataTable stateData, DataTable resultData)
        {
            if (stateData != null && stateData.Rows.Count > 0)
            {
                stateData.Rows.RemoveAt(0);
                BindDDL(ddl_state, "CODE", "NAME", stateData);
            }
            if (resultData != null && resultData.Rows.Count > 0)
            {
                BindDDL(ddl_result, "CODE", "NAME", resultData);
            }
        }
        public void ExeBindCheckData(DataTable data) { }
        public void ExeBindIsSuccessSubmit(bool bol) { }

        public void BindDDL(ExtAspNet.DropDownList ddl, string value, string text, DataTable data)
        {
            ddl.DataValueField = value;
            ddl.DataTextField = text;
            ddl.DataSource = data;
            ddl.DataBind();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            checkSubmitArgs.CheckID = Request.QueryString["ID"].ToString();
            checkSubmitArgs.CheckStateID = ddl_state.SelectedValue;
            if (ddl_result.SelectedValue != null)
                checkSubmitArgs.CheckResultID = ddl_result.SelectedValue.ToString();
            else
                checkSubmitArgs.CheckResultID = "";
            checkSubmitArgs.CheckAdvice = txt_advice.Text;
            checkSubmitArgs.ZhengGaiAdvice = txt_zhenggai.Text;
            checkSubmitArgs.EndDate = zhenggai_date.SelectedDate.ToString();
            checkSubmitArgs.CheckDate = pingshen_date.SelectedDate.ToString();
            if (Session["User"] != null)
            {
                DataTable userdata = Session["User"] as DataTable;
                checkSubmitArgs.UserID = userdata.Rows[0]["USER_ID"].ToString();
                checkSubmitArgs.UserName = userdata.Rows[0]["USER_NAME"].ToString();
            }
            OnSaveCheck(null, checkSubmitArgs);
        }

        protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_state.SelectedValue == "1202")
            {
                txt_advice.Readonly = true;
                txt_advice.Text = "";
                txt_zhenggai.Readonly = true;
                txt_zhenggai.Text = "";
                zhenggai_date.Readonly = true;
                zhenggai_date.SelectedDate = null;
                ddl_result.Readonly = true;
                ddl_result.SelectedValue = null;
            }
            if (ddl_state.SelectedValue == "1203")
            {
                txt_advice.Readonly = false;
                txt_zhenggai.Readonly = true;
                txt_zhenggai.Text = "";
                zhenggai_date.Readonly = true;
                zhenggai_date.SelectedDate = null;
                ddl_result.Readonly = false;
            }
            if (ddl_state.SelectedValue == "1204")
            {
                txt_advice.Readonly = false;
                txt_zhenggai.Readonly = false;
                zhenggai_date.Readonly = false;
                ddl_result.Readonly = true;
                ddl_result.SelectedValue = null;
            }
        }
    }
}