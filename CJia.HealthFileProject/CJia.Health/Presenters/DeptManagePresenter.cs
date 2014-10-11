using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class DeptManagePresenter : CJia.Health.Tools.Presenter<Models.DeptManageModel,Views.IDeptManageView>
    {
        public DeptManagePresenter(Views.IDeptManageView view)
            : base(view)
        {
            view.OnQueryDept += view_OnQueryDept;
            view.OnUpdateDept += view_OnUpdateDept;
            view.OnAddDept += view_OnAddDept;
            view.OnDeleteDept += view_OnDeleteDept;
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteDept(object sender, Views.DeptArgs e)
        {
            bool IsDeleteDept = Model.DeleteDept(e.UserID, e.DeptId);
            if(IsDeleteDept)
            {
                View.ShowMessage("删除成功");
            }
            else
            {
                View.ShowWarning("删除失败");
            }
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnAddDept(object sender, Views.DeptArgs e)
        {
            bool IsAddDept = Model.AddDept(e.DeptName, e.UserID, e.DeptNo, e.DeptPinYin);
            if (IsAddDept)
            {
                View.ShowMessage("添加成功");
            }
            else
            {
                View.ShowWarning("添加失败");
            }
        }

        /// <summary>
        /// 修改科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUpdateDept(object sender, Views.DeptArgs e)
        {
            bool IsUpdateDept = Model.UpdateDept(e.DeptNo, e.DeptName, e.DeptPinYin, e.UserID, e.DeptId);
            if (IsUpdateDept)
            {
                View.ShowMessage("修改成功");
            }
            else
            {
                View.ShowWarning("修改失败");
            }
        }
        
        /// <summary>
        /// 查询科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryDept(object sender, Views.DeptArgs e)
        {
            DataTable dtDept = Model.QueryDept(e.KewWord);
            View.ExeBindDept(dtDept);
        }
    }
}
