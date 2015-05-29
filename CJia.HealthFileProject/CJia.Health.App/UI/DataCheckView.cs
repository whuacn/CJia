using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class DataCheckView :/*DevExpress.XtraEditors.XtraUserControl,*/ CJia.Health.Tools.View, CJia.Health.Views.IDataCheckView
    {

        private DataRow selectRow;

        private DataTable selectPic;

        private DataTable patientInfo;

        private DataRow tabPatient;

        public DataCheckView()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            DateTime now = Sysdate;
            this.cdStart.EditValue = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            this.cdEnd.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            this.OnLockFunction(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataCheckPresenter(this);
        }

        #region 界面事件


        //搜索按钮单击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Seatch();
        }

        //关键字输入框输入事件
        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.Seatch();
            }
        }

        // 病人信息单击事件
        private void gvPatientInfo_DoubleClick(object sender, EventArgs e)
        {
            this.selectRow = this.gvPatientInfo.GetFocusedDataRow();
            this.AddPatientInfo(this.selectRow);
        }

        //tab页切换事件
        private void cJiaTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(this.cJiaTabControl2.SelectedTabPage != null)
            {
                DataRow patient = this.cJiaTabControl2.SelectedTabPage.Tag as DataRow;
                this.tabPatient = patient;
                this.EditBtn(patient);
            }
            else
            {
                this.tabPatient = null;
                this.EditBtn(null);
            }
        }

        //锁定按钮单击事件
        private void btnLock_Click(object sender, EventArgs e)
        {
            this.OnLock(null, new Views.DataCheckArgs()
            {
                healthId = tabPatient["ID"].ToString()
            });
        }

        //解锁按钮单击事件
        private void btnOpenLock_Click(object sender, EventArgs e)
        {
            this.OnOpenLock(null, new Views.DataCheckArgs()
            {
                healthId = tabPatient["ID"].ToString()
            });
        }

        // 审核通过按钮单击事件
        private void btnPass_Click(object sender, EventArgs e)
        {
            this.OnPass(null, new Views.DataCheckArgs()
            {
                healthId = tabPatient["ID"].ToString(),
                CheckReason = "",
                checkStatus = this.tabPatient["CHECK_STATUS"].ToString()
            });
        }

        // 审核不通过按钮单击事件
        private void btnNoPass_Click(object sender, EventArgs e)
        {
            CJia.Health.App.UI.CheckReasonView checkReasonView = new CheckReasonView();
            this.ShowAsWindow("审核不通过原因", checkReasonView);
            if(checkReasonView.isOk)
            {
                this.OnNoPass(null, new Views.DataCheckArgs()
                {
                    healthId = tabPatient["ID"].ToString(),
                    CheckReason = checkReasonView.reason,
                    checkStatus = this.tabPatient["CHECK_STATUS"].ToString()
                });
            }
        }

        // 撤销审核按钮单击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CJia.Health.App.UI.CheckReasonView checkReasonView = new CheckReasonView();
            this.ShowAsWindow("撤销审核原因", checkReasonView);
            this.OnDelete(null, new Views.DataCheckArgs()
            {
                healthId = tabPatient["ID"].ToString(),
                CheckReason = checkReasonView.reason,
                checkStatus = this.tabPatient["CHECK_STATUS"].ToString()
            });
        }

        // 锁定单选框修改
        private void crbLock_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable result = null;
            if(this.patientInfo != null)
            {
                result = this.patientInfo.Clone();
                if(this.crbLock.SelectedIndex == 0)
                {
                    result = this.patientInfo;
                }
                else if(this.crbLock.SelectedIndex == 1)
                {
                    result = CJia.Health.Tools.Help.GetDataSource(this.patientInfo.Select(" LOCK_STATUS = 111 "));
                }
                else
                {
                    result = CJia.Health.Tools.Help.GetDataSource(this.patientInfo.Select(" LOCK_STATUS = 110 "));
                }

                if(result != null)
                {
                    if(this.crdCheck.SelectedIndex == 0)
                    {
                    }
                    else if(this.crdCheck.SelectedIndex == 1)
                    {
                        result = CJia.Health.Tools.Help.GetDataSource(result.Select(" LOCK_STATUS = 111 "));
                    }
                    else
                    {
                        result = CJia.Health.Tools.Help.GetDataSource(result.Select(" LOCK_STATUS = 110 "));
                    }
                }
            }
            this.cgPatient.DataSource = result;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 搜索用户
        /// </summary>
        private void Seatch()
        {
            if(this.OnSreach != null)
            {
                this.OnSreach(null, this.GetArgs());
            }
        }

        private CJia.Health.Views.DataCheckArgs GetArgs()
        {
            CJia.Health.Views.DataCheckArgs dataCheckArge = new Views.DataCheckArgs();
            dataCheckArge.start = this.cdStart.DateTime;
            dataCheckArge.end = this.cdEnd.DateTime;
            dataCheckArge.search = this.txtKey.Text;
            return dataCheckArge;
        }

        /// <summary>
        /// 设置锁定与未锁定数量
        /// </summary>
        /// <param name="result"></param>
        private void SetLockCount(DataTable result)
        {
            if(result != null && result.Rows != null && result.Rows.Count > 0)
            {
                int IsLock = result.Select(" LOCK_STATUS = '111' ").Length;
                int NoLock = result.Select(" LOCK_STATUS = '110' ").Length;
                this.crbLock.Properties.Items[0].Description = "全部(" + result.Rows.Count + ")";
                this.crbLock.Properties.Items[1].Description = "锁定(" + IsLock + ")";
                this.crbLock.Properties.Items[2].Description = "未锁(" + NoLock + ")";
            }
            else
            {
                this.crbLock.Properties.Items[0].Description = "全部(0)";
                this.crbLock.Properties.Items[1].Description = "锁定(0)";
                this.crbLock.Properties.Items[2].Description = "未锁(0)";
            }
        }

        /// <summary>
        /// 设置审核数量
        /// </summary>
        /// <param name="result"></param>
        private void SetCheckCount(DataTable result)
        {
            if(result != null && result.Rows != null && result.Rows.Count > 0)
            {
                int YesCheck = result.Select(" CHECK_STATUS = '101' ").Length;
                int NoCheck = result.Select(" CHECK_STATUS = '102' ").Length;
                int NoHaveCheck = result.Select(" CHECK_STATUS = '100' ").Length;
                this.crdCheck.Properties.Items[0].Description = "全部(" + result.Rows.Count + ")";
                this.crdCheck.Properties.Items[1].Description = "通过(" + YesCheck + ")";
                this.crdCheck.Properties.Items[2].Description = "拒绝(" + NoCheck + ")";
                this.crdCheck.Properties.Items[3].Description = "未审(" + NoHaveCheck + ")";
            }
            else
            {
                this.crdCheck.Properties.Items[0].Description = "全部(0)";
                this.crdCheck.Properties.Items[1].Description = "通过(0)";
                this.crdCheck.Properties.Items[2].Description = "拒绝(0)";
                this.crdCheck.Properties.Items[3].Description = "未审(0)";
            }
        }

        /// <summary>
        /// 增加用户档案查询
        /// </summary>
        /// <param name="patientInfo"></param>
        private void AddPatientInfo(DataRow patientInfo)
        {

            if(patientInfo != null)
            {
                DevExpress.XtraTab.XtraTabPage xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPage1.AutoScroll = true;
                xtraTabPage1.Name = "xtraTabPage1";
                xtraTabPage1.Text = "病人基本信息";
                xtraTabPage1.Controls.Add(new CJia.Health.App.UI.PatientInfoView(patientInfo));

                DevExpress.XtraTab.XtraTabPage xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPage2.Name = "xtraTabPage2";
                xtraTabPage2.Text = "病案档案";
                this.OnSelectPic(null, new Views.DataCheckArgs()
                {
                    healthId = patientInfo["ID"].ToString()
                });
                CJia.Health.App.UI.ImageInfoView imageInfoView = new CJia.Health.App.UI.ImageInfoView(this.selectPic);
                xtraTabPage2.Controls.Add(imageInfoView);



                Controls.CJiaTabControl cJiaTabControl1 = new Controls.CJiaTabControl();
                cJiaTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                cJiaTabControl1.Dock = DockStyle.Fill;
                cJiaTabControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(213)))), ((int)(((byte)(238)))));
                cJiaTabControl1.Appearance.Options.UseBackColor = true;
                cJiaTabControl1.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
                cJiaTabControl1.AppearancePage.Header.BorderColor = System.Drawing.Color.Transparent;
                cJiaTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10F);
                cJiaTabControl1.AppearancePage.Header.Options.UseBackColor = true;
                cJiaTabControl1.AppearancePage.Header.Options.UseBorderColor = true;
                cJiaTabControl1.AppearancePage.Header.Options.UseFont = true;
                cJiaTabControl1.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
                cJiaTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DimGray;
                cJiaTabControl1.AppearancePage.HeaderActive.Options.UseBackColor = true;
                cJiaTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
                cJiaTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.White;
                cJiaTabControl1.AppearancePage.PageClient.Options.UseBackColor = true;
                cJiaTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                cJiaTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
                cJiaTabControl1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next)
                | DevExpress.XtraTab.TabButtons.Close)
                | DevExpress.XtraTab.TabButtons.Default)));
                cJiaTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
                cJiaTabControl1.Location = new System.Drawing.Point(3, 5);
                cJiaTabControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
                cJiaTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                cJiaTabControl1.Name = "cJiaTabControl1";
                cJiaTabControl1.SelectedTabPage = xtraTabPage1;
                cJiaTabControl1.TabIndex = 10;
                cJiaTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                xtraTabPage1,
                xtraTabPage2});
                cJiaTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.Default;
                cJiaTabControl1.Tag = patientInfo;
                //cJiaTabControl1.ShowPage("病人基本信息", new CJia.Health.App.UI.PatientInfoView(patientInfo));
                //cJiaTabControl1.ShowPage("病案档案", new CJia.Health.App.UI.ImageInfoView(patientInfo));

                //imageInfoView.Dock = DockStyle.Fill;


                if(!this.isExistPage(patientInfo["PATIENT_NAME"].ToString() + "(" + patientInfo["PATIENT_ID"].ToString() + ")"))
                {
                    this.ShowPage(patientInfo["PATIENT_NAME"].ToString() + "(" + patientInfo["PATIENT_ID"].ToString() + ")", cJiaTabControl1);
                }
            }
        }

        /// <summary>
        /// 修改按钮的样式
        /// </summary>
        /// <param name="patient"></param>
        private void EditBtn(DataRow patient)
        {
            if(patient != null)
            {
                if(patient["CHECK_STATUS"].ToString() == "103")
                {
                    this.btnPass.Enabled = true;
                    this.btnNoPass.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.cJiaLabel3.Text = "已提交";
                }
                else
                {
                    this.btnPass.Enabled = false;
                    this.btnNoPass.Enabled = false;
                    this.btnDelete.Enabled = true;
                    if(patient["CHECK_STATUS"].ToString() == "101")
                    {
                        this.cJiaLabel3.Text = "审核通过";
                    }
                    else if(patient["CHECK_STATUS"].ToString() == "102")
                    {
                        this.cJiaLabel3.Text = "审核未通过";
                    }
                }

                if(patient["LOCK_STATUS"].ToString() == "110")
                {
                    this.btnLock.Enabled = true;
                    this.btnOpenLock.Enabled = false;
                    this.cJiaLabel2.Text = "未锁定";
                }
                else
                {
                    this.btnLock.Enabled = false;
                    this.btnOpenLock.Enabled = true;

                    this.btnPass.Enabled = false;
                    this.btnNoPass.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.cJiaLabel3.Text = "已锁定";
                }
            }
            else
            {
                this.btnLock.Enabled = false;
                this.btnOpenLock.Enabled = false;

                this.btnPass.Enabled = false;
                this.btnNoPass.Enabled = false;
                this.btnDelete.Enabled = false;
                this.cJiaLabel2.Text = "";
                this.cJiaLabel3.Text = "";
            }
        }

        #region Tab 控件操作
        private void ShowPage(string Title, Control ucPage)
        {
            DevExpress.XtraTab.XtraTabPage xtraPage = new DevExpress.XtraTab.XtraTabPage();
            xtraPage.AllowDrop = true;
            xtraPage.AutoScroll = true;
            xtraPage.Text = Title;
            xtraPage.Controls.Add(ucPage);
            xtraPage.Tag = ucPage.Tag;
            ucPage.Dock = DockStyle.Fill;
            this.cJiaTabControl2.TabPages.Add(xtraPage);
            this.cJiaTabControl2.SelectedTabPage = xtraPage;
        }
        private bool isExistPage(string PageTitle)
        {
            for(int i = 0; i < this.cJiaTabControl2.TabPages.Count; i++)
            {
                if(this.cJiaTabControl2.TabPages[i].Text == PageTitle)
                {
                    this.cJiaTabControl2.SelectedTabPageIndex = i;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #endregion

        #region IDataCheckView 成员

        /// <summary>
        /// 搜索事件
        /// </summary>
        public event EventHandler<Views.DataCheckArgs> OnSreach;

        /// <summary>
        /// 查询病案事件
        /// </summary>
        public event EventHandler<Views.DataCheckArgs> OnSelectPic;


        public event EventHandler<Views.DataCheckArgs> OnLock;

        public event EventHandler<Views.DataCheckArgs> OnOpenLock;

        public event EventHandler<Views.DataCheckArgs> OnPass;

        public event EventHandler<Views.DataCheckArgs> OnNoPass;

        public event EventHandler<Views.DataCheckArgs> OnDelete;

        public event EventHandler<Views.DataCheckArgs> OnLockFunction;

        // 查询登录用户是否有锁定权限回调方法
        public void ExeLockFunction(bool result)
        {
            if(!result)
            {
                this.btnLock.Visible = false;
                this.btnOpenLock.Visible = false;
            }
        }

        public void ExeLock(bool result)
        {
            if(result)
            {
                Message.Show("档案锁定成功！");
                this.tabPatient["LOCK_STATUS"] = "111";
                this.EditBtn(this.tabPatient);
            }
            else
            {
                Message.ShowWarning("档案锁定失败！");
            }
        }

        public void ExeOpenLock(bool result)
        {
            if(result)
            {
                Message.Show("档案解锁成功！");
                this.tabPatient["LOCK_STATUS"] = "110";
                this.EditBtn(this.tabPatient);
            }
            else
            {
                Message.ShowWarning("档案解锁失败！");
            }
        }

        public void ExePass(bool result)
        {
            if(result)
            {
                Message.Show("档案审核通过成功！");
                this.tabPatient["CHECK_STATUS"] = "101";
                this.EditBtn(this.tabPatient);
            }
            else
            {
                Message.ShowWarning("档案审核通过失败！");
            }
        }

        public void ExeNoPass(bool result)
        {
            if(result)
            {
                Message.Show("档案审核不通过成功！");
                this.tabPatient["CHECK_STATUS"] = "102";
                this.EditBtn(this.tabPatient);
            }
            else
            {
                Message.ShowWarning("档案审核不通过失败！");
            }
        }

        public void ExeDelete(bool result)
        {
            if(result)
            {
                Message.Show("档案撤销审核成功！");
                this.tabPatient["CHECK_STATUS"] = "100";
                this.EditBtn(this.tabPatient);
            }
            else
            {
                Message.ShowWarning("档案撤销审核失败！");
            }
        }


        // 搜索病人信息方法回调方法
        public void ExePatient(DataTable result)
        {
            this.cgPatient.DataSource = result;
            this.patientInfo = result;
            this.SetLockCount(result);
            this.SetCheckCount(result);
        }

        public void ExePic(DataTable result)
        {
            this.selectPic = result;
        }

        #endregion

    }
}
