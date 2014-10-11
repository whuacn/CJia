using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class DataQueryModel : CJia.Health.Tools.Model
    {
        public DataTable Sreach(DateTime start, DateTime end, string patientId,string patientName,string card,string reCardNo)
        {
            //object[] parames = new object[] { start, end, "%" + patientId + "%", "%" + patientName + "%", "%" + card + "%", "%" + reCardNo + "%" };
            object[] parames = new object[] { start, end, "%" + patientName + "%", "%" + reCardNo + "%" };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSearchPatientData, parames);
            return result;
        }

        public DataTable SelectPic(string healthId)
        {
            object[] parames = new object[] { healthId };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectPic, parames);
            return result;
        }
    }
}
