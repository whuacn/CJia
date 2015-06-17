using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IPackManageView:Tools.IView
    {
        event EventHandler<PackManageViewArgs> OnSearchPat;
        event EventHandler<PackManageViewArgs> OnAndInPack;
        event EventHandler<PackManageViewArgs> OnPrint;
        event EventHandler<PackManageViewArgs> OnOut;
        event EventHandler<PackManageViewArgs> OnDeletePack;
        void ExeIsDeletePack(bool bol);
        void ExeIsOut(bool bol);
        void ExeIsAndInPack(DataRow dr);
        void ExeBindPat(DataTable data);
    }
    public class PackManageViewArgs : EventArgs
    {
        public string PackCode;
        public string PackName;
        public string RecordNO;
        public string PackID;
        public string HealthID;
        public string DetailID;
    }
}
