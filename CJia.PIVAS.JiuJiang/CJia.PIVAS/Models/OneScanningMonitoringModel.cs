using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace CJia.PIVAS.Models
{
    public class OneScanningMonitoringModel : Tools.Model
    {

        /// <summary>
        /// 注销用户登录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="operation"></param>
        public void OutLogin(string userId, string operation)
        {
            object[] parms = new object[] { userId, operation };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlOuntLoginScanning, parms);
        }

        /// <summary>
        /// 查询登录情况
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable SelectLogin(string operation)
        {
            object[] parms = new object[] { operation };
            return CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlSelectLogin, parms);
        }
    }
}
