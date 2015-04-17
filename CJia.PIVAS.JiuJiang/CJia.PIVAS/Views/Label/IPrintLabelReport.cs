using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views.Label
{
    public interface IPrintLabelReport
    {
         void LabelPrint();
         Image GenImage();
         void DataBind(DataTable LabelDetails, int allLabelCount, int i, string LabelBarCode, DateTime GenDate);
    }
}
