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

namespace CJia.Health.App.UI
{
    public partial class ImagesInputView : CJia.Health.Tools.View, CJia.Health.Views.IImagesInputView
    {
        public void ExeBindProjectByShortKey(DataTable data)
        { }
        /// <summary>
        /// 病案号数据
        /// </summary>
        private DataTable RecordNOData;
        /// <summary>
        /// 病案信息
        /// </summary>
        private DataTable PictureInfo;
        /// <summary>
        /// 已入库的病案信息
        /// </summary>
        private DataTable InputPictureData;
        /// <summary>
        /// 出院时间
        /// </summary>
        private DateTime OutHosDate;
        public ImagesInputView()
        {
            InitializeComponent();
            Init();
            LUProject.GetData += LUProject_GetData;
            LURecordNO.GetData += LURecordNO_GetData;
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
        /// 保存病案信息
        /// </summary>
        List<Dictionary<string, string>> imgList = new List<Dictionary<string, string>>();
        /// <summary>
        /// 传递病案信息参数类
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
                btnDelete.CustomText = "取消(F6)";
                DataTable data = CreatePictureDate(path);
                pictureGrid.DataSource = data;
            }
        }

        private void cJiaPicture_EditValueChanged(object sender, EventArgs e)
        {
            homepanel.Visible = false;
        }

