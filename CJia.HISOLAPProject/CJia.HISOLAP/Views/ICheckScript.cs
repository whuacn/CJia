using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HISOLAP.Views
{
    public interface ICheckScript : Tools.IView
    {
        event EventHandler OnInitView;
        event EventHandler<CheckScriptArgs> OnDelete;
        event EventHandler<CheckScriptArgs> OnSearch;
        event EventHandler<CheckScriptArgs> OnAdd;
        event EventHandler<CheckScriptArgs> OnModify;
        event EventHandler OnQueryCheckType;
        void ExeBindCheckTypeData(DataTable data);
        void ExeBindData(DataTable data);
        void ExeIsSuccessDelete(bool bol);
        void ExeIsSuccessAdd(bool bol);
        void ExeIsSuccessModify(bool bol);
        void ExeFocusNO();
    }
    public class CheckScriptArgs : EventArgs
    {
        public string ID;
        public string OldNO;
        public string NO;
        public string Test;
        public string Error;
        public string CheckID;
        public string Level;
        public string Classify;
        public string Status;
        public string Key;
    }
}
