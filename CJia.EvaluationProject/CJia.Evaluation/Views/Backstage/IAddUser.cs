using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IAddUser : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<AddUserArgs> OnInsertUser;
        void ExeReturnInsertMsg(bool isInsert);
    }

    public class AddUserArgs : EventArgs
    {
        public string UserName;

        public string UserCode;

        public string UserPwd;

        public string UserID;

        public string DeptID;
    }
}
