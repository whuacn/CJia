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
using System.Runtime.InteropServices;

namespace CJia.Health.App.UI
{
    public partial class MergeView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView
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
        /// 审核状态
        /// </summary>
        private string CheckState;
        /// <summary>
        /// ftp 主机ip
        /// </summary>
        private string HostName = ConfigHelper.GetAppStrings("ftp_ip");
        /// <summary>
        /// ftp 用户名
        /// </summary>
        private string UserName = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_userName"));
        /// <summary>
        /// ftp 用户密码
        /// </summary>
        private string Password = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_password"));
        //Thread thread;
        //UI.Loading load;
        public MergeView()
        {
            InitializeComponent();
            LURecordNO.GetData += LURecordNO_GetData;
            LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            lblMesg.Text = "";
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            NoBlankPage = new List<string>();
            lblNoBlank.Text = "";
        }

        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            if (RecordNOData != null && LURecordNO.DisplayText.Length != 0)
            {
                string inHosTimes = BindInHosTimes(RecordNOData, LURecordNO.DisplayValue);
                txtTimes.Text = inHosTimes;
                Page = 0;
                DataRow[] selectRow = RecordNOData.Select(" ID='" + LURecordNO.DisplayValue + "' ");
                string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                CheckState = checkState;
                DateTime outDate = DateTime.Parse(selectRow[0]["OUT_HOSPITAL_DATE"].ToString());
                OutHosDate = outDate;
                if (checkState == "103")//已提交 104已合并 107合并失败
                {
                    MessageBox.Show("此病案为已提交审核，不能进行图片合并");
                    BindNull();
                    return;
                }
                if (checkState == "101")//审核通过
                {
                    MessageBox.Show("此病案为审核通过，不能进行图片合并");
                    BindNull();
                    return;
                }
                if (checkState == "102")//审核未通过
                {
                    //分类错误

                    //图片不清晰，某些图片重拍了

                    //新拍了些图片
                }
                if (checkState == "104")//已合并
                {
                    MessageBox.Show("此病案为已合并,不能继续合并");
                    BindNull();
                    return;
                }
                if (checkState == "107")//合并失败
                {
                    MessageBox.Show("此病案为合并失败,请对此份病案重新录入");
                    BindNull();
                    return;
                }
                //自动生成目录
                DataTable data = CreatePictureDate();
                pictureGrid.DataSource = data;
                lblMesg.Text = "";
                lblNoBlank.Text = "";
                SMAllpageList = new List<string>();
                NoBlankPage = new List<string>();
            }
        }

        public void BindNull()
        {
            LURecordNO.DisplayText = "";
            LURecordNO.Text = "";
            LURecordNO.DisplayValue = "";
            txtTimes.Text = "1";
            pictureGrid.DataSource = null;
            pdfViewer.FileName = "";
            LURecordNO.Focus();
            lblMesg.Text = "";
            lblNoBlank.Text = "";
            SMAllpageList = new List<string>();
            NoBlankPage = new List<string>();
            
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
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                Loading(focuseRow["Pic_Path"].ToString());
                pictureGrid.Focus();
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
                    pdfViewer.FileName = pdfData;
                }
                else
                {
                    Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
            }
            catch { }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (LURecordNO.DisplayText.Length > 0)
            {
                lblMesg.Text = "";
                SMAllpageList = null;
                DataTable data = CreatePictureDate();
                pictureGrid.DataSource = data;
            }
        }
        /// <summary>
        /// 扫描空白页
        /// </summary>
        private List<string> SMAllpageList;
        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null && PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                bool isModify = false;
                CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在处理....", 0, PictureInfo.Rows.Count);
                this.Enabled = false;
                Image img;
                List<string> SMpageList = new List<string>();
                List<string> PZpageList = new List<string>();
                try
                {
                    foreach (DataRow dr in PictureInfo.Rows)
                    {
                        int j = PictureInfo.Rows.IndexOf(dr);
                        waitUC.Do("执行进度(" + j + "/" + PictureInfo.Rows.Count + ")");
                        if (dr["Pic_Name"].ToString().Substring(0, 2) != "PZ")
                        {
                            //img = Tools.Help.GetImageByUri(dr["Pic_Path"].ToString(), UserName, Password);
                            //string isjjfb = CJia.Health.Tools.ConfigHelper.GetAppStrings("isJJCJBlank");
                            //if (isjjfb == "0")//妇保
                            //{
                            //    if (isBlankPage((Bitmap)img, 400))
                            //    {
                            //        SMpageList.Add(dr["Pic_Page"].ToString());//把空白图片的页码存起来
                            //    }
                            //}
                            //else //创佳
                            //{
                            //    if (isBlankPage((Bitmap)img, 200))
                            //    {
                            //        SMpageList.Add(dr["Pic_Page"].ToString());//把空白图片的页码存起来
                            //    }
                            //}
                        }
                    }
                    waitUC.ParentForm.Close();
                    this.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("图片不存在或已删除，请与管理员联系。。。");
                    waitUC.ParentForm.Close();
                    this.Enabled = true;
                }
                if (SMpageList.Count > 0)//排除设置为非空白页的页码
                {
                    if (NoBlankPage != null && NoBlankPage.Count > 0)
                    {
                        foreach (string noBP in NoBlankPage)
                        {
                            try
                            {
                                SMpageList.Remove(noBP);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
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
                if (SMpageList.Count == 0 && PZpageList.Count == 0)
                {
                    if (Message.ShowQuery("只存在扫描的图片,是否继续合并?", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        Merge("104");
                        isModify = true;
                    }
                }
                else if (SMpageList.Count == 0 && PZpageList.Count != 0)
                {
                    if (Message.ShowQuery("只存在拍照的图片,是否继续合并?", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        foreach (DataRow dr in PictureInfo.Rows)
                        {
                            if (dr["Pic_Name"].ToString().Substring(0, 2) == "PZ")
                            {
                                RemovePZ(dr);
                            }
                        }
                        Merge("104");
                        isModify = true;
                    }
                }
                else if (SMpageList.Count != 0 && SMpageList.Count == PZpageList.Count && PZpageList.Count != 0)
                {
                    for (int i = 0; i < SMpageList.Count; i++)
                    {
                        foreach (DataRow dr in PictureInfo.Rows)
                        {
                            if (dr["Pic_Name"].ToString().Substring(0, 2) != "PZ")
                            {
                                if (dr["Pic_Page"].ToString() == SMpageList[i])
                                {
                                    //File.Delete(dr["Pic_Path"].ToString());//删除空白图片
                                    FtpHelp.DeleteFile(dr["Pic_Path"].ToString(), UserName, Password);
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
                    Merge("104");
                    isModify = true;
                }
                else
                {
                    string str = "";
                    SMAllpageList = SMpageList;
                    if (SMpageList.Count > 0)
                    {
                        foreach (string s in SMpageList)
                        {
                            str = str + s + ",";
                        }
                        str = str.Remove(str.Length - 1, 1);
                    }
                    lblMesg.Text = str;
                    if (Message.ShowQuery("空白图片张数与拍照图片页码张数不符，是否对此份病案重新录入？空白图片页码为" + str + "", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        Merge("107");
                    }
                    //MessageBox.Show("空白图片张数与拍照图片页码张数不符，合并失败，请对此份病案重新录入");
                    //Merge("107");
                    //DataTable data = CreatePictureDate();//重新加载图片
                    pictureGrid.DataSource = PictureInfo;
                    isModify = false;
                }
                if (isModify)
                {
                    MessageBox.Show("合并成功");
                    Match();//处理审核未通过的图片
                    BindNull();
                }
            }
        }

        #region 内部调用方法
        public void Match()
        {
            if (CheckState == "102")//审核未通过
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
                //图片不清晰，某些图片重拍了
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    string page = dr["Pic_Page"].ToString();
                    string subPage = dr["Pic_SubPage"].ToString();
                    imagesInputArgs.Page = page;
                    imagesInputArgs.SubPage = subPage;
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnNoAgree(null, imagesInputArgs);
                    string fileName = LURecordNO.DisplayText + "_" + str_inHosTimes + "_" + page + "_" + subPage + CJia.Health.Tools.ConfigHelper.GetAppStrings("ImgExtension");
                    string filepath = Path.GetDirectoryName(dr["Pic_Path"].ToString()) + "\\Copy" + "\\" + fileName;
                    FtpHelp.DeleteFile(filepath.Replace('\\', '/').Insert(4, "/"), UserName, Password);
                }
                //新拍了些图片
            }
        }
        /// <summary>
        /// 合并 改变病案的审核状态
        /// </summary>
        /// <param name="mergeState"></param>
        public void Merge(string mergeState)
        {
            if (CheckState != "102")//不为 审核未通过
            {
                if (OnMerge != null)
                {
                    imagesInputArgs.MergeState = mergeState;
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnMerge(null, imagesInputArgs);
                }
            }
        }
        /// <summary>
        /// 修改拍照图片名称
        /// </summary>
        public void RemovePZ(DataRow dr)
        {
            string subPage = dr["Pic_SubPage"].ToString();
            string page = dr["Pic_Page"].ToString();
            string str_inHosTimes;
            if (txtTimes.Text.Length == 1)
            {
                str_inHosTimes = "0" + txtTimes.Text;
            }
            else
            {
                str_inHosTimes = txtTimes.Text;
            }
            string fileName = LURecordNO.DisplayText + "_" + str_inHosTimes + "_" + page + "_" + subPage + dr["Pic_Extension"];
            string newfilePath = Path.GetDirectoryName(dr["Pic_Path"].ToString()) + "\\" + fileName;
            FtpHelp.Rename(dr["Pic_Path"].ToString(), fileName, UserName, Password);
            dr["Pic_Name"] = fileName;
            dr["Pic_Path"] = newfilePath.Replace('\\', '/').Insert(4, "/");
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
            FtpHelp.Rename(dr["Pic_Path"].ToString(), fileName, UserName, Password);
            dr["Pic_Name"] = fileName;
            dr["Pic_Path"] = newfilePath.Replace('\\', '/').Insert(4, "/");
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
            string isjjfb = CJia.Health.Tools.ConfigHelper.GetAppStrings("isJJCJBlank");
            if (isjjfb == "0")//妇保
            {
                for (int i = 0; i < smallImage.Width; i++)
                {
                    for (int j = 0; j < smallImage.Height; j++)
                    {
                        Color col = smallImage.GetPixel(i, j);
                        if (col.R >= 220 && col.G >= 220 && col.B >= 220)
                        {
                            m++;
                        }
                    }
                }
                float f = float.Parse(m.ToString()) / float.Parse(area.ToString());
                if (f < 0.985)//空白部分超过99%就认为此图片为空白图片
                {
                    bol = false;
                }
                return bol;
            }
            else
            {   //创佳
                for (int i = 0; i < smallImage.Width; i++)
                {
                    for (int j = 0; j < smallImage.Height; j++)
                    {
                        Color col = smallImage.GetPixel(i, j);
                        if (col.R >= 250 && col.G >= 250 && col.B >= 250)
                        {
                            m++;
                        }
                    }
                }
                float f = float.Parse(m.ToString()) / float.Parse(area.ToString());
                float blank = float.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("BlankProbability"));
                if (f < blank)//空白部分超过99%就认为此图片为空白图片
                {
                    bol = false;
                }
                return bol;
            }
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
        /// <param name="picName"></param>
        /// <param name="hostIP"></param>
        /// <returns></returns>
        public DataTable SetPictureDataRows(DataTable data, string picName, string hostIP)
        {
            DataRow row = data.NewRow();
            string str_inHosTimes;
            if (txtTimes.Text.Length == 1)
            {
                str_inHosTimes = "0" + txtTimes.Text;
            }
            else
            {
                str_inHosTimes = txtTimes.Text;
            }
            string storagePath = OutHosDate.Year.ToString() + "/" + OutHosDate.Month.ToString() + "/" + OutHosDate.Day.ToString() + "/" + LURecordNO.DisplayText + "/" + str_inHosTimes;
            row["Pic_Path"] = "ftp://" + hostIP + "/" + storagePath + "/" + picName;
            row["Pic_Name"] = picName;
            row["Pic_Extension"] = Path.GetExtension(row["Pic_Path"].ToString());
            if (picName.Length > 0)
            {
                string[] strs = picName.Split('.')[0].Split('_');
                if (strs.Length >= 4)
                {
                    row["Pic_Page"] = strs[strs.Length - 2];
                    row["Pic_SubPage"] = strs[strs.Length - 1];
                }
            }
            row["STORAGE_PATH"] = storagePath;
            data.Rows.Add(row);
            return data;
        }
        /// <summary>
        /// 根据目录获得图片Datatable
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        public DataTable CreatePictureDate()
        {
            try
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
                DataTable data = PictureData();
                string storagePath = OutHosDate.Year.ToString() + "/" + OutHosDate.Month.ToString() + "/" + OutHosDate.Day.ToString() + "/" + LURecordNO.DisplayText + "/" + str_inHosTimes;
                bool bol = FtpHelp.FtpIsExistsFile(storagePath, HostName, UserName, Password);
                if (bol)
                {
                    string[] picName = FtpHelp.GetFileList(storagePath, HostName, UserName, Password, ".pdf");
                    if (picName != null && picName.Length > 0)
                    {
                        for (int i = 0; i < picName.Length; i++)
                        {
                            data = SetPictureDataRows(data, picName[i], HostName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("此病案未上传任何图片");
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
            return null;
        }
        /// <summary>
        /// 拍完一张 页码自增1
        /// </summary>
        public void PageIdentity()
        {

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
                case Keys.F3:
                    btnMerge_Click(null, null);
                    return true;
                case Keys.F5:
                    btnRefresh_Click(null, null);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    int i = pictureView.FocusedRowHandle;
                    DataRow focuseRow = pictureView.GetFocusedDataRow();
                    string fileName = focuseRow["Pic_Path"].ToString();
                    FtpHelp.DeleteFile(fileName, UserName, Password);
                    string[] arr = fileName.Split('/');
                    string name = focuseRow["Pic_Path"].ToString().Split('/')[arr.Length - 1];
                    string filePath = Application.StartupPath + @"\Cache\" + name;
                    pdfViewer.FileName = "";
                    File.Delete(filePath);
                    pictureView.DeleteRow(i);
                    pictureView.RefreshData();
                    pictureGrid.Focus();
                }
            }
        }

        private void pictureView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (SMAllpageList != null && SMAllpageList.Count > 0)
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Pic_Page")
                    {
                        string picName = pictureView.GetDataRow(e.RowHandle)["Pic_Name"].ToString();
                        if (picName.Substring(0, 2) != "PZ")
                        {
                            string picPage = pictureView.GetDataRow(e.RowHandle)["Pic_Page"].ToString();
                            foreach (string page in SMAllpageList)
                            {
                                if (picPage == page)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置非空白页
        /// </summary>
        private List<string> NoBlankPage; //= new List<string>();
        private void btnNoBlamk_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定设置为非空白页？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    DataRow focuseDr = pictureView.GetFocusedDataRow();
                    string page = focuseDr["Pic_Page"].ToString();
                    NoBlankPage.Add(page);
                    string str = "";
                    foreach (string s in NoBlankPage)
                    {
                        str = str + s + ",";
                    }
                    str = str.Remove(str.Length - 1, 1);
                    lblNoBlank.Text = str;//显示设置为 非空白页 的页码
                }
            }
        }

        private void pictureView_RowCountChanged(object sender, EventArgs e)
        {
            pictureView_FocusedRowChanged(null, null);
        }
    }
}
