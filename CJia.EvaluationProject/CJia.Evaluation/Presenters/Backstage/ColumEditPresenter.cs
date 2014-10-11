using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class ColumEditPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.ColumEditModel,Views.Backstage.IColumEdit>
    {
        public ColumEditPresenter(Views.Backstage.IColumEdit view)
            : base(view)
        {
            view.OnQueryColumTree += view_OnQueryColumTree;
            view.OnQueryColumnLevel += view_OnQueryColumnLevel;
            view.OnDeleteColumnTree += view_OnDeleteColumnTree;
        }

        void view_OnDeleteColumnTree(object sender, Views.Backstage.ColumEditArgs e)
        {
            bool isDelete = Model.DeleteColumn(e.UserID, e.ColumnID);
            View.ExeReturnDeleteMsg(isDelete);
        }

        void view_OnQueryColumnLevel(object sender, Views.Backstage.ColumEditArgs e)
        {
            int ColumnLevel = Model.QueryColumnLevel(e.ColumnID);
            View.ExeReturnColumnLevel(ColumnLevel);
        }

        void view_OnQueryColumTree(object sender, Views.Backstage.ColumEditArgs e)
        {
            DataTable dt = Model.QueryColumTree();
            //DataRow dr = dt.NewRow();
            //dr["COLUM_TREE_ID"] = "0";
            //dr["COLUM_TREE_NAME"] = "慧软三级评审综合";
            View.ExeBindColumTree(dt);
        }
    }
}
