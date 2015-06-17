using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.OneD;
using ZXing.QrCode;

namespace CJia.Health
{
    public class DrawHelper : IDisposable
    {
        private EncodingOptions qrOptions = null;
        private Code128EncodingOptions code128Options = null;
        private BarcodeWriter qrCodeWriter = null;
        private BarcodeWriter code128Writer = null;

        #region 打印画图相关
        private Font heitiFt18 = new System.Drawing.Font("宋体", 16);
        private Font heitiFt14 = new System.Drawing.Font("宋体", 14);
        private Font heitiFt12 = new System.Drawing.Font("宋体", 12);
        private Brush br = new SolidBrush(Color.Black);
        private Brush wr = new SolidBrush(Color.White);
        private Font cellTitleFt = new System.Drawing.Font("宋体", 11);
        private Font cellContentFt = new System.Drawing.Font("宋体", 10);
        private Font cellContentFt_1 = new System.Drawing.Font("宋体", 9);
        private Pen blackPen = Pens.Black;
        #endregion

        public static Size GetTextSize(string text, System.Drawing.Font font)
        {
            return TextRenderer.MeasureText(text, font);
        }

        private Graphics workGraphics = null;

        //设定打印边界
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public DrawHelper(Graphics g)
        {
            if (g == null)
            {
                throw new Exception("初始化失败，Graphics不能为空");
            }
            this.workGraphics = g;
            this.RulePen = Pens.DarkMagenta;

            qrOptions = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 70,
                Height = 70,
                Margin = 0
            };
            qrCodeWriter = new BarcodeWriter();
            qrCodeWriter.Format = BarcodeFormat.QR_CODE;
            qrCodeWriter.Options = qrOptions;

            code128Options = new Code128EncodingOptions
            {
                Width = 200,
                Height = 37,
                PureBarcode = false,
                Margin = 0
            };
            code128Writer = new BarcodeWriter();
            code128Writer.Format = BarcodeFormat.CODE_128;
            code128Writer.Options = code128Options;
        }

