using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class ClinicChooseModel
    {
        /// <summary>
        /// 查询所有诊室
        /// </summary>
        /// <returns>所有诊室名称</returns>
        public DataTable GetClinicName()
        {
            DataTable dtClinicName = CJia.DefaultSQL.Query(SqlTools.sqlSelectClinicName);
            return dtClinicName;
        }

        /// <summary>
        /// 根据病人Id修改诊室
        /// </summary>
        /// <param name="patientId">病人Id</param>
        /// <param name="clinicId">诊室Id</param>
        /// <returns>修改成功:true  ; 修改失败:false</returns>
        public bool IsUpdateSuccessByClinic(long patientId, long clinicId)
        {
            List<object> sqlParams = new List<object>();
            if (patientId != 0 && clinicId != 0)
            {
                sqlParams.Add(clinicId);
                sqlParams.Add(patientId);
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdatePatientByClinic, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据病人Id为病人分配诊室和排队编号
        /// </summary>
        /// <param name="patientId">病人ID</param>
        /// <param name="queueNo">为病人分配的队列编号</param>
        /// <param name="clinicId">为病人分配的诊室号</param>
        /// <returns>修改成功:true  ; 修改失败:false</returns>
        public bool IsSuccessAllocationClinic(long patientId, string queueNo, long clinicId)
        {
            List<object> sqlParams = new List<object>();
            if (patientId != 0 && clinicId != 0)
            {
                sqlParams.Add(queueNo);
                sqlParams.Add(clinicId);
                sqlParams.Add(patientId);
            }
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdatePatientQueueById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 获取排队编号
        /// </summary>
        /// <returns>下一个队列号</returns>
        public string GetPatientMaxQueueNo()
        {
            return CJia.DefaultSQL.QueryScalar(SqlTools.sqlSelectPatientMaxQueueNo);
            //if (nextQueueNo.Length == 0)
            //{
            //    return "1";
            //}
            //else
            //{
            //    return (long.Parse(nextQueueNo) + 1).ToString();
            //}
        }

        /// <summary>
        /// 为待排队病人分配诊室时插入阴道镜系统的病人表
        /// </summary>
        /// <returns></returns>
        public bool IsSuccessInsertColposcopyToSickData(DataRow dataRowBySelectedNoQueuePatient)
        {
            List<object> sqlParams = new List<object>();
            if (dataRowBySelectedNoQueuePatient != null)
            {
                sqlParams.Add(dataRowBySelectedNoQueuePatient["patient_no"]);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["patient_name"]);
                if (dataRowBySelectedNoQueuePatient["gender"].ToString().IndexOf("女") == 1)
                {
                    sqlParams.Add("female");
                }
                else
                {
                    sqlParams.Add("male");
                }
                sqlParams.Add(dataRowBySelectedNoQueuePatient["birthday"]);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["blood_type"]);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["telephone"]);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["REGISTER_DATE"]);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["ADDRESS"]);
                sqlParams.Add(DBNull.Value);
                sqlParams.Add(DBNull.Value);
            }
            return User.ada.Execute(SqlTools.sqlInsertColposcopyToSickData, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 为待排队病人分配诊室时插入阴道镜系统的病史表
        /// </summary>
        /// <returns></returns>
        public bool IsSuccessInsertColposcopyToSickHistoryData(DataRow dataRowBySelectedNoQueuePatient)
        {
            List<object> sqlParams = new List<object>();
            if (dataRowBySelectedNoQueuePatient != null)
            {
                string str = dataRowBySelectedNoQueuePatient["patient_no"].ToString().Remove(0, 1);
                string checkNo = str.Insert(0, "C");
                sqlParams.Add(checkNo);
                sqlParams.Add(dataRowBySelectedNoQueuePatient["patient_no"]);
                int age = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dataRowBySelectedNoQueuePatient["birthday"].ToString().Substring(0, 4));
                sqlParams.Add(age);
                //   受孕次数
                sqlParams.Add(dataRowBySelectedNoQueuePatient["PREGNANCY_NUM"]);
                //   procreatedTime生育次数
                sqlParams.Add(dataRowBySelectedNoQueuePatient["BIRTH_NUM"]);
                //   AbortedTime流产次数
                if (dataRowBySelectedNoQueuePatient["PREGNANCY_NUM"] == null || dataRowBySelectedNoQueuePatient["BIRTH_NUM"] == null)
                {
                    sqlParams.Add(DBNull.Value);
                }
                else
                {
                    int AbortedTime = int.Parse(dataRowBySelectedNoQueuePatient["PREGNANCY_NUM"].ToString()) - int.Parse(dataRowBySelectedNoQueuePatient["BIRTH_NUM"].ToString());
                    sqlParams.Add(AbortedTime);
                }

                // SexFriendNum
                sqlParams.Add(DBNull.Value);
                // Married
                sqlParams.Add(DBNull.Value);
                // HCG
                sqlParams.Add(DBNull.Value);
                // Lastedcatamenia 末次月经
                sqlParams.Add(dataRowBySelectedNoQueuePatient["MENSES_LAST"]);
                // contraceptMode 避孕方法
                sqlParams.Add(dataRowBySelectedNoQueuePatient["CONTRACEPTION_METHOD"]);
                // SmokedHistory 
                sqlParams.Add(DBNull.Value);
                // Occupation 职业
                sqlParams.Add(DBNull.Value);
                // SickSource 挂号诊室
                sqlParams.Add(dataRowBySelectedNoQueuePatient["ADMISSIONS_TYPE"]);
                // CheckDrName 检查医生
                sqlParams.Add(DBNull.Value);
                // CheckTime 检查时间
                sqlParams.Add(DBNull.Value);
                // SickHistoryNote 
                sqlParams.Add(DBNull.Value);
                // Evaluatescore
                sqlParams.Add(DBNull.Value);
                // EvaluatesResult
                sqlParams.Add(DBNull.Value);
                // PlanexamineRecord
                sqlParams.Add(DBNull.Value);
                // ImageFlag
                sqlParams.Add(DBNull.Value);
                // checkNO
                sqlParams.Add(1);
                //  CheckOwnNum
                sqlParams.Add(DBNull.Value);
            }
            return User.ada.Execute(SqlTools.sqlInsertColposcopyToSickHistoryData, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 判断阴道镜系统病人表中是否存在此次登记病人
        /// </summary>
        /// <param name="sickNum">病人卡号</param>
        public bool IsExistSickNumFormSickData(string sickNum)
        {
            object[] sqlParams = new object[] { sickNum };
            return User.ada.Query(SqlTools.sqlSelectSickNumFromSickData, sqlParams).Rows.Count > 0 ? true : false;
        }
    }
}
