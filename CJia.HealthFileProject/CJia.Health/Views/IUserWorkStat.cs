using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IUserWorkStat:CJia.Health.Tools.IView
    {
        event EventHandler<UserWorkStatArgs> OnQuery;
        void ExeBindTatalData(DataTable data);
        void ExeBindAllData(DataTable data);
    }
    public class UserWorkStatArgs : EventArgs
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public string UserNO;
        public bool isAll;
    }
}