        ~DrawHelper()
        {
            Dispose();
        }

        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                workGraphics = null;
                disposed = true;
            }
        }
        //正值表示向右，向下偏移(整体偏移)
        public int Delta_X { get; set; }
        public int Delta_Y { get; set; }

        private int GetActDraw_X(int x)
        {
            return x + Delta_X;
        }
        private int GetActDraw_Y(int y)
        {
            return y + Delta_Y;
        }
        public void DrawLine(Pen p, int x1, int y1, int x2, int y2)
        {
            workGraphics
                .DrawLine(
                    p,
                    new Point(GetActDraw_X(x1), GetActDraw_Y(y1)),
                    new Point(GetActDraw_X(x2), GetActDraw_Y(y2))
                );

        }
        public void DrawLine_Horizon(Pen p, int x, int y, int length_H)
        {
            DrawLine(p, x, y, x + length_H, y);
        }
        public void DrawLine_Horizon_Boundary(Pen p, int y)
        {
            DrawLine_Horizon(p, MinX, y, (MaxX - MinX));
        }
        public void DrawLine_Vertical(Pen p, int x, int y, int length_V)
        {
            DrawLine(p, x, y, x, y + length_V);
        }
        public void DrawLine_Vertical_Boundary(Pen p, int x)
        {
            DrawLine_Vertical(p, x, MinY, (MaxY - MinY));
        }
        public void DrawLine_Rectangle(Pen p, int x, int y, int length_H, int length_V)
        {
            DrawLine_Horizon(p, x, y, length_H);
            DrawLine_Horizon(p, x, y + length_V, length_H);
            DrawLine_Vertical(p, x, y, length_V);
            DrawLine_Vertical(p, x + length_H, y, length_V);
        }
        public void DrawLine_Boundary(Pen p)
        {
            DrawLine_Rectangle(p, MinX, MinY, (MaxX - MinX), (MaxY - MinY));
        }
        public void DrawString(Font f, Brush b, string text, int x, int y)
        {
            workGraphics.DrawString(text, f, b, GetActDraw_X(x), GetActDraw_Y(y));
        }
        public void DrawImage(Image img, int x, int y)
        {
            workGraphics.DrawImage(img, new Point(GetActDraw_X(x), GetActDraw_Y(y)));
        }
        public void DrawString(string content, Font font, Brush br, int x, int y)
        {
            workGraphics.DrawString(content, font, br, GetActDraw_X(x), GetActDraw_Y(y));
        }
        public Pen RulePen { get; set; }
        public void DrawRule_Vertical(int x)
        {
            DrawLine(RulePen, x, MinY, x, MaxY);
        }
        public void DrawRule_Horizon(int y)
        {
            DrawLine(RulePen, MinX, y, MaxX, y);
        }
        public void DrawRule_Point(int x, int y)
        {
            DrawRule_Vertical(x);
            DrawRule_Horizon(y);
        }
        public void DrawRule_Rectangle(int x, int y, int length_H, int length_V)
        {
            DrawLine_Horizon(RulePen, x, y, length_H);
            DrawLine_Horizon(RulePen, x, y + length_V, length_H);
            DrawLine_Vertical(RulePen, x, y, length_V);
            DrawLine_Vertical(RulePen, x + length_H, y, length_V);
        }
        public void FillColor(Color color, int x, int y, int lenght_H, int lenght_V)
        {
            Brush br = new SolidBrush(color);
            Rectangle rec = new Rectangle(x, y, lenght_H, lenght_V);
            workGraphics.FillRectangle(br, rec);
        }
        public void FillColor(int x, int y, int lenght_H, int lenght_V)
        {
            FillColor(Color.FromArgb(239, 239, 239), x, y, lenght_H, lenght_V);
        }

        public void DrawPrintContent(string recordNO,string  patientName,string  inHosTime,Point startPoint,Point endPoint)
        {
            //实际情况 要继续调试
            int minX = MinX = startPoint.X;
            int maxX = MaxX = endPoint.X;
            int minY = MinY = startPoint.Y;
            int maxY = MaxY = endPoint.Y;
            Delta_X = 0;
            Delta_Y = 0;
            //DrawLine_Boundary(blackPen);
            string hosName = Tools.ConfigHelper.GetAppStrings("Hospital");
            DrawString(hosName, cellContentFt, br, minX + 2, minY + 5);
            code128Writer.Options.Width = 170;
            code128Writer.Options.Height = 45;
            Bitmap vin8Bmp = code128Writer.Write(recordNO + "_" + inHosTime);
            DrawImage(vin8Bmp, minX + 10, minY + 10 + 20);
            DrawString("姓名：", cellContentFt, br, minX + 2, minY + 65 + 20);
            DrawString(patientName, cellContentFt, br, minX + 45, minY + 65 + 20);
            DrawString("入院次数：", cellContentFt, br, minX + 85, minY + 65 + 20);
            DrawString(inHosTime, cellContentFt, br, minX + 147, minY + 65 + 20);
        }

        public void DrawPackPrintContent(string packName, string packCode, Point startPoint, Point endPoint)
        {
            //实际情况 要继续调试
            int minX = MinX = startPoint.X;
            int maxX = MaxX = endPoint.X;
            int minY = MinY = startPoint.Y;
            int maxY = MaxY = endPoint.Y;
            Delta_X = 0;
            Delta_Y = 0;
            //DrawLine_Boundary(blackPen);
            string hosName = Tools.ConfigHelper.GetAppStrings("Hospital");
            DrawString(hosName, cellContentFt, br, minX + 2, minY + 5);
            code128Writer.Options.Width = 170;
            code128Writer.Options.Height = 45;
            Bitmap vin8Bmp = code128Writer.Write(packCode);
            DrawImage(vin8Bmp, minX + 10, minY + 10 + 20);
            DrawString(packName, cellContentFt, br, minX + 10, minY + 65 + 20);
        }
    }
}
