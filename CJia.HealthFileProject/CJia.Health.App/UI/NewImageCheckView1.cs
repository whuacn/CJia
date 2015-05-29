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
    public partial class NewImageCheckView1 : CJia.Health.Tools.View, CJia.Health.Views.INewImageCheckView
    {
        public NewImageCheckView1()
        {
            InitializeComponent();
            this.LURecordNO.GetData += LURecordNO_GetData;
            this.LURecordNO.SelectValueChanged += LURecordNO_SelectValueChanged;
        }



        protected override object CreatePresenter()
        {
            return new Presenters.NewImageCheckPresenter(this);
        }

        #region  属性

        /// <summary>
        /// 该病人所有病案
        /// </summary>
        private DataTable AllPicture = null;

        //private Dictionary<string, Image> AllPictureImage = null;

        //private DataTable BigPicture = null;

        //private DataTable SmallPicture = null;

        /// <summary>
        /// 选择的病案
        /// </summary>
        private DataRow SelectPicture
        {
            get
            {
                DataRow selectRow = this.gvPicture.GetFocusedDataRow();
                return selectRow;
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
            Views.NewImageCheckViewArgs NewImageCheckViewArgs = new Views.NewImageCheckViewArgs()
            {
                healthId = healthId
            };
            if(this.OnSreach != null)
            {
                this.OnSreach(null, NewImageCheckViewArgs);
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
                string stutas = this.gvPicture.GetDataRow(e.RowHandle)["CHECK_STATUS"].ToString();
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

            if(e.RowHandle == this.gvPicture.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(93, 175, 223);
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
            DataTable result = this.filterPictureData(this.AllPicture);
            this.bindGridView(result);
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

        public void ExeYesLook(bool result)
        {
            if (result)
            {

            }
        }

        public void ExeNoLook(bool result)
        {
            if (result)
            {

            }
        }

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


        public void ExePic(DataTable AllPicture)
        {
            this.AllPicture = AllPicture;
            this.setPicCount(AllPicture);
            DataTable result = this.filterPictureData(AllPicture);
            this.bindGridView(result);
            //this.DowImage();
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
            if(this.OnSelectPic != null)
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
            switch(keyData)
            {
                case Keys.F1:
                    this.gvPicture.Focus();
                    this.gvPicture.MovePrev();
                    break;
                case Keys.F4:
                    this.gvPicture.Focus();
                    this.gvPicture.MoveNext();
                    break;
                case Keys.F5:
                    if(this.Pass())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
                    break;
                case Keys.F6:
                    if(this.NoPass())
                    {
                        this.gvPicture.Focus();
                        this.gvPicture.MoveNext();
                    }
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
        public void BindPic(DataRow picPath)
        {
            if(picPath != null)
            {
                string path = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + @"\" + picPath["STORAGE_PATH"].ToString() + @"\" + picPath["PICTURE_NAME"].ToString();

                //this.picDA.Image = imageCache.GetImage(path);
                this.picDA.Image = Image.FromFile(path);
                if(picPath["CHECK_STATUS"].ToString() == "103")
                {
                    this.txtCheckStatusName.ForeColor = Color.Black;
                }
                else if(picPath["CHECK_STATUS"].ToString() == "101")
                {
                    this.txtCheckStatusName.ForeColor = Color.Green;
                }
                else
                {
                    this.txtCheckStatusName.ForeColor = Color.Red;
                }
                this.txtPageNo.Text = picPath["PAGE_NO"].ToString();
                this.txtProName.Text = picPath["PRO_NAME"].ToString();
                this.txtCheckStatusName.Text = picPath["CHECK_STATUS_NAME"].ToString();
                this.txtSubPage.Text = picPath["SUBPAGE"].ToString();
                this.selectPicData = picPath;
                this.SetBtnStyle();
            }
        }


        #endregion

        /// <summary>
        /// 赛选出当前该类别的数量
        /// </summary>
        /// <param name="picData"></param>
        /// <returns></returns>
        private DataTable filterPictureData(DataTable AllPicture)
        {
            string selectValue = this.crdCheck.EditValue.ToString();
            DataTable result = null;
            if(selectValue == "0")
            {
                result = AllPicture.Copy();
            }
            else if(selectValue == "1")
            {
                result = CJia.Health.Tools.Help.GetDataSource(AllPicture.Select(" CHECK_STATUS = '101' "));
            }
            else if(selectValue == "2")
            {
                result = CJia.Health.Tools.Help.GetDataSource(AllPicture.Select(" CHECK_STATUS = '102' "));
            }
            else if(selectValue == "3")
            {
                result = CJia.Health.Tools.Help.GetDataSource(AllPicture.Select(" CHECK_STATUS = '103' "));
            }
            return result;
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
        private void setPicCount(DataTable AllPicture)
        {
            int allNumber = 0;
            int passNumber = 0;
            int noPassNumber = 0;
            int noCheckNumber = 0;
            getPicCount(AllPicture, ref allNumber, ref passNumber, ref noPassNumber, ref noCheckNumber);


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
        private void bindGridView(DataTable PicData)
        {
            this.cgPicture.DataSource = PicData;
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
        private bool Pass()
        {
            string checkStatus = this.SelectPicData["CHECK_STATUS"].ToString();
            if(checkStatus == "103")
            {
                string pictrueId = this.SelectPicData["PICTURE_ID"].ToString();
                this.OnPass(null, new Views.NewImageCheckViewArgs()
                {
                    pictureId = pictrueId,
                    originalCheckStatus = this.selectPicData["CHECK_STATUS"].ToString()
                });
                return true;
            }
            return false;
        }

        /// <summary>
        /// 审核不通过
        /// </summary>
        private bool NoPass()
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
                    this.OnNoPass(null, new Views.NewImageCheckViewArgs()
                    {
                        pictureId = pictrueId,
                        originalCheckStatus = this.selectPicData["CHECK_STATUS"].ToString(),
                        checkReasonId = checkReasonView.reasonId,
                        checkReason = checkReasonView.reason
                    });
                    return true;
                }
            }
            return false;
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
                this.OnDelete(null, new Views.NewImageCheckViewArgs()
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
            this.OnRemoveCheckReason(null, new Views.NewImageCheckViewArgs()
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
            this.OnAddCheckReason(null, new Views.NewImageCheckViewArgs()
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
            this.setPicCount(this.AllPicture);
            DataTable dt = this.cgPicture.DataSource as DataTable;
            this.UpdateCheckStatus(dt, checkStatus, checkStatusName);
            this.SelectPicData["CHECK_STATUS_NAME"] = checkStatusName;

            this.SelectPicData["CHECK_STATUS"] = checkStatus;
            this.SetBtnStyle();
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


}
