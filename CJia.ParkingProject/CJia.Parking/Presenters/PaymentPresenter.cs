using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class PaymentPresenter : CJia.Parking.Tools.Presenter<Models.PaymentModel,Views.IPaymentView>
    {
        public PaymentPresenter(Views.IPaymentView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnReCharge += view_OnReCharge;
            view.OnPaylogFocusedRowChanged += view_OnPaylogFocusedRowChanged;
            //view.OnRefreshMem += view_OnRefreshMem;
        }
              
               
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.PaymentArgs e)
        {
            BindGridMember();
            BindDropMemType();
        }

        #region【自定义方法】
         /// <summary>
        /// 绑定会员Grid
        /// </summary>
        void BindGridMember()
        {
            View.ExeGridMember(Model.QueryMember());
        }

        /// <summary>
        /// 绑定下拉会员类型
        /// </summary>
        void BindDropMemType()
        {
            View.ExeDropMemType(Model.QueryMemType());
        }

        /// <summary>
        /// 绑定所选会员所有未过期缴费记录
        /// </summary>
        /// <param name="e"></param>
        void BindGridMemPaylog(Views.PaymentArgs e)
        {
            View.ExeGridMemPaylog(Model.QueryMemPaylog(e.MemId));
        }
       #endregion
        /// <summary>
        /// 充值事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnReCharge(object sender, Views.PaymentArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsExistSameTime = Model.QueryIsExistSameTime(e.StartDate,e.MemId);
            if (dtIsExistSameTime != null && dtIsExistSameTime.Rows.Count > 0)
            {
                Message.Show("同一会员所选时间段不能重叠！");
                return;
            }
            if (Model.InserPayLog(e.MemId, e.MemTypeId, e.FreeTime, e.PayAmount, e.StartDate, e.EffectiveDate, userId))
            {
                Message.Show("【" + e.MemName + "】缴费成功！");
            }
            else
            {
                Message.Show("【" + e.MemName + "】缴费失败！");
            }
            BindGridMemPaylog(e);
        }

        /// <summary>
        /// 会员点击聚焦
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnPaylogFocusedRowChanged(object sender, Views.PaymentArgs e)
        {
            BindGridMemPaylog(e);
        }

        ///// <summary>
        ///// 重新加载Grid会员
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void view_OnRefreshMem(object sender, Views.PaymentArgs e)
        //{
        //    View.ExeGridMember(Model.QueryMember());
        //}
    }
}
