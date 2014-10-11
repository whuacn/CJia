using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class EditDataPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.EditDataModel, Views.Backstage.IEditData>
    {
        public EditDataPresenter(Views.Backstage.IEditData view)
            : base(view)
        {
            view.OnInitDataType += view_OnInitDataType;
            view.OnQueryDataById += view_OnQueryDataById;
            view.OnUpdateData += view_OnUpdateData;
        }

        void view_OnUpdateData(object sender, Views.Backstage.EditArgs e)
        {
            bool isUpdate = Model.UpdateData(e.DataTitle, e.DataContent, e.DataType, e.UserId, e.DataID);
            View.ExeReturnMsg(isUpdate);
        }

        void view_OnQueryDataById(object sender, Views.Backstage.EditArgs e)
        {
            DataTable dtData = Model.QueryDataByID(e.DataID);
            View.ExeBindData(dtData);
        }

        void view_OnInitDataType(object sender, Views.Backstage.EditArgs e)
        {
            DataTable dtDataType = Model.QueryDataType();
            View.ExeBindDataType(dtDataType);
        }
    }
}
