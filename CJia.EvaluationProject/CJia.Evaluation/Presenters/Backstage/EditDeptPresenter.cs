using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class EditDeptPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.EditDeptModel,Views.Backstage.IEditDept>
    {
        public EditDeptPresenter(Views.Backstage.IEditDept view)
            : base(view)
        {
            view.OnInitDept += view_OnInitDept;
            view.OnUpdateDept += view_OnUpdateDept;
            view.OnQueryDeptById += view_OnQueryDeptById;
        }

        void view_OnQueryDeptById(object sender, Views.Backstage.EditDeptArgs e)
        {
            DataTable dtDept = Model.QueryDeptByID(e.DeptId);
            View.ExeBindParentDept(dtDept);
        }

        void view_OnUpdateDept(object sender, Views.Backstage.EditDeptArgs e)
        {
            bool isUpdate = Model.UpdateDept(e.DeptName, e.ParentDeptID, e.UserId, e.DeptId);
            View.ExeReturnUpdateMsg(isUpdate);
        }

        void view_OnInitDept(object sender, Views.Backstage.EditDeptArgs e)
        {
            DataTable dtDept = Model.QueryAllDept();
            View.ExeBingDept(dtDept);
        }
    }
}
