using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using CJia.Health.Tools;
using System.Threading;
using System.IO;

namespace CJia.Health.App.UI
{
    public partial class SelectPatientView : CJia.Health.Tools.View, CJia.Health.Views.IPrintApplyView
    {
        public SelectPatientView()
        {
            InitializeComponent();
            InitValue();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            lblprojectName.Text = "";
            PicName = "";
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PrintApplyPresenter(this);
        }
        /// <summary>
        /// ftp服务器ip
        /// </summary>
        private string HostName = ConfigHelper.GetAppStrings("ftp_ip");
        /// <summary>
        /// ftp验证 用户名
        /// </summary>
        private string UserName = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_userName"));
        /// <summary>
        /// ftp验证 密码
        /// </summary>
        private string Password = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_password"));
        /// <summary>
        /// 当前打印图片
        /// </summary>
        private List<Image> listPic = new List<Image>();

        /// <summary>
        /// 当前打印页数
        /// </summary>
        private int pageNo = 0;

        /// <summary>
        /// 判断是否触发checkbox的SelectedValueChanged事件（目的：第一次双击病人后不加载图片）
        /// </summary>
        private int IsLoadChk = 0;

        CJia.Health.Views.PrintApplyEventArgs printApplyArgs = new Views.PrintApplyEventArgs();

        #region 【接口实现】

        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.PrintApplyEventArgs> OnInit;

        /// <summary>
        /// 查询病人事件
        /// </summary>
        public event EventHandler<Views.PrintApplyEventArgs> OnPatientSearch;

        /// <summary>
        /// 双击病人列表绑定checkboxList图片信息
        /// </summary>
        public event EventHandler<Views.PrintApplyEventArgs> OnPatientDoubleClick;

        ///// <summary>
        ///// 查询图片事件
        ///// </summary>
        //public event EventHandler<Views.PrintApplyEventArgs> OnSelectPicture;

        /// <summary>
        /// 绑定病人列表
        /// </summary>
        /// <param name="dtGridPatient"></param>
        public void ExeGridPatient(DataTable dtGridPatient)
        {
            this.gridPatient.DataSource = dtGridPatient;
        }
        /// <summary>
        /// 绑定界面选择框图片信息
        /// </summary>
        /// <param name="dtPicture"></param>
        public void ExeBindChkPicture(DataTable dtPicture)
        {
            if (dtPicture != null && dtPicture.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPicture.Rows)
                {
                    string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                    dr["SRC"] = host + "/" + dr["SRC"].ToString().Replace('\\', '/');
                }
            }
            cgPicture.DataSource = dtPicture;
            DataRow drPatient = this.gvPatientInfo.GetFocusedDataRow();
            if (drPatient != null)
            {
                DataRow dr = drPatient;
                this.ltxtRecordNo.Text = dr["RECORDNO"].ToString();
                this.ltxtInHospitalTime.Text = dr["IN_HOSPITAL_TIME"].ToString();

                this.ltxtPatientName.Text = dr["PATIENT_NAME"].ToString();
                this.cboGender.Text = dr["GENDER_NAME"].ToString();
                this.cboBirthday.Text = DateTime.Parse(dr["BIRTHDAY"].ToString()).ToString("yyyy-MM-dd");

                this.ltxtBirthPlace.Text = dr["PROVINCE"].ToString();

                this.ltxtIdCard.Text = dr["ID_CARD"].ToString();
                ltxtPatientAge.Text = dr["PATIENT_AGE"].ToString();
                ltxtPatientAddress.Text = dr["PATIENT_ADDRESS"].ToString();

                this.cboInHospitalDate.Text = DateTime.Parse(dr["IN_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");
                this.cboOutHospitalDate.Text = DateTime.Parse(dr["OUT_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");

                this.rtlkInHospitalDept.Text = dr["IN_HOSPITAL_DEPT_NAME"].ToString();

                this.rtlkOutHospitalDept.Text = dr["OUT_HOSPITAL_DEPT_NAME"].ToString();

                this.rtlkICDOutDia1.Text = dr["ICD_OUTDIA1"].ToString();
                this.ltxtOutDiaName1.Text = dr["OUTDIA_NAME1"].ToString();

                this.rtlkICDOutDia2.Text = dr["ICD_OUTDIA2"].ToString();
                this.ltxtOutDiaName2.Text = dr["OUTDIA_NAME2"].ToString();

                this.rtlkICDOutDia3.Text = dr["ICD_OUTDIA3"].ToString();
                this.ltxtOutDiaName3.Text = dr["OUTDIA_NAME3"].ToString();

                this.rtlkICDOutDia4.Text = dr["ICD_OUTDIA4"].ToString();
                this.ltxtOutDiaName4.Text = dr["OUTDIA_NAME4"].ToString();

                this.rtlkICDSurgery1.Text = dr["ICD_SURGERY1"].ToString();
                this.ltxtSurgeryName1.Text = dr["SURGERY_NAME1"].ToString();

                this.rtlkICDSurgery2.Text = dr["ICD_SURGERY2"].ToString();
                this.ltxtSurgeryName2.Text = dr["SURGERY_NAME2"].ToString();

                this.rtlkICDSurgery3.Text = dr["ICD_SURGERY3"].ToString();
                this.ltxtSurgeryName3.Text = dr["SURGERY_NAME3"].ToString();

                this.rtlkICDSurgery4.Text = dr["ICD_SURGERY4"].ToString();
                this.ltxtSurgeryName4.Text = dr["SURGERY_NAME4"].ToString();

                this.cboTreatResult1.Text = dr["TREAT_RESULT1_NAME"].ToString();
                this.cboTreatResult2.Text = dr["TREAT_RESULT2_NAME"].ToString();
                this.cboTreatResult3.Text = dr["TREAT_RESULT3_NAME"].ToString();
                this.cboTreatResult4.Text = dr["TREAT_RESULT4_NAME"].ToString();

                this.cboSurgeryDate1.Text = dr["SURGERY_DATE1"].ToString();
                this.cboSurgeryDate2.Text = dr["SURGERY_DATE2"].ToString();
                this.cboSurgeryDate3.Text = dr["SURGERY_DATE3"].ToString();
                this.cboSurgeryDate4.Text = dr["SURGERY_DATE4"].ToString();
            }
        }
        #endregion

        #region 【界面事件响应】
        private void btnPatientSearch_Click(object sender, EventArgs e)
        {
            pdfViewer.FileName = "";
            PatientSearch();
        }

        private void txtRecotdNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PatientSearch();
            }
        }

