using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class QueueModel
    {
        /// <summary>
        /// 绑定登记未排队病人列表
        /// </summary>
        /// <returns>登记未排队病人数据集</returns>
        public DataTable GetPatientByNotExistQueue()
        {
            return CJia.DefaultSQL.Query(SqlTools.sqlSelectByPatientNotExistQueue);
        }

        /// <summary>
        /// 绑定正在排队病人列表
        /// </summary>
        /// <returns>所有正在排队的病人</returns>
        public DataTable GetPatientByExistQueue()
        {
            return CJia.DefaultSQL.Query(SqlTools.sqlSelectByPatientExistQueue);

        }

        /// <summary>
        /// 根据病人ID查询该病人数据
        /// </summary>
        /// <param name="patientId">病人Id</param>
        /// <returns>病人信息</returns>
        public DataTable GetPatientByID(long patientId)
        {
            object[] sqlParams = new object[] { patientId };
            return CJia.DefaultSQL.Query(SqlTools.sqlSelectPatientById, sqlParams);
        }

        /// <summary>
        /// 查询所有诊室
        /// </summary>
        /// <returns>所有诊室名称</returns>
        public DataTable GetClinicName()
        {
            return CJia.DefaultSQL.Query(SqlTools.sqlSelectClinicName);
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
        /// 根据病人Id修改诊室
        /// </summary>
        /// <param name="patientId">病人Id</param>
        /// <param name="clinicId">诊室Id</param>
        /// <returns>修改成功:true  ; 修改失败:false</returns>
        public bool IsUpdateSuccessByClinic(long patientId, long clinicId)
        {
            object[] sqlParams = new object[] { patientId, clinicId };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdatePatientByClinic, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据病人Id取消病人排队
        /// </summary>
        /// <param name="patientId">病人Id</param>
        /// <returns></returns>
        public bool IsSuccessCancleQueue(int patientId)
        {
            object[] sqlParams = new object[] { patientId };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateByCancleQueue, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 为登记等待排队病人根据病人Id取消等待
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool IsSuccessCancleWait(long patientId)
        {
            object[] sqlParams = new object[] { patientId };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateByCancleWait, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// radioGroup 筛选诊室选择病人排队数据
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns></returns>
        public DataTable GetPatientByFilterClinicId(long clinicId)
        {
            object[] sqlParams = new object[] { clinicId };
            return CJia.DefaultSQL.Query(SqlTools.sqlSelectPatientByFilterClinicId, sqlParams);
        }
    }
}
