using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App
{
    /// <summary>
    /// 程序主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 程序主窗体构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            LblUserName.Text = User.UserName;
            LblLogTime.Text = User.LogTime.ToString();
        }

        #region 公共方法

        
        /// <summary>
        ///根据标题在tabpage中显示出页面
        ///增加新按钮需 1.在该方法的switch中加一个case，case后面的字符为按钮的text属性值
        ///case中new出你要显示的用户控件
        ///2.并且按钮的单击事件绑定到 menubutton_click 方法上
        /// </summary>
        /// <param name="pageTitle">button的text属性字段</param>
        private void MenuShowPage(string pageTitle)
        {
            if(!isExistPage(pageTitle))
            {
                UserControl uc = null;
                switch(pageTitle)
                {
                    case "冲药":
                        uc = new UI.PharmSendView();
                        break;
                    case "退药申请":
                        uc = new UI.CancelApplyView();
                        break;
                    case "退药查询":
                        uc = new UI.CancelRCPView();
                        break;
                    case "冲药查询":
                        uc = new UI.PharmSendSelectView();
                        break;
                    case "药师审方":
                        uc = new UI.CheckAdviceView();
                        break;
                    case "瓶贴生成":
                        uc = new UI.Label.GenLabelView();
                        break;
                    case "瓶贴查询":
                        uc = new UI.Label.QueryLabelView();
                        break;
                    case "瓶贴扫描":
                        uc = new UI.Label.LabelScanning();
                        break;
                    case "发药统计查询":
                        uc = new UI.PharmSendStatSelectView();
                        break;
                    case "拉单维护":
                        uc = new UI.DataManage.RedDrugView(1);
                        break;
                    case "冲药维护":
                        uc = new UI.DataManage.RedDrugView(2);
                        break;
                    case "静脉药物批次维护":
                        uc = new UI.DataManage.BatchToRedDrugView();
                        break;
                    case "频率批次维护":
                        uc = new UI.DataManage.FrequencyToBatchView();
                        break;
                    case "用法给药途径维护":
                        uc = new UI.DataManage.DeptUsageView();
                        break;
                    case "用户维护":
                        uc = new UI.DataManage.UserView();
                        break;
                    case "退药处理":
                        uc = new UI.CancelApplyView();
                        break;
                    default:
                        break;
                }
                if(uc != null)
                {
                    ShowPage(pageTitle, uc);
                }
            }
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

        #endregion

        #region 界面绑定事件

        //所有在tabpage中显示页面的按钮单击事件
        private void MenuButton_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 修改个人信息
        private void TmsiUpdateMessage_Click(object sender, EventArgs e)
        {
            UI.DataManage.EditUserView editUser = new UI.DataManage.EditUserView(User.UserName);
            CJia.PIVAS.Common.ShowAsWindow("修改密码", editUser);
        }

        // 退出系统
        private void TmsiQuit_Click(object sender, EventArgs e)
        {
            if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认退出系统", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        // 注销
        private void TmsiLogOut_Click(object sender, EventArgs e)
        {
            if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认注销", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
            {
                Form frm = new Form();
                frm.Text = "登录";
                frm.Width = 410;
                frm.Height = 270;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.StartPosition = FormStartPosition.CenterScreen;
                UI.LoginView loginView = new UI.LoginView();
                frm.Controls.Add(loginView);
                loginView.Dock = DockStyle.Fill;
                frm.ShowDialog();
                if (User.isLoginSuccess)
                {
                    while (tabMain.TabPages.Count > 0)
                    {
                        tabMain.TabPages[0].Dispose();
                    }
                    LblUserName.Text = User.UserName;
                    LblLogTime.Text = User.LogTime.ToString();
                }
            }
            else
            {
                return;
            }
        }

        #endregion

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(this.tabMain.SelectedTabPage.Controls.Count > 0)
            {
                this.tabMain.SelectedTabPage.Controls[0].Focus();
            }
        }

        private void tabMain_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {

        }


    }
}
