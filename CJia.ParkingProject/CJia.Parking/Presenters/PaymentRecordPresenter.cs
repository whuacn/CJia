using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class PaymentRecordPresenter : CJia.Parking.Tools.Presenter<Models.PaymentRecordModel,Views.IPaymentRecordView>
    {
        public PaymentRecordPresenter(Views.IPaymentRecordView view)
            : base(view)
        {
            view.OnSearch += view_OnSearch;
        }
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.PaymentRecordArgs e)
        {
            View.ExeGridMemPaylog(Model.QueryMemPaymentlog(e.StartDate,e.EndDate,e.MemInfo,e.PlateNo,e.PayDate));
        }
               
    }
}
