using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HIS.Clinic.Register.Views
{
    public interface IRegisterView : CJia.HIS.IView
    {
        event CJia.HIS.Delegate.NoResOnePar GetTxtCardTypeEvent;

        void resCardType(DataTable cardTypes);
    }
}
