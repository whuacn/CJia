using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using TwainLib;
using System.Collections;
using GdiPlusLib;
using CJia.Health.Tools;
using System.Threading;

namespace CJia.Health.App.UI
{
    public partial class JJCJScanView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView, IMessageFilter
    {
        public event EventHandler<Views.ImagesInputArgs> OnShortKeyDown;
        public void ExeBindProjectByShortKey(DataTable data)
        { }
        private Point m_StarPoint = Point.Empty;     //for 拖动
        private Point m_ViewPoint = Point.Empty;
        private bool m_StarMove = false;
        bool msgfilter;
        int Page = 0;
        string MyProductName = "扫描程序";
        /// <summary>
        /// 病案号数据
        /// </summary>
        private DataTable RecordNOData;
        /// <summary>
        /// 图片信息
        /// </summary>
        private DataTable PictureInfo;
        /// <summary>
        /// 已入库的图片信息
        /// </summary>
        private DataTable InputPictureData;
        /// <summary>
        /// 出院时间
        /// </summary>
        private DateTime OutHosDate;
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
        Thread thread;
        UI.Loading load;
        public JJCJScanView()
        {
            InitializeComponent();
            LURecordNO.GetData += LURecordNO_GetData;
            LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            LURecordNO.Focus();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

        }

        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            if (RecordNOData != null && LURecordNO.DisplayText.Length != 0)
            {
                string inHosTimes = BindInHosTimes(RecordNOData, LURecordNO.DisplayValue);
                txtTimes.Text = inHosTimes;
                txtStartPage.Text = "1";
                Page = 0;
                DataRow[] selectRow = RecordNOData.Select(" ID='" + LURecordNO.DisplayValue + "' ");
                string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                DateTime outDate = DateTime.Parse(selectRow[0]["OUT_HOSPITAL_DATE"].ToString());
                OutHosDate = outDate;
                string str_inHosTimes;
                if (txtTimes.Text.Length == 1)
                {
                    str_inHosTimes = "0" + txtTimes.Text;
                }
                else
                {
                    str_inHosTimes = txtTimes.Text;
                }
                string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + str_inHosTimes;
                if (!isSuccessCheckStatus(checkState, true)) return;
                //if (OnSelectPicture != null)
                //{
                //    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                //    OnSelectPicture(sender, imagesInputArgs);
                //}
                //自动生成目录
                //string PICLocalSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_LOCAL_PATH");//本地
                //CreaterFolder(PICLocalSavePath + "\\" + storagePath);
                //txtFolder.Text = PICLocalSavePath + "\\" + storagePath;
                string PICLocalSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("JJCJScanPicPath");//本地
                CreaterFolder(PICLocalSavePath);
                txtFolder.Text = PICLocalSavePath;
                txtFolder_TextChanged(null, null);
            }
        }

