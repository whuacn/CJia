using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IUserSelectView:CJia.Editors.IView
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        string UserNO { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        int UserID { get; }
        /// <summary>
        /// 某个用户信息
        /// </summary>
        DataTable UserData { get; set; }
        /// <summary>
        /// 用户编号查询事件
        /// </summary>
        event EventHandler OnSelectByNO;
        /// <summary>
        /// 用户姓名查询事件
        /// </summary>
        event EventHandler OnSelectByName;
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler OnSelectBtn;
        /// <summary>
        /// 重置密码
        /// </summary>
        event EventHandler OnResetPswdBtn;
        /// <summary>
        /// 编辑用户
        /// </summary>
        event EventHandler OnEditBtn;
        /// <summary>
        /// 删除用户
        /// </summary>
        event EventHandler OnDelete;
        /// <summary>
        /// 绑定用户
        /// </summary>
        /// <param name="data"></param>
        void ExeBindUser(DataTable data);
        /// <summary>
        /// 弹出用户信息编辑页
        /// </summary>
        /// <param name="data"></param>
        void ExeShowUserHandle(DataTable data);
    }
}
