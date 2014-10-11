using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Controls
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public class CJiaPagingPanel : CJiaPanel
    {
        private CJiaButton btnPagePrev;
        private CJiaButton btnNext;
        private CJiaButton btnPrev;
        private CJiaTextBox txtNum;
        private CJiaButton btnOK;
        private CJiaButton btnFive;
        private CJiaButton btnNine;
        private CJiaButton btnTen;
        private CJiaButton btnEight;
        private CJiaButton btnSeven;
        private CJiaButton btnOne;
        private CJiaButton btnFour;
        private CJiaButton btnSix;
        private CJiaButton btnThree;
        private CJiaButton btnTwo;
        private CJiaPanel cJiaPanel2;
        private CJiaButton btnPageNext;
        /// <summary>
        /// 需要分页的grid
        /// </summary>
        public CJiaGrid BindingGrid;
        /// <summary>
        ///每页显示的数据行数
        /// </summary>
        public int count = 1000;
        /// <summary>
        /// 现在已经取到的所有数据
        /// </summary>
        private DataTable nowAllData;
        /// <summary>
        /// 用于数据访问
        /// </summary>
        private CJia.DataAdapter dataAdapter;
        /// <summary>
        /// 分页id
        /// </summary>
        private int padingId;
        /// <summary>
        /// 是否还有数据没有取出来
        /// </summary>
        private bool HasData;
        /// <summary>
        /// 现在所在页
        /// </summary>
        private int nowPage;
        /// <summary>
        /// 当前总页数
        /// </summary>
        private int nowAllPage;
        /// <summary>
        /// CJiaPagingPanel构造函数
        /// </summary>
        public CJiaPagingPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="PadingId">分页id</param>
        public void BindingData(int PadingId)
        {
            if(this.dataAdapter == null)
                this.dataAdapter = new CJia.DataAdapter("pading");
            if( this.padingId != 0)  
                this.dataAdapter.DeletePaging(this.padingId);
            this.padingId = PadingId;
            this.nowAllData = null;
            this.QueryPageData(1);
            this.GoPage(1);
        }

        /// <summary>
        /// 跳转到第x页
        /// </summary>
        /// <param name="x"></param>
        private void GoPage(int x)
        {
            int maxPage = (this.nowAllData.Rows.Count - 1) / this.count + 1;
            if(x > maxPage)
            {
                if(this.HasData)
                {
                    this.QueryPageData(x);
                    this.GoPage(x);
                    return;
                }
                else
                {
                    x = maxPage;
                }
            }
            else if(x < 1)
            {
                x = 1;
            }
            DataTable newTabel = this.GetPageData(x);
            this.BindingGrid.DataSource = newTabel;
            this.nowPage = x;
            this.AdjustButton();
        }

        /// <summary>
        /// 调整按钮
        /// </summary>
        private void AdjustButton()
        {
            #region 上下一页 与十页的修改
            if(this.nowPage <= 1)
                this.btnPagePrev.Enabled = false;
            else
                this.btnPagePrev.Enabled = true;
            if(this.nowPage <= 10)
                this.btnPrev.Enabled = false;
            else
                this.btnPrev.Enabled = true;
            if(((this.nowPage - 1) / 10 + 1) * 10 >= this.nowAllPage && !this.HasData)
                this.btnNext.Enabled = false;
            else
                this.btnNext.Enabled = true;
            if(this.nowPage >= this.nowAllPage && !this.HasData)
                this.btnPageNext.Enabled = false;
            else
                this.btnPageNext.Enabled = true;
            #endregion
            #region 修改页数值
            int start = ((this.nowPage - 1) / 10) * 10;
            this.btnOne.CustomText = (start + 1).ToString();
            this.btnTwo.CustomText = (start + 2).ToString();
            this.btnThree.CustomText = (start + 3).ToString();
            this.btnFour.CustomText = (start + 4).ToString();
            this.btnFive.CustomText = (start + 5).ToString();
            this.btnSix.CustomText = (start + 6).ToString();
            this.btnSeven.CustomText = (start + 7).ToString();
            this.btnEight.CustomText = (start + 8).ToString();
            this.btnNine.CustomText = (start + 9).ToString();
            this.btnTen.CustomText = (start + 10).ToString();
            #endregion
            #region 修改页数显示情况
            if(start + 1 > this.nowAllPage)
                this.btnOne.Enabled = false;
            else
                this.btnOne.Enabled = true;
            if(start + 2 > this.nowAllPage)
                this.btnTwo.Enabled = false;
            else
                this.btnTwo.Enabled = true;
            if(start + 3 > this.nowAllPage)
                this.btnThree.Enabled = false;
            else
                this.btnThree.Enabled = true;
            if(start + 4 > this.nowAllPage)
                this.btnFour.Enabled = false;
            else
                this.btnFour.Enabled = true;
            if(start + 5 > this.nowAllPage)
                this.btnFive.Enabled = false;
            else
                this.btnFive.Enabled = true;
            if(start + 6 > this.nowAllPage)
                this.btnSix.Enabled = false;
            else
                this.btnSix.Enabled = true;
            if(start + 7 > this.nowAllPage)
                this.btnSeven.Enabled = false;
            else
                this.btnSeven.Enabled = true;
            if(start + 8 > this.nowAllPage)
                this.btnEight.Enabled = false;
            else
                this.btnEight.Enabled = true;
            if(start + 9 > this.nowAllPage)
                this.btnNine.Enabled = false;
            else
                this.btnNine.Enabled = true;
            if(start + 10 > this.nowAllPage)
                this.btnTen.Enabled = false;
            else
                this.btnTen.Enabled = true;
            #endregion
            #region 修改当前页粗体
            if(this.nowPage.ToString() == this.btnOne.CustomText)
            {
                this.btnOne.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnOne.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnTwo.CustomText)
            {
                this.btnTwo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnTwo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnThree.CustomText)
            {
                this.btnThree.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnThree.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnFour.CustomText)
            {
                this.btnFour.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnFour.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnFive.CustomText)
            {
                this.btnFive.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnFive.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnSix.CustomText)
            {
                this.btnSix.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnSix.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnSeven.CustomText)
            {
                this.btnSeven.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnSeven.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnEight.CustomText)
            {
                this.btnEight.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnEight.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnNine.CustomText)
            {
                this.btnNine.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnNine.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            if(this.nowPage.ToString() == this.btnTen.CustomText)
            {
                this.btnTen.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                this.btnTen.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            }
            #endregion
        }

        /// <summary>
        /// 获取第x页的数据
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private DataTable GetPageData(int x)
        {
            DataTable newTabel = this.nowAllData.Clone();
            for(int i = (x - 1) * this.count; i < x * this.count && i < this.nowAllData.Rows.Count; i++)
            {
                DataRow newRow = newTabel.NewRow();
                newRow.ItemArray = this.nowAllData.Rows[i].ItemArray;
                newTabel.Rows.Add(newRow);
            }
            return newTabel;
        }

        /// <summary>
        /// 将新获取的数据加到现有数据中
        /// </summary>
        /// <param name="newData"></param>
        private void addData(DataTable newData)
        {
            if(this.nowAllData == null)
            {
                this.nowAllData = newData.Clone();
            }
            if(newData != null && newData.Rows.Count > 0)
            {
                foreach(DataRow row in newData.Rows)
                {
                    DataRow newRow = this.nowAllData.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    this.nowAllData.Rows.Add(newRow);
                }
            }
        }

        /// <summary>
        /// 查询到第x页的数据
        /// </summary>
        /// <param name="x"></param>
        private void QueryPageData(int x)
        {
            int allPage = ((x - 1) / 10 + 1) * 10;
            int addCount = allPage * this.count;
            if(this.nowAllData != null)
                addCount = addCount - this.nowAllData.Rows.Count;
            DataTable result = this.dataAdapter.QueryPagingData(this.padingId, addCount);
            if(result.Rows.Count == addCount)
            {
                this.HasData = true;
            }
            else
            {
                this.HasData = false;
            }
            this.addData(result);
            this.nowAllPage = (this.nowAllData.Rows.Count - 1) / this.count + 1;
        }

        private void InitializeComponent()
        {
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.btnSix = new CJia.Controls.CJiaButton();
            this.btnFive = new CJia.Controls.CJiaButton();
            this.btnPageNext = new CJia.Controls.CJiaButton();
            this.btnNine = new CJia.Controls.CJiaButton();
            this.btnPrev = new CJia.Controls.CJiaButton();
            this.btnTen = new CJia.Controls.CJiaButton();
            this.btnNext = new CJia.Controls.CJiaButton();
            this.btnEight = new CJia.Controls.CJiaButton();
            this.btnPagePrev = new CJia.Controls.CJiaButton();
            this.btnSeven = new CJia.Controls.CJiaButton();
            this.txtNum = new CJia.Controls.CJiaTextBox();
            this.btnOne = new CJia.Controls.CJiaButton();
            this.btnOK = new CJia.Controls.CJiaButton();
            this.btnFour = new CJia.Controls.CJiaButton();
            this.btnTwo = new CJia.Controls.CJiaButton();
            this.btnThree = new CJia.Controls.CJiaButton();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cJiaPanel2.Appearance.Options.UseBackColor = true;
            this.cJiaPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaPanel2.Controls.Add(this.btnSix);
            this.cJiaPanel2.Controls.Add(this.btnFive);
            this.cJiaPanel2.Controls.Add(this.btnPageNext);
            this.cJiaPanel2.Controls.Add(this.btnNine);
            this.cJiaPanel2.Controls.Add(this.btnPrev);
            this.cJiaPanel2.Controls.Add(this.btnTen);
            this.cJiaPanel2.Controls.Add(this.btnNext);
            this.cJiaPanel2.Controls.Add(this.btnEight);
            this.cJiaPanel2.Controls.Add(this.btnPagePrev);
            this.cJiaPanel2.Controls.Add(this.btnSeven);
            this.cJiaPanel2.Controls.Add(this.txtNum);
            this.cJiaPanel2.Controls.Add(this.btnOne);
            this.cJiaPanel2.Controls.Add(this.btnOK);
            this.cJiaPanel2.Controls.Add(this.btnFour);
            this.cJiaPanel2.Controls.Add(this.btnTwo);
            this.cJiaPanel2.Controls.Add(this.btnThree);
            this.cJiaPanel2.Location = new System.Drawing.Point(8, 4);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(470, 28);
            this.cJiaPanel2.TabIndex = 0;
            // 
            // btnSix
            // 
            this.btnSix.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSix.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnSix.Appearance.Options.UseFont = true;
            this.btnSix.Appearance.Options.UseForeColor = true;
            this.btnSix.CustomText = "6";
            this.btnSix.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSix.Location = new System.Drawing.Point(205, 3);
            this.btnSix.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSix.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSix.Name = "btnSix";
            this.btnSix.Selectable = false;
            this.btnSix.Size = new System.Drawing.Size(30, 22);
            this.btnSix.TabIndex = 8;
            this.btnSix.Text = "6";
            this.btnSix.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnFive
            // 
            this.btnFive.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnFive.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnFive.Appearance.Options.UseFont = true;
            this.btnFive.Appearance.Options.UseForeColor = true;
            this.btnFive.CustomText = "5";
            this.btnFive.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFive.Location = new System.Drawing.Point(176, 3);
            this.btnFive.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnFive.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFive.Name = "btnFive";
            this.btnFive.Selectable = false;
            this.btnFive.Size = new System.Drawing.Size(30, 22);
            this.btnFive.TabIndex = 7;
            this.btnFive.Text = "5";
            this.btnFive.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPageNext.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPageNext.Appearance.Options.UseFont = true;
            this.btnPageNext.Appearance.Options.UseForeColor = true;
            this.btnPageNext.CustomText = "";
            this.btnPageNext.Image = global::CJia.Controls.Properties.Resources.Next;
            this.btnPageNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPageNext.Location = new System.Drawing.Point(437, 3);
            this.btnPageNext.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPageNext.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Selectable = false;
            this.btnPageNext.Size = new System.Drawing.Size(30, 22);
            this.btnPageNext.TabIndex = 16;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnNine
            // 
            this.btnNine.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNine.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnNine.Appearance.Options.UseFont = true;
            this.btnNine.Appearance.Options.UseForeColor = true;
            this.btnNine.CustomText = "9";
            this.btnNine.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNine.Location = new System.Drawing.Point(292, 3);
            this.btnNine.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNine.Name = "btnNine";
            this.btnNine.Selectable = false;
            this.btnNine.Size = new System.Drawing.Size(30, 22);
            this.btnNine.TabIndex = 11;
            this.btnNine.Text = "9";
            this.btnNine.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnPrev
            // 
            this.btnPrev.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnPrev.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Appearance.Options.UseForeColor = true;
            this.btnPrev.Appearance.Options.UseTextOptions = true;
            this.btnPrev.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnPrev.CustomText = "...";
            this.btnPrev.Location = new System.Drawing.Point(31, 3);
            this.btnPrev.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPrev.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Selectable = false;
            this.btnPrev.Size = new System.Drawing.Size(30, 22);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "...";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnTen
            // 
            this.btnTen.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnTen.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnTen.Appearance.Options.UseFont = true;
            this.btnTen.Appearance.Options.UseForeColor = true;
            this.btnTen.CustomText = "10";
            this.btnTen.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTen.Location = new System.Drawing.Point(321, 3);
            this.btnTen.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnTen.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTen.Name = "btnTen";
            this.btnTen.Selectable = false;
            this.btnTen.Size = new System.Drawing.Size(30, 22);
            this.btnTen.TabIndex = 12;
            this.btnTen.Text = "10";
            this.btnTen.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.Appearance.Options.UseTextOptions = true;
            this.btnNext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnNext.CustomText = "...";
            this.btnNext.Location = new System.Drawing.Point(408, 3);
            this.btnNext.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNext.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNext.Name = "btnNext";
            this.btnNext.Selectable = false;
            this.btnNext.Size = new System.Drawing.Size(30, 22);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "...";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnEight
            // 
            this.btnEight.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEight.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnEight.Appearance.Options.UseFont = true;
            this.btnEight.Appearance.Options.UseForeColor = true;
            this.btnEight.CustomText = "8";
            this.btnEight.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEight.Location = new System.Drawing.Point(263, 3);
            this.btnEight.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnEight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEight.Name = "btnEight";
            this.btnEight.Selectable = false;
            this.btnEight.Size = new System.Drawing.Size(30, 22);
            this.btnEight.TabIndex = 10;
            this.btnEight.Text = "8";
            this.btnEight.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnPagePrev
            // 
            this.btnPagePrev.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPagePrev.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPagePrev.Appearance.Options.UseFont = true;
            this.btnPagePrev.Appearance.Options.UseForeColor = true;
            this.btnPagePrev.CustomText = "";
            this.btnPagePrev.Image = global::CJia.Controls.Properties.Resources.Prev;
            this.btnPagePrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPagePrev.Location = new System.Drawing.Point(2, 3);
            this.btnPagePrev.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPagePrev.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPagePrev.Name = "btnPagePrev";
            this.btnPagePrev.Selectable = false;
            this.btnPagePrev.Size = new System.Drawing.Size(30, 22);
            this.btnPagePrev.TabIndex = 1;
            this.btnPagePrev.Click += new System.EventHandler(this.btnPagePrev_Click);
            // 
            // btnSeven
            // 
            this.btnSeven.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSeven.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnSeven.Appearance.Options.UseFont = true;
            this.btnSeven.Appearance.Options.UseForeColor = true;
            this.btnSeven.CustomText = "7";
            this.btnSeven.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSeven.Location = new System.Drawing.Point(234, 3);
            this.btnSeven.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSeven.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Selectable = false;
            this.btnSeven.Size = new System.Drawing.Size(30, 22);
            this.btnSeven.TabIndex = 9;
            this.btnSeven.Text = "7";
            this.btnSeven.Click += new System.EventHandler(this.btnNumber);
            // 
            // txtNum
            // 
            this.txtNum.EditValue = "";
            this.txtNum.Location = new System.Drawing.Point(351, 3);
            this.txtNum.Name = "txtNum";
            this.txtNum.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNum.Properties.Appearance.Options.UseBackColor = true;
            this.txtNum.Properties.Appearance.Options.UseFont = true;
            this.txtNum.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtNum.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNum.Size = new System.Drawing.Size(28, 20);
            this.txtNum.TabIndex = 13;
            // 
            // btnOne
            // 
            this.btnOne.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOne.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnOne.Appearance.Options.UseFont = true;
            this.btnOne.Appearance.Options.UseForeColor = true;
            this.btnOne.CustomText = "1";
            this.btnOne.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOne.Location = new System.Drawing.Point(60, 3);
            this.btnOne.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnOne.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOne.Name = "btnOne";
            this.btnOne.Selectable = false;
            this.btnOne.Size = new System.Drawing.Size(30, 22);
            this.btnOne.TabIndex = 3;
            this.btnOne.Text = "1";
            this.btnOne.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.CustomText = "OK";
            this.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOK.Location = new System.Drawing.Point(379, 3);
            this.btnOK.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Selectable = false;
            this.btnOK.Size = new System.Drawing.Size(30, 22);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFour
            // 
            this.btnFour.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnFour.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnFour.Appearance.Options.UseFont = true;
            this.btnFour.Appearance.Options.UseForeColor = true;
            this.btnFour.CustomText = "4";
            this.btnFour.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFour.Location = new System.Drawing.Point(147, 3);
            this.btnFour.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnFour.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFour.Name = "btnFour";
            this.btnFour.Selectable = false;
            this.btnFour.Size = new System.Drawing.Size(30, 22);
            this.btnFour.TabIndex = 6;
            this.btnFour.Text = "4";
            this.btnFour.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnTwo
            // 
            this.btnTwo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnTwo.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnTwo.Appearance.Options.UseFont = true;
            this.btnTwo.Appearance.Options.UseForeColor = true;
            this.btnTwo.CustomText = "2";
            this.btnTwo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTwo.Location = new System.Drawing.Point(89, 3);
            this.btnTwo.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnTwo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Selectable = false;
            this.btnTwo.Size = new System.Drawing.Size(30, 22);
            this.btnTwo.TabIndex = 4;
            this.btnTwo.Text = "2";
            this.btnTwo.Click += new System.EventHandler(this.btnNumber);
            // 
            // btnThree
            // 
            this.btnThree.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnThree.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.btnThree.Appearance.Options.UseFont = true;
            this.btnThree.Appearance.Options.UseForeColor = true;
            this.btnThree.CustomText = "3";
            this.btnThree.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThree.Location = new System.Drawing.Point(118, 3);
            this.btnThree.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnThree.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThree.Name = "btnThree";
            this.btnThree.Selectable = false;
            this.btnThree.Size = new System.Drawing.Size(30, 22);
            this.btnThree.TabIndex = 5;
            this.btnThree.Text = "3";
            this.btnThree.Click += new System.EventHandler(this.btnNumber);
            // 
            // CJiaPagingPanel
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Controls.Add(this.cJiaPanel2);
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Size = new System.Drawing.Size(560, 36);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region 按钮事件
        //上一页
        private void btnPagePrev_Click(object sender, EventArgs e)
        {
            this.GoPage(this.nowPage - 1);
        }
        //上十页
        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.GoPage(((this.nowPage - 1) / 10) * 10);
        }
        //下一页
        private void btnPageNext_Click(object sender, EventArgs e)
        {
            this.GoPage(this.nowPage + 1);
        }
        //下十页 
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.GoPage(((this.nowPage - 1) / 10 + 1) * 10 + 1);
        }
        //页数按钮
        private void btnNumber(object sender, EventArgs e)
        {
            this.GoPage(int.Parse((sender as CJiaButton).Text));
        }
        //ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int page = int.Parse(this.txtNum.Text);
                this.GoPage(page);
                this.txtNum.Text = this.nowPage.ToString();
            }
            catch
            {
                this.txtNum.Text = "";
            }
        }
        #endregion
    }
}
