using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 冲药查询View层
    /// </summary>
    public interface IPharmSendSelectView : Tools.IView
    {
        /// <summary>
        /// 单击grid事件
        /// </summary>
        event EventHandler<PharmSendSelectArgs> OnGridClick;
        /// <summary>
        /// 刷新事件
        /// </summary>
        event EventHandler<PharmSendSelectArgs> OnRefresh;
        /// <summary>
        /// 打印事件
        /// </summary>
        event EventHandler<PharmSendSelectArgs> OnPrint;
        /// <summary>
        /// 绑定冲药单号
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPharmSendNO(DataTable data);
        /// <summary>
        /// 绑定冲药单信息
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        void ExeBindLabel(DataTable data1, DataTable data2);
        /// <summary>
        /// 打印冲药单详情报表
        /// </summary>
        /// <param name="data"></param>
        void ExeBindReport(DataTable data);
        /// <summary>
        /// 打印冲药单统计报表
        /// </summary>
        /// <param name="data"></param>
        void ExeBindCollectReport(DataTable data);
    }
    /// <summary>
    /// 冲药查询参数
    /// </summary>
    public class PharmSendSelectArgs : EventArgs
    {
        /// <summary>
        /// 冲药查询时间
        /// </summary>
        public DateTime PharmSendTime;
        /// <summary>
        /// 发药单号
        /// </summary>
        public string PharmSendNO;
        /// <summary>
        /// 药品汇总按钮是否选中
        /// </summary>
        public bool isChecked = false;
    }
}
