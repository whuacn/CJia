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

namespace CJia.MobileMedicalDoctor.App.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MedicalRecordDetailPage : BasePage, Views.IMedicalRecordDetailPageView
    {
        public MedicalRecordDetailPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MedicalRecordDetailPagePresenter(this);
        }
        Views.IMedicalRecordDetailEventArgs mrdArg = new Views.IMedicalRecordDetailEventArgs();
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            object[] p = e.Parameter as object[];
            Data.PatientEmrDoc doc = p[0] as Data.PatientEmrDoc;
            List<Data.PatientEmrDoc> DocList = p[1] as List<Data.PatientEmrDoc>;
            var groupData = from d in DocList group d by d.DocTypeName;

            this.cvsMedicalRecord.Source = groupData;
            var DateList = cvsMedicalRecord.View.CollectionGroups;
            (this.mmSZoom.ZoomedOutView as ListViewBase).ItemsSource = DateList;

            this.gridDocList.SelectedItem = doc;
            mrdArg.InhosID = doc.InhosID;
            mrdArg.SectionNo = doc.SectionNo;
            OnQueryMedicalRecordDetail(null, mrdArg);
        }

        public event EventHandler<Views.IMedicalRecordDetailEventArgs> OnQueryMedicalRecordDetail;

        public void ExeShowMedicalRecordDetail(Data.PatientEmrDoc DocContent)
        {
            this.docViewer.NavigateToString(DocContent.DocContent);
        }

        private void gridDocList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridDocList.SelectedItem == null) return;
            Data.PatientEmrDoc doc = gridDocList.SelectedItem as Data.PatientEmrDoc;
            mrdArg.InhosID = doc.InhosID;
            mrdArg.SectionNo = doc.SectionNo;
            OnQueryMedicalRecordDetail(null, mrdArg);
        }
    }
}
