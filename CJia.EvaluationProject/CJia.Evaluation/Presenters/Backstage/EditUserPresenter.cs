using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class EditUserPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.EditUserModel,Views.Backstage.IEditUser>
    {
        public EditUserPresenter(Views.Backstage.IEditUser view)
            : base(view)
        {
            view.OnInitDept += view_OnInitDept;
            view.OnResetPwd += view_OnResetPwd;
            view.OnEditUser += view_OnEditUser;
        }

        void view_OnEditUser(object sender, Views.Backstage.EditUserArgs e)
        {
            bool isEdit = Model.EditUser(e.UserName, e.DeptId, e.UserId, e.userId);
            View.ExeResturnEditMsg(isEdit);
        }

        void view_OnResetPwd(object sender, Views.Backstage.EditUserArgs e)
        {
            bool isReset = Model.ResetPwd(e.userId, e.Pwd, e.UserId);
            View.ExeResturnResetMsg(isReset);
        }

        void view_OnInitDept(object sender, Views.Backstage.EditUserArgs e)
        {
            DataTable dtDept = Model.QueryDept();
            View.ExeBindDept(dtDept);
        }
    }
}
