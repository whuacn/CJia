using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.CheckRegOrder.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblUserName.Text = "【" + User.UserName + "】";
            lblLoginDateTime.Text = User.LoginDateTime;
        }

        #region  Tab控件操作
        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="name">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            tabMain.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            tabMain.SelectedTabPage = page1;
        }
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        public bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.TabPages[i].Name == PageTitle)
                {
                    tabMain.SelectedTabPage = tabMain.TabPages[i];
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 双击删除选中tabpage  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_DoubleClick(object sender, EventArgs e)
        {
            if (tabMain.SelectedTabPage != null)
            {
                int index = tabMain.SelectedTabPageIndex;
                this.tabMain.SelectedTabPage.Dispose();
                tabMain.SelectedTabPageIndex = index - 1;
            }
        }
        #endregion

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;//获得tabpage名称
            if (!isExistPage(pageTitle))
            {
                UI.RegisteView rguc = new UI.RegisteView();
                ShowPage(pageTitle, rguc);
            }
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!isExistPage(pageTitle))
            {
                UI.QueueView rguc = new UI.QueueView();
                ShowPage(pageTitle, rguc);
            }
        }

        private void btnPatientManage_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!isExistPage(pageTitle))
            {
                UI.PatientManageView pmuc = new UI.PatientManageView();
                ShowPage(pageTitle, pmuc);
            }
        }

        private void btnReportSelect_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!isExistPage(pageTitle))
            {
                UI.ReportView rpuc = new UI.ReportView();
                ShowPage(pageTitle, rpuc);
            }
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!isExistPage(pageTitle))
            {
                UI.UserManageView umuc = new UI.UserManageView();
                ShowPage(pageTitle, umuc);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Message.ShowQuery("你确定退出系统？", Message.Button.OkCancel) == Message.Result.Ok)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string pageTitle = "登记病人";
            if (!isExistPage(pageTitle))
            {
                UI.RegisteView rguc = new UI.RegisteView();
                ShowPage(pageTitle, rguc);
            }
        }

        private void btnQue_Click(object sender, EventArgs e)
        {
            string pageTitle = "队列管理";
            if (!isExistPage(pageTitle))
            {
                UI.QueueView rguc = new UI.QueueView();
                ShowPage(pageTitle, rguc);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string pageTitle = "查询报告";
            if (!isExistPage(pageTitle))
            {
                UI.ReportView rpuc = new UI.ReportView();
                ShowPage(pageTitle, rpuc);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserHandle uh = new UserHandle();
            uh.ShowDialog();
        }


    }
}
