using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HIS.App.Views
{
    public interface ISelectSystemView : CJia.HIS.IView
    {
        DataRow SelectedSys
        {
            get;
        }

        event EventHandler SelectSysEven;

        void SetSystems(DataTable systems);

        void ShowMessage(string mess);

        void CloseFrom();
    }
}
