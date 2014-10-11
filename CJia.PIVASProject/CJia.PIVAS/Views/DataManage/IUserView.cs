using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 用户维护的接口层
    /// </summary>
    public interface IUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化载入数据
        /// </summary>
        event EventHandler<UserEventArgs> OnLoadData;

        /// <summary>
        /// 删除用户  把状态改为0
        /// </summary>
        event EventHandler<UserEventArgs> OnDeleteUser;

        /// <summary>
        /// gridcontrol的数据源绑定
        /// </summary>
        /// <param name="dt">要绑定的数据源</param>
        void ExeDataBind(DataTable dt);
    }

    /// <summary>
    /// 用户维护的参数类
    /// </summary>
    public class UserEventArgs : EventArgs
    {
        /// <summary>
        /// 修改人Id
        /// </summary>
        public long CreateBy;

        /// <summary>
        /// 要删除的用户Id
        /// </summary>
        public long UserId;
    }
}