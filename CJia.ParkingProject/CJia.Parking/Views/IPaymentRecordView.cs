using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IPaymentRecordView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.PaymentRecordArgs> OnSearch;

         /// <summary>
        /// 绑定Grid会员缴费日志表
        /// </summary>
        /// <param name="dtMemPaylog"></param>
        void ExeGridMemPaylog(DataTable dtMemPaylog);
    }

    public class PaymentRecordArgs : EventArgs
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate;

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate;

        /// <summary>
        /// 会员查询条件
        /// </summary>
        public string MemInfo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo;

        /// <summary>
        /// 缴费时间
        /// </summary>
        public DateTime PayDate;
    }
}
