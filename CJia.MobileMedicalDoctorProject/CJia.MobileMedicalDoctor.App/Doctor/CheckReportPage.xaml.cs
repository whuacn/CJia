using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class CheckReportPage : BasePage, Views.ICheckReportPageView
    {
        public CheckReportPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CheckReportPagePresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.OnQueryReportType(null, null);
            this.OnQueryCheckReportResult(null, new Views.CheckReportPageEventArgs(iCommon.Patient.InhosID));
        }

        public event EventHandler OnQueryReportType;

        public void ExeShowReportTypeList(List<Data.iCode> ReportTypeList)
        {
            this.listRep.ItemsSource = ReportTypeList;
        }

        private void listRep_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listRep.SelectedItem == null) return;
            Data.iCode ic = listRep.SelectedItem as Data.iCode;

            string url = String.Format(ic.Value, iCommon.Patient.IllcaseNo);
            this.repViewer.Navigate(new Uri(url));
        }

        List<Data.CheckResult> ResultListData;
        public event EventHandler<Views.CheckReportPageEventArgs> OnQueryCheckReportResult;

        public void ExeShowCheckReportResult(List<Data.CheckApply> ApplyList, List<Data.CheckResult> ResultList)
        {
            this.listApply.ItemsSource = ApplyList;
            //this.listResult.ItemsSource = ResultList;
            ResultListData = ResultList;
        }

        private void listApply_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listApply.SelectedItem == null) return;
            Data.CheckApply ca = listApply.SelectedItem as Data.CheckApply;
            this.listResult.ItemsSource = ResultListData.FindAll(r => r.ApplyNo == ca.ApplyNo);
        }
    }
}
