using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Navigate.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //xtraTabControl1.Width = this.Width + 7;
            //xtraTabControl1.Height = this.Height + 7;
            lblPcName.Text = CJia.Parking.Tools.ConfigHelper.GetAppStrings("StartFloor") + " 层 " + CJia.Parking.Tools.ConfigHelper.GetAppStrings("StartNo");
            string str = "查询";
            if (!this.isExistPage(str))
            {
                UI.QueryView query = new UI.QueryView();
                this.ShowPage(str, query);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss");
        }

        private void picHome_MouseDown(object sender, MouseEventArgs e)
        {
            picHome.Image = global::CJia.Navigate.App.Properties.Resources._4;
        }

        private void picHome_MouseUp(object sender, MouseEventArgs e)
        {
            picHome.Image = global::CJia.Navigate.App.Properties.Resources._5;
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            //{
            //    if (xtraTabControl1.TabPages[i].Name == "查询")
            //    {
            //        xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
            //    }
            //}
            DevExpress.XtraTab.XtraTabControl tabcon = xtraTabControl1;
            //.TabPages[0].Controls.Find("xtraTabControl1", true)[0] as DevExpress.XtraTab.XtraTabControl;
            //for (int i = 0; i < tabcon.TabPages.Count; i++)
            //{
            //    if (tabcon.TabPages[i].Name == "HomePage")
            //    {
            //        tabcon.SelectedTabPage = tabcon.TabPages[i];
            //        break;
            //    }
                
            //}
            for (int i = 0; i < tabcon.TabPages.Count; i++)
            {
                if (tabcon.TabPages[i].Name == "查询")
                {
                    tabcon.SelectedTabPage = tabcon.TabPages[i];
                    DevExpress.XtraEditors.SimpleButton btnFastQuery = tabcon.TabPages[i].Controls.Find("btnFastQuery", true)[0] as DevExpress.XtraEditors.SimpleButton;
                    DevExpress.XtraEditors.SimpleButton btnLicenceQuery = tabcon.TabPages[i].Controls.Find("btnLicenceQuery", true)[0] as DevExpress.XtraEditors.SimpleButton;
                    DevExpress.XtraEditors.SimpleButton btnDateQuery = tabcon.TabPages[i].Controls.Find("btnDateQuery", true)[0] as DevExpress.XtraEditors.SimpleButton;
                    DevExpress.XtraEditors.SimpleButton btnStallQuery = tabcon.TabPages[i].Controls.Find("btnStallQuery", true)[0] as DevExpress.XtraEditors.SimpleButton;
                    int btnWidth = btnFastQuery.Width <= btnLicenceQuery.Width ? btnFastQuery.Width : btnLicenceQuery.Width;
                    btnFastQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    btnLicenceQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    btnDateQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    btnStallQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    btnFastQuery.Width = btnLicenceQuery.Width = btnDateQuery.Width = btnStallQuery .Width = btnWidth;
                    DevExpress.XtraTab.XtraTabControl con = tabcon.TabPages[i].Controls.Find("xtraTabControl1", true)[0] as DevExpress.XtraTab.XtraTabControl;
                    for (int j = 0; j < con.TabPages.Count; j++)
                    {
                        if (con.TabPages[j].Name == "HomePage")
                        {
                            con.SelectedTabPage = con.TabPages[j];
                        }
                    }
                }
                if (tabcon.TabPages[i].Name == "照片查看")
                {
                    tabcon.TabPages.Remove(tabcon.TabPages[i]);
                }
            }
        }


        private void picReturn_MouseDown(object sender, MouseEventArgs e)
        {
            picReturn.Image = global::CJia.Navigate.App.Properties.Resources.b;
        }

        private void picReturn_MouseUp(object sender, MouseEventArgs e)
        {
            picReturn.Image = global::CJia.Navigate.App.Properties.Resources.a;
        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "导航")
            {
                for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                {
                    if (xtraTabControl1.TabPages[i].Name == "照片查看")
                    {
                        xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                        return;
                    }
                }
            }
            if (xtraTabControl1.SelectedTabPage.Name == "照片查看")
            {
                for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                {
                    if (xtraTabControl1.TabPages[i].Name == "查询")
                    {
                        xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                        return;
                    }
                }
            }
            if (xtraTabControl1.SelectedTabPage.Name == "查询")
            {
                picHome_Click(null, null);
                return;
                //DevExpress.XtraTab.XtraTabControl con = xtraTabControl1.Controls.Find("xtraTabControl1", true)[0] as DevExpress.XtraTab.XtraTabControl;
                //for (int i = 0; i < con.TabPages.Count; i++)
                //{
                //    if (con.TabPages[i].Name == "HomePage")
                //    {
                //        con.SelectedTabPage = con.TabPages[i];
                //        return;
                //    }
                //}
            }


        }
    }
}
