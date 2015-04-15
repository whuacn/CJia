using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CJia.Health.App
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            //Image image = CJia.Health.Tools.Help.GetImageByUri("http://192.168.1.206:1717/2.jpg", "", "");
            Image image = Image.FromFile(@"E:\Health\2013\8\2\1343802\1343802_01_001_00.jpg");
            cJiaPicture1.Image = image;
            //test
        }

        private void cJiaButton1_Click(object sender, EventArgs e)
        {
            string fileName = cJiaOpenFile1.Text;
            CJia.Health.Tools.FtpHelp.UploadFile(fileName, "2023/1/1/01", "192.168.1.207", "ftp", "ftp");
            //CJia.Health.Tools.FtpHelp.UploadFileByFtpWebRequest(fileName, "192.168.1.208", "2014/11/34", "ftp", "ftp");
        }

        private void cJiaButton2_Click(object sender, EventArgs e)
        {
            cJiaTextBox2.Text = CJia.Health.Tools.Utils.AESEncrypt(cJiaTextBox1.Text);
        }

        private void cJiaButton3_Click(object sender, EventArgs e)
        {
            cJiaTextBox3.Text = CJia.Health.Tools.Utils.AESDecrypt(cJiaTextBox2.Text);
        }

        private void cJiaButton4_Click(object sender, EventArgs e)
        {
            string path = "ftp://192.168.1.207/2023/1/1/01/denghua.jpg";
            List<string> list3 = new List<string>();
            string a = Path.GetDirectoryName(path);
            //CJia.Health.Tools.FtpHelp.UploadFile(str2, "123/12", "192.168.1.207", "ftp", "ftp");
            //CJia.Health.Tools.FtpHelp.UploadFile(str2, "123/12", "192.168.1.206", "ftpuser", "ftpuser");
            //list3 = CJia.Health.Tools.FtpHelp.ListDirectory("2013", "192.168.1.206", "ftpuser", "ftpuser");
            //CJia.Health.Tools.FtpHelp.FtpIsExistsFile("", "192.168.1.206", "ftpuser", "ftpuser");
            CJia.Health.Tools.FtpHelp.MakeDirByUri("ftp://192.168.1.207/2013/3333/01/02", "192.168.1.207", "ftp", "ftp");
            string str = "ftp://192.168.1.207/2023/1/1/01";
            int i = str.LastIndexOf("192.168.1.207");
            string[] strs = str.Split('/');
        }
        /// <summary>
        /// 90°顺时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap Rotate90(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 90°逆时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap Rotate270(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        private void cJiaButton5_Click(object sender, EventArgs e)
        {
            Image img = cJiaPicture1.Image;
            Image newimg = Rotate90((Bitmap)img);
            cJiaPicture1.Image = newimg;
            newimg.Save(@"E:\Health\2013\8\2\1343802\1343802_01_001_00.jpg");
        }

        private void cJiaButton6_Click(object sender, EventArgs e)
        {
            Image img = cJiaPicture1.Image;
            Image newimg = Rotate270((Bitmap)img);
            cJiaPicture1.Image = newimg;
            newimg.Save(@"E:\Health\2013\8\2\1343802\1343802_01_001_00.jpg");
        }

        private void cJiaButton7_Click(object sender, EventArgs e)
        {
            string strPath = @"C:\Users\deng\Desktop\6\PNG";
            string[] strs = System.IO.Directory.GetFiles(strPath, "*", SearchOption.AllDirectories);
            foreach (string str in strs)
            {
                string a = @"C:\Users\deng\Desktop\6\" + Path.GetFileName(str);
                if (!File.Exists(a))
                {
                    File.Move(str, a);
                }
                else
                {
                    string b = @"C:\Users\deng\Desktop\6\" + Path.GetFileNameWithoutExtension(str) + Guid.NewGuid().ToString() + Path.GetExtension(str);
                    File.Move(str, b);
                }
            }
        }

    }
}
