//***************************************************
// 文件名（File Name）:      ICheckAdviceView.cs（审方View层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 审方View层
    /// </summary>
    public interface ILoginScanningView : Tools.IView
    {
        /// <summary>
        /// 登录
        /// </summary>
        event EventHandler<LoginScanningEventArgs> OnLogin;

        /// <summary>
        /// 返回登录结果
        /// </summary>
        void ExeLogin(bool succeed,string message, DataTable result);
    }
    /// <summary>
    /// 参数定义
    /// </summary>
    public class LoginScanningEventArgs : EventArgs
    {
        public string userId;

        public string password;

        public string no;

    }
}
