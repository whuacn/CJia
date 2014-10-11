using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI
{
    public partial class PWJJInfoView : DevExpress.XtraEditors.XtraUserControl
    {
        public PWJJInfoView()
        {
            InitializeComponent();
        }
        public PWJJInfoView(string info)
        {
            InitializeComponent();
            txtPWJJ.Text = info;
        }
        #region 窗体事件
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

    }
}
