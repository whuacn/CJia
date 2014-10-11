using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Navigate.App.Common;

namespace CJia.Navigate.App.UI
{
    public partial class CarPhotosView : CJia.Parking.Tools.View, CJia.Parking.Views.Navigate.ICarPhotosView
    {
        //定义当前显示的结果是第几页
        int PageIndex = 1;
        //定义当前显示的是哪个查询页面的查询结果，1代表快速查询，2代表全车牌查询，3代表时间查询，4代表车位查询
        int WhichQuery;
        //1代表查看大图，2代表导航
        int WhichImage;
        //时间查询的参数
        List<object> TimeQueryList = new List<object>();

        string SatrtNo = CJia.Parking.Tools.ConfigHelper.GetAppStrings("StartNo");
        CJia.Parking.Views.Navigate.CarPhotosArgs carPhotosArgs = new Parking.Views.Navigate.CarPhotosArgs();

        Image img1, img2, img3, img4, img5, img6;
        string ParkNo, ParkNo1, ParkNo2, ParkNo3, ParkNo4, ParkNo5, ParkNo6;
        string Lice, Lice1, Lice2, Lice3, Lice4, Lice5, Lice6;
        string Floor, Floor1, Floor2, Floor3, Floor4, Floor5, Floor6;
        string ParkTime, ParkTime1, ParkTime2, ParkTime3, ParkTime4, ParkTime5, ParkTime6;
        DevExpress.XtraTab.XtraTabControl xtra;
        //List<Node> nodeList=Init();
        DevExpress.XtraEditors.SimpleButton btnNavigate1;
        DevExpress.XtraEditors.SimpleButton btnBigPic1 ;
        DevExpress.XtraEditors.SimpleButton btnMorePic1;
        DevExpress.XtraEditors.SimpleButton btnNavigate2;
        DevExpress.XtraEditors.SimpleButton btnBigPic2;
        DevExpress.XtraEditors.SimpleButton btnMorePic2;
        DevExpress.XtraEditors.SimpleButton btnNavigate3;
        DevExpress.XtraEditors.SimpleButton btnBigPic3;
        DevExpress.XtraEditors.SimpleButton btnMorePic3;
        DevExpress.XtraEditors.SimpleButton btnNavigate4;
        DevExpress.XtraEditors.SimpleButton btnBigPic4;
        DevExpress.XtraEditors.SimpleButton btnMorePic4;
        DevExpress.XtraEditors.SimpleButton btnNavigate5;
        DevExpress.XtraEditors.SimpleButton btnBigPic5;
        DevExpress.XtraEditors.SimpleButton btnMorePic5;
        DevExpress.XtraEditors.SimpleButton btnNavigate6;
        DevExpress.XtraEditors.SimpleButton btnBigPic6;
        DevExpress.XtraEditors.SimpleButton btnMorePic6;
        DevExpress.XtraEditors.PictureEdit picbox1;
        DevExpress.XtraEditors.PictureEdit picbox2;
        DevExpress.XtraEditors.PictureEdit picbox3;
        DevExpress.XtraEditors.PictureEdit picbox4;
        DevExpress.XtraEditors.PictureEdit picbox5;
        DevExpress.XtraEditors.PictureEdit picbox6;


        public CarPhotosView()
        {
            InitializeComponent();
            
        }

