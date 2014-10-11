using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GdiPlusLib
{
    public class Gdip
    {
        private static ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        private static bool GetCodecClsid(string filename, out Guid clsid)
        {
            clsid = Guid.Empty;
            string ext = Path.GetExtension(filename);
            if (ext == null)
                return false;
            ext = "*" + ext.ToUpper();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FilenameExtension.IndexOf(ext) >= 0)
                {
                    clsid = codec.Clsid;
                    return true;
                }
            }
            return false;
        }


        public static bool SaveDIBAs(IntPtr bminfo, IntPtr pixdat,string FilePath)
        {
            Guid clsid;
            if (!GetCodecClsid(FilePath, out clsid))
            {
                MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(FilePath),
                                "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            IntPtr img = IntPtr.Zero;
            int st = GdipCreateBitmapFromGdiDib(bminfo, pixdat, ref img);
            if ((st != 0) || (img == IntPtr.Zero))
                return false;

            st = GdipSaveImageToFile(img, FilePath, ref clsid, IntPtr.Zero);
            GdipDisposeImage(img);
            return st == 0;
        }
        public static bool SaveDIBAs(string savePath, string picname, IntPtr bminfo, IntPtr pixdat)
        {
            string strFile = savePath + "\\" + picname + CJia.Health.Tools.ConfigHelper.GetAppStrings("ImgExtension");
            Guid clsid;
            if (!GetCodecClsid(strFile, out clsid))
            {
                MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(strFile),
                                "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            IntPtr img = IntPtr.Zero;
            int st = GdipCreateBitmapFromGdiDib(bminfo, pixdat, ref img);
            if ((st != 0) || (img == IntPtr.Zero))
                return false;
            st = GdipSaveImageToFile(img, strFile, ref clsid, IntPtr.Zero);
            GdipDisposeImage(img);
            return st == 0;

            //SaveFileDialog sd = new SaveFileDialog();
            //sd.InitialDirectory = savePath;
            //sd.FileName = picname;
            //sd.Title = "Save bitmap as...";
            //sd.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*";
            //sd.FilterIndex = 3;
            ////if (sd.ShowDialog() != DialogResult.OK)
            ////    return false;
            //string strFile = sd.InitialDirectory + "\\" + sd.FileName + CJia.Health.Tools.ConfigHelper.GetAppStrings("ImgExtension");
            //sd.FileName = strFile;
            //Guid clsid;
            //if (!GetCodecClsid(sd.FileName, out clsid))
            //{
            //    MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(sd.FileName),
            //                    "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            //IntPtr img = IntPtr.Zero;
            //int st = GdipCreateBitmapFromGdiDib(bminfo, pixdat, ref img);
            //if ((st != 0) || (img == IntPtr.Zero))
            //    return false;

            //st = GdipSaveImageToFile(img, sd.FileName, ref clsid, IntPtr.Zero);
            //sd.Dispose();
            //GdipDisposeImage(img);
            //return st == 0;
        }



        [DllImport("gdiplus.dll", ExactSpelling = true)]
        internal static extern int GdipCreateBitmapFromGdiDib(IntPtr bminfo, IntPtr pixdat, ref IntPtr image);

        [DllImport("gdiplus.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern int GdipSaveImageToFile(IntPtr image, string filename, [In] ref Guid clsid, IntPtr encparams);

        [DllImport("gdiplus.dll", ExactSpelling = true)]
        internal static extern int GdipDisposeImage(IntPtr image);

    }

} // namespace GdiPlusLib
