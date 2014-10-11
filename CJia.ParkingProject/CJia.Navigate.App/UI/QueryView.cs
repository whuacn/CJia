using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Navigate.App.UI
{
    public partial class QueryView : UserControl
    {
        //记录进入那个查询页面
        string str;
        int buttonWith = 0;
        DevExpress.XtraTab.XtraTabControl xtra;
        public QueryView()
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            buttonWith = btnLicenceQuery.Width;
        }

        private void btnFastQuery_Click(object sender, EventArgs e)
        {
            str = btnFastQuery.Text;
            ChangeBackColor(btnFastQuery.Name, btnLicenceQuery.Name, btnDateQuery.Name, btnStallQuery.Name);
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Name == str)
                {
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.TabPages[i]);
                }
            }
            if (!this.isExistPage(str))
            {
                UI.FastQueryView fastQuery = new FastQueryView();
                this.ShowPage(str, fastQuery);
            }
        }

        private void btnStallQuery_Click(object sender, EventArgs e)
        {
            str = btnStallQuery.Text;
            ChangeBackColor(btnStallQuery.Name, btnFastQuery.Name, btnLicenceQuery.Name, btnDateQuery.Name);
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Name == str)
                {
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.TabPages[i]);
                }
            }
            if (!this.isExistPage(str))
            {
                UI.ParkingQueryView queryParking = new ParkingQueryView();
                this.ShowPage(str, queryParking);
            }
        }

        private void btnLicenceQUuery_Click(object sender, EventArgs e)
        {
            str = btnLicenceQuery.Text;
            ChangeBackColor(btnLicenceQuery.Name, btnStallQuery.Name, btnFastQuery.Name, btnDateQuery.Name);
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Name == str)
                {
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.TabPages[i]);
                }
            }
            if (!this.isExistPage(str))
            {
                UI.LicenceQueryView licenceQuery = new LicenceQueryView();
                this.ShowPage(str, licenceQuery);
            }
        }

        private void btnDateQueyr_Click(object sender, EventArgs e)
        {
            str = btnDateQuery.Text;
            ChangeBackColor(btnDateQuery.Name, btnLicenceQuery.Name, btnStallQuery.Name, btnFastQuery.Name);
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Name == str)
                {
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.TabPages[i]);
                }
            }
            if (!this.isExistPage(str))
            {
                UI.TimeQueryView timeQuery = new TimeQueryView();
                this.ShowPage(str, timeQuery);
            }
        }

        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        private bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Name == PageTitle)
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="pageTitle">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            page1.AutoScroll = true;
            xtraTabControl1.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            xtraTabControl1.SelectedTabPage = page1;
        }

        private void ChangeBackColor(string btnName1,string btnName2,string btnName3,string btnName4)
        {
            Control.ControlCollection cons = panelControl1.Controls;
            for (int i = 0; i < cons.Count; i++)
            {
                if (cons[i].GetType() == typeof(DevExpress.XtraEditors.SimpleButton) && cons[i].Name==btnName1)
                {
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).Appearance.BackColor = Color.FromArgb(235, 236, 239);
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).Width = buttonWith + 15;
                    xtraTabControl1.Focus();
                }
                if (cons[i].GetType() == typeof(DevExpress.XtraEditors.SimpleButton) && (cons[i].Name == btnName2 || cons[i].Name == btnName3 || cons[i].Name == btnName4))
                {
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).Width = buttonWith;
                }
            }
        }

        private void HomePage_SizeChanged(object sender, EventArgs e)
        {
            int homePageWidth = HomePage.Width;
            int homePageHeight = HomePage.Height;
            int width = panel1.Width;
            int height = panel1.Height;
            panel1.Location = new Point((homePageWidth - width) / 2, (homePageHeight - height) / 2);
        }
    }
}
