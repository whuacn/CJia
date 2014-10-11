using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class SelectTaskPresenter :CJia.HealthInspection.Tools.PresenterPage<Models.SelectTaskModel,Views.ISelectTask>
    {
        public SelectTaskPresenter(Views.ISelectTask view)
            : base(view)
        {
            view.OnInitTask += view_OnInitTask;
            view.OnQueryTaskByID += view_OnQueryTaskByID;
        }

        void view_OnQueryTaskByID(object sender, Views.SelectTaskArgs e)
        {
            DataTable DtTask = Model.QueryTaskById(e.TaskID);
            if (DtTask != null)
            {
                View.ExeGetSelectTask(DtTask);
            }
        }

        void view_OnInitTask(object sender, Views.SelectTaskArgs e)
        {
            DataTable dtTask = Model.QueryTask(e.OrganId);
            View.ExeBindTask(dtTask);
        }
    }
}
