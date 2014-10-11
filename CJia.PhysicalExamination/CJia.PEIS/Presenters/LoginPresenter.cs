using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Presenters
{
    /// <summary>
    /// 登录Presenter层
    /// </summary>
    public class LoginPresenter:CJia.PEIS.Tools.Presenter<Models.LoginModel,Views.ILoginView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            view.OnLogin += view_OnLogin;
        }

        void view_OnLogin(object sender, Views.LoginEventArgs e)
        {
            DataTable dt = Model.GetUserByNOAndPwd(e.UserNo, e.Password);
            if (dt != null && dt.Rows.Count > 0)
            {
                LoginSuccessBind(dt);
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
