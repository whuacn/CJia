//***************************************************
// 文件名（File Name）:      ICancelRCPView.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.26
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 退药查询接口层
    /// </summary>
    public interface ICancelRCPView:Tools.IView
    {
        /// <summary>
        /// 绑定退药单药品详细信息
        /// </summary>
        /// <param name="dtRCPDetail"></param>
        void ExeBindGridRCPDetail(DataTable dtRCPDetail);

        /// <summary>
        /// 绑定退药单号Id和退药时间
        /// </summary>
        /// <param name="dtRCPId"></param>
        void ExeBindGridRCPId(DataTable dtRCPId);

        /// <summary>
        /// 绑定汇总药品
        /// </summary>
        /// <param name="dtTotalCancelPharm"></param>
        void ExeBindGridTotalCancelPharm(DataTable dtTotalCancelPharm);

        /// <summary>
        /// 打印退药单
        /// </summary>
        /// <param name="dtPrintPharm"></param>
        void ExeBindPrintCancelPharm(DataTable dtPrintPharm);

        /// <summary>
        /// 刷新事件
        /// </summary>
        event EventHandler<CancelRCPArgs> OnRefresh;

        /// <summary>
        /// 打印事件
        /// </summary>
        event EventHandler<CancelRCPArgs> OnPrint;

        /// <summary>
        /// 选择左侧gridControl单号绑定相应单号瓶贴数据事件
        /// </summary>
        event EventHandler<CancelRCPArgs> OnSelecteRCPId;
    }

    public class CancelRCPArgs : EventArgs
    {
        /// <summary>
        /// 时间条件
        /// </summary>
        public DateTime queryDate;

        /// <summary>
        /// 刷新时所选条件（不选：""， 汇总："1"， 拒绝退药："2"）
        /// </summary>
        public string selectValue = "";

        /// <summary>
        /// 左侧GridControl所选择单号
        /// </summary>
        public string selectedRCPId = "";
    }
}
