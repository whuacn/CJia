using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    public interface IRedDrugViewView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化load数据
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar LoadData;

        /// <summary>
        /// 删除选中的时间配置数据
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar DeleteTimeSet;

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dt"></param>
        void initData(DataTable dt);
    }
}