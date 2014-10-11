using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.HISOLAP.Tools
{
    /// <summary>
    /// View的接口基类
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 获取系统时间
        /// </summary>
        DateTime Sysdate { get; }
        /// <summary>
        /// 页面Show之后执行
        /// </summary>
        event EventHandler Load;

        //event EventHandler Closed;
        //event CancelEventHandler Closing;

        /// <summary>
        /// 界面抛出提示信息
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);

        /// <summary>
        /// 界面抛出警告信息
        /// </summary>
        /// <param name="message"></param>
        void ShowWarning(string message);

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        void CloseWindow();
        /// <summary>
        /// 以窗口形式显示
        /// </summary>
        void ShowAsWindow(string Caption);
        ///// <summary>
        ///// 以窗口形式显示
        ///// </summary>
        //void ShowAsWindow(string Caption,System.Windows.Forms.UserControl UControl);
    }
}
