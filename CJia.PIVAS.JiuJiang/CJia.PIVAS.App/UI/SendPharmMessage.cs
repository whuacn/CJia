using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class SendPharmMessage : DevExpress.XtraEditors.XtraUserControl
    {
        public SendPharmMessage()
        {
            InitializeComponent();
        }
        public SendPharmMessage(DataTable data1,DataTable data2)
        {
            InitializeComponent();
            gcAdvice.DataSource = data1;
            gvAdvice.ExpandAllGroups();
            gcFalseAdvice.DataSource = data2;
            gvFalseAdvice.ExpandAllGroups();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

    }
}
