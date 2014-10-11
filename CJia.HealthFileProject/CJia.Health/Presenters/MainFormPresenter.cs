using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class MainFormPresenter : CJia.Health.Tools.Presenter<Models.MainFormModel, Views.IMainFormView>
    {
        public MainFormPresenter(Views.IMainFormView view)
            : base(view)
        {
            view.OnInitFunction += view_OnInitFunction;
        }

        void view_OnInitFunction(object sender, Views.MainFormArgs e)
        {
            View.ExeInitFunction(Model.QueryNoFunction(e.UserID));
        }
    }
}
