using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 修改频率对应批次的接口层
    /// </summary>
    public interface IEditFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化载入数据
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnInitLoadBatch;

        /// <summary>
        /// 修改频率对应批次
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnUpdateFrequencyBatch;

        /// <summary>
        /// 审方修改批次
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnUpdateCheckFrequencyBatch;

        /// <summary>
        /// 为批次多选框绑定数据
        /// </summary>
        /// <param name="dt">批次的数据源</param>
        void ExeInitLoadBatch(DataTable dt);
    }

    /// <summary>
    /// 修改频率对应批次的参数类
    /// </summary>
    public class EditFrequencyToBatchEventArgs : EventArgs
    {
        /// <summary>
        /// 批次名称
        /// </summary>
        public string BatchsName;       

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public long UserId;             

        /// <summary>
        /// 频率对应批次ID
        /// </summary>
        public long FrequencyBatchId;

        /// <summary>
        /// 组号（审方用）
        /// </summary>
        public string GroupIndex;
    }
}