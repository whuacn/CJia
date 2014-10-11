using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IAddUser : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.AddUserArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.AddUserArgs> OnSave;

        ///// <summary>
        ///// 绑定界面树状结构
        ///// </summary>
        ///// <param name="dtTree"></param>
        //void ExeBindTree(DataTable dtTree);

        /// <summary>
        /// 绑定角色选择框
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeCheckBoxList(DataTable dtRole);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        void ExeMessageBox(string message);
    }

    public class AddUserArgs : EventArgs
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
        /// 用户类型（0代表最高级别超级管理员（不能删除）；1代表超级管理员；2代表组织管理员；3代表普通用户）
        /// </summary>
        public string UserType;

        /// <summary>
        /// 所选角色组
        /// </summary>
        public List<string> RoleArr = new List<string>();

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;
    }
}
