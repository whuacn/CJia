using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class ReadBorrowView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IReadBorrowView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnLoadBorrow != null && Session["User"] != null)
                {
                    readBorrowArgs.UserData = Session["User"] as DataTable;
                    OnLoadBorrow(null, readBorrowArgs);
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
            if (data != null)
            {
                PatientGridView.DataSource = data;
                PatientGridView.DataBind();
                lblMsg.Visible = false;
                Session["BorrowDetailData"] = new DataTable();
                Session["BorrowDetailData"] = data;
            }
            else
            {
                lblMsg.Visible = true;
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