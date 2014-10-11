using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SqlTools 的摘要说明
/// </summary>
public class SqlTools
{
	public SqlTools()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region【MainPage】
    /// <summary>
    /// 查询某医生下某类型（住院，出院）的病人个数
    /// </summary>
    public static string SqlQueryMyPatientCount
    {
        get
        {
            return @"Select Count(*) MyPatientCount From [Patient] p Where p.[BedDoctor]=:1 And p.[InhosStatus]=:2";
        }
    }

    /// <summary>
    /// 查询某科室下某类型(正住院 出院..)的病人个数
    /// </summary>
    public static string SqlQueryDeptPatientCount
    {
        get
        {
            return "Select Count(*) DeptPatientCount From [Patient] p Where p.[OfficeID]=:1 And p.[InhosStatus]=:2";
        }
    }

    /// <summary>
    /// 查询某医生下(值班病人,近期病人)的个数
    /// </summary>
    public static string SqlQueryDoctorPatientCount
    {
        get
        {
            return @"Select Count(*) DoctorPatientsCount From [DoctorPatients] dp Where dp.[DoctorID]=:1 And dp.[DPType]=:2";
        }
    }

    /// <summary>
    /// 查询医嘱类型不是中药、草药、中成药的医嘱的个数
    /// </summary>
    public static string SqlQueryNoPharmAdviceCount
    {
        get
        {
            return @"select count(*) NoPharmAdviceCount from [iAdvice] ia Where ia.[AdviceType] not in (901001,901002,901003)";
        }
    }

    /// <summary>
    /// 查询医嘱类型是中药、草药、中成药的医嘱的个数
    /// </summary>
    public static string SqlQueryPharmAdviceCount
    {
        get
        {
            return @"select count(*) PharmAdviceCount from [iAdvice] ia Where ia.[AdviceType] in (901001,901002,901003)";
        }
    }
    
    /// <summary>
    /// 查询医生下的病人信息
    /// </summary>
    public static string SqlQueryMyPatient
    {
        get
        {
            return @"Select p.* From [Patient] p Where p.[BedDoctor]=:1 And p.[InhosStatus]=:2";
        }
    }

    /// <summary>
    /// 查询科室病人
    /// </summary>
    public static string SqlQueryDeptPatient
    {
        get
        {
            return @"Select p.* From [Patient] p Where p.[OfficeID]=:1 And p.[InhosStatus]=:2";
        }
    }

    /// <summary>
    /// 查询值班、近期病人信息
    /// </summary>
    public static string SqlQueryDutyResentPatientList
    {
        get
        {
            return @"Select *
                     From Patient p
                     Where Exists (Select 1
                              From DoctorPatients dp
                             Where dp.DoctorID  = :1
                               And dp.InhosID = p.InhosID
                               And dp.DPType = :2)";
        }
    }

    /// <summary>
    /// 查询医生近期病人信息
    /// </summary>
    public static string SqlQueryResentPatientList
    {
        get
        {
            return @"Select *
                     From Patient p
                     Where Exists (Select 1
                              From DoctorPatients dp
                             Where dp.DoctorID= :1
                               And dp.InhosID = p.InhosID
                               And dp.DPType = :2
                               And dp. CreateDate  = :3)";
        }
    }

    #endregion

    #region【PatientCheckPage】
    /// <summary>
    /// 查询近期病人个数
    /// </summary>
    public static string SqlQueryRecentPatientCount
    {
        get
        {
            return @"Select Count(1)
                      From DoctorPatients
                     Where DPID = :1
                       And CreateDate = :2
                       And DPType =:3";
        }
    }

    /// <summary>
    /// 插入一条近期/值班病人信息
    /// </summary>
    public static string SqlInsertDoctorPatients
    {
        get
        {
            return @" insert into DoctorPatients
                       (DPID, DoctorID, InhosID, DPType, CreateDate) 
                     values
                       (:1, :2, :3, :4, :5)";

//            return @" insert into DoctorPatients
//                       (DPID, DoctorID, InhosID, DPType, CreateDate) 
//                     values
//                       (1, 2, 3,3, 4)";
        }
    }
    #endregion

