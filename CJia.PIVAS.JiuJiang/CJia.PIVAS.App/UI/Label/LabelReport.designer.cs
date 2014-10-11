namespace CJia.PIVAS.App.UI.Label
{
    partial class LabelReport
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
            if(disposing && (components != null))
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
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.pharmName = new DevExpress.XtraReports.UI.XRTableCell();
            this.spec = new DevExpress.XtraReports.UI.XRTableCell();
            this.dosage = new DevExpress.XtraReports.UI.XRTableCell();
            this.from = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.age = new DevExpress.XtraReports.UI.XRLabel();
            this.nowTime = new DevExpress.XtraReports.UI.XRLabel();
            this.usege = new DevExpress.XtraReports.UI.XRLabel();
            this.doctor = new DevExpress.XtraReports.UI.XRLabel();
            this.batch = new DevExpress.XtraReports.UI.XRLabel();
            this.patientID = new DevExpress.XtraReports.UI.XRLabel();
            this.illfield = new DevExpress.XtraReports.UI.XRLabel();
            this.bed = new DevExpress.XtraReports.UI.XRLabel();
            this.patientName = new DevExpress.XtraReports.UI.XRLabel();
            this.adviceID = new DevExpress.XtraReports.UI.XRLabel();
            this.pageCount = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.pharmType = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labPrintDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.barcode = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable4
            // 
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(1.647409F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(348.35F, 20F);
            this.xrTable4.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.pharmName,
            this.spec,
            this.dosage,
            this.from});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // pharmName
            // 
            this.pharmName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.pharmName.Name = "pharmName";
            this.pharmName.StylePriority.UseBorders = false;
            this.pharmName.StylePriority.UseTextAlignment = false;
            this.pharmName.Text = "药品名称";
            this.pharmName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pharmName.Weight = 1.195628479660199D;
            // 
            // spec
            // 
            this.spec.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.spec.Name = "spec";
            this.spec.StylePriority.UseBorders = false;
            this.spec.StylePriority.UseTextAlignment = false;
            this.spec.Text = "规格";
            this.spec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.spec.Weight = 0.5801336963389867D;
            // 
            // dosage
            // 
            this.dosage.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dosage.Name = "dosage";
            this.dosage.StylePriority.UseBorders = false;
            this.dosage.StylePriority.UseTextAlignment = false;
            this.dosage.Text = "用量";
            this.dosage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.dosage.Weight = 0.51948874263759426D;
            // 
            // from
            // 
            this.from.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.from.Multiline = true;
            this.from.Name = "from";
            this.from.StylePriority.UseBorders = false;
            this.from.StylePriority.UseTextAlignment = false;
            this.from.Text = "厂家\r\n";
            this.from.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.from.Weight = 0.70474908136322012D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(89.7246F, 10.00001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(34.26907F, 20F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "年龄:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // age
            // 
            this.age.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.age.LocationFloat = new DevExpress.Utils.PointFloat(123.9936F, 10.00001F);
            this.age.Name = "age";
            this.age.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.age.SizeF = new System.Drawing.SizeF(55.45551F, 20F);
            this.age.StylePriority.UseFont = false;
            this.age.StylePriority.UsePadding = false;
            this.age.StylePriority.UseTextAlignment = false;
            this.age.Text = "12月12天";
            this.age.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // nowTime
            // 
            this.nowTime.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.nowTime.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 19.00009F);
            this.nowTime.Name = "nowTime";
            this.nowTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nowTime.SizeF = new System.Drawing.SizeF(114.9771F, 23F);
            this.nowTime.StylePriority.UseFont = false;
            this.nowTime.StylePriority.UseTextAlignment = false;
            this.nowTime.Text = "2012/12/26 13:23:56";
            this.nowTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // usege
            // 
            this.usege.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.usege.LocationFloat = new DevExpress.Utils.PointFloat(290.6909F, 50F);
            this.usege.Name = "usege";
            this.usege.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.usege.SizeF = new System.Drawing.SizeF(58.48285F, 20F);
            this.usege.StylePriority.UseFont = false;
            this.usege.StylePriority.UsePadding = false;
            this.usege.StylePriority.UseTextAlignment = false;
            this.usege.Text = "静脉注射";
            this.usege.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // doctor
            // 
            this.doctor.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.doctor.LocationFloat = new DevExpress.Utils.PointFloat(256.2178F, 29.99999F);
            this.doctor.Name = "doctor";
            this.doctor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.doctor.SizeF = new System.Drawing.SizeF(50.10684F, 20F);
            this.doctor.StylePriority.UseFont = false;
            this.doctor.StylePriority.UsePadding = false;
            this.doctor.StylePriority.UseTextAlignment = false;
            this.doctor.Text = "是法师打";
            this.doctor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // batch
            // 
            this.batch.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.batch.LocationFloat = new DevExpress.Utils.PointFloat(182.328F, 50.00003F);
            this.batch.Name = "batch";
            this.batch.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.batch.SizeF = new System.Drawing.SizeF(48.26416F, 20F);
            this.batch.StylePriority.UseFont = false;
            this.batch.StylePriority.UsePadding = false;
            this.batch.StylePriority.UseTextAlignment = false;
            this.batch.Text = "第一批";
            this.batch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // patientID
            // 
            this.patientID.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.patientID.LocationFloat = new DevExpress.Utils.PointFloat(225.3707F, 10.00001F);
            this.patientID.Name = "patientID";
            this.patientID.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.patientID.SizeF = new System.Drawing.SizeF(79.54451F, 20F);
            this.patientID.StylePriority.UseFont = false;
            this.patientID.StylePriority.UsePadding = false;
            this.patientID.StylePriority.UseTextAlignment = false;
            this.patientID.Text = "000122276601";
            this.patientID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // illfield
            // 
            this.illfield.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.illfield.LocationFloat = new DevExpress.Utils.PointFloat(37.09669F, 29.99999F);
            this.illfield.Name = "illfield";
            this.illfield.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.illfield.SizeF = new System.Drawing.SizeF(101.7357F, 20.00001F);
            this.illfield.StylePriority.UseFont = false;
            this.illfield.StylePriority.UsePadding = false;
            this.illfield.StylePriority.UseTextAlignment = false;
            this.illfield.Text = "妇一科护理单元";
            this.illfield.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // bed
            // 
            this.bed.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.bed.LocationFloat = new DevExpress.Utils.PointFloat(173.1015F, 29.99999F);
            this.bed.Name = "bed";
            this.bed.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.bed.SizeF = new System.Drawing.SizeF(48.26418F, 20F);
            this.bed.StylePriority.UseFont = false;
            this.bed.StylePriority.UsePadding = false;
            this.bed.StylePriority.UseTextAlignment = false;
            this.bed.Text = "999床";
            this.bed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // patientName
            // 
            this.patientName.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.patientName.LocationFloat = new DevExpress.Utils.PointFloat(34.26908F, 10.00001F);
            this.patientName.Name = "patientName";
            this.patientName.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.patientName.SizeF = new System.Drawing.SizeF(55.45551F, 20F);
            this.patientName.StylePriority.UseFont = false;
            this.patientName.StylePriority.UsePadding = false;
            this.patientName.StylePriority.UseTextAlignment = false;
            this.patientName.Text = "你斯蒂芬";
            this.patientName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // adviceID
            // 
            this.adviceID.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.adviceID.LocationFloat = new DevExpress.Utils.PointFloat(46.98098F, 50F);
            this.adviceID.Name = "adviceID";
            this.adviceID.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.adviceID.SizeF = new System.Drawing.SizeF(100.3114F, 20.00001F);
            this.adviceID.StylePriority.UseFont = false;
            this.adviceID.StylePriority.UsePadding = false;
            this.adviceID.StylePriority.UseTextAlignment = false;
            this.adviceID.Text = "0001222766010068";
            this.adviceID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // pageCount
            // 
            this.pageCount.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.pageCount.ForeColor = System.Drawing.Color.Black;
            this.pageCount.LocationFloat = new DevExpress.Utils.PointFloat(47.22506F, 39.99999F);
            this.pageCount.Name = "pageCount";
            this.pageCount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageCount.SizeF = new System.Drawing.SizeF(76.7686F, 24.05931F);
            this.pageCount.StylePriority.UseFont = false;
            this.pageCount.StylePriority.UseForeColor = false;
            this.pageCount.StylePriority.UseTextAlignment = false;
            this.pageCount.Text = "1/2";
            this.pageCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(40.62501F, 24.05931F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "复核:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(61.36649F, 22.99999F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(43.33693F, 19.00008F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "调配:";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99995F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(40.625F, 19F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "核对:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(222.7749F, 29.99999F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(33.44281F, 20F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "医生:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.8236885F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(60.54281F, 22.99998F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "排药时间:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // pharmType
            // 
            this.pharmType.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.pharmType.ForeColor = System.Drawing.Color.Black;
            this.pharmType.LocationFloat = new DevExpress.Utils.PointFloat(306.3245F, 0F);
            this.pharmType.Name = "pharmType";
            this.pharmType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pharmType.SizeF = new System.Drawing.SizeF(42.84906F, 60.00002F);
            this.pharmType.StylePriority.UseFont = false;
            this.pharmType.StylePriority.UseForeColor = false;
            this.pharmType.StylePriority.UseTextAlignment = false;
            this.pharmType.Text = "普";
            this.pharmType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(46.98097F, 20F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "医嘱号:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(148.0589F, 50.00003F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(34.26911F, 20F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "批次:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(179.4491F, 10.00001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(45.92163F, 20F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "病人ID:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 29.99999F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(35.85728F, 20F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "病区:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(138.8324F, 29.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(34.26909F, 20F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "床号:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labPrintDate
            // 
            this.labPrintDate.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.labPrintDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.labPrintDate.Name = "labPrintDate";
            this.labPrintDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.labPrintDate.SizeF = new System.Drawing.SizeF(34.26907F, 20F);
            this.labPrintDate.StylePriority.UseFont = false;
            this.labPrintDate.StylePriority.UsePadding = false;
            this.labPrintDate.StylePriority.UseTextAlignment = false;
            this.labPrintDate.Text = "姓名:";
            this.labPrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(230.5922F, 50.00003F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(60.0986F, 20F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "使用方法:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.barcode,
            this.xrLabel10,
            this.pageCount,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.nowTime,
            this.xrLabel8});
            this.ReportFooter.HeightF = 65.625F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // barcode
            // 
            this.barcode.LocationFloat = new DevExpress.Utils.PointFloat(124.9771F, 2.000014F);
            this.barcode.Name = "barcode";
            this.barcode.SizeF = new System.Drawing.SizeF(223.4256F, 62.05929F);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(348.4027F, 2F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.labPrintDate,
            this.age,
            this.usege,
            this.doctor,
            this.batch,
            this.patientID,
            this.illfield,
            this.bed,
            this.patientName,
            this.adviceID,
            this.xrLabel11,
            this.pharmType,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel1,
            this.xrLabel7,
            this.xrLabel2});
            this.ReportHeader.HeightF = 72.00005F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70.00005F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(348.4027F, 2F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LabelReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.BottomMargin,
            this.TopMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(16, 468, 0, 0);
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel labPrintDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel pageCount;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel pharmType;
        private DevExpress.XtraReports.UI.XRLabel adviceID;
        private DevExpress.XtraReports.UI.XRLabel illfield;
        private DevExpress.XtraReports.UI.XRLabel bed;
        private DevExpress.XtraReports.UI.XRLabel patientName;
        private DevExpress.XtraReports.UI.XRLabel patientID;
        private DevExpress.XtraReports.UI.XRLabel batch;
        private DevExpress.XtraReports.UI.XRLabel usege;
        private DevExpress.XtraReports.UI.XRLabel doctor;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell pharmName;
        private DevExpress.XtraReports.UI.XRTableCell spec;
        private DevExpress.XtraReports.UI.XRTableCell dosage;
        private DevExpress.XtraReports.UI.XRTableCell from;
        private DevExpress.XtraReports.UI.XRLabel nowTime;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel age;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRPictureBox barcode;
    }
}
