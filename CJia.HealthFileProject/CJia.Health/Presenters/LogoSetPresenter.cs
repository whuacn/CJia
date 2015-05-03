using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class LogoSetPresenter : CJia.Health.Tools.Presenter<Models.LogoSetModel, Views.ILogoSet>
    {
        public LogoSetPresenter(Views.ILogoSet view)
            : base(view)
        {
            view.OnSave += view_OnSave;
        }

        void view_OnSave(object sender, Views.LogoSetArgs e)
        {
            bool bol= Model.ModifyLogoInfo(e.LogoContent, e.Inclination);
            View.ExeBindSuccess(bol);
        }
    }
}