        //Thread thread;
        //UI.Loading load;

        private void Loading(string uri)
        {
            try
            {
                bool bol = CJia.Health.Tools.Help.DownLoadFileByUri(uri, UserName, Password);
                if (bol)
                {
                    string[] arr = uri.Split('/');
                    string fileName = uri.Split('/')[arr.Length - 1];
                    string downLoadFile = Application.StartupPath + @"\Cache\" + fileName;
                    string pdfData = downLoadFile.Replace(".pdf", "");
                    pdfViewer.Password = PDFPassword;
                    pdfViewer.FileName = pdfData;
                    pdfViewer.Tag = uri;
                }
                else
                {
                    Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
            }
            catch { }
        }
        #endregion

        #region 【自定义方法】

        /// <summary>
        /// 初始化赋值
        /// </summary>
        public void InitValue()
        {
            OnInit(null, null);
            DateTime now = Sysdate;
            int Mon = now.Month;
            if (Mon == 1)
            {
                Mon = 12;
            }

            this.cboStartDate.EditValue = new DateTime(now.Year - 1, Mon, now.Day, 0, 0, 0);
            this.cboEndDate.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            dtInputStart.EditValue = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            dtInputEnd.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }


        /// <summary>
        /// 取得界面查询值
        /// </summary>
        /// <returns></returns>
        private CJia.Health.Views.PrintApplyEventArgs SetArgs()
        {
            printApplyArgs.StartDate = cboStartDate.DateTime;
            printApplyArgs.EndDate = cboEndDate.DateTime;
            //printApplyArgs.PatientId = txtPatientId.Text;
            printApplyArgs.PatientName = txtPatientName.Text;
            //printApplyArgs.Card = txtCard.Text;
            printApplyArgs.RecordNo = txtRecotdNo.Text.ToUpper();

            printApplyArgs.isInput = ckInput.Checked; //by dh
            printApplyArgs.InputStartDate = dtInputStart.DateTime;
            printApplyArgs.InputEndDate = dtInputEnd.DateTime;

            DataRow drPatient = this.gvPatientInfo.GetFocusedDataRow();
            if (drPatient != null)
            {
                printApplyArgs.HealthId = drPatient["ID"].ToString();
            }
            return printApplyArgs;
        }

        /// <summary>
        /// 病人查询事件
        /// </summary>
        private void PatientSearch()
        {
            if (OnPatientSearch != null)
            {
                OnPatientSearch(null, SetArgs());
            }
        }
        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnPatientSearch.Focus();
                    btnPatientSearch_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion


        private void gvPatientInfo_Click(object sender, EventArgs e)
        {
            if (gvPatientInfo.GetFocusedDataRow() != null)
            {
                OnPatientDoubleClick(sender, SetArgs());
            }
        }
        private void gvPicture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPicture.GetFocusedDataRow() != null)
            {
                try
                {
                    DataRow dr = gvPicture.GetFocusedDataRow();
                    lblprojectName.Text = dr["PRO_NAME"].ToString();
                    PicName = dr["PICTURE_NAME"].ToString();
                    Loading(dr["SRC"].ToString());
                    cgPicture.Focus();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 图片名称
        /// </summary>
        private string PicName;
        private void btnSavePic_Click(object sender, EventArgs e)
        {
            //if (cJiaPicture.Image != null)
            //{
            //    try
            //    {
            //        Image img = cJiaPicture.Image;
            //        string linshipath = CJia.Health.Tools.ConfigHelper.GetAppStrings("JJCJScanPicPath");//临时保存图片
            //        if (!Directory.Exists(linshipath))//若文件夹不存在则新建文件夹   
            //        {
            //            Directory.CreateDirectory(linshipath); //新建文件夹   
            //        }
            //        string picInfo = linshipath + "\\" + PicName;
            //        img.Save(picInfo);
            //        FtpHelp.UploadFileByUri(picInfo, cJiaPicture.Tag.ToString(), HostName, UserName, Password);
            //        File.Delete(picInfo);
            //        MessageBox.Show("保存成功");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("保存失败");
            //    }
            //}
        }

        private void ckInHos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInHos.Checked)
            {
                cboStartDate.Enabled = true;
                cboEndDate.Enabled = true;
                ckInput.Checked = false;
            }
            else
            {
                cboStartDate.Enabled = false;
                cboEndDate.Enabled = false;
                ckInput.Checked = true;
            }
        }

        private void ckInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInput.Checked)
            {
                dtInputStart.Enabled = true;
                dtInputEnd.Enabled = true;
                ckInHos.Checked = false;
            }
            else
            {
                dtInputStart.Enabled = false;
                dtInputEnd.Enabled = false;
                ckInHos.Checked = true;
            }
        }
    }
}
