using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters
{
    public class LoginViewPresenter : CJia.Evaluation.Tools.PresenterPage<Models.LoginViewModel, Views.ILoginView>
    {
        public LoginViewPresenter(Views.ILoginView view)
            : base(view)
        {
            view.OnLogin += view_OnLogin;
        }

        void view_OnLogin(object sender, Views.LoginViewArgs e)
        {
            DataTable data = Model.GetUser(e.UserNO, e.Password);
            View.ExeBindUserData(data);
        }
    }
}
