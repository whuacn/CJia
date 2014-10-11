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
    public partial class PharmSendDetailView : DevExpress.XtraEditors.XtraUserControl
    {
        public PharmSendDetailView()
        {
            InitializeComponent();
        }
        public PharmSendDetailView(DataTable data)
        {
            InitializeComponent();
            gcLable.DataSource = data;
            gvLabel.ExpandAllGroups();
        }
        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        public event EventHandler CloseForm;

        #region 窗体事件
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseForm != null)
                CloseForm(null, null);
        }
        #endregion
    }
}
