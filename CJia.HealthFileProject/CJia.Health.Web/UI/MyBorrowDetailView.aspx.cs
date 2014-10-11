using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class MyBorrowDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BorrowDetailData"] != null)
                {
                    DataTable data = Session["BorrowDetailData"] as DataTable;
                    PatientGridView.DataSource = data;
                    PatientGridView.DataBind();
                    lblApplyName.Text = data.Rows[0]["APPLYER_NAME"].ToString();
                    lblApplyDate.Text = data.Rows[0]["APPLY_DATE"].ToString();
                    lblListNO.Text = data.Rows[0]["BORROW_LIST_NO"].ToString();
                    lblReason.Text = data.Rows[0]["APPLY_REASON"].ToString();
                    lblBorrowState.Text = data.Rows[0]["BORROW_STATE_NAME"].ToString();
                    lblStart.Text = data.Rows[0]["BORROW_DATE"].ToString();
                    lblEnd.Text = data.Rows[0]["RETURN_DATE"].ToString();
                }
            }
        }

        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MyPatient")
            {
                string recordNO = e.CommandArgument.ToString();
                DataTable patientData = Session["BorrowDetailData"] as DataTable;
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
    }
}