        protected override object CreatePresenter()
        {
            return new CJia.Parking.Presenters.Navigate.CarphotosPresenter(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtPic"></param>
        /// <param name="whichQuery">定义当前显示的是哪个查询页面的查询结果，1代表快速查询，2代表全车牌查询，3代表时间查询，4代表车位查询</param>
        public CarPhotosView(DataTable dtPic,int whichQuery,string Queryfactor,List<object> QueryList)
        {
            InitializeComponent();
            int width = picShowView1.Width = picShowView2.Width = picShowView3.Width = picShowView4.Width = picShowView5.Width = picShowView6.Width = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 100) / 3;
            int height = picShowView1.Height = picShowView2.Height = picShowView3.Height = picShowView4.Height = picShowView5.Height = picShowView6.Height = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 160 - 120) / 2;
            picShowView1.Width = picShowView2.Width = picShowView3.Width = picShowView4.Width = picShowView5.Width = picShowView6.Width = width;
            picShowView1.Height = picShowView2.Height = picShowView3.Height = picShowView4.Height = picShowView5.Height = picShowView6.Height = height;
            picShowView1.Location = new Point(35, 50);
            picShowView2.Location = new Point(55 + width, 50);
            picShowView3.Location = new Point(75 + 2 * width, 50);
            picShowView4.Location = new Point(35, 70 + height);
            picShowView5.Location = new Point(55 + width, 70 + height);
            picShowView6.Location = new Point(75 + 2 * width, 70 + height);
            WhichQuery = whichQuery;
            switch (whichQuery)
            { 
                case 1:
                    carPhotosArgs.fast1 = QueryList[0].ToString();
                    carPhotosArgs.fast2 = QueryList[1].ToString();
                    carPhotosArgs.fast3 = QueryList[2].ToString();
                    carPhotosArgs.fast4 = QueryList[3].ToString();
                    carPhotosArgs.fast5 = QueryList[4].ToString();
                    break;
                case 2:
                    carPhotosArgs.LicenecNo = Queryfactor;
                    break;
                case 3:
                    carPhotosArgs.TimeQuerySql = Queryfactor;
                    carPhotosArgs.TimeQueryPar = QueryList;
                    break;
                case 4:
                    carPhotosArgs.ParkNo = Queryfactor;
                    break;
                default:
                    break;
            }
            ShowPic(dtPic);
        }

