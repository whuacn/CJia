using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryDept : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 根据Id删除部门
        /// </summary>
        event EventHandler<Views.QueryDeptArgs> OnDeleteDeptById;

        /// <summary>
        /// 删除所选部门组
        /// </summary>
        event EventHandler<Views.QueryDeptArgs> OnDeletedDeptArr;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QueryDeptArgs> OnSearch;

         /// <summary>
        /// 绑定界面部门Grid
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeGridDept(DataTable dtUser);
    }

    public class QueryDeptArgs : EventArgs
    {
        /// <summary>
        /// 所要删除的部门编号
        /// </summary>
        public string DeletedDeptId;

        /// <summary>
        /// 删除所选用户
        /// </summary>
        public List<object> DeletedDeptArr = new List<object>();

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
