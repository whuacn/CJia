﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.Tools
{
    public partial class WinFrom : Form
    {
        private object _presenter;
        public WinFrom()
        {
            InitializeComponent();
            _presenter = this.CreatePresenter();
        }
        /// <summary>
        /// 常见Presenter虚方法
        /// </summary>
        /// <returns></returns>
        protected virtual object CreatePresenter()
        {
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} 必须重载 CreatePresenter 方法.", this.GetType().FullName));
            }
        }

        /// <summary>
        /// 显示弹框信息
        /// </summary>
        /// <param name="message">要显示的内容</param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// 界面抛出警告信息
        /// </summary>
        /// <param name="message"></param>
        public void ShowWarning(string message)
        {
            Message.ShowWarning(message);
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseWindow()
        {
            this.Close();
        }
        /// <summary>
        /// 以窗口形式显示
        /// </summary>
        /// <param name="Caption"></param>
        public void ShowAsWindow(string Caption)
        {
            ShowAsWindow(Caption, this);
        }
        /// <summary>
        /// 以窗口形式显示
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="UControl"></param>
        public void ShowAsWindow(string Caption, System.Windows.Forms.Form frm)
        {
            //System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
            //frmBase.Text = Caption;
            //frmBase.FormBorderStyle = FormBorvderStyle.FixedDialog;
            //frmBase.MaximizeBox = false;
            //frmBase.MinimizeBox = false;

            //frmBase.Size = new System.Drawing.Size(UControl.Width + 15, UControl.Height + 30);
            //frmBase.AutoSize = true;
            //frmBase.StartPosition = FormStartPosition.CenterScreen;
            //frmBase.KeyPreview = true;
            ////UControl.Dock = DockStyle.Fill;
            //frmBase.Controls.Add(UControl);
            ////UControl.Parent = frmBase;
            //UControl.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            //frmBase.ShowDialog();
        }
        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        public DateTime Sysdate
        {
            get
            {
                return DateTime.Parse(CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
            }
        }
    }
}