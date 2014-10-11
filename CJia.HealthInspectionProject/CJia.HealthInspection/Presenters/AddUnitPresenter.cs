using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class AddUnitPresenter:Tools.PresenterPage<Models.AddUnitModel,Views.IAddUnit>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AddUnitPresenter(Views.IAddUnit view)
            : base(view)
        {
            view.OnInitPage += view_OnInitPage;
            view.OnSave += view_OnSave;
        }

        void view_OnSave(object sender, EventArgs e)
        {
            bool bol = Model.AddUnit(User.UserData.Rows[0]["USER_ID"].ToString());
            View.ExeIsSuccess(bol);
        }

        void view_OnInitPage(object sender, EventArgs e)
        {
            DataTable unitType = Model.GetTypeValue("UNIT_TYPE");
            DataTable IDType = Model.GetTypeValue("ID_TYPE");
            DataTable ecoType = Model.GetTypeValue("ECO_TYPE");
            DataTable applyType = Model.GetTypeValue("APPLY_TYPE");
            View.ExeBindType(unitType, IDType, ecoType, applyType);
        }
    }
}
