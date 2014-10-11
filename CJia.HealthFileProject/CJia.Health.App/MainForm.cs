using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwainLib;

namespace CJia.Health.App
{
    public partial class MainForm : CJia.Health.Tools.Form1, CJia.Health.Views.IMainFormView
    {
        Health.Views.MainFormArgs mainFormArgs = new Views.MainFormArgs();
        public MainForm()
        {
            InitializeComponent();
            Init();
            OnInitFunction(null, mainFormArgs);
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MainFormPresenter(this);
        }

        public void Init()
        {
            lblLoginTime.Text = User.LoginTime.ToString();
            lblUserName.Text = User.UserData.Rows[0]["USER_NAME"].ToString();
        }

        private void btnInfoInput_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.NewPatientInfoInPutView pat = new UI.NewPatientInfoInPutView();
                cJiaTabControl1.ShowPage(pageTitle, pat);
            }
        }

        private void btnImagesInput_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                string isAUTO = CJia.Health.Tools.ConfigHelper.GetAppStrings("AUTO");
                if (isAUTO == "0")
                {
                    UI.NewPictureInputView image = new UI.NewPictureInputView();
                    cJiaTabControl1.ShowPage(pageTitle, image);
                }
                else
                {
                    UI.PhotoView image = new UI.PhotoView();
                    cJiaTabControl1.ShowPage(pageTitle, image);
                }
            }
        }

        private void btnDataCheck_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.NewImageCheckView data = new UI.NewImageCheckView();
                //UI.DataCheckView data = new UI.DataCheckView();
                cJiaTabControl1.ShowPage(pageTitle, data);
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ProjectManageView project = new UI.ProjectManageView();
                cJiaTabControl1.ShowPage(pageTitle, project);
            }
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DeptManageView dept = new UI.DeptManageView();
                cJiaTabControl1.ShowPage(pageTitle, dept);
            }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DoctorManageView doctor = new UI.DoctorManageView();
                cJiaTabControl1.ShowPage(pageTitle, doctor);
            }
        }

        // 用户维护
        private void btnUser_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.UserManageView user = new UI.UserManageView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }

        // 权限维护
        private void btnRole_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.RoleManageView user = new UI.RoleManageView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }

        // 权限功能维护
        private void btnRoleFounction_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.RoleFunctionView user = new UI.RoleFunctionView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }
        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ApprovalBorrowView borrow = new UI.ApprovalBorrowView();
                cJiaTabControl1.ShowPage(pageTitle, borrow);
            }
        }

        private void btnBorrowTime_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.BorrowTimeLenthView borrow = new UI.BorrowTimeLenthView();
                cJiaTabControl1.ShowPage(pageTitle, borrow);
            }
        }

        //注销
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (CJia.Health.Tools.Message.ShowQuery("是否确认注销", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
            {
                if (CJia.Health.Tools.Help.SystemInitConfig())
                {
                    UI.LoginView login = new UI.LoginView();
                    CJia.Health.Tools.Help.NewNoBorderForm(login);
                    if (User.IsLoginSuccess)
                    {
                        if (this.Controls != null)
                        {
                            for (int i = 0; i < this.Controls.Count; i++)
                            {
                                this.Controls[i].Dispose();
                            }
                        }
                        this.Controls.Clear();
                        this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
                        InitializeComponent();
                        
                        while (cJiaTabControl1.TabPages.Count > 0)
                        {
                            cJiaTabControl1.TabPages[0].Dispose();
                        }
                        Init();
                        mainFormArgs.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
                        OnInitFunction(null, mainFormArgs);
                    }
                }
            }

        }

        //退出
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            Form frmBase = new Form();
            frmBase.Text = "修改密码";
            frmBase.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmBase.MaximizeBox = false;
            frmBase.MinimizeBox = false;
            UI.ChangePwdView changePwd = new UI.ChangePwdView();
            frmBase.Size = new System.Drawing.Size(changePwd.Width + 15, changePwd.Height + 30);
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //frmBase.AutoSize = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(changePwd);
            //UControl.Parent = frmBase;
            changePwd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            frmBase.ShowDialog();
        }

        private void FunctionManage(DataTable dtFunction)
        {
            if (dtFunction != null && dtFunction.Rows != null && dtFunction.Rows.Count > 0)
            {
                for (int i = 0; i < dtFunction.Rows.Count; i++)
                {
                    switch (dtFunction.Rows[i]["FUNCTION_ID"].ToString())
                    {
                        case "1000000104":              //首页录入
                            this.btnInfoInput.Visible = false;
                            this.btnSelectScanner.Visible = false;
                            this.btnInfoInput1.Visible = false;
                            this.toolStripSeparator1.Visible = false;
                            break;
                        case "1000000103":              //数据审核
                            this.btnDataCheck.Visible = false;
                            this.btnToolDataCheck.Visible = false;
                            this.toolStripSeparator3.Visible = false;
                            break;
                        case "1000000105":              //借阅批准
                            this.BtnBorrow.Visible = false;
                            this.BtnBorrow1.Visible = false;
                            break;
                        case "1000000125":              //用户维护
                            this.btnUser.Visible = false;
                            this.btnUser1.Visible = false;
                            break;
                        case "1000000126":              //权限维护
                            this.btnRole.Visible = false;
                            this.btnRole1.Visible = false;
                            break;
                        case "1000000127":              //功能角色维护
                            this.btnRoleFounction.Visible = false;
                            this.btnRoleFounction1.Visible = false;
                            break;
                        case "1000000141":              //起始页
                            this.btnHomePage.Visible = false;
                            this.btnFirst.Visible = false;
                            this.toolStripSeparator5.Visible = false;
                            break;
                        case "1000000123":              //字典维护
                            this.btnDicManage.Visible = false;
                            this.btnDicManage1.Visible = false;
                            break;
                        case "1000000161":              //图片采集
                            this.btnImagesInput.Visible = false;
                            this.btnImagesInput1.Visible = false;
                            this.toolStripSeparator4.Visible = false;
                            break;
                        case "1000000162":
                            this.btnProSet.Visible = false;     //图片分类
                            this.btnProSet1.Visible = false;
                            this.toolStripSeparator6.Visible = false;
                            break;
                        case "1000000163":                  // 档案查询
                            this.btnDataQuery.Visible = false;
                            this.btnDataQuery1.Visible = false;
                            this.toolStripSeparator3.Visible = false;
                            break;
                        case "1000000181":      //档案打印
                            this.btnPrintApply.Visible=false;
                            break;
                        case "1000000201":      //图片扫描
                            this.toolStripButton1.Visible = false;
                            toolStripSeparator7.Visible = false;
                            图片扫描ToolStripMenuItem.Visible = false;
                            break;
                        case "1000000203":      //图片合并
                            toolStripButton2.Visible = false;
                            toolStripSeparator6.Visible = false;
                            图片合并ToolStripMenuItem.Visible = false;
                            break;
                        default: break;
                    }
                }
            }
        }



        #region【实现接口】
        public event EventHandler<Views.MainFormArgs> OnInitFunction;

        public void ExeInitFunction(DataTable dt)
        {
            FunctionManage(dt);
        }
        #endregion
        private void btnFirst_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyPatientHandelView uc = new UI.MyPatientHandelView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyPatientHandelView uc = new UI.MyPatientHandelView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnDataQuery_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DataQueryView uc = new UI.DataQueryView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnToolDataCheck_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DataCheckView uc = new UI.DataCheckView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnToolDataQuery_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DataQueryView uc = new UI.DataQueryView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnPicInfoInput_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ImagesInputView image = new UI.ImagesInputView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void btnProSet_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.PictureProjectSetView image = new UI.PictureProjectSetView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void btnPrintApply_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.PrintApplyView image = new UI.PrintApplyView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        #region Scan扫描仪选择
        bool msgfilter;
        int PicNumber = 0;
        string MyProductName = "扫描程序";
        private void btnSelectScanner_Click(object sender, EventArgs e)
        {
            Tw.Select();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Message.ShowQuery("确定退出此系统吗？", Message.Button.OkCancel) == Message.Result.Ok)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ScanView image = new UI.ScanView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripItem).Text;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MergeView image = new UI.MergeView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

      
    }
}
