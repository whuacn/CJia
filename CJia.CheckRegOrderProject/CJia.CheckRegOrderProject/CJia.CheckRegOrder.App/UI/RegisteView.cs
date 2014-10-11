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
    public partial class RegisteView : CJia.Editors.View, Views.IRegisteView
    {//CJia.Editors.View, Views.IRegisteView//
        public RegisteView()
        {
            InitializeComponent();
            Load(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.RegistePresenter(this);
        }
        /// <summary>
        /// 登记参数设置
        /// </summary>
        Views.RegisteArgs registeArgs = new Views.RegisteArgs();

        #region IRegisteView成员
        public string PatientNO
        {
            get
            {
                return txtPatientNO.Text.Trim();
            }
            set
            {
                txtPatientNO.Text = value;
            }
        }
        public string InvoiceNO
        {
            get
            {
                return txtInvoiceNO.Text.Trim();
            }
            set
            {
                txtInvoiceNO.Text = value;
            }
        }
        public DataTable PatientData
        {
            get;
            set;
        }
        public string AdmissionsType
        {
            get
            {
                return lblAdmissionsType.Text.Trim();
            }
            set
            {
                lblAdmissionsType.Text = value;
            }
        }
        public string PatientNOFocus
        {
            get
            {
                if (PatientData != null)
                {
                    return PatientData.Rows[0]["PATIENT_NO"].ToString();
                }
                else return null;
            }
        }
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
                numMensesFirstAge.Value = decimal.Parse(value);
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
                numLastAge.Value = decimal.Parse(value);
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
                numPrimiparityAge.Value = decimal.Parse(value);
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
                numFirstSexAge.Value = decimal.Parse(value);
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
                numPregnancy.Value = decimal.Parse(value);
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
                numBirth.Value = decimal.Parse(value);
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
                rgSuckle.EditValue = value;
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
                cbSeverity.Text = value;
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
                cbCIN.Text = value;
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
                cbStage.Text = value;
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
                cbTreatWay.Text = value;
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
                rgHistory.EditValue = value;
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
                cbLeucorrheaNum.Text = value;
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
                rgHemolysis.EditValue = value;
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
                rgWaist.EditValue = value;
            }
        }
        public event EventHandler<Views.RegisteArgs> OnSelectHIS;
        public event EventHandler<Views.RegisteArgs> OnClientRegiste;
        public event EventHandler<Views.RegisteArgs> OnCheckRegiste;
        public event EventHandler CancleQueue;
        public event EventHandler Load;
        public void ExeBindPatientInfo(DataTable data)
        {
            PatientData = data;
            gcPatientInfo.DataSource = data;
            gcInvoiceInfo.DataSource = data;
            string admissionsType = data.Rows[0]["DEPARTMENT_NAME"].ToString();
            if (admissionsType == "门诊挂号费")
            {
                AdmissionsType = "门诊病人";
            }
            else
            {
                AdmissionsType = "检查病人";
            }
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
        public void ExeReset()
        {
            gcPatientInfo.DataSource = null;
            gcInvoiceInfo.DataSource = null;
            AdmissionsType = "";
            PatientData = null;
            PatientNO = "";
            txtPatientNO.Focus();
            txtPatientNO.SelectAll();
            InvoiceNO = "";
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
        public void TxtInvoiceNOFocus()
        {
            InvoiceNO = InvoiceNO;
            txtInvoiceNO.Focus();
            txtInvoiceNO.SelectAll();
        }
        public void BtnClinicRegisterFocus()
        {
            btnClinicRegister.Focus();
        }
        public void BtnCheckRegFocus()
        {
            btnCheckReg.Focus();
        }
        public void NumMensesFirstAgeFocus()
        {
            numMensesFirstAge.Focus();
            numMensesFirstAge.Select(0, numMensesFirstAge.Value.ToString().Length);
        }
        #endregion

        private void btnSelectFromHIS_Click(object sender, EventArgs e)
        {
            if (!isExistPatient()) return;
            if (PatientNO.Length != 0 || InvoiceNO.Length != 0)
            {
                registeArgs.PatientNO = PatientNO;
                registeArgs.InvoiceNO = InvoiceNO;
                if (OnSelectHIS != null) OnSelectHIS(sender, registeArgs);
                TxtPatientNOFocus();
            }
            else
            {
                MessageBox.Show("请输入病人卡号或者发票编号");
            }
        }
        private void txtPatientNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientNO)) return;
            if (!isExistPatient()) return;
            registeArgs.PatientNO = PatientNO;
            if (OnSelectHIS != null) OnSelectHIS(sender, registeArgs);
            TxtPatientNOFocus();
        }
        private void txtInvoiceNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientNO)) return;
            if (!isExistPatient()) return;
            registeArgs.InvoiceNO = InvoiceNO;
            if (OnSelectHIS != null) OnSelectHIS(sender, registeArgs);
            TxtInvoiceNOFocus();
        }
        private void btnClinicRegister_Click(object sender, EventArgs e)
        {
            if (AdmissionsType.Length != 0 && AdmissionsType == "门诊病人")
            {
                registeArgs.PatientData = PatientData;
                registeArgs.AdmissionsType = AdmissionsType;
                registeArgs.PatientNOFocus = PatientNOFocus;
                if (OnClientRegiste != null) OnClientRegiste(sender, registeArgs);
                Load(null, null);
            }
            else
            {
                Message.Show("此病人为检查病人，请点击'检查登记'按钮");
                BtnCheckRegFocus();
            }
        }
        private void btnCheckReg_Click(object sender, EventArgs e)
        {
            if (AdmissionsType.Length != 0 && AdmissionsType == "检查病人")
            {
                if (Message.ShowQuery("是否已完成病史输入？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    registeArgs.PatientData = PatientData;
                    registeArgs.AdmissionsType = AdmissionsType;
                    registeArgs.PatientNOFocus = PatientNOFocus;
                    registeArgs.patientHistory = GetPatientHistory();
                    if (OnClientRegiste != null) OnCheckRegiste(sender, registeArgs);
                    Load(null, null);
                }
                else { NumMensesFirstAgeFocus(); }
            }
            else
            {
                Message.Show("此病人为门诊病人，请点击'门诊登记'按钮");
                BtnClinicRegisterFocus();
            }
        }
        private void btnCancelReg_Click(object sender, EventArgs e)
        {
            ExeReset();
        }
        private void gvQueue_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Caption == "诊室号")
            {
                if (e.CellValue.ToString() != "待定")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                else
                {

                }
            }
        }

        # region  排队 by zeng

        /// <summary>
        /// 当前选中正在排队病人ID
        /// </summary>
        public long PatientIdByQueue
        {
            get
            {
                if (gvQueue.GetFocusedDataRow() != null)
                {
                    return long.Parse(gvQueue.GetFocusedDataRow()["patient_id"].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 判断该选择病人是否有诊室号
        /// </summary>
        public string IsExistClinic
        {
            get
            {
                if (gvQueue.GetFocusedDataRow() != null)
                {
                    return gvQueue.GetFocusedDataRow()["clinic_name"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 排队列表双击选择诊室事件  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcQueue_DoubleClick(object sender, EventArgs e)
        {
            if (gvQueue.GetFocusedDataRow() != null)
            {
                DataRow dr = gvQueue.GetFocusedDataRow();
                Clinic clinicFrm = new Clinic(dr);
                clinicFrm.ShowDialog();
                Load(null, null);
            }
            else
            {
                MessageBox.Show("没有可编辑数据！");
            }
        }

        /// <summary>
        /// 查询结果不为空时绑定正在排队病人
        /// </summary>
        /// <param name="dtExistQueue">排队病人数据集</param>
        public void GetPatientByExistQueue(DataTable dtExistQueue)
        {
            DataTable newTable = dtExistQueue.Clone();
            newTable.Columns[3].DataType = typeof(string);
            for (int i = 0; i < dtExistQueue.Rows.Count; i++)
            {
                DataRow newRow = newTable.NewRow();
                for (int j = 0; j < dtExistQueue.Rows[i].ItemArray.Length; j++)
                {
                    if (j == 0)
                    {
                        if (dtExistQueue.Rows[i][j].ToString() == "")
                        {
                            newRow[j] = "待定";
                        }
                        else
                        {
                            newRow[j] = dtExistQueue.Rows[i][j].ToString();
                        }
                    }
                    else
                    {
                        newRow[j] = dtExistQueue.Rows[i][j];
                    }
                }
                newTable.Rows.Add(newRow);
            }
            this.gcQueue.DataSource = newTable;
        }

        /// <summary>
        /// 取消排队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancleQueue_Click(object sender, EventArgs e)
        {
            CancleQueue(sender, e);
            Load(null, null);
        }

        #endregion

        #region 内部调用函数
        /// <summary>
        /// 根据数据绑定病史类
        /// </summary>
        /// <returns>病史类</returns>
        public PatientHistory GetPatientHistory()
        {
            PatientHistory ph = new PatientHistory();
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
        /// <summary>
        /// 判断是否存在没保存的病人
        /// </summary>
        /// <returns></returns>
        bool isExistPatient()
        {
            if (PatientData == null) return true;
            else
            {
                string patientName = PatientData.Rows[0]["PATIENT_NAME"].ToString();
                if (Message.ShowQuery("病人【" + patientName + "】还未登记，是否放弃登记？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
