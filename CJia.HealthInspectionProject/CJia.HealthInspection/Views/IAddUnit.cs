using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface IAddUnit:Tools.IPage
    {
        event EventHandler OnInitPage;
        event EventHandler OnSave;
        void ExeBindType(DataTable unitType, DataTable IDType, DataTable ecoType, DataTable applyType);
        void ExeIsSuccess(bool bol);
    }
}
