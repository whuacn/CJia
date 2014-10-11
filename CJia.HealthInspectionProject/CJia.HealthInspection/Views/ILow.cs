using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ILow : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<LowArgs> OnInitTree;
        event EventHandler<LowArgs> OnTreeClick;
        void ExeBindTree(DataTable data);
        void ExeShowLowPage(DataTable dt);
    }

    public class LowArgs : EventArgs
    {
        public long LowFileId;
    }
}
