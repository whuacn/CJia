using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class RoleManagePresenter : CJia.Health.Tools.Presenter<Models.RoleManageModel,Views.IRoleManageView>
    {
        public RoleManagePresenter(Views.IRoleManageView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnAdd += view_OnAdd;
            view.OnUpdate += view_OnUpdate;
            view.OnDelete += view_OnDelete;
            view.OnFocusedRowChanged += view_OnFocusedRowChanged;
            view.OnSearch += view_OnSearch;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.RoleManageArgs e)
        {
            BindRoleFunc();
            BindGridRole();
        }

        #region【绑定方法】
        /// <summary>
        /// 查询功能角色表绑定选择框
        /// </summary>
        void BindRoleFunc()
        {
            View.ExeBindRoleFunc(Model.QueryRoleFuncUserType());
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        void BindGridRole()
        {
            View.ExeBindGridRole(Model.QueryRoleBindGrid());
        }
        #endregion

        #region【事件响应】

        /// <summary>
        /// 新增角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnAdd(object sender, Views.RoleManageArgs e)
        {
            DataTable dtExistRoleName = Model.IsExistSameRole(e.RoleName);
            if(dtExistRoleName != null)
            {
                if(dtExistRoleName.Rows.Count > 0)
                {
                    Message.Show("库中已存在【" + e.RoleName + "】请修改！");
                    return;
                }
            }
            
            long roleId = Model.QueryNextRoleSeq();
            // 插入角色表
            Model.InsertRole(roleId,e.RoleName);
            // 如果选择角色则想功能角色表插入数据
            if (e.ListFunctionId.Count != 0)
            {
                // 插入角色功能表
                Model.InsertRoleFunction(roleId, e.RoleName, e.ListFunctionId);
            }
            BindGridRole();
        }

        /// <summary>
        /// 修改角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUpdate(object sender, Views.RoleManageArgs e)
        {
            DataTable dtExistSameName = Model.QueryIsExistSameRoleNameWhenUpdateRole(e.RoleId,e.RoleName);
            if (dtExistSameName.Rows.Count > 0)
            {
                Message.Show("库中已存在【"+e.RoleName+"】，请修改！");
                return;
            }
            else
            {
                if (Model.UpdateRoleByRoleId(e.RoleId, e.RoleName))
                {
                    Model.DeleteRoleFunctionByRoleId(e.RoleId);
                    if (e.ListFunctionId.Count > 0)
                    {
                        Model.InsertRoleFunction(e.RoleId, e.RoleName, e.ListFunctionId);
                    }
                }
                BindGridRole();
            }
           
        }

        /// <summary>
        /// 删除角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDelete(object sender, Views.RoleManageArgs e)
        {
            //DataTable dtCount = Model.QueryRoleFunction(e.RoleId);
            if (e.RoleFunctionId != 0)
            {
                Model.DeleteRoleFunctionByRoleFunctionId(e.RoleFunctionId);
            }
            //if (dtCount.Rows.Count == 1)
            //{
                Model.DeleteRoleByRoleId(e.RoleId);
            //}
            BindGridRole();
        }

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnFocusedRowChanged(object sender, Views.RoleManageArgs e)
        {
            // 所选择用户拥有功能角色
            e.TableFunction = Model.QueryRoleExistFunctionId(e.RoleName);
            // 所有功能角色
            View.ExeSetRoleChecked(Model.QueryRoleFuncUserType());
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.RoleManageArgs e)
        {
            View.ExeBindGridRole(Model.QuerySearchRoleByKeyWord(e.KeyWord));
        }
        #endregion
    }
}
