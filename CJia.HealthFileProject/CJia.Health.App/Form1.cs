using FoxitReaderSDKProLib;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = @"F:\赣州数字化病案\九江妇幼保健院数字化病案数据备份\cj\Copy\819310_01_001_00.pdf";
            //axFoxitReader.ShowAllPopup(true);
            //axFoxitReader.OpenFile(fileName, "");
            //axFoxitReader.ZoomLevel = 3;
            //axFoxitReader.ShowTitleBar(false);
            //axFoxitReader.ShowToolbarButton(0, false);
            //axFoxitReader.ShowToolbarButton(1, false);
            //axFoxitReader.ShowToolbarButton(2, false);
            //axFoxitReader.ShowToolbarButton(3, false);
            //axFoxitReader.ShowToolbarButton(4, false);
            //axFoxitReader.ShowToolbarButton(5, false);
            //axFoxitReader.ShowToolbarButton(6, false);
            //axFoxitReader.ShowToolbarButton(7, false);
            //axFoxitReader.ShowToolbarButton(8, false);
            //axFoxitReader.ShowToolbarButton(9, false);
            //axFoxitReader.ShowToolbarButton(10, false);
            //axFoxitReader.ShowToolbarButton(11, false);
            //axFoxitReader.ShowToolbarButton(26, false);
            //axFoxitReader.ShowToolbarButton(25, false);
            //axFoxitReader.ShowToolbarButton(29, false);
            //axFoxitReader.ShowToolbarButton(30, false);
            //axFoxitReader.ShowToolbarButton(31, false);
            //axFoxitReader.ShowStatusBar(false);
            //axFoxitReader.ShowBookmark(false);
            //axFoxitReader.ShowFormFieldsMessageBar(false);
            //axFoxitReader.ShowNavigationPanels(false);

            //axFoxitReader.OpenFile(fileName, "");
            //axFoxitReader.ZoomLevel = 1;
            //axFoxitReader.ShowTitleBar(false);
            //axFoxitReader.ShowToolBar(false);
            //axFoxitReader.ShowStatusBar(false);
            //axFoxitReader.ShowBookmark(false);
            //axFoxitReader.ShowFormFieldsMessageBar(false);
            //axFoxitReader.ShowNavigationPanels(false);
            pdfViewer1.FileName = fileName;
            pdfViewer1.ZoomLevel = 1;
            string str = @"F:\赣州数字化病案\001_01_003_00";
            axFoxitReaderSDK1.OpenFile(str, "123456");
        }


        void axAcroPDF1_Enter(object sender, EventArgs e)
        {
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //axAcroPDF1.setZoom(100);
        }
        public int pentcet = 100;
        private void button2_Click(object sender, EventArgs e)
        {
            int i = pentcet - 20;
            //axAcroPDF1.setZoom(i);
            pentcet = i;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = pentcet + 20;
            //axAcroPDF1.setZoom(i);
            pentcet = i;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //axAcroPDF1.Focus();
            //System.Windows.Forms.SendKeys.Send("^H");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.axAcroPDF1.setView("FitH");//FitH FitV FitB FitBH Fit
            //axFoxitReader.Rotate = 2;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //axFoxitReader.SaveAs("F:\\赣州数字化病案\\3456.pdf");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CJia.Health.Tools.PDFHelp.ConvertJPG2PDF(@"F:\赣州数字化病案\九江妇幼保健院数字化病案数据备份\cj\Copy\819310_01_002_00.jpg", @"F:\赣州数字化病案\九江妇幼保健院数字化病案数据备份\cj\Copy\819310_01_002_00.pdf");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string filename = axFoxitReaderSDK1.FilePath;
            string newFile = Path.GetDirectoryName(filename) + "\\dh";
            Decode(filename, newFile, "123456");
            axFoxitReaderSDK1.OpenFile(newFile, "123456");
            PDFPrinter ip = axFoxitReaderSDK1.Printer;
            ip.printerName = "Microsoft XPS Document Writer";
            ip.PrinterRangeMode = PrinterRangeMode.PRINT_RANGE_SELECTED;
            //ip.printerRangeFrom = 1;
            //ip.printerRangeTo = 1;
            //ip.PrintWithDialog();
            ip.PrintQuiet();
        }
        public static void Decode(string pdfSrc, string pdfDest, string ownerPassword)
        {
            PdfReader reader = new PdfReader(pdfSrc, Encoding.Default.GetBytes(ownerPassword));
            Stream os = (Stream)(new FileStream(pdfDest, FileMode.Create));
            PdfEncryptor.Encrypt(reader, os, null, null,
                PdfWriter.AllowAssembly | PdfWriter.AllowFillIn | PdfWriter.AllowScreenReaders | PdfWriter.AllowPrinting, false);
        }
    }
}
