using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Presenters
{
    public class TemporaryFeeSetPresenter : CJia.Parking.Tools.Presenter<Models.TemporaryFeeSetModel,Views.ITemporaryFeeSetView>
    {
        public TemporaryFeeSetPresenter(Views.ITemporaryFeeSetView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.TemproaryFeeSetArgs e)
        {
            DataTable dtTem = Model.QueryTemporaryCharge();
            if (dtTem != null && dtTem.Rows.Count > 0)
            {
                e.DataTableTem = dtTem;
            }
        }

        void view_OnSave(object sender, Views.TemproaryFeeSetArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtTem = Model.QueryTemporaryCharge();
            if (dtTem != null && dtTem.Rows.Count > 0)
            {
                if (Model.UpdateTemporaryCharge(e.FreeHour, e.HourSet, e.HourSetFee, e.UpperHour, e.UpperHourFee))
                {
                    Message.Show("保存成功！");
                }
            }
            else
            {
                if (Model.InsertTemporaryCharge(e.FreeHour, e.HourSet, e.HourSetFee, e.UpperHour, e.UpperHourFee, userId))
                {
                    Message.Show("保存成功！");
                }
            }
        }
    }
}
