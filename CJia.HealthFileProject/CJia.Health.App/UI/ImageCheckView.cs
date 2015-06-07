using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CJia.Health.App.UI
{
    public partial class ImageCheckView : CJia.Health.Tools.View, CJia.Health.Views.IImageCheckView
    {
        public ImageCheckView()
        {
            InitializeComponent();
            this.LURecordNO.GetData += LURecordNO_GetData;
            this.LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
        }



        protected override object CreatePresenter()
        {
            return new Presenters.ImageCheckPresenter(this);
        }

        #region  属性

        /// <summary>
        /// 该病人所有病案
        /// </summary>
        private DataTable AllPicture = null;

        private Dictionary<string, Image> AllPictureImage = null;

        private DataTable BigPicture = null;

        private DataTable SmallPicture = null;

        /// <summary>
        /// 选择的病案
        /// </summary>
        private DataTable SelectPicture
        {
            get
            {
                DataTable selectPic = null;
                DataRow selectRow = this.gvBigPicture.GetFocusedDataRow();
                if(selectRow != null)
                {
                    string pageNo = selectRow["PAGE_NO"].ToString();
                    selectPic = CJia.Health.Tools.Help.GetDataSource(this.AllPicture.Select(" PAGE_NO = '" + pageNo + "'"));
                }
                return selectPic;
            }
        }

        /// <summary>
        /// 获得焦点的小图
        /// </summary>
        private DataRow SelectSmailPicture
        {
            get
            {
                DataRow selectSmailRow = this.gvSmallPicture.GetFocusedDataRow();
                int i = this.gvSmallPicture.FocusedRowHandle;
                return selectSmailRow;
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
        /// 病案缓存类
        /// </summary>
        private CJia.Health.Tools.ImageCache imageCache = new Tools.ImageCache();

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
            Views.ImageCheckViewArgs imageCheckViewArgs = new Views.ImageCheckViewArgs()
            {
                healthId = healthId
            };
            if(this.OnSreach != null)
            {
                this.OnSreach(null, imageCheckViewArgs);
            }
        }

        // 选择病人后
        void LURecordNO_SelectValueChanged(object sender, EventArgs e)
        {
            this.SelectPic();
            this.cgPicture.Focus();
        }

        // 查询病案
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SelectPic();
            this.cgPicture.Focus();
        }

        // 获得焦点列修改事件
        private void gvBigPicture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.BindPicture();
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
            //this.keyDown(e.KeyData);
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
            if(e.Column.FieldName == "CHECK_STATUS_NAME")
            {
                string stutas = this.gvBigPicture.GetDataRow(e.RowHandle)["CHECK_STATUS"].ToString();
                if(stutas == "103")
                {

                }
                else if(stutas == "101")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if(stutas == "102")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }

        }

        /// <summary>
        /// 根据状态改变字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSmallPicture_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName == "CHECK_STATUS_NAME")
            {
                string stutas = e.CellValue.ToString();
                //DataRow row = this.gvSmallPicture.GetDataRow(e.RowHandle);
                //string stutas = this.gvSmallPicture.GetDataRow(e.RowHandle)["CHECK_STATUS"].ToString();
                if(stutas == "已提交")
                {

                }
                else if(stutas == "审核通过")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if(stutas == "审核未通过")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        // 上一大页
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F1);
        }

        // 上一小页
        private void btnUpSubPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F2);
        }

        // 下一小页
        private void btnDownSubPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F3);
        }

        // 下一大页
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F4);
        }

        // 状态选择修改事件
        private void crdCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable BigPicture = this.BigPicture;
            DataTable SmallPicture = this.SmallPicture;
            this.filterPictureData(ref BigPicture, ref SmallPicture);
            this.bindGridView(BigPicture, SmallPicture);
        }

        // 审核通过
        private void btnPass_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F5);
        }

        // 审核不通过
        private void btnNoPass_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F6);
        }

        // 撤销审核
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.keyDown(Keys.F7);
        }

        // 病案改变
        private void picDA_ImageChanged(object sender, EventArgs e)
        {
            int height = this.picDA.Width * this.picDA.Image.Height / this.picDA.Image.Width;
            this.picDA.Height = height;
        }


        //// 小图焦点改变
        //private void gvSmallPicture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if(this.SelectSmailPicture != null)
        //    {
        //        foreach(Control con in this.imagePanel.Controls)
        //        {
        //            imageTitle it = con.Tag as imageTitle;
        //            if(it.pageNo == this.SelectSmailPicture["PAGE_NO"].ToString() && it.subPage == this.SelectSmailPicture["SUB_PAGE"].ToString())
        //            {
        //                con.Focus();
        //            }
        //        }
        //    }
        //}


        private void gvSmallPicture_Click(object sender, EventArgs e)
        {
            if(this.SelectSmailPicture != null)
            {
                foreach(Control con in this.imagePanel.Controls)
                {
                    NewimageTitle it = con.Tag as NewimageTitle;
                    if(it.pageNo == this.SelectSmailPicture["PAGE_NO"].ToString() && it.subPage == this.SelectSmailPicture["SUB_PAGE"].ToString())
                    {
                        con.Focus();
                    }
                }
            }
        }

        #endregion



        #region IImageCheckView 成员

        public event EventHandler<Views.ImageCheckViewArgs> OnSreach;

        public event EventHandler<Views.ImageCheckViewArgs> OnSelectPic;

        public event EventHandler<Views.ImageCheckViewArgs> OnPass;

        public event EventHandler<Views.ImageCheckViewArgs> OnNoPass;

        public event EventHandler<Views.ImageCheckViewArgs> OnDelete;

        public event EventHandler<Views.ImageCheckViewArgs> OnLockFunction;

        public event EventHandler<Views.ImageCheckViewArgs> OnCheckReason;

        public event EventHandler<Views.ImageCheckViewArgs> OnAddCheckReason;

        public event EventHandler<Views.ImageCheckViewArgs> OnRemoveCheckReason;


        public void ExeCheckReason(DataTable result)
        {
            this.AllCheckReason = result;
        }

        public void ExeLock(bool result)
        {
            throw new NotImplementedException();
        }

        public void ExeOpenLock(bool result)
        {
            throw new NotImplementedException();
        }

        public void ExePass(bool result)
        {
            if(result)
            {
                this.UpdatePicStatus("101", "审核通过");
            }
        }

        public void ExeNoPass(bool result)
        {
            if(result)
            {
                this.UpdatePicStatus("102", "审核未通过");
            }
        }

        public void ExeDelete(bool result)
        {
            if(result)
            {
                this.UpdatePicStatus("103", "已提交");
            }
        }


        public void ExePic(DataTable BigPicture, DataTable SmallPicture, DataTable AllPicture)
        {
            this.AllPicture = AllPicture;
            this.BigPicture = BigPicture;
            this.SmallPicture = SmallPicture;
            this.setPicCount(BigPicture, SmallPicture);
            this.filterPictureData(ref BigPicture, ref SmallPicture);
            this.bindGridView(BigPicture, SmallPicture);
            this.DowImage();
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
            Views.ImageCheckViewArgs imageCheckViewArgs = new Views.ImageCheckViewArgs()
            {
                healthId = healthId
            };
            if(this.OnSelectPic != null)
            {
                this.OnSelectPic(null, imageCheckViewArgs);
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
            switch(keyData)
            {
                case Keys.F1:
                    this.gvBigPicture.Focus();
                    this.gvBigPicture.MovePrev();
                    break;
                case Keys.F2:
                    this.moveToPanel(this.selectPanelNumber - 1);
                    this.gvSmallPicture.Focus();
                    this.gvSmallPicture.MovePrev();
                    break;
                case Keys.F3:
                    this.moveToPanel(this.selectPanelNumber + 1);
                    this.gvSmallPicture.Focus();
                    this.gvSmallPicture.MovePrev();
                    break;
                case Keys.F4:
                    this.gvBigPicture.Focus();
                    this.gvBigPicture.MoveNext();
                    break;
                case Keys.F5:
                    this.Pass();
                    break;
                case Keys.F6:
                    this.NoPass();
                    break;
                case Keys.F7:
                    this.Delete();
                    break;
                case Keys.F9:
                    this.LURecordNO.Focus();
                    this.LURecordNO.SelectAll();
                    break;
                case Keys.F12:
                    this.SelectPic();
                    this.cgPicture.Focus();
                    break;
                default:
                    break;
            }
        }


        #region 病案绑定显示

        // 病案列表绑定事件
        public void BindPic(DataTable picPath)
        {
            if(picPath != null && picPath.Rows != null && picPath.Rows.Count > 0)
            {
                this.imagePanel.Visible = true;
                imagePanel.Controls.Clear();
                this.height = 0;
                List<string> pics = new List<string>();
                for(int i = 0; i < picPath.Rows.Count; i++)
                {
                    string path = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + @"\" + picPath.Rows[i]["STORAGE_PATH"].ToString() + @"\" + picPath.Rows[i]["PICTURE_NAME"].ToString();
                    //if(i == 0)
                    //{
                    //    this.picDA.Image = Image.FromFile(path);
                    //    //this.labTitle.Text = picPath.Rows[i]["pro_name"].ToString();
                    //    //this.labPageNo.Text = picPath.Rows[i]["PAGE_NO"].ToString() + " " + picPath.Rows[i]["SUBPAGE"].ToString();
                    //}
                    this.AddPicStr(picPath.Rows[i], path, picPath.Rows[i]["PRO_NAME"].ToString(), picPath.Rows[i]["PAGE_NO"].ToString(), picPath.Rows[i]["SUBPAGE"].ToString(), i);
                }
                this.moveToPanel(0);
            }
            else
            {
                this.imagePanel.Visible = false;
            }
        }


        private void panel_Enter(object sender, EventArgs e)
        {
            CJia.Controls.CJiaPanel panel = sender as CJia.Controls.CJiaPanel;
            this.movePanel(panel);
        }

        //高度
        private int height = 0;

        //增加病案
        private void AddPic(DataRow picData, Image picImage, string title, string pageNo, string subPage, int i)
        {
            NewimageTitle imagetitle = new NewimageTitle()
            {
                image = picImage,
                title = title,
                pageNo = pageNo,
                subPage = subPage,
                number = i,
                picData = picData
            };
            CJia.Controls.CJiaPicture pic = new Controls.CJiaPicture();
            pic.Image = picImage;
            pic.Location = new System.Drawing.Point(1, 1);
            pic.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            pic.Properties.Appearance.Options.UseBackColor = true;
            pic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pic.Size = new System.Drawing.Size(158, 120);


            CJia.Controls.CJiaLabel label = new Controls.CJiaLabel();
            label.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            label.Location = new System.Drawing.Point(1, 122);
            label.Size = new System.Drawing.Size(156, 16);
            label.Name = picData["PICTURE_ID"].ToString();
            label.Text = title + " " + pageNo + " " + subPage;
            if(picData["CHECK_STATUS"].ToString() == "103")
            {
                label.Appearance.ForeColor = Color.Black;
            }
            else if(picData["CHECK_STATUS"].ToString() == "101")
            {
                label.Appearance.ForeColor = Color.Green;
            }
            else
            {
                label.Appearance.ForeColor = Color.Red;
            }

            CJia.Controls.CJiaLabel line = new Controls.CJiaLabel();
            line.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            line.LineVisible = true;
            line.Location = new System.Drawing.Point(1, 138);
            line.LookAndFeel.SkinName = "Office 2010 Blue";
            line.LookAndFeel.UseDefaultLookAndFeel = false;
            line.Size = new System.Drawing.Size(160, 10);

            CJia.Controls.CJiaPanel panel = new Controls.CJiaPanel();
            panel.Appearance.Options.UseBackColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panel.Controls.Add(pic);
            panel.Controls.Add(label);
            panel.Controls.Add(line);
            panel.Location = new System.Drawing.Point(3, height + 3);
            panel.LookAndFeel.SkinName = "Office 2010 Silver";
            panel.LookAndFeel.UseDefaultLookAndFeel = false;
            panel.Size = new System.Drawing.Size(140, 140);
            panel.Tag = imagetitle;
            panel.Name = "panel" + i.ToString();
            panel.Enter += new System.EventHandler(panel_Enter);

            imagePanel.Controls.Add(panel);

            this.height += 140;
        }

        private void AddPicStr(DataRow picData, string picPham, string title, string pageNo, string subPage, int i)
        {
            Image image = imageCache.GetImage(picPham);
            
            //if(this.AllPictureImage != null)
            //{
            //    bool isHave = false;
            //    foreach(string key in this.AllPictureImage.Keys)
            //    {
            //        if(key == picPham)
            //        {
            //            isHave = true;
            //            break;
            //        }
            //    }
            //    if(isHave)
            //    {
            //        this.AddPic(picData, this.AllPictureImage[picPham], title, pageNo, subPage, i);
            //        return;
            //    }
            //}
            this.AddPic(picData, image, title, pageNo, subPage, i);
        }


        #endregion

        /// <summary>
        /// 应向相对与指定位置的panel
        /// </summary>
        /// <param name="i"></param>
        private void moveToPanel(int i)
        {
            Control[] selects = imagePanel.Controls.Find("panel" + i.ToString(), false);
            if(selects != null && selects.Length > 0)
            {
                this.movePanel((CJia.Controls.CJiaPanel)selects[0]);
            }
        }

        /// <summary>
        /// 一项该panel
        /// </summary>
        /// <param name="panel"></param>
        private void movePanel(CJia.Controls.CJiaPanel panel)
        {
            panel.Focus();
            if(imagePanel.Controls != null && imagePanel.Controls.Count > 0)
            {
                for(int i = 0; i < imagePanel.Controls.Count; i++)
                {
                    if(imagePanel.Controls[i] is CJia.Controls.CJiaPanel)
                    {
                        imagePanel.Controls[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                    }
                }
            }
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            NewimageTitle imagetitle = panel.Tag as NewimageTitle;
            this.selectPanelNumber = imagetitle.number;
            this.SelectPicData = imagetitle.picData;
            this.picDA.Image = imagetitle.image;
            if(imagetitle.picData["CHECK_STATUS"].ToString() == "103")
            {
                this.txtCheckStatusName.ForeColor = Color.Black;
            }
            else if(imagetitle.picData["CHECK_STATUS"].ToString() == "101")
            {
                this.txtCheckStatusName.ForeColor = Color.Green;
            }
            else
            {
                this.txtCheckStatusName.ForeColor = Color.Red;
            }
            this.txtPageNo.Text = imagetitle.pageNo;
            this.txtProName.Text = imagetitle.title;
            this.txtCheckStatusName.Text = imagetitle.picData["CHECK_STATUS_NAME"].ToString();
            this.txtSubPage.Text = imagetitle.subPage;
            //this.labTitle.Text = imagetitle.title;
            //this.labPageNo.Text = imagetitle.pageNo;
        }


        /// <summary>
        /// 赛选出当前该类别的数量
        /// </summary>
        /// <param name="picData"></param>
        /// <returns></returns>
        private DataTable filterPictureData(ref DataTable bigPic, ref DataTable smallPic)
        {
            if(smallPic != null && smallPic.Rows != null && smallPic.Rows.Count > 0)
            {
                string selectValue = this.crdCheck.EditValue.ToString();
                DataTable result = null;
                if(selectValue == "0")
                {
                    result = smallPic.Copy();
                }
                else if(selectValue == "1")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(smallPic.Select(" CHECK_STATUS = '101' "));
                }
                else if(selectValue == "2")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(smallPic.Select(" CHECK_STATUS = '102' "));
                }
                else if(selectValue == "3")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(smallPic.Select(" CHECK_STATUS = '103' "));
                }
                smallPic = result;
                if(smallPic == null)
                {
                    smallPic = this.SmallPicture.Clone();
                }
            }
            if(bigPic != null && bigPic.Rows != null && bigPic.Rows.Count > 0)
            {
                string selectValue = this.crdCheck.EditValue.ToString();
                DataTable result = null;
                string filterStr = " 0 = 1  ";
                if(smallPic != null && smallPic.Rows != null && smallPic.Rows.Count > 0)
                {
                    filterStr = " PAGE_NO IN (";
                    foreach(DataRow small in smallPic.Rows)
                    {
                        filterStr += "'" + small["PAGE_NO"].ToString() + "',";
                    }
                    filterStr = filterStr.Substring(0, filterStr.Length - 1);
                    filterStr += ") ";
                }
                if(selectValue == "0")
                {
                    result = bigPic.Copy();
                }
                else if(selectValue == "1")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(bigPic.Select(" CHECK_STATUS = '101' or " + filterStr));
                }
                else if(selectValue == "2")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(bigPic.Select(" CHECK_STATUS = '102' or " + filterStr));
                }
                else if(selectValue == "3")
                {
                    result = CJia.Health.Tools.Help.GetDataSource(bigPic.Select(" CHECK_STATUS = '103' or " + filterStr));
                }
                bigPic = result;
                if(bigPic == null)
                {
                    bigPic = this.BigPicture.Clone();
                }
            }
            return null;
        }

        /// <summary>
        /// 计算数据中个中类别的数量
        /// </summary>
        /// <param name="picData"></param>
        /// <param name="allNumber"></param>
        /// <param name="passNumber"></param>
        /// <param name="noPassNumber"></param>
        /// <param name="noCheckNumber"></param>
        private void getPicCount(DataTable picData, ref int allNumber, ref int passNumber, ref int noPassNumber, ref int noCheckNumber)
        {
            if(picData != null && picData.Rows != null && picData.Rows.Count > 0)
            {
                DataTable result = null;
                result = picData;
                allNumber = result != null ? result.Rows.Count : 0;
                result = CJia.Health.Tools.Help.GetDataSource(picData.Select(" CHECK_STATUS = '101' "));
                passNumber = result != null ? result.Rows.Count : 0;
                result = CJia.Health.Tools.Help.GetDataSource(picData.Select(" CHECK_STATUS = '102' "));
                noPassNumber = result != null ? result.Rows.Count : 0;
                result = CJia.Health.Tools.Help.GetDataSource(picData.Select(" CHECK_STATUS = '103' "));
                noCheckNumber = result != null ? result.Rows.Count : 0;
            }
            else
            {
                allNumber = 0;
                passNumber = 0;
                noPassNumber = 0;
                noCheckNumber = 0;
            }
        }

        /// <summary>
        /// 设置个状态数量
        /// </summary>
        /// <param name="bigPic"></param>
        /// <param name="smallPic"></param>
        private void setPicCount(DataTable bigPic, DataTable smallPic)
        {
            int allNumber = 0;
            int passNumber = 0;
            int noPassNumber = 0;
            int noCheckNumber = 0;

            int allNumber1 = 0;
            int passNumber1 = 0;
            int noPassNumber1 = 0;
            int noCheckNumber1 = 0;
            string filterStr = " 0 = 1 ";
            if(smallPic != null && smallPic.Rows != null && smallPic.Rows.Count > 0)
            {
                filterStr = " PAGE_NO NOT IN (";

                foreach(DataRow small in smallPic.Rows)
                {
                    filterStr += small["PAGE_NO"].ToString() + ",";
                }
                filterStr = filterStr.Substring(0, filterStr.Length - 1);
                filterStr += ") ";
            }
            bigPic = CJia.Health.Tools.Help.GetDataSource(bigPic.Select(filterStr));
            getPicCount(bigPic, ref allNumber1, ref passNumber1, ref noPassNumber1, ref noCheckNumber1);

            int allNumber2 = 0;
            int passNumber2 = 0;
            int noPassNumber2 = 0;
            int noCheckNumber2 = 0;
            getPicCount(smallPic, ref allNumber2, ref passNumber2, ref noPassNumber2, ref noCheckNumber2);

            allNumber = allNumber1 + allNumber2;
            passNumber = passNumber1 + passNumber2;
            noPassNumber = noPassNumber1 + noPassNumber2;
            noCheckNumber = noCheckNumber1 + noCheckNumber2;

            this.crdCheck.Properties.Items[0].Description = "全部(" + allNumber + ")";
            this.crdCheck.Properties.Items[1].Description = "通过(" + passNumber + ")";
            this.crdCheck.Properties.Items[2].Description = "拒绝(" + noPassNumber + ")";
            this.crdCheck.Properties.Items[3].Description = "提交(" + noCheckNumber + ")";
        }

        /// <summary>
        /// 绑定gridView
        /// </summary>
        /// <param name="BigPicture"></param>
        /// <param name="SmallPicture"></param>
        private void bindGridView(DataTable BigPicture, DataTable SmallPicture)
        {
            DataSet ds = new DataSet();
            if(BigPicture != null && BigPicture.Rows != null && BigPicture.Rows.Count > 0)
            {
                ds.Tables.Add(BigPicture);
                ds.Tables.Add(SmallPicture);
                ds.Tables[0].TableName = "BigPicture";
                ds.Tables[1].TableName = "SmallPicture";
                //不显示分组的面板
                gvBigPicture.OptionsView.ShowGroupPanel = false;
                gvSmallPicture.OptionsView.ShowGroupPanel = false;
                gvBigPicture.OptionsDetail.ShowDetailTabs = false;
                gvSmallPicture.OptionsDetail.ShowDetailTabs = false;
                gvBigPicture.OptionsSelection.MultiSelect = true;

                gvBigPicture.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                //gvSmallPicture.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
                //gvSmallPicture.OptionsDetail.EnableDetailToolTip = false;

                DataRelation relation = new DataRelation("gvSmallPicture",
                                            ds.Tables["BigPicture"].Columns["PAGE_NO"],
                                            ds.Tables["SmallPicture"].Columns["PAGE_NO"]);
                ds.Relations.Add(relation);
                this.cgPicture.DataSource = ds.Tables[0];
                //this.gvBigPicture.ExpandGroupLevel(0);
                //this.gvSmallPicture.ExpandGroupLevel(0);
                //this.gvSmallPicture.ExpandGroupLevel(1);

            }
            else
            {
                cgPicture.DataSource = null;
                return;
            }
        }

        /// <summary>
        /// 下载病案
        /// </summary>
        private void DowImage()
        {
            List<string> picPaths = new List<string>();
            for(int i = 0; i < this.AllPicture.Rows.Count; i++)
            {
                string path = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + @"\" + this.AllPicture.Rows[i]["STORAGE_PATH"].ToString() + @"\" + this.AllPicture.Rows[i]["PICTURE_NAME"].ToString();
                picPaths.Add(path);
            }
            imageCache.DowImage(picPaths);
        }

        /// <summary>
        /// 设置按钮样式
        /// </summary>
        private void SetBtnStyle()
        {
            string checkStatus = this.SelectPicData["CHECK_STATUS"].ToString();
            if(checkStatus == "103")
            {
                this.btnPass.Enabled = true;
                this.btnNoPass.Enabled = true;
                this.btnDelete.Enabled = false;
            }
            else if(checkStatus == "102")
            {
                this.btnPass.Enabled = false;
                this.btnNoPass.Enabled = false;
                this.btnDelete.Enabled = true;
            }
            else if(checkStatus == "101")
            {
                this.btnPass.Enabled = false;
                this.btnNoPass.Enabled = false;
                this.btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        private void Pass()
        {
            string checkStatus = this.SelectPicData["CHECK_STATUS"].ToString();
            if(checkStatus == "103")
            {
                string pictrueId = this.SelectPicData["PICTURE_ID"].ToString();
                this.OnPass(null, new Views.ImageCheckViewArgs()
                {
                    pictureId = pictrueId,
                    originalCheckStatus = this.selectPicData["CHECK_STATUS"].ToString()
                });
            }
        }

        /// <summary>
        /// 审核不通过
        /// </summary>
        private void NoPass()
        {
            string checkStatus = this.SelectPicData["CHECK_STATUS"].ToString();
            if(checkStatus == "103")
            {
                CJia.Health.App.UI.CheckReasonView checkReasonView = new CheckReasonView();
                checkReasonView.OnAddCheckReason += checkReasonView_OnAddCheckReason;
                checkReasonView.OnRemoveCheckReason += checkReasonView_OnRemoveCheckReason;
                this.OnCheckReason(null, null);
                checkReasonView.BindData(this.AllCheckReason);
                this.ShowAsWindow("审核原因", checkReasonView);
                if(checkReasonView.isOk)
                {
                    string pictrueId = this.SelectPicData["PICTURE_ID"].ToString();
                    this.OnNoPass(null, new Views.ImageCheckViewArgs()
                    {
                        pictureId = pictrueId,
                        originalCheckStatus = this.selectPicData["CHECK_STATUS"].ToString(),
                        checkReasonId = checkReasonView.reasonId,
                        checkReason = checkReasonView.reason
                    });
                }
            }
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        private void Delete()
        {
            string checkStatus = this.SelectPicData["CHECK_STATUS"].ToString();
            if(checkStatus == "101" || checkStatus == "102")
            {
                string pictrueId = this.SelectPicData["PICTURE_ID"].ToString();
                this.OnDelete(null, new Views.ImageCheckViewArgs()
                {
                    pictureId = pictrueId,
                    originalCheckStatus = this.selectPicData["CHECK_STATUS"].ToString()
                });
            }
        }

        /// <summary>
        /// 移除审核原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void checkReasonView_OnRemoveCheckReason(object sender, CheckReasonEventArgs e)
        {
            this.OnRemoveCheckReason(null, new Views.ImageCheckViewArgs()
            {
                checkReasonId = e.checkReasonId
            });
        }

        /// <summary>
        /// 增加审核原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void checkReasonView_OnAddCheckReason(object sender, CheckReasonEventArgs e)
        {
            this.OnAddCheckReason(null, new Views.ImageCheckViewArgs()
            {
                checkReason = e.checkReason
            });
        }



        ///// <summary>
        ///// 修改数据中的审核状态
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="checkStatus"></param>
        ///// <param name="checkStatusName"></param>
        //private void UpdateCheckStatus(DataTable dt, string checkStatus, string checkStatusName)
        //{
        //    DataRow[] selectRows = dt.Select(" PAGE_NO = '" + this.selectPicData["PAGE_NO"].ToString() + "'");
        //    if(selectRows != null && selectRows.Length == 1)
        //    {
        //        selectRows[0]["CHECK_STATUS_NAME"] = checkStatusName;
        //        selectRows[0]["CHECK_STATUS"] = checkStatus;
        //    }
        //}

        /// <summary>
        /// 修改数据中的审核状态
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="checkStatus"></param>
        /// <param name="checkStatusName"></param>
        private void UpdateCheckStatus(DataTable dt, string checkStatus, string checkStatusName)
        {
            DataRow[] selectRows = dt.Select(" PAGE_NO = '" + this.selectPicData["PAGE_NO"].ToString() + "'  AND SUBPAGE = '" + this.selectPicData["SUBPAGE"].ToString() + "'");
            if(selectRows != null && selectRows.Length == 1)
            {
                selectRows[0]["CHECK_STATUS_NAME"] = checkStatusName;
                selectRows[0]["CHECK_STATUS"] = checkStatus;
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="checkStatus"></param>
        /// <param name="checkStatusName"></param>
        private void UpdatePicStatus(string checkStatus, string checkStatusName)
        {
            this.UpdateCheckStatus(this.AllPicture, checkStatus, checkStatusName);
            this.UpdateCheckStatus(this.BigPicture, checkStatus, checkStatusName);
            this.UpdateCheckStatus(this.SmallPicture, checkStatus, checkStatusName);
            this.setPicCount(this.BigPicture, this.SmallPicture);
            DataTable dt = this.cgPicture.DataSource as DataTable;
            DataSet ds = dt.DataSet;
            this.UpdateCheckStatus(dt.DataSet.Tables["BigPicture"], checkStatus, checkStatusName);
            this.UpdateCheckStatus(dt.DataSet.Tables["SmallPicture"], checkStatus, checkStatusName);
            this.SelectPicData["CHECK_STATUS_NAME"] = checkStatusName;

            this.SelectPicData["CHECK_STATUS"] = checkStatus;
            this.SetBtnStyle();
            Control[] controls = this.imagePanel.Controls.Find(this.selectPicData["PICTURE_ID"].ToString(), true);
            if(controls != null && controls.Length > 0)
            {
                if(this.SelectPicData["CHECK_STATUS"].ToString() == "103")
                {
                    controls[0].ForeColor = Color.Black;
                }
                else if(this.SelectPicData["CHECK_STATUS"].ToString() == "101")
                {
                    controls[0].ForeColor = Color.Green;
                }
                else
                {
                    controls[0].ForeColor = Color.Red;
                }
            }
            this.txtCheckStatusName.Text = checkStatusName;
            if(this.SelectPicData["CHECK_STATUS"].ToString() == "103")
            {
                this.txtCheckStatusName.ForeColor = Color.Black;
            }
            else if(this.SelectPicData["CHECK_STATUS"].ToString() == "101")
            {
                this.txtCheckStatusName.ForeColor = Color.Green;
            }
            else
            {
                this.txtCheckStatusName.ForeColor = Color.Red;
            }
        }

        #endregion










    }


    public class NewimageTitle
    {
        public Image image;

        public string title;

        public string pageNo;

        public int number;

        public DataRow picData;

        public string subPage;
    }
}
