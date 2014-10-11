using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IUserManageView : CJia.Parking.Tools.IView
    {
             
        /// <summary>
        /// 绑定Grid用户
        /// </summary>
        /// <param name="dtUser"></param>
        void ExeBindGridUser(DataTable dtUser);

        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.UserArgs> OnInit;

        /// <summary>
        /// 保存用户事件
        /// </summary>
        event EventHandler<Views.UserArgs> OnUserSave;

        /// <summary>
        /// 删除用户事件
        /// </summary>
        event EventHandler<Views.UserArgs> OnUserDelete;

        /// <summary>
        /// 点击用户Grid勾选用户相应角色
        /// </summary>
        event EventHandler<Views.UserArgs> OnUserFocusedRowChanged;

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeCheckRole(DataTable dtRole);

        /// <summary>
        /// 设定用户权限勾选状态
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeSetRoleChecked(DataTable dtRole);

    }

    public class UserArgs : EventArgs
    {
        /// <summary>
        /// 角色流水号
        /// </summary>
        public long RoleId;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName;

        /// <summary>
        /// 修改时表中所存角色名（原角色名）
        /// </summary>
        public string OldRoleName;

        /// <summary>
        /// 用户流水号
        /// </summary>
        public long UserId;

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 修改时表中所存用户名（原用户名）
        /// </summary>
        public string OldUserName;
        
        /// <summary>
        /// 用户工号
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password;

        /// <summary>
        /// 所选角色
        /// </summary>
        public List<long> ListRoleId = new List<long>();

        /// <summary>
        /// 角色保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string RoleSaveStatus = "add";

        /// <summary>
        /// 用户保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string UserSaveStatus = "add";

        /// <summary>
        /// 根据userId搜索到的角色数据从Model层传到页面绑定
        /// </summary>
        public DataTable TableUserRole = null;
    }
}
