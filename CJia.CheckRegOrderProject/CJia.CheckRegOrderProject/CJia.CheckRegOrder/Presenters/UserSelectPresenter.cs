using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class UserSelectPresenter : CJia.Presenter<Views.IUserSelectView>
    {
        private Models.UserSelectModel Model
        {
            get;
            set;
        }
        public UserSelectPresenter(Views.IUserSelectView view)
            : base(view)
        {
            Model = new Models.UserSelectModel();
        }
        protected override void OnViewSet()
        {
            View.Load += View_Load;
            View.OnSelectByNO += View_OnSelectByNO;
            View.OnSelectByName += View_OnSelectByName;
            View.OnSelectBtn += View_OnSelectBtn;
            View.OnResetPswdBtn += View_OnResetPswdBtn;
            View.OnDelete += View_OnDelete;
            View.OnEditBtn += View_OnEditBtn;
        }

        void View_OnEditBtn(object sender, EventArgs e)
        {
            DataTable data = Model.GetUserByID(View.UserID);
            View.ExeShowUserHandle(data);
        }

        void View_OnDelete(object sender, EventArgs e)
        {
            Model.DeleteUserByID(User.UserID, View.UserID);
        }

        void View_OnResetPswdBtn(object sender, EventArgs e)
        {
            Model.ResetPswdByID(User.UserID, View.UserID);
        }

        void View_OnSelectBtn(object sender, EventArgs e)
        {
            DataTable data = GetUserByNOAndName(View.UserNO, View.UserName);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindUser(data);
            }
            else
            {
                View.ShowMessage("无此用户");
            }
        }

        void View_OnSelectByName(object sender, EventArgs e)
        {
            DataTable data = Model.GetUserByName(View.UserName);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindUser(data);
            }
            else
            {
                View.ShowMessage("无此用户");
            }
        }

        void View_OnSelectByNO(object sender, EventArgs e)
        {
            DataTable data = Model.GetUserByNO(View.UserNO);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindUser(data);
            }
            else
            {
                View.ShowMessage("无此用户");
            }
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetAllUser();
            View.ExeBindUser(data);
        }

        #region 内部调用方法
        /// <summary>
        /// 根据工号 姓名查询
        /// </summary>
        /// <param name="userNO">工号 </param>
        /// <param name="userName">姓名</param>
        /// <returns></returns>
        public DataTable GetUserByNOAndName(string userNO, string userName)
        {
            DataTable data = Model.GetUserByNO(userNO);
            if (data != null && data.Rows.Count > 0)
            {
                return data;
            }
            else
            {
                DataTable data1 = Model.GetUserByName(userName);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    return data1;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
