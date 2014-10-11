using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class LoginPresenter : CJia.Parking.Tools.Presenter<Models.LoginModel,Views.ILoginView>
    {
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            view.OnLogin += view_OnLogin;
        }

        void view_OnLogin(object sender, Views.LoginArgs e)
        {
            DataTable dtUser = Model.QueryUser(e.UserNo,e.UserPassword);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                LoginSuccessBind(dtUser);
                View.CloseWindow();
            }
            else
            {
                View.ShowMessage("用户名或密码错误！");
                View.TxtUserNOFocus();
            }
        }

        #region 内部调用方法
        /// <summary>
        /// 成功登录绑定用户信息
        /// </summary>
        private void LoginSuccessBind(DataTable dt)
        {
            User.UserData = dt;
            User.IsLoginSuccess = true;
            User.LoginTime = View.Sysdate;
        }
        #endregion
       
    }
}
