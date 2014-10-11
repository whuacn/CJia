using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.FrontStage
{
    public interface IFirstOne : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<FirstOneArgs> OnInit;
        event EventHandler<FirstOneArgs> OnGetTreeByPatID;
        event EventHandler<FirstOneArgs> OnGetZLByID;
        event EventHandler<FirstOneArgs> OnGetAnotherZLByID;
        event EventHandler<FirstOneArgs> OnGetParentByID;
        void ExeBindParentData(DataTable data);
        void ExeBindAnotherZLData(DataTable data);
        void ExeBindData(DataTable data, DataTable patdata);
        void ExeBindABCData(DataTable data, DataTable selfData);
        void ExeBindZLData(DataTable data);
    }
    /// <summary>
    /// 参数类
    /// </summary>
    public class FirstOneArgs : EventArgs
    {
        public string treeID;
    }
}
