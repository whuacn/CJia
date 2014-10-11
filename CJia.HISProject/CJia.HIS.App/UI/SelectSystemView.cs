using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.HIS.App.UI
{
    public partial class SelectSystemView : CJia.HIS.View,Views.ISelectSystemView
    {
        
        public SelectSystemView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectSystemPresenter(this);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = this.gvwSelectSys.GetFocusedDataRow();
            this.SelectedSys = selectedRow;
            if(this.selectedSys == null)
            {
                MessageBox.Show("����ѡ��ϵͳ��");
            }
            else
            {
                this.SelectSysEven(sender, e);
                this.ParentForm.Close();
            }
        }

        private void btnCentel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        #region ISelectSystemView ��Ա
        public DataRow selectedSys;
        public DataRow SelectedSys
        {
            get
            {
                return selectedSys;
            }
            set
            {
                selectedSys = value;
            }
        }

        /// <summary>
        /// ѡ��ϵͳ�¼�
        /// </summary>
        public event EventHandler SelectSysEven;

        /// <summary>
        /// �󶨸��û����Է��ʵ�ϵͳ
        /// </summary>
        /// <param name="systems"></param>
        public void SetSystems(DataTable systems)
        {
            this.gctSelectSys.DataSource = systems;
        }

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        /// <param name="mess">Ҫ��ʾ����Ϣ</param>
        public void ShowMessage(string mess)
        {
            MessageBox.Show(mess);
        }

        /// <summary>
        /// �ر����ڴ���
        /// </summary>
        public void CloseFrom()
        {
            this.ParentForm.Close();
        }


        #endregion
    }
}
