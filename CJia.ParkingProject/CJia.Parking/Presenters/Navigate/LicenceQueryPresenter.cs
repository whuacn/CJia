using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class LicenceQueryPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.LicenceQueryModel, Views.Navigate.ILicenceQueryView>
    {
        public LicenceQueryPresenter(Views.Navigate.ILicenceQueryView view)
            : base(view)
        {
            view.OnLicenceQuery += view_OnLicenceQuery;
        }

        void view_OnLicenceQuery(object sender, Views.Navigate.LicenceQueryArgs e)
        {
            DataTable dt= Model.LicenceQuery(e.Lice1, e.Lice2, e.Lice3, e.Lice4, e.Lice5,1);
            View.ExeShowPic(dt);
        }
    }
}
