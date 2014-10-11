using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 频率对应批次的接口层
    /// </summary>
    public interface IFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnLoadData;

        /// <summary>
        /// 添加频率对应批次
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnAddFrequencyToBatch;

        /// <summary>
        /// 删除频率对应批次
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnDeleteFrequencyBatch;

        //event EventHandler<FrequencyToBatchEventArgs> OnEditFrequencyToBatch;

        /// <summary>
        /// 初始化gridcontrol数据
        /// </summary>
        /// <param name="dt"></param>
        void ExeinitData(DataTable dt);    

    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class FrequencyToBatchEventArgs:EventArgs
    {
        /// <summary>
        /// 频率对应批次表的ID
        /// </summary>
        public long FrequencyBatchId;   

        /// <summary>
        /// 当前登录用户的ID
        /// </summary>
        public long UserId;            
    }
}