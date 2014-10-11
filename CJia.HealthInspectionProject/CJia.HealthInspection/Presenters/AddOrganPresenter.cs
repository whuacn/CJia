using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public  class AddOrganPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.AddOrganModel,Views.IAddOrgan>
    {
        public AddOrganPresenter(Views.IAddOrgan view)
            : base(view)
        {
            view.OnInit += View_OnInit;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.AddOrganArgs e)
        {
            //View.ExeDropArea(Model.QueryAllArea());
            View.ExeBindTree(Model.QueryAllArea());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AddOrganArgs e)
        {
            if (Model.QueryExistSameOrganId(e.OrganNo))
            {
                View.ExeMessageBox("存在相同组织编号，请修改...");
                return;
            }
            if (Model.InsertOrgan(e.OrganNo, e.OrganName, e.UserId, e.AreaId))
            {
                View.ExeMessageBox("保存成功！");
            }
            else
            {
                View.ExeMessageBox("修改失败,请联系管理员...");
            }
        }
    }
}
