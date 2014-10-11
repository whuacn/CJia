using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Controls
{
    public partial class CJiaLineTextBox : DevExpress.XtraEditors.XtraUserControl
    {
        public string text = "";
        [Category("CJia属性"), Description("文本")]
        public string MyText
        {
            get { return text; }
            set
            {
                text = value;
                this.cJiaTextBox1.Text = value;
            }
        }

        public CJiaLineTextBox()
        {
            InitializeComponent();
        }

        private void CJiaLineTextBox_SizeChanged(object sender, EventArgs e)
        {
            this.cJiaTextBox1.Width = this.Width;
            this.cJiaLabel3.Width = this.Width;
        }

        private void cJiaTextBox1_TextChanged(object sender, EventArgs e)
        {
            text = this.cJiaTextBox1.Text;
        }

        private bool readOnly = false;
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("是否是只读")]
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                this.cJiaTextBox1.Properties.ReadOnly = value;
            }
        }
    }
}
