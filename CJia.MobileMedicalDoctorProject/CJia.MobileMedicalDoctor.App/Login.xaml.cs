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

namespace CJia.MobileMedicalDoctor.App
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
            if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Back)
            {
                //To do:清空用户名密码；
                if (OnQueryLocalLoginUser != null)
                {
                    OnQueryLocalLoginUser(null, null);
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.OnUserLogin != null)
            {
                this.OnUserLogin(null, null);
            }
        }

        public event EventHandler OnUserLogin;

        public string UserCode
        {
            get { return this.txtUserCode.Text; }
        }

        public string Password
        {
            get { return this.txtPassword.Password; }
        }

        public void ToMainPage()
        {
            
            Frame.Navigate(typeof(Doctor.MainPage));
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

        //private void switchLoginModel_Toggled(object sender, RoutedEventArgs e)
        //{
        //    if (switchLoginModel == null) return;
        //    if (switchLoginModel.IsOn)
        //    {
        //        CJia.MobileMedicalDoctor.iCommon.IsOnline = true;
        //    }
        //    else
        //    {
        //        CJia.MobileMedicalDoctor.iCommon.IsOnline = false;
        //    }
        //}
    }
}
