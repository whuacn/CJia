using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class AddDeptPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.AddDeptModel,Views.IAddDept>
    {
        public AddDeptPresenter(Views.IAddDept view)
            : base(view)
        {
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AddDeptArgs e)
        {
            if (Model.IsExistSameDeptNo(e.DeptNo, e.OrganId))
            {
                View.ExeMessage("您所在组织存在相同部门编号,请修改...");
                return;
            }
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.DeptNo);
            sqlParams.Add(e.DeptName);
            sqlParams.Add(e.OrganId);
            sqlParams.Add(e.UserId);
            if (Model.InsertDept(sqlParams))
            {
                View.ExeMessage("添加成功！");
            }
            else
            {
                View.ExeMessage("添加失败,请联系管理员...");
            }
        }
    }
}
