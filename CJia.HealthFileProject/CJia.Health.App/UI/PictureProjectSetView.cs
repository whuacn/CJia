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
using CJia.Health.Tools;
using System.Threading;

namespace CJia.Health.App.UI
{
    public partial class PictureProjectSetView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView
    {
        private Point m_StarPoint = Point.Empty;        //for 拖动
        private bool m_StarMove = false;
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
        /// 项目分类
        /// </summary>
        private DataTable ProjectData = null;
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
        public PictureProjectSetView()
        {
            InitializeComponent();
            Init();
            LUProject.GetData += LUProject_GetData;
            LURecordNO.GetData += LURecordNO_GetData;
            LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
            repositoryItemComboBox1.SelectedIndexChanged += repositoryItemComboBox1_SelectedIndexChanged;
            lblprojectName.Text = "";
            PicName = "";
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
                if (checkState == "103")//已提交
                {
                    MessageBox.Show("此病案为已提交审核，不能进行图片分类");
                    BindNull();
                    return;
                }
                if (checkState == "101")
                {
                    MessageBox.Show("此病案为已审核通过，不能进行图片分类");
                    BindNull();
                    return;
                }

                if (checkState == "100" || checkState == "107")//没有合并成功
                {
                    MessageBox.Show("此病案没有进行合并，不能进行图片分类");
                    BindNull();
                    return;
                }
                if (checkState == "102")//审核未通过
                {
                    MessageBox.Show("此病案为审核未通过，请查看已入库图片的审核原因，进行重新分类");
                }
                if (OnSelectPicture != null)
                {
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnSelectPicture(sender, imagesInputArgs);
                }
                //自动生成目录
                ckInput.Checked = false;
                pictureGrid.Visible = true;
                inputGrid.Visible = false;
                btnDelete.CustomText = "取消(F6)";
                DataTable data = CreatePictureDate();
                pictureGrid.DataSource = data;
            }
        }
        public void BindNull()
        {
            LURecordNO.DisplayText = "";
            LURecordNO.Text = "";
            LURecordNO.DisplayValue = "";
            txtTimes.Text = "1";
            pictureGrid.DataSource = null;
            inputGrid.DataSource = null;
            pdfViewer.FileName = "";
            lblprojectName.Text = "";
            PicName = "";

        }
        void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = (sender as DevExpress.XtraEditors.ComboBoxEdit).EditValue.ToString();
            string proID = ProjectData.Select(" PRO_NAME='" + value + "'")[0]["PRO_ID"].ToString();
            string page = pictureView.GetFocusedDataRow()["Pic_Page"].ToString();
            string inhosTimes;
            if (txtTimes.Text.Length == 1)
            {
                inhosTimes = "0" + txtTimes.Text;
            }
            else
            {
                inhosTimes = txtTimes.Text;
            }
            foreach (DataRow dr in PictureInfo.Rows)
            {
                if (dr["Pic_Page"].ToString() == page)
                {
                    dr["Pic_ProjectID"] = proID;
                    dr["Pic_ProjectName"] = value;
                    dr["Pic_State"] = "已保存";
                    dr["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + inhosTimes + "\\Copy";
                    dr["LOGIC_PATH"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("LOGIC_PATH");
                    dr["HEALTH_ID"] = LURecordNO.DisplayValue;
                    lblprojectName.Text = value;
                }
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

        void LUProject_GetData(object sender, Controls.CJiaRTLookUpArgs e)
        {
            if (OnProject != null)
            {
                imagesInputArgs.SelectValue = e.SearchValue.Trim().ToUpper();
                OnProject(sender, imagesInputArgs);
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

        private void cJiaPicture_EditValueChanged(object sender, EventArgs e)
        {
            //homepanel.Visible = false;
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
            if (PictureInfo != null && PictureInfo.Rows.Count > 0 && PictureInfo.Select(" Pic_State='已保存'").Length > 0)
            {
                DataRow[] rows = PictureInfo.Select(" Pic_State='已保存'");
                string count = rows.Length.ToString();
                string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                        "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                        "共: " + count + " 张图片" + "\r\n" +
                        "是否确认入库? ";
                if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
                {
                    if (OnInput != null)
                    {
                        imagesInputArgs.PictureData = GetSavePictureData();
                        OnInput(sender, imagesInputArgs);//保存图片信息到数据库
                    }
                    CopyFilesToNext();
                    DataTable data = CreatePictureDate();
                    pictureGrid.DataSource = data;
                }
                else
                {
                    return;
                }
                if (OnSelectPicture != null)
                {
                    imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                    OnSelectPicture(sender, imagesInputArgs);
                }
                DataTable data1 = (DataTable)pictureGrid.DataSource;
                if (data1 != null && data1.Rows.Count > 0)
                {
                    return;
                }
                else
                {
                    if (Message.ShowQuery("所有图片都已入库，是否提交审核？", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        btnReview_Click(null, null);
                    }
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null && !ckInput.Checked)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                if (SetImagePage().Length == 0) return;
                if (LURecordNO.DisplayText.Length == 0 || LUProject.DisplayText.Length == 0)
                {
                    MessageBox.Show("病案号,项目名称不能为空");
                    return;
                }
                if (isPage(focuseRow))
                {
                    Save(focuseRow);
                }
                else if (isInput().Length > 0)
                {
                    Input(focuseRow);
                }
                else
                {
                    SavePictureInfo(focuseRow);
                }
            }
            else if (ckInput.Checked && inputView.GetFocusedDataRow() != null)
            {
                if (SetImagePage().Length == 0) return;
                if (LURecordNO.DisplayText.Length == 0 || LUProject.DisplayText.Length == 0)
                {
                    MessageBox.Show("病案号,项目名称不能为空");
                    return;
                }
                DataRow focuseRow = inputView.GetFocusedDataRow();
                if (isPage() != null)
                {
                    if (Message.ShowQuery("您【已保存图片】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        UpdatePicState(isPage());
                        UpdatePicture(focuseRow);
                        if (OnSelectPicture != null)
                        {
                            imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                            OnSelectPicture(sender, imagesInputArgs);
                        }
                    }
                }
                else if (isInput(focuseRow).Length > 0)
                {
                    if (Message.ShowQuery("您【已入库图片】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        if (OnInputDelete != null)
                        {
                            imagesInputArgs.PictureID = isInput(focuseRow);
                            OnInputDelete(null, imagesInputArgs);
                        }
                        UpdatePicture(focuseRow);
                        if (OnSelectPicture != null)
                        {
                            imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                            OnSelectPicture(sender, imagesInputArgs);
                        }
                    }
                }
                else
                {
                    string page = txtPage.Text;
                    string subpage = txtSubPage.Text;
                    string proID = LUProject.DisplayValue;
                    string pageOld = focuseRow["PAGE_NO"].ToString();
                    string subpageOld = focuseRow["SUBPAGE"].ToString();
                    string proIDOld = focuseRow["PRO_ID"].ToString();
                    if (page != pageOld || subpage != subpageOld || proID != proIDOld)
                    {
                        UpdatePicture(focuseRow);
                        if (OnSelectPicture != null)
                        {
                            imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                            OnSelectPicture(sender, imagesInputArgs);
                        }
                    }
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

        private void ckInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInput.Checked)
            {
                inputGrid.Visible = true;
                pictureGrid.Visible = false;
                btnDelete.CustomText = "删除(F6)";
                inputView_FocusedRowChanged(null, null);
                inputGrid.Focus();
            }
            else
            {
                inputGrid.Visible = false;
                pictureGrid.Visible = true;
                btnDelete.CustomText = "取消(F6)";
                pictureView_FocusedRowChanged(null, null);
                pictureGrid.Focus();
            }
        }

        private void Loading(string uri)
        {
            try
            {
                bool bol = CJia.Health.Tools.Help.DownLoadFileByUri(uri, UserName, Password);
                this.ParentForm.Enabled = true;
                if (bol)
                {
                    string[] arr = uri.Split('/');
                    string fileName = uri.Split('/')[arr.Length - 1];
                    string downLoadFile = Application.StartupPath + @"\Cache\" + fileName;
                    string pdfData = downLoadFile.Replace(".pdf", "");
                    pdfViewer.Password = PDFPassword;
                    pdfViewer.FileName = pdfData;
                }
                else
                {
                    Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
                this.ParentForm.Activate();
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ckInput.Checked && pictureView.GetFocusedDataRow() != null && pictureView.GetFocusedDataRow()["Pic_State"].ToString() == "已保存")
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                focuseRow["Pic_State"] = "";
                btnDelete.CustomText = "删除(F6)";
                return;
            }
            if (!ckInput.Checked && pictureView.GetFocusedDataRow() != null && pictureView.GetFocusedDataRow()["Pic_State"].ToString() == "")
            {
                if (Message.ShowQuery("确定删除此张图片吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    DataRow focuseRow = pictureView.GetFocusedDataRow();
                    string fileName = focuseRow["Pic_Path"].ToString();
                    FtpHelp.DeleteFile(fileName, UserName, Password);
                    string[] arr = fileName.Split('/');
                    string name = focuseRow["Pic_Path"].ToString().Split('/')[arr.Length - 1];
                    string filePath = Application.StartupPath + @"\Cache\" + name;
                    pdfViewer.FileName = "";
                    File.Delete(filePath);
                    pictureView.DeleteRow(pictureView.FocusedRowHandle);
                    pictureView.RefreshData();
                }
            }
            if (ckInput.Checked && inputView.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    if (OnInputDelete != null)
                    {
                        imagesInputArgs.PictureID = inputView.GetFocusedDataRow()["PICTURE_ID"].ToString();
                        OnInputDelete(null, imagesInputArgs);
                        inputView.DeleteRow(inputView.FocusedRowHandle);
                        inputView.RefreshData();
                    }
                }
            }
        }

        #region 内部调用方法

        public void UpdatePicture(DataRow dr)
        {
            if (OnInputSave != null)
            {
                imagesInputArgs.PictureID = dr["PICTURE_ID"].ToString();
                imagesInputArgs.ProID = LUProject.DisplayValue;
                imagesInputArgs.ProName = LUProject.DisplayText;
                imagesInputArgs.Page = txtPage.Text;
                imagesInputArgs.SubPage = txtSubPage.Text;
                OnInputSave(null, imagesInputArgs);
            }
        }
        public DataRow isPage()
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in PictureInfo.Rows)
                {
                    if (dr["Pic_State"].ToString() == "已保存")
                    {
                        if (dr["Pic_Page"].ToString() == txtPage.Text && dr["Pic_SubPage"].ToString() == txtSubPage.Text)
                        {
                            return dr;
                        }
                    }
                }
            }
            return null;
        }
        public string isInput(DataRow row)
        {
            foreach (DataRow dr in InputPictureData.Rows)
            {
                if (row != dr && dr["PAGE_NO"].ToString() == txtPage.Text && dr["SUBPAGE"].ToString() == txtSubPage.Text)
                {
                    return dr["PICTURE_ID"].ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 判断已入库的图片中是否存在此页码设置,并且返回图片id
        /// </summary>
        /// <returns></returns>
        public string isInput()
        {
            if (InputPictureData != null && InputPictureData.Rows.Count > 0)
            {
                foreach (DataRow dr in InputPictureData.Rows)
                {
                    if (dr["PAGE_NO"].ToString() == txtPage.Text && dr["SUBPAGE"].ToString() == txtSubPage.Text)
                    {
                        return dr["PICTURE_ID"].ToString();
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// 保存的图片中存在页码设置
        /// </summary>
        /// <param name="dr"></param>
        public void Save(DataRow dr)
        {
            if (isPage(dr))
            {
                if (Message.ShowQuery("您【已保存图片】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    UpdatePicState(dr);
                    SavePictureInfo(dr);
                }
            }
        }
        /// <summary>
        /// 入库的图片中存在页码设置
        /// </summary>
        /// <param name="dr"></param>
        public void Input(DataRow dr)
        {
            if (isInput().Length > 0)
            {
                if (Message.ShowQuery("您【已入库图片】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    if (OnInputDelete != null)
                    {
                        imagesInputArgs.PictureID = isInput();
                        OnInputDelete(null, imagesInputArgs);
                    }
                    if (OnSelectPicture != null)
                    {
                        imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                        OnSelectPicture(null, imagesInputArgs);
                    }
                    SavePictureInfo(dr);
                }
            }
        }
        /// <summary>
        /// 获得保存的图片信息
        /// </summary>
        public DataTable GetSavePictureData()
        {
            if (PictureInfo != null && PictureInfo.Rows.Count > 0 && PictureInfo.Select(" Pic_State='已保存'").Length > 0)
            {
                DataTable data = PictureInfo.Clone();
                DataRow[] rows = PictureInfo.Select(" Pic_State='已保存'");
                foreach (DataRow dr in rows)
                {
                    data.Rows.Add(dr.ItemArray);
                }
                return data;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存图片到服务器207
        /// </summary>
        public void InputPicture()
        {
            DataRow[] rows = PictureInfo.Select(" Pic_State='已保存'");
            string count = rows.Length.ToString();
            string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                    "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                    "共: " + count + " 张图片" + "\r\n" +
                    "是否确认入库? ";
            if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
            {
                CopyFilesToNet(GetSavePictureData());//上传图片
            }
        }
        /// <summary>
        /// 保存图片修改
        /// </summary>
        /// <param name="row"></param>
        public void SavePictureInfo(DataRow row)
        {
            if (txtPage.Text.Length == 1)
            {
                row["Pic_Page"] = "00" + txtPage.Text;
            }
            else if (txtPage.Text.Length == 2)
            {
                row["Pic_Page"] = "0" + txtPage.Text;
            }
            else
            {
                row["Pic_Page"] = txtPage.Text;
            }
            if (txtSubPage.Text.Length == 1)
            {
                row["Pic_SubPage"] = "0" + txtSubPage.Text;
            }
            else
            {
                row["Pic_SubPage"] = txtSubPage.Text;
            }
            row["Pic_Name"] = SetImagePage() + row["Pic_Extension"].ToString();
            row["Pic_ProjectName"] = LUProject.DisplayText;
            row["Pic_ProjectID"] = LUProject.DisplayValue;
            row["Pic_State"] = "已保存";
            string inhosTimes;
            if (txtTimes.Text.Length == 1)
            {
                inhosTimes = "0" + txtTimes.Text;
            }
            else
            {
                inhosTimes = txtTimes.Text;
            }
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + inhosTimes + "\\Copy";
            //row["STORAGE_PATH"] = Sysdate.ToString("yyyyMMdd") + "\\" + LURecordNO.DisplayText + "\\Copy";
            row["LOGIC_PATH"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("LOGIC_PATH");
            row["HEALTH_ID"] = LURecordNO.DisplayValue;
        }
        /// <summary>
        /// 重复页面设置的置为未保存
        /// </summary>
        /// <param name="row"></param>
        public void UpdatePicState(DataRow row)
        {
            foreach (DataRow dr in PictureInfo.Rows)
            {
                if (dr != row && dr["Pic_State"].ToString() == "已保存")
                {
                    if (dr["Pic_Page"].ToString() == txtPage.Text && dr["Pic_SubPage"].ToString() == txtSubPage.Text)
                    {
                        dr["Pic_State"] = "";
                    }
                }
            }
        }
        /// <summary>
        /// 判断PictureInfo中是否存在此页面设置
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isPage(DataRow row)
        {
            foreach (DataRow dr in PictureInfo.Rows)
            {
                if (dr != row && dr["Pic_State"].ToString() == "已保存")
                {
                    if (dr["Pic_Page"].ToString() == txtPage.Text && dr["Pic_SubPage"].ToString() == txtSubPage.Text)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                    string imgExtension = ConfigHelper.GetAppStrings("ImgExtension");//图片格式
                    string[] picName = FtpHelp.GetFileList(storagePath, HostName, UserName, Password, imgExtension);
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
        /// 判断图片格式为Jpeg
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool isJpegImage(string fileName)
        {
            bool isJPG = false;
            System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                isJPG = true;
                return isJPG;
            }
            return isJPG;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (OnLoad != null)
            {
                OnLoad(null, null);
            }
        }
        /// <summary>
        /// 设定Image名称，根据住院次数，页码，附加码
        /// </summary>
        public string SetImagePage()
        {
            string inhosTimes = "";
            string page = "";
            string subPage = "";
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
                string fileName = LURecordNO.DisplayText + "_" + inhosTimes + "_" + page + "_" + subPage;
                return fileName;
            }
            else
            {
                MessageBox.Show("页码设定和住院次数不能为空");
                return "";
            }
        }
        /// <summary>
        /// 上传图片到服务器上
        /// </summary>
        public void CopyFilesToNet(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                CreaterFolder(CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + dr["STORAGE_PATH"].ToString());
                string fileName = dr["Pic_Path"].ToString();
                File.Copy(fileName, CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + dr["STORAGE_PATH"] + "\\" + dr["Pic_Name"], true);
            }
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
        public void CopyFilesToNext()
        {
            if (GetSavePictureData() != null && GetSavePictureData().Rows.Count > 0)
            {
                foreach (DataRow dr in GetSavePictureData().Rows)
                {
                    string fileName = dr["Pic_Path"].ToString();
                    string name = dr["Pic_Name"].ToString().Replace(".pdf", "");
                    string pathOld = Application.StartupPath + @"\Cache\" + name;
                    foreach (Control cs in this.ParentForm.Controls.Find("pdfViewer", true))
                    {
                        if ((cs as CJia.Health.Tools.PDFViewer).FileName == pathOld)
                        {
                            (cs as CJia.Health.Tools.PDFViewer).FileName = "";
                        }
                    }
                    foreach (Control cs2 in this.ParentForm.Controls.Find("smallpdfViewer", true))
                    {
                        if ((cs2 as CJia.Health.Tools.PDFViewer).FileName == pathOld)
                        {
                            (cs2 as CJia.Health.Tools.PDFViewer).FileName = "";
                        }
                    }
                    try { File.Delete(pathOld); }
                    catch { }
                    FtpHelp.MoveFileToCopy(fileName, HostName, UserName, Password);
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
                case Keys.F8:
                    btnSave_Click_1(null, null);
                    return true;
                case Keys.F2:
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
        public event EventHandler<Views.ImagesInputArgs> OnShortKeyDown;
        public void ExeBindProjectByShortKey(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                string proName = data.Rows[0]["PRO_NAME"].ToString();
                string proID = data.Rows[0]["PRO_ID"].ToString();
                SetProjectByKey(proName, proID);
            }
        }
        public void ExeBindPicture(DataTable data)
        {
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
        }
        public void ExeInit(DataTable data)
        {
            if (data != null)
            {
                LUProject.DataSource = data;
                LUProject.Caption = "项目名称";
                LUProject.DisplayField = "PRO_NAME";
                LUProject.ValueField = "PRO_ID";
                foreach (DataRow dr in data.Rows)
                {
                    repositoryItemComboBox1.Items.Add(dr["PRO_NAME"].ToString());
                }
                if (ProjectData == null)
                {
                    ProjectData = data;
                }
            }
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

        #region 图片旋转函数
        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <returns></returns>
        public Bitmap Rotate(Bitmap b, int angle)
        {
            angle = angle % 360;            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            return dsImage;
        }
        #endregion 图片旋转函数

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (LURecordNO.DisplayValue.Length > 0 && OnReview != null)
            {
                DataTable data = (DataTable)pictureGrid.DataSource;
                if (data != null && data.Rows.Count > 0)
                {
                    MessageBox.Show("还存在未入库的图片，不能提交审核");
                    return;
                }
                imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                imagesInputArgs.RecordNO = LURecordNO.DisplayText;
                OnReview(sender, imagesInputArgs);
                RecordNOData = null;
                LURecordNO.DataSource = null;
                LURecordNO.DisplayText = "";
                LURecordNO.DisplayValue = "";
                LURecordNO.Text = "";
                lblprojectName.Text = "";
                LUProject.DataSource = null;
                LUProject.DisplayText = "";
                LUProject.DisplayValue = "";
                LUProject.Text = "";
                txtTimes.Text = "1";
                txtPage.Text = "001";
                txtSubPage.Text = "00";
                pdfViewer.FileName = "";
                pictureGrid.DataSource = null;
                inputGrid.DataSource = null;
            }
        }

        private void pictureView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                string uri = focuseRow["Pic_Path"].ToString();
                bool bol = CJia.Health.Tools.Help.DownLoadFileByUri(uri, UserName, Password);
                if (bol)
                {
                    string[] arr = uri.Split('/');
                    string fileName = uri.Split('/')[arr.Length - 1];
                    string downLoadFile = Application.StartupPath + @"\Cache\" + fileName;
                    string pdfData = downLoadFile.Replace(".pdf", "");
                    pdfViewer.Password = PDFPassword;
                    pdfViewer.FileName = pdfData;
                    pdfViewer.Tag = focuseRow["Pic_Path"].ToString();
                    PicName = focuseRow["Pic_Name"].ToString();
                }
                else
                {
                    Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
                LUProject.DisplayText = focuseRow["Pic_ProjectName"].ToString();
                LUProject.Text = focuseRow["Pic_ProjectName"].ToString();
                lblprojectName.Text = focuseRow["Pic_ProjectName"].ToString();
                LUProject.DisplayValue = focuseRow["Pic_ProjectID"].ToString();
                txtPage.Text = focuseRow["Pic_Page"].ToString();
                txtSubPage.Text = focuseRow["Pic_SubPage"].ToString();
                if (pictureView.GetFocusedDataRow()["Pic_State"].ToString() == "已保存")
                {
                    btnDelete.CustomText = "取消(F6)";
                }
                else
                {
                    btnDelete.CustomText = "删除(F6)";
                }
                pictureGrid.Focus();
            }
        }
        private void inputView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (inputView.GetFocusedDataRow() != null && ckInput.Checked)
                {
                    DataRow focuseRow = inputView.GetFocusedDataRow();
                    string uri = focuseRow["SRC"].ToString();
                    LUProject.DisplayText = focuseRow["PRO_NAME"].ToString();
                    LUProject.Text = focuseRow["PRO_NAME"].ToString();
                    LUProject.DisplayValue = focuseRow["PRO_ID"].ToString();
                    lblprojectName.Text = focuseRow["PRO_NAME"].ToString();
                    txtPage.Text = focuseRow["PAGE_NO"].ToString();
                    txtSubPage.Text = focuseRow["SUBPAGE"].ToString();
                    bool bol = CJia.Health.Tools.Help.DownLoadFileByUri(uri, UserName, Password);
                    if (bol)
                    {
                        string[] arr = uri.Split('/');
                        string fileName = uri.Split('/')[arr.Length - 1];
                        string downLoadFile = Application.StartupPath + @"\Cache\" + fileName;
                        string pdfData = downLoadFile.Replace(".pdf", "");
                        pdfViewer.Password = PDFPassword;
                        pdfViewer.FileName = pdfData;
                        pdfViewer.Tag = focuseRow["SRC"].ToString();
                        PicName = focuseRow["PICTURE_NAME"].ToString();
                        inputGrid.Focus();
                    }
                    else
                    {
                        Message.Show("此图片不存在或已删除，请与管理员联系。。。");
                    }
                }
            }
            catch { }
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
            //        CreaterFolder(linshipath);
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

        private void pictureView_KeyDown(object sender, KeyEventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                //ProjectKeyPress(e.KeyData);
                char key = (char)e.KeyValue;
                if (OnShortKeyDown != null)
                {
                    imagesInputArgs.ShortKey = key.ToString().ToUpper();
                    OnShortKeyDown(this, imagesInputArgs);
                }
            }
        }
        public void ProjectKeyPress(Keys keyData)
        {
            string shortKey = keyData.ToString();
            switch (keyData)
            {
                case Keys.Q:
                    SetProjectByKey("病案首页", "1000000061");
                    break;
                case Keys.W:
                    SetProjectByKey("出院（死亡）记录", "1000010002");
                    break;
                case Keys.E:
                    SetProjectByKey("死亡讨论记录", "1000000062");
                    break;
                case Keys.R:
                    SetProjectByKey("入院记录", "1000010003");
                    break;
                case Keys.T:
                    SetProjectByKey("病程记录", "1000010004");
                    break;
                case Keys.Y:
                    SetProjectByKey("特殊治疗记录单", "1000010021");
                    break;
                case Keys.U:
                    SetProjectByKey("术前讨论记录", "1000010005");
                    break;
                case Keys.I:
                    SetProjectByKey("术前小结记录", "1000010022");
                    break;
                case Keys.O:
                    SetProjectByKey("麻醉记录", "1000010006");
                    break;
                case Keys.P:
                    SetProjectByKey("手术记录或分娩记录", "1000010007");
                    break;
                case Keys.A:
                    SetProjectByKey("一般患者护理记录", "1000010023");
                    break;
                case Keys.S:
                    SetProjectByKey("危重患者护理记录", "1000010024");
                    break;
                case Keys.D:
                    SetProjectByKey("会诊记录单", "1000010025");
                    break;
                case Keys.F:
                    SetProjectByKey("器械检查报告单", "1000010009");
                    break;
                case Keys.G:
                    SetProjectByKey("交叉配血报告单、检验报告单", "1000010010");
                    break;
                case Keys.H:
                    SetProjectByKey("长期医嘱单", "1000010011");
                    break;
                case Keys.J:
                    SetProjectByKey("临时医嘱单", "1000010012");
                    break;
                case Keys.K:
                    SetProjectByKey("体温单", "1000010013");
                    break;
                case Keys.L:
                    SetProjectByKey("各种知情告知医疗文书", "1000010026");
                    break;
                default:
                    break;
            }
        }
        public void SetProjectByKey(string proName, string proID)
        {
            string page = pictureView.GetFocusedDataRow()["Pic_Page"].ToString();
            string inhosTimes;
            if (txtTimes.Text.Length == 1)
            {
                inhosTimes = "0" + txtTimes.Text;
            }
            else
            {
                inhosTimes = txtTimes.Text;
            }
            foreach (DataRow dr in PictureInfo.Rows)
            {
                if (dr["Pic_Page"].ToString() == page)
                {
                    dr["Pic_ProjectID"] = proID;
                    dr["Pic_ProjectName"] = proName;
                    dr["Pic_State"] = "已保存";
                    dr["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\" + inhosTimes + "\\Copy";
                    dr["LOGIC_PATH"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("LOGIC_PATH");
                    dr["HEALTH_ID"] = LURecordNO.DisplayValue;
                    lblprojectName.Text = proName;
                }
            }
        }

        private void pictureView_RowCountChanged(object sender, EventArgs e)
        {
            pictureView_FocusedRowChanged(null, null);
        }

        private void inputView_RowCountChanged(object sender, EventArgs e)
        {
            inputView_FocusedRowChanged(null, null);
        }
    }
}