        /// <summary>
        /// 页面显示图片
        /// </summary>
        /// <param name="dtPic"></param>
        private void ShowPic(DataTable dtPic)
        {
            if (dtPic.Rows.Count < 6 || (dtPic.Rows[5] != null && dtPic.Rows.Count == 6))
            {
                LblNextPage.Enabled = false;
            }
            else
            {
                LblNextPage.Enabled = true;
            }
            if (PageIndex == 1)
            {
                LblBeforePage.Enabled = false;
            }
            else
            {
                LblBeforePage.Enabled = true;
            }
            if (dtPic.Rows.Count >= 1)
            {
                img1 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[0]["PARKING_PIC"]);
                picShowView1.Visible = true;
                picShowView1.Img = img1;
                Lice1 = picShowView1.LicenceNo = dtPic.Rows[0]["PLATE_NO"].ToString();
                picShowView1.ParkNo = dtPic.Rows[0]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[0]["AREA_NO"].ToString() + "->" + dtPic.Rows[0]["PARK_NO"].ToString() + "车位";
                ParkNo1 = dtPic.Rows[0]["PARK_NO"].ToString();
                Floor1 = dtPic.Rows[0]["FLOOR_NO"].ToString();
                ParkTime1 = picShowView1.InParkTime = dtPic.Rows[0]["IN_PARK_DATE"].ToString();
                //picShowView1.Location = new Point(50, 50);
                picbox1 = picShowView1.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate1 = picShowView1.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic1 = picShowView1.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic1 = picShowView1.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox1.Click += btnBigPic1_Click;
                btnBigPic1.Click += btnBigPic1_Click;
                btnNavigate1.Click += btnNavigate1_Click;
                this.Controls.Add(picShowView1);
            }
            if (dtPic.Rows.Count >= 2)
            {
                img2 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[1]["PARKING_PIC"]);
                picShowView2.Visible = true;
                picShowView2.Img = img2;
                Lice2 = picShowView2.LicenceNo = dtPic.Rows[1]["PLATE_NO"].ToString();
                picShowView2.ParkNo = dtPic.Rows[1]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[1]["AREA_NO"].ToString() + "->" + dtPic.Rows[1]["PARK_NO"].ToString() + "车位";
                ParkNo2 = dtPic.Rows[1]["PARK_NO"].ToString();
                Floor2 = dtPic.Rows[1]["FLOOR_NO"].ToString();
                ParkTime2 = picShowView2.InParkTime = dtPic.Rows[1]["IN_PARK_DATE"].ToString();
                picbox2 = picShowView2.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate2 = picShowView2.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic2 = picShowView2.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic2 = picShowView2.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox2.Click += btnBigPic2_Click;
                btnBigPic2.Click += btnBigPic2_Click;
                btnNavigate2.Click += btnNavigate2_Click;
                this.Controls.Add(picShowView2);
            }
            if (dtPic.Rows.Count >= 3)
            {
                img3 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[2]["PARKING_PIC"]);
                picShowView3.Visible = true;
                picShowView3.Img = img3;
                Lice3 = picShowView3.LicenceNo = dtPic.Rows[2]["PLATE_NO"].ToString();
                picShowView3.ParkNo = dtPic.Rows[2]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[2]["AREA_NO"].ToString() + "->" + dtPic.Rows[2]["PARK_NO"].ToString() + "车位";
                ParkNo3 = dtPic.Rows[2]["PARK_NO"].ToString();
                Floor3 = dtPic.Rows[2]["FLOOR_NO"].ToString();
                ParkTime3 = picShowView3.InParkTime = dtPic.Rows[2]["IN_PARK_DATE"].ToString();
                picbox3 = picShowView3.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate3 = picShowView3.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic3 = picShowView3.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic3 = picShowView3.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox3.Click += btnBigPic3_Click;
                btnBigPic3.Click += btnBigPic3_Click;
                btnNavigate3.Click += btnNavigate3_Click;
                this.Controls.Add(picShowView3);
            }
            if (dtPic.Rows.Count >= 4)
            {
                img4 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[3]["PARKING_PIC"]);
                picShowView4.Visible = true;
                picShowView4.Img = img4;
                Lice4 = picShowView4.LicenceNo = dtPic.Rows[3]["PLATE_NO"].ToString();
                picShowView4.ParkNo = dtPic.Rows[3]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[3]["AREA_NO"].ToString() + "->" + dtPic.Rows[3]["PARK_NO"].ToString() + "车位";
                ParkNo4 = dtPic.Rows[3]["PARK_NO"].ToString();
                Floor4 = dtPic.Rows[3]["FLOOR_NO"].ToString();
                ParkTime4 = picShowView4.InParkTime = dtPic.Rows[3]["IN_PARK_DATE"].ToString();
                picbox4 = picShowView4.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate4 = picShowView4.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic4 = picShowView4.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic4 = picShowView4.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox4.Click += btnBigPic4_Click;
                btnBigPic4.Click += btnBigPic4_Click;
                btnNavigate4.Click += btnNavigate4_Click;
                this.Controls.Add(picShowView4);
            }
            if (dtPic.Rows.Count >= 5)
            {
                img5 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[4]["PARKING_PIC"]);
                picShowView5.Visible = true;
                picShowView5.Img = img5;
                Lice5 = picShowView5.LicenceNo = dtPic.Rows[4]["PLATE_NO"].ToString();
                picShowView5.ParkNo = dtPic.Rows[4]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[4]["AREA_NO"].ToString() + "->" + dtPic.Rows[4]["PARK_NO"].ToString() + "车位";
                ParkNo5 = dtPic.Rows[4]["PARK_NO"].ToString();
                Floor5 = dtPic.Rows[4]["FLOOR_NO"].ToString();
                ParkTime5 = picShowView5.InParkTime = dtPic.Rows[4]["IN_PARK_DATE"].ToString();
                picbox5 = picShowView5.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate5 = picShowView5.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic5 = picShowView5.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic5 = picShowView5.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox5.Click += btnBigPic5_Click;
                btnBigPic5.Click += btnBigPic5_Click;
                btnNavigate5.Click += btnNavigate5_Click;
                this.Controls.Add(picShowView5);
            }
            if (dtPic.Rows.Count >= 6)
            {
                img6 = CJia.Parking.Tools.Help.GetImageByBytes((byte[])dtPic.Rows[5]["PARKING_PIC"]);
                picShowView6.Visible = true;
                picShowView6.Img = img6;
                Lice6 = picShowView6.LicenceNo = dtPic.Rows[5]["PLATE_NO"].ToString();
                picShowView6.ParkNo = dtPic.Rows[5]["FLOOR_NO"].ToString() + "层->" + dtPic.Rows[5]["AREA_NO"].ToString() + "->" + dtPic.Rows[5]["PARK_NO"].ToString() + "车位";
                ParkNo6 = dtPic.Rows[5]["PARK_NO"].ToString();
                Floor6 = dtPic.Rows[5]["FLOOR_NO"].ToString();
                ParkTime6 = picShowView6.InParkTime = dtPic.Rows[5]["IN_PARK_DATE"].ToString();
                picbox6 = picShowView6.Controls.Find("pictureEdit1", true)[0] as DevExpress.XtraEditors.PictureEdit;
                btnNavigate6 = picShowView6.Controls.Find("btnNavigate", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnBigPic6 = picShowView6.Controls.Find("btnBigPic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                btnMorePic6 = picShowView6.Controls.Find("btnMorePic", true)[0] as DevExpress.XtraEditors.SimpleButton;
                picbox6.Click += btnBigPic6_Click;
                btnBigPic6.Click += btnBigPic6_Click;
                btnNavigate6.Click += btnNavigate6_Click;
                this.Controls.Add(picShowView6);
            }
        }

        #region【界面代码】
        void btnBigPic6_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan, picturebox, img6, "查看大图");
        }

        void btnBigPic5_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan, picturebox, img5, "查看大图");
        }

        void btnBigPic4_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan, picturebox, img4, "查看大图");
        }

        void btnBigPic3_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan, picturebox, img3, "查看大图");
        }

        void btnBigPic2_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan, picturebox, img2, "查看大图");
        }

        void btnBigPic1_Click(object sender, EventArgs e)
        {
            WhichImage = 1;
            ShowBigPic(pan,picturebox, img1,"查看大图");
        }

        //private void pictureEdit1_Click(object sender, EventArgs e)
        //{
        //    WhichImage = 1;
        //    CancleShowBigPic();
        //}
        void btnNavigate6_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo6;
            Floor = Floor6;
            ParkTime = ParkTime6;
            Lice = Lice6;
            ShowWay(SatrtNo, ParkNo6, Floor6, ParkTime6, Lice6);
        }

        void btnNavigate5_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo5;
            Floor = Floor5;
            ParkTime = ParkTime5;
            Lice = Lice5;
            ShowWay(SatrtNo, ParkNo5, Floor5, ParkTime5, Lice5);
        }

        void btnNavigate4_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo4;
            Floor = Floor4;
            ParkTime = ParkTime4;
            Lice = Lice4;
            ShowWay(SatrtNo,ParkNo4, Floor4, ParkTime4, Lice4);
        }

        void btnNavigate3_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo3;
            Floor = Floor3;
            ParkTime = ParkTime3;
            Lice = Lice3;
            ShowWay(SatrtNo,ParkNo3, Floor3, ParkTime3, Lice3);
        }

        void btnNavigate2_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo2;
            Floor = Floor2;
            ParkTime = ParkTime2;
            Lice = Lice2;
            ShowWay(SatrtNo,ParkNo2, Floor2, ParkTime2, Lice2);
        }

        void btnNavigate1_Click(object sender, EventArgs e)
        {
            WhichImage = 2;
            ParkNo = ParkNo1;
            Floor = Floor1;
            ParkTime = ParkTime1;
            Lice = Lice1;
            ShowWay(SatrtNo,ParkNo1, Floor1, ParkTime1, Lice1);
        }

        private void pan_Click(object sender, EventArgs e)
        {
            CancleShowBigPic();

            if (WhichImage == 2)
            {
                if (Floor == "B2")
                {
                    SatrtNo = "PC-002";
                }
                if (Floor == "B1")
                {
                    SatrtNo = "PC-001";
                }

                xtra = this.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
                ShowWayView showway = new ShowWayView(SatrtNo, ParkNo, Floor, ParkTime, Lice);
                this.ShowPage("导航", showway);
            }
        }
        
        private void ShowWay(string Start, string parkNo,string floor,string parkTime,string lice)
        {
            if (CJia.Parking.Tools.ConfigHelper.GetAppStrings("StartFloor") == floor)
            {
                xtra = this.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
                ShowWayView showway = new ShowWayView(SatrtNo,parkNo, floor, parkTime, lice);
                this.ShowPage("导航", showway);
            }
            else
            {
                if (floor == "B1")
                {
                    ShowBigPic(pan, picturebox, global::CJia.Navigate.App.Properties.Resources.B2_B1, "楼层指引");
                }
                if (Floor == "B2")
                {
                    ShowBigPic(pan, picturebox, global::CJia.Navigate.App.Properties.Resources.B1_B2, "楼层指引");
                }
                //pan.Width = 650;
                //pan.Height = 500;
                //pan.BackColor = Color.Black;
                //picturebox.Width = 640;
                //picturebox.Height = 430;
                //pan.Controls.Add(picturebox);
                //picturebox.Location = new Point(5, 65);
                //pan.Location = GetPosition(pan.Width, pan.Height);
                
                //this.Controls.SetChildIndex(pan, 1);
                
            }
            //if (!this.isExistPage("导航"))
            //{
            //    //string Queryfactor = fastQueryArgs.Fast1 + fastQueryArgs.Fast2 + fastQueryArgs.Fast3 + fastQueryArgs.Fast4 + fastQueryArgs.Fast5;
            //    //List<object> QueryList = new List<object>() { fastQueryArgs.Fast1, fastQueryArgs.Fast2, fastQueryArgs.Fast3, fastQueryArgs.Fast4, fastQueryArgs.Fast5 };
            //    ShowWayView showway = new ShowWayView(parkNo, floor, parkTime, lice);
            //    this.ShowPage("导航", showway);
            //}
        }
        #endregion

        #region 【页面代码】
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        private bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < xtra.TabPages.Count; i++)
            {
                if (xtra.TabPages[i].Name == PageTitle)
                {
                    xtra.SelectedTabPage = xtra.TabPages[i];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="pageTitle">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            page1.AutoScroll = true;
            xtra.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            xtra.SelectedTabPage = page1;
        }
        #endregion

        #region【页面操作】
        /// <summary>
        /// 查看大图
        /// </summary>
        /// <param name="img">图片</param>
        private void ShowBigPic(Panel panle, PictureBox picbox, Image img,string msg)
        {
            panle.Width = 650;
            panle.Height = 480;
            panle.BackColor = Color.Black;
            lblMsg.Location = new Point(270, 10);
            picbox.Width = 640;
            picbox.Height = 430;
            picbox.Location = new Point(5, 45);
            panle.Location = GetPosition(panle.Width, panle.Height);
            this.Controls.SetChildIndex(panle, 1);
            this.BackColor = Color.Gray;
            picShowView1.BackColor = Color.Gray;
            picShowView2.BackColor = Color.Gray;
            picShowView3.BackColor = Color.Gray;
            picShowView4.BackColor = Color.Gray;
            picShowView5.BackColor = Color.Gray;
            picShowView6.BackColor = Color.Gray;
            LblBeforePage.Enabled = false;
            LblNextPage.Enabled = false;
            //LblReturn.Enabled = false;
            Control.ControlCollection cons = this.Controls;
            for (int i = 0; i < cons.Count; i++)
            {
                if (cons[i].GetType() == typeof(CJia.Navigate.App.UI.PicShowView))
                {
                    Control.ControlCollection picCon = cons[i].Controls;
                    for (int j = 0; j < picCon.Count; j++)
                    {
                        if (picCon[j].GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                        {
                            (picCon[j] as DevExpress.XtraEditors.SimpleButton).Enabled = false;
                        }
                        if(picCon[j].GetType() == typeof(DevExpress.XtraEditors.PictureEdit))
                        {
                            (picCon[j] as DevExpress.XtraEditors.PictureEdit).Enabled = false;
                        }
                    }
                }
            }
            lblMsg.Text = "【" + msg + "】";
            lblMsg.Visible = true;
            panle.Visible = true;
            picbox.Visible = true;
            picbox.Image = img;
        }

        /// <summary>
        /// 取消查看大图
        /// </summary>
        private void CancleShowBigPic()
        {
            this.BackColor = Color.LightGray;
            picShowView1.BackColor = Color.LightGray;
            picShowView2.BackColor = Color.LightGray;
            picShowView3.BackColor = Color.LightGray;
            picShowView4.BackColor = Color.LightGray;
            picShowView5.BackColor = Color.LightGray;
            picShowView6.BackColor = Color.LightGray;
            LblBeforePage.Enabled = true;
            LblNextPage.Enabled = true;
            //LblReturn.Enabled = true;
            //把按钮置为可用状态
            Control.ControlCollection cons = this.Controls;
            for (int i = 0; i < cons.Count; i++)
            {
                if (cons[i].GetType() == typeof(CJia.Navigate.App.UI.PicShowView))
                {
                    Control.ControlCollection picCon = cons[i].Controls;
                    for (int j = 0; j < picCon.Count; j++)
                    {
                        if (picCon[j].GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                        {
                            (picCon[j] as DevExpress.XtraEditors.SimpleButton).Enabled = true;
                        }
                        if(picCon[j].GetType() == typeof(DevExpress.XtraEditors.PictureEdit))
                        {
                            (picCon[j] as DevExpress.XtraEditors.PictureEdit).Enabled = true;
                        }
                    }
                }
            }
            lblMsg.Visible = false;
            pan.Visible = false;
            picturebox.Visible = false;
        }

    

        //返回
        //private void LblReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DevExpress.XtraTab.XtraTabControl xtra = LblReturn.Parent.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
        //    //xtra.SelectedTabPage=
        //    //DevExpress.XtraTab.XtraTabPage tabPage = LblReturn.Parent.Parent as DevExpress.XtraTab.XtraTabPage;
        //    //tabPage.Dispose();
        //    for (int i = 0; i < xtra.TabPages.Count; i++)
        //    {
        //        if (xtra.TabPages[i].Name == "查询")
        //        {
        //            xtra.SelectedTabPage = xtra.TabPages[i];
        //        }
        //        if (xtra.TabPages[i].Name == "照片查看")
        //        {
        //            xtra.TabPages.Remove(xtra.TabPages[i]);
        //        }
        //    }
        //}

        //下一页
        private void LblNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picShowView1.Visible = false;
            picShowView2.Visible = false;
            picShowView3.Visible = false;
            picShowView4.Visible = false;
            picShowView5.Visible = false;
            picShowView6.Visible = false;
            PageIndex++;
            if (WhichQuery == 1)
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueryNextPageByFast(null, carPhotosArgs);
            }
            else if (WhichQuery == 2)
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueryNextPageByLice(null, carPhotosArgs);
            }
            else if (WhichQuery == 3)
            {
                int count = carPhotosArgs.TimeQueryPar.Count;
                carPhotosArgs.TimeQueryPar.RemoveAt(count - 1);
                carPhotosArgs.TimeQueryPar.RemoveAt(count - 2);
                carPhotosArgs.TimeQueryPar.Add(PageIndex * 6 - 5);
                carPhotosArgs.TimeQueryPar.Add(PageIndex * 6 + 1);
                OnQueryNextPageByTime(null, carPhotosArgs);
            }
            else
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueyrNextPageByPark(null, carPhotosArgs);
            }
            
            
        }

        //上一页
        private void LblBeforePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picShowView1.Visible = false;
            picShowView2.Visible = false;
            picShowView3.Visible = false;
            picShowView4.Visible = false;
            picShowView5.Visible = false;
            picShowView6.Visible = false;
            PageIndex--;
            if (WhichQuery == 1)
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueryNextPageByFast(null, carPhotosArgs);
            }
            else if (WhichQuery == 2)
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueryNextPageByLice(null, carPhotosArgs);
            }
            else if (WhichQuery == 3)
            {
                
                int count = carPhotosArgs.TimeQueryPar.Count;
                carPhotosArgs.TimeQueryPar.RemoveAt(count - 1);
                carPhotosArgs.TimeQueryPar.RemoveAt(count - 2);
                carPhotosArgs.TimeQueryPar.Add(PageIndex * 6 - 5);
                carPhotosArgs.TimeQueryPar.Add(PageIndex * 6 + 1);
                OnQueryNextPageByTime(null, carPhotosArgs);
            }
            else
            {
                carPhotosArgs.PageIndex = PageIndex;
                OnQueyrNextPageByPark(null, carPhotosArgs);
            }
        }

        private Point GetPosition(int width,int height)
        {
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            return new Point((ScreenWidth - width) / 2, (ScreenHeight - height) / 2 - 80);
        }

        #endregion

        #region【接口实现】
        public event EventHandler<Parking.Views.Navigate.CarPhotosArgs> OnQueryNextPageByLice;

        public event EventHandler<Parking.Views.Navigate.CarPhotosArgs> OnQueyrNextPageByPark;

        public event EventHandler<Parking.Views.Navigate.CarPhotosArgs> OnQueryNextPageByFast;

        public event EventHandler<Parking.Views.Navigate.CarPhotosArgs> OnQueryNextPageByTime;

        public void ExeShowPictrues(DataTable dt)
        {
            ShowPic(dt);
        }
        #endregion


        

        


       
    }
}
