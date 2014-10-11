using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IChangePassword : CJia.HealthInspection.Tools.IPage
    {
         /// <summary>
        /// 修改密码事件
        /// </summary>
        event EventHandler<ChangePasswordArgs> OnSave;
        void ExeIsSuccess(bool bol);
    }
    public class ChangePasswordArgs : EventArgs
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword;
        public DataTable UserData;
    }
}
