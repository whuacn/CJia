using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Navigate.App.Common;
using Microsoft.VisualBasic.PowerPacks;

namespace CJia.Navigate.App
{
    public partial class Form1 : Form
    {
        private Bitmap _backImage;
        private Size _size;//图像大小
        private List<Point> listPoint =new List<Point>();
        

        public Form1()
        {
            InitializeComponent();
            GetPic();
        }
        private void GetPic()
        {
            Bitmap bitmap;
            //Image img = Image.FromFile("C:\\Users\\huyang\\Desktop\\11-120484991.jpg");
            Image img = Image.FromFile("C:\\Users\\huyang\\Desktop\\停车场2.jpg");
            _size = new Size(img.Size.Width, img.Size.Height);
            _backImage = new Bitmap(img, _size);
            bitmap = new Bitmap(img, _size);
            pictureBox1.Height = _size.Height;
            pictureBox1.Width = _size.Width;
            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            GetPic();
            string begin = textBox1.Text;
            string end = textBox2.Text;
            //Graph graph = new Graph();
            //graph.Init();
            //RoutePlanner planner = new RoutePlanner();
            //RoutePlanResult result = planner.Paln(graph.NodeList, begin, end);

            //planner = null;
            //textBox3.Text = "";
            //List<string> nodeList = result.ResultNodes.ToList<string>();
            //nodeList.Add(end);
            //for (int i = 0; i < nodeList.Count; i++)
            //{
            //    textBox3.Text = textBox3.Text + "->" + nodeList[i];
            //    switch (nodeList[i].ToString())
            //    { 
            //        case "A":
            //            listPoint.Add(new Point(460,306));
            //            break;
            //        case "B":
            //            listPoint.Add(new Point(434,306));
            //            break;
            //        case "C":
            //            listPoint.Add(new Point(434, 291));
            //            break;
            //        case "D":
            //            listPoint.Add(new Point(434, 199));
            //            break;
            //        case "E":
            //            listPoint.Add(new Point(434, 51));
            //            break;
            //        case "F":
            //            listPoint.Add(new Point(251,51));
            //            break;
            //        case "G":
            //            listPoint.Add(new Point(251,199));
            //            break;
            //        case "H":
            //            listPoint.Add(new Point(251,291));
            //            break;
            //        case "I":
            //            listPoint.Add(new Point(251,249));
            //            break;
            //        case "J":
            //            listPoint.Add(new Point(194,249));
            //            break;
            //        default:
            //            break;
            //    }

            //    DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointByPointNo, new object[] { nodeList[i].ToString() });
            //    Point point = new Point(Convert.ToInt32(dtPoint.Rows[0]["point_X"]), Convert.ToInt32(dtPoint.Rows[0]["point_Y"]));
            //    listPoint.Add(point);
            //}
            //textBox3.Text = textBox3.Text.Substring(2);
            //for(int j=0;j<listPoint.Count-1;j++)
            //{
            //    Bitmap bitmap1 = DrawLineInPicture(_backImage, listPoint[j], listPoint[j + 1], Color.Red, 2, DashStyle.Solid);
            //    Image myimage = Image.FromHbitmap(bitmap1.GetHbitmap());
            //    pictureBox1.Image = myimage;
            //}
            //listPoint.Clear();
        }

        //画线
        public static Bitmap DrawLineInPicture(Bitmap bitmap, Point p0, Point p1, Color LineColor, int LineWidth, DashStyle ds)
        {
            if (bitmap == null) return null;

            if (p0.X == p1.X && p0.Y == p1.Y) return bitmap;

            Graphics g = Graphics.FromImage(bitmap);

            Brush brush = new SolidBrush(LineColor);

            Pen pen = new Pen(brush, LineWidth);
            //pen.Alignment = PenAlignment.Inset;

            pen.DashStyle = ds;

            g.DrawLine(pen, p0, p1);

            g.Dispose();

            return bitmap;
        }
    }
}
