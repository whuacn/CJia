using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class LoginModel : ModelBase, IModel
    {
        /// <summary>
        /// 从本地数据库获取当前设备信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public iDevice QueryLocalDeviceInfo(string DeviceID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDevice] Where [DeviceID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DeviceID);
                var Result = cmd.ExecuteQuery<iDevice>();
                if (Result.Count > 0)
                    return Result[0];
                return null;
            }
        }
        /// <summary>
        /// 查询本地设备所属科室信息
        /// </summary>
        public List<Data.iDeviceOffice> QueryLocalDeviceOffice(string DeviceID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDeviceOffice] Where [DeviceID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DeviceID);
                var Result = cmd.ExecuteQuery<iDeviceOffice>();
                return Result;
            }
        }
        /// <summary>
        /// 从服务器数据库检索当前设备信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public async Task<iDevice> QueryServerDeviceInfo(string DeviceID)
        {
            object Result = await RemoteExcute(new object[] { DeviceID });
            List<iDevice> DataList = Deserialize<iDevice>(Result as byte[]);
            if (DataList != null && DataList.Count > 0)
                return DataList[0];
            else
                return null;
        }
        /// <summary>
        /// 从服务器数据库检索当前设备所属科室信息
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public async Task<List<iDeviceOffice>> QueryServerDeviceOfficeInfo(string DeviceID)
        {
            object Result = await RemoteExcute(new object[] { DeviceID });
            List<iDeviceOffice> DataList = Deserialize<iDeviceOffice>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 保存设备信息至本地数据库
        /// </summary>
        /// <param name="device"></param>
        public void SaveDeviceInfoToLocal(iDevice device)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.Insert(device);
            }
        }
        /// <summary>
        /// 保存设备所属科室信息至本地数据库
        /// </summary>
        /// <param name="deviceOffice"></param>
        public void SaveDeviceOfficeInfoToLocal(List<iDeviceOffice> deviceOffice)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                foreach (iDeviceOffice ido in deviceOffice)
                {
                    conn.Insert(ido);
                }
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserCode">工号</param>
        /// <param name="Password">密码</param>
        /// <param name="ClientTag">客户端信息</param>
        public async Task<User> Login(string UserCode, string Password, string ClientTag)
        {
            object Result = await RemoteExcute(new object[] { UserCode, Password, ClientTag });
            List<User> DataList = Deserialize<User>(Result as byte[]);
            if (DataList != null && DataList.Count > 0)
                return DataList[0];
            else
                return null;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserCode">工号</param>
        /// <param name="Password">密码</param>
        /// <param name="ClientTag">客户端信息</param>
        public User LocalLogin(string UserCode, string Password, string ClientTag)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                var existUser = conn.Table<User>().Where(u => u.Code == UserCode && u.Password == Password && u.Status == "1").ToList();
                if (existUser != null && existUser.Count > 0)
                {
                    return existUser[0];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 更新本地用户资料
        /// </summary>
        /// <param name="loginUser"></param>
        public void UpdateLocalUser(User loginUser)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                var existUser = conn.Table<User>().Where(u => u.ID == loginUser.ID).SingleOrDefault();
                if (existUser != null)
                {
                    conn.Update(loginUser);
                }
                else
                {
                    conn.Insert(loginUser);
                }
            }
        }

        /// <summary>
        /// 查询本地设备用户
        /// </summary>
        public List<Data.User> QueryLocalUserList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                return conn.Table<User>().ToList();
            }
        }
    }
}
