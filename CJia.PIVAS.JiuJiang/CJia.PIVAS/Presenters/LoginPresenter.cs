using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 登录界面的P层
    /// </summary>
    public class LoginPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.LoginModel, CJia.PIVAS.Views.ILoginView>
    {

        /// <summary>
        /// 登录的构造方法
        /// </summary>
        /// <param name="view"></param>
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            this.View.OnLogin += View_OnLogin;
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLogin(object sender, Views.LoginEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.SelectUser(e.UserNo, e.Password);
            if (dt != null && dt.Rows != null && dt.Rows.Count == 1)
            {
                string str = dt.Rows[0]["LOGINTIME"].ToString();
                CJia.PIVAS.User.SetUser(true, long.Parse(dt.Rows[0]["user_id"].ToString()), dt.Rows[0]["user_no"].ToString(), dt.Rows[0]["user_name"].ToString(), dt.Rows[0]["dept_id"].ToString(), dt.Rows[0]["dept_name"].ToString(), dt.Rows[0]["USER_PASSWORD"].ToString(), dt.Rows[0]["LOGINTIME"].ToString(), dt.Rows[0]["IS_ADMIN"].ToString(), dt.Rows[0]["HIS_USER_ID"].ToString(), dt.Rows[0]["ROLE"].ToString());
                this.View.CloseWindow();
            }
            else
            {
                CJia.PIVAS.User.IsLoginSuccess = false;
                this.View.ExeLoginFail();
            }
        }
           
        /// <summary>
        /// 重写OnInitView 方法
        /// </summary>
        protected override void OnInitView()
        {

        }

    }
}