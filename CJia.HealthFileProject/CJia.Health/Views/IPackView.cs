using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IPackView:Tools.IView
    {
        event EventHandler<PackViewArgs> OnSearchPatient;
        event EventHandler<PackViewArgs> OnOK;
        event EventHandler<PackViewArgs> OnPack;
        void ExeisPack(bool bol);
        void ExeisOk(DataRow dr);
        void ExeBindData(DataTable data);
    }
    public class PackViewArgs : EventArgs
    {
        public DateTime Start;
        public DateTime End;
        public List<string> HealthID;
        public bool isPrintCode;
        public string PackName;
        public string PackAddress;
        public string PackRemark;
        public string RecordNo;
    }
}
