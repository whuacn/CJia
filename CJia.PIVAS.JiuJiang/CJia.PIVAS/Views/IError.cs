using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    public interface IError : Tools.IView
    {
        event EventHandler OnInitPage;
        void ExeBindData(DataTable data);
    }
}
