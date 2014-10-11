using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ISelectOrgan : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 查询组织事件
        /// </summary>
        event EventHandler<Views.SelectOrganArgs> OnSearchOragn;

        /// <summary>
        /// 根据组织Id查询名称
        /// </summary>
        event EventHandler<Views.SelectOrganArgs> OnQueryOrganNameById;

        /// <summary>
        /// 绑定Grid组织
        /// </summary>
        /// <param name="dtOrgan"></param>
        void ExeGridOrgan(DataTable dtOrgan);
    }

    public class SelectOrganArgs : EventArgs
    {
        /// <summary>
        /// 查询内容
        /// </summary>
        public string SearchKeyWord;

        /// <summary>
        /// 所要查询组织ID
        /// </summary>
        public string SelectedOrganId;

        /// <summary>
        /// 根据Id所查出的组织名称
        /// </summary>
        public string SelectedOrganName;
    }
}
