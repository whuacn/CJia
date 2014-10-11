using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 冲药Presenter层
    /// </summary>
    public class LoginScanningPresenter : Tools.Presenter<Models.LoginScanningModel, Views.ILoginScanningView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public LoginScanningPresenter(Views.ILoginScanningView view)
            : base(view)
        {
            view.OnLogin += view_OnLogin;
        }

        void view_OnLogin(object sender, Views.LoginScanningEventArgs e)
        {
            DataTable result = this.Model.Login(e.userId, e.password);
            string mes;
            bool succeed = false;
            if(result != null && result.Rows != null & result.Rows.Count > 0)
            {
                if(this.Model.ExamineUser(result.Rows[0]["USER_ID"].ToString()))
                {
                    if(this.Model.ExamineOperation(e.no))
                    {
                        mes = "";
                        succeed = true;
                        this.Model.InsertLoginScanning(result.Rows[0]["USER_ID"].ToString(), result.Rows[0]["USER_NAME"].ToString(), e.no);
                    }
                    else
                    {
                        mes = "*该操作台已登录";
                    }
                }
                else
                {
                    mes = "*该用户已登录";
                }
            }
            else
            {
                mes = "*用户名或密码错误";
            }
            this.View.ExeLogin(succeed,mes,result);
        }

        //private void view_Load(object sender, EventArgs e)
        //{
        //    this.Model.Login(e.
        //}

   
    }
}
