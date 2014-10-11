using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Presenters
{
    public class LoginPresenter : Presenter<Models.LoginModel, Views.ILoginView>
    {
        public LoginPresenter(Views.ILoginView view)
            : base(view)
        {
            View.OnUserLogin += View_OnUserLogin;
            View.OnQueryLocalLoginUser += View_OnQueryLocalLoginUser;
            View.OnQueryDeviceInfo += View_OnQueryDeviceInfo;
        }

        void View_OnQueryDeviceInfo(object sender, EventArgs e)
        {
            iCommon.CurrentDevice = Model.QueryLocalDeviceInfo(iCommon.DeviceID);
            if (iCommon.CurrentDevice == null) return;
            iCommon.DeviceOffice = Model.QueryLocalDeviceOffice(iCommon.DeviceID);
            View.ExeShowDeviceInfo();
        }

        void View_OnQueryLocalLoginUser(object sender, EventArgs e)
        {
            List<Data.User> localUserList = Model.QueryLocalUserList();
            View.ExeShowLocalUserList(localUserList);
        }

        async void View_OnUserLogin(object sender, Views.LoginEventArgs e)
        {
            bool IsRightDevice = await CheckDevice(e.UserCode, e.Password);
            if (IsRightDevice)
                Login(e.UserCode, e.Password);
        }
        /// <summary>
        /// 检查设备状态
        /// </summary>
        /// <returns></returns>
        async Task<bool> CheckDevice(string UserCode, string Password)
        {
            if (iCommon.CurrentDevice != null)
            {
                if (iCommon.CurrentDevice.Status == "正常")
                {
                    return true;
                }
                else
                {
                    View.ExeLoginFail("当前设备已被禁用，请与管理员联系。");
                    return false;
                }
            }
            //如果本地无设备信息，说明是第一次使用，或重新安装程序等。
            if (iCommon.IsOnline == false || iCommon.IsConnected == false)
            {
                View.ExeLoginFail("设备初次使用时，请先联网登录。");
                return false;
            }
            bool Result = false;
            //如果是在线模式并且网络连通，则从服务器检索该设备信息
            Data.iDevice device = await Model.QueryServerDeviceInfo(iCommon.DeviceID);

            if (device != null)
            {//当前设备已在服务器中登记过
                //将数据同步至本地
                Model.SaveDeviceInfoToLocal(device);
                List<Data.iDeviceOffice> doList = await Model.QueryServerDeviceOfficeInfo(iCommon.DeviceID);
                if (doList != null)
                {
                    Model.SaveDeviceOfficeInfoToLocal(doList);
                }
                iCommon.CurrentDevice = device;
                iCommon.DeviceOffice = doList;

                if (device.Status == "正常")
                {
                    return true;
                }
                else
                {//若设备状态为非正常，则禁止使用。
                    View.ExeLoginFail("当前设备已被禁用，请与管理员联系。");
                }
            }
            else
            {//若设备未在服务器中登记，则检查当前用户是否管理员
                User user = await Model.Login(UserCode, Password, "");
                if (user != null)
                {
                    if (user.UserType == "管理员")
                    {
                        View.ExeShowDeviceRegister();
                    }
                    else
                    {
                        View.ExeLoginFail("设备初次使用，需要由管理员先进行登记。");
                    }
                }
                else
                {
                    View.ExeLoginFail("设备初次使用，必须由管理员先进行登记。");
                }
            }

            return Result;
        }

        async void Login(string UserCode, string Password)
        {
            Data.User user = null;
            if (iCommon.IsOnline)
                user = await Model.Login(UserCode, Password, "");
            else
                user = Model.LocalLogin(UserCode, Password, "");

            if (user != null)
            {//登录成功
                Data.iDeviceOffice ido = iCommon.DeviceOffice.Find(idoe =>idoe.OfficeID == user.DeptID);
                if (ido != null)
                {//判断登录用户的科室属性是否存在于此设备的科室列表中
                    if (iCommon.IsOnline)
                        Model.UpdateLocalUser(user);
                    iCommon.LoginUser = user;
                    View.ExeLoginSuccess();
                }
                else
                {//不存在
                    View.ExeLoginFail("登录失败，您非本设备所属科室医生.");
                }
            }
            else if (user == null)
            {
                View.ExeLoginFail("登录失败，用户名或密码有误.");
            }
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
