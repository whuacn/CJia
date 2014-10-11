using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    public interface ICancelLabelView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<CancelLabeEventArgs> OnInitIffield;
        /// <summary>
        /// 根据病区病床查询病人医嘱
        /// </summary>
        event EventHandler<CancelLabeEventArgs> OnSelect;
        /// <summary>
        /// 根据条形码和医嘱编号查询病人医嘱
        /// </summary>
        event EventHandler<CancelLabeEventArgs> OnSelectByNO;
        /// <summary>
        /// 提交申请事件
        /// </summary>
        event EventHandler<CancelLabeEventArgs> OnBtnOK;
        /// <summary>
        /// 刷新事件
        /// </summary>
        event EventHandler<CancelLabeEventArgs> OnBtnRefresh;
        /// <summary>
        /// 绑定所有病区
        /// </summary>
        /// <param name="data"></param>
        void ExeBindAllIffield(DataTable data,DataTable piciData);
        /// <summary>
        /// 根据病区信息绑定医嘱
        /// </summary>
        /// <param name="data"></param>
        void ExeBindAdvice(DataTable data);
        /// <summary>
        /// 根据瓶贴信息绑定病人医嘱
        /// </summary>
        /// <param name="data"></param>
        void ExeBindAdviceNO(DataTable data);
        /// <summary>
        /// 查询待处理的退药申请
        /// </summary>
        /// <param name="data"></param>
        void ExeBindCancelApply(DataTable data);

    }
    /// <summary>
    /// 退药申请参数
    /// </summary>
    public class CancelLabeEventArgs : EventArgs
    {
        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// 条形码id
        /// </summary>
        public string barCode;
        /// <summary>
        /// 病区id
        /// </summary>
        public string IffieldID;
        /// <summary>
        /// 病床号
        /// </summary>
        public string BedNO;
        /// <summary>
        /// 条形码编号
        /// </summary>
        public string BarCodeNO;
        /// <summary>
        /// 医嘱编号
        /// </summary>
        public string AdviceNO;
        /// <summary>
        /// 瓶贴id
        /// </summary>
        public List<string> LabelID;
        /// <summary>
        /// 条形码号
        /// </summary>
        public List<string> LabelBarID;
        /// <summary>
        /// 病人信息
        /// </summary>
        public string PatientInfo;
        /// <summary>
        /// 申退理由
        /// </summary>
        public string ApplyReason;
        /// <summary>
        /// 申退人
        /// </summary>
        public string ApplyName;
        /// <summary>
        /// 批次
        /// </summary>
        public string PiCi;
    }
}
