using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.MobileMedicalDoctor.Data;

namespace CJia.MobileMedicalDoctor.Models
{
    public class LoginModel : ModelBase, IModel
    {
        /// <summary>
        /// 在线模式下登录
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
        /// 离线模式下登录
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
