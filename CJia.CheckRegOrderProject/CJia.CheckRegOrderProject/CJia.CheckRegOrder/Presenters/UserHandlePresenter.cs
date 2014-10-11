using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class UserHandlePresenter : CJia.Presenter<Views.IUserHandleView>
    {
        private Models.UserHandleModel Model
        {
            get;
            set;
        }
        public UserHandlePresenter(Views.IUserHandleView view)
            : base(view)
        {
            Model = new Models.UserHandleModel();
        }
        protected override void OnViewSet()
        {
            View.OnSaveBtn += View_OnSaveBtn;
            View.OnAddUser += View_OnAddUser;
        }

        void View_OnAddUser(object sender, EventArgs e)
        {
            if (IsExistUser(View.UserNO))
            {
                if (Model.AddUser(View.UserNO, View.UserName, View.IsAdmin, User.UserID))
                {
                    View.CloseForm();
                }
            }
            else
            {
                View.ShowMessage("用户工号不能重复");
                View.TxtUserNOFocus();
            }
        }

        void View_OnSaveBtn(object sender, EventArgs e)
        {
            if (View.UserNO != View.OldUserNO)
            {
                if (!IsExistUser(View.UserNO))
                {
                    View.ShowMessage("用户工号不能重复");
                    View.TxtUserNOFocus();
                    return;
                }
            }

            if (Model.ModifyUserByID(View.UserNO, View.UserName, View.IsAdmin, User.UserID, View.UserID))
            {
                View.CloseForm();
            }
        }
        #region 内部函数
        /// <summary>
        /// 判断是否存在此用户工号
        /// </summary>
        /// <param name="userNO"></param>
        /// <returns></returns>
        public bool IsExistUser(string userNO)
        {
            DataTable data = Model.GetUserByNO(userNO);
            if (data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
