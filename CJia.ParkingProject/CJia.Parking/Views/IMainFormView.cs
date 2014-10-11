using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IMainFormView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.MainFormArgs> OnInit;

        /// <summary>
        /// 判断绑定登录用户权限
        /// </summary>
        /// <param name="dtLoginUserRoles"></param>
        void ExeLoginUserRoles(DataTable dtLoginUserRoles);
    }

    public class MainFormArgs : EventArgs
    {
        public long UserID = (long)User.UserData.Rows[0]["USER_ID"];
    }
}
