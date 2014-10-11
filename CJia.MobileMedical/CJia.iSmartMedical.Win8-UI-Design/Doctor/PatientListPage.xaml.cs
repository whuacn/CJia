using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;
using System.Collections.ObjectModel;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.iSmartMedical.Win8.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PatientsPage : BasePage, Views.IMyPatientsPageView
    {
        Data.Tile CurrentTile;
        public PatientsPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MyPatientsPagePresenter(this);
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                labDoctorName.Text = CJia.iSmartMedical.iCommon.DoctorName;
                labOfficeName.Text = CJia.iSmartMedical.iCommon.LoginUser.DeptName;
            }
            if (e.Parameter != null)
            {
                Data.Tile t = e.Parameter as Data.Tile;
                CurrentTile = t;
                this.labTitle.Text = t.Title;
                this.PatientItemBackground.Color = t.Background.Color;
                switch (t.Title)
                {
                    case "我的病人": OnShowMyPatientList(null, null); break;
                    case "科室病人": OnShowOfficePatientList(null, null); break;
                    case "值班病人": OnShowDutyPatientList(null, null); break;
                    case "近期查房": OnShowTodayPatientList(null, null); break;
                    case "出院患者": OnShowHistoryPatientList(null, null); break;
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        private void gridPatientList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.gridPatientList.SelectedItem == null) return;
            Data.Patient patient = this.gridPatientList.SelectedItem as Data.Patient;
            iSmartMedical.iCommon.Patient = patient;
            Frame.Navigate(typeof(Doctor.PatientCheckPage), CurrentTile);
        }

        //系统注销
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void gridIllfields_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridIllfields.SelectedItem == null) return;
            string IllfieldName = gridIllfields.SelectedItem.ToString();
            var FilterData = CurrentPatientList.FindAll(p => p.IllfieldName == IllfieldName || IllfieldName == "全部病区");
            BindPatientList(FilterData);
        }

        #region 接口实现
        public event EventHandler OnShowOfficePatientList;
        public event EventHandler OnShowDutyPatientList;
        public event EventHandler OnShowHistoryPatientList;
        public event EventHandler OnShowMyPatientList;
        public event EventHandler OnShowTodayPatientList;

        List<Data.Patient> CurrentPatientList;
        ObservableCollection<string> ListIllfield = new ObservableCollection<string>();
        public void ExeShowPatientList(List<Data.Patient> PatientList)
        {
            ListIllfield.Clear();
            ListIllfield.Add("全部病区");
            foreach (Data.Patient p in PatientList)
            {
                if (!ListIllfield.Contains(p.IllfieldName))
                {
                    ListIllfield.Add(p.IllfieldName);
                }
            }

            this.gridIllfields.ItemsSource = ListIllfield;
            this.gridIllfields.SelectedIndex = 0;

            BindPatientList(PatientList);

            iSmartMedical.iCommon.PatientList = PatientList.OrderBy<Data.Patient, string>(new Func<Data.Patient, string>(OrderByBed)); ;
            CurrentPatientList = PatientList;
            if (CurrentTile.Title == "值班病人")
            {
                this.btnImportPatient.Visibility = Windows.UI.Xaml.Visibility.Visible;
                if (PatientList.Count == 0)
                    BottomAppBar.IsOpen = true;
            }
            else
            {
                this.btnImportPatient.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void BindPatientList(List<Data.Patient> PatientList)
        {
            //var groupData = from p in PatientList group p by p.RoomName;
            //var orderList = PatientList.OrderBy<Data.Patient, string>(new Func<Data.Patient, string>(GroupAndOrderByRoom));
            var groupRoom = PatientList.GroupBy<Data.Patient, string>(new Func<Data.Patient, string>(GroupAndOrderByRoom));
            cvsPatient.Source = groupRoom;
            var RoomList = cvsPatient.View.CollectionGroups;
            (patientSZoom.ZoomedOutView as ListViewBase).ItemsSource = RoomList;
        }

        private string OrderByBed(Data.Patient p)
        {
            return p.BedName;
        }

        private string GroupByIllfield(Data.Patient p)
        {
            return p.RoomName;
        }

        private string GroupAndOrderByRoom(Data.Patient p)
        {
            return p.RoomName;
        }
        #endregion

        private void btnImportPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Doctor.DutyPatientListPage), CurrentTile);
        }
    }
}
