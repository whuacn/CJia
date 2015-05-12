using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoxitReaderSDKProLib;
using System.IO;

namespace CJia.Health.Tools
{
    public partial class PDFViewer : UserControl
    {
        public PDFViewer()
        {
            InitializeComponent();
            axFoxitReader.ShowTitleBar(false);
            axFoxitReader.ShowStatusBar(false);
            axFoxitReader.ShowBookmark(false);
            axFoxitReader.ShowFormFieldsMessageBar(false);
            axFoxitReader.PreviewKeyDown += axFoxitReader_PreviewKeyDown;
        }

        void axFoxitReader_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            return;
        }

        private string fileName;
        /// <summary>
        /// PDF文件路径
        /// </summary>
        [Category("CJia属性"), Description("PDF文件路径")]
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                axFoxitReader.OpenFile(value, password);
                axFoxitReader.ShowNavigationPanels(false);
            }
        }
        /// <summary>
        /// 打开PDF
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="passWord"></param>
        public void OpenFile(string fileName, string passWord)
        {
            axFoxitReader.OpenFile(fileName, passWord);
            axFoxitReader.ShowNavigationPanels(false);
        }
        private string password = "";
        /// <summary>
        /// PDF密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public enum PDFStyle
        {
            All,
            single
        }
        private PDFStyle style = PDFStyle.All;
        /// <summary>
        /// PDF控件样式
        /// </summary>
        [Category("CJia属性"), Description("PDF控件样式")]
        public PDFStyle StylePDF
        {
            get { return style; }
            set
            {
                style = value;
                if (value == PDFStyle.single)
                {
                    axFoxitReader.ShowToolBar(false);
                }
                else
                {
                    axFoxitReader.ShowAllPopup(true);
                    axFoxitReader.ShowToolbarButton(0, false);
                    axFoxitReader.ShowToolbarButton(1, false);
                    axFoxitReader.ShowToolbarButton(2, false);
                    axFoxitReader.ShowToolbarButton(3, false);
                    axFoxitReader.ShowToolbarButton(4, false);
                    axFoxitReader.ShowToolbarButton(5, false);
                    axFoxitReader.ShowToolbarButton(6, false);
                    axFoxitReader.ShowToolbarButton(7, false);
                    axFoxitReader.ShowToolbarButton(8, false);
                    axFoxitReader.ShowToolbarButton(9, false);
                    axFoxitReader.ShowToolbarButton(10, false);
                    axFoxitReader.ShowToolbarButton(11, false);
                    axFoxitReader.ShowToolbarButton(12, false);
                    axFoxitReader.ShowToolbarButton(27, false);
                    axFoxitReader.ShowToolbarButton(26, false);
                    axFoxitReader.ShowToolbarButton(25, false);
                    axFoxitReader.ShowToolbarButton(29, false);
                    axFoxitReader.ShowToolbarButton(30, false);
                    axFoxitReader.ShowToolbarButton(31, false);
                }
            }
        }
        private int zoomLevel = 3;
        /// <summary>
        /// PDF 打开方式
        /// </summary>
        [Category("CJia属性"), Description("PDF 打开方式")]
        public int ZoomLevel
        {
            get { return zoomLevel; }
            set
            {
                zoomLevel = value;
                axFoxitReader.ZoomLevel = value;
            }
        }
        /// <summary>
        /// 打印PDF文件
        /// </summary>
        /// <param name="fileName"></param>
        public void Print(string fileName, string password)
        {
            try
            {
                string path = Path.GetDirectoryName(fileName);
                string newPrint = path + "\\ForPrint";
                PDFHelp.DecodePDF(fileName, newPrint, password);
                axFoxitReader.OpenFile(newPrint, password);
                PDFPrinter ip = axFoxitReader.Printer;
                //ip.printerName = "Microsoft XPS Document Writer";
                ip.PrinterRangeMode = PrinterRangeMode.PRINT_RANGE_SELECTED;
                //ip.printerRangeFrom = 1;
                //ip.printerRangeTo = 1;
                //ip.PrintWithDialog();
                ip.PrintQuiet();
                axFoxitReader.OpenFile("", "");
                File.Delete(newPrint);
            }
            catch { }
        }
    }
}
