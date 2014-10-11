using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class WorkLoadPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.WorkLoadModel,Views.IWorkLoad>
    {
        public WorkLoadPresenter(Views.IWorkLoad view)
            : base(view)
        {

        }
    }
}
