using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class PackViewModel : Tools.Model
    {
        /// <summary>
        /// 根据录入时间查询病案
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetPatientByInputDate(DateTime start, DateTime end)
        {
            object[] parames = new object[] { start, end };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPatinetByInputDate, parames);
            return result;
        }
        public DataTable GetPatientByNO(string recordNo)
        {
            object[] parames = new object[] { recordNo };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPatByNO, parames);
            return result;
        }
        public DataTable GetPackByID(string healthID)
        {
            object[] parames = new object[] { healthID };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryIsPack, parames);
            return result;
        }
        public string GetPackID(string transID)
        {
            return CJia.DefaultOleDb.QueryScalar(transID, CJia.Health.Models.SqlTools.SqlQueryPackID);
        }
        public bool AddPack(string transID, string packID, string packCode, string packName, string packAddress, string packRemark, string creater)
        {
            object[] sqlParams = new object[] { packID, packCode, packName, packAddress, packRemark, creater };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddPack, sqlParams) > 0 ? true : false;
        }
        public string GetPackCode()
        {
            return CJia.DefaultOleDb.QueryScalar(CJia.Health.Models.SqlTools.SqlQueryPackCode);
        }
        public bool AddPackDetail(string transID, string packID, string healthID, string creater)
        {
            object[] sqlParams = new object[] { packID, healthID, creater };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddPackDetail, sqlParams) > 0 ? true : false;
        }
        public DataTable GetPackByName(string name)
        {
            object[] parames = new object[] { name };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPackByName, parames);
            return result;
        }
    }
}
