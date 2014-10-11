using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class DeviceRegisterPresenter : Presenter<Models.DeviceRegisterModel, Views.IDeviceRegister>
    {
        public DeviceRegisterPresenter(Views.IDeviceRegister view)
            : base(view)
        {
            View.OnQueryDeviceInfo += View_OnQueryDeviceInfo;
            View.OnSaveDeviceInfo += View_OnSaveDeviceInfo;
        }

        async void View_OnSaveDeviceInfo(object sender, Views.DeviceRegisterEventArgs e)
        {
            Data.iDevice device = new Data.iDevice();
            device.DeviceID = iCommon.DeviceID;
            device.DeviceName = e.DeviceName;
            device.Notes = e.Notes;
            device.Status = e.Status;
            device.CreateDate = iCommon.DateNow;
            
            bool IsSaveSuccess = await Model.SaveDeviceInfo(iCommon.DeviceID, e.DeviceName, e.Notes, e.Status, e.OfficeIDs, e.OfficeNames);
            if (IsSaveSuccess)
            {
                Model.SaveLocalDeviceInfo(device);
                Model.SaveLocalDeviceOffice(iCommon.DeviceID, e.OfficeIDs, e.OfficeNames);
            }
            View.ExeShowSaveResult(IsSaveSuccess);
        }

        async void View_OnQueryDeviceInfo(object sender, EventArgs e)
        {
            //1.查询本地科室
            List<Data.iDept> deptList = Model.QueryLocalDept();
            if (deptList.Count == 0)
            {//不存在则先从服务器获取
                deptList = await Model.QueryServerDept();
                //List<Data.iIllfieldDept> IllfieldDept = await Model.QueryServerIllfieldDept();
                //同步至本地
                Model.SaveDeptToLocal(deptList);
                deptList = Model.QueryLocalDept();
            }
            //List<Data.iIllfieldDept> IllfieldDeptList = Model.QueryLocalIllfieldDept();
            //2.显示当前病区和科室
            View.ExeShowDeptList(deptList);
            //3.查询本地设备信息
            Data.iDevice device = Model.QueryLocalDevice(iCommon.DeviceID);

            if (device != null)
            {//存在设备信息，则显示，以便修改
                List<Data.iDeviceOffice> idoList = Model.QueryLocalDeviceOffice(iCommon.DeviceID);
                //4.显示设备配置信息
                View.ExeShowDeviceInfo(device, idoList);
            }
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
