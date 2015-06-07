using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IIPSetView:Tools.IView
    {
        event EventHandler<IPSetViewArgs> OnAdd;
        event EventHandler<IPSetViewArgs> OnDelete;
        event EventHandler<IPSetViewArgs> OnInitView;
        void ExeBindData(DataTable data);
        void ExeIsDelete(bool bol);
        void ExeIsAdd(bool bol);
    }
    public class IPSetViewArgs : EventArgs
    {
        public List<string> IPList;
    }
}
