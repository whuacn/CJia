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

namespace CJia.iSmartMedical.Win8
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DeviceRegister : BasePage, Views.IDeviceRegister
    {
        public DeviceRegister()
        {
            this.InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DeviceRegisterPresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OnQueryDeviceInfo(null, null);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        public event EventHandler<Views.DeviceRegisterEventArgs> OnSaveDeviceInfo;

        public event EventHandler OnQueryDeviceInfo;

        List<Data.iDept> DeptDataList;
        public void ExeShowDeptList(List<Data.iDept> DeptList)
        {
            this.listOffice.ItemsSource = DeptList.FindAll(dept => dept.DeptFlag == "1");
            DeptDataList = DeptList;
        }

        public void ExeShowDeviceInfo(Data.iDevice device, List<Data.iDeviceOffice> OfficeList)
        {
            if (device == null) return;
            this.txtDeviceName.Text = device.DeviceName;
            this.txtNotes.Text = device.Notes;
            if (OfficeList.Count > 0)
            {
                foreach (Data.iDeviceOffice ido in OfficeList)
                {
                    Data.iDept dept = DeptDataList.Find(dd => dd.DeptID == ido.OfficeID);
                    if (dept != null)
                        this.listOffice.SelectedItems.Add(dept);
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!IsRightInput()) return;
            Views.DeviceRegisterEventArgs drArg = new Views.DeviceRegisterEventArgs();
            drArg.DeviceName = txtDeviceName.Text.Trim();
            drArg.Notes = txtNotes.Text.Trim();
            drArg.Status = radNormal.IsChecked == true ? "正常" : "禁用";
            drArg.OfficeIDs = new List<string>();
            drArg.OfficeNames = new List<string>();
            foreach(object o in listOffice.SelectedItems)
            {
                Data.iDept dept = o as Data.iDept;
                drArg.OfficeIDs.Add(dept.DeptID);
                drArg.OfficeNames.Add(dept.DeptName);
            }
            OnSaveDeviceInfo(null, drArg);
        }

        bool IsRightInput()
        {
            if (String.IsNullOrEmpty(txtDeviceName.Text))
            {
                ShowMessage("请输入设备名称。");
                this.txtDeviceName.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                return false;
            }
            
            if (this.listOffice.SelectedItems.Count == 0)
            {
                ShowMessage("请选择所属科室。");
                return false;
            }
            return true;
        }

        public void ExeShowSaveResult(bool IsSaveSuccess)
        {
            if (IsSaveSuccess)
            {
                ShowMessage("设备登记成功，可正常使用。");
            }
            else
            {
                ShowMessage("设备登记失败。");
            }
        }
    }
}
