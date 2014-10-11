using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class PatientSelectModel
    {
        /// <summary>
        /// 查询出3天就诊完病人
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetPatient()
        {
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectPatient);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据病人卡号查询就诊完病人信息
        /// </summary>
        /// <param name="patientName">病人卡号</param>
        /// <returns></returns>
        public DataTable GetPatientByNO(string patientNO)
        {
            object[] sqlParams = new object[] { patientNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectPatientByNO,sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据病人姓名查询就诊完病人信息
        /// </summary>
        /// <param name="patientName">姓名</param>
        /// <returns></returns>
        public DataTable GetPatientByName(string patientName)
        {
            object[] sqlParams = new object[] { patientName };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectPatientByName, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

    }
}
