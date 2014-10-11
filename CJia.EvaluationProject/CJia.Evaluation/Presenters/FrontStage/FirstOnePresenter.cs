using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Evaluation.Presenters.FrontStage
{
    public class FirstOnePresenter : CJia.Evaluation.Tools.PresenterPage<Models.FrontStage.FirstOneModel, Views.FrontStage.IFirstOne>
    {
        public FirstOnePresenter(Views.FrontStage.IFirstOne view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnGetTreeByPatID += view_OnGetTreeByPatID;
            view.OnGetZLByID += view_OnGetZLByID;
            view.OnGetAnotherZLByID += view_OnGetAnotherZLByID;
            view.OnGetParentByID += view_OnGetParentByID;
        }

        void view_OnGetParentByID(object sender, Views.FrontStage.FirstOneArgs e)
        {
            DataTable data = Model.GetParentByID(e.treeID);
            View.ExeBindParentData(data);
        }

        void view_OnGetAnotherZLByID(object sender, Views.FrontStage.FirstOneArgs e)
        {
            DataTable data = Model.GetZLByID(e.treeID);
            View.ExeBindAnotherZLData(data);
        }

        void view_OnGetZLByID(object sender, Views.FrontStage.FirstOneArgs e)
        {
            DataTable data = Model.GetZLByID(e.treeID);
            View.ExeBindZLData(data);
        }

        void view_OnGetTreeByPatID(object sender, Views.FrontStage.FirstOneArgs e)
        {
            DataTable data = Model.GetTreeByPatID(e.treeID);
            if (data != null && data.Rows.Count > 0)
                View.ExeBindABCData(data, null);
            else
            {
                DataTable selfData = Model.GetTreeBySelfID(e.treeID);
                View.ExeBindABCData(data, selfData);
            }
        }

        void view_OnInit(object sender, Views.FrontStage.FirstOneArgs e)
        {
            DataTable data1 = Model.GetTreeDataByID(e.treeID);
            DataTable data2 = Model.GetTreePatDataByID(e.treeID);
            View.ExeBindData(data1, data2);
        }

    }
}
