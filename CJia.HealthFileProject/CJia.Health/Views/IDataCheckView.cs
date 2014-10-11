using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IDataCheckView : CJia.Health.Tools.IView
    {
        event EventHandler<DataCheckArgs> OnSreach;

        event EventHandler<DataCheckArgs> OnSelectPic;

        event EventHandler<DataCheckArgs> OnLock;

        event EventHandler<DataCheckArgs> OnOpenLock;

        event EventHandler<DataCheckArgs> OnPass;

        event EventHandler<DataCheckArgs> OnNoPass;

        event EventHandler<DataCheckArgs> OnDelete;

        event EventHandler<DataCheckArgs> OnLockFunction;


        void ExeLock(bool result);

        void ExeOpenLock(bool result);

        void ExePass(bool result);

        void ExeNoPass(bool result);

        void ExeDelete(bool result);

        void ExePic(DataTable result);

        void ExePatient(DataTable result);

        void ExeLockFunction(bool result);
       
    }
    public class DataCheckArgs : EventArgs
    {
        public DateTime start;

        public DateTime end;

        public string search;

        public string healthId;

        public string checkStatus;

        public string CheckReason;

        public string LockReason;

    }
}
