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
    public sealed partial class MedicalRecordPage : BasePage, Views.IMedicalRecordPageView
    {
        ViewModelData vData = new ViewModelData();
        public MedicalRecordPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MedicalRecordPagePresenter(this);
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OnQueryMedicalRecord(null, new Views.MedicalRecordEventArgs(iCommon.Patient.InhosID));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        public event EventHandler<Views.MedicalRecordEventArgs> OnQueryMedicalRecord;

        List<Data.PatientEmrDoc> PatientDocList;
        public void ExeShowMedicalRecordList(List<Data.PatientEmrDoc> DocList)
        {
            //this.vData.Sourcedata = new ObservableCollection<DataGroupModel>();
            //bool hasExists = false;
            //foreach (Data.PatientEmrDoc doc in DocList)
            //{
            //    hasExists = false;
            //    foreach (DataGroupModel dgm in this.vData.Sourcedata)
            //    {
            //        if (dgm.GroupTitle == doc.DocTypeName)
            //        {
            //            dgm.ItemContent.Add(doc);
            //            hasExists = true;
            //            break;
            //        }
            //    }
            //    if (!hasExists)
            //    {
            //        DataGroupModel dm = new DataGroupModel(doc.DocTypeName, doc);
            //        this.vData.Sourcedata.Add(dm);
            //    }
            //}
            var groupData = from doc in DocList group doc by doc.DocTypeName;
            this.cvsMedicalRecord.Source = groupData;
            var DateList = cvsMedicalRecord.View.CollectionGroups;
            (this.mmSZoom.ZoomedOutView as ListViewBase).ItemsSource = DateList;
            PatientDocList = DocList;
        }

        private void gridMedicalRecord_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridMedicalRecord.SelectedItem == null) return;
            Data.PatientEmrDoc doc = gridMedicalRecord.SelectedItem as Data.PatientEmrDoc;
            this.Frame.Navigate(typeof(MedicalRecordDetailPage), new object[] { doc, PatientDocList });
        }
    }

    public class DataGroupModel
    {
        public DataGroupModel(string groupTitle, Data.PatientEmrDoc doc)
        {
            GroupTitle = groupTitle;
            ItemContent = new ObservableCollection<Data.PatientEmrDoc>();
            ItemContent.Add(doc);
        }
        public string GroupTitle { get; set; }
        public ObservableCollection<Data.PatientEmrDoc> ItemContent { get; set; }
    }

    public class ViewModelData
    {
        public ViewModelData()
        {

        }
        private ObservableCollection<DataGroupModel> _Sourcedata;

        public ObservableCollection<DataGroupModel> Sourcedata
        {
            get { return _Sourcedata; }
            set { _Sourcedata = value; }
        }
    }
}
