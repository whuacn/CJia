using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Services.Protocols;

namespace CJia.Health.Service
{
    /// <summary>
    /// HealthService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HealthService : System.Web.Services.WebService
    {

        /// <summary>
        /// SOAP消息头
        /// </summary>

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "根据病案号与住院次数，查询出病案信息")]
        public DataTable QueryPatientBy(string recordNo, string inhosTimes)
        {
            try
            {
                string ConnString = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ConntionString"));
                using (Adapter ada = new Adapter(ConnString))
                {
                    return ada.Query(SqlText.SqlSelectPatient, new object[] { recordNo, inhosTimes });
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
