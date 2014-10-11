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
    public partial class TimeQueryView : CJia.Parking.Tools.View, CJia.Parking.Views.Navigate.ITimeQueryView
    {
        DevExpress.XtraEditors.SimpleButton buttonFloor;
        DevExpress.XtraEditors.SimpleButton buttonTime;

        List<int> floorList=new List<int>();

        List<string> timeList = new List<string>();

        DevExpress.XtraTab.XtraTabControl xtra;

        DataTable dtPic;

        CJia.Parking.Views.Navigate.TimeQueryArgs timeQueryArgs = new Parking.Views.Navigate.TimeQueryArgs();

        public TimeQueryView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new CJia.Parking.Presenters.Navigate.TimeQueryPresenter(this);
        }

        private void btnFloor_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = sender as DevExpress.XtraEditors.SimpleButton;
            if (btn.ButtonStyle == DevExpress.XtraEditors.Controls.BorderStyles.Default)
            {
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                btn.Appearance.BackColor = Color.Gray;
                floorList.Add(int.Parse(btn.Tag.ToString()));
            }
            else
            {
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                floorList.RemoveAll(t => t == Convert.ToInt32(btn.Tag));
            }
        }

        private void buttonTime_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = sender as DevExpress.XtraEditors.SimpleButton;

            if (btn.ButtonStyle == DevExpress.XtraEditors.Controls.BorderStyles.Default)
            {
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                btn.Appearance.BackColor = Color.Gray;
                timeList.Add(btn.Text.ToString().PadLeft(2, '0'));
            }
            else
            {
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                timeList.RemoveAll(t => t == btn.Text.ToString().PadLeft(2, '0'));
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            timeQueryArgs.floorList = floorList;
            timeQueryArgs.timeList = timeList;
            if (floorList.Count == 0 && timeList.Count == 0)
            {
                MessageBox.Show("楼层与时间必须同时选择！");
                return;
            }
            OnTimeQury(null, timeQueryArgs);


            string Queryfactor = @"select res.* from 
                            (select row_number() over() rownumber,* 
                                from vt_park 
                                where  ";
            List<object> list = new List<object>();
            if (floorList.Count > 0)
            {
                Queryfactor = Queryfactor + " ( ";
                for (int i = 0; i < floorList.Count; i++)
                {
                    Queryfactor = Queryfactor + " floor_id=:" + (i + 1).ToString() + " or ";
                    list.Add(floorList[i]);
                }
                Queryfactor = Queryfactor.Substring(0, Queryfactor.Length - 3) + " ) ";
            }
            if (floorList.Count > 0 && timeList.Count > 0)
            {
                Queryfactor = Queryfactor + " and  ";
            }
            if (timeList.Count > 0)
            {
                Queryfactor = Queryfactor + "  ( ";
                for (int j = 0; j < timeList.Count; j++)
                {
                    Queryfactor = Queryfactor + " to_char(in_park_date, 'HH24')=:" + (floorList.Count + j + 1).ToString() + " or ";
                    list.Add(timeList[j]);
                }
                Queryfactor = Queryfactor.Substring(0, Queryfactor.Length - 3) + " ) ";
            }
            
            Queryfactor = Queryfactor + ") res where  rownumber BETWEEN :" + (floorList.Count + timeList.Count + 1).ToString() + " and :" + (floorList.Count + timeList.Count + 2).ToString();
            list.Add(1);
            list.Add(4);

            xtra = this.Parent.Parent.Parent.Parent.Parent as DevExpress.XtraTab.XtraTabControl;
            if (!this.isExistPage("照片查看"))
            {
                CarPhotosView carphotos = new CarPhotosView(dtPic, 3, Queryfactor,list);
                this.ShowPage("照片查看", carphotos);
            }
            else
            {
                for (int i = 0; i < xtra.TabPages.Count; i++)
                {
                    if (xtra.TabPages[i].Name == "照片查看")
                    {
                        CarPhotosView carphotos = new CarPhotosView(dtPic, 3, Queryfactor, list);
                        this.ShowPage("照片查看", carphotos);
                        break;
                    }
                }
            }
        }

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

        #region【接口实现 】
        public void ExeShowPic(DataTable dt)
        {
            dtPic = dt;
        }

        public event EventHandler<Parking.Views.Navigate.TimeQueryArgs> OnTimeQury;
        #endregion

        private void btnResect_Click(object sender, EventArgs e)
        {
            Panel pan = this.Controls.Find("panTime", true)[0] as Panel;
            Control.ControlCollection cons = pan.Controls;
            for (int i = 0; i < cons.Count; i++)
            {
                if (cons[i].GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                {
                    (cons[i] as DevExpress.XtraEditors.SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                }
            }
        }

        private void TimeQueryView_SizeChanged(object sender, EventArgs e)
        {
            int parentWidth = this.Width;
            int parentHeight = this.Height;
            int width = panTime.Width;
            int height = panTime.Height;
            panTime.Location = new Point((parentWidth - width) / 2, (parentHeight - height) / 2);
        }
    }
}
