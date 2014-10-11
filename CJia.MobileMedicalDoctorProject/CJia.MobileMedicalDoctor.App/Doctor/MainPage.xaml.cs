using CJia.MobileMedicalDoctor.App.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.MobileMedicalDoctor.App.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : BasePage, Views.IMainPageView
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MainPagePresenter(this);
        }

        ObservableCollection<Data.Tile> listTile = new ObservableCollection<Data.Tile>();

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            listTile.Clear();

            Data.Tile myPatientTile = new Data.Tile("日常查房", "我的病人", "☆共个", "Images/Doctor/MyPatients.png", "Images/Doctor/MyPatient.png");
            myPatientTile.Description2 = "☆您有新病人！";
            myPatientTile.Description3 = "☆今天有新检查报告！";
            listTile.Add(myPatientTile);
            // new SolidColorBrush(Colors.Purple)  UI.NewSolidColorBrush("#ff215f0e")
            Data.Tile officePatientTile = new Data.Tile("日常查房", "科室病人", "☆共个", "Images/Doctor/DeptPatient.png", "Images/Doctor/OfficePatient.png");
            officePatientTile.Description2 = "☆今天有新化验报告！";
            listTile.Add(officePatientTile);

            listTile.Add(new Data.Tile("日常查房", "值班病人", "☆共个", "Images/Doctor/DutyPatient.jpg", "Images/DoctorMyPatient.png"));

            listTile.Add(new Data.Tile("历史记录", "近期查房", "☆共个", "Images/Doctor/ResentVisit.png", "Images/Doctor/HistoryPatient.png"));
            listTile.Add(new Data.Tile("历史记录", "出院患者", "☆共个", "Images/Doctor/LeavePatient.jpg", "Images/Doctor/OfficePatient.png"));
            listTile.Add(new Data.Tile("历史记录", "同步日志", "☆共100条", "Images/Doctor/Blog.jpg", "Images/Doctor/DutyPatient.png"));
            listTile.Add(new Data.Tile("数据字典", "医嘱数据", "☆共条", "Images/Doctor/Advice1.png", "Images/Doctor/OfficePatient.png"));
            listTile.Add(new Data.Tile("数据字典", "药品数据", "☆共条", "Images/Doctor/PharmData1.png", "Images/Doctor/DutyPatient.png"));
            listTile.Add(new Data.Tile("数据字典", "物价数据", "☆共条", "Images/Doctor/Price1.png", "Images/Doctor/HistoryPatient.png"));

            var groupData = listTile.GroupBy<Data.Tile, string>(new Func<Data.Tile, string>(GroupAndOrderByDataType));
            cvsGroupData.Source = groupData;

            labDoctorName.Text = CJia.MobileMedicalDoctor.iCommon.DoctorName;
            labOfficeName.Text = CJia.MobileMedicalDoctor.iCommon.LoginUser.DeptName;
            //this.gridMain.IsEnabled = false;
            //OnLoadData(null, null);
            OnQueryTileData(null, null);
        }
        private string GroupAndOrderByDataType(Data.Tile p)
        {
            return p.TileType;
        }
        private void gridMain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridMain.SelectedItem == null) return;
            Data.Tile t = this.gridMain.SelectedItem as Data.Tile;
            if (t.TileType == "日常查房" || t.Title == "近期查房" || t.Title == "出院患者")
                this.Frame.Navigate(typeof(Doctor.PatientsPage), t);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        public event EventHandler OnLoadData;

        //public void ExeLoadDataComplet()
        //{
            //this.gridMain.IsEnabled = true;
            //this.cvSync.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ////加载完成后查询Tile相关数据；
            //OnQueryTileData(null, null);
        //}


        //public void ExeShowSyncProgress(int now, int max, string Hint)
        //{
            //this.barSync.Value = now;
            //this.barSync.Maximum = max;
            //this.txtSyncHint.Text = Hint;
            //this.cvSync.Visibility = Windows.UI.Xaml.Visibility.Visible;
        //}


        public void ExeShowPatientCount(List<int> CountData)
        {
            listTile[0].Description1 = String.Format("☆共{0}个", CountData[0]);
            listTile[1].Description1 = String.Format("☆共{0}个", CountData[1]);
            listTile[2].Description1 = String.Format("☆共{0}个", CountData[2]);
            listTile[3].Description1 = String.Format("☆共{0}个", CountData[3]);
            listTile[4].Description1 = String.Format("☆共{0}个", CountData[4]);
            listTile[6].Description1 = String.Format("☆共{0}个", CountData[5]);
            listTile[7].Description1 = String.Format("☆共{0}个", CountData[6]);
        }

        public event EventHandler OnQueryTileData;

        //数据同步
        //private void btnDataSync_Click_1(object sender, RoutedEventArgs e)
        //{
        //    this.OnLoadData(null, null);
        //}
    }
}
