using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using System.Reflection;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.FileProperties;
using CJia.MobileMedicalDoctor.App.Common;
using System.Collections.ObjectModel;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.MobileMedicalDoctor.App.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CheckPhotoDetailPage : BasePage, Views.ICheckPhotoDetailPageView
    {
        public CheckPhotoDetailPage()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CheckPhotoDetailPagePresenter(this);
        }

        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Views.CheckPhotoDetailEventArgs arg = new Views.CheckPhotoDetailEventArgs();
            arg.InhosID = iCommon.Patient.InhosID;
            OnQueryCheckPhoto(null, arg);
        }

        private void gridPhotoList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridPhotoList.SelectedItem == null) return;
            Data.DoctorCheckLog photo = gridPhotoList.SelectedItem as Data.DoctorCheckLog;
            ShowPhoto(photo);
        }

        private async void ShowPhoto(Data.DoctorCheckLog photo)
        {
            var bitmapImage = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                DataWriter datawriter = new DataWriter(stream.GetOutputStreamAt(0));
                datawriter.WriteBytes(photo.Photo);
                await datawriter.StoreAsync();
                bitmapImage.SetSource(stream);
            }
            imgCheck.Source = bitmapImage;
        }

        public event EventHandler<Views.CheckPhotoDetailEventArgs> OnQueryCheckPhoto;
        List<Data.DoctorCheckLog> PatientCheckPhoto;
        public void ExeShowCheckPhotoList(List<Data.DoctorCheckLog> PhotoList)
        {
            var groupData = from doc in PhotoList group doc by doc.CheckDate;

            this.cvsCheckPhoto.Source = groupData;
            var DateList = cvsCheckPhoto.View.CollectionGroups;
            (this.mmSZoom.ZoomedOutView as ListViewBase).ItemsSource = DateList;
            PatientCheckPhoto = PhotoList;

            if (gridPhotoList.SelectedItem != null)
            {
                ShowPhoto(this.gridPhotoList.SelectedItem as Data.DoctorCheckLog);
            }
        }

        public event EventHandler<Views.CheckPhotoDetailEventArgs> OnSaveCheckPhoto;

        public void ExeShowCheckPhoto(Data.DoctorCheckLog CheckPhoto)
        {
            PatientCheckPhoto.Insert(0, CheckPhoto);
            ExeShowCheckPhotoList(PatientCheckPhoto);
        }

        public event EventHandler<Views.CheckPhotoDetailEventArgs> OnDeleteCheckPhoto;

        public void ExeDeleteCheckPhoto(Data.DoctorCheckLog CheckPhoto)
        {
            PatientCheckPhoto.Remove(CheckPhoto);
            ExeShowCheckPhotoList(PatientCheckPhoto);
        }

        private void btnDeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (this.gridPhotoList.SelectedItem == null) return;
            Data.DoctorCheckLog photo = gridPhotoList.SelectedItem as Data.DoctorCheckLog;
            Views.CheckPhotoDetailEventArgs arg = new Views.CheckPhotoDetailEventArgs();
            arg.InhosID = iCommon.Patient.InhosID;
            arg.CheckPhoto = photo;
            OnDeleteCheckPhoto(null, arg);
        }

        #region 拍照
        private void btnCamara_Click(object sender, RoutedEventArgs e)
        {
            CapturePhoto();
        }
        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            CapturePhoto();
        }

        async void CapturePhoto()
        {
            CameraCaptureUI camera = new CameraCaptureUI();
            //camera.PhotoSettings.CroppedAspectRatio = new Size(16, 9);//获得图片的宽高比例
            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;// 设置照片格式  
            camera.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;// 设置分辨率
            StorageFile file = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (file != null)
            {
                SaveCheckPhoto(file);
            }
        }

        async void SaveCheckPhoto(StorageFile ImageFile)
        {
            IBuffer fileBuffer = await FileIO.ReadBufferAsync(ImageFile);
            byte[] btsImage = WindowsRuntimeBufferExtensions.ToArray(fileBuffer, 0, (int)fileBuffer.Length);
            Data.DoctorCheckLog photo = NewPhoto();
            photo.Photo = btsImage;
            Views.CheckPhotoDetailEventArgs cva = new Views.CheckPhotoDetailEventArgs();
            cva.InhosID = iCommon.Patient.InhosID;
            cva.CheckPhoto = photo;
            OnSaveCheckPhoto(null, cva);
        }

        Data.DoctorCheckLog NewPhoto()
        {
            Data.DoctorCheckLog nLog = new Data.DoctorCheckLog();
            nLog.DCLID = Guid.NewGuid().ToString();
            nLog.DeviceID = iCommon.DeviceID;
            nLog.DoctorID = iCommon.DoctorID;
            nLog.DoctorName = iCommon.DoctorName;
            nLog.InhosID = iCommon.Patient.InhosID;
            nLog.LogType = "照片";
            nLog.CheckDate = iCommon.Today;
            nLog.CheckTime = iCommon.NowTime;
            nLog.LastSaveDate = iCommon.DateNow;
            return nLog;
        }
        #endregion
    }
}
