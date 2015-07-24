using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SpeechLib;
using System.Drawing.Printing;

namespace CJia.PIVAS.App
{
    /// <summary>
    /// 程序主窗体
    /// </summary>
    public partial class MainForm : CJia.PIVAS.Tools.FromView, Views.IMainFromView
    {
        /// <summary>
        /// 是否注销
        /// </summary>
        public bool isLogOff = false;

        private bool isTimer = false;

        /// <summary>
        /// 程序主窗体构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            LblUserName.Text = User.UserName;
            LblLogTime.Text = User.LogTime.ToString();
            this.IimitsManagement();
            string labelSpec = (Common.GetLableSpec() == "1") ? "普通瓶贴版" : "静脉高营养";
            this.Text = this.Text + "【" + labelSpec + "】";
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MainFromPresenter(this);
        }

        #region 公共方法


        /// <summary>
        /// 系统类型控制
        /// </summary>
        public void IimitsManagement()
        {
            if (User.IsAdmin != "1")
            {
                this.TmsiDataManage.Visible = false;
                this.btnPharmEconomize.Visible = false;
                this.btnEconomizePharm.Visible = false;
            }
            else
            {
                this.TmsiDataManage.Visible = true;
                this.btnPharmEconomize.Visible = true;
                this.btnEconomizePharm.Visible = true;
            }
            if (User.role == "0")
            {
                this.btnCheckAdvice.Text = "修改医嘱批次";
                this.基本业务ToolStripMenuItem.Visible = false;
                this.综合查询ToolStripMenuItem.Visible = false;
                this.btnGenLabel.Visible = true;
                this.btnQueryLabel.Visible = false;
                this.btnPharmSend.Visible = false;
                this.btnCancelApplyHandle.Visible = false;
                this.btnPharmSendSelect.Visible = true;
                this.btnCancelRCP.Visible = false;
                this.toolStripBtnStorage.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
                this.toolStripSeparator3.Visible = false;
                this.toolStripSeparator4.Visible = false;
                this.toolStripSeparator5.Visible = false;
                this.toolStripSeparator6.Visible = false;
                this.toolStripSeparator7.Visible = false;
                this.toolStripSeparator8.Visible = false;
                this.btnLabelAgin.Visible = false;
                this.btnCancelApply.Visible = true;
                this.btnLabelAginin.Visible = false;
                this.瓶贴生成ToolStripMenuItem.Visible = false;
                this.btnGenLabel.Text = "频率批次维护";
                this.btnCancelLabel.Visible = true;
                this.btnEconomizePharm.Visible = false;
                this.btnPharmEconomize.Visible = false;
                this.btnNoPrintLabel.Visible = false;


                this.cbSpeak.Visible = false;
                this.btnCancelPreview.Visible = false;
                this.btnQueryExpition.Visible = false;
                this.btnQueryPharm.Visible = false;
            }
            else if (User.role == "2")
            {
                this.基本业务ToolStripMenuItem.Visible = false;
                this.综合查询ToolStripMenuItem.Visible = false;
                this.btnGenLabel.Visible = true;
                this.btnQueryLabel.Visible = false;
                this.btnPharmSend.Visible = false;
                this.btnCancelApplyHandle.Visible = false;
                this.btnPharmSendSelect.Visible = false;
                this.btnCancelRCP.Visible = false;
                this.toolStripBtnStorage.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
                this.toolStripSeparator3.Visible = false;
                this.toolStripSeparator4.Visible = false;
                this.toolStripSeparator5.Visible = false;
                this.toolStripSeparator6.Visible = false;
                this.toolStripSeparator7.Visible = false;
                this.toolStripSeparator8.Visible = false;
                this.btnLabelAgin.Visible = false;
                this.btnCancelApply.Visible = false;
                this.btnLabelAginin.Visible = false;
                this.瓶贴生成ToolStripMenuItem.Visible = true;
                this.btnCancelLabel.Visible = false;
                this.btnEconomizePharm.Visible = false;
                this.btnPharmEconomize.Visible = false;
                this.btnNoPrintLabel.Visible = false;

                //this.isTimer = true;
                //this.cbSpeak.Visible = true;
                //this.btnCancelPreview.Visible = true;
                //this.btnQueryExpition.Visible = true;
                //this.btnQueryPharm.Visible = true;
                //this.btnNoPrintLabel.Visible = true;
                //this.btnTimer.Location = new Point(this.cbSpeak.Location.X - 25, this.btnTimer.Location.Y);
                //this.btnTimer.Text = "》";
                this.btnTimer.Visible = false;

                this.btnCancelApply.Visible = false;
                timer.Enabled = true;
                this.timer_Tick(null, null);
                timerSpeak.Enabled = true;
                this.timerSpeak_Tick(null, null);
            }
            else
            {
                this.btnCancelApply.Visible = false;
                timer.Enabled = true;
                this.timer_Tick(null, null);
                timerSpeak.Enabled = true;
                this.timerSpeak_Tick(null, null);
            }
        }


