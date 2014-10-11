using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class PatientApplyView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IPatientApplyView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PatientData"] != null)
                {
                    DataTable patientData = Session["PatientData"] as DataTable;
                    PatientGridView.DataSource = patientData;
                    PatientGridView.DataBind();
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.PatientApplyPresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        Views.Web.PatientApplyArgs patientApplyArgs = new Views.Web.PatientApplyArgs();

        #region IPatientApplyView成员
        public event EventHandler<Views.Web.PatientApplyArgs> OnApply;
        public void ExeBindPatient(DataTable data)
        {
            PatientGridView.DataSource = data;
            PatientGridView.DataBind();
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 判断已勾选病人
        /// </summary>
        /// <returns></returns>
        public bool GetCheckedPatient()
        {
            bool bol = false;
            for (int i = 0; i < PatientGridView.Rows.Count; i++)
            {
                CheckBox ckbox = new CheckBox();
                ckbox = (CheckBox)PatientGridView.Rows[i].FindControl("ckApply");
                if (ckbox != null && ckbox.Checked == true)
                {
                    bol = true;
                }
            }
            return bol;
        }
        /// <summary>
        /// 获得选中的病案号
        /// </summary>
        /// <returns></returns>
        public List<string> GetRecordNO()
        {
            List<string> recordNO = new List<string>();
            for (int i = 0; i < PatientGridView.Rows.Count; i++)
            {
                CheckBox ckbox = new CheckBox();
                ckbox = (CheckBox)PatientGridView.Rows[i].FindControl("ckApply");
                if (ckbox != null && ckbox.Checked == true)
                {
                    Label lbl = new Label();
                    lbl = (Label)PatientGridView.Rows[i].FindControl("lblID");
                    string txt = lbl.Text;
                    recordNO.Add(txt);
                }
            }
            return recordNO;
        }
        #endregion
        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MyPatient")
            {
                string recordNO = e.CommandArgument.ToString();
                DataTable patientData = Session["PatientData"] as DataTable;
                DataRow[] onePatient = patientData.Select(" RECORDNO='" + recordNO + "'");
                Session["OnePatientData"] = patientData.NewRow();
                Session["OnePatientData"] = onePatient[0];
                string patientName = onePatient[0]["PATIENT_NAME"].ToString() + "「" + onePatient[0]["RECORDNO"].ToString() + "」";
                RunScript("top.myTab.Cts('" + patientName + "','PatientInfoView.aspx',true);");
                //Response.Redirect("PatientInfoView.aspx");
            }
        }
        private void RunScript(string script)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), script, script, true);
        }
        protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentColor=this.style.backgroundColor;this.style.backgroundColor='#FFE4B5';");//FFE4B5 6ed0ff
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentColor;");
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (GetCheckedPatient() && OnApply != null && Session["User"] != null)
            {
                patientApplyArgs.HealthIDList = GetRecordNO();
                if (Session["Select"] != null)
                {
                    MyPatient patient = Session["Select"] as MyPatient;
                    patientApplyArgs.Patient = patient;
                }
                if (txtReason.Value.Trim().Length > 51)
                {
                    patientApplyArgs.Reason = txtReason.Value.Trim().Substring(0, 50);
                }
                else if (txtReason.Value.Trim() == "最多输入汉字50个！！！")
                {
                    patientApplyArgs.Reason = "";
                }
                else
                {
                    patientApplyArgs.Reason = txtReason.Value.Trim();
                }
                patientApplyArgs.UserData = Session["User"] as DataTable;
                OnApply(sender, patientApplyArgs);
                lblMeg.Text = "";
                txtReason.Value = "最多输入汉字50个！！！";
            }
            else
            {
                lblMeg.Text = "请勾选病案";
            }
        }
    }
}