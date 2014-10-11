using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditDeptPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditDeptModel,Views.IEditDept>
    {
        public EditDeptPresenter(Views.IEditDept view)
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
        void view_OnInit(object sender, Views.EditDeptArgs e)
        {
            View.ExeBindControl(Model.QueryDeptById(e.DeptId));
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditDeptArgs e)
        {
            if (Model.QueryIsExistSameDeptNo(e.DeptNo, e.DeptId,e.OrganId))
            {
                View.ExeMessageBox("存在相同部门编号,请修改...",false);
                return;
            }
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.DeptNo);
            sqlParams.Add(e.DeptName);
            sqlParams.Add(e.OrganId);
            sqlParams.Add(e.User.Rows[0]["user_id"].ToString());
            sqlParams.Add(e.DeptId);
            if (Model.UpdateDept(sqlParams))
            {
                View.ExeMessageBox("保存成功！",true);
            }
            else
            {
                View.ExeMessageBox("修改失败,请联系管理员...",false);
            }
        }
    }
}
