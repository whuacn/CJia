using CJia.iSmartMedical.Win8.Common;
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

namespace CJia.iSmartMedical.Win8.Doctor
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

            Data.Tile myPatientTile = new Data.Tile("日常查房", "我的病人", "☆共个", new SolidColorBrush(Colors.DodgerBlue), "Images/Doctor/MyPatient.png");
            myPatientTile.Description2 = "☆您有新病人！";
            myPatientTile.Description3 = "☆今天有新检查报告！";
            listTile.Add(myPatientTile);

            Data.Tile officePatientTile = new Data.Tile("日常查房", "科室病人", "☆共个", new SolidColorBrush(Colors.Purple), "Images/Doctor/OfficePatient.png");
            officePatientTile.Description2 = "☆今天有新化验报告！";
            listTile.Add(officePatientTile);

            listTile.Add(new Data.Tile("日常查房", "值班病人", "☆共个", new SolidColorBrush(Colors.SlateBlue), "Images/Doctor/DutyPatient.png"));
            listTile.Add(new Data.Tile("日常查房", "近期查房", "☆共个", UI.NewSolidColorBrush("#FF00C996"), "Images/Doctor/HistoryPatient.png"));

            listTile.Add(new Data.Tile("医生会诊", "会诊病人", "☆共个", new SolidColorBrush(Colors.Coral), "Images/Doctor/HistoryPatient.png"));
            listTile.Add(new Data.Tile("医生会诊", "远程会诊", "☆共2个会诊请求", new SolidColorBrush(Colors.Indigo), "Images/Doctor/OfficePatient.png"));

            listTile.Add(new Data.Tile("历史记录", "出院患者", "☆共个", UI.NewSolidColorBrush("#FF00B6C3"), "Images/Doctor/OfficePatient.png"));
            listTile.Add(new Data.Tile("历史记录", "同步日志", "☆共100条", UI.NewSolidColorBrush("#FFE2AA10"), "Images/Doctor/DutyPatient.png"));
            listTile.Add(new Data.Tile("数据字典", "医嘱字典", "☆共条", new SolidColorBrush(Colors.Purple), "Images/Doctor/OfficePatient.png"));
            listTile.Add(new Data.Tile("数据字典", "药品字典", "☆共条", new SolidColorBrush(Colors.SlateBlue), "Images/Doctor/DutyPatient.png"));
            listTile.Add(new Data.Tile("数据字典", "物价字典", "☆共条", new SolidColorBrush(Colors.DarkGreen), "Images/Doctor/HistoryPatient.png"));
            
            var groupData = from gd in listTile group gd by gd.TileType;
            //var groupData = listTile.GroupBy<Data.Tile, string>(new Func<Data.Tile, string>(GroupAndOrderByDataType));
            cvsGroupData.Source = groupData;

            labDoctorName.Text = CJia.iSmartMedical.iCommon.DoctorName;
            labOfficeName.Text = CJia.iSmartMedical.iCommon.LoginUser.DeptName;
            this.gridMain.IsEnabled = false;
            
            OnLoadData(null, null);
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

        public void ExeLoadDataComplet()
        {
            this.gridMain.IsEnabled = true;
            this.cvSync.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //加载完成后查询Tile相关数据；
            OnQueryTileData(null, null);
            iDB.IsDataInitComplete = true;
        }


        public void ExeShowSyncProgress(int now, int max, string Hint)
        {
            this.barSync.Value = now;
            this.barSync.Maximum = max;
            this.txtSyncHint.Text = Hint;
            this.cvSync.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }


        public void ExeShowPatientCount(int[] CountData)
        {
            listTile[0].Description1 = String.Format("☆共{0}个", CountData[0]);
            listTile[1].Description1 = String.Format("☆共{0}个", CountData[1]);
            listTile[2].Description1 = String.Format("☆共{0}个", CountData[2]);
            listTile[3].Description1 = String.Format("☆共{0}个", CountData[3]);
            listTile[6].Description1 = String.Format("☆共{0}个", CountData[4]);
            listTile[8].Description1 = String.Format("☆共{0}个", CountData[5]);
            listTile[9].Description1 = String.Format("☆共{0}个", CountData[6]);
        }

        public event EventHandler OnQueryTileData;
    }
}
