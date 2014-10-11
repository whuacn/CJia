using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// 查询瓶贴接口
    /// </summary>
    public interface IQueryLabelView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 查询所有病区所有批次的瓶贴汇总事件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        /// <summary>
        /// 查询药瓶汇总信息事件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryPharmCollect;

        /// <summary>
        /// 查询摆药单事件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryArrangeEvent;

        /// <summary>
        /// 查询瓶贴详情信息事件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelDetails;

        /// <summary>
        /// 查询瓶贴详情信息事件 带瓶贴详情表中的数据
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelDetailsInfo;

        /// <summary>
        /// 查询瓶贴汇总信息事件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelCollect;

        /// <summary>
        /// 修改摆药单id列表过滤条件
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnModifFilterArrange;

        /// <summary>
        /// 修改瓶贴条形码状态
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnUpdateBarCode; 

        /// <summary>
        /// 获取瓶贴条形码
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnGetLabelBarcode;

        /// <summary>
        /// 修改瓶贴打印状态
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnUpdateLabelPrintStatus;

        /// <summary>
        /// 删除瓶贴
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnDeleteLabel;

        /// <summary>
        /// 扣费扣库存
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnPharmFee;

        /// <summary>
        /// 获取扣费时间
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnFeeTIME;

        /// <summary>
        /// 绑定瓶贴详情回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelDetails(DataTable result);

        /// <summary>
        /// 绑定瓶贴详情回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelDetailsInfo(DataTable result);

        /// <summary>
        /// 绑定瓶贴汇总回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelCollect(DataTable result);

        /// <summary>
        /// 绑定摆药单回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingArrange(DataTable result);

        /// <summary>
        /// 绑定所有病区所有批次瓶贴汇总信息回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingAlllIffieldBachLabelCollect(DataTable result);

        /// <summary>
        /// 绑定药品汇总信息回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingPharmCollect(DataTable result);

    }

    /// <summary>
    /// 查询瓶贴事件参数
    /// </summary>
    public class QueryLabelViewEventArgs : EventArgs
    {

        /// <summary>
        /// 选择的查询事件
        /// </summary>
        public DateTime QueryTime;

        /// <summary>
        /// 选择的摆药单id列表
        /// </summary>
        public List<object> SelectArrangeIdList;

        /// <summary>
        /// 瓶贴页码号
        /// </summary>
        public string LabelPageNo;

        /// <summary>
        /// 瓶贴id
        /// </summary>
        public string LabelId;

    }



}