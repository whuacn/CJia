using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class DataInputPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.DataInputModel,Views.Backstage.IDataInput>
    {
        public DataInputPresenter(Views.Backstage.IDataInput view)
            : base(view)
        {
            view.OnInitColumnTree += view_OnInitColumnTree;
            view.OnQueryDataByColumnId += view_OnQueryDataByColumnId;
            view.OnDeleteData += view_OnDeleteData;
        }

        void view_OnDeleteData(object sender, Views.Backstage.DataInputArgs e)
        {
            bool isDelete = Model.DeleteData(e.UserId, e.DataID);
            View.ExeReturnDeleteMsg(isDelete);
        }

        void view_OnQueryDataByColumnId(object sender, Views.Backstage.DataInputArgs e)
        {
            DataTable dtData = Model.QueryDataByColumnId(e.ColumnID);
            View.ExeBindData(dtData);
        }

        void view_OnInitColumnTree(object sender, Views.Backstage.DataInputArgs e)
        {
            DataTable dtColumnTree = Model.QueryColumTree(e.UserId);
            View.ExeBindColumnTree(dtColumnTree);
        }
    }
}
