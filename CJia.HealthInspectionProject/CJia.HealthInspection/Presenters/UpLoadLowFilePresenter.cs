using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class UpLoadLowFilePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.UpLoadLowFileModel, Views.IUpLoadLowFile>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public UpLoadLowFilePresenter(Views.IUpLoadLowFile view)
            : base(view)
        {
            View.OnInit += View_OnInit;
            View.OnInsertLowFile += View_OnInsertLowFile;
        }

        void View_OnInsertLowFile(object sender, Views.UpLoadLowFileArgs e)
        {
            bool IsInsert = Model.InsertLowFile(e.LowName, e.LowTypeId, e.WordFilepath, Convert.ToInt64(User.UserData.Rows[0]["USER_ID"]), e.WordFileName, e.HtmlFileName, e.HtmlFilepath);
            View.ExeShowLowIsInsert(IsInsert);
        }

        void View_OnInit(object sender, Views.UpLoadLowFileArgs e)
        {
            DataTable dtLowTemplate = Model.GetLowTemplate();
            View.ExeBindLowTemp(dtLowTemplate);
        }
    }
}
