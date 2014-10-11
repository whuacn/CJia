//***************************************************
// 文件名（File Name）:      ICancelApplyView.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.22
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
    /// 退药处理接口层
    /// </summary>
    public interface ICancelApplyView:Tools.IView
    {
        /// <summary>
        ///  查询申请退药列表信息，绑定GridControl
        /// </summary>
        /// <param name="dtCancelApply"></param>
        void  ExeBindGridCancelApply(DataTable dtCancelApply);

        /// <summary>
        /// 绑定病区
        /// </summary>
        /// <param name="dtOfficeName"></param>
        void ExeBindOfficeName(DataTable dtOfficeName);

        /// <summary>
        /// 绑定打印所勾选药品
        /// </summary>
        /// <param name="dtCheckedPharm"></param>
        void ExeBindPrintApplyCancelPharm(DataTable dtCheckedPharm);

        /// <summary>
        /// 确定退药事件
        /// </summary>
        event EventHandler<CancelApplyArgs> OnOkCancel;

        /// <summary>
        /// 拒绝退药事件
        /// </summary>
        event EventHandler<CancelApplyArgs> OnRefuseApply;

        /// <summary>
        /// 预览退药事件,即查询申退单
        /// </summary>
        event EventHandler<CancelApplyArgs> OnCancelPreview;
    }

    public class CancelApplyArgs : EventArgs
    {
        /// <summary>
        /// 瓶贴Id
        /// </summary>
        public int labelId = 0;

        ///// <summary>
        ///// 预览查询条件
        ///// </summary>
        //public string queryStr = "";

        /// <summary>
        /// 所选瓶贴组号
        /// </summary>
        public string  group_index = "";

        /// <summary>
        /// 是否勾选打印, 未勾选：false  勾选：true
        /// </summary>
        public bool isPrint = false;

        /// <summary>
        /// 所选预览查询时间
        /// </summary>
        public string queryDate = "";

        /// <summary>
        /// 瓶贴冲药状态（1，已冲；0，未冲）
        /// </summary>
        public string queryExeStatus = "";

        /// <summary>
        /// 所选病区
        /// </summary>
        public string queryIllFieldId = "";
    }
}
