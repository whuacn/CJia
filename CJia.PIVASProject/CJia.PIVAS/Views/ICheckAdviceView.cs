//***************************************************
// 文件名（File Name）:      ICheckAdviceView.cs（审方View层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 审方View层
    /// </summary>
    public interface ICheckAdviceView:Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler OnInitLoad;

        /// <summary>
        /// 刷新医嘱事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnRefresh;

        /// <summary>
        /// 单个通过事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnInsertCheck;

        /// <summary>
        /// 取消审核事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnCancelCheck;

        /// <summary>
        /// 拒绝医嘱事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnRefuseCheck;

        /// <summary>
        /// 查询病人信息事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnPatient;

        /// <summary>
        /// 查询病史资料事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnPatientHistory;

        /// <summary>
        /// 审方完成事件
        /// </summary>
        event EventHandler<CheckAdviceArgs> OnComplete;

        /// <summary>
        /// 绑定病区
        /// </summary>
        /// <param name="data"></param>
        void ExeBindOffice(DataTable data);

        /// <summary>
        /// 根据病区、开单时间绑定有效医嘱
        /// </summary>
        /// <param name="dtAdvice"></param>
        void ExeGetAdvice(DataTable dtAdvice);

        ///// <summary>
        ///// 绑定需要插入的待审医嘱
        ///// </summary>
        ///// <param name="dtBatchData"></param>
        //void ExeGetBatchData(DataTable dtBatchData);

        /// <summary>
        /// 绑定病人信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPatient(DataTable data);

        /// <summary>
        /// 绑定病史资料
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPatientHistory(DataTable data);
    }
    /// <summary>
    /// 参数定义
    /// </summary>
    public class CheckAdviceArgs : EventArgs
    {
        /// <summary>
        /// 开始（开单时间）
        /// </summary>
        public DateTime BeginListDate;

        /// <summary>
        /// 结束（开单时间）
        /// </summary>
        public DateTime EndListDate;

        /// <summary>
        /// 病区ID
        /// </summary>
        public string OfficeID;

        /// <summary>
        /// 配置中心审核医嘱状态
        /// </summary>
        public int CheckPivasStatus;

        /// <summary>
        /// 无效按钮
        /// </summary>
        public bool IsValidCheck;

        /// <summary>
        /// 所有按钮
        /// </summary>
        public bool IsAllCheck;

        /// <summary>
        /// 已审按钮
        /// </summary>
        public bool IsYesCheck;

        /// <summary>
        /// 未审按钮
        /// </summary>
        public bool IsNoCheck;

        /// <summary>
        /// 成组药品类别--化疗药
        /// </summary>
        public bool IsTypeHLY;

        /// <summary>
        /// 成组药品类别--抗生素
        /// </summary>
        public bool IsTypeKSS;

        /// <summary>
        /// 成组药品类别--三升袋
        /// </summary>
        public bool IsTypeSSD;

        /// <summary>
        /// 成组药品类别--普通药
        /// </summary>
        public bool IsTypePTY;

        /// <summary>
        /// 住院号
        /// </summary>
        public string InhosId;

        /// <summary>
        /// 医嘱组编号
        /// </summary>
        public string GroupIndex;

        /// <summary>
        /// 原始配置中心状态
        /// </summary>
        public int OriginalPivasStatus;

        /// <summary>
        /// 原始配置中心批次
        /// </summary>
        public string OriginalPivasBatchNo;

        /// <summary>
        /// 审核配置中心批次
        /// </summary>
        public string CheckPivasBatchNo;

        /// <summary>
        /// 拒绝原因
        /// </summary>
        public string CancelReason;
    }
}
