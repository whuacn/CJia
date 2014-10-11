using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI.Label
{
    public partial class MessageBoxView : UserControl
    {
        public bool SelectValue = false;

        public MessageBoxView(string mes)
        {
            InitializeComponent();
            this.lblMessage.Text = "    " + mes;
        }

        private void cbYes_CheckedChanged(object sender, EventArgs e)
        {
            if(this.cbYes.Checked)
            {
                this.btnYes.Enabled = true;
            }
            else
            {
                this.btnYes.Enabled = false;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.SelectValue = true;
            this.FindForm().Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.SelectValue = false;
            this.FindForm().Close();
        }
    }
}
