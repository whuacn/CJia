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
    public sealed partial class LisResultPage : BasePage,Views.ILisResultPageView
    {
        public LisResultPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.LisResultPagePresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OnQueryLisResult(null, new Views.LisResultEventArgs(iCommon.Patient.IllcaseNo));
        }

        public event EventHandler<Views.LisResultEventArgs> OnQueryLisResult;


        public void ExeShowLisResult(List<Data.LisResult> ResultList)
        {
            var groupData = from lis in ResultList group lis by lis.AdviceInfo;

            this.cvsLisResult.Source = groupData;
            var AdviceList = cvsLisResult.View.CollectionGroups;
            (this.mmSZoom.ZoomedOutView as ListViewBase).ItemsSource = AdviceList;
        }
    }
}
