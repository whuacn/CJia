using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditRolePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditRoleModel,Views.IEditRole>
    {
        public EditRolePresenter(Views.IEditRole view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditRoleArgs e)
        {
            bool isSuccess = false;
            string organId = e.User.Rows[0]["organ_id"].ToString();
            // 查询修改新名称是否在库中存在相同名称
            if (Model.QueryExistSameRoleNameWhenUpdate(e.RoleId, e.RoleName,organId))
            {
                View.ExeMessageBox("存在相同角色名称，请修改...",false);
                return;
            }
            string userId = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                // 修改角色表信息
                if (Model.UpdateRole(trans.ID, e.RoleName, userId, e.RoleId))
                {
                    // 删除该角色所有权限
                    bool a = Model.DeleteRoleFunctionByRoleId(trans.ID, e.RoleId, userId);
                    
                    // 插入角色功能表
                    bool b = Model.InsertRoleFunction(trans.ID, e.RoleId, e.ListFunction, userId);
                    isSuccess = true;
                }
                trans.Complete();
            }
            if (isSuccess)
            {
                View.ExeMessageBox("修改成功！",true);
            }
            else
            {
                View.ExeMessageBox("修改失败,请联系管理员...",false);
            }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.EditRoleArgs e)
        {
            BindControl(e);
            BindTree(e);
        }

        /// <summary>
        /// 根据roleId查询绑定输入框值和勾选树中所拥有功能
        /// </summary>
        void BindControl(Views.EditRoleArgs e)
        {
            View.ExeBindControl(Model.QueryRoleNameById(e.RoleId));
        }

        /// <summary>
        /// 绑定树
        /// </summary>
        void BindTree(Views.EditRoleArgs e)
        {
            View.ExeBindTree(Model.QueryUserIdOwnFunction(e.User.Rows[0]["user_id"].ToString()), Model.QueryRoleFunctionByRoleId(e.RoleId));
        }
    }
}
