using CJia.Health.Views.Web;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb.UI
{
    public partial class MyQuery : CJia.Health.Tools.Page, Views.Web.IQueryPatientView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
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
        protected override bool InitPage()
        {
            this.B_gr_Main = this.gr_Main;
            return true;
        }
        Views.Web.QueryPatientArgs queryPatientArgs = new Views.Web.QueryPatientArgs();
        #region IQueryPatientView成员
        public event EventHandler<QueryPatientArgs> OnApply;
        public void ExeBindPatient(DataTable data)
        {
            if (data != null)
            {
                InitGrid(data);
            }
        }
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
            BindDropDownDate(cbRYKS, dept, "DEPT_NAME", "DEPT_ID");
            BindDropDownDate(cbCYKS, dept, "DEPT_NAME", "DEPT_ID");
        }
        public void ExeBindCity(DataTable data)
        {

        }
        public void ExeBIndDoctor(DataTable data, int i)
        {

        }
        public event EventHandler<Views.Web.QueryPatientArgs> OnSelect;
        public void ExeBindSelectRecord(DataTable data)
        {
            if (data != null)
            {
                InitGrid(data);
            }
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 绑定有关icd值得显示
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public void BindDropDownDate(ExtAspNet.DropDownList cb, DataTable data, string dataTextField, string dataValueField)
        {
            if (data != null)
            {
                cb.DataSource = data;
                cb.DataTextField = dataTextField;
                cb.DataValueField = dataValueField;
                cb.DataBind();
            }
        }
        /// <summary>
        /// 获得查询条件
        /// </summary>
        public MyPatient GetUserSelect()
        {
            MyPatient patient = new MyPatient();
            if (txtRecordNO.Text.Trim().Length > 0)
            {
                patient.RecordNO = txtRecordNO.Text.Trim();
            }
            if (startDate.Text.Trim().Length > 0 && endDate.Text.Trim().Length > 0)
            {
                DateTime date = DateTime.Parse(startDate.Text.Trim());
                DateTime date1 = DateTime.Parse(endDate.Text.Trim());
                patient.StartDate = DateTime.Parse(date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString());
                patient.EndDate = DateTime.Parse(date1.Year.ToString() + "/" + date1.Month.ToString() + "/" + date1.Day.ToString());
            }
            if (CYZD.Text.Trim().Length > 0)
            {
                patient.CYZD = CYZD.Text.Trim();
            }
            if (SSMC.Text.Trim().Length > 0)
            {
                patient.SSMC = SSMC.Text.Trim();
            }
            if (txtPatientName.Text.Trim().Length > 0)
            {
                patient.PatientName = txtPatientName.Text.Trim();
            }
            if (cbRYKS.SelectedValue.Length > 0 && cbRYKS.SelectedValue != "0")
            {
                patient.RYDept = cbRYKS.SelectedValue;
            }
            if (cbCYKS.SelectedValue.Length > 0 && cbCYKS.SelectedValue != "0")
            {
                patient.CYDept = cbCYKS.SelectedValue;
            }
            return patient;
        }
        #endregion

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (OnSelect != null && Session["User"] != null)
            {
                B_gr_Main.PageIndex = 0;
                queryPatientArgs.Patient = GetUserSelect();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                OnSelect(sender, queryPatientArgs);
            }
        }

        protected void btnResert_Click(object sender, EventArgs e)
        {
            txtRecordNO.Text = "";
            txtPatientName.Text = "";
            startDate.Text = "";
            endDate.Text = "";
            CYZD.Text = "";
            SSMC.Text = "";
            cbCYKS.SelectedValue = "0";
            cbRYKS.SelectedValue = "0";
        }

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Info":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("PatientInfoView.aspx?ID=" + keys[0].ToString(), "基本信息"));
                    break;
                case "Favorite":
                    break;
                case "Apply":
                    win_Reson.Hidden = false;
                    break;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择病案！");
                return;
            }
            string[] ids = new string[this.gr_Main.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_Main.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_Main.DataKeys[this.gr_Main.SelectedRowIndexArray[i]][0].ToString();
            }
            string reson = txtReson.Text.Trim();
            if (reson.Length > 0 && reson.Length < 51)
            {
                win_Reson.Hidden = true;
                queryPatientArgs.HealthIDList = ids.ToList();
                queryPatientArgs.Patient = GetUserSelect();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                queryPatientArgs.Reason = reson;
                OnApply(null, queryPatientArgs);
            }
            else
                Alert.ShowInTop("请填写申请原因且长度不能超过50！");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择病案！");
                return;
            }
            win_Reson.Hidden = false;
        }

    }
}