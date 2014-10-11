using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface ILoginView : IView
    {
        event EventHandler<LoginEventArgs> OnUserLogin;

        event EventHandler OnQueryLocalLoginUser;

        event EventHandler OnQueryDeviceInfo;

        void ExeShowDeviceInfo();

        void ExeLoginSuccess();

        void ExeLoginFail(string FailMsg);

        void ExeShowDeviceRegister();

        void ExeShowLocalUserList(List<Data.User> LocalUserList);
    }
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs()
        {
            
        }
        public string UserCode;
        public string Password;
    }
}
