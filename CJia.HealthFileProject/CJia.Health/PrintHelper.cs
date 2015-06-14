using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health
{
    public class PrintHelper
    {
        private int printW = -1;
        private int printH = -1;
        PaperSize customPs = null;

        public PrintHelper()
        {
            //A4 21cm*29.7cm
            //1cm = 0.39370078740157英寸
            //printW = (int)(21 * 0.394 * 100);//计算其宽度打印点数，打印机默认的单位是Display，及1/100英寸，即1英寸打印机打印100个点，这个依打印机可能不同
            //printH = (int)(28 * 0.394 * 100);
            //customPs = new PaperSize("Custom", printW, printH);
            printW = (int)(4.8 * 0.394 * 100);//189
            printH = (int)(3.2 * 0.394 * 100);//126
            customPs = new PaperSize("Custom", printW, printH);
        }
        /// <summary>
        /// 打印病案号标签条码
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="havPreview"></param>
        /// <param name="recordNO"></param>
        /// <param name="patientName"></param>
        /// <param name="inHosTimes"></param>
        public void PrintRecord(string printer, bool havPreview, string recordNO, string patientName, string inHosTimes)
        {
            if (printer.Length == 0)
            {
                return;
            }
            try
            {
                PrintDocument pdoc = new PrintDocument();
                PrinterSettings printerSetting = pdoc.PrinterSettings;
                printerSetting.PrinterName = printer;
                pdoc.DefaultPageSettings.PaperSize = customPs;
                PageSettings pageSetting = pdoc.DefaultPageSettings;
                //纵向打印
                pageSetting.Landscape = false;
                RectangleF area = pageSetting.PrintableArea;
                pageSetting.Margins.Top = 0;
                pageSetting.Margins.Right = 0;
                pageSetting.Margins.Bottom = 0;
                pageSetting.Margins.Left = 0;
                ////隐藏对话框
                PrintController printController = new StandardPrintController();
                pdoc.PrintController = printController;
                ////这边做个处理，可能因为事件和变量销毁不同步，可能造成打印事件取的变量值为空
                ////打印机分辨率一般都是600*600,一英寸分布的点
                pdoc.EndPrint += (s, e) =>
                {

                };
                pdoc.PrintPage += (object sender, System.Drawing.Printing.PrintPageEventArgs e) =>
                    {
                        try
                        {
                            Point startPoint = new Point((int)area.X + 5, (int)area.Y + 5);
                            Point endPoint = new Point((int)(area.Width) - 5, (int)(area.Height) - 5);

                            using (DrawHelper drawTool = new DrawHelper(e.Graphics))
                            {
                                drawTool.DrawPrintContent(recordNO, patientName, inHosTimes, startPoint, endPoint);
                            }
                        }
                        catch
                        {

                        }
                    };
                if (havPreview)
                {
                    PrintPreviewDialog preview = new PrintPreviewDialog();
                    preview.StartPosition = FormStartPosition.CenterScreen;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.Document = pdoc;
                    preview.PrintPreviewControl.AutoZoom = false;
                    preview.PrintPreviewControl.Zoom = 1;
                    preview.ShowDialog();
                }
                else
                {
                    pdoc.Print();
                }
            }
            catch
            {

            }
        }
        public void PrintPack(string printer, bool havPreview, string packName, string packCode)
        {
            if (printer.Length == 0)
            {
                return;
            }
            try
            {
                PrintDocument pdoc = new PrintDocument();
                PrinterSettings printerSetting = pdoc.PrinterSettings;
                printerSetting.PrinterName = printer;
                pdoc.DefaultPageSettings.PaperSize = customPs;
                PageSettings pageSetting = pdoc.DefaultPageSettings;
                //纵向打印
                pageSetting.Landscape = false;
                RectangleF area = pageSetting.PrintableArea;
                pageSetting.Margins.Top = 0;
                pageSetting.Margins.Right = 0;
                pageSetting.Margins.Bottom = 0;
                pageSetting.Margins.Left = 0;
                ////隐藏对话框
                PrintController printController = new StandardPrintController();
                pdoc.PrintController = printController;
                ////这边做个处理，可能因为事件和变量销毁不同步，可能造成打印事件取的变量值为空
                ////打印机分辨率一般都是600*600,一英寸分布的点
                pdoc.EndPrint += (s, e) =>
                {

                };
                pdoc.PrintPage += (object sender, System.Drawing.Printing.PrintPageEventArgs e) =>
                {
                    try
                    {
                        Point startPoint = new Point((int)area.X + 5, (int)area.Y + 5);
                        Point endPoint = new Point((int)(area.Width) - 5, (int)(area.Height) - 5);

                        using (DrawHelper drawTool = new DrawHelper(e.Graphics))
                        {
                            drawTool.DrawPackPrintContent(packName, packCode, startPoint, endPoint);
                        }
                    }
                    catch
                    {

                    }
                };
                if (havPreview)
                {
                    PrintPreviewDialog preview = new PrintPreviewDialog();
                    preview.StartPosition = FormStartPosition.CenterScreen;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.Document = pdoc;
                    preview.PrintPreviewControl.AutoZoom = false;
                    preview.PrintPreviewControl.Zoom = 1;
                    preview.ShowDialog();
                }
                else
                {
                    pdoc.Print();
                }
            }
            catch
            {

            }
        }
    }
}
