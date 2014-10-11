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

        //UI���¼��ť�����¼�
        void View_LoginEven(object sender, EventArgs e)
        {
            int result = this.GetLoginEvent();
            switch(result)
            {
                case 0:
                    this.View.ShowMessage("�û���Ż��������!");
                    break;
                case 1:
                    this.View.CloseForm();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ���ص�¼���
        /// </summary>
        /// <returns>0���˺Ż�������� 1����¼�ɹ�</returns>
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