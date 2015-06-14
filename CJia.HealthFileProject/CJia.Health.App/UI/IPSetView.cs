﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;
using System.Text.RegularExpressions;

namespace CJia.Health.App.UI
{
    public partial class IPSetView : CJia.Health.Tools.View, CJia.Health.Views.IIPSetView
    {
        public IPSetView()
        {
            InitializeComponent();
            InitView();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.IPSetViewPresenter(this);
        }

        private void InitView()
        {
            txtIP.Text = string.Empty;
            OnInitView(null, null);
            chkAll_CheckedChanged(null, null);
        }

        Views.IPSetViewArgs args = new Views.IPSetViewArgs();

        #region IIPSetView
        public event EventHandler<IPSetViewArgs> OnAdd;
        public event EventHandler<IPSetViewArgs> OnDelete;
        public event EventHandler<IPSetViewArgs> OnInitView;
        public void ExeBindData(DataTable data)
        {
            ckIP.DataSource = data;
            ckIP.DisplayMember = "IP";
            ckIP.ValueMember = "ID";
            ckIP.UnCheckAll();
        }
        public void ExeIsDelete(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("删除成功");
                InitView();
            }
            else
                MessageBox.Show("删除失败");
        }
        public void ExeIsAdd(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("添加成功");
                InitView();
            }
            else
                MessageBox.Show("添加失败或者已存在");
        }
        #endregion

        private void IPSetView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlIp.Width) / 2;
            pnlIp.Location = new Point(location, 9);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ckIP.CheckedIndices.Count > 0)
            {
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    List<string> ipList = new List<string>();
                    for (int i = 0; i < ckIP.CheckedIndices.Count; i++)
                    {
                        string ip = ckIP.GetItemValue(ckIP.CheckedIndices[i]).ToString();
                        ipList.Add(ip);
                    }
                    args.IPList = ipList;
                    OnDelete(null, args);
                }
            }
            else
            {
                Message.Show("请勾选IP地址，可多选");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            if (ip.Length > 0)
            {
                List<string> ipList = new List<string>();
                if (IsIPAddress(ip))
                {
                    ipList.Add(ip);
                    args.IPList = ipList;
                    OnAdd(null, args);
                }
                else if (IsIPAddressAll(ip))
                {
                    string tip = ip.Split('*')[0];
                    for (int i = 1; i < 255; i++)
                    {
                        ipList.Add(tip + i.ToString());
                    }
                    args.IPList = ipList;
                    OnAdd(null, args);
                }
                else if (IsIPAddressFrom(ip))
                {
                    string[] sip = ip.Split('-')[0].Split('.');
                    string[] eip = ip.Split('-')[1].Split('.');
                    if (sip[0] == eip[0] && sip[1] == eip[1] && sip[2] == eip[2])
                    {
                        int si=int.Parse(sip[3]);
                        int ei=int.Parse(eip[3]);
                        if (si <= ei)
                        {
                            for (int i = si; i <= ei; i++)
                            {
                                ipList.Add(sip[0] + "." + sip[1] + "." + sip[2] + "." + i);
                            }
                            args.IPList = ipList;
                            OnAdd(null, args);
                            return;
                        }
                    }
                    MessageBox.Show("IP地址输入格式不对");
                }
                else
                {
                    MessageBox.Show("IP地址输入格式不对");
                }
            }
            else
                MessageBox.Show("请输入IP地址");
        }
        /// <summary>
        /// 判断是否是Ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            if (string.IsNullOrEmpty(ip) || ip.Length < 7 || ip.Length > 15) return false;
            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(ip);
        }
        public static bool IsIPAddressAll(string ip)
        {
            if (string.IsNullOrEmpty(ip) || ip.Length < 7 || ip.Length > 13) return false;
            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.\*$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(ip);
        }
        public static bool IsIPAddressFrom(string ip)
        {
            if (string.IsNullOrEmpty(ip) || ip.Length < 15 || ip.Length > 31) return false;
            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\-(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(ip);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                ckIP.CheckAll();
            else
                ckIP.UnCheckAll();
        }
    }
}
