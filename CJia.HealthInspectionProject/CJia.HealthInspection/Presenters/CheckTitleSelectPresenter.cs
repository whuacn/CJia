using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class CheckTitleSelectPresenter:CJia.HealthInspection.Tools.PresenterPage<Models.CheckTitleSelectModel, Views.ICheckTitleSelect>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public CheckTitleSelectPresenter(Views.ICheckTitleSelect view)
            : base(view)
        {
            view.OnInitTree += view_OnInitTree;
            view.OnTreeClick += view_OnTreeClick;
            view.OnDelete += view_OnDelete;
        }

        void view_OnDelete(object sender, Views.CheckTitleSelectArgs e)
        {
            bool bol = Model.DeleteCheckTitle(User.UserData.Rows[0]["USER_ID"].ToString(), e.CheckTitleID);
            View.ExeIsDelete(bol);
        }

        void view_OnTreeClick(object sender, Views.CheckTitleSelectArgs e)
        {
            if (e.TemplateID == "1")
            {
                DataTable data = Model.GetAllCheckTitle(e.OrganId);
                View.ExeBindCheckTitle(data);
            }
            else
            {
                DataTable data = Model.GetCheckTitleByType(e.TemplateID,e.OrganId);
                View.ExeBindCheckTitle(data);
            }
        }

        void view_OnInitTree(object sender, EventArgs e)
        {
            DataTable data = Model.GetTemplate();
            View.ExeBindTree(data);
        }
    }
}
