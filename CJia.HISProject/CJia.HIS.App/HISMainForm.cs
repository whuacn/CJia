using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.HIS.App
{
    public partial class HISMainForm : DevExpress.XtraEditors.XtraForm
    {
        public UserControl NowContainer;


        public HISMainForm()
        {
            InitializeComponent();
            CJia.HIS.SystemInfo.ChangeLoginStateEven += SystemInfo_ChangeLoginStateEven;
            CJia.HIS.SystemInfo.ChangeUserEven += SystemInfo_ChangeUserEven;
            ShowNewContainer();
        }

        //是否登录信息发生更改事件绑定方法
        void SystemInfo_ChangeUserEven(object sender, EventArgs e)
        {
            if(CJia.HIS.SystemInfo.IsLoginSucceed )
            {
                ShowNewContainer();
            }
            else
            {
                CJia.HIS.App.Tools.ShowForm.ShowLogin();
            }
        }

        // 系统信息发生更改事件绑定方法
        void SystemInfo_ChangeLoginStateEven(object sender, EventArgs e)
        {
            ShowNewContainer();
        }

        // 将系统容器根据系统信息刷新一遍
        private void ShowNewContainer()
        {
            this.Controls.Clear();
            this.NowContainer = CJia.HIS.App.Tools.ShowForm.CreaterContainer();
            this.Size = this.NowContainer.Size;
            this.Controls.Add(this.NowContainer);
            this.Name = CJia.HIS.SystemInfo.loginSystem["SYSTEM_NAME"].ToString();
        }

        // 关闭窗体前发生
        private void HISMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("您确定要退出系统吗？", "提示确定退出系统", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }


        //// 键盘单击事件
        //public void MainContainerView_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string downKey = "";
        //    if(e.Alt)
        //    {
        //        downKey += "ALT";
        //    }
        //    if(e.Control)
        //    {
        //        downKey += "CTRL";
        //    }
        //    if(e.Shift)
        //    {
        //        downKey += "SHIFT";
        //    }
        //    downKey += "+" + e.KeyData.ToString();
        //    if(this.ShortcutKeyDic[downKey] is System.Windows.Forms.ToolStripButton)
        //    {
        //        System.Windows.Forms.ToolStripButton toolStripButton = this.ShortcutKeyDic["downKey"] as System.Windows.Forms.ToolStripButton;
        //        if(toolStripButton.Tag.ToString() != "")
        //        {
        //            this.ModuleId = toolStripButton.Tag.ToString();
        //            this.MenuClickEven(sender, e);
        //        }
        //    }
        //}

    }
}