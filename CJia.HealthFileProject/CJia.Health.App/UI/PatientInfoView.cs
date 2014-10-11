using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class PatientInfoView : UserControl
    {

        private DataRow PatientInfo;

        public PatientInfoView(DataRow result)
        {
            InitializeComponent();
            this.PatientInfo = result;
            this.init();
        }

        private void init()
        {
            if(PatientInfo != null)
            {
                this.ltxtRecordNo.MyText = PatientInfo["RECORDNO"].ToString();
                this.ltxtPatientId.MyText = PatientInfo["PATIENT_ID"].ToString();
                this.ltxtShelfNo.MyText = PatientInfo["SHELFNO"].ToString();
                this.chkIsSpecial.Checked = PatientInfo["IS_SPECIAL"].ToString() == "0" ? false : true;
                this.ltxtPatientName.MyText = PatientInfo["PATIENT_NAME"].ToString();
                this.AssignmentCJiaComboBox2(this.cboGender, PatientInfo["GENDER_NAME"].ToString());
                this.cboBirthday.EditValue = PatientInfo["BIRTHDAY"];
                this.AssignmentCJiaComboBox2(this.cboJob,PatientInfo["JOB_NAME"].ToString());
                this.AssignmentRTLookUp(this.rtlkProvince,PatientInfo["province_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkCity,PatientInfo["city_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboIsMarry,PatientInfo["is_marry_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboNation,PatientInfo["nation_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboCountry,PatientInfo["country_name"].ToString());
                this.ltxtIdCard.MyText = PatientInfo["id_card"].ToString();
                this.AssignmentCJiaComboBox2(this.cboInHospitalType,PatientInfo["in_hospital_type_name"].ToString());
                this.ltxtInHospitalTime.MyText = PatientInfo["in_hospital_time"].ToString();
                this.cboInHospitalDate.EditValue = PatientInfo["in_hospital_date"];
                this.AssignmentRTLookUp(this.rtlkInHospitalDept, PatientInfo["in_hospital_dept_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkInHospitalDoctor,PatientInfo["in_hospital_doctor_name"].ToString());
                this.ltxtInHospitalDocId.MyText = PatientInfo["in_hospital_doctor_no"].ToString();
                this.cboOutHospitalDate.EditValue = PatientInfo["out_hospital_date"];
                this.AssignmentRTLookUp(this.rtlkOutHospitalDept,PatientInfo["out_hospital_dept_name"].ToString());
                //this.AssignmentRTLookUp(this.rtlkOutHospitalDoctor, PatientInfo["out_hospital_doctor_name"].ToString());
                //this.ltxtOutHospitalDocId.MyText = PatientInfo["out_hospital_doctor_no"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDOutDia1,PatientInfo["icd_outdia1"].ToString());
                this.ltxtOutDiaName1.MyText = PatientInfo["outdia_name1"].ToString();
                this.AssignmentRTLookUp(this.rtlkTreatResult1,PatientInfo["treat_result1_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkICDSurgery1,PatientInfo["surgery_name1"].ToString());
                this.ltxtSurgeryName1.MyText = PatientInfo["surgery_name1"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDOutDia2,PatientInfo["icd_outdia2"].ToString());
                this.ltxtOutDiaName2.MyText = PatientInfo["outdia_name2"].ToString();
                this.AssignmentRTLookUp(this.rtlkTreatResult2,PatientInfo["treat_result2_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkICDSurgery2,PatientInfo["surgery_name2"].ToString());
                this.ltxtSurgeryName2.MyText = PatientInfo["surgery_name2"].ToString();
                this.AssignmentRTLookUp( this.rtlkICDOutDia3,PatientInfo["icd_outdia3"].ToString());
                this.ltxtOutDiaName3.MyText = PatientInfo["outdia_name3"].ToString();
                this.AssignmentRTLookUp(this.rtlkTreatResult3,PatientInfo["treat_result3_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkICDSurgery3,PatientInfo["surgery_name3"].ToString());
                this.ltxtSurgeryName3.MyText = PatientInfo["surgery_name3"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDOutDia4,PatientInfo["icd_outdia4"].ToString());
                this.ltxtOutDiaName4.MyText = PatientInfo["outdia_name3"].ToString();
                this.AssignmentRTLookUp(this.rtlkTreatResult4,PatientInfo["treat_result4_name"].ToString());
                this.AssignmentRTLookUp(this.rtlkICDSurgery4,PatientInfo["surgery_name4"].ToString());
                this.ltxtSurgeryName4.MyText = PatientInfo["surgery_name4"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDBLZD1,PatientInfo["icd_blzd1"].ToString());
                this.ltxtBLZDName1.MyText = PatientInfo["blzd_name1"].ToString();
                this.ltxtDrugAllergy.MyText = PatientInfo["drug_allergy"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDYNGR1,PatientInfo["icd_yngr1"].ToString());
                this.ltxtYNGRName1.MyText = PatientInfo["yngr_name1"].ToString();
                this.AssignmentRTLookUp(this.rtlkICDBLZD2, PatientInfo["icd_blzd2"].ToString());
                this.ltxtBLZDName2.MyText = PatientInfo["blzd_name2"].ToString();
                this.AssignmentCJiaComboBox2(this.cboBloodType, PatientInfo["blood_type_name"].ToString());
                this.AssignmentRTLookUp( this.rtlkICDYNGR2,PatientInfo["icd_yngr2"].ToString());
                this.ltxtYNGRName2.MyText = PatientInfo["yngr_name2"].ToString();
                this.AssignmentCJiaComboBox2(this.cboOutPatientOutHospitalDia,PatientInfo["outpatient_out_dia_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboInOutHospitalDia, PatientInfo["in_out_hospital_dia_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboBeforeAfterSurDia, PatientInfo["begore_after_surgery_dia_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboRadAfterDia, PatientInfo["radiation_after_dia_name"].ToString());
                this.AssignmentCJiaComboBox2(this.cboClinicalPathDia,PatientInfo["clinical_pathology_dia_name"].ToString());
            }
            for(int i = 0; i < this.cJiaPanel2.Controls.Count; i++)
            {
                if(!(this.cJiaPanel2.Controls[i] is CJia.Controls.CJiaLabel))
                {
                    this.cJiaPanel2.Controls[i].Enabled = false;
                }
            }
        }


        private void AssignmentRTLookUp(CJia.Controls.CJiaRTLookUp crlu, string value)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Rows.Add(value, "0");
            crlu.DataSource = dt;
            crlu.DisplayField = "text";
            crlu.ValueField = "value";
            crlu.EditValue = value;
        }

        private void AssignmentCJiaComboBox2(CJia.Controls.CJiaComboBox2 Ccb, string value)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Rows.Add(value, "0");
            Ccb.Properties.DataSource = dt;
            Ccb.Properties.DisplayMember = "text";
            Ccb.Properties.ValueMember = "value";
            Ccb.EditValue = "0";
        }
    }
}
