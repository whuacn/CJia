using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IAddSupervise : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.AddSuperviseArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.AddSuperviseArgs> OnSave;

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        void ExeBindTree(DataTable dtTree);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        void ExeMessageBox(string message);
    }

    public class AddSuperviseArgs : EventArgs
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 所属组织ID
        /// </summary>
        public string OrganId;

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;

        /// <summary>
        /// 所选功能节点组
        /// </summary>
        public List<string> ListFunction = new List<string>();

        /// <summary>
        /// 是否勾选是否为超级管理员
        /// </summary>
        public bool IsCheckSupper = false;

        /// <summary>
        /// 用户类型（0代表超级管理员；1代表组织管理员；2代表普通用户）
        /// </summary>
        public string UserType;

        /// <summary>
        /// 角色类型（0代表超级管理员所拥有角色；1代表超级管理员（为组织管理员）所建角色；2代表组织管理员（为普通用户）所建角色）
        /// </summary>
        public string RoleType;
    }
}
