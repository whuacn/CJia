using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IMainFormView : CJia.Health.Tools.IView
    {
        event EventHandler<MainFormArgs> OnInitFunction;

        void ExeInitFunction(DataTable dt);
    }

    public class MainFormArgs : EventArgs
    {
        public string UserID = User.UserData.Rows[0]["USER_ID"].ToString();
    }
}
