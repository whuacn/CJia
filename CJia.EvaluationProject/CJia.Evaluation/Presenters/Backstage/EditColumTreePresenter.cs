using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class EditColumTreePresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.EditColumTreeModel,Views.Backstage.IEditColumTree>
    {
        public EditColumTreePresenter(Views.Backstage.IEditColumTree view)
            : base(view)
        {
            view.OnQueryColumnNode += view_OnQueryColumnNode;
            view.OnUpdateColumnTree += view_OnUpdateColumnTree;
        }

        void view_OnUpdateColumnTree(object sender, Views.Backstage.EditColumTreeArgs e)
        {
            bool isUpdate = Model.UpdateColumnTree(e.ColumnTreeName, e.ColumnTreeDescript, e.ColumnNo, e.ColumnGrade, e.CheckWay, e.Score, e.ScoreStandard, e.UserID, e.ColumnID, e.DutyDept, e.HelpDept);
            View.ExeReturnUpdateMsg(isUpdate);
        }

        void view_OnQueryColumnNode(object sender, Views.Backstage.EditColumTreeArgs e)
        {
            DataTable dtColumnNode = Model.QueryColumnNode(e.ColumnID);
            DataTable dtAllDept = Model.QueryAllDept();
            DataTable dtDutyDept = Model.QueryDutyDept(e.ColumnID);
            DataTable dtHelpDept = Model.QueryHelpDept(e.ColumnID);
            View.ExeBindColumnNode(dtColumnNode, dtAllDept, dtDutyDept, dtHelpDept);
        }
    }
}
