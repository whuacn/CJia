﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using TwainLib;

namespace CJia.Health.App
{
    public partial class NewMainForm : CJia.Health.Tools.Form1, CJia.Health.Views.IMainFormView
    {
        Health.Views.MainFormArgs mainFormArgs = new Views.MainFormArgs();
        public NewMainForm()
        {
            InitializeComponent();
            Init();
            OnInitFunction(null, mainFormArgs);
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            this.Text = this.Text + " " + CJia.Health.Tools.ConfigHelper.GetAppStrings("Version");
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

        private void btnInfoInput_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.NewPatientInfoInPutView pat = new UI.NewPatientInfoInPutView();
                cJiaTabControl1.ShowPage(pageTitle, pat);
            }
        }

        private void btnImagesInput_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                string isAUTO = CJia.Health.Tools.ConfigHelper.GetAppStrings("AUTO");
                string isGZ = CJia.Health.Tools.ConfigHelper.GetAppStrings("isGZ");
                if (isAUTO == "0")
                {
                    UI.NewPictureInputView image = new UI.NewPictureInputView();
                    cJiaTabControl1.ShowPage(pageTitle, image);
                }
                else
                {
                    if (isGZ == "1")
                    {
                        UI.PhotoNewView image = new UI.PhotoNewView();
                        cJiaTabControl1.ShowPage(pageTitle, image);
                    }
                    else
                    {
                        UI.PhotoView image = new UI.PhotoView();
                        cJiaTabControl1.ShowPage(pageTitle, image);
                    }
                }
            }
        }

        private void btnDataCheck_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.NewImageCheckView data = new UI.NewImageCheckView();
                //UI.DataCheckView data = new UI.DataCheckView();
                cJiaTabControl1.ShowPage(pageTitle, data);
            }
        }

        private void btnProject_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ProjectManageView project = new UI.ProjectManageView();
                cJiaTabControl1.ShowPage(pageTitle, project);
            }
        }

        private void btnDept_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DeptManageView dept = new UI.DeptManageView();
                cJiaTabControl1.ShowPage(pageTitle, dept);
            }
        }

        private void btnDoctor_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DoctorManageView doctor = new UI.DoctorManageView();
                cJiaTabControl1.ShowPage(pageTitle, doctor);
            }
        }

        // 用户维护
        private void btnUser_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.UserManageView user = new UI.UserManageView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }

        // 权限维护
        private void btnRole_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.RoleManageView user = new UI.RoleManageView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }

        // 权限功能维护
        private void btnRoleFounction_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.RoleFunctionView user = new UI.RoleFunctionView();
                cJiaTabControl1.ShowPage(pageTitle, user);
            }
        }
        private void BtnBorrow_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ApprovalBorrowView borrow = new UI.ApprovalBorrowView();
                cJiaTabControl1.ShowPage(pageTitle, borrow);
            }
        }

        private void btnBorrowTime_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;//获得tabpage名称
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.BorrowTimeLenthView borrow = new UI.BorrowTimeLenthView();
                cJiaTabControl1.ShowPage(pageTitle, borrow);
            }
        }

        //注销
        private void btnCancle_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

                        Tw = new Twain(MyProductName);
                        Tw.Init(this.Handle);
                        this.Text = this.Text + " " + CJia.Health.Tools.ConfigHelper.GetAppStrings("Version");
                        Application.DoEvents();
                    }
                }
            }

        }

        //退出
        private void btnQuit_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChangePwd_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                            this.btnInfoInput.Enabled = false;
                            break;
                        case "1000000103":              //数据审核
                            this.btnDataCheck.Enabled = false;
                            break;
                        case "1000000105":              //借阅审批
                            this.BtnBorrow.Enabled = false;
                            break;
                        case "1000000125":              //用户设置
                            this.btnUser.Enabled = false;
                            break;
                        case "1000000126":              //角色设置
                            this.btnRole1.Enabled = false;
                            break;
                        case "1000000127":              //功能设置
                            this.btnRoleFounction1.Enabled = false;
                            break;
                        case "1000000141":              //起始页
                            this.btnHomePage.Enabled = false;
                            break;
                        case "1000000123":              //字典维护
                            barButtonItem23.Enabled = false;
                            barButtonItem24.Enabled = false;
                            barButtonItem25.Enabled = false;
                            barButtonItem26.Enabled = false;
                            break;
                        case "1000000161":              //图片拍照
                            this.btnImagesInput.Enabled = false;
                            break;
                        case "1000000162":   //图片分类
                            this.btnProSet.Enabled = false;
                            break;
                        case "1000000163":                  // 病案查询
                            this.btnDataQuery.Enabled = false;
                            break;
                        case "1000000181":      //病案打印
                            this.btnPrintApply.Enabled = false;
                            break;
                        case "1000000201":      //图片扫描
                            this.toolStripButton1.Enabled = false;
                            break;
                        case "1000000203":      //图片合并
                            this.toolStripButton2.Enabled = false;
                            break;
                        case "1000001000":      //统计分析
                            this.btnUserWork.Enabled = false;
                            break;
                        case "1000000301":      //完成进度
                            this.btnCompleteQuery.Enabled = false;
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
        private void btnFirst_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyPatientHandelView uc = new UI.MyPatientHandelView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnHomePage_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyPatientHandelView uc = new UI.MyPatientHandelView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnDataQuery_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.SelectPatientView uc = new UI.SelectPatientView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnToolDataCheck_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DataCheckView uc = new UI.DataCheckView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnToolDataQuery_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.DataQueryView uc = new UI.DataQueryView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnPicInfoInput_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.ImagesInputView image = new UI.ImagesInputView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void btnProSet_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.PictureProjectSetView image = new UI.PictureProjectSetView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void btnPrintApply_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
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
        private void btnSelectScanner_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void toolStripButton1_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                string isScan = CJia.Health.Tools.ConfigHelper.GetAppStrings("isScanInSoftware");
                if (isScan == "1")//程序中调用扫描仪进行扫描
                {
                    UI.ScanView image = new UI.ScanView();
                    cJiaTabControl1.ShowPage(pageTitle, image);
                }
                else
                {
                    UI.JJCJScanView image2 = new UI.JJCJScanView();
                    cJiaTabControl1.ShowPage(pageTitle, image2);
                }
            }
        }

        private void toolStripButton2_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MergeView image = new UI.MergeView();
                cJiaTabControl1.ShowPage(pageTitle, image);
            }
        }

        private void cJiaTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (cJiaTabControl1.TabPages.Count > 0)
            {
                DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
                if (page.Controls.Find("axCmCaptureOcx1", true).Length > 0)
                {
                    pgPhoto.Enabled = true;
                    ckZidong.Checked = true;
                    ckZidong.CheckedChanged -= ckZidong_EditValueChanged;
                    ckZidong.CheckedChanged += ckZidong_EditValueChanged;
                    ckShoudong.CheckedChanged -= ckShoudong_EditValueChanged;
                    ckShoudong.CheckedChanged += ckShoudong_EditValueChanged;
                    ckBaoguang.CheckedChanged -= ckBaoguang_CheckedChanged;
                    ckBaoguang.CheckedChanged += ckBaoguang_CheckedChanged;
                    ckTuo.CheckedChanged -= ckTuo_CheckedChanged;
                    ckTuo.CheckedChanged += ckTuo_CheckedChanged;
                    btnQuZhaodian.CheckedChanged -= btnQuZhaodian_ItemClick;
                    btnQuZhaodian.CheckedChanged += btnQuZhaodian_ItemClick;
                    //combType.EditValueChanged -= combType_EditValueChanged;
                    //combType.EditValueChanged += combType_EditValueChanged;
                }
                else
                {
                    pgPhoto.Enabled = false;
                    ckZidong.CheckedChanged -= ckZidong_EditValueChanged;
                    ckShoudong.CheckedChanged -= ckShoudong_EditValueChanged;
                    ckBaoguang.CheckedChanged -= ckBaoguang_CheckedChanged;
                    ckTuo.CheckedChanged -= ckTuo_CheckedChanged;
                    btnQuZhaodian.CheckedChanged -= btnQuZhaodian_ItemClick;
                    //combType.EditValueChanged -= combType_EditValueChanged;
                }
                if (page.Controls.Find("cJiaPicture", true).Length > 0)
                {
                    btnBig.ItemClick -= btnBig_ItemClick;
                    btnBig.Enabled = true;
                    btnBig.ItemClick += btnBig_ItemClick;
                    btnSmall.ItemClick -= btnSmall_ItemClick;
                    btnSmall.Enabled = true;
                    btnSmall.ItemClick += btnSmall_ItemClick;

                    btnRight.ItemClick -= btnRight_ItemClick;
                    btnRight.Enabled = true;
                    btnRight.ItemClick += btnRight_ItemClick;
                    btnLeft.ItemClick -= btnLeft_ItemClick;
                    btnLeft.Enabled = true;
                    btnLeft.ItemClick += btnLeft_ItemClick;

                    btnFact.ItemClick -= btnFact_ItemClick;
                    btnFact.Enabled = true;
                    btnFact.ItemClick += btnFact_ItemClick;
                    btnFit.ItemClick -= btnFit_ItemClick;
                    btnFit.Enabled = true;
                    btnFit.ItemClick += btnFit_ItemClick;
                }
                else
                {
                    btnBig.Enabled = false;
                    btnBig.ItemClick -= btnBig_ItemClick;
                    btnSmall.Enabled = false;
                    btnSmall.ItemClick -= btnSmall_ItemClick;
                    btnRight.Enabled = false;
                    btnRight.ItemClick -= btnRight_ItemClick;
                    btnLeft.Enabled = false;
                    btnLeft.ItemClick -= btnLeft_ItemClick;
                    btnFact.Enabled = false;
                    btnFact.ItemClick -= btnFact_ItemClick;
                    btnFit.Enabled = false;
                    btnFit.ItemClick -= btnFit_ItemClick;
                }
            }
        }

        void combType_EditValueChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            //AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            //if(combType.EditValue.ToString()=="jpg")
            //    photo.SetFileType(1);
            //if (combType.EditValue.ToString() == "tif")
            //    photo.SetFileType(2);
        }

        void btnQuZhaodian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            if (btnQuZhaodian.Checked)
            {
                photo.SetDenoise(1);
            }
            else
            {
                photo.SetDenoise(0);
            }
        }

        void ckTuo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            if (ckTuo.Checked)
            {
                photo.DragVideo(1);
            }
            else
            {
                photo.DragVideo(0);
            }
        }

        void ckBaoguang_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            if (ckBaoguang.Checked)
            {
                photo.AutoExposure(1);
            }
            else
            {
                photo.AutoExposure(0);
            }
        }

        void ckShoudong_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            CJia.Controls.CJiaCheck ck = (CJia.Controls.CJiaCheck)page.Controls.Find("ckShouDong", true)[0];
            if (ckShoudong.Checked)
            {
                photo.CusCrop(1);
                ck.Checked = true;
            }
            else
            {
                photo.CusCrop(0);
                ck.Checked = false;
            }
        }

        void ckZidong_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            AxCmCaptureOcxLib.AxCmCaptureOcx photo = (AxCmCaptureOcxLib.AxCmCaptureOcx)page.Controls.Find("axCmCaptureOcx1", true)[0];
            CJia.Controls.CJiaCheck ck = (CJia.Controls.CJiaCheck)page.Controls.Find("ckZiDong", true)[0];
            if (ckZidong.Checked)
            {
                photo.AutoCrop(1);
                ck.Checked = true;
            }
            else
            {
                photo.AutoCrop(0);
                ck.Checked = false;
            }
        }

        void btnFit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InFactSize(false);
        }

        void btnFact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InFactSize(true);
        }

        void btnLeft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuanZhuang(false);
        }

        void btnRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuanZhuang(true);
        }

        void btnSmall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FangDa(false);
        }

        void btnBig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FangDa(true);
        }
        /// <summary>
        /// 实际尺寸 合适尺寸
        /// </summary>
        /// <param name="bol">true表示实际尺寸</param>
        public void InFactSize(bool bol)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            CJia.Controls.CJiaPicture pic = (CJia.Controls.CJiaPicture)page.Controls.Find("cJiaPicture", true)[0];
            if (pic.Image != null)
            {
                Image img = pic.Image;
                if (bol)
                {
                    pic.Width = img.Width;
                    pic.Height = img.Height;
                }
                else
                {
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                }
            }
        }
        /// <summary>
        /// 左 右 旋转
        /// </summary>
        /// <param name="bol">true表示左旋转</param>
        public void XuanZhuang(bool bol)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            CJia.Controls.CJiaPicture pic = (CJia.Controls.CJiaPicture)page.Controls.Find("cJiaPicture", true)[0];
            if (pic.Image != null)
            {
                Image img = pic.Image;
                if (bol)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                    pic.Image = img;
                }
                else
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                    pic.Image = img;
                }
            }
        }
        /// <summary>
        /// 放大 缩小
        /// </summary>
        /// <param name="bol"></param>
        public void FangDa(bool bol)
        {
            DevExpress.XtraTab.XtraTabPage page = cJiaTabControl1.SelectedTabPage;
            CJia.Controls.CJiaPicture pic = (CJia.Controls.CJiaPicture)page.Controls.Find("cJiaPicture", true)[0];
            if (pic.Image != null)
            {
                int panel_W = pic.Width;
                Image img = pic.Image;
                float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                if (bol)
                {
                    if (panel_W + 100 < img.Width)
                    {
                        pic.Width = panel_W + 100;
                        float height = i * (panel_W + 100);
                        pic.Height = Convert.ToInt32(height);
                    }
                }
                else
                {
                    if (panel_W - 100 > 100)
                    {
                        pic.Width = panel_W - 100;
                        float height = i * (panel_W - 100);
                        pic.Height = Convert.ToInt32(height);
                    }
                }
            }
        }

        private void btnUserWork_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.UserWorkStat uc = new UI.UserWorkStat();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnCompleteQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = e.Item.Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.CompleteQuery uc = new UI.CompleteQuery();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

    }
}
