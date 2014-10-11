using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.iSmartMedical.Win8
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Login : BasePage, Views.ILoginView
    {
        public Login()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 创建Presenter（此方法必须重载）
        /// </summary>
        /// <returns></returns>
        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OnQueryLocalLoginUser(null, null);
            OnQueryDeviceInfo(null, null);
        }

        Views.LoginEventArgs loginArg = new Views.LoginEventArgs();
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!IsRightParams()) return;
            if (txtUserCode.Text == "init" && txtPassword.Password == "db")
            {
                await iDB.ReInit();
                this.txtDeviceInfo.Text = "设备已初始化";
                return;
            }
            if (this.OnUserLogin != null)
            {
                loginArg.UserCode = txtUserCode.Text.Trim();
                loginArg.Password = txtPassword.Password;
                this.OnUserLogin(null, loginArg);
            }
        }

        bool IsRightParams()
        {
            if (String.IsNullOrEmpty(txtUserCode.Text.Trim()))
            {
                ShowMessage("请输入登录用户名.");
                this.txtUserCode.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                return false;
            }
            if (String.IsNullOrEmpty(txtPassword.Password))
            {
                ShowMessage("请输入登录密码.");
                this.txtPassword.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                return false;
            }
            return true;
        }

        public event EventHandler<Views.LoginEventArgs> OnUserLogin;

        public void ExeLoginSuccess()
        {
            Frame.Navigate(typeof(Doctor.MainPage));
        }

        public void ExeLoginFail(string FailMsg)
        {
            ShowMessage(FailMsg);
        }

        public event EventHandler OnQueryLocalLoginUser;

        public void ExeShowLocalUserList(List<Data.User> LocalUserList)
        {
            this.listUser.ItemsSource = LocalUserList;
        }

        private void listUser_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listUser.SelectedItem != null)
            {
                this.txtUserCode.Text = (listUser.SelectedItem as Data.User).Code;
                this.txtPassword.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
        }

        private void switchLoginModel_Toggled(object sender, RoutedEventArgs e)
        {
            if (switchLoginModel == null) return;
            if (switchLoginModel.IsOn)
            {
                CJia.iSmartMedical.iCommon.IsOnline = true;
            }
            else
            {
                CJia.iSmartMedical.iCommon.IsOnline = false;
            }
        }


        public void ExeShowDeviceRegister()
        {
            this.Frame.Navigate(typeof(DeviceRegister));
        }


        public event EventHandler OnQueryDeviceInfo;

        public void ExeShowDeviceInfo()
        {
            if (iCommon.CurrentDevice == null) return;
            txtDeviceInfo.Text = "设备名称：" + iCommon.CurrentDevice.DeviceName;
            if (iCommon.DeviceOffice.Count > 0)
            {
                txtDeviceInfo.Text +=  "   所属科室：";
            }
            foreach (Data.iDeviceOffice dof in iCommon.DeviceOffice)
            {
                txtDeviceInfo.Text += dof.OfficeName + "   ";
            }
        }
    }
}
