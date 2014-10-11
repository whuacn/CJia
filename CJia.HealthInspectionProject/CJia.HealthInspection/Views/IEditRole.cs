using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditRole : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditRoleArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditRoleArgs> OnSave;

        /// <summary>
        /// 绑定控件值
        /// </summary>
        /// <param name="roleName">根据角色ID所查出的角色名称</param>
        void ExeBindControl(string roleName);

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree">所有权限（即功能）</param>
        /// <param name="dtFun">角色所拥有权限</param>
        void ExeBindTree(DataTable dtTree, DataTable dtFun);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditRoleArgs : EventArgs
    {
        /// <summary>
        /// 所编辑角色ID
        /// </summary>
        public string RoleId;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName;

        /// <summary>
        /// 所选功能权限
        /// </summary>
        public List<string> ListFunction = new List<string>();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;
    }
}
