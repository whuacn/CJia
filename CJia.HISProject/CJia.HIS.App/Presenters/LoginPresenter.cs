using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.App.Presenters
{
    public class LoginPresenter : CJia.HIS.Presenter<Models.LoginModel,Views.ILoginView>
    {

        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            this.View.LoginEven += View_LoginEven;
        }

        //UI层登录按钮单击事件
        void View_LoginEven(object sender, EventArgs e)
        {
            int result = this.GetLoginEvent();
            switch(result)
            {
                case 0:
                    this.View.ShowMessage("用户编号或密码错误!");
                    break;
                case 1:
                    this.View.CloseForm();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 返回登录结果
        /// </summary>
        /// <returns>0：账号或密码错误 1：登录成功</returns>
        public int GetLoginEvent()
        {
            DataTable result = this.Model.Login(this.View.UserNo, this.View.UserPwd);
            if(result == null || result.Rows == null || result.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                CJia.HIS.SystemInfo.User = result.Rows[0];
                CJia.HIS.SystemInfo.IsLoginSucceed = true;
                return 1;
            }
        }
    

        protected override void OnInitView()
        {
            base.OnInitView();
        }

    }
}