using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Net.Business.MobileMedical
{
    public class SqlText
    {
        /// <summary>
        /// 从服务器数据库检索当前设备信息
        /// </summary>
        public static string SqlQueryServerDeviceInfo
        {
            get
            {
                return @"Select * From [iDevice] t Where t.[DeviceID] = @1";
            }
        }
        /// <summary>
        /// 从服务器数据库检索当前设备所属科室信息
        /// </summary>
        public static string SqlQueryServerDeviceOfficeInfo
        {
            get
            {
                return @"Select * From [iDeviceOffice] t Where t.[DeviceID] = @1";
            }
        }
        /// <summary>
        /// 保存设备信息
        /// </summary>
        public static string SqlSaveDeviceInfo
        {
            get 
            {
                return @"Insert Into [iDevice] ([DeviceID],[DeviceName],[Notes],[Status],[CreateDate],[LastSaveDate]) Values (@1,@2,@3,@4,@5,@6)";
            }
        }
        /// <summary>
        /// 修改设备信息
        /// </summary>
        public static string SqlUpdateDeviceInfo
        {
            get
            {
                return @"Update [iDevice] Set [DeviceName]=@1,[Notes]=@2,[Status]=@3,[LastSaveDate]=@4 Where [DeviceID]=@5";
            }
        }
        /// <summary>
        /// 删除设备科室设置
        /// </summary>
        public static string SqlDeleteDeviceOffice
        {
            get
            {
                return @"Delete From [iDeviceOffice] Where [DeviceID]=@1";
            }
        }
        /// <summary>
        /// 保存设备科室信息
        /// </summary>
        public static string SqlSaveDeviceOffice
        {
            get {
                return @"Insert Into [iDeviceOffice] ([DOID],[DeviceID],[OfficeID],[OfficeName],[CreateDate]) Values (@1,@2,@3,@4,@5)";
            }
        }
        /// <summary>
        /// 删除设备病人
        /// </summary>
        public static string SqlDeleteDevicePatient
        {
            get
            {
                return @"Delete From [iDevicePatient] Where [DeviceID]=@1";
            }
        }
        /// <summary>
        /// 保存设备病人至设备病人表中
        /// </summary>
        public static string SqlSaveDevicePatient
        {
            get {
                return @"Insert Into iDevicePatient ([DeviceID],[InhosID],[IllcaseNo],[PatientName],[CreateDate])
Select @1,[InhosID],[IllcaseNo],[PatientName],@2 From [Patient] p Where p.[OfficeID]=@3 And p.[InhosStatus]='正住院'";
            }
        }
        /// <summary>
        /// 从服务器数据库检索当前设备数量
        /// </summary>
        public static string SqlQueryServerDeviceCount
        {
            get
            {
                return @"Select Count(1) From [iDevice] t Where t.[DeviceID] = @1";
            }
        }
        /// <summary>
        /// 查询科室信息
        /// </summary>
        public static string SqlQueryDept
        {
            get
            {
                return @"Select * From [iDept]";
            }
        }
        /// <summary>
        /// 查询病区科室关联信息
        /// </summary>
        public static string SqlQueryIllfieldDept
        {
            get
            {
                return @"Select * From [iIllfieldDept]";
            }
        }
        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        public static string SqlQueryUserForLogin
        {
            get
            {
                return @"select * from [User] t where t.[Code] = @1 And t.[Password] = @2";
            }
        }

        /// <summary>
        /// 获取病区病人列表
        /// </summary>
        public static string SqlQueryIllfieldPatientList
        {
            get
            {
                return @"select * from [Patient] t Where t.[IllfieldID]=@1 And t.[InhosStatus]='正住院'";
            }
        }
        /// <summary>
        /// 获取医生值班病区
        /// </summary>
        public static string SqlQueryDoctorDutyIllfield
        {
            get
            {
                return @"select * from [DoctorIllfield] t Where t.[DoctorID]=@1";
            }
        }
        /// <summary>
        /// 查询医生的新病人数量
        /// </summary>
        public static string SqlQueryDoctorNewPatientCount
        {
            get
            {
                return @"Select count(1) From [Patient] p Where (p.[BedDoctor]=@1 Or p.[OfficeID]=@2) And p.[InhosID] Not In (Select t.[InhosID] From [DevicePatients] t Where t.[deviceid] = @3)";
            }
        }
        /// <summary>
        /// 获取医生的病人列表,用于存入本地库
        /// </summary>
        public static string SqlQueryDoctorPatientListToSync
        {
            get
            {
                return @"Select p.* From [Patient] p,[iDevicePatient] dp Where dp.[DeviceID] = @1 And dp.[InhosID] = p.[InhosID]";
            }
        }
        /// <summary>
        /// 插入医生的病人数据
        /// </summary>
        public static string SqlInsertDoctorPatient
        {
            get
            {
                return @"Insert Into [DoctorPatients] ([DPID],[DoctorID],[InhosID],[Status],[CreateDate],[RemoveDate]) Values (@1,@2,@3,@4,@5,@6)";
            }
        }
        /// <summary>
        /// 插入设备的病人数据
        /// </summary>
        public static string SqlInsertDevicePatient
        {
            get
            {
                return @"Insert Into [DevicePatients] ([DPID],[DeviceID],[InhosID],[SyncStatus],[LastSyncDate],[ChangeType]) Values (@1,@2,@3,@4,@5,@6)";
            }
        }
        /// <summary>
        /// 将该医生的新病人插入到设备病人列表中，若该设备无此病人；
        /// </summary>
        public static string SqlInsertDoctorPatientToDeviceList
        {
            get
            {
                return @"Insert Into [DevicePatients] ([DPID],[DeviceID],[InhosID],[SyncStatus],[LastSyncDate],[ChangeType])
Select @3||p.[InhosID],@3, p.[InhosID],'0',datetime('now'),'0000000000'
From [Patient] p 
Where (p.[BedDoctor] = @1 Or p.[OfficeID] = @2)
And p.[InhosID] Not In (Select [InhosID] From [DevicePatients] dp Where dp.[DeviceID] = @3)";
            }
        }
        /// <summary>
        /// 将新病人加入的医生的病人列表
        /// </summary>
        public static string SqlInsertPatientToDoctorList
        {
            get
            {
                return @"Insert Into [DoctorPatients] ([DPID],[DoctorID],[InhosID],[Status],[CreateDate])
Select @1||p.[InhosID],@1, p.[InhosID],'1',datetime('now')
From [Patient] p Where p.[BedDoctor] = @1 
And p.[InhosID] Not In (Select [InhosID] From [DoctorPatients] dp Where dp.[DoctorID] = @1)";
            }
        }
        /// <summary>
        /// 查询该医生是否已存在某病人
        /// </summary>
        public static string SqlQueryDoctorPatientCount
        {
            get {
                return @"Select Count(1) From [DoctorPatients] dp Where dp.[DPID] = @1";
            }
        }
        /// <summary>
        /// 查询该设备是否已存在某病人
        /// </summary>
        public static string SqlQueryDevicePatientCount
        {
            get
            {
                return @"Select Count(1) From [DevicePatients] dp Where dp.[DPID] = @1";
            }
        }
        /// <summary>
        /// 查询病人住院医嘱信息
        /// </summary>
        public static string SqlQueryPatientAdvices
        {
            get
            {
                return @"Select * From [PatientAdvices] pa Where pa.[InhosID] = @1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人的住院医嘱信息
        /// </summary>
        public static string SqlQueryDevicePatientAdvices
        {
            get
            {
                return @"Select pa.* From [PatientAdvices] pa,[DevicePatients] dp Where pa.[InhosID] = dp.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询病人住院病历文书
        /// </summary>
        public static string SqlQueryPatientEmrDoc
        {
            get
            {
                return @"Select * From [PatientEmrDoc] ed Where ed.[InhosID] = @1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人的住院病历文书
        /// </summary>
        public static string SqlQueryDevicePatientEmrDoc
        {
            get
            {
                return @"Select ed.* From [PatientEmrDoc] ed,[DevicePatients] dp Where ed.[InhosID] = dp.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询代码信息
        /// </summary>
        public static string SqlQueryCodeList
        {
            get
            {
                return @"Select * From [iCode] Where [GroupName] = @1";
            }
        }
        /// <summary>
        /// 查询某病人的查房日志
        /// </summary>
        public static string SqlQueryPatientCheckLogList
        {
            get
            {
                return @"Select * From [DoctorCheckLog] Where [InhosID]=@1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人的查房日志
        /// </summary>
        public static string SqlQueryDevicePatientCheckLogList
        {
            get
            {
                return @"Select dc.* From [DoctorCheckLog] dc,[DevicePatients] dp Where dc.[InhosID] = dp.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询某病人的查房日志明细
        /// </summary>
        public static string SqlQueryPatientCheckLogDetailList
        {
            get
            {
                return @"Select * From [DoctorCheckDetail] Where [InhosID]=@1";
            }
        }
        /// <summary>
        /// 查询病人查房影像数据
        /// </summary>
        public static string SqlQueryPatientCheckImageList
        {
            get
            {
                return @"Select * From [PatientCheckImages] Where [InhosID]=@1";
            }
        }
        /// <summary>
        /// 查询LIS医嘱信息
        /// </summary>
        public static string SqlQueryLisAdvice
        {
            get
            {
                return @"Select * From [LisAdvice] Where [IllcaseNo]=@1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人的LIS医嘱信息
        /// </summary>
        public static string SqlQueryDeviceLisAdvice
        {
            get
            {
                return @"Select la.* From [LisAdvice] la,[DevicePatients] dp,[Patient] p Where la.[IllcaseNo]=p.[IllcaseNo] And dp.[InhosID]=p.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询LIS结果信息
        /// </summary>
        public static string SqlQueryLisResult
        {
            get
            {
                return @"select r.* from [LisResult] r where r.[IllcaseNo] =@1";
            }
        }
        /// <summary>
        /// 查询LIS结果信息
        /// </summary>
        public static string SqlQueryDeviceLisResult
        {
            get
            {
                return @"Select lr.* From [LisResult] lr,[DevicePatients] dp,[Patient] p Where lr.[IllcaseNo]=p.[IllcaseNo] And dp.[InhosID]=p.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询费用信息
        /// </summary>
        public static string SqlQueryPatientFee
        {
            get
            {
                return @"Select * From [PatientFee] Where [InhosID]=@1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人费用信息
        /// </summary>
        public static string SqlQueryDevicePatientFee
        {
            get
            {
                return @"Select pf.* From [PatientFee] pf,[DevicePatients] dp Where pf.[InhosID] = dp.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询预交款信息
        /// </summary>
        public static string SqlQueryPatientPrepay
        {
            get
            {
                return @"Select * From [PatientPrepay] where [InhosID] = @1";
            }
        }
        /// <summary>
        /// 查询设备中所有病人预交款信息
        /// </summary>
        public static string SqlQueryDevicePatientPrepay
        {
            get
            {
                return @"Select pp.* From [PatientPrepay] pp,[DevicePatients] dp Where pp.[InhosID] = dp.[InhosID] And dp.[DeviceID]=@1";
            }
        }
        /// <summary>
        /// 查询医嘱子类别
        /// </summary>
        public static string SqlQuerySubTypeList
        {
            get
            {
                return @"select * from [iType2] where [AdviceTypeID] = @1";
            }
        }
        /// <summary>
        /// 查询变化的数据表
        /// </summary>
        public static string SqlQueryTableChangeList
        {
            get
            {
                return @"Select * From [iTableChange]";
            }
        }
        /// <summary>
        /// 查询设备对应的变化的数据表
        /// </summary>
        public static string SqlQueryChangeDataByDevice
        {
            get
            {
                return @"Select T.*,C.[ChangeType] From [iDataChangeLog] C,[{0}] T Where C.[TableName] = @1 And T.[{1}] = C.[KeyValue]
  And Not Exists (Select 1 From [iDataSyncLog] S 
                  Where S.[DeviceID]=@2 
                    And S.[TableName]=@3 
                    And C.[KeyValue]=S.[KeyValue] 
                    And C.[LastChangeDate]=S.[LastChangeDate]
                    And '1'=@4)";
            }
        }
        /// <summary>
        /// 插入或更新Pad在服务器中同步日志
        /// </summary>
        public static string SqlInsertSyncLogFromServer
        {
            get
            {
                return @"Replace Into [iDataSyncLog]
Select '{0}',c.[TableName],c.[KeyValue],c.[LastChangeDate]
From [iDataChangeLog] c
where c.[TableName] = @1
and c.[LastChangeDate] <= @2";
            }
        }
        /// <summary>
        /// 查询检查报告
        /// </summary>
        public static string SqlQueryDeviceCheckApply
        {
            get {
                return @"Select ca.* From [CheckApply] ca,[DevicePatients] dp
Where ca.[InhosID] = dp.[InhosID]
and dp.[DeviceID] = @1";
            }
        }
        /// <summary>
        /// 查询检查报告
        /// </summary>
        public static string SqlQueryCheckApply
        {
            get
            {
                return @"Select ca.* From [CheckApply] ca Where ca.[InhosID] = @1";
            }
        }
        /// <summary>
        /// 查询检查结果
        /// </summary>
        public static string SqlQueryCheckResult
        {
            get {
                return @"Select cr.* From [CheckApply] ca,[CheckResult] cr Where ca.[InhosID] =@1 and ca.[ApplyNo] = cr.[ApplyNo]";
            }
        }
        /// <summary>
        /// 查询检查结果
        /// </summary>
        public static string SqlQueryDeviceCheckResult
        {
            get
            {
                return @"Select cr.* From [CheckApply] ca,[CheckResult] cr,[DevicePatients] dp
Where ca.[InhosID] = dp.[InhosID]
and ca.[ApplyNo] = cr.[ApplyNo]
and dp.[DeviceID] = @1";
            }
        }
    }
}
