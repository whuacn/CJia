using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class TemplateManagePresenter:Tools.PresenterPage<Models.TemplateManageModel,Views.ITemplateManage>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public TemplateManagePresenter(Views.ITemplateManage view)
            : base(view)
        {
            view.OnInitPage += view_OnInitPage;
            view.OnTreeClick += view_OnTreeClick;
            view.OnDeleteTemp += view_OnDeleteTemp;
        }

        void view_OnDeleteTemp(object sender, Views.TemplateManageArgs e)
        {
            bool bol = Model.DeleteTemplate(e.TemplateID);
            View.ExeIsSuccess(bol);
        }

        void view_OnTreeClick(object sender, Views.TemplateManageArgs e)
        {
            if (e.TypeID == "1")
            {
                DataTable data = Model.QueryTemplateByOrgan(e.User.Rows[0]["organ_id"].ToString());
                View.ExeBindTemplate(data);
            }
            else
            {
                DataTable data = Model.GetTemplateByOrganIdAndType(e.User.Rows[0]["organ_id"].ToString(), e.TypeID);
                View.ExeBindTemplate(data);
            }
        }

        void view_OnInitPage(object sender, EventArgs e)
        {
            DataTable data = Model.GetTemplateType();
            View.ExeBindTree(data);
        }
    }
}
