using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class QueryPatientView : CJia.Health.Tools.Page, Views.Web.IQueryPatientView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CJia.Health.Tools.Help.SystemInitConfig();//连接数据库
                if (OnInit != null)
                {
                    OnInit(null, null);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.QueryPatientPresenter(this);
        }
        /// <summary>
        /// 查询病案信息参数
        /// </summary>
        Views.Web.QueryPatientArgs queryPatientArgs = new Views.Web.QueryPatientArgs();

        #region IQueryPatientView成员
        public event EventHandler OnInit;
        public event EventHandler<Views.Web.QueryPatientArgs> OnProviceChanged;
        public event EventHandler<Views.Web.QueryPatientArgs> OnDeptChanged;
        public void ExeBind(DataTable icdData, DataTable zlData, DataTable dept, DataTable provice)
        {
            if (dept != null && dept.Rows.Count > 0)
            {
                DataRow dr = dept.NewRow();
                dr["DEPT_NAME"] = "全部";
                dr["DEPT_ID"] = "0";
                dept.Rows.InsertAt(dr, 0);
            }
            //BindICD(cbZLJG, zlData, "NAME", "CODE");
            BindICD(cbRYKS, dept, "DEPT_NAME", "DEPT_ID");
            BindICD(cbCYKS, dept, "DEPT_NAME", "DEPT_ID");
            //BindICD(cbSheng, provice, "AREA_NAME", "AREA_ID");
        }
        public void ExeBindCity(DataTable data)
        {
            //BindICD(cbShi, data, "AREA_NAME", "AREA_ID");
        }
        public void ExeBIndDoctor(DataTable data, int i)
        {
            if (i == 1)
            {
                //BindICD(cbRYYS, data, "DOCTOR_NAME", "DOCTOR_ID");
            }
            if (i == 2)
            {
                //BindICD(cbCYYS, data, "DOCTOR_NAME", "DOCTOR_ID");
            }
        }
        public event EventHandler<Views.Web.QueryPatientArgs> OnSelect;
        public void ExeBindSelectRecord(DataTable data)
        {
            if (data != null)
            {
                Session["PatientData"] = new DataTable();
                Session["PatientData"] = data;
                Session["Select"] = new MyPatient();
                Session["Select"] = GetUserSelect();
                Response.Redirect("PatientApplyView.aspx");
            }
            else
            {
                lblMsg.Text = "没有您要查询的结果!";
            }
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 选中旁边的checkbox启用控件
        /// </summary>
        /// <param name="ck"></param>
        /// <param name="control"></param>
        public void CheckedChanged(CheckBox ck, WebControl control)
        {
            if (ck.Checked)
            {
                control.Enabled = true;
            }
            else
            {
                control.Enabled = false;
            }
        }
        public void CheckedChangedReadyOnly(CheckBox ck, TextBox control)
        {
            if (ck.Checked)
            {
                control.ReadOnly = false;
            }
            else
            {
                control.ReadOnly = true;
            }
        }
        /// <summary>
        /// 绑定有关icd值得显示
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public void BindICD(DropDownList cb, DataTable data, string dataTextField, string dataValueField)
        {
            if (data != null)
            {
                cb.DataSource = data;
                cb.DataTextField = dataTextField;// "ICD10_NAME";
                cb.DataValueField = dataValueField;// "ICD10_CODE";
                cb.DataBind();
            }
        }
        /// <summary>
        /// 获得查询条件
        /// </summary>
        public MyPatient GetUserSelect()
        {
            MyPatient patient = new MyPatient();
            if (txtRecordNO.Text.Trim().Length > 0)//ckRecord.Checked && 
            {
                patient.RecordNO = txtRecordNO.Text.Trim();
            }
            //if (ckPatientID.Checked && txtPatientID.Text.Trim().Length > 0)
            //{
            //    patient.PatientID = txtPatientID.Text.Trim();
            //}
            if (startDate.Text.Trim().Length > 0 && endDate.Text.Trim().Length > 0)//ckDate.Checked && 
            {
                DateTime date = DateTime.Parse(startDate.Text.Trim());
                DateTime date1 = DateTime.Parse(endDate.Text.Trim());
                patient.StartDate = DateTime.Parse(date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString());
                patient.EndDate = DateTime.Parse(date1.Year.ToString() + "/" + date1.Month.ToString() + "/" + date1.Day.ToString());
            }
            if (CYZD.Text.Trim().Length > 0)//ckCYZD.Checked && 
            {
                patient.CYZD = CYZD.Text.Trim();
            }
            //if (ckYNGR.Checked && YNGR.Text.Trim().Length > 0)
            //{
            //    patient.YNGR = YNGR.Text.Trim();
            //}
            if (SSMC.Text.Trim().Length > 0)//ckSSMC.Checked && 
            {
                patient.SSMC = SSMC.Text.Trim();
            }
            //if (ckZLJG.Checked && cbZLJG.SelectedValue.Length > 0)
            //{
            //    patient.ZLJG = cbZLJG.SelectedValue;
            //}
            //if (ckBLZD.Checked && BLZD.Text.Trim().Length > 0)
            //{
            //    patient.BLZD = BLZD.Text.Trim();
            //}
            if (ckPatientName.Checked && txtPatientName.Text.Trim().Length > 0)
            {
                patient.PatientName = txtPatientName.Text.Trim();
            }
            //if (cbSheng.SelectedValue.Length > 0)//ckBirth.Checked && 
            //{
            //    patient.Provice = cbSheng.SelectedValue;
            //    if (cbShi.SelectedValue.Length > 0)
            //    {
            //        patient.City = cbShi.SelectedValue;
            //    }
            //}
            if (cbRYKS.SelectedValue.Length > 0 && cbRYKS.SelectedValue != "0")//ckRYDept.Checked && 
            {
                patient.RYDept = cbRYKS.SelectedValue;
            }
            //if (ckRYDoctor.Checked && cbRYYS.SelectedValue.Length > 0)
            //{
            //    patient.RYDoctor = cbRYYS.SelectedValue;
            //}
            if (cbCYKS.SelectedValue.Length > 0 && cbCYKS.SelectedValue != "0")//ckCYDept.Checked && 
            {
                patient.CYDept = cbCYKS.SelectedValue;
            }
            //if (ckCYDoctor.Checked && cbCYYS.SelectedValue.Length > 0)
            //{
            //    patient.CYDoctor = cbCYYS.SelectedValue;
            //}
            return patient;
        }
        #endregion

        protected void ckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDate.Checked)
            {
                startDate.Enabled = true;
                endDate.Enabled = true;
            }
            else
            {
                startDate.Enabled = false;
                endDate.Enabled = false;
            }
        }

        protected void ckRecord_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChangedReadyOnly(ckRecord, txtRecordNO);
        }

        protected void ckPatientID_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChangedReadyOnly(ckPatientID, txtPatientID);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChangedReadyOnly(ckCYZD, CYZD);
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChanged(ckZLJG, cbZLJG);
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChangedReadyOnly(ckSSMC, SSMC);
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChangedReadyOnly(ckYNGR, YNGR);
        }

        protected void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChangedReadyOnly(ckBLZD, BLZD);
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChangedReadyOnly(ckPatientName, txtPatientName);
        }

        protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckBirth.Checked)
            //{
            //    cbSheng.Enabled = true;
            //    cbShi.Enabled = true;
            //}
            //else
            //{
            //    cbSheng.Enabled = false;
            //    cbShi.Enabled = false;
            //}
        }

        protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(ckRYDept, cbRYKS);
        }

        protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChanged(ckRYDoctor, cbRYYS);
        }

        protected void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChanged(ckCYDept, cbCYKS);
        }

        protected void CheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            //CheckedChanged(ckCYDoctor, cbCYYS);
        }

        protected void cbSheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (OnProviceChanged != null)
            //{
            //    string procice = cbSheng.SelectedValue;
            //    queryPatientArgs.ProviceID = procice;
            //    OnProviceChanged(sender, queryPatientArgs);
            //}
        }

        protected void cbRYKS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnDeptChanged != null)
            {
                queryPatientArgs.DeptID = cbRYKS.SelectedValue;
                queryPatientArgs.i = 1;
                OnDeptChanged(sender, queryPatientArgs);
            }
        }

        protected void cbCYKS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnDeptChanged != null)
            {
                queryPatientArgs.DeptID = cbCYKS.SelectedValue;
                queryPatientArgs.i = 2;
                OnDeptChanged(sender, queryPatientArgs);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (OnSelect != null && Session["User"] != null)
            {
                queryPatientArgs.Patient = GetUserSelect();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                OnSelect(sender, queryPatientArgs);
            }
        }

        protected void btnResert_Click(object sender, EventArgs e)
        {
            txtRecordNO.Text = "";
            txtPatientName.Text = "";
            //txtPatientID.Text = "";
            startDate.Text = "";
            endDate.Text = "";
            CYZD.Text = "";
            SSMC.Text = "";
        }

    }
}