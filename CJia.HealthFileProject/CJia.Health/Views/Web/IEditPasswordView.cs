using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IEditPasswordView:CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 保存密码事件
        /// </summary>
        event EventHandler<EditPasswordArgs> OnSave;
        void ExeIsSuccess(bool bol);
    }
    public class EditPasswordArgs : EventArgs
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword;
        public DataTable UserData;
    }
}
