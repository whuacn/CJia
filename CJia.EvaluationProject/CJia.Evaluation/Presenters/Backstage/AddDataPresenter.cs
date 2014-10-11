using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class AddDataPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.AddDataModel,Views.Backstage.IAddData>
    {
        public AddDataPresenter(Views.Backstage.IAddData view)
            : base(view)
        {
            view.OnInitDataType += view_OnInitDataType;
            view.OnAddData += view_OnAddData;
        }

        void view_OnAddData(object sender, Views.Backstage.AddDataArgs e)
        {
            bool isInsert = Model.InsertData(e.DataTitle, e.DataContent, e.DataType, e.UserID, e.ColumnTreeId);
            View.ExeReturnMsg(isInsert);
        }

        void view_OnInitDataType(object sender, Views.Backstage.AddDataArgs e)
        {
            DataTable dtDataType = Model.QueryDataType();
            View.ExeBindDataType(dtDataType);
        }
    }
}
