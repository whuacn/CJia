using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryOrgan : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QueryOrganArgs> OnSearch;

        /// <summary>
        /// 删除单个组织
        /// </summary>
        event EventHandler<Views.QueryOrganArgs> OnDeleteOrganId;

        /// <summary>
        /// 删除所选多个组织
        /// </summary>
        event EventHandler<Views.QueryOrganArgs> OnDeletedOrganArr;

        /// <summary>
        /// 绑定组织
        /// </summary>
        /// <param name="dtOrgan"></param>
        void ExeGridOrgan(DataTable dtOrgan);
    }

    public class QueryOrganArgs : EventArgs
    {
        /// <summary>
        /// 删除所选组织
        /// </summary>
        public List<object> DeletedOrganArr = new List<object>();

        /// <summary>
        /// 所要删除组织Id
        /// </summary>
        public string DeletedOrganId;

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWords;

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;


    }
}
