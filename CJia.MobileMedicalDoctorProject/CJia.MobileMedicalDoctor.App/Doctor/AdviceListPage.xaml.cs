using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AdviceListPage : BasePage, Views.IAdviceListPageView
    {
        public AdviceListPage()
        {
            this.InitializeComponent();
        }

        List<Data.PatientAdvices> CacheAdvices;
        protected override object CreatePresenter()
        {
            return new Presenters.AdviceListPagePresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data.Patient patient = MobileMedicalDoctor.iCommon.Patient;
            Views.AdviceEventArgs arg = new Views.AdviceEventArgs(patient.InhosID);
            arg.StandingFlag = "长期";
            OnQueryAdviceTypeList(null, arg);
            OnQueryPatientAdvices(null, arg);
        }

        public event EventHandler<Views.AdviceEventArgs> OnQueryPatientAdvices;

        public void ExeShowAdviceList(List<Data.PatientAdvices> AdviceList)
        {
            CacheAdvices = AdviceList;
            FilterAdvice();
        }

        void FilterAdvice()
        {
            if (CacheAdvices == null) return;

            bool isLongChecked = tsStandingFlag.IsOn;//radLongAdvice.IsChecked.Value;
            bool isTempChecked = !isLongChecked;
            Data.AdviceTypeGroup atg = listAdviceType.SelectedItem as Data.AdviceTypeGroup;
            bool isAllType = atg.AdviceType == "全部";
            string AdviceType = atg.AdviceType;

            List<Data.PatientAdvices> FilterResult = CacheAdvices.FindAll(pa => ((pa.StandingFlag == "临时" && isTempChecked) || pa.StandingFlag == "长期" && isLongChecked) && (isAllType || (pa.AdviceType == AdviceType)));
            listAdvices.ItemsSource = FilterResult;
        }

        public void ExeShowAdviceTypeList(List<Data.AdviceTypeGroup> AdviceTypeList)
        {
            listAdviceType.ItemsSource = AdviceTypeList;
            listAdviceType.SelectedIndex = 0;
        }

        private void listAdviceType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listAdviceType.SelectedItem == null) return;
            FilterAdvice();
        }

        private void AdviceStandingFlag_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FilterAdvice();
        }

        private void tsStandingFlag_Toggled(object sender, RoutedEventArgs e)
        {
            if (tsStandingFlag == null) return;
            Views.AdviceEventArgs arg = new Views.AdviceEventArgs(iCommon.Patient.InhosID);
            arg.StandingFlag = tsStandingFlag.IsOn ? "长期" : "临时";
            OnQueryAdviceTypeList(null, arg);
            FilterAdvice();
        }


        public event EventHandler<Views.AdviceEventArgs> OnQueryAdviceTypeList;
    }
}
