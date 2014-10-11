using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters.Web
{
    public class EditPasswordPresenter : CJia.Health.Tools.PresenterPage<Models.Web.EditPasswordModel, Views.Web.IEditPasswordView>
    {
        public EditPasswordPresenter(Views.Web.IEditPasswordView view)
            : base(view)
        {
            view.OnSave += view_OnSave;
        }

        void view_OnSave(object sender, Views.Web.EditPasswordArgs e)
        {
            bool bol = Model.ModifyPassword(e.UserData.Rows[0]["USER_ID"].ToString(), e.NewPassword);
            View.ExeIsSuccess(bol);
        }
    }
}
