using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 修改用户信息接口层
    /// </summary>
    public interface IEditUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 修改个人信息
        /// </summary>
        event EventHandler<EditUsereventArgs> OnUpdateUser;

        /// <summary>
        /// 确认修改密码时 输入的旧密码是否正确
        /// </summary>
        event EventHandler<EditUsereventArgs> OnCheckPwd;

        /// <summary>
        /// 把值传回UI层
        /// </summary>
        /// <param name="isPwdOk"></param>
        void ExeIsPwdOk(bool isPwdOk);
    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class EditUsereventArgs:EventArgs
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPwd;

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPwd;

        /// <summary>
        /// 当期那登录用户iD
        /// </summary>
        public long UserId;
    }
}