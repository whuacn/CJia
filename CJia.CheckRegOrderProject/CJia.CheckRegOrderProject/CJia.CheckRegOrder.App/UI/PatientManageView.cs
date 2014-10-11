using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class PatientManageView : CJia.Editors.View
    {
        public PatientManageView()
        {
            InitializeComponent();
        }
        protected override object CreatePresenter()
        {
            return null;
        }
        #region  Tab控件操作
        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="name">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            System.Windows.Forms.TabPage page1 = new System.Windows.Forms.TabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            tabSecond.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            tabSecond.SelectedTab = page1;
        }
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        public bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < tabSecond.TabPages.Count; i++)
            {
                if (tabSecond.TabPages[i].Name == PageTitle)
                {
                    tabSecond.SelectedTab = tabSecond.TabPages[i];
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
        private void tabSecond_DoubleClick(object sender, EventArgs e)
        {
            if (tabSecond.SelectedTab != null)
            {
                int index = tabSecond.SelectedIndex;
                this.tabSecond.SelectedTab.Dispose();
                tabSecond.SelectedIndex = index - 1;
            }
        }
        #endregion

        private void btnSelectPatient_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if(!isExistPage(pageTitle))
            {
                UI.PatientSelectView psuc = new PatientSelectView();
                ShowPage(pageTitle, psuc);
            }
        }

        private void btnHistory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if (!isExistPage(pageTitle))
            {
                UI.PatientHistoryView phuc = new PatientHistoryView();
                ShowPage(pageTitle, phuc);
            }
        }

        private void btnRegNoCheck_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if (!isExistPage(pageTitle))
            {
                UI.RegNoCheckView rncuc = new RegNoCheckView();
                ShowPage(pageTitle, rncuc);
            }
        }

    }
}
