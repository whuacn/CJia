using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class RegNoCheckModel
    {
        /// <summary>
        /// 查询出登记未排队就诊的病人
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetRegNoCheckPatient()
        {
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectRegNoCheck);
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
        /// 删除登记未排队的病人
        /// </summary>
        /// <param name="patientID">病人id</param>
        /// <returns></returns>
        public bool DeleteRegNoCheckPatient(int? patientID)
        {
            object[] sqlParams = new object[] { patientID };
            return CJia.DefaultSQL.Execute(SqlTools.sqlDeleteRegNoCheck, sqlParams) > 0 ? true : false;
        }
    }
}
