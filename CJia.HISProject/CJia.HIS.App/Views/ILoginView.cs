using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HIS.App.Views
{
    public interface ILoginView : CJia.HIS.IView
    {
        string UserNo
        {
            get;
        }

        string UserPwd
        {
            get;
        }

        event EventHandler LoginEven;

        void ShowMessage(string mes);

        void CloseForm();

    }
}
