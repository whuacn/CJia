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
    public partial class PatientSelectView : CJia.Editors.View, Views.IPatientSelectView
    {
        public PatientSelectView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PatientSelectPresenter(this);
        }
        /// <summary>
        /// 参数设值
        /// </summary>
        Views.PatientSelectArgs patientSelectArgs = new Views.PatientSelectArgs();

        #region IPatientSelectView成员
        public string PatientNO
        {
            get { return txtPatientNO.Text.Trim(); }
            set { txtPatientNO.Text = value; }
        }
        public string PatientName
        {
            get { return txtPatientName.Text.Trim(); }
            set { txtPatientName.Text = value; }
        }
        public event EventHandler Load;
        public event EventHandler<Views.PatientSelectArgs> OnSelectByNO;
        public event EventHandler<Views.PatientSelectArgs> OnSelectByName;
        public event EventHandler<Views.PatientSelectArgs> OnSelect;
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
        public void ExeBindPatient(DataTable data)
        {
            gcPatient.DataSource = data;
        }
        #endregion

        private void txtPatientNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientNO)) return; 
            patientSelectArgs.PatientNO=PatientNO;
            OnSelectByNO(sender, patientSelectArgs);
        }
        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRightKeyDown(e, PatientName)) return;
            patientSelectArgs.PatientName = PatientName;
            OnSelectByName(sender, patientSelectArgs);
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (PatientNO.Length != 0 || PatientName.Length != 0)
            {
                patientSelectArgs.PatientNO = PatientNO;
                patientSelectArgs.PatientName = PatientName;
                OnSelect(sender, patientSelectArgs);
            }
            else
            {
                MessageBox.Show("请输入病人卡号或者姓名");
            }
        }
        /// <summary>
        /// 判断能否按Enter键执行
        /// </summary>
        /// <param name="e"></param>
        /// <param name="txt">输入框中值</param>
        /// <returns></returns>
        bool isRightKeyDown(KeyEventArgs e,string txt)
        {
            if (e.KeyValue != 13) return false;
            if (txt.Length == 0)
            {
                MessageBox.Show("不能为空");
                return false;
            }
            return true;
        }
    }
}
