using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class AddDeptPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.AddDeptModel,Views.Backstage.IAddDept>
    {
        public AddDeptPresenter(Views.Backstage.IAddDept view)
            : base(view)
        {
            view.OnQueryAllDept += view_OnQueryAllDept;
            view.OnInsertDept += view_OnInsertDept;
        }

        void view_OnInsertDept(object sender, Views.Backstage.AddDeptArgs e)
        {
            bool IsInsert = Model.InsertDept(e.DeptName, e.ParentId, e.UserId);
            View.ExeReturnAddDeptMsg(IsInsert);
        }

        void view_OnQueryAllDept(object sender, Views.Backstage.AddDeptArgs e)
        {
            DataTable dtDep = Model.QueryAllDept();
            View.ExeBindDept(dtDep);
        }
    }
}
