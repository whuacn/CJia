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

namespace CJia.Health.App.UI
{
    public partial class PrintApplyView : CJia.Health.Tools.View, CJia.Health.Views.IPrintApplyView
    {
        public PrintApplyView()
        {
            InitializeComponent();
            InitValue();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
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
            chkPicture.Items.Clear();
            if (dtPicture != null && dtPicture.Rows.Count > 0)
            {
                DataTable data = dtPicture.Clone();
                foreach (DataRow dr in dtPicture.Rows)//by dh
                {
                    //dr["SRC"] = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH") + @"\" + dr["SRC"];
                    string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                    dr["SRC"] = host + "/" + dr["SRC"].ToString().Replace('\\', '/');
                    //    this.chkPicture.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
                    //new DevExpress.XtraEditors.Controls.CheckedListBoxItem(dr["SRC"])});
                    if (dr["IS_PRINT"].ToString() == "1")//不可打印的项目分类，不显示
                    {
                        data.Rows.Add(dr.ItemArray);
                    }
                }
                chkPicture.DisplayMember = "PIC_INFO";
                chkPicture.ValueMember = "SRC";
                //dtPicture.Columns.Add();
                chkPicture.DataSource = data;
            }
        }
        #endregion

        #region 【界面事件响应】
        private void btnPatientSearch_Click(object sender, EventArgs e)
        {
            PatientSearch();
        }

