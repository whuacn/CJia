using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.ExtWeb.UI
{
    public partial class PatientInfoView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IPatientApplyView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    PatientApplyArgs.ID = Request["ID"].ToString();
                    OnGetPatientByID(null, PatientApplyArgs);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.PatientApplyPresenter(this);
        }
        Views.Web.PatientApplyArgs PatientApplyArgs = new Views.Web.PatientApplyArgs();
        public event EventHandler<Views.Web.PatientApplyArgs> OnApply;
        public event EventHandler<Views.Web.PatientApplyArgs> OnGetPatientByID;
        public void ExeBindPatient(DataTable data)
        {
            DataRow patientRow = data.Rows[0];
            lblPatientName.Text = patientRow["PATIENT_NAME"].ToString();
            lblPatientName1.Text = patientRow["PATIENT_NAME"].ToString();
            lblInHosTimes.Text = patientRow["IN_HOSPITAL_TIME"].ToString();
            lblRecordNO.Text = patientRow["RECORDNO"].ToString();

            lblGender.Text = patientRow["GENDER_NAME"].ToString();
            lblBirthDay1.Text = DateTime.Parse(patientRow["BIRTHDAY"].ToString()).ToShortDateString();
            lblHunFou.Text = patientRow["IS_MARRY_NAME"].ToString();
            lblZhiYe.Text = patientRow["JOB_NAME"].ToString();
            lblBirthCity.Text = patientRow["COUNTRY_NAME"].ToString() + patientRow["PROVINCE_NAME"].ToString() + patientRow["CITY_NAME"].ToString();
            lblMinZu.Text = patientRow["NATION_NAME"].ToString();
            lblGuoJi.Text = patientRow["COUNTRY_NAME"].ToString();
            lblRYFS.Text = patientRow["IN_HOSPITAL_TYPE_NAME"].ToString();

            lblRYDept.Text = patientRow["IN_HOSPITAL_DEPT_NAME"].ToString();
            lblRYDate.Text = DateTime.Parse(patientRow["IN_HOSPITAL_DATE"].ToString()).ToShortDateString();
            lblRYDoctor.Text = patientRow["IN_HOSPITAL_DOCTOR_NAME"].ToString();
            lblRYDoctorNO.Text = patientRow["IN_HOSPITAL_DOCTOR_NO"].ToString();
            lblCYDept.Text = patientRow["OUT_HOSPITAL_DEPT_NAME"].ToString();
            lblCYDate.Text = DateTime.Parse(patientRow["OUT_HOSPITAL_DATE"].ToString()).ToShortDateString();
            //lblCYDoctor.Text = patientRow["OUT_HOSPITAL_DOCTOR_NAME"].ToString();
            //lblCYDoctorNO.Text = patientRow["OUT_HOSPITAL_DOCTOR_NO"].ToString();

            lblCYZD1.Text = patientRow["OUTDIA_NAME1"].ToString();
            lblCYZD2.Text = patientRow["OUTDIA_NAME2"].ToString();
            lblCYZD3.Text = patientRow["OUTDIA_NAME3"].ToString();
            lblCYZD4.Text = patientRow["OUTDIA_NAME4"].ToString();
            lblSSMC1.Text = patientRow["SURGERY_NAME1"].ToString();
            lblSSMC2.Text = patientRow["SURGERY_NAME2"].ToString();

            lblSSMC3.Text = patientRow["SURGERY_NAME3"].ToString();
            lblSSMC4.Text = patientRow["SURGERY_NAME4"].ToString();
            lblYNGR1.Text = patientRow["YNGR_NAME1"].ToString();
            lblYNGR2.Text = patientRow["YNGR_NAME2"].ToString();
            lblBLZD1.Text = patientRow["BLZD_NAME1"].ToString();
            lblBLZD2.Text = patientRow["BLZD_NAME2"].ToString();
        }
    }
}