        void LURecordNO_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnRecordNO != null)
            {
                imagesInputArgs.RecordNO = e.SearchValue.Trim().ToUpper();
                OnRecordNO(sender, imagesInputArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ImagesInputPresenter(this);
        }
        /// <summary>
        /// 传递图片信息参数类
        /// </summary>
        Views.ImagesInputArgs imagesInputArgs = new Views.ImagesInputArgs();

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            string path = txtFolder.Text;
            if (path.Length > 0)
            {
                ckInput.Checked = false;
                pictureGrid.Visible = true;
                inputGrid.Visible = false;
                DataTable data = CreatePictureDate(path);
                pictureGrid.DataSource = data;
                if (data != null && data.Rows.Count > 0)
                {
                    pictureView.FocusedRowHandle = data.Rows.Count - 1;
                }
                txtStartPage.Text = "1";
                isReName = false;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                if (isReName)
                {
                    string count = PictureInfo.Rows.Count.ToString();
                    string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                            "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                            "共: " + count + " 张图片" + "\r\n" +
                            "是否确认入库? ";
                    if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
                    {
                        if (OnRecordNO != null)
                        {
                            imagesInputArgs.RecordNO = LURecordNO.DisplayText;
                            OnRecordNO(sender, imagesInputArgs);
                        }
                        DataRow[] selectRow = RecordNOData.Select(" ID='" + LURecordNO.DisplayValue + "' ");
                        string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                        if (!isSuccessCheckStatus(checkState, false)) return;
                        pdfViewer.FileName = "";
                        smallpdfViewer.FileName = "";
                        CopyFilesToNet(PictureInfo);//上传图片
                    }
                    else
                    {
                        return;
                    }
                    //if (Message.ShowQuery("入库成功的图片已上传至服务器,是否删除本地图片？", Message.Button.YesNo) == Message.Result.Yes)
                    //{
                    DeleteFile();
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    pdfViewer.FileName = "";
                    smallpdfViewer.FileName = "";
                    BindNull();
                    GC.Collect();
                    isReName = false;
                    //}
                    //else
                    //{
                    //    BindNull();
                    //}
                    try
                    {
                        foreach (Control cs in this.ParentForm.Controls.Find("pdfViewer", true))
                        {
                            (cs as CJia.Health.Tools.PDFViewer).FileName = "";
                        }
                        foreach (Control cs in this.ParentForm.Controls.Find("smallpdfViewer", true))
                        {
                            (cs as CJia.Health.Tools.PDFViewer).FileName = "";
                        }
                        string path = Application.StartupPath + @"\Cache";
                        if (Directory.Exists(path))
                            Directory.Delete(path, true);
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("请先进行重命名操作！");
                }
            }
        }

        private void txtTimes_Leave(object sender, EventArgs e)
        {
            string inHosTimes = txtTimes.Text;
            if (inHosTimes.Length == 0)
            {
                txtTimes.Text = "1";
            }
        }

        private void pictureView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (pictureView.GetFocusedDataRow() != null)
                {
                    DataRow focuseRow = pictureView.GetFocusedDataRow();
                    string filePath = focuseRow["Pic_Path"].ToString();
                    pdfViewer.FileName = filePath;
                    pdfViewer.Tag = filePath;
                    smallpdfViewer.FileName = filePath;
                    pictureGrid.Focus();
                }
            }
            catch { }
        }
        private void ckInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInput.Checked)
            {
                inputGrid.Visible = true;
                pictureGrid.Visible = false;
                btnDelete.Enabled = false;
                btnInput.Enabled = false;
                btnReName.Enabled = false;
                btnRefresh.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                if (OnSelectPicture != null)
                {
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnSelectPicture(sender, imagesInputArgs);
                }
                inputGrid.Focus();
            }
            else
            {
                inputGrid.Visible = false;
                pictureGrid.Visible = true;
                btnDelete.Enabled = true;
                btnInput.Enabled = true;
                btnReName.Enabled = true;
                btnRefresh.Enabled = true;
                btnLeft.Enabled = true;
                btnRight.Enabled = true;
                pictureView_FocusedRowChanged(null, null);
                pictureGrid.Focus();
            }
        }
        
        private void inputPicGridView_Click(object sender, EventArgs e)
        {
           
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
                    if (!File.Exists(downLoadFile))
                    {
                        if (File.Exists(pdfData))
                            File.Move(pdfData, downLoadFile);
                    }
                    pdfViewer.FileName = downLoadFile;
                    smallpdfViewer.FileName = downLoadFile;
                    if (OldRowHandel != -1 && OldRowHandel < inputView.RowCount)
                    {
                        DataRow dr = inputView.GetDataRow(OldRowHandel);
                        fileName = dr["PICTURE_NAME"].ToString();
                        downLoadFile = Application.StartupPath + @"\Cache\" + fileName;
                        pdfData = downLoadFile.Replace(".pdf", "");
                        if (File.Exists(downLoadFile) && pdfViewer.FileName != downLoadFile)
                            File.Move(downLoadFile, pdfData);
                    }
                }
                else
                {
                    Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
            }
            catch { }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                int i = pictureView.FocusedRowHandle;
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    pdfViewer.FileName = "";
                    smallpdfViewer.FileName = "";
                    string fileName = focuseRow["Pic_Path"].ToString();
                    File.Delete(fileName);
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    if (i == data.Rows.Count)
                    {
                        pictureView.FocusedRowHandle = i - 1;
                    }
                    else
                    {
                        pictureView.FocusedRowHandle = i;
                    }
                }
            }
        }

        private void btnSaoMiao_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                if (!msgfilter)
                {
                    this.ParentForm.Enabled = false;
                    msgfilter = true;
                    Application.AddMessageFilter(this);
                }
                Tw.Acquire();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)//刷新后，就要重命名
            {
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                pictureView.FocusedRowHandle = data.Rows.Count - 1;
                isReName = false;
            }
        }
        private void txtStartPage_Leave(object sender, EventArgs e)
        {
            if (txtStartPage.Text.Length == 0)
            {
                txtStartPage.Text = "1";
                Page = 0;
            }
        }

        private void txtStartPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Page = int.Parse(txtStartPage.Text) - 1;
            }
            catch
            {
                Page = 0;
            }
        }
        #region 内部调用方法
        /// <summary>
        /// 根据病案审核状态，提示信息
        /// </summary>
        /// <param name="checkState"></param>
        /// <returns></returns>
        public bool isSuccessCheckStatus(string checkState, bool bol)
        {
            string str_inHosTimes;
            if (txtTimes.Text.Length == 1)
            {
                str_inHosTimes = "0" + txtTimes.Text;
            }
            else
            {
                str_inHosTimes = txtTimes.Text;
            }
            string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + str_inHosTimes;
            if (checkState == "103")//已提交
            {
                MessageBox.Show("此病案为已提交审核，不能进行图片扫描");
                BindNull();
                return false;
            }
            if (checkState == "101")
            {
                MessageBox.Show("此病案为已审核通过，不能进行图片扫描");
                BindNull();
                return false;
            }
            if (checkState == "104")
            {
                MessageBox.Show("此病案为已合并，不能进行图片扫描");
                BindNull();
                return false;
            }
            if (checkState == "107" && bol == true)
            {
                if (Message.ShowQuery("此病案为合并失败，是否进行重新上传？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    string imgExtension = ConfigHelper.GetAppStrings("ImgExtension");//图片格式
                    string[] picName = FtpHelp.GetFileList(storagePath.Replace('\\', '/'), HostName, UserName, Password, imgExtension);
                    if (picName != null && picName.Length > 0)
                    {
                        for (int i = 0; i < picName.Length; i++)
                        {
                            string picPath = "ftp://" + HostName + "/" + storagePath.Replace('\\', '/') + "/" + picName[i];
                            FtpHelp.DeleteFile(picPath, UserName, Password);
                        }
                    }
                    if (OnMerge != null)
                    {
                        imagesInputArgs.MergeState = "100";
                        imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                        OnMerge(null, imagesInputArgs);
                    }
                }
                else
                {
                    BindNull();
                    return false;
                }
            }
            if (checkState == "102" && bol == true)//审核未通过
            {
                MessageBox.Show("此病案为审核未通过，请查看已入库图片的审核原因，然后进行重新上传");
            }
            return true;
        }
        public void BindNull()
        {
            LURecordNO.DisplayText = "";
            LURecordNO.Text = "";
            LURecordNO.DisplayValue = "";
            txtTimes.Text = "1";
            txtFolder.Text = "";
            txtStartPage.Text = "1";
            pictureGrid.DataSource = null;
            inputGrid.DataSource = null;
            pdfViewer.FileName = "";
            smallpdfViewer.FileName = "";
            pdfViewer.Tag = "";
        }
        /// <summary>
        /// 合并后修改图片信息
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="newPage"></param>
        public void ModifyImageInfo(DataRow dr, string newPage)
        {
            dr["Pic_Page"] = newPage;
            string subPage = dr["Pic_SubPage"].ToString();
            string str_inHosTimes;
            if (txtTimes.Text.Length == 1)
            {
                str_inHosTimes = "0" + txtTimes.Text;
            }
            else
            {
                str_inHosTimes = txtTimes.Text;
            }
            string fileName = LURecordNO.DisplayText + "_" + str_inHosTimes + "_" + newPage + "_" + subPage + dr["Pic_Extension"];
            string newfilePath = Path.GetDirectoryName(dr["Pic_Path"].ToString()) + "\\" + fileName;
            File.Move(dr["Pic_Path"].ToString(), newfilePath);
            dr["Pic_Name"] = fileName;
            dr["Pic_Path"] = newfilePath;
        }
        /// <summary>
        /// 判断图片是否空白页
        /// </summary>
        /// <param name="bp"></param>
        /// <returns></returns>
        public bool isBlankPage(Bitmap bp, int intHeight)
        {
            double bl = (intHeight / Convert.ToDouble(bp.Height));
            double intWidth = bl * Convert.ToDouble(bp.Width);
            int Width = Convert.ToInt32(intWidth);
            if (Width == 0)
            {
                Width = 1;
            }
            Bitmap smallImage = new Bitmap(bp, Width, intHeight);
            bool bol = true;
            int m = 0;
            int area = smallImage.Width * smallImage.Height;
            for (int i = 0; i < smallImage.Width; i++)
            {
                for (int j = 0; j < smallImage.Height; j++)
                {
                    Color col = smallImage.GetPixel(i, j);
                    if (col.ToArgb() == Color.White.ToArgb())
                    {
                        m++;
                    }
                }
            }
            float f = float.Parse(m.ToString()) / float.Parse(area.ToString());
            if (f < 0.99)//空白部分超过99%就认为此图片为空白图片
            {
                bol = false;
            }
            return bol;
        }
        /// <summary>
        /// 初始化时，获得最大页码
        /// </summary>
        public int InitPage()
        {
            int initPage = 0;
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                int i;
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_Name"].ToString().Substring(0, 2) == "PZ")//拍照的图片，过滤出最大的页码
                    {
                        try
                        {
                            i = int.Parse(dr["Pic_Page"].ToString());
                        }
                        catch
                        {
                            i = 0;
                        }
                        if (i > initPage)
                        {
                            initPage = i;
                        }
                    }
                }
                return initPage;
            }
            return 0;
        }
        /// <summary>
        /// 创建图片DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable PictureData()
        {
            DataTable data = new DataTable("Picture");
            data.Columns.Add("Pic_Path", typeof(string));
            data.Columns.Add("Pic_Name", typeof(string));
            data.Columns.Add("Pic_Page", typeof(string));
            data.Columns.Add("Pic_SubPage", typeof(string));
            data.Columns.Add("Pic_ProjectName", typeof(string));
            data.Columns.Add("Pic_ProjectID", typeof(string));
            data.Columns.Add("Pic_State", typeof(string));
            data.Columns.Add("Pic_Extension", typeof(string));
            data.Columns.Add("STORAGE_PATH", typeof(string));
            data.Columns.Add("LOGIC_PATH", typeof(string));
            data.Columns.Add("HEALTH_ID", typeof(string));
            return data;
        }
        /// <summary>
        /// 根据图片路径获得DataRow
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public DataTable SetPictureDataRows(DataTable data, string pathName)
        {
            string fileName = Path.GetFileNameWithoutExtension(pathName);
            DataRow row = data.NewRow();
            row["Pic_Path"] = pathName;
            row["Pic_Name"] = Path.GetFileName(pathName);
            row["Pic_Extension"] = Path.GetExtension(pathName);
            //if (fileName.Length > 0)
            //{
            //    string[] strs = fileName.Split('_');
            //    if (strs.Length >= 4)
            //    {
            //        row["Pic_Page"] = strs[strs.Length - 2];
            //        row["Pic_SubPage"] = strs[strs.Length - 1];
            //    }
            //}
            string str_inHosTimes;
            if (txtTimes.Text.Length == 1)
            {
                str_inHosTimes = "0" + txtTimes.Text;
            }
            else
            {
                str_inHosTimes = txtTimes.Text;
            }
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "/" + OutHosDate.Month.ToString() + "/" + OutHosDate.Day.ToString() + "/" + LURecordNO.DisplayText + "/" + str_inHosTimes;
            data.Rows.Add(row);
            return data;
        }
        /// <summary>
        /// 根据目录获得图片Datatable
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        public DataTable CreatePictureDate(string pathname)
        {
            if (pathname.Trim().Length == 0) { return null; }
            try
            {
                DataTable data = PictureData();
                string imgtype = "*.PDF";
                string[] ImageType = imgtype.Split('|');
                for (int i = 0; i < ImageType.Length; i++)
                {
                    string[] tmp1 = System.IO.Directory.GetFiles(pathname, ImageType[i], SearchOption.TopDirectoryOnly);
                    foreach (string str in tmp1)
                    {
                        data = SetPictureDataRows(data, str);
                    }
                }
                PictureInfo = data;
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// 上传图片到服务器上
        /// </summary>
        public void CopyFilesToNet(DataTable data)
        {
            CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力上传....", 0, data.Rows.Count);
            this.Enabled = false;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string fileName = data.Rows[i]["Pic_Path"].ToString();
                FtpHelp.UploadFile(fileName, data.Rows[i]["STORAGE_PATH"].ToString(), HostName, UserName, Password);
                waitUC.Do("执行进度(" + i + "/" + data.Rows.Count + ")");
            }
            waitUC.ParentForm.Close();
            this.Enabled = true;
        }
        /// <summary>
        /// 删除本地图片
        /// </summary>
        public void DeleteFile()
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    string fileName = dr["Pic_Path"].ToString();
                    File.Delete(fileName);
                }
            }
        }
        /// <summary>
        /// copy图片到图片目录下的子目录
        /// </summary>
        public void CopyFilesToNext(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                string fileName = dr["Pic_Path"].ToString();
                string directory = System.IO.Path.GetDirectoryName(fileName);
                CreaterFolder(directory + "\\Copy");
                File.Copy(fileName, directory + "\\Copy" + "\\" + dr["Pic_Name"], true);
                File.Delete(fileName);
            }
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderName">文件夹名</param>
        public void CreaterFolder(string folderName)
        {
            if (!Directory.Exists(folderName))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(folderName); //新建文件夹   
            }
        }
        /// <summary>
        /// 获得住院次数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string BindInHosTimes(DataTable data, string value)
        {
            DataRow[] inHosTimes = data.Select(" ID='" + value + "' ");
            return inHosTimes[0]["IN_HOSPITAL_TIME"].ToString();
        }
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnRefresh_Click(null, null);
                    return true;
                case Keys.F3:
                    btnReName_Click(null, null);
                    return true;
                case Keys.F4:
                    btnInput_Click(null, null);
                    return true;
                case Keys.F6:
                    btnDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region ImagesInputView成员
        public event EventHandler OnLoad;
        public event EventHandler<Views.ImagesInputArgs> OnInput;
        public event EventHandler<Views.ImagesInputArgs> OnProject;
        public event EventHandler<Views.ImagesInputArgs> OnRecordNO;
        public event EventHandler<Views.ImagesInputArgs> OnSelectPicture;
        public event EventHandler<Views.ImagesInputArgs> OnInputSave;
        public event EventHandler<Views.ImagesInputArgs> OnInputDelete;
        public event EventHandler<Views.ImagesInputArgs> OnReview;
        public event EventHandler<Views.ImagesInputArgs> OnMerge;
        public event EventHandler<Views.ImagesInputArgs> OnNoAgree;
        public void ExeBindPicture(DataTable data)
        {
            int i = inputView.FocusedRowHandle;
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                    dr["SRC"] = host + "/" + dr["SRC"].ToString().Replace('\\', '/');
                }
            }
            inputGrid.DataSource = data;
            InputPictureData = data;
            if (i < 0) return;
            if (i == data.Rows.Count)
            {
                inputView.FocusedRowHandle = i - 1;
            }
            else
            {
                inputView.FocusedRowHandle = i;
            }
        }
        public void ExeInit(DataTable data)
        {

        }
        public void ExeRecordNO(DataTable data)
        {
            RecordNOData = data;
            LURecordNO.DataSource = data;
            LURecordNO.DisplayField = "RECORDNO";
            LURecordNO.ValueField = "ID";
            LURecordNO.Fields = new string[,] { { "RECORDNO", "病案号" }, { "IN_HOSPITAL_TIME", "入院次数" }, { "PATIENT_NAME", "姓名" }, { "GENDER_NAME", "性别" } };
        }
        #endregion

        #region IMessageFilter 成员 及 扫描仪 图片保存
        BITMAPINFOHEADER bmi;
        Rectangle bmprect;
        IntPtr dibhand;
        IntPtr bmpptr;
        IntPtr pixptr;
        bool IMessageFilter.PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            TwainCommand Tc = Tw.PassMessage(ref m);
            if (Tc == TwainCommand.Not)
                return false;
            //if (Tc == TwainCommand.Null)//by dh
            //{
            //    return false;
            //}
            switch (Tc)
            {
                case TwainCommand.CloseRequest:
                case TwainCommand.CloseOk:
                    EndScanning();
                    Tw.CloseSrc();
                    break;
                case TwainCommand.DeviceEvent:
                    break;
                case TwainCommand.TransferReady:
                    ArrayList LstPic = Tw.TransferPictures();
                    EndScanning();
                    Tw.CloseSrc();
                    string inhosTimes = txtTimes.Text;
                    if (inhosTimes.ToString().Length == 1)
                    {
                        inhosTimes = "0" + inhosTimes;
                    }
                    for (int i = 0; i < LstPic.Count; ++i)
                    {
                        IntPtr Img = (IntPtr)LstPic[i];
                        Page++;
                        string page = SetPage(Page);
                        string fileName = LURecordNO.DisplayText + "_" + inhosTimes + "_" + page + "_00";
                        bmpptr = GlobalLock(Img);
                        pixptr = GetPixelInfo(bmpptr);
                        Gdip.SaveDIBAs(txtFolder.Text, fileName, bmpptr, pixptr);//保存图片
                    }
                    for (int i = 0; i < LstPic.Count; ++i)//回收内存
                    {
                        IntPtr Img = (IntPtr)LstPic[i];
                        Marshal.FreeHGlobal(Img);
                    }
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    if (data != null && data.Rows.Count > 0)
                    {
                        pictureView.FocusedRowHandle = data.Rows.Count - 1;
                    }
                    txtStartPage.Text = SetPage(Page + 1);
                    LstPic.Clear();
                    //GC.SuppressFinalize(this);
                    GC.Collect();//回收内存
                    //dibhand = IntPtr.Zero;
                    //bmpptr = IntPtr.Zero;
                    //pixptr = IntPtr.Zero;
                    //Marshal.FreeCoTaskMem(dibhand);
                    //Marshal.FreeCoTaskMem(bmpptr);
                    //Marshal.FreeCoTaskMem(pixptr);
                    //Marshal.FreeHGlobal(dibhand);
                    //Marshal.FreeHGlobal(bmpptr);
                    //Marshal.FreeHGlobal(pixptr);
                    break;
            }
            return true;
        }

        private string SetPage(int oldpage)
        {
            string str;
            if (oldpage.ToString().Length == 1)
            {
                str = "00" + oldpage.ToString();
            }
            else if (oldpage.ToString().Length == 2)
            {
                str = "0" + oldpage.ToString();
            }
            else
            {
                str = oldpage.ToString();
            }
            return str;
        }

        private void EndScanning()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                this.ParentForm.Enabled = true;
                this.ParentForm.Activate();
            }
        }

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,
                                                int width, int height, int xsrc, int ysrc, int start, int lines,
                                                IntPtr bitsptr, IntPtr bmiptr, int color);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string outstr);

        protected IntPtr GetPixelInfo(IntPtr bmpptr)
        {
            bmi = new BITMAPINFOHEADER();
            Marshal.PtrToStructure(bmpptr, bmi);

            bmprect.X = bmprect.Y = 0;
            bmprect.Width = bmi.biWidth;
            bmprect.Height = bmi.biHeight;

            if (bmi.biSizeImage == 0)
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

            int p = bmi.biClrUsed;
            if ((p == 0) && (bmi.biBitCount <= 8))
                p = 1 << bmi.biBitCount;
            p = (p * 4) + bmi.biSize + (int)bmpptr;
            return (IntPtr)p;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal class BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }
        #endregion

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 设定图片控件大小
        /// </summary>
        /// <param name="img"></param>
        public void BindPictureBoxSize(Image img)
        {
            //int panel_W = splitContainerControl1.Panel2.Width;
            //float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
            //cJiaPicture.Width = panel_W - 20;
            //float height = i * (panel_W - 20);
            //cJiaPicture.Height = Convert.ToInt32(height);
            //int sPic_w = smallPicture.Width;
            //smallPicture.Height = Convert.ToInt32(i * sPic_w);
            //smallPicture.Image = img;
        }
        /// <summary>
        /// 90°顺时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap Rotate90(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 90°逆时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap Rotate270(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 判断是否已经重命名
        /// </summary>
        private bool isReName = false;
        private void btnReName_Click(object sender, EventArgs e)
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                if (!isReName)
                {
                    if (Message.ShowQuery("确定从'001'开始重命名？", Message.Button.OkCancel) == Message.Result.Ok)
                    {
                        pdfViewer.FileName = "";
                        smallpdfViewer.FileName = "";
                        string recordNO = LURecordNO.DisplayText;
                        string inhosTimes = txtTimes.Text;
                        if (inhosTimes.ToString().Length == 1)
                        {
                            inhosTimes = "0" + inhosTimes;
                        }
                        for (int i = 0; i < PictureInfo.Rows.Count; i++)
                        {
                            string page = SetPage(i + 1);
                            string fileName = recordNO + "_" + inhosTimes + "_" + page + "_00" + PictureInfo.Rows[i]["Pic_Extension"];
                            string newfilePath = Path.GetDirectoryName(PictureInfo.Rows[i]["Pic_Path"].ToString()) + "\\" + fileName;
                            try
                            {
                                File.Move(PictureInfo.Rows[i]["Pic_Path"].ToString(), newfilePath);
                            }
                            catch
                            {
                                MessageBox.Show("重命名失败！");
                                return;
                            }
                            PictureInfo.Rows[i]["Pic_Name"] = fileName;
                            PictureInfo.Rows[i]["Pic_Path"] = newfilePath;
                            PictureInfo.Rows[i]["Pic_Page"] = page;
                            PictureInfo.Rows[i]["Pic_SubPage"] = "00";
                        }
                        pictureGrid.DataSource = PictureInfo;
                        isReName = true;
                        btnRefresh_Click(null, null);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("已进行过重命名操作！");
                }
            }
        }

        private void btnOneReName_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                ReName frm = new ReName();
                frm.ShowDialog();
                string page = frm.PageNO;
                if (page.Length > 0)
                {
                    if (!IsPage(page))
                    {
                        string newpage = SetPage(int.Parse(page));
                        string recordNO = LURecordNO.DisplayText;
                        string inhosTimes = txtTimes.Text;
                        if (inhosTimes.ToString().Length == 1)
                        {
                            inhosTimes = "0" + inhosTimes;
                        }
                        DataRow dr = pictureView.GetFocusedDataRow();
                        string fileName = recordNO + "_" + inhosTimes + "_" + newpage + "_00" + dr["Pic_Extension"];
                        string newfilePath = Path.GetDirectoryName(dr["Pic_Path"].ToString()) + "\\" + fileName;
                        try
                        {
                            pdfViewer.FileName = "";
                            smallpdfViewer.FileName = "";
                            File.Move(dr["Pic_Path"].ToString(), newfilePath);
                            pdfViewer.FileName = newfilePath;
                            smallpdfViewer.FileName = newfilePath;
                        }
                        catch
                        {
                            MessageBox.Show("重命名失败！");
                            return;
                        }
                        dr["Pic_Name"] = fileName;
                        dr["Pic_Path"] = newfilePath;
                        dr["Pic_Page"] = newpage;
                        dr["Pic_SubPage"] = "00";
                        pictureView.RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("存在相同的页码");
                        return;
                    }
                    if (isAllReName())
                    {
                        isReName = true;
                    }
                    else
                    {
                        isReName = false;
                    }
                }
                pictureGrid.Focus();
            }
        }

        public bool IsPage(string page)
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_Page"].ToString().Length > 0)
                    {
                        if (int.Parse(dr["Pic_Page"].ToString()) == int.Parse(page))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (pictureView.GetFocusedDataRow() == null)
            {
                btnOneReName.Enabled = false;
            }
            else
            {
                btnOneReName.Enabled = true;
            }
        }
        /// <summary>
        /// 判断是否全部重命名
        /// </summary>
        /// <returns></returns>
        private bool isAllReName()
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_Page"].ToString().Length == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int OldRowHandel = -1;
        private void inputView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (inputView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = inputView.GetFocusedDataRow();
                Loading(focuseRow["SRC"].ToString());
                inputGrid.Focus();
                OldRowHandel = inputView.FocusedRowHandle;
            }
        }
    }
}
