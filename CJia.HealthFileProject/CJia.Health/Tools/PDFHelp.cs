using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using O2S.Components.PDFRender4NET;
using System.Drawing.Imaging;
using System.Drawing;

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
                    //PdfReader reader = new PdfReader(sname);
                    //int n = reader.NumberOfPages;
                    //Document document = new Document(reader.GetPageSizeWithRotation(1));
                    //PdfWriter.GetInstance(document, new FileStream(sname1, FileMode.Create));
                    //writer.SetEncryption(PdfWriter.STRENGTH128BITS, "123456", null, PdfWriter.AllowPrinting);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    //writer.SetEncryption(PdfWriter.STRENGTH128BITS, "123456", null, PdfWriter.AllowPrinting);
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
        /// <summary>
        /// 加密PDF
        /// </summary>
        /// <param name="pdfFile"></param>
        /// <param name="passWord"></param>
        public static void EncryptionPDF(string pdfFile, string passWord)
        {
            try
            {
                string fileName = Path.GetFileName(pdfFile);
                string dir = Path.GetDirectoryName(pdfFile);
                string tmpname = Guid.NewGuid().ToString();
                string pdfDest = Path.GetDirectoryName(pdfFile) + "\\" + tmpname + ".pdf";
                PdfReader reader = new PdfReader(pdfFile);
                Stream os = (Stream)(new FileStream(pdfDest, FileMode.Create));
                PdfEncryptor.Encrypt(reader, os, PdfWriter.STRENGTH128BITS, passWord, passWord, PdfWriter.AllowPrinting);
                reader.Close();
                reader.Dispose();
                File.Delete(pdfFile);
                File.Move(pdfDest, dir + "\\" + fileName);
            }
            catch { }
        }
        /// <summary>
        /// 添加普通偏转角度文字水印
        /// </summary>
        /// <param name="inputfilepath"></param>
        /// <param name="waterMarkName"></param>
        /// <param name="passWord"></param>
        /// <param name="inclination">倾斜度</param>
        public static void SetWatermark(string inputfilepath, string waterMarkName, string passWord, int inclination)
        {
            PdfReader pdfReader = null;
            PdfStamper pdfStamper = null;
            string fileName = Path.GetFileName(inputfilepath);
            string dir = Path.GetDirectoryName(inputfilepath);
            string tmpname = Guid.NewGuid().ToString();
            string pdfDest = Path.GetDirectoryName(inputfilepath) + "\\" + tmpname + ".pdf";
            try
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(passWord);
                pdfReader = new PdfReader(inputfilepath, bytes);
                pdfStamper = new PdfStamper(pdfReader, new FileStream(pdfDest, FileMode.Create));
                pdfStamper.SetEncryption(false, passWord, passWord, 1);
                int total = pdfReader.NumberOfPages + 1;
                iTextSharp.text.Rectangle psize = pdfReader.GetPageSize(1);
                float width = psize.Width;
                float height = psize.Height;
                PdfContentByte content;
                BaseFont font = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                PdfGState gs = new PdfGState();
                for (int i = 1; i < total; i++)
                {
                    content = pdfStamper.GetOverContent(i);//在内容上方加水印
                    //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                    //透明度
                    gs.FillOpacity = 0.3f;
                    content.SetGState(gs);
                    //content.SetGrayFill(0.3f);
                    //开始写入文本
                    content.BeginText();
                    content.SetColorFill(BaseColor.LIGHT_GRAY);
                    content.SetFontAndSize(font, 100);//100
                    content.SetTextMatrix(0, 0);
                    content.ShowTextAligned(Element.ALIGN_CENTER, waterMarkName, width / 2 + 10, height / 2 - 50, 55);//55
                    //content.ShowTextAligned(Element.ALIGN_CENTER, waterMarkName, width / 2 - 50, height / 2 - 50, 55)
                    //content.SetColorFill(BaseColor.BLACK);
                    //content.SetFontAndSize(font, 8);
                    //content.ShowTextAligned(Element.ALIGN_CENTER, waterMarkName, 0, 0, 0);
                    content.EndText();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pdfStamper != null)
                    pdfStamper.Close();
                if (pdfReader != null)
                {
                    pdfReader.Close();
                    pdfReader.Dispose();
                    File.Delete(inputfilepath);
                    File.Move(pdfDest, dir + "\\" + fileName);
                }
            }
        }
        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }
        public static void ConvertPDF2Image(string pdfInputPath, string password, int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
        {
            string fileName = Path.GetFileName(pdfInputPath);
            string dir = Path.GetDirectoryName(pdfInputPath);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(password);
            PDFFile pdfFile = PDFFile.Open(pdfInputPath, bytes);
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 300 * (int)definition);
                pageImage.Save(dir + "\\" + fileName.Replace(".pdf", "") + "." + imageFormat.ToString(), imageFormat);
                pageImage.Dispose();
            }
            pdfFile.Dispose();
        }
    }
}
