using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Presenters
{
    public class UserManagePresenter : CJia.Parking.Tools.Presenter<Models.UserManageModel,Views.IUserManageView>
    {
        public UserManagePresenter(Views.IUserManageView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnUserSave += view_OnUserSave;
            view.OnUserDelete += view_OnUserDelete;
            view.OnUserFocusedRowChanged += view_OnUserFocusedRowChanged;
        }

        /// <summary>
        /// 点击用户Grid勾选用户相应角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUserFocusedRowChanged(object sender, Views.UserArgs e)
        {
            e.TableUserRole = Model.QueryUserRoleByUserId(e.UserId); // 用户拥有角色
            View.ExeSetRoleChecked(Model.QueryRole()); // 全部角色
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.UserArgs e)
        {
            BindChkRole();
            BindGridUser();
        }

        #region 【角色】
                 
        /// <summary>
        /// 删除角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnRoleDelete(object sender, Views.UserArgs e)
        {
            long updateBy = (long)User.UserData.Rows[0]["user_id"];
            DataTable dt = Model.QueryIsExistUsingRoleIdWhenDelete(e.RoleId);
            if (dt != null && dt.Rows.Count > 0)
            {
                Message.Show("请先删除拥有【" + e.RoleName + "】权限用户");
                return;
            }
            else
            {
                if (Message.ShowQuery("确定要删除【" + e.RoleName + "】") == Message.Result.Ok)
                {
                    Model.DeleteRole(updateBy, e.RoleId);
                    BindChkRole();
                }
            }
        }
        #endregion

        #region 【用户】
        /// <summary>
        /// 绑定角色
        /// </summary>
        void BindChkRole()
        {
           View.ExeCheckRole(Model.QueryRole());
        }

        /// <summary>
        /// 绑定Grid用户
        /// </summary>
        void BindGridUser()
        {
            View.ExeBindGridUser(Model.QueryUser());
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUserSave(object sender, Views.UserArgs e)
        {
            long userSeq = Model.QueryUserSeq();
            long createBy = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsExistSameUserNo = Model.QueryIsExistSameUserNo(e.UserNo);
            if (dtIsExistSameUserNo != null && dtIsExistSameUserNo.Rows.Count > 0)
            {
                if (Convert.ToInt64(dtIsExistSameUserNo.Rows[0]["user_id"]) != e.UserId)
                {
                    Message.Show("存在相同用户工号，请修改！");
                    return;
                }
            }
            if (e.UserSaveStatus == "add")
            {
                
                if (Message.ShowQuery("确定保存【" + e.UserName + "】") == Message.Result.Ok)
                {
                    if (Model.InsertUser(userSeq, e.UserName, e.UserNo, createBy))
                    {
                        for (int i = 0; i < e.ListRoleId.Count; i++)
                        {
                            Model.InsertUserRole(userSeq, e.ListRoleId[i], createBy);
                        }
                    }
                }
            }
            if (e.UserSaveStatus == "update")
            {
                if (Message.ShowQuery("确定修改【" + e.OldUserName + "】") == Message.Result.Ok)
                {
                    Model.DeleteUserRole(e.UserId);
                    Model.UpdateUser(e.UserName, e.UserNo, e.Password, createBy, e.UserId); 
                    for (int i = 0; i < e.ListRoleId.Count; i++)
                    {
                        Model.InsertUserRole(e.UserId, e.ListRoleId[i], createBy);
                    }
                }
                
            }
            BindGridUser();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUserDelete(object sender, Views.UserArgs e)
        {
            long updateBy = (long)User.UserData.Rows[0]["user_id"];
            if (Message.ShowQuery("确定删除【" + e.OldUserName + "】") == Message.Result.Ok)
            {
                if (Model.DeleteUserRole(e.UserId))
                {
                    Model.DeleteUser(e.UserId);
                }
            }
            BindGridUser();
        }
        #endregion

    }
}
