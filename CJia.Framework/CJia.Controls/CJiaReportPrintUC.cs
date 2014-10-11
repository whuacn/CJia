using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 报表打印选择界面
    /// </summary>
    public class CJiaReportPrintUC : DevExpress.XtraEditors.XtraUserControl
    {
        private CJiaGrid cJiaGrid1;
        private CJiaPanel cJiaPanel1;
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
        private CJiaPagingPanel cJiaPagingPanel1;
        private CJiaPagingPanel cJiaPagingPanel2;
        private CJiaButton btnPageNext;
    
        public CJiaReportPrintUC()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CJiaReportPrintUC));
            this.cJiaGrid1 = new CJia.Controls.CJiaGrid();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.btnSix = new CJia.Controls.CJiaButton();
            this.btnFive = new CJia.Controls.CJiaButton();
            this.btnPrev = new CJia.Controls.CJiaButton();
            this.btnPageNext = new CJia.Controls.CJiaButton();
            this.btnNine = new CJia.Controls.CJiaButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaGrid1
            // 
            this.cJiaGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaGrid1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaGrid1.IndicatorWidth = 30;
            this.cJiaGrid1.Location = new System.Drawing.Point(3, 3);
            this.cJiaGrid1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaGrid1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaGrid1.Name = "cJiaGrid1";
            this.cJiaGrid1.ShowRowNumber = true;
            this.cJiaGrid1.Size = new System.Drawing.Size(649, 198);
            this.cJiaGrid1.TabIndex = 0;
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.cJiaPanel1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.cJiaPanel1.Appearance.Options.UseBackColor = true;
            this.cJiaPanel1.Appearance.Options.UseBorderColor = true;
            this.cJiaPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cJiaPanel1.Controls.Add(this.cJiaPanel2);
            this.cJiaPanel1.Location = new System.Drawing.Point(14, 224);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(599, 37);
            this.cJiaPanel1.TabIndex = 1;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cJiaPanel2.Appearance.Options.UseBackColor = true;
            this.cJiaPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaPanel2.Controls.Add(this.btnSix);
            this.cJiaPanel2.Controls.Add(this.btnFive);
            this.cJiaPanel2.Controls.Add(this.btnPrev);
            this.cJiaPanel2.Controls.Add(this.btnPageNext);
            this.cJiaPanel2.Controls.Add(this.btnNine);
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
            this.cJiaPanel2.Size = new System.Drawing.Size(552, 28);
            this.cJiaPanel2.TabIndex = 19;
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
            // 
            // btnPrev
            // 
            this.btnPrev.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPrev.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Appearance.Options.UseForeColor = true;
            this.btnPrev.CustomText = "";
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrev.Location = new System.Drawing.Point(2, 3);
            this.btnPrev.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPrev.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Selectable = false;
            this.btnPrev.Size = new System.Drawing.Size(30, 22);
            this.btnPrev.TabIndex = 2;
            // 
            // btnPageNext
            // 
            this.btnPageNext.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnPageNext.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPageNext.Appearance.Options.UseFont = true;
            this.btnPageNext.Appearance.Options.UseForeColor = true;
            this.btnPageNext.Appearance.Options.UseTextOptions = true;
            this.btnPageNext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnPageNext.CustomText = "...";
            this.btnPageNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPageNext.Location = new System.Drawing.Point(408, 3);
            this.btnPageNext.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPageNext.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Selectable = false;
            this.btnPageNext.Size = new System.Drawing.Size(30, 22);
            this.btnPageNext.TabIndex = 16;
            this.btnPageNext.Text = "...";
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
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.CustomText = "";
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNext.Location = new System.Drawing.Point(437, 3);
            this.btnNext.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNext.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNext.Name = "btnNext";
            this.btnNext.Selectable = false;
            this.btnNext.Size = new System.Drawing.Size(30, 22);
            this.btnNext.TabIndex = 15;
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
            // 
            // btnPagePrev
            // 
            this.btnPagePrev.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnPagePrev.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPagePrev.Appearance.Options.UseFont = true;
            this.btnPagePrev.Appearance.Options.UseForeColor = true;
            this.btnPagePrev.Appearance.Options.UseTextOptions = true;
            this.btnPagePrev.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnPagePrev.CustomText = "...";
            this.btnPagePrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPagePrev.Location = new System.Drawing.Point(31, 3);
            this.btnPagePrev.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPagePrev.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPagePrev.Name = "btnPagePrev";
            this.btnPagePrev.Selectable = false;
            this.btnPagePrev.Size = new System.Drawing.Size(30, 22);
            this.btnPagePrev.TabIndex = 1;
            this.btnPagePrev.Text = "...";
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
            // 
            // cJiaPagingPanel2
            // 
            this.cJiaPagingPanel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.cJiaPagingPanel2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.cJiaPagingPanel2.Appearance.Options.UseBackColor = true;
            this.cJiaPagingPanel2.Appearance.Options.UseBorderColor = true;
            this.cJiaPagingPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cJiaPagingPanel2.Location = new System.Drawing.Point(48, 293);
            this.cJiaPagingPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPagingPanel2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaPagingPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPagingPanel2.Name = "cJiaPagingPanel2";
            this.cJiaPagingPanel2.Size = new System.Drawing.Size(560, 35);
            this.cJiaPagingPanel2.TabIndex = 2;
            // 
            // CJiaReportPrintUC
            // 
            this.Controls.Add(this.cJiaPanel1);
            this.Controls.Add(this.cJiaGrid1);
            this.Name = "CJiaReportPrintUC";
            this.Size = new System.Drawing.Size(655, 447);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void cJiaPagingPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
