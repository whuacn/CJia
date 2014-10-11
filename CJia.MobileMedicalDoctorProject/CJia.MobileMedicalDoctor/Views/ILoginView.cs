using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface ILoginView : IView
    {
        event EventHandler OnUserLogin;

        event EventHandler OnQueryLocalLoginUser;


        string UserCode { get; }
        string Password { get; }

        void ToMainPage();
        void ExeShowLocalUserList(List<Data.User> LocalUserList);
    }
}
