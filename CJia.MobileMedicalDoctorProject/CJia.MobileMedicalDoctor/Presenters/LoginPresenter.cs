using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class LoginPresenter : Presenter<Models.LoginModel, Views.ILoginView>
    {
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            View.OnUserLogin += View_OnUserLogin;
            view.OnQueryLocalLoginUser += view_OnQueryLocalLoginUser;
        }

        async void view_OnQueryLocalLoginUser(object sender, EventArgs e)
        {
            try
            {
                CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient medicServic = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
                CJia.iSmartMedical.MobileMedicDoctorService.GetUserResponse x = await medicServic.GetUserAsync(View.UserCode, View.Password);
                List<Dictionary<string, string>> listDic = Entity.XmlToListDic(x.Body.GetUserResult);
                List<Data.User> localUserList = Entity.GetEntity<Data.User>(listDic);

                //List<Data.User> localUserList = Model.QueryLocalUserList();
                View.ExeShowLocalUserList(localUserList);
            }
            catch (Exception ex)
            {
                View.ShowMessage(ex.ToString());
            }
        }

        async void View_OnUserLogin(object sender, EventArgs e)
        {
            Data.User user = await Login(View.UserCode, View.Password);
            //Data.User user = await Login(View.UserCode, View.Password);
            //SmartMedicService.WebServiceSoapClient medicServic = new SmartMedicService.WebServiceSoapClient();
            //var user = await medicServic.GetUserAsync(View.UserCode, View.Password);
            //SmartMedicService.GetUserResponse x = await medicServic.GetUserAsync(View.UserCode, View.Password);
            //List<Dictionary<string, string>> str = Entity.XmlToListDic(x.Body.GetUserResult);
            //string str1 = str[0]["Name"];
            if (user != null)
            {
                View.ToMainPage(); //跳转到主页
            }
            else
            {
                View.ShowMessage("登录失败，用户名或密码有误。");
            }
        }

        //async Task<Data.User> Login(string UserCode, string Password)
        //{
        //    Data.User user = null;
        //    if (iCommon.IsConnected)
        //        user = await Model.Login(View.UserCode, View.Password, "");
        //    else
        //        user = Model.LocalLogin(View.UserCode, View.Password, "");
            //if (user != null)
            //{//登录成功
            //    Model.UpdateLocalUser(user);
            //    iCommon.LoginUser = user;
            //}
            //return user;
        //}

        /// <summary>
        /// webService的登录方法
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        async Task<Data.User> Login(string UserCode, string Password)
        {
            Data.User user = null;
            if (iCommon.IsConnected)
            {
                CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient medicServic = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
                CJia.iSmartMedical.MobileMedicDoctorService.GetUserResponse x = await medicServic.GetUserAsync(View.UserCode, View.Password);
                List<Dictionary<string, string>> listDic = Entity.XmlToListDic(x.Body.GetUserResult);
                List<Data.User> userentity = Entity.GetEntity<Data.User>(listDic);
                user = userentity[0];
                //user = Entity.dicToUser(listDic[0]);
            }
            if (user != null)
            {//登录成功
                //Model.UpdateLocalUser(user);
                iCommon.LoginUser = user;
            }
            return user;
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
