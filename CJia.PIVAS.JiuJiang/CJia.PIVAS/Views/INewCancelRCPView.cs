using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    public interface INewCancelRCPView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 刷新事件
        /// </summary>
        event EventHandler<NewCancelRCPEventArgs> OnRefresh;
        /// <summary>
        /// 打印事件
        /// </summary>
        event EventHandler<NewCancelRCPEventArgs> OnPrint;
        /// <summary>
        /// 绑定退药药品详细信息
        /// </summary>
        /// <param name="dtRCPDetail"></param>
        void ExeBindRCPDetail(DataTable dtRCPDetail);
        /// <summary>
        /// 绑定病区
        /// </summary>
        /// <param name="data"></param>
        void ExeBindIllfield(DataTable data);
        /// <summary>
        /// 绑定汇总药品
        /// </summary>
        /// <param name="dtTotalCancelPharm"></param>
        void ExeBindTotalCancelPharm(DataTable dtTotalCancelPharm);
        /// <summary>
        /// 打印退药汇总单
        /// </summary>
        /// <param name="dtPrintPharm"></param>
        void ExePrintCancelPharm(DataTable dtPrintPharm);
        /// <summary>
        /// 打印退药详情单
        /// </summary>
        /// <param name="data"></param>
        void ExePrintCancelPharmDetail(DataTable data);
        /// <summary>
        /// 绑定拒绝退药药品详细信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindRefuseRCPDetail(DataTable data);
        /// <summary>
        /// 绑定拒绝退药汇总药品
        /// </summary>
        /// <param name="data"></param>
        void ExeBindRefuseTotalCancelPharm(DataTable data);

    }
    public class NewCancelRCPEventArgs : EventArgs
    {
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// 查询截止时间
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 选择的病区
        /// </summary>
        public string IllfieldID;
        /// <summary>
        /// 汇总是否被选中
        /// </summary>
        public bool IsAllPharm = false;
        /// <summary>
        /// 拒绝是否被选中
        /// </summary>
        public bool IsRefuse = false;
        /// <summary>
        /// 退药状态
        /// </summary>
        public string retreatStatus = string.Empty;

        /// <summary>
        /// 时间类型
        /// </summary>
        public string dateStyle = "";
    }
}
