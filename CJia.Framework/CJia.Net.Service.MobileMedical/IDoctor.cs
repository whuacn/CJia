using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CJia.Net;

namespace CJia.Net.Service.MobileMedical
{
    /// <summary>
    /// 医生查房接口
    /// </summary>
    [CJiaService(Version = "1.0.0.0")]
    public interface IDoctor
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserCode">工号</param>
        /// <param name="Password">密码</param>
        /// <param name="ClientTag">客户端信息</param>
        byte[] Login(string UserCode, string Password, string ClientTag);
        /// <summary>
        /// 获取病人列表
        /// </summary>
        /// <param name="IllfieldID"></param>
        /// <returns></returns>
        byte[] QueryIllfieldPatientList(string IllfieldID);
        /// <summary>
        /// 获取医生值班病区列表
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        byte[] QueryDoctorDutyIllfield(string DoctorID);
        /// <summary>
        /// 获取医生的新病人列表（检查是否有新病人）（在Patient表中，但不在DoctorPatients表中）
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="OfficeID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] SyncDevicePatientsFromServer(string DoctorID, string OfficeID, string DeviceID);
        /// <summary>
        /// 查询并同步病人住院医嘱信息
        /// </summary>
        /// <param name="InhosID">住院流水号</param>
        /// <param name="DeviceID">设备ID</param>
        /// <returns></returns>
        byte[] QueryPatientAdvices(string InhosID, string DeviceID);
        /// <summary>
        /// 查询病人的查房日志
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryDoctorCheckLog(string InhosID, string DeviceID);
        /// <summary>
        /// 查询病人查房影像数据
        /// </summary>
        /// <param name="InhosID"></param>
        /// <returns></returns>
        byte[] QueryPatientCheckImages(string InhosID);
        /// <summary>
        /// 同步本地数据到服务器
        /// </summary>
        /// <returns></returns>
        bool SyncLocalData(string TableName, string KeyField, string KeyValue, string ChangeType, string ChangeDate, string[] Fields, object[] Data);
        /// <summary>
        /// 查询病人的病历文书
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID">设备ID</param>
        /// <returns></returns>
        byte[] QueryPatientEmrDoc(string InhosID, string DeviceID);
        /// <summary>
        /// 查询代码信息
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        byte[] QueryCodeList(string Group);
        /// <summary>
        /// 查询LIS医嘱信息
        /// </summary>
        /// <param name="IllcaseNo"></param>
        /// <returns></returns>
        byte[] QueryLisAdvice(string IllcaseNo, string DeviceID);
        /// <summary>
        /// 查询LIS结果信息
        /// </summary>
        /// <param name="IllcaseNo"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryLisResult(string IllcaseNo, string DeviceID);
        /// <summary>
        /// 查询病人费用信息
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryPatientFee(string InhosID, string DeviceID);
        /// <summary>
        /// 查询病人预交款
        /// </summary>
        /// <param name="InhosID"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryPatientPrepay(string InhosID,string DeviceID);
        /// <summary>
        /// 查询医嘱子类别
        /// </summary>
        /// <param name="AdviceTypeID"></param>
        /// <returns></returns>
        byte[] QuerySubTypeList(string AdviceTypeID);
        /// <summary>
        /// 查询有变化的数据表
        /// </summary>
        /// <param name="PadTableChangeList"></param>
        /// <returns></returns>
        byte[] QueryChangeTable(string[] PadTableChangeList);
        /// <summary>
        /// 从服务器同步数据到Pad
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        byte[] SyncDataFromServer(string DeviceID, string TableName, string PrimaryKey, string IsInitData);
        /// <summary>
        /// 保存Pad同步日志到服务器
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="TableName"></param>
        /// <param name="LastChangeDate"></param>
        /// <returns></returns>
        bool SavePadSyncLog(string DeviceID, string TableName, string LastChangeDate);
        /// <summary>
        /// 查询检查报告
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryCheckApply(string InhosID, string DeviceID);
        /// <summary>
        /// 查询检查报告结果
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        byte[] QueryCheckResult(string InhosID, string DeviceID);
    }
}