    #region【AdciceListPage】
    /// <summary>
    /// 查询病人医嘱类型下的医嘱个数
    /// </summary>
    public static string SqlQueryAdviceCount
    {
        get
        {
            return @"Select '全部' As AdviceType, Count(1) As GroupCount
                      From PatientAdvices pa
                     Where pa.InhosID = :1
                       And pa.StandingFlag = :2   
                    union all
                    Select AdviceType, Count(1) As GroupCount
                      From PatientAdvices pa
                     Where pa.InhosID = :3
                       And pa.StandingFlag = :4
                     Group By AdviceType";
        }
    }

    /// <summary>
    /// 查询病人医嘱信息
    /// </summary>
    public static string SqlQueryAdvice
    {
        get
        {
            return @"Select pa.* From PatientAdvices pa Where pa.InhosID = :1 Order By ListDate";
        }
    }

    #endregion

    #region【MedicalRecord】
    /// <summary>
    /// 查询病历文书
    /// </summary>
    public static string SqlQueryEmrDocHeader
    {
        get
        {
            return @"Select InhosID,
                       SectionNo,
                       DocTypeID,
                       DocTypeName,
                       Title,
                       Creator,
                       CreateDate,
                       CheckDate
                  From PatientEmrDoc pa
                 Where pa. InhosID = :1";
        }
    }

    /// <summary>
    /// 查询病人病历文书详细信息
    /// </summary>
    public static string SqlQueryPatientEmrDocDetail
    {
        get
        {
            return @"Select pa.*
                      From PatientEmrDoc pa
                     Where pa.InhosID = :1
                       And pa.SectionNo = :2";
        }
    }
    #endregion

    #region【CheckReport】
    /// <summary>
    /// 查询检查申请
    /// </summary>
    public static string SqlQueryCheckApply
    {
        get
        {
            return @"Select * From CheckApply Where InhosID = :1 Order By ReportDate Desc";
        }
    }

    /// <summary>
    /// 查询检查结果
    /// </summary>
    public static string SqlQueryCheckResult
    {
        get
        {
            return @"Select cr.*
                      From CheckApply ca, CheckResult cr
                     Where ca.InhosID = :1
                       and ca.ApplyNo = cr.ApplyNo
                     Order By SerialNo";
        }
    }
    #endregion

    #region【iCode】
    /// <summary>
    /// 查询代码信息
    /// </summary>
    public static string SqlQueryCodeListByGroup
    {
        get
        {
            return @"Select * From iCode Where GroupName=:1";
        }
    }
    #endregion

    #region【】
    /// <summary>
    /// 查询本地病人LIS结果
    /// </summary>
    public static string SqlQueryLisResult
    {
        get
        {
            return @"Select *
                      From LisResult
                     Where IllcaseNo = :1
                     Order By ReportDate Desc";
        }
    }
    #endregion

    #region【AdviceInputPage】
    /// <summary>
    /// 查询医嘱信息
    /// </summary>
    public static string SqlQueryAdviceByLike
    {
        get
        {
            return @"Select *
                      From iAdvice
                     Where AdviceType = :1
                       And AdviceFilter Like :2
                       And (StandingType =:3 Or StandingType = '9')";
        }
    }

    /// <summary>
    /// 查询用法
    /// </summary>
    public static string SqlQueryUsage
    {
        get
        {
            return @"Select * From iUsage";
        }
    }

    /// <summary>
    /// 查询频率
    /// </summary>
    public static string SqlQueryFrequence
    {
        get
        {
            return @"Select * From iFrequency";
        }
    }
    #endregion

    #region【ChecklogDetailpage】
    /// <summary>
    /// 查询查房日志
    /// </summary>
    public static string SqlQueryCheckLogDetail
    {
        get
        {
            return @"Select *
                      From DoctorCheckLog
                     Where InhosID = :1
                       And LogType = :2
                     Order By CheckDate, CheckTime Desc";
        }
    }

    /// <summary>
    /// 查询此日志是否存在
    /// </summary>
    public static string SqlCheckLogExist
    {
        get
        {
            return @"Select * From DoctorCheckLog Where DCLID=:1";
        }
    }
    #endregion

}