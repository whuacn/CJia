using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class QueryPatientModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询省
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProvince()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectProvince);
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
        /// 查找市
        /// </summary>
        /// <param name="provinceId">根据省筛选市</param>
        /// <returns></returns>
        public DataTable QueryCity(string provinceId)
        {
            List<object> sqlParams = new List<object>() { provinceId };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectCityByProvince, sqlParams);
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
        /// 医生所属科室
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectDept);
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
        /// 根据科室筛选医生
        /// </summary>
        /// <param name="selectedDeptId">所选科室</param>
        /// <returns></returns>
        public DataTable QueryDoctor(string selectedDeptId)
        {
            List<object> sqlParams = new List<object>() { selectedDeptId };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectDoctor, sqlParams);
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
        /// 查询ICD编码
        /// </summary>
        /// <returns></returns>
        public DataTable QueryICDCode()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectICDCode);
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
        /// 查询治疗结果
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTreatResult()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectTreatResult);
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
        /// 根据病人条件查询病案资料
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public DataTable QueryPatient(MyPatient patient)
        {
            string str = "";
            if (patient.StartDate != DateTime.MinValue)
            {
                str = str + " and p.out_hospital_date between to_date('" + patient.StartDate.ToShortDateString() + "','yyyy/MM/dd') and to_date('" + patient.EndDate.ToShortDateString() + "','yyyy/MM/dd')";
            }
            if (patient.RecordNO != null)
            {
                str = str + " and p.recordno='" + patient.RecordNO + "'";
            }
            if (patient.PatientID != null)
            {
                str = str + " and p.patient_id='" + patient.PatientID + "'";
            }
            if (patient.CYZD != null && patient.ZLJG == null)
            {
                str = str + " and (p.outdia_name1 like '%" + patient.CYZD + "%' or p.outdia_name2 like '%" + patient.CYZD + "%' or p.outdia_name3 like '%" + patient.CYZD + "%' or p.outdia_name4 like '%" + patient.CYZD + "%') ";
            }
            else if (patient.CYZD != null && patient.ZLJG != null)
            {
                str = str + " and ((p.outdia_name1 like '%" + patient.CYZD + "%' and p.treat_result1 = '" + patient.ZLJG + "') or (p.outdia_name2 like '%" + patient.CYZD + "%' and p.treat_result2 = '" + patient.ZLJG + "') or (p.outdia_name3 like '%" + patient.CYZD + "%' and p.treat_result3 = '" + patient.ZLJG + "') or (p.outdia_name4 like '%" + patient.CYZD + "%' and p.treat_result4 = '" + patient.ZLJG + "'))";
            }
            else if (patient.ZLJG != null && patient.CYZD == null)
            {
                str = str + " and (p.treat_result1= '" + patient.ZLJG + "' or p.treat_result2= '" + patient.ZLJG + "' or p.treat_result3= '" + patient.ZLJG + "' or p.treat_result4 = '" + patient.ZLJG + "')";
            }
            if (patient.SSMC != null)
            {
                str = str + " and (p.surgery_name1 like '%" + patient.SSMC + "%' or p.surgery_name2 like '%" + patient.SSMC + "%' or p.surgery_name3 like '%" + patient.SSMC + "%' or p.surgery_name4 like '%" + patient.SSMC + "%') ";
            }
            if (patient.YNGR != null)
            {
                str = str + " and (p.yngr_name1 like '%" + patient.YNGR + "%' or p.yngr_name2 like '%" + patient.YNGR + "%')";
            }
            if (patient.BLZD != null)
            {
                str = str + " and (p.blzd_name1 like '%" + patient.BLZD + "%' or p.blzd_name2 like '%" + patient.BLZD + "%')";
            }
            if (patient.PatientName != null)
            {
                str = str + " and p.patient_name like '%" + patient.PatientName + "%'";
            }
            if (patient.Provice != null)
            {
                str = str + " and p.province='" + patient.Provice + "'";
            }
            if (patient.City != null)
            {
                str = str + " and p.city='" + patient.City + "'";
            }
            if (patient.RYDept != null)
            {
                str = str + " and p.in_hospital_dept='" + patient.RYDept + "'";
            }
            if (patient.RYDoctor != null)
            {
                str = str + " and p.in_hospital_doctor='" + patient.RYDoctor + "'";
            }
            if (patient.CYDept != null)
            {
                str = str + " and p.out_hospital_dept='" + patient.CYDept + "'";
            }
            if (patient.CYDoctor != null)
            {
                str = str + " and p.out_hospital_doctor='" + patient.CYDoctor + "'";
            }
            if (str.Length == 0)
            {
                str = str + " and 1=0";
            }
            string newsqlStr = string.Format(SqlTools.SqlQueryPatient, str);
            DataTable dtResult = CJia.DefaultOleDb.Query(newsqlStr);
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
        /// 根据用户id查询申请病案
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetApply(string userID)
        {
            object[] sqlParams = new object[] { userID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryApply, sqlParams);
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
