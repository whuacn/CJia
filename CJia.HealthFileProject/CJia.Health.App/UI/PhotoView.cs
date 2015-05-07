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
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class PhotoView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView
    {
        public event EventHandler<ImagesInputArgs> OnShortKeyDown;
        public void ExeBindProjectByShortKey(DataTable data) { }
        private Point m_StarPoint = Point.Empty;        //for 拖动
        private Point m_ViewPoint = Point.Empty;
        private bool m_StarMove = false;

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
        public PhotoView()
        {
            InitializeComponent();
            LURecordNO.GetData += LURecordNO_GetData;
            LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            axCmCaptureOcx1.Visible = false;
            LURecordNO.Focus();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            pdfViewer.StylePDF = PDFViewer.PDFStyle.All;
            pdfViewer.ZoomLevel = 3;
            smallpdfViewer.StylePDF = PDFViewer.PDFStyle.single;
            smallpdfViewer.ZoomLevel = 1;
        }

        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            if (RecordNOData != null && LURecordNO.DisplayText.Length != 0)
            {
                string inHosTimes = BindInHosTimes(RecordNOData, LURecordNO.DisplayValue);
                txtTimes.Text = inHosTimes;
                txtPage.Text = "001";
                txtSubPage.Text = "00";
                DataRow[] selectRow = RecordNOData.Select(" ID='" + LURecordNO.DisplayValue + "' ");
                string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                DateTime outDate = DateTime.Parse(selectRow[0]["OUT_HOSPITAL_DATE"].ToString());
                OutHosDate = outDate;
                string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + SetImagePage()[0];
                if (!isSuccessCheckStatus(checkState, true)) return;
                //未提交的病案都可以继续图片入库
                //if (OnSelectPicture != null)
                //{
                //    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                //    OnSelectPicture(sender, imagesInputArgs);
                //}
                //自动生成目录
                string PICLocalSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_LOCAL_PATH");//本地
                CreaterFolder(PICLocalSavePath + "\\" + storagePath);
                txtFolder.Text = PICLocalSavePath + "\\" + storagePath;
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
                txtPage.Text = SetPage(InitPage() + 1);
            }
        }

        private void ckModel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModel.Checked)
            {
                axCmCaptureOcx1.Visible = true;
                InitHighshotMeter();//初始化高拍仪
                pdfViewer.Visible = false;
                ckPage.Checked = true;
                btnTakePhoto.Enabled = true;
                ckZiDong.Visible = true;
                ckShouDong.Visible = true;
                btnRight.Visible = true;
                btnLeft.Visible = true;
                pnlRight.Visible = true;
            }
            else
            {
                btnTakePhoto.Enabled = false;
                ckPage.Checked = false;
                pdfViewer.Visible = true;
                axCmCaptureOcx1.Visible = false;
                axCmCaptureOcx1.Destory();//停止拍摄
                btnTakePhoto.Enabled = false;
                ckZiDong.Visible = false;
                ckShouDong.Visible = false;
                btnRight.Visible = false;
                btnLeft.Visible = false;
                pnlRight.Visible = false;
            }
        }

        private void ckPage_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPage.Checked)
            {
                txtPage.Properties.ReadOnly = false;
                txtSubPage.Properties.ReadOnly = false;
            }
            else
            {
                txtPage.Properties.ReadOnly = true;
                txtSubPage.Properties.ReadOnly = true;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
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
                DeleteFile();
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                pdfViewer.FileName = "";
                BindNull();
            }
        }

        private void txtPage_Leave(object sender, EventArgs e)
        {
            try
            {
                string page = txtPage.Text;
                if (txtPage.Text.Length == 0)
                {
                    txtPage.Text = "001";
                }
                if (txtPage.Text.Length == 1)
                {
                    txtPage.Text = "00" + page;
                }
                if (txtPage.Text.Length == 2)
                {
                    txtPage.Text = "0" + page;
                }
                if (int.Parse(txtPage.Text) == 0)
                {
                    txtPage.Text = "001";
                }
            }
            catch
            {
                txtPage.Text = "001";
            }
        }

        private void txtSubPage_Leave(object sender, EventArgs e)
        {
            try
            {
                string subpage = txtSubPage.Text;
                if (txtSubPage.Text.Length == 0)
                {
                    txtSubPage.Text = "00";
                }
                if (txtSubPage.Text.Length == 1)
                {
                    txtSubPage.Text = "0" + subpage;
                }
            }
            catch
            {
                txtSubPage.Text = "00";
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
                    smallpdfViewer.FileName = filePath;
                    pictureGrid.Focus();
                }
            }
            catch (Exception ex)
            {
                NlogMonitor.LogMonitor.Error(ex.Message);
            }
        }
        private void ckInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInput.Checked)
            {
                inputGrid.Visible = true;
                pictureGrid.Visible = false;
                btnDelete.Enabled = false;
                btnInput.Enabled = false;
                btnRefresh.Enabled = false;
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
                btnRefresh.Enabled = true;
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
                    pdfViewer.FileName = downLoadFile.Replace(".pdf","");
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

        private void ckSubPage_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModel.Checked && ckSubPage.Checked)
            {
                txtSubPage.Text = "01";
            }
            if (ckModel.Checked && !ckSubPage.Checked)
            {
                txtSubPage.Text = "00";
                txtPage.Text = SetPage(InitPage() + 1);
            }
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            if (ckModel.Checked && LURecordNO.DisplayText.Length > 0 && txtFolder.Text.Length > 0)
            {
                CaptureImage();//拍照
            }
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int page = int.Parse(txtPage.Text);
                if (ckSubPage.Checked)
                {
                    txtSubPage.Text = "01";
                }
                else
                {
                    txtSubPage.Text = "00";
                }
            }
            catch
            {
                //Page = 0;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                pictureView.FocusedRowHandle = data.Rows.Count - 1;
                txtPage.Text = SetPage(InitPage() + 1);
            }
        }
        private void ckZiDong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckZiDong.Checked)
                axCmCaptureOcx1.AutoCrop(1);
            else
                axCmCaptureOcx1.AutoCrop(0);
        }

        private void ckShouDong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShouDong.Checked)
                axCmCaptureOcx1.CusCrop(1);
            else
                axCmCaptureOcx1.CusCrop(0);
        }
        private int i = 0;
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (i < 3)
            {
                i = i + 1;
                axCmCaptureOcx1.RotateVideo(i);
            }
            else
            {
                i = 0;
                axCmCaptureOcx1.RotateVideo(0);
            }
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i = i - 1;
                axCmCaptureOcx1.RotateVideo(i);
            }
            else
            {
                i = 3;
                axCmCaptureOcx1.RotateVideo(i);
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
            string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + SetImagePage()[0];
            if (checkState == "103")//已提交
            {
                MessageBox.Show("此病案为已提交审核，不能进行图片拍照上传");
                BindNull();
                return false;
            }
            if (checkState == "101")
            {
                MessageBox.Show("此病案为已审核通过，不能进行图片拍照上传");
                BindNull();
                return false;
            }
            if (checkState == "104")
            {
                MessageBox.Show("此病案为已合并，不能进行图片拍照上传");
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
                MessageBox.Show("此病案为审核未通过，请查看已入库图片的审核原因，然后进行重新拍照上传");
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
            pictureGrid.DataSource = null;
            inputGrid.DataSource = null;
            pdfViewer.FileName = "";
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
            string inhosTimes = SetImagePage()[0];
            string fileName = LURecordNO.DisplayText + "_" + inhosTimes + "_" + newPage + "_" + subPage + dr["Pic_Extension"];
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
            if (fileName.Length > 0)
            {
                string[] strs = fileName.Split('_');
                if (strs.Length >= 4)
                {
                    row["Pic_Page"] = strs[strs.Length - 2];
                    row["Pic_SubPage"] = strs[strs.Length - 1];
                }
            }
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "/" + OutHosDate.Month.ToString() + "/" + OutHosDate.Day.ToString() + "/" + LURecordNO.DisplayText + "/" + SetImagePage()[0];
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
        /// 设定Image名称，根据住院次数，页码，附加码
        /// </summary>
        public string[] SetImagePage()
        {
            string inhosTimes = "";
            string page = "";
            string subPage = "";
            string[] strs = new string[3];
            if (txtTimes.Text.Length > 0 && txtPage.Text.Length > 0 && txtSubPage.Text.Length > 0)
            {
                if (txtTimes.Text.Length == 1)
                {
                    inhosTimes = "0" + txtTimes.Text;
                }
                else
                {
                    inhosTimes = txtTimes.Text;
                }
                if (txtPage.Text.Length == 1)
                {
                    page = "00" + txtPage.Text;
                }
                else if (txtPage.Text.Length == 2)
                {
                    page = "0" + txtPage.Text;
                }
                else
                {
                    page = txtPage.Text;
                }
                if (txtSubPage.Text.Length == 1)
                {
                    subPage = "0" + txtSubPage.Text;
                }
                else
                {
                    subPage = txtSubPage.Text;
                }
                strs[0] = inhosTimes;
                strs[1] = page;
                strs[2] = subPage;
                return strs;
            }
            else
            {
                MessageBox.Show("页码设定和住院次数不能为空");
                return null;
            }
        }
        /// <summary>
        /// 拍完一张 页码自增1
        /// </summary>
        public void PageIdentity()
        {
            int page = int.Parse(txtPage.Text);
            int subPage = int.Parse(txtSubPage.Text);
            int newSubPage = subPage + 1;
            if (!ckSubPage.Checked)
            {
                int newPage = page + 1;
                if (newPage.ToString().Length == 1)
                {
                    txtPage.Text = "00" + newPage.ToString();
                }
                if (newPage.ToString().Length == 2)
                {
                    txtPage.Text = "0" + newPage.ToString();
                }
                if (newPage.ToString().Length == 3)
                {
                    txtPage.Text = newPage.ToString();
                }
            }
            if (ckSubPage.Checked)
            {
                if (newSubPage.ToString().Length == 1)
                {
                    txtSubPage.Text = "0" + newSubPage.ToString();
                }
                if (newSubPage.ToString().Length == 2)
                {
                    txtSubPage.Text = newSubPage.ToString();
                }
            }
        }
        /// <summary>
        /// 上传图片到服务器上
        /// </summary>
        public void CopyFilesToNet(DataTable data)
        {
            string pdsPassword = PDFPassword;
            CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力上传....", 0, data.Rows.Count);
            this.Enabled = false;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string fileName = data.Rows[i]["Pic_Path"].ToString();
                PDFHelp.EncryptionPDF(fileName, pdsPassword);//上传加密
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
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    btnTakePhoto_Click(null, null);
                    return true;
                case Keys.F5:
                    btnRefresh_Click(null, null);
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

        #region 高拍仪
        /// <summary>
        /// 初始化高拍仪
        /// </summary>
        public void InitHighshotMeter()
        {
            int i = axCmCaptureOcx1.Initial();//初始化
            if (i == -2)
            {
                MessageBox.Show("请检查设备是否已连接上。。。");
                return;
            }
            int NO;
            try
            {
                NO = int.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("CmCaptureNO"));
            }
            catch
            {
                NO = 0;
            }
            axCmCaptureOcx1.StartRun(NO); //开启视频
            axCmCaptureOcx1.AutoFocus();//自动对焦
            if (ckZiDong.Checked)
                axCmCaptureOcx1.AutoCrop(1);//自动裁切纠偏
            axCmCaptureOcx1.SetResolution(0);//设置分辨率
            axCmCaptureOcx1.SetFileType(1);//设置图片保存格式  .jpg
            axCmCaptureOcx1.SetImageColorMode(0);//设置颜色格式   彩色
            //axCmCaptureOcx1.SetImageDPI(250);//设置DPI
            //axCmCaptureOcx1.SetJpgQuanlity(100);
            axCmCaptureOcx1.DragVideo(0);
        }
        /// <summary>
        /// 拍照
        /// </summary>
        public void CaptureImage()
        {
            string[] strs = SetImagePage();
            if (strs[0].Length == 0) return;
            //图片名称 S_123456_01_001_00
            string fileName = "PZ_" + LURecordNO.DisplayText + "_" + strs[0] + "_" + strs[1] + "_" + strs[2] + ".jpg";
            string filePath = txtFolder.Text + "\\" + fileName;
            string[] tmp1 = System.IO.Directory.GetFiles(txtFolder.Text, "*.PDF");
            bool isHave = false;
            foreach (string s in tmp1)
            {
                if (s == filePath)
                {
                    isHave = true;
                }
            }
            if (isHave)
            {
                if (Message.ShowQuery("文件已存在，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    axCmCaptureOcx1.CaptureImage(filePath);         //拍照保存图片
                    string pdfPath = filePath.Split('.')[0] + ".pdf";
                    CJia.Health.Tools.PDFHelp.ConvertJPG2PDF(filePath, pdfPath);
                    File.Delete(filePath);
                    CJia.Health.Tools.PDFHelp.SetWatermark(pdfPath, LogoName, PDFPassword, LogoInclination);
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    pictureView.FocusedRowHandle = data.Rows.Count - 1;
                    PageIdentity();
                }
            }
            else
            {
                axCmCaptureOcx1.CaptureImage(filePath);         //拍照保存图片
                string pdfPath = filePath.Split('.')[0] + ".pdf";
                CJia.Health.Tools.PDFHelp.ConvertJPG2PDF(filePath, pdfPath);
                File.Delete(filePath);
                CJia.Health.Tools.PDFHelp.SetWatermark(pdfPath, LogoName, PDFPassword, LogoInclination);
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                pictureView.FocusedRowHandle = data.Rows.Count - 1;
                PageIdentity();
            }
        }
        #endregion
        private void inputView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (inputView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = inputView.GetFocusedDataRow();
                Loading(focuseRow["SRC"].ToString());
                inputGrid.Focus();
            }
        }
    }
}
