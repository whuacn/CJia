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
    public interface IQueryPrintLabelView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitIffield;

        /// <summary>
        /// 初始化批次
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitBacth;

        /// <summary>
        /// 初始化给药途径
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitUsage;

        /// <summary>
        /// 查询所有病区所有批次的瓶贴汇总事件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        /// <summary>
        /// 查询药瓶汇总信息事件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryPharmCollect;

        /// <summary>
        /// 查询摆药单事件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryArrangeEvent;

        /// <summary>
        /// 查询瓶贴详情信息事件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelDetails;

        /// <summary>
        /// 查询瓶贴详情信息事件 带瓶贴详情表中的数据
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelDetailsInfo;

        /// <summary>
        /// 查询瓶贴汇总信息事件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelCollect;

        /// <summary>
        /// 修改摆药单id列表过滤条件
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnModifFilterArrange;

        /// <summary>
        /// 修改瓶贴条形码状态
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnUpdateBarCode;

        /// <summary>
        /// 打印瓶贴
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnGenLabel;

        /// <summary>
        /// 修改瓶贴冲药状态
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        /// <summary>
        /// 检查该瓶贴会不会使药品库存不足
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnLabelPharmCount;


        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitUsage(DataTable result);

        /// <summary>
        /// 初始化批次绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitBacth(DataTable result);

        /// <summary>
        /// 获取瓶贴条形码
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnGetLabelBarcode;

        /// <summary>
        /// 修改瓶贴打印状态
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResTwoPar OnUpdateLabelPrintStatus;

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
        /// 瓶贴计费次数
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnLabelIsFee;

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
    public class QueryPrintLabelViewEventArgs : EventArgs
    {

        /// <summary>
        /// 0 代表今天  1代表明天
        /// </summary>
        public int selectDate;

        /// <summary>
        /// 0代表当日  1代表隔日
        /// </summary>
        public int grOrDr;

        public int labelCount;
        /// <summary>
        /// 长期临时标志
        /// </summary>
        public string longTemporary;

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

        /// <summary>
        /// 病区id
        /// </summary>
        public string IllfieldId;

        /// <summary>
        /// 给药途径id
        /// </summary>
        public string UsageId;

        /// <summary>
        /// 批次id
        /// </summary>
        public string batchid;

        /// <summary>
        /// 打印类型 1:代表打印拼贴 0:不打印瓶贴
        /// </summary>
        public string printType;

        /// <summary>
        /// 需要生成瓶贴的病区批次数据
        /// </summary>
        public DataTable groupIndexBatchid;

        /// <summary>
        /// 是否使用审核时间过滤
        /// </summary>
        public bool useCheckData;

        /// <summary>
        /// 开始审核时间
        /// </summary>
        public DateTime CheckDataStart;

        /// <summary>
        /// 结束审核时间
        /// </summary>
        public DateTime CheckDataEnd;


    }



}