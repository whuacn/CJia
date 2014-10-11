using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 添加用户的接口层
    /// </summary>
    public interface IAddUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 工号输入框失去焦点
        /// </summary>
        event EventHandler<addUsereventArgs> OnLeave;

        /// <summary>
        /// 添加用户
        /// </summary>
        event EventHandler<addUsereventArgs> OnaddUser;

        /// <summary>
        /// 记录工号是否已经存在
        /// </summary>
        void ExeGetFocus();
    }

    /// <summary>
    /// 添加用户的参数类
    /// </summary>
    public class addUsereventArgs : EventArgs
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 要添加的用户姓名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 要添加的用户密码
        /// </summary>
        public string Pwd;

        /// <summary>
        /// 当前登录用户的Id
        /// </summary>
        public long UserId;

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName;
    }
}