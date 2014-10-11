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
    public sealed partial class DutyPatientListPage : BasePage, Views.IDutyPatientListPageView
    {
        public DutyPatientListPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DutyPatientListPagePresenter(this);
        }
        Data.Tile CurrentTile;
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
                CurrentTile = e.Parameter as Data.Tile;
                this.labTitle.Text = "导入" + CurrentTile.Title;
                if (CurrentTile.Title == "值班病人")
                    OnQueryDutyIllfield(null, null);
                else if (CurrentTile.Title == "出院患者")
                {
                    OnQueryLeavehosPatient(null, null);
                }
            }

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

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
            Data.DoctorIllfield di = gridIllfields.SelectedItem as Data.DoctorIllfield;
            OnShowDutyPatientList(null, new Views.DutyPatientListEventArgs(di.IllfeildID));
        }

        public void ExeShowDutyPatientList(List<Data.Patient> PatientList)
        {
            this.listDutyPatient.ItemsSource = PatientList;
        }

        public void ExeShowDutyIllfieldList(List<Data.DoctorIllfield> IllfieldList)
        {
            this.gridIllfields.ItemsSource = IllfieldList;
        }

        public event EventHandler<Views.DutyPatientListEventArgs> OnShowDutyPatientList;

        public event EventHandler OnQueryDutyIllfield;

        public event EventHandler<Views.DutyPatientListEventArgs> OnAddDutyPatientList;

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            if (listDutyPatient.SelectedItems.Count == 0) return;
            this.BottomAppBar.IsOpen = false;
            List<Data.Patient> patientList = new List<Data.Patient>();
            foreach (object op in listDutyPatient.SelectedItems)
            {
                patientList.Add(op as Data.Patient);
            }
            Views.DutyPatientListEventArgs dtArgs = new Views.DutyPatientListEventArgs("");
            dtArgs.SelectedPatient = patientList;
            OnAddDutyPatientList(null, dtArgs);
        }


        public void ExeGoBack()
        {
            this.Frame.Navigate(typeof(Doctor.PatientsPage), CurrentTile);
        }

        private void listDutyPatient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.BottomAppBar.IsOpen = true;
        }

        public void ExeShowSyncProgress(int now, int max, string Hint)
        {
            this.barSync.Value = now;
            this.barSync.Maximum = max;
            this.txtSyncHint.Text = Hint;
            this.cvSync.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }


        public event EventHandler OnQueryLeavehosPatient;
    }
}
