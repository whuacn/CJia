using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IPaymentView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.PaymentArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.PaymentArgs> OnReCharge;

        /// <summary>
        /// 会员点击聚焦
        /// </summary>
        event EventHandler<Views.PaymentArgs> OnPaylogFocusedRowChanged;

        ///// <summary>
        ///// 重新加载会员信息
        ///// </summary>
        //event EventHandler<Views.PaymentArgs> OnRefreshMem;

        /// <summary>
        /// 绑定界面会员Grid
        /// </summary>
        /// <param name="dtMemType"></param>
        void ExeGridMember(DataTable dtMember);

        /// <summary>
        /// 绑定下拉会员类型
        /// </summary>
        /// <param name="dtMemType"></param>
        void ExeDropMemType(DataTable dtMemType);

        /// <summary>
        /// 绑定会员日志记录
        /// </summary>
        /// <param name="dtMemPaylog"></param>
        void ExeGridMemPaylog(DataTable dtMemPaylog);
    }

    public class PaymentArgs : EventArgs
    {
        /// <summary>
        /// 缴费流水号
        /// </summary>
        public long PayLogId;

        /// <summary>
        /// 会员ID
        /// </summary>
        public long MemId;

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemName;

        /// <summary>
        /// 会员类型ID
        /// </summary>
        public long MemTypeId;

        /// <summary>
        /// 免费停车时长
        /// </summary>
        public string FreeTime;

        /// <summary>
        /// 缴费金额
        /// </summary>
        public double PayAmount;

        ///// <summary>
        ///// 缴费日期
        ///// </summary>
        //public DateTime PayDate;

        /// <summary>
        /// 开始计费日期
        /// </summary>
        public DateTime StartDate;

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime EffectiveDate;

        
    }
}
