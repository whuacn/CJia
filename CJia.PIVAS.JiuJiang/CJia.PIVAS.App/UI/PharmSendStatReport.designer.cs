namespace CJia.PIVAS.App.UI
{
    partial class PharmSendStatReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); 
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblPharmName = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSpec = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblFactoryName = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblAmountUnit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblFormName = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblPharmAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStartDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEndDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblstart = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lblPrintDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMoney = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblIllFieldName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBacthName = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25.95833F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable1.BorderWidth = 0;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(740F, 25.95833F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseBorderWidth = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblPharmName,
            this.lblSpec,
            this.lblFactoryName,
            this.lblAmountUnit,
            this.lblFormName,
            this.lblPharmAmount,
            this.lblPrice});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblPharmName
            // 
            this.lblPharmName.Name = "lblPharmName";
            this.lblPharmName.Text = "药品名称";
            this.lblPharmName.Weight = 0.67707057226271861D;
            // 
            // lblSpec
            // 
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Text = "规格";
            this.lblSpec.Weight = 0.27653134815276614D;
            // 
            // lblFactoryName
            // 
            this.lblFactoryName.Name = "lblFactoryName";
            this.lblFactoryName.Text = "厂商";
            this.lblFactoryName.Weight = 0.83459703505985328D;
            // 
            // lblAmountUnit
            // 
            this.lblAmountUnit.Name = "lblAmountUnit";
            this.lblAmountUnit.Text = "单位";
            this.lblAmountUnit.Weight = 0.17161208864242311D;
            // 
            // lblFormName
            // 
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Text = "剂型";
            this.lblFormName.Weight = 0.569950709267268D;
            // 
            // lblPharmAmount
            // 
            this.lblPharmAmount.Name = "lblPharmAmount";
            this.lblPharmAmount.Text = "数量";
            this.lblPharmAmount.Weight = 0.15929717109316868D;
            // 
            // lblPrice
            // 
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "单价";
            this.lblPrice.Weight = 0.24744901202973871D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 48F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 55F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.ReportHeader.HeightF = 95.82208F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.lblStartDate,
            this.lblEndDate,
            this.lblstart,
            this.xrLabel1});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(739.9999F, 95.82208F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(567.2851F, 72.82207F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(27.2641F, 23.00001F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "~";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblStartDate.LocationFloat = new DevExpress.Utils.PointFloat(439.3954F, 72.8221F);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStartDate.SizeF = new System.Drawing.SizeF(127.8898F, 23F);
            this.lblStartDate.StylePriority.UseFont = false;
            this.lblStartDate.StylePriority.UseTextAlignment = false;
            this.lblStartDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblEndDate.LocationFloat = new DevExpress.Utils.PointFloat(594.5492F, 72.8221F);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEndDate.SizeF = new System.Drawing.SizeF(135.4507F, 23F);
            this.lblEndDate.StylePriority.UseFont = false;
            this.lblEndDate.StylePriority.UseTextAlignment = false;
            this.lblEndDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblstart
            // 
            this.lblstart.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblstart.LocationFloat = new DevExpress.Utils.PointFloat(339.0931F, 72.8221F);
            this.lblstart.Name = "lblstart";
            this.lblstart.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblstart.SizeF = new System.Drawing.SizeF(100.3022F, 23F);
            this.lblstart.StylePriority.UseFont = false;
            this.lblstart.StylePriority.UseTextAlignment = false;
            this.lblstart.Text = "执行日期：";
            this.lblstart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(740.0001F, 45.91666F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "药品发药单（汇总）";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageHeader.HeightF = 33.00001F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(649.9999F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblPrintDate,
            this.xrLabel6,
            this.lblMoney,
            this.xrLabel4,
            this.xrLine1});
            this.ReportFooter.HeightF = 66.66666F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lblPrintDate
            // 
            this.lblPrintDate.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblPrintDate.LocationFloat = new DevExpress.Utils.PointFloat(604.5493F, 36.54168F);
            this.lblPrintDate.Name = "lblPrintDate";
            this.lblPrintDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintDate.SizeF = new System.Drawing.SizeF(145.4509F, 23.00002F);
            this.lblPrintDate.StylePriority.UseFont = false;
            this.lblPrintDate.StylePriority.UseTextAlignment = false;
            this.lblPrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(507.3721F, 36.54168F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(97.17715F, 23.00001F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "打印时间：";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblMoney
            // 
            this.lblMoney.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblMoney.LocationFloat = new DevExpress.Utils.PointFloat(585.1144F, 13.54167F);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblMoney.SizeF = new System.Drawing.SizeF(164.8855F, 23.00001F);
            this.lblMoney.StylePriority.UseFont = false;
            this.lblMoney.StylePriority.UseTextAlignment = false;
            this.lblMoney.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(449.3954F, 13.54167F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(135.7189F, 23.00001F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "发药总金额：";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine1
            // 
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(9.999879F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(740F, 13.54167F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.lblIllFieldName,
            this.lblBacthName});
            this.GroupHeader1.HeightF = 71.9583F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable2.BorderWidth = 1;
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10.00023F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(740F, 25.95833F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell8,
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "药品名称";
            this.xrTableCell1.Weight = 0.67707057226271861D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "规格";
            this.xrTableCell6.Weight = 0.27653134815276614D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "厂商";
            this.xrTableCell5.Weight = 0.84451676171923451D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "单位";
            this.xrTableCell7.Weight = 0.17161190699017231D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "剂型";
            this.xrTableCell2.Weight = 0.56995084550645625D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "数量";
            this.xrTableCell8.Weight = 0.15929691375248012D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "单价";
            this.xrTableCell4.Weight = 0.23752958812410877D;
            // 
            // lblIllFieldName
            // 
            this.lblIllFieldName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblIllFieldName.LocationFloat = new DevExpress.Utils.PointFloat(20.00023F, 25.95831F);
            this.lblIllFieldName.Name = "lblIllFieldName";
            this.lblIllFieldName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblIllFieldName.SizeF = new System.Drawing.SizeF(135.4167F, 23F);
            this.lblIllFieldName.StylePriority.UseFont = false;
            this.lblIllFieldName.StylePriority.UseTextAlignment = false;
            this.lblIllFieldName.Text = "lblIllFieldName";
            this.lblIllFieldName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblBacthName
            // 
            this.lblBacthName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBacthName.LocationFloat = new DevExpress.Utils.PointFloat(34.16341F, 48.9583F);
            this.lblBacthName.Name = "lblBacthName";
            this.lblBacthName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBacthName.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lblBacthName.StylePriority.UseFont = false;
            this.lblBacthName.StylePriority.UseTextAlignment = false;
            this.lblBacthName.Text = "lblBacthName";
            this.lblBacthName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PharmSendStatReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(49, 40, 48, 55);
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail; 
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel lblEndDate;
        private DevExpress.XtraReports.UI.XRLabel lblstart;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell lblPharmName;
        private DevExpress.XtraReports.UI.XRTableCell lblSpec;
        private DevExpress.XtraReports.UI.XRTableCell lblFactoryName;
        private DevExpress.XtraReports.UI.XRTableCell lblAmountUnit;
        private DevExpress.XtraReports.UI.XRTableCell lblFormName;
        private DevExpress.XtraReports.UI.XRTableCell lblPharmAmount;
        private DevExpress.XtraReports.UI.XRTableCell lblPrice;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblStartDate;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lblPrintDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel lblMoney;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel lblBacthName;
        private DevExpress.XtraReports.UI.XRLabel lblIllFieldName;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;

    }
}
