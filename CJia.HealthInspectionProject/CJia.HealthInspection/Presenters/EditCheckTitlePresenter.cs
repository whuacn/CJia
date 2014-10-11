using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditCheckTitlePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditCheckTitleModel, Views.IEditCheckTitle>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public EditCheckTitlePresenter(Views.IEditCheckTitle view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnBigChanged += view_OnBigChanged;
            view.OnMidChanged += view_OnMidChanged;
            view.OnGetTitleBySmallType += view_OnGetTitleBySmallType;
        }

        void view_OnGetTitleBySmallType(object sender, Views.EditCheckTitleArgs e)
        {
            View.ExeBindTitle(Model.QueryTitleBySmallType(e.organ, e.BigTempID, e.MidTempID, e.SmallTempID));
        }

        void view_OnMidChanged(object sender, Views.EditCheckTitleArgs e)
        {
            View.ExeBindSmallTemptype(Model.GetSmallTemplateByMid(e.MidTempID));
        }

        void view_OnBigChanged(object sender, Views.EditCheckTitleArgs e)
        {
            View.ExeBindMidTempType(Model.GetMidTemplateByBig(e.BigTempID));
        }

        void view_OnInit(object sender, Views.EditCheckTitleArgs e)
        {
            View.ExeBindBigTempType(Model.GetBigTemplate());
        }
    }
}
