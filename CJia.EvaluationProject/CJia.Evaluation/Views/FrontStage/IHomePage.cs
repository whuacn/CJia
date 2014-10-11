using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.FrontStage
{
    public interface IHomePage : CJia.Evaluation.Tools.IPage
    {
        event EventHandler OnInit;
        void ExeBindTree(DataTable data);
    }
}
