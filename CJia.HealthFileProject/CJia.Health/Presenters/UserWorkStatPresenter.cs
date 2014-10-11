using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class UserWorkStatPresenter : CJia.Health.Tools.Presenter<Models.UserWorkStatModel, Views.IUserWorkStat>
    {
        public UserWorkStatPresenter(Views.IUserWorkStat view)
            : base(view)
        {
            view.OnQuery += view_OnQuery;
        }

        void view_OnQuery(object sender, Views.UserWorkStatArgs e)
        {
            if (e.isAll)
            {
                DataTable data = Model.QueryUserWorkAll(e.StartDate, e.EndDate, e.UserNO);
                View.ExeBindAllData(data);
            }
            else
            {
                DataTable data = Model.QueryUserWorkTotal(e.StartDate, e.EndDate, e.UserNO);
                View.ExeBindTatalData(data);
            }
        }
    }
}
