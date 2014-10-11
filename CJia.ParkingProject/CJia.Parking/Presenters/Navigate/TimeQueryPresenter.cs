using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class TimeQueryPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.TimeQueryModel, Views.Navigate.ITimeQueryView>
    {
        public TimeQueryPresenter(Views.Navigate.ITimeQueryView view)
            : base(view)
        {
            view.OnTimeQury += view_OnTimeQury;
        }

        void view_OnTimeQury(object sender, Views.Navigate.TimeQueryArgs e)
        {
            DataTable dt = Model.TimeQuery(e.floorList, e.timeList,1);
            View.ExeShowPic(dt);
        }
    }
}
