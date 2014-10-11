using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Navigate.App.UI
{
    public partial class PicShowView : CJia.Parking.Tools.View, CJia.Parking.Views.Navigate.IPicShowView
    {
        CJia.Parking.Views.Navigate.PicShowArgs picShowArgs=new Parking.Views.Navigate.PicShowArgs();

        public PicShowView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new CJia.Parking.Presenters.Navigate.PicShowPresenter(this);
        }

        private Image img;
        private string licenceNo;
        private string parkNo;
        private string inParkTime;
        //public delegate void BtnNavigateClick(object sender, CJia.Parking.Views.Navigate.PicShowArgs e);//事件所需的委托
        //public event BtnNavigateClick NavigateClick;
        //public virtual void OnBtnNavigateClick(CJia.Parking.Views.Navigate.PicShowArgs e)
        //{
        //    if (NavigateClick != null)
        //    {//判断事件是否为空
        //        NavigateClick(this, e);//触发事件
        //    }
        //}

        public Image Img
        {
            set
            {
                img = value;
                pictureEdit1.Image = value;
            }
            get
            {
                return img;
            }
        }

        public string LicenceNo
        {
            set
            {
                licenceNo = value;
                labelControl4.Text = value;
            }
            get
            {
                return licenceNo;
            }
        }

        public string ParkNo
        {
            set
            {
                parkNo = value;
                labelControl5.Text = value;
            }
            get
            {
                return parkNo;
            }
        }

        public string InParkTime
        {
            set
            {
                inParkTime = value;
                labelControl6.Text = value;
            }
            get
            {
                return inParkTime;
            }
        }
    }
}
