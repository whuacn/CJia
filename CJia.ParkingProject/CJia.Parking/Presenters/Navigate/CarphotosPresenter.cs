using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class CarphotosPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.CarPhotosModel, Views.Navigate.ICarPhotosView>
    {
        public CarphotosPresenter(Views.Navigate.ICarPhotosView view)
            : base(view)
        {
            view.OnQueryNextPageByLice += view_OnQueryNextPageByLice;
            view.OnQueyrNextPageByPark += view_OnQueyrNextPageByPark;
            view.OnQueryNextPageByFast += view_OnQueryNextPageByFast;
            view.OnQueryNextPageByTime += view_OnQueryNextPageByTime;
        }

        void view_OnQueryNextPageByTime(object sender, Views.Navigate.CarPhotosArgs e)
        {
            DataTable dt = Model.QueryByTime(e.TimeQuerySql, e.TimeQueryPar);
            View.ExeShowPictrues(dt);
        }

        void view_OnQueryNextPageByFast(object sender, Views.Navigate.CarPhotosArgs e)
        {
            DataTable dt = Model.QueryByFast(e.fast1, e.fast2, e.fast3, e.fast4, e.fast5, e.PageIndex);
            View.ExeShowPictrues(dt);
        }

        void view_OnQueyrNextPageByPark(object sender, Views.Navigate.CarPhotosArgs e)
        {
            DataTable dt = Model.QueryByPark(e.ParkNo, e.PageIndex);
            View.ExeShowPictrues(dt);
        }

        void view_OnQueryNextPageByLice(object sender, Views.Navigate.CarPhotosArgs e)
        {
            DataTable dt = Model.QueryByLice(e.LicenecNo, e.PageIndex);
            View.ExeShowPictrues(dt);
        }
    }
}
