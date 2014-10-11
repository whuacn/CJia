using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.HIS
{
    /// <summary>
    /// View的接口基类
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 页面Show之后执行
        /// </summary>
        event EventHandler Load;

        //event EventHandler Closed;
        //event CancelEventHandler Closing;
    }
}
