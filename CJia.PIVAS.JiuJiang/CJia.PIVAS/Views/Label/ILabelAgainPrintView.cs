using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// 赛选瓶贴用户控件接口
    /// </summary>
    public interface ILabelAgainPrintView : CJia.PIVAS.Tools.IView
    {
        event EventHandler<LabelAgainPrintEventArgs> OnSelect;

        void ExeLabel(DataTable result);

        event EventHandler<LabelAgainPrintEventArgs> OnSelectPrintInfo;

        void ExePrintLabelInfo(DataTable result);

        //初始化病区
        event EventHandler<Views.SendPharmSelectEventArgs> OnInitIffield;

        //初始化批次
        event EventHandler<Views.SendPharmSelectEventArgs> OnInitBacth;

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

    }

    /// <summary>
    /// 时间参数类
    /// </summary>
    public class LabelAgainPrintEventArgs : EventArgs
    {
        /// <summary>
        /// 筛选类型
        /// </summary>
        public string filterStyle;

        /// <summary>
        /// 开始打印时间
        /// </summary>
        public DateTime startDate;

        /// <summary>
        /// 结束打印时间
        /// </summary>
        public DateTime endDate;

        /// <summary>
        /// 病区id
        /// </summary>
        public string IllfieldId;

        /// <summary>
        /// 批次id
        /// </summary>
        public string BatchId;

        /// <summary>
        /// 开始瓶贴id
        /// </summary>
        public string startBarId;

        /// <summary>
        /// 结束瓶贴id
        /// </summary>
        public string endBarId;

        /// <summary>
        /// 需要重打的瓶贴id
        /// </summary>
        public List<string> printLabelList;
    }
}
