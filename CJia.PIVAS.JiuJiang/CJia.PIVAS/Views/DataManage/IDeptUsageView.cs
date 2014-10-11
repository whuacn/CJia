using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 病区用法配置接口定义
    /// </summary>
    public interface IDeptUsageView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化载入数据
        /// </summary>
        event EventHandler<DeptUsageEventArgs> OnInitLoadData;

        /// <summary>
        /// 删除数据
        /// </summary>
        event EventHandler<DeptUsageEventArgs> OnDeleteDeptUsage;

        /// <summary>
        /// 绑定数据源 
        /// </summary>
        /// <param name="dt">病区对应用法的数据源</param>
        void ExeDataBinds(DataTable dt);
    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class DeptUsageEventArgs : EventArgs
    {
        /// <summary>
        /// 当前登录用户ＩＤ
        /// </summary>
        public long UserId;         

        /// <summary>
        /// 批次病区用法ID
        /// </summary>
        public long PivasSetId;     
    }
}