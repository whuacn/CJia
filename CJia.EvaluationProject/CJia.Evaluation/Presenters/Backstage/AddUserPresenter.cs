using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class AddUserPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.AddUserModel,Views.Backstage.IAddUser>
    {
        public AddUserPresenter(Views.Backstage.IAddUser view)
            : base(view)
        {
            view.OnInsertUser += view_OnInsertUser;
        }

        void view_OnInsertUser(object sender, Views.Backstage.AddUserArgs e)
        {
            bool isInsert = Model.InsertUser(e.UserCode, e.UserName, e.UserPwd, e.DeptID, e.UserID);
            View.ExeReturnInsertMsg(isInsert);
        }
    }
}
