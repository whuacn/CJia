using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Tools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Tab 控件操作
        private void ShowPage(string Title, Control ucPage)
        {
            TabPage xtraPage = new TabPage();
            xtraPage.Text = Title;
            xtraPage.Controls.Add(ucPage);
            ucPage.Dock = DockStyle.Fill;
            tabMain.TabPages.Add(xtraPage);
            tabMain.SelectedTab = xtraPage;
        }
        private bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.TabPages[i].Text == PageTitle)
                {
                    tabMain.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void btnNewEntity_Click(object sender, EventArgs e)
        {
            string Title = (sender as ToolStripButton).Text;
            if (!isExistPage(Title)) ShowPage(Title, new UI.NewEntityView());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string Title = (sender as ToolStripButton).Text;
            if(!this.isExistPage(Title))
                ShowPage(Title, new UI.CreatMvpView());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string Title = (sender as ToolStripButton).Text;
            if(!this.isExistPage(Title))
                ShowPage(Title, new UI.SyetemConfigView());
        }

    }
}
