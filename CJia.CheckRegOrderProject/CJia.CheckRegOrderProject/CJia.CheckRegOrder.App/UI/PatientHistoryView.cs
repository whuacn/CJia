using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class PatientHistoryView : CJia.Editors.View, Views.IPatientHistoryView
    {
        public PatientHistoryView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PatientHistoryPresenter(this);
        }
        /// <summary>
        /// 病史管理设置参数
        /// </summary>
        Views.PatientHistoryArgs patientHistoryArgs = new Views.PatientHistoryArgs();

        #region IPatientHistoryView成员
        public string PatientNO
        {
            get { return txtPatientNO.Text.Trim(); }
            set { txtPatientNO.Text = value; }
        }
        public int? FocusPatientID
        {
            get
            {
                if (gvHistory.GetFocusedDataRow() != null)
                    return int.Parse(gvHistory.GetFocusedDataRow()["patient_id"].ToString());
                else return null;
            }
        }
        public string PatientName
        {
            get { return txtPatientName.Text.Trim(); }
            set { txtPatientName.Text = value; }
        }
        public string LblPatientName
        {
            set { gbHistory.Text = value; }
        }
        public DataTable PatientData { get; set; }
        /// <summary>
        /// 初潮年龄
        /// </summary>
        public string MensesFirstAge
        {
            get
            {
                if (numMensesFirstAge.Value != 0)
                {
                    return numMensesFirstAge.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numMensesFirstAge.Value = 0;
                }
                else
                {
                    numMensesFirstAge.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 平时月经周期
        /// </summary>
        public string Cycle
        {
            get
            {
                if (txtCycle.Text.Trim() == "") { return null; }
                else { return txtCycle.Text.Trim(); }
            }
            set
            {
                txtCycle.Text = value;
            }
        }
        /// <summary>
        /// 末次月经时间
        /// </summary>
        public DateTime? LastDate
        {
            get
            {
                if (dateLast.EditValue == null)
                {
                    return null;
                }
                else
                {
                    return DateTime.Parse(dateLast.EditValue.ToString());
                }
            }
            set
            {
                dateLast.EditValue = value;
            }
        }
        /// <summary>
        /// 绝经年龄
        /// </summary>
        public string LastAge
        {
            get
            {
                if (numLastAge.Value != 0)
                {
                    return numLastAge.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numLastAge.Value = 0;
                }
                else
                {
                    numLastAge.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 初产年龄
        /// </summary>
        public string PrimiparityAge
        {
            get
            {
                if (numPrimiparityAge.Value != 0)
                {
                    return numPrimiparityAge.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numPrimiparityAge.Value = 0;
                }
                else
                {
                    numPrimiparityAge.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 第一次性交年龄
        /// </summary>
        public string FirstSexAge
        {
            get
            {
                if (numFirstSexAge.Value != 0)
                {
                    return numFirstSexAge.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numFirstSexAge.Value = 0;
                }
                else
                {
                    numFirstSexAge.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 怀孕次数
        /// </summary>
        public string PregnancyNum
        {
            get
            {
                if (numPregnancy.Value != 0)
                {
                    return numPregnancy.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numPregnancy.Value = 0;
                }
                else
                {
                    numPregnancy.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 生育次数
        /// </summary>
        public string BirthNum
        {
            get
            {
                if (numBirth.Value != 0)
                {
                    return numBirth.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    numBirth.Value = 0;
                }
                else
                {
                    numBirth.Value = decimal.Parse(value);
                }
            }
        }
        /// <summary>
        /// 避孕方法
        /// </summary>
        public string Contraception
        {
            get
            {
                if (txtContraception.Text.Trim() == "")
                {
                    return null;
                }
                else
                {
                    return txtContraception.Text.Trim();
                }
            }
            set
            {
                txtContraception.Text = value;
            }
        }
        /// <summary>
        /// 有无哺乳
        /// </summary>
        public string Suckle
        {
            get
            {
                if (rgSuckle.EditValue == null)
                {
                    return null;
                }
                else
                {
                    return rgSuckle.EditValue.ToString();
                }
            }
            set
            {
                if (value == "1")
                {
                    rgSuckle.SelectedIndex = 0;
                }
                else if (value == "0")
                {
                    rgSuckle.SelectedIndex = 1;
                }
                else
                {
                    rgSuckle.SelectedIndex = -1;
                }
            }
        }
        /// <summary>
        /// 宫颈炎严重程度
        /// </summary>
        public string Severity
        {
            get
            {
                if (cbSeverity.Text != "<--请选择-->")
                {
                    return cbSeverity.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    cbSeverity.Text = "<--请选择-->";
                }
                else
                {
                    cbSeverity.Text = value;
                }
            }
        }
        /// <summary>
        /// 宫颈炎CIN
        /// </summary>
        public string CIN
        {
            get
            {
                if (cbCIN.Text != "<--请选择-->")
                {
                    return cbCIN.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    cbCIN.Text = "<--请选择-->";
                }
                else
                {
                    cbCIN.Text = value;
                }
            }
        }
        /// <summary>
        /// 宫颈瘤阶段
        /// </summary>
        public string Stage
        {
            get
            {
                if (cbStage.Text != "<--请选择-->")
                {
                    return cbStage.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    cbStage.Text = "<--请选择-->";
                }
                else
                {
                    cbStage.Text = value;
                }
            }
        }
        /// <summary>
        /// 宫颈治疗方法
        /// </summary>
        public string TreatWay
        {
            get
            {
                if (cbTreatWay.Text != "<--请选择-->")
                {
                    return cbTreatWay.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    cbTreatWay.Text = "<--请选择-->";
                }
                else
                {
                    cbTreatWay.Text = value;
                }
            }
        }
        /// <summary>
        /// 宫颈治疗时间
        /// </summary>
        public DateTime? TreatDate
        {
            get
            {
                if (dateTreat.EditValue == null)
                {
                    return null;
                }
                else
                {
                    return DateTime.Parse(dateTreat.EditValue.ToString());
                }
            }
            set
            {
                dateTreat.EditValue = value;
            }
        }
        /// <summary>
        /// 直系家属是否有肿瘤史
        /// </summary>
        public string TumourHistory
        {
            get
            {
                if (rgHistory.EditValue == null) { return null; }
                else { return rgHistory.EditValue.ToString(); }
            }
            set
            {
                if (value == "1")
                {
                    rgHistory.SelectedIndex = 0;
                }
                else if (value == "0")
                {
                    rgHistory.SelectedIndex = 1;
                }
                else
                {
                    rgHistory.SelectedIndex = -1;
                }
            }
        }
        /// <summary>
        /// 肿瘤部位
        /// </summary>
        public string TumourPart
        {
            get
            {
                if (txtTumourPart.Text.Trim() == "") { return null; }
                else { return txtTumourPart.Text.Trim(); }
            }
            set
            {
                txtTumourPart.Text = value;
            }
        }
        /// <summary>
        /// 自觉症状 白带数量
        /// </summary>
        public string LeucorrheaNum
        {
            get
            {
                if (cbLeucorrheaNum.Text != "<--请选择-->")
                {
                    return cbLeucorrheaNum.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == "")
                {
                    cbLeucorrheaNum.Text = "<--请选择-->";
                }
                else
                {
                    cbLeucorrheaNum.Text = value;
                }
            }
        }
        /// <summary>
        /// 自觉症状 是否溶血
        /// </summary>
        public string Hemolysis
        {
            get
            {
                if (rgHemolysis.EditValue == null) { return null; }
                else { return rgHemolysis.EditValue.ToString(); }
            }
            set
            {
                if (value == "1")
                {
                    rgHemolysis.SelectedIndex = 0;
                }
                else if (value == "0")
                {
                    rgHemolysis.SelectedIndex = 1;
                }
                else
                {
                    rgHemolysis.SelectedIndex = -1;
                }
            }
        }
        /// <summary>
        /// 自觉症状 是否腰酸
        /// </summary>
        public string Waist
        {
            get
            {
                if (rgWaist.EditValue == null) { return null; }
                else { return rgWaist.EditValue.ToString(); }
            }
            set
            {
                if (value == "1")
                {
                    rgWaist.SelectedIndex = 0;
                }
                else if (value == "0")
                {
                    rgWaist.SelectedIndex = 1;
                }
                else
                {
                    rgWaist.SelectedIndex = -1;
                }
            }
        }
        public event EventHandler Load;
        public event EventHandler<Views.PatientHistoryArgs> OnSelectByNO;
        public event EventHandler<Views.PatientHistoryArgs> OnSelectByName;
        public event EventHandler<Views.PatientHistoryArgs> OnSelect;
        public event EventHandler<Views.PatientHistoryArgs> OnGCClick;
        public event EventHandler<Views.PatientHistoryArgs> OnSave;
        public void Reset()
        {
            PatientData = null;
            LblPatientName = "";
            PatientNO = "";
            txtPatientNO.Focus();
            txtPatientNO.SelectAll();
            PatientName = "";
            MensesFirstAge = "0";
            Cycle = "";
            dateLast.EditValue = null;
            LastAge = "0";
            PrimiparityAge = "0";
            FirstSexAge = "0";
            PregnancyNum = "0";
            BirthNum = "0";
            Contraception = "";
            Suckle = null;
            Severity = "<--请选择-->";
            CIN = "<--请选择-->";
            Stage = "<--请选择-->";
            TreatWay = "<--请选择-->";
            dateTreat.EditValue = null;
            TumourHistory = null;
            TumourPart = "";
            LeucorrheaNum = "<--请选择-->";
            Hemolysis = null;
            Waist = null;
        }
        public void TxtPatientNOFocus()
        {
            PatientNO = PatientNO;
            txtPatientNO.Focus();
            txtPatientNO.SelectAll();
        }
        public void TxtPatientNameFocus()
        {
            PatientName = PatientName;
            txtPatientName.Focus();
            txtPatientName.SelectAll();
        }
        public void ExeBindHistory(DataTable data)
        {
            gcHistory.DataSource = data;
        }
        public void ExeBindComboBox(DataTable SeverityData, DataTable CINData, DataTable StageData, DataTable TreatData, DataTable LeucorrheaData)
        {
            DataRow dr = SeverityData.NewRow();
            dr["code_value"] = "<--请选择-->";
            SeverityData.Rows.InsertAt(dr, 0);
            DataRow dr1 = CINData.NewRow();
            dr1["code_value"] = "<--请选择-->";
            CINData.Rows.InsertAt(dr1, 0);
            DataRow dr2 = StageData.NewRow();
            dr2["code_value"] = "<--请选择-->";
            StageData.Rows.InsertAt(dr2, 0);
            DataRow dr3 = TreatData.NewRow();
            dr3["code_value"] = "<--请选择-->";
            TreatData.Rows.InsertAt(dr3, 0);
            DataRow dr4 = LeucorrheaData.NewRow();
            dr4["code_value"] = "<--请选择-->";
            LeucorrheaData.Rows.InsertAt(dr4, 0);
            cbSeverity.DataSource = SeverityData;
            cbSeverity.DisplayMember = "code_value";
            cbSeverity.ValueMember = "code_no";
            cbCIN.DataSource = CINData;
            cbCIN.DisplayMember = "code_value";
            cbCIN.ValueMember = "code_no";
            cbStage.DataSource = StageData;
            cbStage.DisplayMember = "code_value";
            cbStage.ValueMember = "code_no";
            cbTreatWay.DataSource = TreatData;
            cbTreatWay.DisplayMember = "code_value";
            cbTreatWay.ValueMember = "code_no";
            cbLeucorrheaNum.DataSource = LeucorrheaData;
            cbLeucorrheaNum.DisplayMember = "code_value";
            cbLeucorrheaNum.ValueMember = "code_no";
        }
        public void ExeBindEditHistory(DataTable data)
        {
            PatientData = data;
            LblPatientName = data.Rows[0]["patient_name"].ToString();
            MensesFirstAge = data.Rows[0]["menses_first_age"].ToString();
            Cycle = data.Rows[0]["menses_cycle"].ToString();
            if (data.Rows[0]["menses_last"].ToString() == "") { LastDate = null; }
            else { LastDate = DateTime.Parse(data.Rows[0]["menses_last"].ToString()); }
            LastAge = data.Rows[0]["menses_last_age"].ToString();
            FirstSexAge = data.Rows[0]["first_sex_age"].ToString();
            PrimiparityAge = data.Rows[0]["primiparity_age"].ToString();
            PregnancyNum = data.Rows[0]["pregnancy_num"].ToString();
            BirthNum = data.Rows[0]["birth_num"].ToString();
            Suckle = data.Rows[0]["suckle_state"].ToString();
            Contraception = data.Rows[0]["contraception_method"].ToString();
            Severity = data.Rows[0]["severity"].ToString();
            CIN = data.Rows[0]["cin"].ToString();
            Stage = data.Rows[0]["stage"].ToString();
            TreatWay = data.Rows[0]["treatWay"].ToString();
            if (data.Rows[0]["cervical_treat_date"].ToString() == "") { TreatDate = null; }
            else { TreatDate = DateTime.Parse(data.Rows[0]["cervical_treat_date"].ToString()); }
            TumourHistory = data.Rows[0]["is_tumour_history"].ToString();
            TumourPart = data.Rows[0]["tumour_part"].ToString();
            LeucorrheaNum = data.Rows[0]["leucorrhea"].ToString();
            Hemolysis = data.Rows[0]["is_hemolysis"].ToString();
            Waist = data.Rows[0]["is_waist_ache"].ToString();
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (PatientNO.Length != 0 || PatientName.Length != 0)
            {
                patientHistoryArgs.PatientNO = PatientNO;
                patientHistoryArgs.PatientName = PatientName;
                OnSelect(sender, patientHistoryArgs);
            }
            else
            {
                MessageBox.Show("请输入病人卡号或者姓名");
                TxtPatientNOFocus();
            }
        }
        private void txtPatientNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientNO)) return;
            patientHistoryArgs.PatientNO = PatientNO;
            if (OnSelectByNO != null) OnSelectByNO(sender, patientHistoryArgs);
        }
        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientNO)) return;
            patientHistoryArgs.PatientName = PatientName;
            if (OnSelectByName != null) OnSelectByName(sender, patientHistoryArgs);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void gcHistory_Click(object sender, EventArgs e)
        {
            if (FocusPatientID != null)
            {
                patientHistoryArgs.PatientID = FocusPatientID;
                OnGCClick(sender, patientHistoryArgs);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PatientData != null && PatientData.Rows.Count > 0)
            {
                if (Message.ShowQuery("确定保存病史吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    patientHistoryArgs.patientHistory = GetPatientHistory();
                    OnSave(sender, patientHistoryArgs);
                }
            }
        }

        #region 内部调用函数
        /// <summary>
        /// 根据数据绑定病史类
        /// </summary>
        /// <returns>病史类</returns>
        public PatientHistory GetPatientHistory()
        {
            PatientHistory ph = new PatientHistory();
            ph.PatientID = FocusPatientID;
            ph.MensesFirstAge = MensesFirstAge;
            ph.Cycle = Cycle;
            ph.LastDate = LastDate;
            ph.LastAge = LastAge;
            ph.FirstSexAge = FirstSexAge;
            ph.PrimiparityAge = PrimiparityAge;
            ph.PregnancyNum = PregnancyNum;
            ph.BirthNum = BirthNum;
            ph.Suckle = Suckle;
            ph.Contraception = Contraception;
            ph.Severity = Severity;
            ph.CIN = CIN;
            ph.Stage = Stage;
            ph.TreatWay = TreatWay;
            ph.TreatDate = TreatDate;
            ph.TumourHistory = TumourHistory;
            ph.TumourPart = TumourPart;
            ph.LeucorrheaNum = LeucorrheaNum;
            ph.Hemolysis = Hemolysis;
            ph.Waist = Waist;
            return ph;
        }
        /// <summary>
        /// 判断能否按Enter键执行
        /// </summary>
        /// <param name="e"></param>
        /// <param name="txt">输入框中值</param>
        /// <returns></returns>
        bool isRightKeyDown(KeyEventArgs e, string txt)
        {
            if (e.KeyValue != 13) return false;
            if (txt.Length == 0)
            {
                MessageBox.Show("不能为空");
                return false;
            }
            return true;
        }
        #endregion
    }
}
