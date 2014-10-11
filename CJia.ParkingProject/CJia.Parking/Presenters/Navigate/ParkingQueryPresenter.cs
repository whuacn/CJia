using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class ParkingQueryPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.ParkingQueryModel, Views.Navigate.IParkingQueryView>
    {
        public ParkingQueryPresenter(Views.Navigate.IParkingQueryView view)
            : base(view)
        {
            view.OnParkQuery += view_OnParkQuery;
        }

        void view_OnParkQuery(object sender, Views.Navigate.ParkingQueryArgs e)
        {
            DataTable dt = Model.ParkQuery(e.park1, e.park2, e.park3, e.park4, 1);
            View.ExeShowPic(dt);
        }
    }
}
