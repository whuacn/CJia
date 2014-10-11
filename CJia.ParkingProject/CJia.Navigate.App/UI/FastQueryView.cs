﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Navigate.App.UI
{
    public partial class FastQueryView : CJia.Parking.Tools.View, CJia.Parking.Views.Navigate.IFastQueryView
    {
        int textBoxIndex = 1;

        DevExpress.XtraTab.XtraTabControl xtra;

        DataTable dtPic;

        CJia.Parking.Views.Navigate.FastQueryArgs fastQueryArgs = new Parking.Views.Navigate.FastQueryArgs();

        public FastQueryView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new CJia.Parking.Presenters.Navigate.FastQueryPresenter(this);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = sender as DevExpress.XtraEditors.SimpleButton;
            switch (textBoxIndex)
            {
                case 1:
                    textBox1.Text = btn.Text;
                    textBoxIndex++;
                    break;
                case 2:
                    textBox2.Text = btn.Text;
                    textBoxIndex++;
                    break;
                case 3:
                    textBox3.Text = btn.Text;
                    textBoxIndex++;
                    break;
                case 4:
                    textBox4.Text = btn.Text;
                    textBoxIndex++;
                    break;
                case 5:
                    textBox5.Text = btn.Text;
                    textBoxIndex = 5;
                    break;
                default:
                    break;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("查询信息不能为空!");
                return;
            }
            fastQueryArgs.Fast1 = textBox1.Text;
            fastQueryArgs.Fast2 = textBox2.Text;
            fastQueryArgs.Fast3 = textBox3.Text;
            fastQueryArgs.Fast4 = textBox4.Text;
            fastQueryArgs.Fast5 = textBox5.Text;
            OnFastQuery(null, fastQueryArgs);

            xtra = this.Parent.Parent.Parent.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
            if (!this.isExistPage("照片查看"))
            {
                string Queryfactor = fastQueryArgs.Fast1 + fastQueryArgs.Fast2 + fastQueryArgs.Fast3 + fastQueryArgs.Fast4 + fastQueryArgs.Fast5;
                List<object> QueryList = new List<object>() { fastQueryArgs.Fast1, fastQueryArgs.Fast2, fastQueryArgs.Fast3, fastQueryArgs.Fast4, fastQueryArgs.Fast5 };
                CarPhotosView carphotos = new CarPhotosView(dtPic, 1, Queryfactor, QueryList);
                this.ShowPage("照片查看", carphotos);
            }
            else
            {
                for (int i = 0; i < xtra.TabPages.Count; i++)
                {
                    if (xtra.TabPages[i].Name == "照片查看")
                    {
                        xtra.TabPages.Remove(xtra.TabPages[i]);
                        string Queryfactor = fastQueryArgs.Fast1 + fastQueryArgs.Fast2 + fastQueryArgs.Fast3 + fastQueryArgs.Fast4 + fastQueryArgs.Fast5;
                        List<object> QueryList = new List<object>() { fastQueryArgs.Fast1, fastQueryArgs.Fast2, fastQueryArgs.Fast3, fastQueryArgs.Fast4, fastQueryArgs.Fast5 };
                        CarPhotosView carphotos = new CarPhotosView(dtPic, 1, Queryfactor, QueryList);
                        this.ShowPage("照片查看", carphotos);
                        break;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (textBoxIndex == 5 && textBox5.Text != "")
            {
                textBox5.Text = "";
            }
            else if (textBoxIndex == 5 && textBox5.Text == "")
            {
                textBox4.Text = "";
                textBoxIndex = 4;
            }
            else if (textBoxIndex == 4 && textBox4.Text != "")
            {
                textBox4.Text = "";
            }
            else if (textBoxIndex == 4 && textBox4.Text == "")
            {
                textBox3.Text = "";
                textBoxIndex = 3;
            }
            else if (textBoxIndex == 3 && textBox3.Text != "")
            {
                textBox3.Text = "";
            }
            else if (textBoxIndex == 3 && textBox3.Text == "")
            {
                textBox2.Text = "";
                textBoxIndex = 2;
            }
            else if (textBoxIndex == 2 && textBox2.Text != "")
            {
                textBox2.Text = "";
            }
            else if (textBoxIndex == 2 && textBox2.Text == "")
            {
                textBox1.Text = "";
                textBoxIndex = 1;
            }
            else if (textBoxIndex == 1 && textBox1.Text != "")
            {
                textBox1.Text = "";
                textBoxIndex = 1;
            }
            else
            {
                textBoxIndex = 1;
            }
        }

        #region 【页面代码】
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        private bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < xtra.TabPages.Count; i++)
            {
                if (xtra.TabPages[i].Name == PageTitle)
                {
                    xtra.SelectedTabPage = xtra.TabPages[i];
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
            xtra.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            xtra.SelectedTabPage = page1;
        }
        #endregion

        #region【接口实现】
        public event EventHandler<Parking.Views.Navigate.FastQueryArgs> OnFastQuery;

        public void ExeShowPic(DataTable dt)
        {
            dtPic = dt;
        }
        #endregion

        private void FastQueryView_SizeChanged(object sender, EventArgs e)
        {
            int parentWidth = this.Width;
            int parentHeight = this.Height;
            int width = panel1.Width;
            int height = panel1.Height;
            panel1.Location = new Point((parentWidth - width) / 2, (parentHeight - height) / 2);
        }

        
    }
}
