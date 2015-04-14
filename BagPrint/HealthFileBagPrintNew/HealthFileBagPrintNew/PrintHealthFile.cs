namespace HealthFileBagPrintNew
{
    using DevExpress.Utils;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraReports.UI;
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Drawing.Printing;

    public class PrintHealthFile : XtraReport
    {
        private BottomMarginBand bottomMarginBand1;
        private IContainer components = null;
        private DetailBand detailBand1;
        private XRLabel LableDept;
        private XRLabel LableFicd;
        private XRLabel LableHealthIllcaseNo;
        private XRLabel LableName;
        private XRLabel LableODate;
        private XRLabel LableBlackTag;
        private TopMarginBand topMarginBand1;
        private XRLabel LableHealthFileID;
        public string strBlackTag;

        public PrintHealthFile()
        {
            this.InitializeComponent();
        }

        public void DataBind(string FBIHID,string FMRDID, string FNAME, string FDESC, string FICD_D, string FODATE)
        {
            this.LableHealthIllcaseNo.Text = FBIHID;
            this.LableHealthFileID.Text = FMRDID;
            this.LableName.Text = FNAME;
            this.LableDept.Text = FDESC;
            this.LableFicd.Text = FICD_D;
            this.LableODate.Text = FODATE;
            //strBlackTag = FMRDID.Substring(FMRDID.Length - 6, 1);

            int Y = int.Parse(strBlackTag);
            if (2 * Y <= 8)
            {
                Y = 2 * Y;
            }
            else if (2 * Y <= 18)
            {
                Y = 2 * Y - 9;
            }

            this.LableBlackTag.LocationFloat = new PointFloat(0f, Y * 78.2f);
            this.LableBlackTag.Text = strBlackTag;
            this.LableBlackTag.ForeColor = System.Drawing.Color.White;

            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            this.PrinterName = ConfigurationSettings.AppSettings["bagPrint"];
            base.CreateDocument();
            
            this.Print();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.LableHealthFileID = new DevExpress.XtraReports.UI.XRLabel();
            this.LableODate = new DevExpress.XtraReports.UI.XRLabel();
            this.LableFicd = new DevExpress.XtraReports.UI.XRLabel();
            this.LableDept = new DevExpress.XtraReports.UI.XRLabel();
            this.LableName = new DevExpress.XtraReports.UI.XRLabel();
            this.LableHealthIllcaseNo = new DevExpress.XtraReports.UI.XRLabel();
            this.LableBlackTag = new DevExpress.XtraReports.UI.XRLabel();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LableHealthFileID,
            this.LableODate,
            this.LableFicd,
            this.LableDept,
            this.LableName,
            this.LableHealthIllcaseNo,
            this.LableBlackTag});
            this.detailBand1.HeightF = 782.2917F;
            this.detailBand1.Name = "detailBand1";
            // 
            // LableHealthFileID
            // 
            this.LableHealthFileID.BorderWidth = 0;
            this.LableHealthFileID.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableHealthFileID.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 556.25F);
            this.LableHealthFileID.Multiline = true;
            this.LableHealthFileID.Name = "LableHealthFileID";
            this.LableHealthFileID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableHealthFileID.SizeF = new System.Drawing.SizeF(442.5833F, 71.66663F);
            this.LableHealthFileID.StylePriority.UseFont = false;
            this.LableHealthFileID.StylePriority.UseTextAlignment = false;
            this.LableHealthFileID.Text = "1212DFE";
            // 
            // LableODate
            // 
            this.LableODate.BorderWidth = 0;
            this.LableODate.Font = new System.Drawing.Font("黑体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableODate.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 677.0833F);
            this.LableODate.Multiline = true;
            this.LableODate.Name = "LableODate";
            this.LableODate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableODate.SizeF = new System.Drawing.SizeF(384.25F, 56.04166F);
            this.LableODate.StylePriority.UseFont = false;
            this.LableODate.StylePriority.UseTextAlignment = false;
            // 
            // LableFicd
            // 
            this.LableFicd.BorderWidth = 0;
            this.LableFicd.Font = new System.Drawing.Font("黑体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableFicd.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 441.6667F);
            this.LableFicd.Multiline = true;
            this.LableFicd.Name = "LableFicd";
            this.LableFicd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableFicd.SizeF = new System.Drawing.SizeF(384.25F, 56.04166F);
            this.LableFicd.StylePriority.UseFont = false;
            this.LableFicd.StylePriority.UseTextAlignment = false;
            // 
            // LableDept
            // 
            this.LableDept.BorderWidth = 0;
            this.LableDept.Font = new System.Drawing.Font("黑体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableDept.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 342.7084F);
            this.LableDept.Multiline = true;
            this.LableDept.Name = "LableDept";
            this.LableDept.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableDept.SizeF = new System.Drawing.SizeF(384.25F, 56.04166F);
            this.LableDept.StylePriority.UseFont = false;
            this.LableDept.StylePriority.UseTextAlignment = false;
            // 
            // LableName
            // 
            this.LableName.BorderWidth = 0;
            this.LableName.Font = new System.Drawing.Font("黑体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableName.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 242.7083F);
            this.LableName.Multiline = true;
            this.LableName.Name = "LableName";
            this.LableName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableName.SizeF = new System.Drawing.SizeF(384.25F, 56.04166F);
            this.LableName.StylePriority.UseFont = false;
            this.LableName.StylePriority.UseTextAlignment = false;
            // 
            // LableHealthIllcaseNo
            // 
            this.LableHealthIllcaseNo.BorderWidth = 0;
            this.LableHealthIllcaseNo.Font = new System.Drawing.Font("黑体", 72F, System.Drawing.FontStyle.Bold);
            this.LableHealthIllcaseNo.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 66.25001F);
            this.LableHealthIllcaseNo.Multiline = true;
            this.LableHealthIllcaseNo.Name = "LableHealthIllcaseNo";
            this.LableHealthIllcaseNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LableHealthIllcaseNo.SizeF = new System.Drawing.SizeF(458.2083F, 116.4583F);
            this.LableHealthIllcaseNo.StylePriority.UseFont = false;
            this.LableHealthIllcaseNo.StylePriority.UseTextAlignment = false;
            this.LableHealthIllcaseNo.Text = "1212DFE";
            // 
            // LableBlackTag
            // 
            this.LableBlackTag.BackColor = System.Drawing.Color.Black;
            this.LableBlackTag.Font = new System.Drawing.Font("黑体", 60F, System.Drawing.FontStyle.Bold);
            this.LableBlackTag.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.LableBlackTag.Name = "LableBlackTag";
            this.LableBlackTag.SizeF = new System.Drawing.SizeF(100F, 78F);
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 4.166667F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // PrintHealthFile
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 4);
            this.PageHeight = 1004;
            this.PageWidth = 1339;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}

