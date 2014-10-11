using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IRoleManageView:CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnInit;

        /// <summary>
        /// 添加事件
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnAdd;

        /// <summary>
        /// 更新事件
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnUpdate;

        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnDelete;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        event EventHandler<Views.RoleManageArgs> OnSearch;

        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtGridRole"></param>
        void ExeBindGridRole(DataTable dtGridRole);

        /// <summary>
        /// 绑定界面功能角色选择框
        /// </summary>
        /// <param name="dtUserRole"></param>
        void ExeBindRoleFunc(DataTable dtUserRole);

        /// <summary>
        /// 设定用户权限选择状态
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeSetRoleChecked(DataTable dtRole);
    }

    public class RoleManageArgs : EventArgs
    {
        /// <summary>
        /// 功能角色ID
        /// </summary>
        public long RoleFunctionId;
        /// <summary>
        /// 角色流水号
        /// </summary>
        public long RoleId;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName;

        /// <summary>
        /// 修改角色时库中所存原值（名称）
        /// </summary>
        public string ExistNameWhenUpdate;

        /// <summary>
        /// 功能角色ID
        /// </summary>
        public List<long> ListFunctionId = new List<long>();

        /// <summary>
        /// 点击Grid到数据库搜功能角色绑定到界面选择框
        /// </summary>
        public DataTable TableFunction = null;

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord;
    }
}
