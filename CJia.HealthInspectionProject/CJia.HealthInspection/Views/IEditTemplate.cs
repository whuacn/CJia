using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface IEditTemplate:Views.IAddTemplate
    {
        event EventHandler<AddTemplateArgs> OnEditSave;
        void ExeBindTemplate(DataTable data);
    }
}
