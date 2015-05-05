using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class PatientApplyModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetSysdate()
        {
            return DateTime.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlSysdate));
        }
        /// <summary>
        /// 获得borrow表的seq值
        /// </summary>
        /// <returns></returns>
        public string GetBorrowSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlBorrowSeq);
        }
        /// <summary>
        /// 获得申请单编号
        /// </summary>
        /// <returns></returns>
        public string GetBorrowNO()
        {
            string seq = CJia.DefaultOleDb.QueryScalar(SqlTools.SqlBorrowListNOSeq);
            string listNO = GetSysdate().ToString("yyyyMMdd") + "00" + seq;
            return listNO;
        }
        /// <summary>
        /// 插入申请详细表
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="healthID"></param>
        /// <param name="listid"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool AddBorrowDetail(string transID, string healthID, string listid, string userID)
        {
            object[] sqlParams = new object[] { healthID, userID, listid };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddBorrowDetail, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 插入申请表
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="listid"></param>
        /// <param name="listNO"></param>
        /// <param name="reason"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool AddBorrow(string transID, string listid, string listNO, string reason, string userID, string userName)
        {
            object[] sqlParams = new object[] { listid, listNO, userID, userName, reason, userID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddBorrow, sqlParams) > 0 ? true : false;
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
            //string str = "";
            //if (patient.StartDate != DateTime.MinValue)
            //{
            //    str = str + " and p.out_hospital_date between to_date('" + patient.StartDate.ToShortDateString() + "','yyyy/MM/dd') and to_date('" + patient.EndDate.ToShortDateString() + "','yyyy/MM/dd')";
            //}
            //if (patient.RecordNO != null)
            //{
            //    str = str + " and p.recordno='" + patient.RecordNO + "'";
            //}
            //if (patient.PatientID != null)
            //{
            //    str = str + " and p.patient_id='" + patient.PatientID + "'";
            //}
            //if (patient.CYZD != null && patient.ZLJG == null)
            //{
            //    str = str + " and (p.outdia_name1 like '%" + patient.CYZD + "%' or p.outdia_name2 like '%" + patient.CYZD + "%' or p.outdia_name3 like '%" + patient.CYZD + "%' or p.outdia_name4 like '%" + patient.CYZD + "%') ";
            //}
            //else if (patient.CYZD != null && patient.ZLJG != null)
            //{
            //    str = str + " and ((p.outdia_name1 like '%" + patient.CYZD + "%' and p.treat_result1 = '" + patient.ZLJG + "') or (p.outdia_name2 like '%" + patient.CYZD + "%' and p.treat_result2 = '" + patient.ZLJG + "') or (p.outdia_name3 like '%" + patient.CYZD + "%' and p.treat_result3 = '" + patient.ZLJG + "') or (p.outdia_name4 like '%" + patient.CYZD + "%' and p.treat_result4 = '" + patient.ZLJG + "'))";
            //}
            //else if (patient.ZLJG != null && patient.CYZD == null)
            //{
            //    str = str + " and (p.treat_result1= '" + patient.ZLJG + "' or p.treat_result2= '" + patient.ZLJG + "' or p.treat_result3= '" + patient.ZLJG + "' or p.treat_result4 = '" + patient.ZLJG + "')";
            //}
            //if (patient.SSMC != null)
            //{
            //    str = str + " and (p.surgery_name1 like '%" + patient.SSMC + "%' or p.surgery_name2 like '%" + patient.SSMC + "%' or p.surgery_name3 like '%" + patient.SSMC + "%' or p.surgery_name4 like '%" + patient.SSMC + "%') ";
            //}
            //if (patient.YNGR != null)
            //{
            //    str = str + " and (p.yngr_name1 like '%" + patient.YNGR + "%' or p.yngr_name2 like '%" + patient.YNGR + "%')";
            //}
            //if (patient.BLZD != null)
            //{
            //    str = str + " and (p.blzd_name1 like '%" + patient.BLZD + "%' or p.blzd_name2 like '%" + patient.BLZD + "%')";
            //}
            //if (patient.PatientName != null)
            //{
            //    str = str + " and p.patient_name like '%" + patient.BLZD + "%'";
            //}
            //if (patient.Provice != null)
            //{
            //    str = str + " and p.province='" + patient.Provice + "'";
            //}
            //if (patient.City != null)
            //{
            //    str = str + " and p.city='" + patient.City + "'";
            //}
            //if (patient.RYDept != null)
            //{
            //    str = str + " and p.in_hospital_dept='" + patient.RYDept + "'";
            //}
            //if (patient.RYDoctor != null)
            //{
            //    str = str + " and p.in_hospital_doctor='" + patient.RYDoctor + "'";
            //}
            //if (patient.CYDept != null)
            //{
            //    str = str + " and p.out_hospital_dept='" + patient.CYDept + "'";
            //}
            //if (patient.CYDoctor != null)
            //{
            //    str = str + " and p.out_hospital_doctor='" + patient.CYDoctor + "'";
            //}
            //if (str.Length == 0)
            //{
            //    str = str + " and 1=0";
            //}
            //string newsqlStr = string.Format(SqlTools.SqlQueryPatient, str);
            //DataTable dtResult = CJia.DefaultOleDb.Query(newsqlStr);
            //if (dtResult != null && dtResult.Rows.Count > 0)
            //{
            //    return dtResult;
            //}
            //else
            //{
            //    return null;
            //}
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
        /// <summary>
        /// 根据病案ID 查询病案
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public DataTable GetPatientByID(string patientID)
        {
            object[] sqlParams = new object[] { patientID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPatientByID, sqlParams);
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
