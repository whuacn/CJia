using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views
{
    public interface ILoginView : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<LoginViewArgs> OnLogin;
        void ExeBindUserData(DataTable data);
    }
    public class LoginViewArgs:EventArgs
    {
        public string UserNO;
        public string Password;
        public string UserType;
    }
}
