using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    public interface IStorageQueryView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 查询库存
        /// </summary>
        event EventHandler<StorageQueryArgs> OnStorageQuery;

        /// <summary>
        /// 绑定网格数据
        /// </summary>
        /// <param name="dt"></param>
        void ExeDataBind(DataTable dt);
    }

    /// <summary>
    /// 接口类
    /// </summary>
    public class StorageQueryArgs : EventArgs
    { 
        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugName;

        /// <summary>
        /// 药品规格
        /// </summary>
        public string DrugSpec;

        /// <summary>
        /// 药品批号
        /// </summary>
        public string DrugNo;

        /// <summary>
        /// 药品厂商
        /// </summary>
        public string DrugFirm;

        /// <summary>
        /// 是否过滤0数量
        /// </summary>
        public bool FilterZero;
    }
}
