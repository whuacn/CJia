using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditOrganPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditOrganModel,Views.IEditOrgan>
    {
        public EditOrganPresenter(Views.IEditOrgan view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
        }
                
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.EditOrganArgs e)
        {
            View.ExeBindControl(Model.QueryOrganById(e.OrganId));
            View.ExeBindTree(Model.QueryAllArea());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditOrganArgs e)
        {
            if (Model.QueryExistSameOrganId(e.OrganId, e.OrganNo))
            {
                View.ExeMessageBox("存在相同组织编号，请修改...",false);
                return;
            }
            if (Model.UpdateOrganById(e.OrganNo, e.OrganName, e.AreaId, e.UserId, e.OrganId))
            {
                View.ExeMessageBox("保存成功！",true);
            }
            else
            {
                View.ExeMessageBox("修改失败,请联系管理员",false);
            }
        }
    }
}
