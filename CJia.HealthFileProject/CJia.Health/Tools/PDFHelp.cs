using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CJia.Health.Tools
{
    public class PDFHelp
    {
        /// <summary>
        /// 将单张jpg图片转成PDF输出
        /// </summary>
        /// <param name="jpgFilePath"></param>
        /// <param name="outPDFPath"></param>
        public static void ConvertJPG2PDF(string jpgFilePath, string outPDFPath)
        {
            try
            {
                var document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                using (var stream = new FileStream(outPDFPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    using (var imageStream = new FileStream(jpgFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = iTextSharp.text.Image.GetInstance(imageStream);
                        if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                        {
                            image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                        }
                        else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                        {
                            image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                        }
                        image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                        document.Add(image);
                    }
                    document.Close();
                }
            }
            catch { }
        }
        /// <summary>
        /// 将多张图片转成一张PDF输出
        /// </summary>
        /// <param name="jpgFilesPath"></param>
        /// <param name="newPDFPath"></param>
        public static void ConvertJPG2PDF(string[] jpgFilesPath, string newPDFPath)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(newPDFPath, FileMode.Create, FileAccess.ReadWrite));

                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < jpgFilesPath.Length; i++)
                {
                    if (String.IsNullOrEmpty(jpgFilesPath[i])) break;

                    image = iTextSharp.text.Image.GetInstance(jpgFilesPath[i]);

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);
                    document.NewPage();
                    document.Add(image);
                }
            }
            catch
            {
            }
            document.Close();
        }
    }
}
