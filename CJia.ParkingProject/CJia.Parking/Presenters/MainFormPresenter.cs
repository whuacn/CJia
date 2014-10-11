using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class MainFormPresenter : CJia.Parking.Tools.Presenter<Models.MainFormModel,Views.IMainFormView>
    {
        public MainFormPresenter(Views.IMainFormView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
        }

        void view_OnInit(object sender, Views.MainFormArgs e)
        {
            View.ExeLoginUserRoles(Model.QueryLogionUserRoles(e.UserID));
        }
    }
}
