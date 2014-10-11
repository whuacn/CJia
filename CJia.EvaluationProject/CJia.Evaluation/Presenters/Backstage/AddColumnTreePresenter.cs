using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class AddColumnTreePresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.AddColumnTreeModel,Views.Backstage.IAddColumnTree>
    {
        public AddColumnTreePresenter(Views.Backstage.IAddColumnTree view)
            : base(view)
        {
            view.OnAddColumnTree += view_OnAddColumnTree;
            view.OnInsertColumnTree += view_OnInsertColumnTree;
            view.OnInitDept += view_OnInitDept;
        }

        void view_OnInitDept(object sender, Views.Backstage.AddColumnTreeArgs e)
        {
            DataTable dtDept = Model.QueryAllDept();
            View.ExeBindDeptTree(dtDept);
        }

        void view_OnInsertColumnTree(object sender, Views.Backstage.AddColumnTreeArgs e)
        {
            bool bl = Model.InsertColumntree(e.ColumnTreeName, e.ColumnTreeDescript, e.ColumnNo, e.ColumnGrade, e.ParentColumnTreeId, e.UserID, e.CheckWay,e.Score,e.ScoreStandard,e.DutyDept,e.HelpDept);
            View.ExeShowAddResult(bl);
        }

        void view_OnAddColumnTree(object sender, Views.Backstage.AddColumnTreeArgs e)
        {
            bool bl = Model.AddColumnTree(e.ColumnTreeName, e.ColumnTreeDescript, e.ColumnNo, e.ColumnGrade, e.ParentColumnTreeId, e.UserID, e.CheckWay, e.Score, e.ScoreStandard, e.DutyDept, e.HelpDept);
            View.ExeShowAddResult(bl);
        }
    }
}
