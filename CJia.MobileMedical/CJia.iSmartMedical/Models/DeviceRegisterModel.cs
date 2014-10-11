using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Models
{
    public class DeviceRegisterModel : ModelBase, IModel
    {
        /// <summary>
        /// 查询本地科室信息
        /// </summary>
        public List<Data.iDept> QueryLocalDept()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDept]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                var Result = cmd.ExecuteQuery<iDept>();
                return Result;
            }
        }
        /// <summary>
        /// 查询本地病区科室关系
        /// </summary>
        public List<Data.iIllfieldDept> QueryLocalIllfieldDept()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iIllfieldDept]";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText);
                var Result = cmd.ExecuteQuery<iIllfieldDept>();
                return Result;
            }
        }
        /// <summary>
        /// 查询本地设备信息
        /// </summary>
        public Data.iDevice QueryLocalDevice(string DeviceID)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDevice] Where [DeviceID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DeviceID);
                var Result = cmd.ExecuteQuery<iDevice>();
                if (Result.Count == 1)
                {
                    return Result[0];
                }
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
        /// 从服务器数据库检索科室信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<iDept>> QueryServerDept()
        {
            object Result = await RemoteExcute(new object[] { });
            List<iDept> DataList = Deserialize<iDept>(Result as byte[]);
            return DataList;
        }
        /// <summary>
        /// 从服务器数据库检索病区科室信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<iIllfieldDept>> QueryServerIllfieldDept()
        {
            object Result = await RemoteExcute(new object[] { });
            List<iIllfieldDept> DataList = Deserialize<iIllfieldDept>(Result as byte[]);
            return DataList;
        }

        /// <summary>
        /// 将科室信息保存至本地
        /// </summary>
        public void SaveDeptToLocal(List<iDept> DeptList)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                foreach (iDept dept in DeptList)
                {
                    conn.Insert(dept);
                }
                conn.Commit();
            }
        }
        /// <summary>
        /// 保存设备到本地
        /// </summary>
        /// <param name="device"></param>
        public void SaveLocalDeviceInfo(Data.iDevice device)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                string SqlText = @"Select * From [iDevice] Where [DeviceID]=?";
                SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, device.DeviceID);
                var Result = cmd.ExecuteQuery<iDevice>();
                if (Result.Count == 1)
                {
                    conn.Update(device);
                }
                else
                {
                    conn.Insert(device);
                }
            }
        }
        /// <summary>
        /// 保存本地设备所属科室信息
        /// </summary>
        public void SaveLocalDeviceOffice(string DeviceID, List<string> OfficeIDs, List<string> OfficeNames)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(iDB.DbFile))
            {
                conn.BeginTransaction();
                try
                {
                    string SqlText = @"Delete From [iDeviceOffice] Where [DeviceID]=?";
                    SQLite.SQLiteCommand cmd = conn.CreateCommand(SqlText, DeviceID);
                    cmd.ExecuteNonQuery();
                    SqlText = @"Insert Into [iDeviceOffice] ([DOID],[DeviceID], [OfficeID],[OfficeName],[CreateDate]) Values (@1,@2,@3,@4,@5)";
                    cmd.CommandText = SqlText;
                    for (int i = 0; i < OfficeIDs.Count; i++)
                    {
                        cmd.ClearBindings();
                        cmd.Bind(Guid.NewGuid().ToString());
                        cmd.Bind(DeviceID);
                        cmd.Bind(OfficeIDs[i]); cmd.Bind(OfficeNames[i]);
                        cmd.Bind(iCommon.DateNow);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Commit();
                }
                catch
                {
                    conn.Rollback();
                }
            }
        }
        /// <summary>
        /// 保存设备信息到服务器
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveDeviceInfo(string DeviceID, string DeviceName, string Notes, string Status, List<string> OfficeIDs, List<string> OfficeNames)
        {
            object Result = await RemoteExcute(new object[] { DeviceID, DeviceName, Notes, Status, OfficeIDs.ToArray(), OfficeNames.ToArray() });
            return (bool)Result;
        }
    }
}
