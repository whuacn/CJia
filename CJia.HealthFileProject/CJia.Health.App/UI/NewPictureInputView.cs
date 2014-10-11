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

namespace CJia.Health.App.UI
{
    public partial class NewPictureInputView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView, IMessageFilter
    {
        public event EventHandler<Views.ImagesInputArgs> OnShortKeyDown;
        public void ExeBindProjectByShortKey(DataTable data)
        { }
        private int begin_x;        //图片开始位置
        private int begin_y;
        private Image image_ori;    //最原始的图片
        private Image image_dest;   //经缩放后的图片
        private float zoom;           //缩小放大百份比，每10%为一个阶梯。每次缩放都基于最原始的图片
        private Point m_StarPoint = Point.Empty;        //for 拖动
        private Point m_ViewPoint = Point.Empty;
        private bool m_StarMove = false;
        int w;                      //缩放后的图片大小
        int h;

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
        /// 图片缓存(已入库)
        /// </summary>
        //private CJia.Health.Tools.ImageCache ImageCancheForInput;
        public NewPictureInputView()
        {
            InitializeComponent();
            LURecordNO.GetData += LURecordNO_GetData;
            LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            axCmCaptureOcx1.Visible = false;
        }

        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            if (RecordNOData != null && LURecordNO.DisplayText.Length != 0)
            {
                string inHosTimes = BindInHosTimes(RecordNOData, LURecordNO.DisplayValue);
                txtTimes.Text = inHosTimes;
                txtPage.Text = "001";
                txtSubPage.Text = "00";
                Page = 0;
                DataRow[] selectRow = RecordNOData.Select(" ID='" + LURecordNO.DisplayValue + "' ");
                string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                DateTime outDate = DateTime.Parse(selectRow[0]["OUT_HOSPITAL_DATE"].ToString());
                OutHosDate = outDate;
                if (checkState == "101" || checkState == "103")//审核通过 已提交
                {
                    MessageBox.Show("此病案信息已提交审核或者已审核通过，不能进行图片入库，请联系管理员");
                    LURecordNO.DisplayText = "";
                    LURecordNO.Text = "";
                    LURecordNO.DisplayValue = "";
                    txtTimes.Text = "1";
                    txtFolder.Text = "";
                    pictureGrid.DataSource = null;
                    inputGrid.DataSource = null;
                    cJiaPicture.Image = null;
                    return;
                }
                if (checkState == "102")//审核未通过
                {
                    MessageBox.Show("此病案信息审核未通过，请查看已入库图片的审核原因，然后进行重新上传");
                }
                if (OnSelectPicture != null)
                {
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnSelectPicture(sender, imagesInputArgs);
                }
                //自动生成目录
                string PICLocalSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_LOCAL_PATH");//本地
                string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + SetImagePage()[0];
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

        private void cJiaPicture_EditValueChanged(object sender, EventArgs e)
        {
            homepanel.Visible = false;
        }

        private void ckModel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModel.Checked)
            {
                axCmCaptureOcx1.Visible = true;
                InitHighshotMeter();//初始化高拍仪
                cJiaPicture.Visible = false;
                homepanel.Visible = false;
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
                cJiaPicture.Visible = true;
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

        bool isMergeSuccess = false;
        private void btnInput_Click(object sender, EventArgs e)
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_Name"].ToString().Substring(0, 2) == "PZ")
                    {
                        isMergeSuccess = true;
                        break;
                    }
                }
                if (isMergeSuccess)
                {
                    MessageBox.Show("请先合并页码");
                    isMergeSuccess = false;
                    return;
                }
                string count = PictureInfo.Rows.Count.ToString();
                string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                        "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                        "共: " + count + " 张图片" + "\r\n" +
                        "是否确认入库? ";
                if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
                {
                    CopyFilesToNet(PictureInfo);//上传图片
                }
                else
                {
                    return;
                }
                if (Message.ShowQuery("入库成功的图片已上传至服务器,是否删除本地图片？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    DeleteFile();
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    cJiaPicture.Image = null;
                }
                else
                {

                }
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

        private void LURecordNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void pictureGrid_Click(object sender, EventArgs e)
        {

        }
        private void pictureView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                FileStream fs = new FileStream(focuseRow["Pic_Path"].ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Bitmap bt = new Bitmap(fs);
                int panel_W = splitContainerControl1.Panel2.Width;
                float i = float.Parse(bt.Height.ToString()) / float.Parse(bt.Width.ToString());
                cJiaPicture.Width = panel_W - 20;
                float height = i * (panel_W - 20);
                cJiaPicture.Height = Convert.ToInt32(height);
                cJiaPicture.Image = bt;
                cJiaPicture.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                fs.Close();//关键  释放资源
                splitContainerControl1.Panel2.AutoScrollPosition = new Point(0, 0);

                int sPic_w = smallPicture.Width;
                smallPicture.Height = Convert.ToInt32(i * sPic_w);
                smallPicture.Image = bt;
                //smallPicture.Refresh();
                //int new_height = ((panel_W - 20) / bt.Width) * bt.Height;
                //Bitmap map = new Bitmap(bt, cJiaPicture.Width, cJiaPicture.Height);
                //image_ori = bt;
                //begin_x = 0;
                //begin_y = 0;
                //zoom = 100;
                //txtPage.Text = focuseRow["Pic_Page"].ToString();
                //txtSubPage.Text = focuseRow["Pic_SubPage"].ToString();
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
                btnSaoMiao.Enabled = false;
                btnRefresh.Enabled = false;
                btnMerge.Enabled = false;
            }
            else
            {
                inputGrid.Visible = false;
                pictureGrid.Visible = true;
                btnDelete.Enabled = true;
                btnInput.Enabled = true;
                btnSaoMiao.Enabled = true;
                btnRefresh.Enabled = true;
                btnMerge.Enabled = true;
            }
        }

