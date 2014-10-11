using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 添加频率对应批次的接口
    /// </summary>
    public interface IAddFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化页面载入频率和批次数据
        /// </summary>
        event EventHandler<AddFrequencyToBatchEventArgs> OnInitLoadData;

        /// <summary>
        /// 添加频率对应用法
        /// </summary>
        event EventHandler<AddFrequencyToBatchEventArgs> OnAddFrequencyBatch;

        /// <summary>
        /// 为频率的下拉框和批次的多选框绑定数据源
        /// </summary>
        /// <param name="dtFrequency">频率数据源datatable</param>
        /// <param name="dtBatch">批次数据源</param>
        void ExeGridLookUpDataBind(DataTable dtFrequency,DataTable dtBatch);

    }

    /// <summary>
    /// 添加频率对应批次的参数类
    /// </summary>
    public class AddFrequencyToBatchEventArgs : EventArgs
    {
        /// <summary>
        /// 频率Id
        /// </summary>
        public long FrequencyId;

        /// <summary>
        /// 频率名称
        /// </summary>
        public string FrequencyName;

        /// <summary>
        /// 频率查询码
        /// </summary>
        public string FrequencyFilter;

        /// <summary>
        /// 批次名称
        /// </summary>
        public string BatchsName;

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public long UserId;
    }
}