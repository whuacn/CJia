using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Net;

namespace CJia.Evaluation.Web
{
    public partial class CheckCode : System.Web.UI.Page
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //生成验证码
                string temp = this.GetCode(4);
                HttpCookie cookie = new HttpCookie("yzm");
                cookie.Value = temp;
                Response.Cookies.Add(cookie);
                //画图
                this.GetCheckCodeImage(temp);
            }
        }
        //产生随机字符串 
        private string GetCode(int num)
        {
            string[] source ={ "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", 
            "K", "L", "M", "N", "O","P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" ,"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", 
            "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y","z"};
            string code = "";
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                code += source[rd.Next(0, source.Length)];
            }
            Session["ValidateCode"] = code;//将字符串保存到Session中，以便需要时进行验证  
            return code;

        }
        #region    验证码
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="checkCode"></param>
        private void GetCheckCodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty) return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)) + 2, 25);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();     //生成随机生成器 
                g.Clear(Color.White);            //清空图片背景色
                for (int i = 0; i < 5; i++)     //画图片的背景噪音线
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点
                for (int i = 0; i < 60; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}

        #endregion
