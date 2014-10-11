using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class FastQueryPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.FastQueryModel, Views.Navigate.IFastQueryView>
    {
        public FastQueryPresenter(Views.Navigate.IFastQueryView view)
            : base(view)
        {
            view.OnFastQuery += view_OnFastQuery;
        }

        void view_OnFastQuery(object sender, Views.Navigate.FastQueryArgs e)
        {
            DataTable dt = Model.FastQuery(e.Fast1, e.Fast2, e.Fast3, e.Fast4, e.Fast4, 1);
            View.ExeShowPic(dt);
        }
    }
}
