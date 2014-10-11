using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace CJia.HIS.Clinic.Register.UI
{
    public partial class RegisterView : CJia.HIS.View, Views.IRegisterView
    {
        CJia.HIS.Controls.SelectGridControl txtCardTypeSelectGrid;
        CJia.HIS.Controls.SelectGridControl txtClinicTypeSelectGrid;
        CJia.HIS.Controls.SelectGridControl txtRegisterTypeSelectGrid;
        public RegisterView()
        {
            InitializeComponent();
            this.Init();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void Init()
        {
            txtCardTypeSelectGrid = new CJia.HIS.Controls.SelectGridControl(this.txtCardType,true);
            txtClinicTypeSelectGrid = new CJia.HIS.Controls.SelectGridControl(this.txtClinicType);
            txtRegisterTypeSelectGrid = new CJia.HIS.Controls.SelectGridControl(this.txtRegisterType);
            this.Controls.Add(txtCardTypeSelectGrid);
            this.Controls.Add(txtClinicTypeSelectGrid);
            this.Controls.Add(txtRegisterTypeSelectGrid);
        }



        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        protected override object CreatePresenter()
        {
            return new Presenters.RegisterPresenter(this);
        }



        private void btnSelectCardId_Click(object sender, EventArgs e)
        {
        }

        private void txtCardType_GotFocus(object sender, EventArgs e)
        {
            this.GetTxtCardTypeEvent(this.txtCardType.Text.ToUpper());
        }

        #region IRegisterView 成员

        public event Delegate.NoResOnePar GetTxtCardTypeEvent;

        public void resCardType( DataTable cardTypes)
        {
            this.txtCardTypeSelectGrid.DataSource = cardTypes;
        }

        #endregion
    }
}
