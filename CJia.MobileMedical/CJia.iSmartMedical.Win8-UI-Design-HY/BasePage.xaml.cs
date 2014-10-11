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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.iSmartMedical.Win8
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public partial class BasePage : Page
    {
        private object _presenter;

        public BasePage()
        {
            this.InitializeComponent();
            this._presenter = CreatePresenter();
        }

        protected virtual object CreatePresenter()
        {
            return null;
        }
        
        /// <summary>
        /// 关闭前触发事件
        /// </summary>
        public static event EventHandler BeforeClose;
        /// <summary>
        /// 关闭
        /// </summary>
        public static void OnClose()
        {
            if (BeforeClose != null)
            {
                BeforeClose(null, null);
            }
        }

        public async void ShowMessage(string Text)
        {
            MessageDialog msg = new MessageDialog(Text);
            await msg.ShowAsync();
        }

        public async void ShowConfirm(string TextConfirm, UICommand[] Cmds)
        {
            MessageDialog msgDialog = new MessageDialog(TextConfirm);
            foreach (UICommand cmd in Cmds)
            {
                msgDialog.Commands.Add(cmd);
            }
            msgDialog.DefaultCommandIndex = 0;
            await msgDialog.ShowAsync();
        }
    }
}
