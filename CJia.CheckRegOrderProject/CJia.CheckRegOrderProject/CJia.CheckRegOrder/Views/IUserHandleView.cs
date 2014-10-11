using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IUserHandleView:CJia.Editors.IView
    {
        /// <summary>
        /// 用户id
        /// </summary>
        int UserID { get; set; }
        /// <summary>
        /// 初始时 记录用户工号
        /// </summary>
        string OldUserNO { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        string UserNO { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        bool IsAdmin { get; set; }
        /// <summary>
        /// 保存编辑
        /// </summary>
        event EventHandler OnSaveBtn;
        /// <summary>
        /// 增加用户
        /// </summary>
        event EventHandler OnAddUser;
        /// <summary>
        /// 绑定用户信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindUser(DataTable data);
        /// <summary>
        /// 关闭窗体
        /// </summary>
        void CloseForm();
        /// <summary>
        /// 工号输入框获得焦点
        /// </summary>
        void TxtUserNOFocus();
    }
}
