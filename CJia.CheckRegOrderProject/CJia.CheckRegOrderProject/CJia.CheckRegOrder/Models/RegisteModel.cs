using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class RegisteModel
    {
        #region HIS中数据获得
        /// <summary>
        /// 跟据病人卡号或者发票编号HIS中查询信息
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <param name="invoiceNO">发票编号</param>
        /// <returns>病人信息</returns>
        public DataTable GetHISPatient(string patientNO, string invoiceNO)
        {
            object[] sqlParams = new object[] { patientNO, invoiceNO };
            DataTable dtResult = CJia.DefaultData.Query(SqlTools.sqlHISSelect, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return ChangeDate(dtResult);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 本系统数据操作
        /// <summary>
        /// 登记门诊病人
        /// </summary>
        /// <param name="data">HIS中获得的数据</param>
        /// <param name="registeBy">登记人id</param>
        /// <param name="admissionsType">病人类型</param>
        /// <returns>bool</returns>
        public bool AddClinicPatient(DataTable data, int registeBy, string admissionsType)
        {
            List<object> sqlParams = new List<object>();
            if (data != null && data.Rows.Count > 0)
            {
                sqlParams.Add(data.Rows[0]["PATIENT_NO"]);
                sqlParams.Add(data.Rows[0]["PATIENT_NAME"]);
                sqlParams.Add(data.Rows[0]["GENDER"]);
                sqlParams.Add(data.Rows[0]["BIRTHDAY"]);
                sqlParams.Add(data.Rows[0]["BLOOD_TYPE"]);
                sqlParams.Add(data.Rows[0]["TELEPHONE"]);
                sqlParams.Add(data.Rows[0]["ADDRESS"]);
                sqlParams.Add(data.Rows[0]["PATIENT_TYPE"]);
                sqlParams.Add(admissionsType);
                sqlParams.Add(data.Rows[0]["INVOICE_NO"]);
                sqlParams.Add(data.Rows[0]["INVOICE_DATE"]);
                sqlParams.Add(data.Rows[0]["COST_TOTAL"]);
                sqlParams.Add(data.Rows[0]["COST_DETAILS"]);
                sqlParams.Add(registeBy);
                sqlParams.Add(registeBy);
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlAddClinicPatient, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 登记检查病人
        /// </summary>
        /// <param name="data">HIS中获得的数据</param>
        /// <param name="registeBy">登记人id</param>
        /// <param name="admissionsType">病人类型</param>
        /// <param name="ph">病史类</param>
        /// <returns>bool</returns>
        public bool AddCheckPatient(DataTable data, int registeBy, string admissionsType,PatientHistory ph)
        {
            List<object> sqlParams = new List<object>();
            if (data != null && data.Rows.Count > 0)
            {
                sqlParams.Add(data.Rows[0]["PATIENT_NO"]);
                sqlParams.Add(data.Rows[0]["PATIENT_NAME"]);
                sqlParams.Add(data.Rows[0]["GENDER"]);
                sqlParams.Add(data.Rows[0]["BIRTHDAY"]);
                sqlParams.Add(data.Rows[0]["BLOOD_TYPE"]);
                sqlParams.Add(data.Rows[0]["TELEPHONE"]);
                sqlParams.Add(data.Rows[0]["ADDRESS"]);
                sqlParams.Add(data.Rows[0]["PATIENT_TYPE"]);
                sqlParams.Add(admissionsType);
                sqlParams.Add(data.Rows[0]["INVOICE_NO"]);
                sqlParams.Add(data.Rows[0]["INVOICE_DATE"]);
                sqlParams.Add(data.Rows[0]["COST_TOTAL"]);
                sqlParams.Add(data.Rows[0]["COST_DETAILS"]);
                sqlParams.Add(registeBy);
                sqlParams.Add(registeBy);
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
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlAddCheckPatient, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 待排队和排队队列中查询病人
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <returns>病人信息</returns>
        public DataTable GetLinePatientByNO(string patientNO)
        {
            object[] sqlParams = new object[] { patientNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlLineViewSelectByPatientNO, sqlParams);
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
        /// 待排队和排队队列中查询病人
        /// </summary>
        /// <param name="invoiceNO">发票编号</param>
        /// <returns>病人信息</returns>
        public DataTable GetLinePatientByInvoiceNO(string invoiceNO)
        {
            object[] sqlParams = new object[] { invoiceNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlLineViewSelectByInvoiceNO, sqlParams);
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
        /// 登记未排队队列中查询病人
        /// </summary>
        /// <param name="patientNO">发票编号</param>
        /// <returns>病人信息</returns>
        public DataTable GetNotLinePatientByPatientNO(string patientNO)
        {
            object[] sqlParams = new object[] { patientNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlNotLineSelectByPatientNO, sqlParams);
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
        /// 登记未排队队列中查询病人
        /// </summary>
        /// <param name="invoiceNO">发票编号</param>
        /// <returns>病人信息</returns>
        public DataTable GetNotLinePatientByInvoiceNO(string invoiceNO)
        {
            object[] sqlParams = new object[] { invoiceNO };
            DataTable dtResult = CJia.DefaultSQL.Query(SqlTools.sqlNotLineSelectByInvoiceNO, sqlParams);
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
        /// 根据病人卡号修改病人状态
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <returns>bool</returns>
        public bool ModifyStateByPatientNO(string patientNO)
        {
            object[] sqlParams = new object[] { patientNO };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdatePatientStateByNO, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据数据类型，字典中得到值
        /// </summary>
        /// <param name="codeType">数据类型</param>
        /// <returns></returns>
        public DataTable GetCodeValueByType(string codeType)
        {
            object[] sqlParams = new object[] { codeType };
            DataTable dtResult=CJia.DefaultSQL.Query(SqlTools.sqlSelectCodeValueByType, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        #endregion
        
        /// <summary>
        /// 转换数据
        /// </summary>
        /// <param name="data">源数据</param>
        /// <returns>新数据</returns>
        public DataTable ChangeDate(DataTable data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string admissionsType = data.Rows[0]["DEPARTMENT_NAME"].ToString();
                if (admissionsType == "")
                {
                    data.Rows[i]["DEPARTMENT_NAME"] = "阴道镜检查费";
                }
                else
                {
                    data.Rows[i]["DEPARTMENT_NAME"] = "门诊挂号费";
                }
            }
            return data;
        }


        # region 排队
        /// <summary>
        /// 绑定正在排队病人列表   by zeng
        /// </summary>
        /// <returns>所有正在排队的病人</returns>
        public DataTable GetPatientByExistQueue()
        {
            DataTable dtNotExistQueue = CJia.DefaultSQL.Query(SqlTools.sqlSelectByPatientRegisterQueue);
            if (dtNotExistQueue != null && dtNotExistQueue.Rows.Count > 0)
            {
                return dtNotExistQueue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据病人Id取消病人排队 by zeng
        /// </summary>
        /// <param name="patientId">病人Id</param>
        /// <returns></returns>
        public bool IsSuccessCancleQueue(long patientId)
        {
            List<object> sqlParams = new List<object>();
            if (patientId != 0)
            {
                sqlParams.Add(patientId);
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateByCancleQueue, sqlParams) > 0 ? true : false;
        }
        #endregion
    }
}
