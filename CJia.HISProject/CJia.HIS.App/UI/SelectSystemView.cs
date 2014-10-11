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
                MessageBox.Show("请先选择系统！");
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


        #region ISelectSystemView 成员
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
        /// 选择系统事件
        /// </summary>
        public event EventHandler SelectSysEven;

        /// <summary>
        /// 绑定该用户可以访问的系统
        /// </summary>
        /// <param name="systems"></param>
        public void SetSystems(DataTable systems)
        {
            this.gctSelectSys.DataSource = systems;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="mess">要显示的信息</param>
        public void ShowMessage(string mess)
        {
            MessageBox.Show(mess);
        }

        /// <summary>
        /// 关闭所在窗体
        /// </summary>
        public void CloseFrom()
        {
            this.ParentForm.Close();
        }


        #endregion
    }
}