        /// <summary>
        ///根据标题在tabpage中显示出页面
        ///增加新按钮需 1.在该方法的switch中加一个case，case后面的字符为按钮的text属性值
        ///case中new出你要显示的用户控件
        ///2.并且按钮的单击事件绑定到 menubutton_click 方法上
        /// </summary>
        /// <param name="pageTitle">button的text属性字段</param>
        private void MenuShowPage(string pageTitle)
        {
            if (!isExistPage(pageTitle))
            {
                UserControl uc = null;
                switch (pageTitle)
                {
                    case "单组冲药":
                        uc = new UI.SendPharm();
                        break;
                    case "批次维护":
                        uc = new UI.DataManage.BatchToRedDrugView();
                        break;
                    case "退药申请":
                        uc = new UI.CancelLabelView();
                        break;
                    case "退药查询":
                        uc = new UI.NewCancelRCPView();
                        break;
                    case "瓶贴查询":
                        uc = new UI.SendPharmSelect();
                        break;
                    case "药师审方":
                        uc = new UI.CheckAdviceView();
                        break;
                    case "修改医嘱批次":
                        uc = new UI.CheckAdviceView();
                        break;
                    case "瓶贴生成":
                        uc = new UI.Label.QueryPrintLabellView();
                        break;
                    //case "瓶贴查询":
                    //    uc = new UI.Label.QueryLabelView();
                    //    break;
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
                        uc = new UI.NewCancelApplyView();
                        break;
                    case "药品库存查询":
                        uc = new UI.StorageQueryView();
                        break;
                    case "瓶贴重打":
                        uc = new UI.Label.LabelAgainPrintView();
                        break;
                    case "日常用药":
                        uc = new UI.PharmEconomizeView();
                        //uc = new UI.PharmEconomizeUI();
                        break;
                    case "扫描监控":
                        uc = new UI.ScanningMonitoringView();
                        break;
                    case "未校验医嘱":
                        uc = new UI.ErrorView();
                        break;
                    default:
                        break;
                }
                if (uc != null)
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


        /// <summary>
        /// 朗读语音提示信息
        /// </summary>
        /// <param name="text"></param>
        private void SpeakMessage(string text)
        {
            try
            {
                SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                SpVoice Voice = new SpVoice();
                Voice.Rate = 2;
                Voice.Speak(text, SpFlags);
            }
            catch
            {

            }
        }

        #endregion

        #region 界面绑定事件


        private void tsbScanningMonitoring_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.App.UI.ScanningMonitoringForm scanningMonitoringForm = new UI.ScanningMonitoringForm();
            scanningMonitoringForm.ShowDialog();
        }

        /// <summary>
        /// 是否开启自动检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimer_Click(object sender, EventArgs e)
        {
            this.isTimer = !this.isTimer;
            if (this.isTimer)
            {
                this.cbSpeak.Visible = true;
                this.btnCancelPreview.Visible = true;
                this.btnQueryExpition.Visible = true;
                this.btnQueryPharm.Visible = true;
                this.btnNoPrintLabel.Visible = true;
                this.btnTimer.Location = new Point(this.cbSpeak.Location.X - 25, this.btnTimer.Location.Y);
                this.btnTimer.Text = "》";
            }
            else
            {
                this.cbSpeak.Visible = false;
                this.btnCancelPreview.Visible = false;
                this.btnQueryExpition.Visible = false;
                this.btnQueryPharm.Visible = false;
                this.btnNoPrintLabel.Visible = false;
                this.btnTimer.Location = new Point(this.btnNoPrintLabel.Location.X + (this.btnNoPrintLabel.Width - this.btnTimer.Width), this.btnTimer.Location.Y);
                this.btnTimer.Text = "《";
            }

        }

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

                    this.isLogOff = true;
                    this.FindForm().Close();
                }
            }
            else
            {
                return;
            }
        }

        //定时监测
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.isTimer)
            {
                this.timer.Stop();
                CJia.PIVAS.Views.MainFromEventArgs mainFromEventArgs = new Views.MainFromEventArgs();
                this.OnQueryNoCheckAdvice(null, mainFromEventArgs);
                this.OnQueryExceptionLabel(null, mainFromEventArgs);
                this.OnQueryStorage(null, mainFromEventArgs);
                this.OnQueryNoPrintLabel(null, mainFromEventArgs);
                this.timer.Start();
            }
        }

        //语音提示
        private void timerSpeak_Tick(object sender, EventArgs e)
        {
            if (this.isTimer)
            {
                if (this.cbSpeak.Checked)
                {
                    if (this.IsNoCheck)
                    {
                        this.SpeakMessage("有未审核的医嘱");
                    }
                    if (this.IsExceptionLabel)
                    {
                        this.SpeakMessage("有异常瓶贴");
                    }
                    if (this.IsSorage)
                    {
                        this.SpeakMessage("有药品库存不足");
                    }
                    if (this.IsNoPrintLabel)
                    {
                        this.SpeakMessage("有未打印的瓶贴");
                    }
                }
            }
        }

        //有未审核的医嘱按钮单机事件
        private void btnCancelPreview_Click(object sender, EventArgs e)
        {
            string pageTitle = "药师审方";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        private DataTable NoPrintLabel;
        // 瓶贴生成按钮单击事件
        private void btnNoPrintLabel_Click(object sender, EventArgs e)
        {
            //string pageTitle = "瓶贴生成";//获得tabpage名称
            //this.MenuShowPage(pageTitle);
            CJia.PIVAS.App.UI.NoPrintLabel noPrintLabel = new UI.NoPrintLabel(this.NoPrintLabel);
            frmBase.Dispose();
            frmBase = new System.Windows.Forms.Form();
            frmBase.Text = "未打印的瓶贴";
            //frmBase.MaximizeBox = false;
            //frmBase.MinimizeBox = false;
            frmBase.Size = new System.Drawing.Size(noPrintLabel.Width + 15, noPrintLabel.Height + 30);
            //frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(noPrintLabel);
            //UControl.Parent = frmBase;
            noPrintLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            //frmBase.TopMost = true;
            frmBase.Show();
        }

        System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
        //异常瓶贴按钮单击事件
        private void btnQueryExpition_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.App.UI.ExceptionLabel exceptionLabel = new UI.ExceptionLabel(this.ExceptionLabel);
            frmBase.Dispose();
            frmBase = new System.Windows.Forms.Form();
            frmBase.Text = "停止或未通过审核的医嘱对应的已打印的瓶贴";
            //frmBase.MaximizeBox = false;
            //frmBase.MinimizeBox = false;
            frmBase.Size = new System.Drawing.Size(exceptionLabel.Width + 15, exceptionLabel.Height + 30);
            //frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(exceptionLabel);
            //UControl.Parent = frmBase;
            exceptionLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            //frmBase.TopMost = true;
            frmBase.Show();
        }

        private void btnQueryPharm_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.App.UI.StorageLabel storageLabel = new UI.StorageLabel(this.PharmStorage);
            frmBase.Dispose();
            frmBase = new System.Windows.Forms.Form();
            frmBase.Text = "库存不足药品";
            //frmBase.MaximizeBox = false;
            //frmBase.MinimizeBox = false;
            frmBase.Size = new System.Drawing.Size(storageLabel.Width + 15, storageLabel.Height + 30);
            //frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(storageLabel);
            //UControl.Parent = frmBase;
            storageLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            //frmBase.TopMost = true;
            frmBase.Show();
        }

        #endregion


        #region IMainFromView 成员

        //查询是否有未审核的医嘱
        public event EventHandler<Views.MainFromEventArgs> OnQueryNoCheckAdvice;

        //监测异常瓶贴
        public event EventHandler<Views.MainFromEventArgs> OnQueryExceptionLabel;

        //查询库存
        public event EventHandler<Views.MainFromEventArgs> OnQueryStorage;

        public event EventHandler<Views.MainFromEventArgs> OnQueryNoPrintLabel;


        private bool IsNoPrintLabel = false;
        //public void ExeQueryNoPrintLabel(int result)
        //{
        //    if(result > 0)
        //    {
        //        this.btnNoPrintLabel.ForeColor = Color.Red;
        //        this.btnNoPrintLabel.Text = "有" + result + "张未打印瓶贴";
        //        this.IsNoPrintLabel = true;
        //    }
        //    else
        //    {
        //        this.btnNoPrintLabel.ForeColor = Color.Black;
        //        this.btnNoPrintLabel.Text = "无未打印瓶贴";
        //        this.IsNoPrintLabel = false;
        //    }
        //}

        private DataTable ExceptionLabel;
        private bool IsExceptionLabel = false;

        //监测未打印瓶贴回调方法
        public void ExeQueryNoPrintLabel(DataTable result)
        {
            if (result.Rows.Count > 0)
            {
                this.btnNoPrintLabel.ForeColor = Color.Red;
                this.btnNoPrintLabel.Text = "有未打印瓶贴";
                this.IsNoPrintLabel = true;
                this.NoPrintLabel = result;
            }
            else
            {
                this.btnNoPrintLabel.ForeColor = Color.Black;
                this.btnNoPrintLabel.Text = "无未打印瓶贴";
                this.IsNoPrintLabel = false;
                this.NoPrintLabel = null;
            }
        }

        //监测异常瓶贴回调方法
        public void ExeQueryExceptionLabel(DataTable result)
        {
            if (result != null && result.Rows != null && result.Rows.Count != 0)
            {
                this.btnQueryExpition.ForeColor = Color.Red;
                this.btnQueryExpition.Text = "有异常瓶贴";
                this.IsExceptionLabel = true;
                this.ExceptionLabel = result;
            }
            else
            {
                this.btnQueryExpition.ForeColor = Color.Black;
                this.btnQueryExpition.Text = "无异常瓶贴";
                this.IsExceptionLabel = false;
                this.ExceptionLabel = null;
            }
        }

        //药品库存
        private DataTable PharmStorage;
        //是否有库存不足
        private bool IsSorage = false;
        public void ExeQueryStorage(DataTable result)
        {
            if (result != null && result.Rows != null && result.Rows.Count != 0)
            {
                this.btnQueryPharm.ForeColor = Color.Red;
                this.btnQueryPharm.Text = "有药品库存不足";
                this.IsSorage = true;
                this.PharmStorage = result;
            }
            else
            {
                this.btnQueryPharm.ForeColor = Color.Black;
                this.btnQueryPharm.Text = "无药品库存不足";
                this.IsSorage = false;
                this.PharmStorage = null;
            }
        }

        private bool IsNoCheck = false;
        //回调方法
        public void ExeQueryNoCheckAdvice(bool result)
        {
            if (result)
            {
                this.btnCancelPreview.ForeColor = Color.Red;
                this.btnCancelPreview.Text = "有未审核的医嘱";
                this.IsNoCheck = true;
            }
            else
            {
                this.btnCancelPreview.ForeColor = Color.Black;
                this.btnCancelPreview.Text = "无未审核的医嘱";
                this.IsNoCheck = false;
            }
        }

        #endregion

        private void btnError_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }



    }
}