        private void txtRecotdNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PatientSearch();
            }
        }

        // 
        private void gvPatientInfo_DoubleClick(object sender, EventArgs e)
        {
            //IsLoadChk = 0;
            if (gvPatientInfo.GetFocusedDataRow() == null)
            {
                return;
            }
            OnPatientDoubleClick(sender, SetArgs());
            //PictureState();
        }
        //Thread thread;
        //UI.Loading load;
        private void chkPicture_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (IsLoadChk == 0)
            //{
            //    IsLoadChk = 1;
            //    return;
            //}
            if (chkPicture.SelectedIndex >= 0)
            {
                try
                {
                    //this.ParentForm.Enabled = false;
                   //load = new UI.Loading();
                    //CJia.Health.Tools.Help.NewRedBorderFrom(load);
                    //thread = new Thread(new ParameterizedThreadStart(Loading));
                    //thread.Start((object)chkPicture.SelectedValue.ToString());
                    //Image img = Image.FromFile(chkPicture.SelectedValue.ToString());
                    //Image img = CJia.Health.Tools.Help.GetImageByUri(chkPicture.SelectedValue.ToString(), UserName, Password);
                    Loading((object)chkPicture.SelectedValue.ToString());
                }
                catch
                { 
                    
                }
            }
        }
        private void Loading(object uri)
        {
            Image img = CJia.Health.Tools.Help.GetImageByUri(uri.ToString(), UserName, Password);
            //load.ParentForm.Close();
            //this.ParentForm.Enabled = true;
            if (img != null)
            {
                int panel_W = pnlPicture.Width;
                float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                cJiaPicture.Width = panel_W - 20;
                float height = i * (panel_W - 20);
                cJiaPicture.Height = Convert.ToInt32(height);
                cJiaPicture.Image = img;
            }
            else
            {
                Message.Show("此图片不存在或已删除，请与管理员联系。。。");
            }
            //this.ParentForm.Activate();
        }
        // 打印按钮
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            Image image;
            listPic.Clear();
            for (int i = 0; i < chkPicture.CheckedIndices.Count; i++)
            {
                pageNo = i;
                image = CJia.Health.Tools.Help.GetImageByUri(chkPicture.CheckedItems[i].ToString(), UserName, Password);
                //listPic.Add(Image.FromFile(chkPicture.CheckedItems[i].ToString()));
                listPic.Add(image);
                printDialog.Document = printDocument1;

                //if (printDialog.ShowDialog() == DialogResult.OK)
                //{
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
                //}
            }
        }

        //// 打印每张图片
        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{


        //    if (e.PageSettings.PaperSize.PaperName.Equals("A4"))
        //    {
        //        printDocument1.DefaultPageSettings.PaperSize = e.PageSettings.PaperSize;
        //    }
        //    int x = e.PageSettings.PaperSize.Width;//打印机默认纸张大小
        //    int y = e.PageSettings.PaperSize.Height;

        //    int resultWidth;
        //    int resultHeight;

        //    if (((decimal)listPic[pageNo].Width) / listPic[pageNo].Height <= ((decimal)x) / y)
        //    {
        //        resultWidth = x;
        //        resultHeight = x * listPic[pageNo].Height / listPic[pageNo].Width;
        //    }
        //    else
        //    {
        //        resultWidth = y * listPic[pageNo].Width / listPic[pageNo].Height;
        //        resultHeight = y;
        //    }


        //    //Rectangle destRect = new Rectangle(0, 0, resultWidth, resultHeight);//背景图片打印区域
        //    Rectangle destRect = new Rectangle(0, 0, x, y);
        //    e.Graphics.DrawImage(listPic[pageNo], destRect, 0, 0, listPic[pageNo].Width, listPic[pageNo].Height, System.Drawing.GraphicsUnit.Pixel);
        //}

        // 打印每张图片
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            if (e.PageSettings.PaperSize.PaperName.Equals("A4"))
            {
                printDocument1.DefaultPageSettings.PaperSize = e.PageSettings.PaperSize;
            }

            // 等比例缩小放大图片
            int newWidth = e.PageSettings.PaperSize.Width;//打印机默认纸张大小
            int newHeight = e.PageSettings.PaperSize.Height;

            int iWidth = listPic[pageNo].Width;
            int iHeight = listPic[pageNo].Height;

            //如果宽和高都超过最大限制
            if (iWidth > newWidth && iHeight > newHeight)
            {
                //判断下是宽更长还是高更长，以便以它做标准
                if ((double)iHeight / (double)iWidth > (double)newHeight / (double)newWidth)
                {
                    //如果是高更长，设置高为最大限制值，宽等比例缩小
                    newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
                }
                else
                {
                    //如果是宽更长，设置宽为最大限制值，高等比例缩小
                    newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
                }
            }
            else if (iWidth > newWidth && iHeight <= newHeight)
            {
                //如果只是宽超过限制，设置宽为最大值，高等比例缩小
                newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
            }
            else if (iWidth <= newWidth && iHeight > newHeight)
            {
                //如果只是高超过限制，设置高为最大值，宽等比例缩小
                newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
            }
            else
            {
                //如果都没超过则用原来的大小
                newWidth = iWidth;
                newHeight = iHeight;
            }
            //Bitmap bitMap = new Bitmap(listPic[pageNo],newWidth,newHeight);
            //Rectangle destRect = new Rectangle(0, 0, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height);
            //e.Graphics.DrawImage(bitMap, 0, 0, newWidth, newHeight);
            e.Graphics.DrawImage(listPic[pageNo], 0, 0, newWidth, newHeight);
        }

        // 全选状态
        private void chkAllPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPicture.Checked)
            {
                for (int i = 0; i < chkPicture.Items.Count; i++)
                {
                    this.chkPicture.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
                }
            }
            else
            {
                for (int i = 0; i < chkPicture.Items.Count; i++)
                {
                    this.chkPicture.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
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
            this.cboStartDate.EditValue = new DateTime(now.Year - 1, now.Month, now.Day, 0, 0, 0);
            this.cboEndDate.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
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
            printApplyArgs.RecordNo = txtRecotdNo.Text;

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

        ///// <summary>
        ///// 页面加载时病区选择状态
        ///// </summary>
        //private void PictureState()
        //{
        //    chkAllPicture.CheckState = CheckState.Checked;
        //    for (int i = 0; i < chkPicture.Items.Count; i++)
        //    {
        //        this.chkPicture.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
        //    }
        //    if (chkPicture.Items.Count == 0)
        //    {
        //        cJiaPicture1.Image = null;
        //    }
        //}
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
                case Keys.F7:
                    btnPrint.Focus();
                    btnPrint_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

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
                int Grasp_y = pnlPicture.AutoScrollPosition.Y;
                int Grasp_x = pnlPicture.AutoScrollPosition.X;
                int x, y;
                int move_y; //滚动的位置
                int move_x;
                x = m_StarPoint.X - e.X;
                y = m_StarPoint.Y - e.Y;
                if (Grasp_y - y > 0) move_y = 0;
                else move_y = Grasp_y - y;
                if (Grasp_x - x > 0) move_x = 0;
                else move_x = Grasp_x - x;
                pnlPicture.AutoScrollPosition = new Point(Math.Abs(move_x), Math.Abs(move_y));
            }
        }

        private void cJiaPicture_MouseUp(object sender, MouseEventArgs e)
        {
            m_StarMove = false;
            cJiaPicture.Cursor = Cursors.Default;
        }
        private Point m_StarPoint = Point.Empty;        //for 拖动
        private Point m_ViewPoint = Point.Empty;
        private bool m_StarMove = false;

        private void btnBig_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.FangDa(cJiaPicture, true);
        }

        private void btnSmall_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.FangDa(cJiaPicture, false);
        }

        private void btnNiX_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.XuanZhuang(cJiaPicture, true);
        }

        private void btnShunX_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.XuanZhuang(cJiaPicture, false);
        }

        private void btnShij_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.InFactSize(cJiaPicture, true);
        }

        private void btnHeShi_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.Help.InFactSize(cJiaPicture, false);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (cJiaPicture.Image == null)
            {
                btnBig.Enabled = false;
                btnSmall.Enabled = false;
                btnNiX.Enabled = false;
                btnShunX.Enabled = false;
                btnShij.Enabled = false;
                btnHeShi.Enabled = false;
            }
            else
            {
                btnBig.Enabled = true;
                btnSmall.Enabled = true;
                btnNiX.Enabled = true;
                btnShunX.Enabled = true;
                btnShij.Enabled = true;
                btnHeShi.Enabled = true;
            }
        }
    }
}
