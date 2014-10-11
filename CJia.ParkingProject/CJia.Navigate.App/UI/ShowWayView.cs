using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Navigate.App.Common;
using System.Drawing.Drawing2D;

namespace CJia.Navigate.App.UI
{
    public partial class ShowWayView : UserControl
    {
        string Start;
        string ParkNo;
        string Floor;
        string ParkTime;
        string Lice;
        private Bitmap _backImage;
        private Size _size;//图像大小
        private List<Point> listPoint = new List<Point>();
        //List<Node> NodeList;

        //public ShowWayView()
        //{
        //    InitializeComponent();
        //}

        public ShowWayView(string start, string parkNo,string floor,string parkTime,string lice)
        {
            InitializeComponent();
            pictureBox1.Location = GetPosition();
            //panelControl1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //panelControl1.Location = GetPanlePosition();
            Start = start;
            ParkNo = parkNo;
            Floor = floor;
            ParkTime = parkTime;
            Lice = lice;
            //NodeList = nodeList;
            lblParkNo.Text = parkNo;
            labelControl7.Text = lblFloor.Text = floor;
            lblParkTime.Text = parkTime;
            lblLIce.Text = lice;
            GetPic();
        }

        private void GetPic()
        {
            Bitmap bitmap;
            Image img = global::CJia.Navigate.App.Properties.Resources.停车场2;
            _size = new Size(img.Size.Width, img.Size.Height);
            _backImage = new Bitmap(img, _size);
            bitmap = new Bitmap(img, _size);
            pictureBox1.Height = _size.Height;
            pictureBox1.Width = _size.Width;
            pictureBox1.Image = global::CJia.Navigate.App.Properties.Resources.停车场2;

            //string StartNo = CJia.Parking.Tools.ConfigHelper.GetAppStrings("StartNo");
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = planner.Paln(Graph.Nodelist, Start, ParkNo);

            planner = null;
            List<Point> pointList = result.PointList;
            DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointByPointNo, new object[] { ParkNo });
            Point point = new Point(Convert.ToInt32(dtPoint.Rows[0]["point_X"]), Convert.ToInt32(dtPoint.Rows[0]["point_Y"]));
            pointList.Add(point);

            for (int i = 0; i < pointList.Count - 1; i++)
            {
                //DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryPointByPointNo, new object[] { nodeList[i].ToString() });
                //Point point = new Point(Convert.ToInt32(dtPoint.Rows[0]["point_X"]), Convert.ToInt32(dtPoint.Rows[0]["point_Y"]));
                //listPoint.Add(point);
                if (result.PointList.Count > 1)
                {
                    Bitmap bitmap1 = DrawLineInPicture(_backImage, pointList[i], pointList[i + 1], Color.Red, 5, DashStyle.Solid);
                    Image myimage = Image.FromHbitmap(bitmap1.GetHbitmap());
                    pictureBox1.Image = myimage;
                }
                PictureBox picstart = new PictureBox();
                //Image.FromFile("Images/起点.png");
                picstart.Image = global::CJia.Navigate.App.Properties.Resources.起点;
                picstart.Width = 25;
                picstart.Height = 24;
                picstart.BackColor = System.Drawing.Color.Transparent;
                pictureBox1.Controls.Add(picstart);
                picstart.Location = new Point(pointList[0].X - 12, pointList[0].Y - 12);

                PictureBox picend = new PictureBox();
                //Image.FromFile("Images/起点.png");
                picend.Image = global::CJia.Navigate.App.Properties.Resources.终点;
                picend.Width = 25;
                picend.Height = 24;
                picend.BackColor = System.Drawing.Color.Transparent;
                pictureBox1.Controls.Add(picend);
                picend.Location = new Point(pointList[pointList.Count - 1].X - 12, pointList[pointList.Count - 1].Y - 12);
            }


            //for (int j = 0; j < listPoint.Count - 1; j++)
            //{
            //    Bitmap bitmap1 = DrawLineInPicture(_backImage, listPoint[j], listPoint[j + 1], Color.Red, 2, DashStyle.Solid);
            //    Image myimage = Image.FromHbitmap(bitmap1.GetHbitmap());
            //    pictureBox1.Image = myimage;
            //}
            listPoint.Clear();
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

        private Point GetPosition()
        {
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int PicBoxWidth = pictureBox1.Width;
            int picBoxHeight = pictureBox1.Height;
            return new Point((ScreenWidth - PicBoxWidth) / 2, (ScreenHeight - picBoxHeight) / 2 - 80);
        }

        private Point GetPanlePosition()
        {
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int panWidth = panelControl1.Width;
            int panHeight = panelControl1.Height;
            return new Point(0, (ScreenHeight - panHeight) / 2);
        }

        //private void LblReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DevExpress.XtraTab.XtraTabControl xtra = LblReturn.Parent.Parent.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
        //    //xtra.SelectedTabPage=
        //    //DevExpress.XtraTab.XtraTabPage tabPage = LblReturn.Parent.Parent as DevExpress.XtraTab.XtraTabPage;
        //    //tabPage.Dispose();
        //    for (int i = 0; i < xtra.TabPages.Count; i++)
        //    {
        //        if (xtra.TabPages[i].Name == "照片查看")
        //        {
        //            xtra.SelectedTabPage = xtra.TabPages[i];
        //        }
        //        if (xtra.TabPages[i].Name == "导航")
        //        {
        //            //xtra.TabPages.Remove(xtra.TabPages[i]);
        //            xtra.TabPages[i].Dispose();
        //        }
        //    }
        //}

        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            int parentWidth = panelControl1.Width;
            int parentHeight = panelControl1.Height;
            //int panWidth = panel1.Width;
            //int panHeight = panel1.Height;
            int a = pictureBox1.Location.X;
            int b = pictureBox1.Location.Y;
            panel2.Location = new Point((a - panel2.Width)-5, b+5);
            panel1.Location = new Point(a + pictureBox1.Width + 5, b + 5);
        }

    }
}
