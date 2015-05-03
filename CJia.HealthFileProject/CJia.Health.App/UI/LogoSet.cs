using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class LogoSet : CJia.Health.Tools.View, CJia.Health.Views.ILogoSet
    {
        public LogoSet()
        {
            InitializeComponent();
            txtContent.Text = LogoName;
            txtDu.Text = LogoInclination.ToString();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.LogoSetPresenter(this);
        }
        LogoSetArgs logoSetArgs = new LogoSetArgs();
        public event EventHandler<LogoSetArgs> OnSave;
        public void ExeBindSuccess(bool bol)
        {
            if (bol)
                this.ParentForm.Close();
            else
                MessageBox.Show("保存失败！");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text.Trim();
            string du = txtDu.Text.Trim();
            if (content.Length > 0 && du.Length > 0)
            {
                try
                {
                    int i = int.Parse(du);
                    if (i >= 0 && i <= 360)
                    {
                        logoSetArgs.LogoContent = content;
                        logoSetArgs.Inclination = du;
                        if (OnSave != null)
                            OnSave(e, logoSetArgs);
                    }
                    else
                        MessageBox.Show("倾斜度输入有误！必须为0~360");
                }
                catch
                {
                    MessageBox.Show("倾斜度输入有误！必须为0~360");
                }
            }
            else
                MessageBox.Show("不能有空值！");
        }
        
    }
}
