using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class PatientHistoryModel
    {
        /// <summary>
        /// 修改病史
        /// </summary>
        /// <param name="ph">病史类</param>
        /// <returns>bool</returns>
        public bool ModifyPatientHistory(PatientHistory ph,int updateBy)
        {
            List<object> sqlParams = new List<object>();
            if (ph.PatientID != null)
            {
                if (ph.MensesFirstAge == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.MensesFirstAge); }
                if (ph.Cycle == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Cycle); }
                if (ph.LastDate == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.LastDate); }
                if (ph.LastAge == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.LastAge); }
                if (ph.FirstSexAge == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.FirstSexAge); }
                if (ph.PrimiparityAge == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.PrimiparityAge); }
                if (ph.PregnancyNum == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.PregnancyNum); }
                if (ph.BirthNum == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.BirthNum); }
                if (ph.Suckle == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Suckle); }
                if (ph.Contraception == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Contraception); }
                if (ph.Severity == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Severity); }
                if (ph.CIN == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.CIN); }
                if (ph.Stage == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Stage); }
                if (ph.TreatWay == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.TreatWay); }
                if (ph.TreatDate == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.TreatDate); }
                if (ph.TumourHistory == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.TumourHistory); }
                if (ph.TumourPart == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.TumourPart); }
                if (ph.LeucorrheaNum == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.LeucorrheaNum); }
                if (ph.Hemolysis == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Hemolysis); }
                if (ph.Waist == null) { sqlParams.Add(DBNull.Value); }
                else { sqlParams.Add(ph.Waist); }
                sqlParams.Add(updateBy);
                sqlParams.Add(ph.PatientID);
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdatePatientHistory, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 查询出3天内登记排队检查完病人
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetPatient()
        {
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectHistory);
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
        /// 根据病人卡号查询病史
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <returns>DataTable</returns>
        public DataTable GetPatientByNO(string patientNO)
        {
            object[] sqlParams = new object[] { patientNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectHistoryByNO, sqlParams);
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
        /// 根据病人姓名查询病史
        /// </summary>
        /// <param name="patientName">病人姓名</param>
        /// <returns>DataTable</returns>
        public DataTable GetPatientByName(string patientName)
        {
            object[] sqlParams = new object[] { patientName };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectHistoryByName, sqlParams);
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
        /// 根据病人id查询病史
        /// </summary>
        /// <param name="patientID">病人id</param>
        /// <returns>DataTable</returns>
        public DataTable GetPatientByID(int? patientID)
        {
            object[] sqlParams = new object[] { patientID };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectPatientById, sqlParams);
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
        /// 根据数据类型，字典中得到值
        /// </summary>
        /// <param name="codeType">数据类型</param>
        /// <returns></returns>
        public DataTable GetCodeValueByType(string codeType)
        {
            object[] sqlParams = new object[] { codeType };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlSelectCodeValueByType, sqlParams);
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
