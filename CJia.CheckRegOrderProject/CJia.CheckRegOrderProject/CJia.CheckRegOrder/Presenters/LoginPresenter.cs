using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CJia.CheckRegOrder.Presenters
{
    public class LoginPresenter : CJia.Presenter<Views.ILoginView>
    {
        private Models.LoginModel Model
        {
            set;
            get;
        }
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            this.Model = new Models.LoginModel();
        }
        protected override void OnViewSet()
        {
            this.View.OnLogin += View_OnLogin;
        }

        void View_OnLogin(object sender, Views.LoginArgs e)
        {
            DataTable result = Model.GetUserByNOAndPassword(e.UserNO, e.Password);
            if (result != null && result.Rows.Count > 0)
            {
                DataTable dataTime = Model.GetSystemDateTime();
                View.ExeLogin(result, dataTime);
            }
            else
            {
                View.ShowMessage("登录失败，工号或密码错误");
                View.TxtUserNOFocus();
            }
        }
        
    }
}
