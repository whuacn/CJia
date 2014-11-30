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
        private XRLabel LableHealthFileID;
        private XRLabel LableName;
        private XRLabel LableODate;
        private XRLabel LableBlackTag;
        private TopMarginBand topMarginBand1;
        public string strBlackTag;

        public PrintHealthFile()
        {
            this.InitializeComponent();
        }

        public void DataBind(string FMRDID, string FNAME, string FDESC, string FICD_D, string FODATE)
        {

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
            this.topMarginBand1 = new TopMarginBand();
            this.detailBand1 = new DetailBand();
            this.LableODate = new XRLabel();
            this.LableBlackTag = new XRLabel();
            this.LableFicd = new XRLabel();
            this.LableDept = new XRLabel();
            this.LableName = new XRLabel();
            this.LableHealthFileID = new XRLabel();

            this.LableBlackTag.BackColor = System.Drawing.Color.Black;
            this.LableBlackTag.Size = new System.Drawing.Size(100, 78);
            this.LableBlackTag.Font = new Font("黑体", 60f, FontStyle.Bold);

            this.bottomMarginBand1 = new BottomMarginBand();
            this.BeginInit();
            this.topMarginBand1.HeightF = 0f;
            this.topMarginBand1.Name = "topMarginBand1";
            this.detailBand1.Controls.AddRange(new XRControl[] { this.LableODate, this.LableFicd, this.LableDept, this.LableName, this.LableHealthFileID, this.LableBlackTag });
            this.detailBand1.HeightF = 782.2917f;
            this.detailBand1.Name = "detailBand1";
            this.LableODate.BorderWidth = 0;
            this.LableODate.Font = new Font("黑体", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.LableODate.LocationFloat = new PointFloat(281.25f, 677.0833f);
            this.LableODate.Multiline = true;
            this.LableODate.Name = "LableODate";
            this.LableODate.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
            this.LableODate.SizeF = new SizeF(384.25f, 56.04166f);
            this.LableODate.StylePriority.UseFont = false;
            this.LableODate.StylePriority.UseTextAlignment = false;
            this.LableODate.TextAlignment = TextAlignment.MiddleLeft;
            this.LableFicd.BorderWidth = 0;
            this.LableFicd.Font = new Font("黑体", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.LableFicd.LocationFloat = new PointFloat(281.25f, 544.7917f);
            this.LableFicd.Multiline = true;
            this.LableFicd.Name = "LableFicd";
            this.LableFicd.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
            this.LableFicd.SizeF = new SizeF(384.25f, 56.04166f);
            this.LableFicd.StylePriority.UseFont = false;
            this.LableFicd.StylePriority.UseTextAlignment = false;
            this.LableFicd.TextAlignment = TextAlignment.MiddleLeft;
            this.LableDept.BorderWidth = 0;
            this.LableDept.Font = new Font("黑体", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.LableDept.LocationFloat = new PointFloat(281.25f, 402.0834f);
            this.LableDept.Multiline = true;
            this.LableDept.Name = "LableDept";
            this.LableDept.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
            this.LableDept.SizeF = new SizeF(384.25f, 56.04166f);
            this.LableDept.StylePriority.UseFont = false;
            this.LableDept.StylePriority.UseTextAlignment = false;
            this.LableDept.TextAlignment = TextAlignment.MiddleLeft;
            this.LableName.BorderWidth = 0;
            this.LableName.Font = new Font("黑体", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.LableName.LocationFloat = new PointFloat(281.2499f, 265.625f);
            this.LableName.Multiline = true;
            this.LableName.Name = "LableName";
            this.LableName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
            this.LableName.SizeF = new SizeF(384.25f, 56.04166f);
            this.LableName.StylePriority.UseFont = false;
            this.LableName.StylePriority.UseTextAlignment = false;
            this.LableName.TextAlignment = TextAlignment.MiddleLeft;
            this.LableHealthFileID.BorderWidth = 0;
            this.LableHealthFileID.Font = new Font("黑体", 72f, FontStyle.Bold);
            this.LableHealthFileID.LocationFloat = new PointFloat(281.25f, 66.25001f);
            this.LableHealthFileID.Multiline = true;
            this.LableHealthFileID.Name = "LableHealthFileID";
            this.LableHealthFileID.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
            this.LableHealthFileID.SizeF = new SizeF(458.2083f, 116.4583f);
            this.LableHealthFileID.StylePriority.UseFont = false;
            this.LableHealthFileID.StylePriority.UseTextAlignment = false;
            this.LableHealthFileID.Text = "1212DFE";
            this.LableHealthFileID.TextAlignment = TextAlignment.MiddleLeft;
            this.bottomMarginBand1.HeightF = 4.166667f;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            base.Bands.AddRange(new Band[] { this.topMarginBand1, this.detailBand1, this.bottomMarginBand1 });
            base.Landscape = true;
            base.Margins = new Margins(0, 0, 0, 4);
            base.PageHeight = 0x33b;
            base.PageWidth = 0x491;
            base.PaperKind = PaperKind.A4;
            base.Version = "12.1";
            this.EndInit();
        }
    }
}

