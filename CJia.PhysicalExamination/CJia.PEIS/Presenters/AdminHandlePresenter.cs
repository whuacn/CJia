using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Presenters
{
    public class AdminHandlePresenter : CJia.PEIS.Tools.Presenter<Models.AdminHandleModel, Views.IAdminHandleView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AdminHandlePresenter(Views.IAdminHandleView view)
            : base(view)
        {
            view.OnLoad += view_OnLoad;
            view.OnSave += view_OnSave;
            view.OnGridClick += view_OnGridClick;
            view.OnDelete += view_OnDelete;
            view.OnResetPassword += view_OnResetPassword;
            view.OnCheck += view_OnCheck;
            view.OnBtnSearchClick += view_OnBtnSearchClick;
        }

        void view_OnBtnSearchClick(object sender, Views.AdminHandleEventArgs e)
        {
            DataTable data = Model.GetUsersByKeys(e.isShowNoUse, e.Keys);
            View.ExeBindAllUser(data);
        }

        void view_OnLoad(object sender, Views.AdminHandleEventArgs e)
        {
            DataTable genderData = Model.GetGender();
            DataTable userData = Model.GetAllUsers(e.isShowNoUse);
            DataTable userStatusData = Model.GetUserStatus();
            View.ExeInitialize(genderData, userData, userStatusData);
        }

        void view_OnCheck(object sender, Views.AdminHandleEventArgs e)
        {
            DataTable data = Model.GetAllUsers(e.isShowNoUse);
            View.ExeBindAllUser(data);
        }

        void view_OnResetPassword(object sender, Views.AdminHandleEventArgs e)
        {
            bool bol = Model.ResetPasswordByUserID(int.Parse(User.UserData.Rows[0]["user_id"].ToString()), e.UserID);
            if (bol)
            {
                View.ShowMessage("用户【" + e.UserNo + "|" + e.UserName + "】密码初始化成功,密码为8888");
            }
        }

        void view_OnDelete(object sender, Views.AdminHandleEventArgs e)
        {
            Model.DeleteUserByUserID(int.Parse(User.UserData.Rows[0]["user_id"].ToString()), e.UserID);
        }

        void view_OnGridClick(object sender, Views.AdminHandleEventArgs e)
        {
            DataTable userData = Model.GetUserByUserID(e.UserID);
            View.ExeBindUserInfo(userData);
        }

        void view_OnSave(object sender, Views.AdminHandleEventArgs e)
        {
            if (e.UserID == 0)
            {
                AddUser(e);
            }
            else
            {
                ModifyUser(e);
            }
        }

        #region 内部调用方法
        /// <summary>
        /// 判断是否存在此用户编号
        /// </summary>
        /// <param name="userNO">用户编号</param>
        /// <returns></returns>
        private bool isExistUserNO(string userNO)
        {
            DataTable data = Model.GetUserByUserNO(userNO);
            if (data != null) return true;
            else return false;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="e"></param>
        private void AddUser(Views.AdminHandleEventArgs e)
        {
            if (isExistUserNO(e.UserNo))
            {
                View.ShowMessage("【" + e.UserNo + "】工号存在");
                View.ExeTxtUserNOFocus();
                return;
            }
            bool bol = Model.AddUser(e, int.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            if (bol)
            {
                View.ShowMessage("用户【" + e.UserNo + "|" + e.UserName + "】添加成功");
            }
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="e"></param>
        private void ModifyUser(Views.AdminHandleEventArgs e)
        {
            if (e.UserNo != e.OldUserNo)
            {
                if (isExistUserNO(e.UserNo))
                {
                    View.ShowMessage("【" + e.UserNo + "】工号存在");
                    View.ExeTxtUserNOFocus();
                    return;
                }
            }
            bool bol = Model.ModifyUser(e, int.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            if (bol)
            {
                View.ShowMessage("用户【" + e.UserNo + "|" + e.UserName + "】信息修改成功");
            }
        }
        #endregion
    }
}
