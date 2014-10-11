using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class ReName : Form
    {
        /// <summary>
        /// 新页码
        /// </summary>
        public string PageNO = "";
        public ReName()
        {
            InitializeComponent();
        }

        private void cJiaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PageNO = txtStartPage.Text;
            this.Close();
        }
    }
}
