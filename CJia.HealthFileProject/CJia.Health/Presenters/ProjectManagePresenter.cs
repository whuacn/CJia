using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class ProjectManagePresenter : CJia.Health.Tools.Presenter<Models.ProjectManageModel, Views.IProjectManageView>
    {
        public ProjectManagePresenter(Views.IProjectManageView view)
            : base(view)
        {
            view.OnQueryProject += view_QueryProject;
            view.OnUpdateProject += view_UpdateProject;
            view.OnInsertProject += view_InsertProject;
            view.OnDeleteProject += view_DeleteProject;
        }

        void view_DeleteProject(object sender, Views.ProjectKeyWordArg e)
        {
            bool IsDelete = Model.DeleteProject(e.UserID, e.ProId);
            if (IsDelete)
            {
                View.ShowMessage("删除成功");
            }
            else
            {
                View.ShowWarning("删除失败");
            }
        }

        void view_InsertProject(object sender, Views.ProjectKeyWordArg e)
        {
            bool IsInsert = Model.InsertProject(e.ProjectName, e.ProNo, e.ProPinyin, e.UserID, e.isPrint, e.shortKey,e.isLook,e.isExport);
            if (IsInsert)
            {
                View.ShowMessage("添加项目成功");
            }
            else
            {
                View.ShowWarning("添加失败");
            }
        }

        void view_UpdateProject(object sender, Views.ProjectKeyWordArg e)
        {
            bool IsUpdate = Model.UpdateProject(e.ProjectName, e.ProNo, e.ProPinyin, e.UserID, e.ProId, e.isPrint, e.shortKey,e.isLook,e.isExport);
            if (IsUpdate)
            {
                View.ShowMessage("修改成功");
            }
            else
            {
                View.ShowWarning("修改失败");
            }
        }

        void view_QueryProject(object sender, Views.ProjectKeyWordArg e)
        {
            DataTable dtProject = Model.QueryProject(e.KeyWord);
            View.ExeBindProject(dtProject);
        }
    }
}
