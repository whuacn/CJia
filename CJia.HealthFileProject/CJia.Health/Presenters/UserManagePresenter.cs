using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class UserManagePresenter : CJia.Health.Tools.Presenter<Models.UserManageModel, Views.IUserManageView>
    {
        public UserManagePresenter(Views.IUserManageView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnInsertUser += view_OnInsertUser;
            view.OnQueryDept += view_OnQueryDept;
            view.OnUpdateUser += view_OnUpdateUser;
            view.OnDeleteUser += view_OnDeleteUser;
            view.OnFocusedRowChanged += view_OnFocusedRowChanged;
            view.OnSearch += view_OnSearch;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.UserArgs e)
        {
            View.ExeBindDept(Model.QueryDept());
            BindUserRole();
            BindDoctorDescript();
            QueryGridUser();
            
        }

        /// <summary>
        /// 模糊查询科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryDept(object sender, Views.UserArgs e)
        {
            View.ExeBindDept(Model.QueryDeptBySearch(e.KeyWord));
        }

        /// <summary>
        /// 绑定用户网格
        /// </summary>
        void QueryGridUser()
        {
            View.ExeBindGridUser(Model.QueryUserByAll());
        }

        /// <summary>
        /// 绑定角色用户
        /// </summary>
        void BindUserRole()
        {
            View.ExeBindRole(Model.QueryUserRole());
        }

        /// <summary>
        /// 绑定医生职称
        /// </summary>
        void BindDoctorDescript()
        {
            View.ExeBindDoctorDescript(Model.QueryDoctorDescript());
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInsertUser(object sender, Views.UserArgs e)
        {
            if (Model.QueryIsExistSameUserNo(e.UserNo) == e.UserNo)
            {
                Message.Show("存在相同用户编号,请修改！");
                e.IsInsertSuccess = false;
                return;
            }
            if (Message.ShowQuery("确定插入" + e.UserName + "信息？") == Message.Result.Ok)
            {
                long userId = Model.QueryNextSequenceFromUser();
                // 添加用户
                bool isSuccessAddUser = Model.AddUser(userId,e.UserNo, e.UserName, e.DeptId,e.DoctorDescript);
                if (e.ListRoleId.Count != 0)
                {
                    // 添加用户角色表
                    Model.AddUserRole(userId, e.UserName, e.ListRoleId, e.ListRoleName);
                }
                QueryGridUser();
            }
        }

        /// <summary>
        /// 修改用户表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUpdateUser(object sender, Views.UserArgs e)
        {
            if (Message.ShowQuery("确定要修改" + e.ExistName + "?") == Message.Result.Ok)
            {
                // 修改用户表
                 Model.UpdateUser(e.UserNo, e.UserName, e.DeptId, e.UserId,e.DoctorDescript);
                // 修改前先删除用户角色表
                 Model.DeleteUserRole(e.UserId);
                 if (e.ListRoleId.Count > 0)
                 {
                     // 插入用户角色表
                     Model.AddUserRole(e.UserId, e.UserName, e.ListRoleId, e.ListRoleName);
                 }
            }
            QueryGridUser();
        }

        /// <summary>
        /// 删除用户表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteUser(object sender, Views.UserArgs e)
        {
            if (Message.ShowQuery("确定要删除" + e.ExistName + "?") == Message.Result.Ok)
            {
                // 修改前先删除用户角色表
                Model.DeleteUserRole(e.UserId);
                Model.DeleteUser(e.UserId);
                QueryGridUser();
            }
        }

        /// <summary>
        /// Grid行改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnFocusedRowChanged(object sender, Views.UserArgs e)
        {
            e.TableUserRole = Model.QueryUserRoleByUserId(e.UserId);
            View.ExeSetRoleChecked(Model.QueryUserRole());
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.UserArgs e)
        {
            DataTable dt = Model.QueryBySearchGrid(e.KeyWord);
           View.ExeBindGridUser(Model.QueryBySearchGrid(e.KeyWord));
        }
    }
}
