using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Storage.Streams;

namespace CJia.MobileMedicalDoctor
{
    public class iCommon
    {
        static iCommon()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        static void NetworkInformation_NetworkStatusChanged(object sender)
        {
            bool b = IsConnected;//检测网络
        }

        #region 当前用户
        static Data.User user = null;
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static Data.User LoginUser
        {
            get { return user; }
            set
            {
                user = value;
                doctorID = user.ID;
                doctorName = user.Name;
                deptID = user.DeptID;
                deptName = user.DeptName;
            }
        }

        static string doctorID;
        /// <summary>
        /// 当前医生ID
        /// </summary>
        public static string DoctorID
        {
            get { return doctorID; }
        }
        static string doctorName;
        /// <summary>
        /// 当前医生姓名
        /// </summary>
        public static string DoctorName
        {
            get { return doctorName; }
        }
        static string deptID;
        /// <summary>
        /// 科室ID
        /// </summary>
        public static string DeptID
        {
            get { return deptID; }
        }
        static string deptName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public static string DeptName
        {
            get { return deptName; }
        }
        static string deviceID = "";
        /// <summary>
        /// 设备ID
        /// </summary>
        public static string DeviceID
        {
            get
            {
                if (deviceID.Length > 0) return deviceID;
                Windows.System.Profile.HardwareToken hToke = Windows.System.Profile.HardwareIdentification.GetPackageSpecificToken(null);
                IBuffer hardwareId = hToke.Id;
                DataReader reader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);
                byte[] ar = new Byte[hardwareId.Length];
                reader.ReadBytes(ar);
                string i = ar.ToString();
                string id = System.Text.Encoding.Unicode.GetString(ar, 0, ar.Length);
                deviceID = Convert.ToBase64String(ar);
                return deviceID;
            }
        }
        #endregion

        #region 当前病人
        static Data.Patient CurrentPatient;
        /// <summary>
        /// 当前查看病人
        /// </summary>
        public static Data.Patient Patient
        {
            get 
            { 
                return CurrentPatient;
            }
            set 
            {
                CurrentPatient = value;
            }
        }
        /// <summary>
        /// 当前病人列表
        /// </summary>
        public static IOrderedEnumerable<Data.Patient> PatientList;

        #endregion

        #region 日期时间
        /// <summary>
        /// 当前时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public static string DateNow
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        /// <summary>
        /// 今天日期（yyyy-MM-dd）
        /// </summary>
        public static string Today
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd"); }
        }
        /// <summary>
        /// 当前时间（HH:mm:ss）
        /// </summary>
        public static string NowTime
        {
            get { return DateTime.Now.ToString("HH:mm:ss"); }
        }
        public static string[] SuggestionList =
        {
            "abc","decd","saddd","ass","add","bcc"
        };
        #endregion

        #region 代码数据
        static List<Data.iCode> CodeList = null;
        /// <summary>
        /// 代码数据
        /// </summary>
        public static List<Data.iCode> iCodeList
        {
            get
            {
                if (CodeList != null) return CodeList;
                CodeList = (new Models.iCodeModel()).QueryLocalCodeList();
                return CodeList;
            }
        }
        #endregion

        #region 网络
        /// <summary>
        /// 设置当前操作模式，True：在线使用，False：离线查房
        /// </summary>
        public static bool IsOnline = true;
        /// <summary>
        /// 当前网络连接状态
        /// </summary>
        public static bool IsConnected
        {
            get
            {
                if (!IsOnline) return false;//离线查房模式，直接返回为未连接
                var icp = NetworkInformation.GetInternetConnectionProfile();
                if (icp == null) return false;
                NetworkConnectivityLevel connectionStatus = icp.GetNetworkConnectivityLevel();
                if (connectionStatus == NetworkConnectivityLevel.None)
                    return false;
                else
                    return true;
            }
        }
        static string netAdapterID = "";
        /// <summary>
        /// 网络适配器ID
        /// </summary>
        public static string NetworkAdapterId
        {
            get
            {
                if (netAdapterID.Length > 0) return netAdapterID;
                IReadOnlyCollection<Windows.Networking.Connectivity.ConnectionProfile> profiles = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles();
                Windows.Networking.Connectivity.NetworkAdapter na = profiles.First<Windows.Networking.Connectivity.ConnectionProfile>().NetworkAdapter;
                netAdapterID = na.NetworkAdapterId.ToString();
                return netAdapterID;
            }
        }
        #endregion
    }
}