        private void images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ckModel.Checked && images.SelectedIndex >= 0)
            {
                int index = images.SelectedIndex;
                cJiaPicture.Image = imageCollection1.Images[index];
                string imageName = images.Items[index].Value.ToString();
                string fileName = imageCollection1.Images.Keys[index].ToString();
                if (imageName.Length > 6)
                {
                    //txtTimes.Text = imageName.Substring(0, 2);
                    txtPage.Text = imageName.Substring(2, 3);
                    txtSubPage.Text = imageName.Substring(5, 2);
                }
                if (isExitePage(fileName))
                {
                    lblMessage.Text = "已保存";
                }
                else
                {
                    lblMessage.Text = "";
                }
            }
        }

        private void ckModel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModel.Checked)
            {
                cJiaPicture.Visible = false;
                homepanel.Visible = false;
                ckPage.Checked = true;
                this.OpenCapture();
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                ckPage.Checked = false;
                cJiaPicture.Visible = true;
                ImagesInputView.SendMessage(this.hHwnd, 0x40b, 0, 0);//停止视频注销视频句柄
                ImagesInputView.DestroyWindow(this.hHwnd);
                if (isPicInput())
                {
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                }
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
            if (!ckModel.Checked && PictureInfo != null && PictureInfo.Rows.Count > 0 && PictureInfo.Select(" Pic_State='已保存'").Length > 0)
            {
                DataRow[] rows = PictureInfo.Select(" Pic_State='已保存'");
                string count = rows.Length.ToString();
                string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                        "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                        "共: " + count + " 张病案" + "\r\n" +
                        "是否确认入库? ";
                if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
                {
                    if (OnInput != null)
                    {
                        imagesInputArgs.PictureData = GetSavePictureData();
                        OnInput(sender, imagesInputArgs);//保存病案信息到数据库
                    }
                    CopyFilesToNext();
                    DataTable data = CreatePictureDate(txtFolder.Text);
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
            }
            //不选择项目
            if (ckModel.Checked && PictureInfo != null && PictureInfo.Rows.Count > 0 && isPicInput())
            {
                string count = PictureInfo.Rows.Count.ToString();
                string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                        "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                        "共: " + count + " 张病案" + "\r\n" +
                        "是否确认入库? ";
                if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
                {
                    CopyFilesToNet(PictureInfo);//上传病案
                }
                else
                {
                    return;
                }
                if (Message.ShowQuery("入库成功的病案已上传至服务器,是否删除本地病案？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    DeleteFile();
                    DataTable data = CreatePictureDate(txtFolder.Text);
                    pictureGrid.DataSource = data;
                }
                else
                {
                    //CopyFilesToNext();
                    //DataTable data = CreatePictureDate(txtFolder.Text);
                    //pictureGrid.DataSource = data;
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ckModel.Checked && pictureView.GetFocusedDataRow() != null && !ckInput.Checked)
            {
                if (SetImagePage().Length == 0) return;
                if (LURecordNO.DisplayText.Length == 0 || LUProject.DisplayText.Length == 0)
                {
                    MessageBox.Show("病案号,项目名称不能为空");
                    return;
                }
                DataRow focuseRow = pictureView.GetFocusedDataRow();
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
            else if (!ckModel.Checked && ckInput.Checked && inputView.GetFocusedDataRow() != null)
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
                    if (Message.ShowQuery("您【已保存病案】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
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
                    if (Message.ShowQuery("您【已入库病案】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
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
                    UpdatePicture(focuseRow);
                    if (OnSelectPicture != null)
                    {
                        imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                        OnSelectPicture(sender, imagesInputArgs);
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
                if (RecordNOData != null && LURecordNO.DisplayText.Length != 0)
                {
                    string inHosTimes = BindInHosTimes(RecordNOData, LURecordNO.DisplayText);
                    txtTimes.Text = inHosTimes;
                    txtPage.Text = "001";
                    txtSubPage.Text = "00";
                    DataRow[] selectRow = RecordNOData.Select(" RECORDNO='" + LURecordNO.DisplayText + "' ");
                    string checkState = selectRow[0]["CHECK_STATUS"].ToString();
                    DateTime outDate = DateTime.Parse(selectRow[0]["OUT_HOSPITAL_DATE"].ToString());
                    OutHosDate = outDate;
                    if (checkState == "101" || checkState == "103")//审核通过 已提交
                    {
                        MessageBox.Show("此病案信息已提交审核或者已审核通过，不能进行病案入库，请联系管理员。。。");
                        LURecordNO.DisplayText = "";
                        LURecordNO.Text = "";
                        LURecordNO.DisplayValue = "";
                        txtTimes.Text = "1";
                        return;
                    }
                    if (OnSelectPicture != null)
                    {
                        imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                        OnSelectPicture(sender, imagesInputArgs);
                    }
                    //自动生成目录
                    string PICLocalSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_LOCAL_PATH");//本地
                    string PICServiceSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH");//服务端
                    string storagePath = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText;
                    if (ckModel.Checked)
                    {
                        CreaterFolder(PICLocalSavePath + "\\" + storagePath);
                        txtFolder.Text = PICLocalSavePath + "\\" + storagePath;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        txtFolder.Text = PICServiceSavePath + "\\" + storagePath;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void pictureGrid_Click(object sender, EventArgs e)
        {
            if (pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                FileStream fs = new FileStream(focuseRow["Pic_Path"].ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Bitmap bt = new Bitmap(fs);
                cJiaPicture.Image = bt;
                fs.Close();//关键  释放资源
                LUProject.DisplayText = focuseRow["Pic_ProjectName"].ToString();
                LUProject.Text = focuseRow["Pic_ProjectName"].ToString();
                LUProject.DisplayValue = focuseRow["Pic_ProjectID"].ToString();
                txtPage.Text = focuseRow["Pic_Page"].ToString();
                txtSubPage.Text = focuseRow["Pic_SubPage"].ToString();
            }
        }

        private void ckInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInput.Checked)
            {
                inputGrid.Visible = true;
                pictureGrid.Visible = false;
                btnDelete.CustomText = "删除(F6)";
            }
            else
            {
                inputGrid.Visible = false;
                pictureGrid.Visible = true;
                btnDelete.CustomText = "取消(F6)";
            }
        }

        private void inputPicGridView_Click(object sender, EventArgs e)
        {
            if (inputView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = inputView.GetFocusedDataRow();
                FileStream fs = new FileStream(focuseRow["SRC"].ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Bitmap bt = new Bitmap(fs);
                cJiaPicture.Image = bt;
                fs.Close();//关键  释放资源
                LUProject.DisplayText = focuseRow["PRO_NAME"].ToString();
                LUProject.Text = focuseRow["PRO_NAME"].ToString();
                LUProject.DisplayValue = focuseRow["PRO_ID"].ToString();
                txtPage.Text = focuseRow["PAGE_NO"].ToString();
                txtSubPage.Text = focuseRow["SUBPAGE"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ckInput.Checked && pictureView.GetFocusedDataRow() != null)
            {
                DataRow focuseRow = pictureView.GetFocusedDataRow();
                focuseRow["Pic_State"] = "";
            }
            if (ckInput.Checked && inputView.GetFocusedDataRow() != null)
            {
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    if (OnInputDelete != null)
                    {
                        imagesInputArgs.PictureID = inputView.GetFocusedDataRow()["PICTURE_ID"].ToString();
                        OnInputDelete(null, imagesInputArgs);
                    }
                    if (OnSelectPicture != null)
                    {
                        imagesInputArgs.HealthID = LURecordNO.DisplayValue;
                        OnSelectPicture(null, imagesInputArgs);
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
        }

        #region 内部调用方法
        /// <summary>
        /// 判断是否是病案入库
        /// </summary>
        /// <returns></returns>
        public bool isPicInput()
        {
            string filePath = txtFolder.Text;
            string picSavePath = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_LOCAL_PATH");
            if (filePath.Contains(picSavePath))
            {
                return true;
            }
            return false;
        }

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
        /// 判断已入库的病案中是否存在此页码设置,并且返回病案id
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
        /// 保存的病案中存在页码设置
        /// </summary>
        /// <param name="dr"></param>
        public void Save(DataRow dr)
        {
            if (isPage(dr))
            {
                if (Message.ShowQuery("您【已保存病案】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    UpdatePicState(dr);
                    SavePictureInfo(dr);
                }
            }
        }
        /// <summary>
        /// 入库的病案中存在页码设置
        /// </summary>
        /// <param name="dr"></param>
        public void Input(DataRow dr)
        {
            if (isInput().Length > 0)
            {
                if (Message.ShowQuery("您【已入库病案】中存在此页码设置，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
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
        /// 获得保存的病案信息
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
        /// 保存病案到服务器207
        /// </summary>
        public void InputPicture()
        {
            DataRow[] rows = PictureInfo.Select(" Pic_State='已保存'");
            string count = rows.Length.ToString();
            string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                    "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                    "共: " + count + " 张病案" + "\r\n" +
                    "是否确认入库? ";
            if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
            {
                CopyFilesToNet(GetSavePictureData());//上传病案
            }
        }
        /// <summary>
        /// 保存病案修改
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
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText + "\\Copy";
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
        /// 创建病案DataTable
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
        /// 根据病案路径获得DataRow
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
            if (fileName.Length > 6)
            {
                row["Pic_Page"] = fileName.Substring(2, 3);
                row["Pic_SubPage"] = fileName.Substring(5, 2);
            }
            row["STORAGE_PATH"] = OutHosDate.Year.ToString() + "\\" + OutHosDate.Month.ToString() + "\\" + OutHosDate.Day.ToString() + "\\" + LURecordNO.DisplayText;
            data.Rows.Add(row);
            return data;
        }
        /// <summary>
        /// 根据目录获得病案Datatable
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
        /// 递归浏览所有文件，pathname是文件夹名
        /// </summary>
        /// <param name="pathname"></param>
        public void LookFile(string pathname)
        {
            if (pathname.Trim().Length == 0) { return; } //判断文件名不为空                      
            try
            {
                imageCollection1.Images.Clear();
                images.Items.Clear();
                string imgtype = "*.BMP|*.JPG|*.GIF|*.PNG";
                string[] ImageType = imgtype.Split('|');
                for (int i = 0; i < ImageType.Length; i++)
                {
                    string[] tmp1 = System.IO.Directory.GetFiles(pathname, ImageType[i], SearchOption.TopDirectoryOnly);
                    foreach (string str in tmp1)
                    {
                        imageCollection1.Images.Add(Image.FromFile(str), str);
                    }
                }
                if (imageCollection1.Images.Count > 0)
                {
                    for (int i = 0; i < imageCollection1.Images.Count; i++)
                    {
                        string key = imageCollection1.Images.Keys[i];
                        string[] s = key.Split('\\');
                        string[] valueArray = s[s.Length - 1].Split('.');
                        string value = "";
                        for (int j = 0; j < valueArray.Length - 1; j++)
                        {
                            value = value + valueArray[j];
                        }
                        images.Items.Add(new DevExpress.XtraEditors.Controls.ImageListBoxItem(value, i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());//防止有些文件无权限访问，屏蔽异常    
            }
        }
        /// <summary>
        /// 判断病案格式为Jpeg
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
                return inhosTimes + page + subPage;
            }
            else
            {
                MessageBox.Show("页码设定和住院次数不能为空");
                return "";
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
        /// 上传病案到服务器上
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
        /// 删除本地病案
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
        /// copy病案到病案目录下的子目录
        /// </summary>
        public void CopyFilesToNext()
        {
            if (GetSavePictureData() != null && GetSavePictureData().Rows.Count > 0)
            {
                foreach (DataRow dr in GetSavePictureData().Rows)
                {
                    string fileName = dr["Pic_Path"].ToString();
                    string directory = System.IO.Path.GetDirectoryName(fileName);
                    CreaterFolder(directory + "\\Copy");
                    File.Copy(fileName, directory + "\\Copy" + "\\" + dr["Pic_Name"], true);
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
        /// 判断同一个病人页码设置是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isExitePage(string name)
        {
            foreach (Dictionary<string, string> dict in imgList)
            {
                string fileName = dict["FILE_NAME"];
                if (name == fileName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 删除字典中存在的某条数据
        /// </summary>
        public void DeleteDictionary(string name)
        {
            for (int i = 0; i < imgList.Count; i++)
            {
                string pageName = imgList[i]["FILE_NAME"];
                if (pageName == name)
                {
                    imgList.Remove(imgList[i]);
                }
            }
        }
        /// <summary>
        /// 保存数据,向Dictionary中添加数据
        /// </summary>
        public void AddDictionary()
        {
            string meg = @"病案号：" + LURecordNO.DisplayText + "\r\n" +
                    "第 " + txtTimes.Text + " 次入院" + "\r\n" +
                    "项目名称：" + LUProject.DisplayText + "\r\n" +
                    "第 " + txtPage.Text + " 页" + "\r\n" +
                    "附加页：" + txtSubPage.Text;
            if (Message.ShowQuery(meg, Message.Button.YesNo) == Message.Result.Yes)
            {
                int index = images.SelectedIndex;
                string fileName = imageCollection1.Images.Keys[index].ToString();
                string[] s = fileName.Split('\\');
                string old = s[s.Length - 1];
                string[] pictureNameArray = s[s.Length - 1].Split('.');
                string pictureForm = pictureNameArray[pictureNameArray.Length - 1];
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("ID", LURecordNO.DisplayValue);
                dict.Add("PRO_ID", LUProject.DisplayValue);
                dict.Add("PRO_NAME", LUProject.DisplayText);
                dict.Add("PAGE_NO", txtPage.Text);
                dict.Add("SUBPAGE", txtSubPage.Text);
                dict.Add("PICTURE_NAME", SetImagePage() + "." + pictureForm);
                dict.Add("STORAGE_PATH", Sysdate.ToString("yyyyMMdd") + "\\" + LURecordNO.DisplayText);//存储路径
                dict.Add("LOGIC_PATH", CJia.Health.Tools.ConfigHelper.GetAppStrings("LOGIC_PATH"));//逻辑存储路径
                dict.Add("FILE_NAME", fileName);
                dict.Add("PICTURE_OLD", old);
                imgList.Add(dict);
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
            DataRow[] inHosTimes = data.Select(" RECORDNO='" + value + "' ");
            return inHosTimes[0]["IN_HOSPITAL_TIME"].ToString();
        }
        #endregion

        #region 照相机
        private int hHwnd;
        private const int port = 2000;
        public struct videohdr_tag
        {
            public byte[] lpData;
            public int dwBufferLength;
            public int dwBytesUsed;
            public int dwTimeCaptured;
            public int dwUser;
            public int dwFlags;
            public int[] dwReserved;

        }
        public delegate bool CallBack(int hwnd, int lParam);
        ///   <summary>   
        ///   必需的设计器变量。   
        ///   </summary>   
        //private System.ComponentModel.Container components = null;
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszVer, int cbVer);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool DestroyWindow(int hndw);
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]   object lParam);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("vfw32.dll")]
        public static extern string capVideoStreamCallback(int hwnd, videohdr_tag videohdr_tag);
        [DllImport("vicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool capSetCallbackOnFrame(int hwnd, string s);

        private void OpenCapture()
        {
            int intWidth = this.pnlCamera.Width;
            int intHeight = this.pnlCamera.Height;
            int intDevice = 0;
            string refDevice = intDevice.ToString();
            //创建视频窗口并得到句柄
            hHwnd = ImagesInputView.capCreateCaptureWindowA(ref   refDevice, 1342177280, 0, 0, 640, 480, this.pnlCamera.Handle.ToInt32(), 0);
            if (ImagesInputView.SendMessage(hHwnd, 0x40a, intDevice, 0) > 0)
            {
                ImagesInputView.SendMessage(this.hHwnd, 0x435, -1, 0);
                ImagesInputView.SendMessage(this.hHwnd, 0x434, 0x42, 0);
                ImagesInputView.SendMessage(this.hHwnd, 0x432, -1, 0);
                ImagesInputView.SetWindowPos(this.hHwnd, 1, 0, 0, intWidth, intHeight, 6);
            }
            else
            {
                ImagesInputView.DestroyWindow(this.hHwnd);
            }
        }
        /// <summary>
        /// 截图
        /// </summary>
        private void Screenshot()
        {
            try
            {
                if (txtFolder.Text.Length > 0 && isPicInput())
                {
                    if (SetImagePage().Length == 0) return; //页码问题
                    ImagesInputView.SendMessage(this.hHwnd, 0x41e, 0, 0);
                    IDataObject obj1 = Clipboard.GetDataObject();
                    if (obj1.GetDataPresent(typeof(Bitmap)))
                    {
                        Image image1 = (Image)obj1.GetData(typeof(Bitmap));
                        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                        SaveFileDialog1.InitialDirectory = txtFolder.Text;
                        SaveFileDialog1.FileName = SetImagePage();
                        SaveFileDialog1.Filter = "Image Files(*.JPG;*.GIF)|*.JPG;*.GIF|All files (*.*)|*.*";
                        string strFile = SaveFileDialog1.InitialDirectory + "\\" + SaveFileDialog1.FileName + ".JPG";//if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                        string[] tmp1 = System.IO.Directory.GetFiles(txtFolder.Text, "*.JPG");
                        bool isHave = false;
                        foreach (string s in tmp1)
                        {
                            if (s == strFile)
                            {
                                isHave = true;
                            }
                        }
                        if (isHave)
                        {
                            if (Message.ShowQuery("文件已存在，是否覆盖？", Message.Button.YesNo) == Message.Result.Yes)
                            {
                                image1.Save(strFile, ImageFormat.Bmp);
                                if (GetSavePictureData() != null)
                                {
                                    DataTable data = SetPictureDataRows(PictureInfo, strFile);
                                    pictureGrid.DataSource = data;
                                }
                                else
                                {
                                    DataTable data = CreatePictureDate(txtFolder.Text);
                                    pictureGrid.DataSource = data;
                                }
                                PageIdentity();
                            }
                        }
                        else
                        {
                            image1.Save(strFile, ImageFormat.Bmp);
                            if (GetSavePictureData() != null)
                            {
                                DataTable data = SetPictureDataRows(PictureInfo, strFile);
                                pictureGrid.DataSource = data;
                            }
                            else
                            {
                                DataTable data = CreatePictureDate(txtFolder.Text);
                                pictureGrid.DataSource = data;
                            }
                            PageIdentity();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("目录有误");
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    if (ckModel.Checked)
                    {
                        Screenshot();
                    }
                    return true;
                case Keys.F8:
                    if (!ckModel.Checked)
                    {
                        btnSave_Click_1(null, null);
                    }
                    return true;
                case Keys.F2:
                    if (!ckModel.Checked)
                    {
                        btnInput_Click(null, null);
                    }
                    return true;
                case Keys.F6:
                    if (!ckModel.Checked)
                    {
                        btnDelete_Click(null, null);
                    }
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
        public void ExeBindPicture(DataTable data)
        {
            if (data != null)
            {
                data.Columns.Add("Pic_State", typeof(string));
                foreach (DataRow dr in data.Rows)
                {
                    dr["Pic_State"] = "已入库";
                    dr["SRC"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + "\\" + dr["SRC"];
                }
            }
            inputGrid.DataSource = data;
            InputPictureData = data;
        }
        public void ExeInit(DataTable data)
        {
            LUProject.DataSource = data;
            LUProject.Caption = "项目名称";
            LUProject.DisplayField = "PRO_NAME";
            LUProject.ValueField = "PRO_ID";
        }
        public void ExeRecordNO(DataTable data)
        {
            RecordNOData = data;
            LURecordNO.DataSource = data;
            LURecordNO.DisplayField = "RECORDNO";
            LURecordNO.ValueField = "ID";
            LURecordNO.Fields = new string[,] { { "RECORDNO", "病案号" }, { "PATIENT_NAME", "姓名" }, { "GENDER_NAME", "性别" } };
        }
        #endregion



    }
}
