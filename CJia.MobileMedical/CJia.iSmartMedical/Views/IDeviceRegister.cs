using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IDeviceRegister : IView
    {
        event EventHandler<DeviceRegisterEventArgs> OnSaveDeviceInfo;

        event EventHandler OnQueryDeviceInfo;

        void ExeShowDeptList(List<Data.iDept> DeptList);

        void ExeShowDeviceInfo(Data.iDevice device,List<Data.iDeviceOffice> OfficeList);

        void ExeShowSaveResult(bool IsSaveSuccess);
    }
    public class DeviceRegisterEventArgs : EventArgs
    {
        public DeviceRegisterEventArgs()
        {
            
        }
        public string DeviceName;
        public string Notes;
        public string Status;
        public List<string> OfficeIDs;
        public List<string> OfficeNames;
    }
}
