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
    public partial class DataQueryView :/*DevExpress.XtraEditors.XtraUserControl,*/ CJia.Health.Tools.View, CJia.Health.Views.IDataQueryView
    {

        private DataRow selectRow;

        private DataTable selectPic;

        private DataTable patientInfo;

        private DataRow tabPatient;

        public DataQueryView()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            DateTime now = Sysdate;
            this.cdStart.EditValue = new DateTime(now.Year - 1, now.Month, now.Day, 0, 0, 0);
            this.cdEnd.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataQueryPresenter(this);
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
            }
            else
            {
                this.tabPatient = null;
            }
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

        private CJia.Health.Views.DataQueryArgs GetArgs()
        {
            CJia.Health.Views.DataQueryArgs dataCheckArge = new Views.DataQueryArgs();
            dataCheckArge.start = this.cdStart.DateTime;
            dataCheckArge.end = this.cdEnd.DateTime;
            //dataCheckArge.patientId = this.txtPatientId.Text;
            dataCheckArge.patientName = this.txtPatientName.Text;
            dataCheckArge.card = this.txtCard.Text;
            dataCheckArge.recordNo = this.txtRecotdNo.Text;
            return dataCheckArge;
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
                xtraTabPage2.Text = "图片档案";
                this.OnSelectPic(null, new Views.DataQueryArgs()
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
                //cJiaTabControl1.ShowPage("图片档案", new CJia.Health.App.UI.ImageInfoView(patientInfo));

                //imageInfoView.Dock = DockStyle.Fill;


                if(!this.isExistPage(patientInfo["PATIENT_NAME"].ToString() + "(" + patientInfo["PATIENT_ID"].ToString() + ")"))
                {
                    this.ShowPage(patientInfo["PATIENT_NAME"].ToString() + "(" + patientInfo["PATIENT_ID"].ToString() + ")", cJiaTabControl1);
                }
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
        public event EventHandler<Views.DataQueryArgs> OnSreach;

        /// <summary>
        /// 查询图片事件
        /// </summary>
        public event EventHandler<Views.DataQueryArgs> OnSelectPic;



        // 搜索病人信息方法回调方法
        public void ExePatient(DataTable result)
        {
            this.cgPatient.DataSource = result;
            this.patientInfo = result;
            //this.SetLockCount(result);
            //this.SetCheckCount(result);
        }

        public void ExePic(DataTable result)
        {
            this.selectPic = result;
        }

        #endregion

        bool isAll = false;
        private void btnAll_Click(object sender, EventArgs e)
        {
            if(isAll)
            {
                this.selectPanel.Size = new Size(this.selectPanel.Size.Width, 131);
                this.isAll = false;
            }
            else
            {
                this.selectPanel.Size = new Size(this.selectPanel.Size.Width, 500);
                this.isAll = true;
            }

        }

    }
}
