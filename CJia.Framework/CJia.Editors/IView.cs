using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.Editors
{
    /// <summary>
    /// View的接口基类
    /// </summary>
    public interface IView
    {
        event EventHandler Load;
        //event EventHandler Closed;
        //event CancelEventHandler Closing;
        void ShowMessage(string message);
    }
}
