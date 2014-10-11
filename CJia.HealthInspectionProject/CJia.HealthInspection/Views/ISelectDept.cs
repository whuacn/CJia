using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ISelectDept : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.SelectDeptArgs> OnInit;

        /// <summary>
        /// 查询部门
        /// </summary>
        event EventHandler<Views.SelectDeptArgs> OnSearchDept;

        /// <summary>
        /// 根据部门Id查询名称
        /// </summary>
        event EventHandler<Views.SelectDeptArgs> OnQueryDeptNameById;

        /// <summary>
        /// 绑定Grid单位
        /// </summary>
        /// <param name="dtDept"></param>
        void ExeGridDept(DataTable dtDept);
    }

    public class SelectDeptArgs : EventArgs
    {
        /// <summary>
        /// 搜索内容
        /// </summary>
        public string SearchKey;

        /// <summary>
        /// 所选部门ID
        /// </summary>
        public string SelectedDeptId;

        /// <summary>
        /// 根据部门ID所查询到的部门名称
        /// </summary>
        public string SelectedDeptName;

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;
    }
}
