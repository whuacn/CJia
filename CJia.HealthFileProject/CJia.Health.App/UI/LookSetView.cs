using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CJia.Health.Tools;
using System.IO;

namespace CJia.Health.App.UI
{
    public partial class LookSetView : CJia.Health.Tools.View, CJia.Health.Views.INewImageCheckView
    {
        public LookSetView()
        {
            InitializeComponent();
            this.LURecordNO.GetData += LURecordNO_GetData;
            this.LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            lblprojectName.Text = "";
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


        protected override object CreatePresenter()
        {
            return new Presenters.NewImageCheckPresenter(this);
        }

        #region  属性

        /// <summary>
        /// 该病人所有病案
        /// </summary>
        private DataTable AllPicture = null;

        /// <summary>
        /// 选择的病案
        /// </summary>
        private DataRow SelectPicture
        {
            get
            {
                if (this.gvPicture.GetFocusedDataRow() != null)
                {
                    DataRow selectRow = this.gvPicture.GetFocusedDataRow();
                    return selectRow;
                }
                return null;
            }
        }

        /// <summary>
        /// 选择的panel数
        /// </summary>
        private int selectPanelNumber = 0;

        private DataRow selectPicData = null;
        /// <summary>
        /// 展示的病案数据
        /// </summary>
        private DataRow SelectPicData
        {
            get
            {
                return this.selectPicData;
            }
            set
            {
                this.selectPicData = value;
                this.SetBtnStyle();
            }
        }

        /// <summary>
        /// 所有审核原因
        /// </summary>
        private DataTable AllCheckReason = null;

        #endregion

        #region 界面事件

        // 获取病人
        void LURecordNO_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            string healthId = this.LURecordNO.Text.Trim().ToUpper();
            Views.NewImageCheckViewArgs NewImageCheckViewArgs = new Views.NewImageCheckViewArgs()
            {
                healthId = healthId
            };
            if (this.OnSreach != null)
            {
                this.OnSreach(null, NewImageCheckViewArgs);
            }

        }

        // 选择病人后
        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            string healthID = LURecordNO.DisplayValue;
            DataTable data = LURecordNO.DataSource;
            DataRow[] drs = data.Select(" ID='" + healthID + "' ");
            if (drs.Length > 0)
            {
                string lockstatus = drs[0]["LOCK_STATUS"].ToString();
                if (lockstatus == "110")
                {
                    btnUnLock.Enabled = false;
                    btnLock.Enabled = true;
                }
                else
                {
                    btnUnLock.Enabled = true;
                    btnLock.Enabled = false;
                }
            }
            this.SelectPic();
            this.cgPicture.Focus();
        }

        // 用户控件键盘事件
        protected override bool ProcessDialogKey(Keys keyData)
        {
            this.keyDown(keyData);
            return false;
        }

