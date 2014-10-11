using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryRole : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 删除单个角色
        /// </summary>
        event EventHandler<Views.QueryRoleArgs> OnDeleteRole;

        /// <summary>
        /// 删除单个角色
        /// </summary>
        event EventHandler<Views.QueryRoleArgs> OnDeleteRoleArr;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QueryRoleArgs> OnSearch;

        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeGridRole(DataTable dtRole);
    }

    public class QueryRoleArgs : EventArgs
    {
        /// <summary>
        /// 所要删除角色（单个）
        /// </summary>
        public string DeleteRoleId;

        /// <summary>
        /// 删除所勾选角色（多个）
        /// </summary>
        public List<object> DeleteRoleIdArr = new List<object>();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWords;
    }
}
