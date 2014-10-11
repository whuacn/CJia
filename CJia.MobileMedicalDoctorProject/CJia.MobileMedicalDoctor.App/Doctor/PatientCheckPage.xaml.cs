using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
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
    public sealed partial class PatientCheckPage : BasePage,Views.IPatientCheckPageView
    {
        object CurrentTile;
        public PatientCheckPage()
        {
            this.InitializeComponent();
            InitFunctions();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PatientCheckPagePresenter(this);
        }

        Dictionary<string, Data.iFunction> dicFunction = new Dictionary<string, Data.iFunction>();
        string[] aryFunction;
        void InitFunctions()
        {
            dicFunction.Clear();
            string inhosID = iCommon.Patient.InhosID;
            dicFunction.Add("住院医嘱", new Data.iFunction("住院医嘱", 0, typeof(Doctor.AdviceListPage), FrmMain0, Colors.AliceBlue, inhosID));
            dicFunction.Add("病历文书", new Data.iFunction("病历文书", 1, typeof(Doctor.MedicalRecordPage), FrmMain1, Colors.AliceBlue, inhosID));
            dicFunction.Add("检查报告", new Data.iFunction("检查报告", 2, typeof(Doctor.CheckReportPage), FrmMain2, Colors.AliceBlue, inhosID));
            dicFunction.Add("化验报告", new Data.iFunction("化验报告", 3, typeof(Doctor.LisResultPage), FrmMain3, Colors.AliceBlue, inhosID));
            dicFunction.Add("查房日志", new Data.iFunction("查房日志", 4, typeof(Doctor.CheckLogDetailPage), FrmMain4, Colors.AliceBlue, inhosID));
            dicFunction.Add("诊疗相册", new Data.iFunction("诊疗相册", 5, typeof(Doctor.CheckPhotoDetailPage), FrmMain5, Colors.AliceBlue, inhosID));
            dicFunction.Add("新建医嘱", new Data.iFunction("新建医嘱", 6, typeof(Doctor.AdviceInputPage), FrmMain6, Colors.AliceBlue, inhosID));
            aryFunction = dicFunction.Keys.ToArray<string>();
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentTile = e.Parameter;
            ShowUserInfo();
            ShowPatientInfo();
            ShowPage("住院医嘱");
        }

        private void ShowUserInfo()
        {
            labDoctorName.Text = CJia.MobileMedicalDoctor.iCommon.DoctorName;
            labOfficeName.Text = CJia.MobileMedicalDoctor.iCommon.LoginUser.DeptName;
        }

        private void ShowPatientInfo()
        {
            Data.Patient patient = MobileMedicalDoctor.iCommon.Patient;
            this.labPatientName.Text = patient.PatientName;
            this.labInhosInfo.Text = "（" + patient.BedName + "）" + patient.GradeName;
            this.gridPatientList.ItemsSource = MobileMedicalDoctor.iCommon.PatientList;
            this.gridPatientList.SelectedItem = patient;
            OnChangePatient(null,new Views.PatientCheckEventArgs(patient.InhosID));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BasePage.OnClose();
            this.Frame.Navigate(typeof(Doctor.PatientsPage), CurrentTile);
        }

        private void gridPatientList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridPatientList.SelectedItem == null) return;
            ChangePatient();
        }

        private void ChangePatient()
        {
            Data.Patient p = gridPatientList.SelectedItem as Data.Patient;
            MobileMedicalDoctor.iCommon.Patient = p;
            ShowPatientInfo();
            string functionName = aryFunction[CurrentIndex];
            ShowPage(functionName);
        }

        private void Function_Changed(object sender, TappedRoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            ShowPage(tb.Text);
        }
        int CurrentIndex = 0;
        void ShowPage(string FunctionName)
        {
            foreach (Data.iFunction iFunc in dicFunction.Values)
            {
                iFunc.ParentFrame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            Data.iFunction func = dicFunction[FunctionName];
            if (func.ParentFrame.Content == null || func.InhosID != iCommon.Patient.InhosID)
            {
                func.ParentFrame.Navigate(func.TargetPage);
                func.InhosID = iCommon.Patient.InhosID;
                func.BottomAppBar = (func.ParentFrame.Content as Page).BottomAppBar;
            }
            func.ParentFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            Grid.SetColumn(labHint, func.Index);
            CurrentIndex = func.Index;
            this.BottomAppBar = func.BottomAppBar;// (func.ParentFrame.Content as Page).BottomAppBar;
        }

        private void imgNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CurrentIndex == dicFunction.Count - 1)
                CurrentIndex = -1; ;
            CurrentIndex++;
            ShowPage(aryFunction[CurrentIndex]);
        }

        private void imgPrev_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string functionName = aryFunction[CurrentIndex];
            Data.iFunction func = dicFunction[functionName];
            string pageName = func.ParentFrame.Content.ToString();
            if (pageName == func.TargetPage.FullName)
            {
                if (CurrentIndex == 0)
                    CurrentIndex = dicFunction.Count - 1;
                else
                    CurrentIndex--;
                functionName = aryFunction[CurrentIndex];
                ShowPage(functionName);
            }
            else
            {
                func.ParentFrame.GoBack();
            }
        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {
            Frame frm = sender as Frame;
            this.BottomAppBar = (frm.Content as Page).BottomAppBar;
        }

        public event EventHandler<Views.PatientCheckEventArgs> OnChangePatient;
    }
}