        // 病案输入框键盘事件
        private void LURecordNO_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyDown(e.KeyData);
        }

        // grid键盘事件
        private void cgPicture_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyDown(e.KeyData);
        }

        private void ImageCheckView_Enter(object sender, EventArgs e)
        {
            this.LURecordNO.Focus();
        }


        /// <summary>
        /// 根据状态改变字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBigPicture_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "IS_LOOK_NAME")
            {
                string look = this.gvPicture.GetDataRow(e.RowHandle)["IS_LOOK_NAME"].ToString();
                if (look == "可以导出")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if (look == "可以打印")
                {
                    e.Appearance.ForeColor = Color.DodgerBlue;
                }
                else if (look == "可以浏览")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            if (e.RowHandle == this.gvPicture.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(93, 175, 223);
            }
        }

        // 上一大页
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F1);
        }

        // 下一大页
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F4);
        }
        #endregion

        #region IImageCheckView 成员

        public event EventHandler<Views.NewImageCheckViewArgs> OnSreach;

        public event EventHandler<Views.NewImageCheckViewArgs> OnSelectPic;

        public event EventHandler<Views.NewImageCheckViewArgs> OnPass;

        public event EventHandler<Views.NewImageCheckViewArgs> OnNoPass;

        public event EventHandler<Views.NewImageCheckViewArgs> OnDelete;

        public event EventHandler<Views.NewImageCheckViewArgs> OnLockFunction;

        public event EventHandler<Views.NewImageCheckViewArgs> OnCheckReason;

        public event EventHandler<Views.NewImageCheckViewArgs> OnAddCheckReason;

        public event EventHandler<Views.NewImageCheckViewArgs> OnRemoveCheckReason;

        public event EventHandler<Views.NewImageCheckViewArgs> OnYesLook;

        public event EventHandler<Views.NewImageCheckViewArgs> OnNOLook;

        public event EventHandler<Views.NewImageCheckViewArgs> OnPrint;

        public event EventHandler<Views.NewImageCheckViewArgs> OnExport;

        public event EventHandler<Views.NewImageCheckViewArgs> OnLock;

        public event EventHandler<Views.NewImageCheckViewArgs> OnUnLock;

        public void ExeUnLock(bool result)
        {
            if (result)
            {
                MessageBox.Show("此病案解锁成功");
                btnLock.Enabled = true;
                btnUnLock.Enabled = false;
                DataTable data = LURecordNO.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string id = dr["ID"].ToString();
                    if (id == LURecordNO.DisplayValue)
                    {
                        dr["LOCK_STATUS"] = "110";
                        break;
                    }
                }
            }
        }

        public void ExeLock(bool result)
        {
            if (result)
            {
                MessageBox.Show("此病案锁定成功");
                btnLock.Enabled = false;
                btnUnLock.Enabled = true;
                DataTable data = LURecordNO.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string id = dr["ID"].ToString();
                    if (id == LURecordNO.DisplayValue)
                    {
                        dr["LOCK_STATUS"] = "111";
                        break;
                    }
                }
            }
        }

        public void ExePrint(bool result)
        {
            if (result)
            {
                DataRow dr = gvPicture.GetFocusedDataRow();
                dr["IS_LOOK"] = "1";
                dr["IS_PRINT"] = "1";
                dr["IS_EXPORT"] = "0";
                dr["IS_LOOK_NAME"] = "可以打印";
                this.SetBtnStyle();
            }
        }

        public void ExeExport(bool result)
        {
            if (result)
            {
                DataRow dr = gvPicture.GetFocusedDataRow();
                dr["IS_LOOK"] = "1";
                dr["IS_PRINT"] = "1";
                dr["IS_EXPORT"] = "1";
                dr["IS_LOOK_NAME"] = "可以导出";
                this.SetBtnStyle();
            }
        }

        public void ExeYesLook(bool result)
        {
            if (result)
            {
                DataRow dr = gvPicture.GetFocusedDataRow();
                dr["IS_LOOK"] = "1";
                dr["IS_PRINT"] = "0";
                dr["IS_EXPORT"] = "0";
                dr["IS_LOOK_NAME"] = "可以浏览";
                this.SetBtnStyle();
            }
        }

        public void ExeNoLook(bool result)
        {
            if (result)
            {
                DataRow dr = gvPicture.GetFocusedDataRow();
                dr["IS_LOOK"] = "0";
                dr["IS_PRINT"] = "0";
                dr["IS_EXPORT"] = "0";
                dr["IS_LOOK_NAME"] = "不能浏览";
                this.SetBtnStyle();
            }
        }

        public void ExeCheckReason(DataTable result)
        {
            this.AllCheckReason = result;
        }

        public void ExeOpenLock(bool result)
        {
            throw new NotImplementedException();
        }

        public void ExePass(bool result)
        {

        }

        public void ExeNoPass(bool result)
        {

        }

        public void ExeDelete(bool result)
        {

        }


        public void ExePic(DataTable AllPicture)
        {
            this.AllPicture = AllPicture;
            cgPicture.DataSource = AllPicture;
        }



        public void ExePatient(DataTable result)
        {
            LURecordNO.DataSource = result;
            LURecordNO.DisplayField = "RECORDNO";
            LURecordNO.ValueField = "ID";
            LURecordNO.Fields = new string[,] { { "RECORDNO", "病案号" }, { "PATIENT_NAME", "姓名" }, { "GENDER_NAME", "性别" }, { "IN_HOSPITAL_TIME", "入院次数" } };
        }

        public void ExeLockFunction(bool result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 补助方法


        /// <summary>
        /// 查询病案
        /// </summary>
        private void SelectPic()
        {
            string healthId = this.LURecordNO.DisplayValue.Trim();
            Views.NewImageCheckViewArgs NewImageCheckViewArgs = new Views.NewImageCheckViewArgs()
            {
                healthId = healthId
            };
            if (this.OnSelectPic != null)
            {
                this.OnSelectPic(null, NewImageCheckViewArgs);
            }
        }

        /// <summary>
        /// 绑定病案
        /// </summary>
        private void BindPicture()
        {
            this.BindPic(this.SelectPicture);
        }

        private void keyDown(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    this.gvPicture.Focus();
                    this.gvPicture.MovePrev();
                    break;
                case Keys.F4:
                    this.gvPicture.Focus();
                    this.gvPicture.MoveNext();
                    break;
                case Keys.F6:
                    if (this.YesLook())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
                    break;
                case Keys.F5:
                    if (this.NoLook())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
                    break;
                case Keys.F7:
                    if (this.Print())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
                    break;
                case Keys.F8:
                    if (this.Export())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
                    break;
                default:
                    break;
            }
        }


        #region 病案绑定显示
        Thread thread;
        UI.Loading load;
        // 病案列表绑定事件
        public void BindPic(DataRow picPath)
        {
            if (picPath != null)
            {
                string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                string path = host + "/" + picPath["STORAGE_PATH"].ToString().Replace('\\', '/') + "/" + picPath["PICTURE_NAME"].ToString();
                Loading(path);
                lblprojectName.Text = picPath["PRO_NAME"].ToString();
                this.selectPicData = picPath;
                this.SetBtnStyle();
            }
        }
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
                    cgPicture.Focus();
                }
                else
                {
                    Message.Show("此病案不存在或已删除，请与管理员联系。。。");
                }
            }
            catch { }
        }

        #endregion

        /// <summary>
        /// 设置按钮样式
        /// </summary>
        private void SetBtnStyle()
        {
            string look = this.SelectPicData["IS_LOOK_NAME"].ToString();
            if (look == "可以导出")
            {
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnPrint.Enabled = true;
                btnExport.Enabled = false;
            }
            else if (look == "可以打印")
            {
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnPrint.Enabled = false;
                btnExport.Enabled = true;
            }
            else if (look == "可以浏览")
            {
                btnYes.Enabled = false;
                btnNo.Enabled = true;
                btnPrint.Enabled = true;
                btnExport.Enabled = true;
            }
            else
            {
                btnYes.Enabled = true;
                btnNo.Enabled = false;
                btnPrint.Enabled = true;
                btnExport.Enabled = true;
            }
        }

        private bool Print()
        {
            DataRow dr = gvPicture.GetFocusedDataRow();
            string checkStatus = dr["IS_LOOK_NAME"].ToString();
            if (checkStatus != "可以打印")
            {
                string pictrueId = dr["PICTURE_ID"].ToString();
                this.OnPrint(null, new Views.NewImageCheckViewArgs()
                {
                    pictureId = pictrueId
                });
                return true;
            }
            return false;
        }

        private bool Export()
        {
            DataRow dr = gvPicture.GetFocusedDataRow();
            string checkStatus = dr["IS_LOOK_NAME"].ToString();
            if (checkStatus != "可以导出")
            {
                string pictrueId = dr["PICTURE_ID"].ToString();
                this.OnExport(null, new Views.NewImageCheckViewArgs()
                {
                    pictureId = pictrueId
                });
                return true;
            }
            return false;
        }

        private bool YesLook()
        {
            DataRow dr = gvPicture.GetFocusedDataRow();
            string checkStatus = dr["IS_LOOK_NAME"].ToString();
            if (checkStatus != "可以浏览")
            {
                string pictrueId = dr["PICTURE_ID"].ToString();
                this.OnYesLook(null, new Views.NewImageCheckViewArgs()
                {
                    pictureId = pictrueId
                });
                return true;
            }
            return false;
        }
        private bool NoLook()
        {
            DataRow dr = gvPicture.GetFocusedDataRow();
            string checkStatus = dr["IS_LOOK_NAME"].ToString();
            if (checkStatus != "不能浏览")
            {
                string pictrueId = dr["PICTURE_ID"].ToString();
                this.OnNOLook(null, new Views.NewImageCheckViewArgs()
                {
                    pictureId = pictrueId
                });
                return true;
            }
            return false;
        }
        #endregion


        private void btnAllNO_Click(object sender, EventArgs e)
        {
            BindAllNOLook();
        }
        public void BindAllNOLook()
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                DataTable data = (DataTable)cgPicture.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string pictrueId = dr["PICTURE_ID"].ToString();
                    this.OnNOLook(null, new Views.NewImageCheckViewArgs()
                    {
                        pictureId = pictrueId
                    });
                }
                this.SelectPic();
                this.cgPicture.Focus();
            }
        }

        private void gvPicture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                pdfViewer.FileName = "";
                gvPicture.Focus();
                if (gvPicture.GetFocusedDataRow() != null)
                {
                    this.BindPicture();
                }
                gvPicture.Focus();
            }
            catch { }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                this.keyDown(Keys.F6);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                this.keyDown(Keys.F5);
            }
        }

        private void btnAllYes_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                DataTable data = (DataTable)cgPicture.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string pictrueId = dr["PICTURE_ID"].ToString();
                    this.OnYesLook(null, new Views.NewImageCheckViewArgs()
                    {
                        pictureId = pictrueId
                    });
                }
                this.SelectPic();
                this.cgPicture.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                this.keyDown(Keys.F7);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                this.keyDown(Keys.F8);
            }
        }

        private void btnAllPrint_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                DataTable data = (DataTable)cgPicture.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string pictrueId = dr["PICTURE_ID"].ToString();
                    this.OnPrint(null, new Views.NewImageCheckViewArgs()
                    {
                        pictureId = pictrueId
                    });
                }
                this.SelectPic();
                this.cgPicture.Focus();
            }
        }

        private void btnAllExport_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                DataTable data = (DataTable)cgPicture.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    string pictrueId = dr["PICTURE_ID"].ToString();
                    this.OnExport(null, new Views.NewImageCheckViewArgs()
                    {
                        pictureId = pictrueId
                    });
                }
                this.SelectPic();
                this.cgPicture.Focus();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定锁定？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    string healthId = (cgPicture.DataSource as DataTable).Rows[0]["HEALTH_ID"].ToString();
                    this.OnLock(null, new Views.NewImageCheckViewArgs()
                    {
                        healthId = healthId
                    });
                }
            }
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (cgPicture.DataSource != null && gvPicture.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定解锁？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    string healthId = (cgPicture.DataSource as DataTable).Rows[0]["HEALTH_ID"].ToString();
                    this.OnUnLock(null, new Views.NewImageCheckViewArgs()
                    {
                        healthId = healthId
                    });
                }
            }
        }

    }


}
