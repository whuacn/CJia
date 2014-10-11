using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 冲药接口
    /// </summary>
    public interface ISendPharmView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnInitIffield;

        /// <summary>
        /// 初始化批次
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnInitBacth;

        /// <summary>
        /// 查询瓶贴
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnSelectLabel;

        /// <summary>
        /// 查询药品汇总
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnSelectPharmColloet;

        /// <summary>
        /// 冲药
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnSendPharm;

        /// <summary>
        /// 打印摆药单
        /// </summary>
        event EventHandler<SendPharmEventArgs> OnPrintPharm;

        /// <summary>
        /// 修改瓶贴冲药状态
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        /// <summary>
        /// 扣费扣库存
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnPharmFee;

        /// <summary>
        /// 获取扣费时间
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnFeeTIME;

        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

         /// <summary>
        /// 初始化批次绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitBacth(DataTable result);
        
        /// <summary>
        /// 查询瓶贴绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitLabel(DataTable result);

        /// <summary>
        /// 查询药瓶汇总信息
        /// </summary>
        /// <param name="result"></param>
        void ExeInitPharmColloet(DataTable result);

        /// <summary>
        /// 绑定库存不足提示信息
        /// </summary>
        void ExeBindTodayNoPharmStore(DataTable data, string iffieldID);

        /// <summary>
        ///绑定冲药结果 
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        void ExeBindTodayPharmSend(DataTable data1, DataTable data2);

        /// <summary>
        /// 绑定摆药单 
        /// </summary>
        /// <param name="data"></param>
        void ExeBindTodayPharmSendReport(DataTable data);
    }
    /// <summary>
    /// 冲药参数类
    /// </summary>
    public class SendPharmEventArgs : EventArgs
    {
        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime date;
        /// <summary>
        /// 病区id
        /// </summary>
        public string IffieldID;
        /// <summary>
        /// 批次id
        /// </summary>
        public string barchID;
    }

}
