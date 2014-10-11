using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class CompleteQueryPresenter : CJia.Health.Tools.Presenter<Models.CompleteQueryModel, Views.ICompleteQuery>
    {
        public CompleteQueryPresenter(Views.ICompleteQuery view)
            : base(view)
        {
            view.OnCompleteQuery += view_OnCompleteQuery;
        }

        void view_OnCompleteQuery(object sender, Views.CompleteQueryArgs e)
        {
            //if (e.isAll)
            //{
            //    DataTable data = Model.QueryUserWorkAll(e.StartDate, e.EndDate, e.UserNO);
            //    View.ExeBindAllData(data);
            //}
            //else
            //{
            //    DataTable data = Model.QueryUserWorkTotal(e.StartDate, e.EndDate, e.UserNO);
            //    View.ExeBindTatalData(data);
            //}
            DataTable data = Model.QueryCompleteDate(e.CompleteDate, e.RecordBegin, e.RecordEnd);
            View.ExeBindTatalData(data);
        }
    }
}
