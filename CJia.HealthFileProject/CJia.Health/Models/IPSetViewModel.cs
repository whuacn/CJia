using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class IPSetViewModel : Tools.Model
    {
        /// <summary>
        /// 获得IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public DataTable GetIP(string ip)
        {
            object[] parames = new object[] { ip };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryIP, parames);
            return result;
        }
        /// <summary>
        /// 获得IP
        /// </summary>
        /// <returns></returns>
        public DataTable GetIP()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryAllIP);
            return result;
        }
        /// <summary>
        /// 删除ip
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteIP(string tarnsID, string ip, string userID)
        {
            object[] ob = new object[] { userID, ip };
            return CJia.DefaultOleDb.Execute(tarnsID, SqlTools.SqlDeleteIP, ob) > 0 ? true : false;
        }
        /// <summary>
        /// 新增ip
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddIP(string tarnsID, string ip, string userID)
        {
            object[] ob = new object[] { ip, userID };
            return CJia.DefaultOleDb.Execute(tarnsID, SqlTools.SqlAddIP, ob) > 0 ? true : false;
        }
    }
}