        private void inputPicGridView_Click(object sender, EventArgs e)
        {
            if (inputView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = inputView.GetFocusedDataRow();
                //Image img = ImageCancheForInput.GetImageStream(focuseRow["SRC"].ToString());
                FileStream fs = new FileStream(focuseRow["SRC"].ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Bitmap img = new Bitmap(fs);
                int panel_W = splitContainerControl1.Panel2.Width;
                float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                cJiaPicture.Width = panel_W - 20;
                float height = i * (panel_W - 20);
                cJiaPicture.Height = Convert.ToInt32(height);
                cJiaPicture.Image = img;
                fs.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                int i = pictureView.FocusedRowHandle;
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
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

        private void btnSaoMiao_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                //if (!msgfilter)
                //{
                //    //this.Enabled = false;
                //    msgfilter = true;
                //    Application.AddMessageFilter(this);
                //}
                //Tw.Acquire();
                btnSaoMiao.Enabled = false;
                string path = txtFolder.Text;
                string recordNO = LURecordNO.DisplayText;
                string inhosTimes = txtTimes.Text;
                UI.ScanForm frm = new ScanForm(path, recordNO, inhosTimes);
                frm.OnRefresh += frm_OnRefresh;
                frm.OnGetFocus += frm_OnGetFocus;
                frm.Show();
            }
        }

        void frm_OnGetFocus(object sender, EventArgs e)
        {
            this.ParentForm.Activate();
        }

        void frm_OnRefresh(object sender, EventArgs e)
        {
            this.ParentForm.Activate();
            if (ScanForm.isSuccessEnd)
            {
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                if (data != null && data.Rows.Count > 0)
                {
                    pictureView.FocusedRowHandle = data.Rows.Count - 1;
                }
            }
            btnSaoMiao.Enabled = true;
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int page = int.Parse(txtPage.Text);
                //Page = page - 1;
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
            }
        }
        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null && PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                bool isModify = false;
                CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在进行合并....", 0, PictureInfo.Rows.Count);
                this.Enabled = false;
                Bitmap myBitmap;
                List<string> SMpageList = new List<string>();
                List<string> PZpageList = new List<string>();
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    int j = PictureInfo.Rows.IndexOf(dr);
                    waitUC.Do("执行进度(" + j + "/" + PictureInfo.Rows.Count + ")");
                    if (dr["Pic_Name"].ToString().Substring(0, 2) != "PZ")
                    {
                        FileStream fs = new FileStream(dr["Pic_Path"].ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        myBitmap = new Bitmap(fs);
                        fs.Close();
                        if (isBlankPage(myBitmap, 100))
                        {
                            SMpageList.Add(dr["Pic_Page"].ToString());//把空白图片的页码存起来
                        }
                    }
                }
                waitUC.ParentForm.Close();
                this.Enabled = true;
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_Name"].ToString().Substring(0, 2) == "PZ")
                    {
                        if (!PZpageList.Contains(dr["Pic_Page"].ToString()))
                        {
                            PZpageList.Add(dr["Pic_Page"].ToString());
                        }
                    }
                }
                if (SMpageList.Count != 0 && SMpageList.Count == PZpageList.Count && PZpageList.Count != 0)
                {
                    isModify = true;
                    for (int i = 0; i < SMpageList.Count; i++)
                    {
                        foreach (DataRow dr in PictureInfo.Rows)
                        {
                            if (dr["Pic_Name"].ToString().Substring(0, 2) != "PZ")
                            {
                                if (dr["Pic_Page"].ToString() == SMpageList[i])
                                {
                                    File.Delete(dr["Pic_Path"].ToString());//删除空白图片
                                }
                            }
                            if (dr["Pic_Name"].ToString().Substring(0, 2) == "PZ")
                            {
                                if (dr["Pic_Page"].ToString() == PZpageList[i])
                                {
                                    try
                                    {
                                        string SMPage = SMpageList[i];
                                        ModifyImageInfo(dr, SMPage);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("空白图片张数与拍照图片页码张数不符，不能继续进行合并");
                    isModify = false;
                }
                if (isModify)
                {
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                }
            }
        }

        #region 内部调用方法
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
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + SetImagePage()[0];
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
                string imgtype = "*.BMP|*.JPG|*.GIF|*.PNG";
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
            CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力上传....", 0, data.Rows.Count);
            this.Enabled = false;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                CreaterFolder(CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + data.Rows[i]["STORAGE_PATH"].ToString());
                string fileName = data.Rows[i]["Pic_Path"].ToString();
                File.Copy(fileName, CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + data.Rows[i]["STORAGE_PATH"] + "\\" + data.Rows[i]["Pic_Name"], true);
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
                case Keys.F2:
                    btnTakePhoto_Click(null, null);
                    return true;
                case Keys.F1:
                    btnSaoMiao_Click(null, null);
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
            if (data != null)
            {
                //List<string> path = new List<string>();
                foreach (DataRow dr in data.Rows)
                {
                    dr["SRC"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + dr["SRC"];
                    //path.Add(dr["SRC"].ToString());
                }
                //if (path != null && path.Count > 0)
                //{
                //    using (ImageCancheForInput = new Tools.ImageCache(path))
                //    {
                //        ImageCancheForInput.DowImageStream();
                //    }
                //}
            }
            inputGrid.DataSource = data;
            InputPictureData = data;
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
            if (Tc == TwainCommand.Null)//by dh
            {
                return false;
            }
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
                    ArrayList LstPic = Tw.TransferPictures();//点击扫描按钮
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
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    if (data != null && data.Rows.Count > 0)
                    {
                        pictureView.FocusedRowHandle = data.Rows.Count - 1;
                    }
                    //txtPage.Text = SetPage(Page + 1);
                    break;
                //case TwainCommand.Null://by dh
                //    EndScanning();
                //    Tw.CloseSrc();
                //    break;
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
                //this.Enabled = true;
                //this.ParentForm.Activate();
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
            axCmCaptureOcx1.StartRun(0); //开启视频
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
            string fileName = "PZ_" + LURecordNO.DisplayText + "_" + strs[0] + "_" + strs[1] + "_" + strs[2] + CJia.Health.Tools.ConfigHelper.GetAppStrings("ImgExtension");
            string filePath = txtFolder.Text + "\\" + fileName;
            string[] tmp1 = System.IO.Directory.GetFiles(txtFolder.Text, "*.JPG");
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
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                    pictureView.FocusedRowHandle = data.Rows.Count - 1;
                    PageIdentity();
                }
            }
            else
            {
                axCmCaptureOcx1.CaptureImage(filePath);         //拍照保存图片
                DataTable data = CreatePictureDate(txtFolder.Text);
                pictureGrid.DataSource = data;
                pictureView.FocusedRowHandle = data.Rows.Count - 1;
                PageIdentity();
            }
        }
        #endregion

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

        private void cJiaPicture_MouseDown(object sender, MouseEventArgs e)
        {
            cJiaPicture.Cursor = Cursors.Hand;
            m_StarMove = true;
            m_StarPoint = e.Location;
        }

        private void cJiaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_StarMove)
            {
                int Grasp_y = splitContainerControl1.Panel2.AutoScrollPosition.Y;
                int x, y;
                int move_y; //滚动的位置
                x = m_StarPoint.X - e.X;
                y = m_StarPoint.Y - e.Y;
                if (Grasp_y - y > 0) move_y = 0;
                else move_y = Grasp_y - y;
                splitContainerControl1.Panel2.AutoScrollPosition = new Point(0, Math.Abs(move_y));
            }
        }

        private void cJiaPicture_MouseUp(object sender, MouseEventArgs e)
        {
            //if (m_StarMove)
            //{
            //    int Grasp_y = splitContainerControl1.Panel2.AutoScrollPosition.Y;
            //    int x, y;
            //    int move_y; //滚动的位置
            //    x = m_StarPoint.X - e.X;
            //    y = m_StarPoint.Y - e.Y;
            //    //if (x > 0)
            //    //{
            //    //    if (begin_x + x <= w - cJiaPicture.Width) begin_x += x;
            //    //    else begin_x = w - cJiaPicture.Width;
            //    //}
            //    //else
            //    //{
            //    //    if (begin_x + x <= 0) begin_x = 0;
            //    //    else begin_x += x;
            //    //}
            //    //if (y > 0)
            //    //{
            //    //    if (begin_y + y <= h - cJiaPicture.Height) begin_y += y;
            //    //    else begin_y = h - cJiaPicture.Height;
            //    //}
            //    //else
            //    //{
            //    //    if (begin_y + y <= 0) begin_y = 0;
            //    //    else begin_y += y;
            //    //}
            //    if (Grasp_y - y > 0) move_y = 0;
            //    else move_y = Grasp_y - y;
            //    //zoom_image(false);
            //    splitContainerControl1.Panel2.AutoScrollPosition = new Point(0, Math.Abs(move_y));
            //}
            m_StarMove = false;
            cJiaPicture.Cursor = Cursors.Default;
        }

        private void zoom_image(bool chec)
        {
            w = Convert.ToInt32(image_ori.Width * zoom / 100);
            h = Convert.ToInt32(image_ori.Height * zoom / 100);
            if (w < 1 || h < 1) return;
            if (chec)
            {
                if (begin_x + cJiaPicture.Width > w) begin_x = w - cJiaPicture.Width;
                if (begin_y + cJiaPicture.Height > h) begin_y = h - cJiaPicture.Height;
                if (begin_x < 0) begin_x = 0;
                if (begin_y < 0) begin_y = 0;
            }
            Bitmap resizedBmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(resizedBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.DrawImage(image_ori, new Rectangle(0, 0, w, h), new Rectangle(0, 0, image_ori.Width, image_ori.Height), GraphicsUnit.Pixel);

            int ww, hh;
            ww = w;
            hh = h;
            if (cJiaPicture.Width < ww) ww = cJiaPicture.Width;
            if (cJiaPicture.Height < hh) hh = cJiaPicture.Height;
            try
            {
                cJiaPicture.Image = resizedBmp.Clone(new RectangleF((float)begin_x, (float)begin_y, ww, hh), PixelFormat.Format24bppRgb);   //在图片框上显示区域图片
            }
            catch
            {

            }
            g.Dispose();
        }

    }
}
