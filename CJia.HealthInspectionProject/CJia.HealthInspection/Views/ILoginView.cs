using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface ILoginView : CJia.HealthInspection.Tools.IPage
    {
       event EventHandler<LoginEventArgs> OnLogin;
       void ExeBindUserSession(DataTable data);
    }
    public  class LoginEventArgs:EventArgs
    {
        public string UserAccount;

        public string UserPassword;
    }
}
