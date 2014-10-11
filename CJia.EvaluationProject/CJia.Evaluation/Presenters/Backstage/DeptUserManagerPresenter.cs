using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class DeptUserManagerPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.DeptUserManagerModel,Views.Backstage.IDeptUserManager>
    {
        public DeptUserManagerPresenter(Views.Backstage.IDeptUserManager view)
            : base(view)
        {
            view.OnInitDept += view_OnInitDept;
            view.OnQueryUserByDeptId += view_OnQueryUserByDeptId;
            view.OnDeleteDept += view_OnDeleteDept;
            view.OnIsHaveChildDept += view_OnIsHaveChildDept;
            view.OnDeleteUser += view_OnDeleteUser;
        }

        void view_OnDeleteUser(object sender, Views.Backstage.DeptUserManagerArgs e)
        {
            bool isDelete = Model.DeleteUser(e.UserID, e.userId);
            View.ExeReturnDeleteUserMsg(isDelete);
        }

        void view_OnIsHaveChildDept(object sender, Views.Backstage.DeptUserManagerArgs e)
        {
            bool isHaveChildDept = Model.IsHaveChildDept(e.DeptId);
            View.ExeInsertUser(isHaveChildDept);
        }

        void view_OnDeleteDept(object sender, Views.Backstage.DeptUserManagerArgs e)
        {
            bool isDelete = Model.DeleteDept(e.DeptId, e.UserID);
            View.ExeReturnDeleteMsg(isDelete);
        }

        void view_OnQueryUserByDeptId(object sender, Views.Backstage.DeptUserManagerArgs e)
        {
            DataTable dtUser = Model.QueryUserByDeptId(e.DeptId);
            View.ExeBindUser(dtUser);
        }

        void view_OnInitDept(object sender, Views.Backstage.DeptUserManagerArgs e)
        {
            DataTable dtDept = Model.QueryAllDept();
            View.ExeBindDept(dtDept);
        }
    }
}
