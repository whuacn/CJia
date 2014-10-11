using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryCheckPresenter :CJia.HealthInspection.Tools.PresenterPage<Models.QueryCheckModel,Views.IQueryCheck>
    {
        public QueryCheckPresenter(Views.IQueryCheck view)
            : base(view)
        {
            view.OnQueryCheckByKey += view_OnQueryCheckByKey;
        }

        void view_OnQueryCheckByKey(object sender, Views.QueryCheckArgs e)
        {
            DataTable dtCheck = Model.QueryCheckByKey(e.keyWord, e.OrganId);
            View.ExeBindCheck(dtCheck);
        }
    }
}
