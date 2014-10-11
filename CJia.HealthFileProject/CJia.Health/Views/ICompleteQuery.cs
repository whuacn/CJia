using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface ICompleteQuery : CJia.Health.Tools.IView
    {
        event EventHandler<CompleteQueryArgs> OnCompleteQuery;
        void ExeBindTatalData(DataTable data);
        void ExeBindAllData(DataTable data);
    }
    public class CompleteQueryArgs : EventArgs
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public string UserNO;
        public bool isAll;
        public string CompleteDate;
        public string RecordBegin;
        public string RecordEnd;
    }
}
