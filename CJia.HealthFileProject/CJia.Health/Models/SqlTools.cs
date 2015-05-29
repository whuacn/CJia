using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    /// <summary>
    /// SQL语句定义
    /// </summary>
    public class SqlTools
    {
        #region 病人页面输入

        //用户工作量统计
        public static string SqlQueryUserWorkAll
        {
            get
            {
                return @"select u.user_no,pt.pat_commit_name, pt.recordno,pt.patient_name,pt.in_hospital_time,count(*) total,u.user_no||'['||pt.pat_commit_name||']' groupName
                      from gm_patient pt, st_picture pic,gm_user u
                     where pt.check_status = '101'
                       and pt.id = pic.health_id
                       and pt.status='1'
                       and pic.status='1'
                       and pt.pat_commit_id=u.user_id
                       and pt.pat_commit_date between ? and ?
                       and (pt.pat_commit_name like ?
                       or u.user_no like ?)
                       group by pt.recordno,pt.patient_name,pt.in_hospital_time,pt.pat_commit_name,u.user_no";
            }
        }
        public static string SqlQueryUserWorkTotal
        {
            get
            {
                return @"select u.user_no,pt.pat_commit_name,count(*) total,count(distinct pt.id) sub
                      from gm_patient pt, st_picture pic,gm_user u
                     where pt.check_status = '101'
                       and pt.id = pic.health_id
                       and pt.status='1'
                       and pic.status='1'
                       and pt.pat_commit_id=u.user_id
                       and pt.pat_commit_date between ? and ?
                       and (pt.pat_commit_name like ?
                       or u.user_no like ?)
                       group by pt.pat_commit_id,pt.pat_commit_name,u.user_no";
            }
        }
        #region 查询下拉列表信息
        /// <summary>
        /// 从字典表查询性别
        /// </summary>
        public static string SqlSelectGender
        {
            get
            {
                return @"SELECT CODE,NAME FROM GM_CODE WHERE CODE_TYPE = 'GENDER'";
            }
        }

        /// <summary>
        /// 从字典表查询婚姻状况
        /// </summary>
        public static string SqlSelectIsMarry
        {
            get
            {
                return @"SELECT CODE,NAME FROM GM_CODE WHERE CODE_TYPE = 'IS_MARRY'";
            }
        }

        /// <summary>
        /// 从字典表查询职业
        /// </summary>
        public static string SqlSelectJob
        {
            get
            {
                return @"SELECT CODE,NAME FROM GM_CODE WHERE CODE_TYPE = 'JOB'";
            }
        }

        /// <summary>
        /// 字典表查询病案质量
        /// </summary>
        public static string SqlSelectRecordQuality
        {
            get
            {
                return @"select * from gm_code where code_type='RECORD_QUALITY'";
            }
        }

        /// <summary>
        /// 从地区表查询省(直辖市)
        /// </summary>
        public static string SqlSelectProvince
        {
            get
            {
                return @"SELECT * FROM GM_AREA WHERE PARENT_ID IS NULL ORDER BY PINYIN";
            }
        }

        /// <summary>
        /// 从地区表查市(县)
        /// </summary>
        public static string SqlSelectCity
        {
            get
            {
                return @"SELECT * FROM GM_AREA WHERE PARENT_ID IS NOT NULL ORDER BY PINYIN";
            }
        }

        /// <summary>
        /// 从GM_CODE表查找民族
        /// </summary>
        public static string SqlSelectNation
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'NATION' ORDER BY PINYIN";
            }
        }

        /// <summary>
        /// 从GM_COUNTRY表查找国家信息
        /// </summary>
        public static string SqlSelectCountry
        {
            get
            {
                return @"SELECT * FROM GM_COUNTRY";
            }
        }

        /// <summary>
        /// 查找入院方式
        /// </summary>
        public static string SqlSelectInHospitalType
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'IN_HOSPITAL_TYPE'";
            }
        }

        /// <summary>
        /// 查找科室
        /// </summary>
        public static string SqlSelectDept
        {
            get
            {
                return @"SELECT DEPT_ID,DEPT_NAME,DEPT_NO FROM GM_DEPT WHERE STATUS = '1' ORDER BY FIRST_PINYIN";
            }
        }

        /// <summary>
        /// 查找医生
        /// </summary>
        public static string SqlSelectDoctor
        {
            get
            {
                return @"SELECT DOCTOR_ID,DOCTOR_NAME,DOCTOR_NO FROM GM_DOCTOR WHERE STATUS = '1'";
            }
        }

        /// <summary>
        /// 查找ICD编码
        /// </summary>
        public static string SqlSelectICDCode
        {
            get
            {
                return @"SELECT * FROM GM_ICDCODE";
            }
        }

        /// <summary>
        /// 治疗结果
        /// </summary>
        public static string SqlSelectTreatResult
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'TREAT_RESULT'";
            }
        }

        /// <summary>
        /// 查找血型
        /// </summary>
        public static string SqlSelectBloodType
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'BLOOD_TYPE'";
            }
        }

        /// <summary>
        /// 诊断结果
        /// </summary>
        public static string SqlSelectDiagnosisResult
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'DIAGNOSIS_RESULT'";
            }
        }
        #endregion

        /// <summary>
        /// 插入GM_PATIENT表基本信息
        /// </summary>
        public static string SqlInsertGmPatient
        {
            get
            {
                return @"insert into gm_patient
                  (id, patient_id, patient_name, recordno, shelfno, is_special, 
                gender, birthday, is_marry, job, province, city, nation, country,
                id_card, in_hospital_type, in_hospital_time, in_hospital_date, out_hospital_date,
                in_hospital_dept, out_hospital_dept, in_hospital_room, out_hospital_room,
                drug_allergy, blood_type, icd_outdia1, outdia_name1, icd_outdia2, outdia_name2,
                icd_outdia3, outdia_name3, icd_outdia4, outdia_name4, icd_surgery1, surgery_name1,
                icd_surgery2, surgery_name2, icd_surgery3, surgery_name3, icd_surgery4, surgery_name4, 
                treat_result1, treat_result2, treat_result3, treat_result4, icd_blzd1, blzd_name1, 
                icd_blzd2, blzd_name2, icd_yngr1, yngr_name1, icd_yngr2, yngr_name2, outpatient_out_dia, 
                in_out_hospital_dia, begore_after_surgery_dia, radiation_after_dia, clinical_pathology_dia,
                check_status, lock_status, status, create_date, create_by, pat_commit_id, pat_commit_name, 
                pat_commit_date,patient_age,patient_address,dept_director,
                dept_doctor,
                main_doctor,
                in_hospital_doctor,
                advance_study_doctor,
                graduate_practice_doctor,
                practice_doctor,
                record_quality,
                qc_doctor,
                qc_nurse, 
                surgery_date1,
                surgery_date2,
                surgery_date3,
                surgery_date4)
                values
                  (GM_PATIENT_SEQ.NEXTVAL,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?,?,?,?,
                         '100','110','1',SYSDATE,?,?,?,SYSDATE,?,?,
                         ?,?,?,?,?,?,?,?,?,?,
                         ?,?,?,?)";
            }
        }

        /// <summary>
        /// 根据病案号修改病人表
        /// </summary>
        public static string SqlUpdateGmPatient
        {
            get
            {
                return @"update gm_patient
                           set patient_id = ?,
                               patient_name = ?,
                               shelfno = ?,
                               is_special = ?,
                               gender = ?,
                               birthday = ?,
                               is_marry = ?,
                               job = ?,
                               province = ?,
                               city = ?,
                               nation = ?,
                               country = ?,
                               id_card = ?,
                               in_hospital_type = ?,
                               in_hospital_time = ?,
                               in_hospital_date = ?,
                               out_hospital_date = ?,
                               in_hospital_dept = ?,
                               out_hospital_dept = ?,
                               in_hospital_room = ?,
                               out_hospital_room = ?,
                               drug_allergy = ?,
                               blood_type = ?,
                               icd_outdia1 = ?,
                               outdia_name1 = ?,
                               icd_outdia2 = ?,
                               outdia_name2 = ?,
                               icd_outdia3 = ?,
                               outdia_name3 = ?,
                               icd_outdia4 = ?,
                               outdia_name4 = ?,
                               icd_surgery1 = ?,
                               surgery_name1 = ?,
                               icd_surgery2 = ?,
                               surgery_name2 = ?,
                               icd_surgery3 = ?,
                               surgery_name3 = ?,
                               icd_surgery4 = ?,
                               surgery_name4 = ?,
                               treat_result1 = ?,
                               treat_result2 = ?,
                               treat_result3 = ?,
                               treat_result4 = ?,
                               icd_blzd1 = ?,
                               blzd_name1 = ?,
                               icd_blzd2 = ?,
                               blzd_name2 = ?,
                               icd_yngr1 = ?,
                               yngr_name1 = ?,
                               icd_yngr2 = ?,
                               yngr_name2 = ?,
                               outpatient_out_dia = ?,
                               in_out_hospital_dia = ?,
                               begore_after_surgery_dia = ?,
                               radiation_after_dia = ?,
                               clinical_pathology_dia = ?,
                               update_by = ?,
                               update_date = sysdate,
                               dept_director = ?,
                               dept_doctor = ?,
                               main_doctor = ?,
                               in_hospital_doctor = ?,
                               advance_study_doctor = ?,
                               graduate_practice_doctor = ?,
                               practice_doctor = ?,
                               record_quality = ?,
                               qc_doctor = ?,
                               qc_nurse = ?
                         where recordno = ? and status = '1'";
            }
        }

        /// <summary>
        /// 接口中读取病人信息
        /// </summary>
        public static string SqlSelectPatientInfoFromInterface
        {
            get
            {
                return @"select t.* from GM_HEALTH_VIEW t where t.RECORD_NO = ? and t.IN_HOSPITAL_TIME = ?";
            }
        }

        /// <summary>
        /// 根据省筛选市
        /// </summary>
        public static string SqlSelectCityByProvince
        {
            get
            {
                return @"select * from gm_area where parent_id = ? order by pinyin";
            }
        }

        /// <summary>
        /// 根据所输内容模糊查询省
        /// </summary>
        public static string SqlSelectProvinceBySearch
        {
            get
            {
                return @"SELECT * FROM GM_AREA WHERE PARENT_ID IS NULL AND PINYIN LIKE ? ORDER BY PINYIN";
            }
        }

        /// <summary>
        /// 省模糊查询
        /// </summary>
        public static string SqlSelectCityBySearch
        {
            get
            {
                return @"SELECT * FROM GM_AREA WHERE PARENT_ID IS NOT NULL AND PINYIN LIKE ? ORDER BY PINYIN";
            }
        }

        /// <summary>
        /// 模糊查询ICD信息
        /// </summary>
        public static string SqlSelectICDBySearch
        {
            get
            {
                return @"SELECT * FROM GM_ICDCODE WHERE ICD10_CODE LIKE ? OR ICD10_NAME LIKE ?";
            }
        }

        /// <summary>
        /// 模糊查询民族
        /// </summary>
        public static string SqlSelectNationBySearch
        {
            get
            {
                return @"SELECT * FROM GM_CODE WHERE CODE_TYPE = 'NATION' AND(NAME LIKE ? OR PINYIN LIKE ?)";
            }
        }

        /// <summary>
        /// 模糊查询国家
        /// </summary>
        public static string SqlSelectCountryBySearch
        {
            get
            {
                return @"SELECT * FROM GM_COUNTRY WHERE COUNTRY_NAME LIKE ? OR PINYIN LIKE ?";
            }
        }

        /// <summary>
        /// 部门模糊查询
        /// </summary>
        public static string SqlSelectDeptBySearch
        {
            get
            {
                return @"SELECT * FROM GM_DEPT WHERE STATUS = '1' AND (DEPT_NO LIKE ? OR FIRST_PINYIN LIKE ?) ORDER BY FIRST_PINYIN";
            }
        }

        /// <summary>
        /// 医生模糊查询
        /// </summary>
        public static string SqlSelectDoctorBySearch
        {
            get
            {
                return @"SELECT * FROM GM_DOCTOR WHERE STATUS = '1' AND (DOCTOR_NO LIKE ? OR DOCTOR_NAME LIKE ? OR FIRST_PINYIN LIKE ?)";
            }
        }

        /// <summary>
        /// 查询库中是否存在页面病案号
        /// </summary>
        public static string SqlQueryPatientByRecordNo
        {
            get
            {
                return @"select * from gm_patient_view where recordno=? and in_hospital_time=? and status='1'";
            }
        }

        /// <summary>
        /// 查询聚焦ComBox2所对应值
        /// </summary>
        public static string SqlQueryGmCodeByComBox2
        {
            get
            {
                return @"select * from gm_code where code_type=?";
            }
        }
        #endregion

        #region 信息入库
        /// <summary>
        /// 根据病人表id查询此病人入库图片
        /// </summary>
        public static string SqlQueryPictureByID
        {
            get
            {
                return @"select * from st_picture pic where pic.status='1' and pic.health_id=?";
            }
        }
        /// <summary>
        /// 修改图片审核状态   有问题 AND PIC.CHECK_STATUS IN (100,102)
        /// </summary>
        public static string SqlUpdatePictureCheckState
        {
            get
            {
                return @"update st_picture PIC
                   set PIC.update_by = ?,
                       PIC.update_date = sysdate,
                       PIC.check_status = ?
                 where PIC.health_id = ?
                 AND PIC.STATUS='1' ";
            }
        }
        /// <summary>
        /// 删除病案的某一页
        /// </summary>
        public static string SqlUpdatePictureCheckStateByPage
        {
            get
            {
                return @"update st_picture PIC
                   set PIC.status = '0', PIC.update_by = ?, PIC.update_date = SYSDATE
                 where PIC.HEALTH_ID = ?
                   AND PIC.PAGE_NO = ?
                   AND PIC.SUBPAGE = ?";
            }
        }
        /// <summary>
        /// 修改病人审核状态
        /// </summary>
        public static string SqlUpdatePatientCheckState
        {
            get
            {
                return @"update gm_patient p
                   set p.check_status = ?,
                       p.update_by = ?,
                       p.update_date = sysdate,
                       p.PAT_REVIEW_DATE=sysdate
                 where p.id = ?";
            }
        }
        /// <summary>
        /// 删除病人
        /// </summary>
        public static string SqlDeletePatient
        {
            get
            {
                return @"update gm_patient p
                   set p.status = '0',
                       p.update_by = ?,
                       p.update_date = sysdate
                 where p.id = ?";
            }
        }
        /// <summary>
        /// 获得未审核的病案，根据提交人
        /// </summary>
        public static string SqlQueryMyPatientByCheckState
        {
            get
            {
                return @"select *
                              from (select PV.*,
                                           PIC.PIC_COMMIT_NAME,
                                           PIC.PIC_COMMIT_DATE,
                                           row_number() over(partition by pv.id order by pic.pic_commit_date desc) rn
                                      from GM_PATIENT_VIEW PV,
                                           (select * from ST_PICTURE PIC where STATUS = '1') pic
                                     where PV.id = PIC.HEALTH_ID(+)
                                       AND PV.check_status = ?
                                       AND PV.status = '1'
                                       AND (PV.PAT_COMMIT_ID = ? or
                                           pic.pic_commit_id = ?))
                             where rn = 1";
            }
        }
        /// <summary>
        /// 根据图片id，修改图片信息
        /// </summary>
        public static string SqlUpdatePictureByID
        {
            get
            {
                return @"update st_picture
                   set pro_id = ?,
                       page_no = ?,
                       update_by = ?,
                       update_date = sysdate,
                       subpage = ?,
                       pro_name = ?,
                       check_status=100
                 where picture_id =?";
            }
        }
        /// <summary>
        /// 根据图片id，删除图片
        /// </summary>
        public static string SqlDeletePictureByID
        {
            get
            {
                return @"update st_picture
                   set status = '0',
                       update_by = ?,
                       update_date = sysdate
                 where picture_id=?";
            }
        }
        /// <summary>
        /// 查询病案号
        /// </summary>
        public static string SqlQueryRecordNO
        {
            get
            {
                return @"select p.*,c.name gender_name from GM_PATIENT P left join gm_code c on p.gender=c.code
                    where P.STATUS='1' AND P.RECORDNO LIKE ?";
            }
        }
        /// <summary>
        /// 查询项目
        /// </summary>
        public static string SqlSelectProject
        {
            get
            {
                return @"select *
  from gm_project P
 where P.STATUS = '1'
   and p.first_pinyin like ?
    order by P.PRO_NO";
            }
        }
        public static string SqlSelectProjectByShortKey
        {
            get
            {
                return @"select *
  from gm_project P
 where P.STATUS = '1'
   and p.SHORT_KEY = ?";
            }
        }
        /// <summary>
        /// 插入图片
        /// </summary>
        public static string SqlAddPicture
        {
            get
            {
                return @"insert into st_picture
  (picture_id,
   picture_name,
   HEALTH_ID,
   pro_id,
   page_no,
   storage_path,
   logic_path,
   status,
   create_by,
   subpage,
   PRO_NAME,
    PIC_COMMIT_ID,
    PIC_COMMIT_NAME,
    PIC_COMMIT_DATE,
    check_status)
                values
  (ST_PICTURE_SEQ.NEXTVAL, ?, ?, ?, ?, ?, ?, '1', ?, ?, ?,?,?,?,100)";
            }
        }
        #endregion

        #region 用户管理
        /// <summary>
        /// 登陆
        /// </summary>
        public static string SqlQueryUser
        {
            get
            {
                return @"select * from gm_user u where u.status='1' and u.user_no=? and u.user_pwd=?";
            }
        }
        /// <summary>
        /// web端用户登录
        /// </summary>
        public static string SqlWebQueryUser
        {
            get
            {
                return @" select u.*,dt.dept_name
                      from gm_user u, tr_user_role ur,gm_dept dt
                     where u.status = '1'
                       and u.user_id = ur.user_id
                       and ur.status = '1'
                       and u.dept_id=dt.dept_id
                       and ur.role_id in (select distinct rf.role_id
                                            from tr_role_function rf,
                                                 (select * from tm_role ro where ro.status = '1') r
                                           where rf.status = '1'
                                             and rf.role_id = r.role_id
                                             and rf.function_id in
                                                 (select fu.function_id
                                                    from tm_function fu
                                                   where fu.status = '1'
                                                     and fu.user_type = 304))
                       and u.user_no = ?
                       and u.user_pwd = ?";
            }
        }
        #endregion

        #region Web
        /// <summary>
        /// 修改密码
        /// </summary>
        public static string SqlUpdatePassword
        {
            get
            {
                return @"update gm_user set user_pwd = ? where user_id = ?";
            }
        }

        /// <summary>
        /// 修改密码（客户端）
        /// </summary>
        public static string SqlUpdatePwd
        {
            get
            {
                return @"update gm_user
                           set user_pwd = ?, 
                               update_by = ?,
                               update_date = sysdate
                         where user_id = ?";
            }
        }

        /// <summary>
        /// 验证原始密码是否正确
        /// </summary>
        public static string SqlCheckOldPwd
        {
            get
            {
                return @"select count(*)
                          from gm_user
                         where user_id = ?
                           and user_pwd = ?";
            }
        }



        /// <summary>
        /// 根据病人信息查询病案信息
        /// </summary>
        public static string SqlQueryRecordByPatientInfo
        {
            get
            {
                return @"select p.*,c.name gender_name from GM_PATIENT P left join gm_code c on p.gender=c.code
                    where P.STATUS='1' AND P.PATIENT_NAME like ?";
            }
        }
        /// <summary>
        /// 插入病案申请详细表
        /// </summary>
        public static string SqlAddBorrowDetail
        {
            get
            {
                return @" insert into st_borrow_detail
                      (borrow_id, apply_date, health_id, status, creater_by, borrow_list_id)
                    values
                      (st_borrow_detail_seq.nextval, sysdate, ?, '1', ?, ?)";
            }
        }
        /// <summary>
        /// 插入病案申请表
        /// </summary>
        public static string SqlAddBorrow
        {
            get
            {
                return @"insert into st_borrow
                        (borrow_list_id, borrow_list_no, apply_date, applyer_id, applyer_name, apply_reason, create_by, status,borrow_state)
                 values
                        (?,?,sysdate, ?, ?, ?, ?, '1','90')";
            }
        }
        /// <summary>
        /// 根据用户id查询申请信息
        /// </summary>
        public static string SqlQueryApply
        {
            get
            {
                return @"select * from st_borrow_detail bd,st_borrow b
                        where bd.borrow_list_id=b.borrow_list_id
                        and bd.status='1' and b.status='1'
                        and b.borrow_state in (90,91)
                        and b.applyer_id=?";
            }
        }
        /// <summary>
        /// 根据条件查询病案信息
        /// </summary>
        public static string SqlQueryPatient
        {
            get
            {
                return @"select P.*, to_char(p.in_hospital_date,'yyyy/mm/dd') in_hospital_date2,to_char(p.out_hospital_date,'yyyy/mm/dd') out_hospital_date2 from gm_patient_view p where p.status='1' AND P.check_status='101' {0}";
            }
        }
        /// <summary>
        /// 获得ST_BORROW_LIST_NO_SEQ的下一个值
        /// </summary>
        public static string SqlBorrowListNOSeq
        {
            get
            {
                return @"select ST_BORROW_LIST_NO_SEQ.NEXTVAL from DUAL";
            }
        }
        /// <summary>
        /// 获得申请表st_borrow_seq的下一个值
        /// </summary>
        public static string SqlBorrowSeq
        {
            get
            {
                return @"select st_borrow_seq.nextval from DUAL";
            }
        }
        /// <summary>
        /// 获得系统时间
        /// </summary>
        public static string SqlSysdate
        {
            get
            {
                return @"select sysdate from dual";
            }
        }
        /// <summary>
        /// 根据用户id查询申请单
        /// </summary>
        public static string SqlQueryMyApplyListByUserID
        {
            get
            {
                return @"select b.*,c.name borrow_state_name from st_borrow b,gm_code c WHERE b.borrow_state=c.code and b.status='1' and b.borrow_state=?
                        and b.applyer_id=? ";
            }
        }
        /// <summary>
        /// 根据申请单id查询详情
        /// </summary>
        public static string SqlQueryMyApplyDetailByID
        {
            get
            {
                return @"select pv.*,b.*,gc.name borrow_state_name,to_char( pv.in_hospital_date,'yyyy/mm/dd') in_hospital_date2 from st_borrow_detail bd,gm_patient_view pv,st_borrow b,gm_code gc 
                        where bd.health_id=pv.id and bd.borrow_list_id=b.borrow_list_id and gc.code=b.borrow_state
                        and bd.status='1' and pv.status='1' and bd.borrow_list_id=?";
            }
        }
        /// <summary>
        /// 修改申请单状态
        /// </summary>
        public static string SqlUpdateBorrowStatus
        {
            get
            {
                return @"update st_borrow b
                    set b.update_by = ?,
                        b.update_date = sysdate,
                        b.borrow_state = '93',
                        b.cancel_date = sysdate
                    where b.borrow_list_id=?";
            }
        }
        /// <summary>
        /// 根据id查询病案信息及图片信息
        /// </summary>
        public static string SqlQueryMyPictureByID
        {
            get
            {
                return @"select pv.*,to_char(PV.birthday,'yyyy/mm/dd') birthday2,
                       pic.*,
                       pic.storage_path || '/' || pic.picture_name src,
                       GC.NAME PICTURE_CHECK_STATUS,
                       cr.Check_Info
                  from gm_patient_view pv,
                       st_picture pic,
                       GM_CODE GC,
                       (select * from gm_check_record R where R.STATUS = '1') cr,
                        (SELECT * FROM  gm_project gp WHERE gp.status='1' and gp.is_look='1') gp
                 where pv.id = pic.health_id
                   and pic.picture_id = cr.picture_id(+)
                   and pv.status = '1'
                   and pic.status = '1'
                   AND GC.CODE = PIC.CHECK_STATUS
                    and pic.is_look='1'
                    and pic.pro_id=gp.pro_id
                   and pv.id = ? {0}
                 order by PIC.PAGE_NO ASC, PIC.SUBPAGE ASC";
            }
        }
        /// <summary>
        /// 根据id查询所有图片项目
        /// </summary>
        public static string SqlQueryMyPictureProjectByID
        {
            get
            {
                return @"SELECT PRO_ID,PRO_NAME
  FROM GM_PROJECT GP
 WHERE EXISTS (SELECT 1
          FROM ST_PICTURE PIC
         WHERE PIC.STATUS = '1'
           AND PIC.HEALTH_ID = ?
           AND PIC.PRO_ID = GP.PRO_ID)
 ORDER BY GP.PRO_NO";
            }
        }
        /// <summary>
        /// 根据用户id查询其借阅病案
        /// </summary>
        public static string SqlQueryBorrowByUserID
        {
            get
            {
                return @"select pv.*,b.*,gc.name borrow_state_name,to_char( pv.in_hospital_date,'yyyy/mm/dd') in_hospital_date2,to_char( pv.out_hospital_date,'yyyy/mm/dd') out_hospital_date2 from st_borrow_detail bd,gm_patient_view pv,st_borrow b,gm_code gc 
                        where bd.health_id=pv.id and bd.borrow_list_id=b.borrow_list_id and gc.code=b.borrow_state
                        and bd.status='1' and pv.status='1' and b.borrow_state='91' and b.applyer_id=?";
            }
        }
        #endregion

        #region 档案查询

        /// <summary>
        /// 查询GM_PATIENT表基本信息
        /// </summary>
        public static string SqlSearchPatientData
        {
            get
            {
                return @"select *
  from gm_patient_view gpv
 where gpv.status = '1'
   and gpv.IN_HOSPITAL_DATE between ? and ?
   and gpv.check_status = 101
   and gpv.patient_name like ? 
   and gpv.recordno like ?
    order by GPV.recordno";
            }
        }
        public static string SqlSearchPatientDataByInputDate
        {
            get
            {
                return @"select *
  from gm_patient_view gpv
 where gpv.status = '1'
   and gpv.PAT_COMMIT_DATE between ? and ?
   and gpv.check_status = 101
   and gpv.patient_name like ? 
   and gpv.recordno like ?
    order by GPV.recordno";
            }
        }

        #endregion

        #region 档案审核

        /// <summary>
        /// 查询GM_PATIENT表基本信息
        /// </summary>
        public static string SqlSearchData
        {
            get
            {
                return @"select *
  from gm_patient_view gpv
 where gpv.status = '1'
   and gpv.create_date between ? and ?
   and gpv.check_status in (101,102,103)
   and (gpv.patient_name like ? or gpv.patient_id like ? or
       gpv.recordno like ? or gpv.id_card like ?)";
            }
        }

        /// <summary>
        /// 查询图片档案
        /// </summary>
        public static string SqlSelectPic
        {
            get
            {
                return @"select sp.*,gc.name check_status_name
  from st_picture sp,gm_code gc
 where sp.check_status = gc.code
   and sp.status = '1'
   and sp.health_id = ?
 order by sp.PICTURE_NAME ";
            }
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        public static string SqlModifCheckStatis
        {
            get
            {
                return @"UPDATE GM_PATIENT GP
SET GP.CHECK_STATUS = ?
WHERE GP.ID = ?";
            }
        }

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        public static string SqlModifLockStatus
        {
            get
            {
                return @"UPDATE GM_PATIENT GP
SET GP.LOCK_STATUS = ?
WHERE GP.ID = ?";
            }
        }



        /// <summary>
        /// 获取用户是否有锁定权限
        /// </summary>
        public static string SqlQueryLockFunction
        {
            get
            {
                return @"select count(*) from gm_user gu,tr_user_role tur,tm_role tr,tr_role_function trf,tm_function tf
where gu.status = '1'
  and tur.status = '1'
  and tr.status = '1'
  and trf.status = '1'
  and tf.status = '1'
  and gu.user_id = tur.user_id
  and tur.role_id = tr.role_id
  and tr.role_id = trf.role_id
  and trf.function_id = tf.function_id
  and gu.user_id = ?
  and tf.function_id = '1000000142'";
            }
        }

        /// <summary>
        /// 插入审核表
        /// </summary>
        public static string SqlInsertCheckReason
        {
            get
            {
                return @"insert into gm_check_record
  (check_record_id, health_id, check_status, check_date, check_by, check_name, check_info, original_check_static)
values
  (GM_CHECK_RECORD_SEQ.Nextval , ?, ?, sysdate, ?, ?, ?, ?)";
            }
        }
        #endregion

        #region 图片审核

        /// <summary>
        /// 查询GM_PATIENT表基本信息
        /// </summary>
        public static string SqlSearchPatient
        {
            get
            {
                return @"select *
  from gm_patient_view gpv
 where gpv.status = '1'
   and gpv.check_status in (101,102,103)
   and gpv.recordno like ? ";
            }
        }

        /// <summary>
        /// 查询大图
        /// </summary>
        public static string SqlSelectBigPicture
        {
            get
            {
                return @"select distinct t.*, '00' subpage,
       (select gc.name from gm_code gc where gc.code = t.check_status) check_status_name
  from (select sp.health_id,
               sp.page_no,
               sp.pro_name,
               decode(count(1),1,max(sp.check_status),'000') check_status
          from st_picture sp
         where sp.status = '1'
           and sp.health_id = ?
         group by sp.health_id, sp.page_no, sp.pro_name
         order by sp.page_no) t";
            }
        }

        /// <summary>
        /// 查询小图
        /// </summary>
        public static string SqlSelectSmallPicture
        {
            get
            {
                return @"select sp.page_no,sp.pro_name,sp.subpage,sp.check_status,
       (select gc.name from gm_code gc where gc.code = sp.check_status) check_status_name
  from st_picture sp
 where sp.status = '1'
   and sp.health_id = ?
   and sp.subpage != '00'";
            }
        }

        /// <summary>
        /// 查询所有图
        /// </summary>
        public static string SqlSelectAllPicture
        {
            get
            {
                return @"select sp.*,(case
         when sp.is_export = '1' then
          '可以导出'
         when sp.is_print='1' then
          '可以打印'
         when sp.is_look = '1' then
          '可以浏览'
         else
          '不能浏览'
       end) is_look_name,
       (select gc.name from gm_code gc where gc.code = sp.check_status) check_status_name
  from st_picture sp
 where sp.status = '1'
   and sp.health_id = ?
   order by sp.page_no,sp.subpage";
            }
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        public static string SqlModifPictureCheckStatis
        {
            get
            {
                return @"update st_picture sp
set sp.check_status = ?,
    sp.update_by = ?,
    sp.update_date = SYSDATE
where sp.picture_id = ?";
            }
        }

        /// <summary>
        /// 修改病人审核状态
        /// </summary>
        public static string SqlModifPatientCheckStatis
        {
            get
            {
                return @"update gm_patient gp
   set gp.check_status = decode((select count(1)
          from st_picture sp1, st_picture sp2
         where sp1.status = '1'
           and sp2.status = '1'
           and sp1.health_id = sp2.health_id
           and sp1.picture_id = ?
           and sp2.check_status not in (101)),0,'101','102')
 where gp.id in (select sp.health_id
                   from st_picture sp
                  where sp.picture_id = ?)";
            }
        }

        /// <summary>
        /// 插入审核表
        /// </summary>
        public static string SqlInsertPictureCheckReason
        {
            get
            {
                return @"insert into gm_check_record
  (check_record_id, picture_id, check_status, check_date, check_by, check_name, check_info_id, check_info, original_check_static,status)
values
  (GM_CHECK_RECORD_SEQ.Nextval , ?, ?, sysdate, ?, ?, ?, ?, ?,'1')";
            }
        }

        /// <summary>
        /// 删除审核记录
        /// </summary>
        public static string SqlDeletePictureCheckReason
        {
            get
            {
                return @"update gm_check_record gcr set gcr.status = '0' where gcr.picture_id = ?";
            }
        }

        /// <summary>
        /// 获取审核原因
        /// </summary>
        public static string SqlSelectCheckReason
        {
            get
            {
                return @"select * from gm_check_reason gcr where gcr.status = '1'";
            }
        }

        /// <summary>
        /// 插入审核原因
        /// </summary>
        public static string SqlInsertCheckReasonData
        {
            get
            {
                return @"insert into gm_check_reason
  (check_reason_id, check_reason, status)
values
  (gm_check_reason_seq.nextval, ?, '1')";
            }
        }

        /// <summary>
        /// 删除审核原因
        /// </summary>
        public static string SqlDeleteCheckReasonData
        {
            get
            {
                return @"update gm_check_reason gcr set  gcr.status = '0'  where gcr.check_reason_id = ?";
            }
        }

        #endregion

        #region【项目维护】

        /// <summary>
        /// 查询所有项目信息
        /// </summary>
        public static string SqlQueryAllProject
        {
            get
            {
                return @"select * from gm_project where status='1' order by pro_no";
            }
        }

        /// <summary>
        /// 根据关键字查询项目信息
        /// </summary>
        public static string SqlQueryProject
        {
            get
            {
                return @"select * from gm_project where status='1' and (pro_name like ? or pro_no like ? or first_pinyin like ? ) order by pro_no";
            }
        }

        /// <summary>
        /// 插入一条项目信息
        /// </summary>
        public static string SqlInsertProject
        {
            get
            {
                return @"insert into gm_project values(gm_project_seq.nextval,?,?,?,'1',sysdate,'','',?,?,?,?,?)";
            }
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        public static string SqlUpdateProject
        {
            get
            {
                return @"update gm_project set pro_name=?,pro_no=?,first_pinyin=?,update_date=sysdate,update_by=?,is_print=?,SHORT_KEY=?,IS_LOOK=?,IS_EXPORT=? where pro_id=?";
            }
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        public static string SqlDelectProject
        {
            get
            {
                return @"update gm_project set status='0',update_by=?,update_date=sysdate where pro_id=?";
            }
        }
        /// <summary>
        /// 校验快捷键不能重复
        /// </summary>
        public static string SqlIsShortKey
        {
            get
            {
                return @"select * from gm_project p where p.status='1' and p.short_key=?";
            }
        }
        /// <summary>
        /// 查询项目表里有几条与当前编号一样的数据
        /// </summary>
        public static string SqlCheckProIsRepeat
        {
            get
            {
                return "select count(*) from gm_project where pro_no=? and pro_id not in (?) and status='1'";
            }
        }


        #endregion

        #region【科室维护】
        /// <summary>
        /// 查询科室信息
        /// </summary>
        public static string SqlQueryAllDept
        {
            get
            {
                return @"select dept_id,dept_no,dept_name,first_pinyin from gm_dept where status='1' order by dept_no";
            }
        }

        /// <summary>
        /// 根据关键字查询科室信息
        /// </summary>
        public static string SqlQueryDept
        {
            get
            {
                return @"select * from gm_dept where status='1' and (dept_name like ? or dept_no like ? or first_pinyin like ? ) order by dept_no";
            }
        }

        /// <summary>
        /// 插入科室信息
        /// </summary>
        public static string SqlInsertDept
        {
            get
            {
                return @"insert into gm_dept
                        values(gm_dept_seq.nextval,?,'1',sysdate,'','',?,?,?)";
            }
        }

        /// <summary>
        /// 修改科室信息
        /// </summary>
        public static string SqlUpdateDept
        {
            get
            {
                return @"update gm_dept set dept_no=?, dept_name=?,first_pinyin=?,create_by=?,create_date=sysdate where dept_id=?";
            }
        }

        /// <summary>
        /// 删除科室信息
        /// </summary>
        public static string SqlDeleteDept
        {
            get
            {
                return @"update gm_dept set status='0', update_by=?,update_date=sysdate where dept_id=?";
            }
        }

        /// <summary>
        /// 查询项目表里有几条与当前编号一样的数据
        /// </summary>
        public static string SqlCheckDeptIsRepeat
        {
            get
            {
                return "select count(*) from gm_dept where dept_no=? and dept_id not in (?) and status='1'";
            }
        }
        #endregion

        #region【医生信息维护】
        /// <summary>
        /// 根据关键字查询医生信息
        /// </summary>
        public static string SqlQueryDoctor
        {
            get
            {
                return @"select doc.doctor_id,doc.doctor_no,doc.doctor_name,doc.first_pinyin,doc.doctor_descript,cod.name,doc.dept_id ,dept.dept_name
                            from gm_doctor doc,gm_code cod,gm_dept dept 
                            where doc.doctor_descript=cod.code and doc.dept_id=dept.dept_id
                            and cod.code_type='DOCTOR_DESCRIPT'
                            and doc.status='1'
                            and (doc.doctor_no like ? or doc.doctor_name like ? or doc.first_pinyin like ? or dept.dept_no like ? or dept.dept_name like ? or cod.name like ? or cod.pinyin like ?)";
            }
        }

        /// <summary>
        /// 查询所有医生信息
        /// </summary>
        public static string SqlQueryAllDoctor
        {
            get
            {
                return @"select doc.doctor_id,doc.doctor_no,doc.doctor_name,doc.first_pinyin,doc.doctor_descript,cod.name,doc.dept_id ,dept.dept_name
                            from gm_doctor doc,gm_code cod,gm_dept dept 
                            where 
                            doc.doctor_descript=cod.code and doc.dept_id=dept.dept_id
                            and cod.code_type='DOCTOR_DESCRIPT'
                            and doc.status='1' ";
            }
        }

        /// <summary>
        /// 修改医生信息
        /// </summary>
        public static string SqlUpdateDoctor
        {
            get
            {
                return @"update gm_doctor set doctor_name=?,dept_id=?,first_pinyin=?,update_by=?,update_date=sysdate,doctor_descript=? where doctor_no=?";
            }
        }

        /// <summary>
        /// 插入医生信息
        /// </summary>
        public static string SqlInsertDoctor
        {
            get
            {
                return @"insert into gm_doctor
                        (doctor_id, doctor_name, dept_id, first_pinyin, doctor_descript, doctor_no, status, create_date, update_by, update_date, create_by)
                    values
                        (gm_doctor_seq.nextval, ?, ?, ?, ?, ?, '1', sysdate, '', '', ?)";
            }
        }

        /// <summary>
        /// 删除医生信息
        /// </summary>
        public static string SqlDeleteDoctor
        {
            get
            {
                return @"update gm_doctor set status='0',update_by=?,update_date=sysdate where doctor_id=?";
            }
        }

        /// <summary>
        /// 获取医生职称
        /// </summary>
        public static string SqlQueryDocDescript
        {
            get
            {
                return @"select * from gm_code where code_type='DOCTOR_DESCRIPT' and (code like '%%' or pinyin like '%%')  ";
            }
        }

        /// <summary>
        /// 判断此工号在User表中是否存在
        /// </summary>
        public static string SqlCheckUserNo
        {
            get
            {
                return @"select count(*) from gm_user u where u.user_no=?";
            }
        }

        /// <summary>
        /// 获取到用户变当前seq
        /// </summary>
        public static string SqlQueryUserSeq
        {
            get
            {
                return @"select gm_user_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 查询医生表里有几条与当前编号一样的数据
        /// </summary>
        public static string SqlCheckDoctorIsRepeat
        {
            get
            {
                return "select count(*) from gm_doctor where doctor_no =? and doctor_id not in (?) and status='1'";
            }
        }

        /// <summary>
        /// 把医生作为用户
        /// </summary>
        public static string SqlInsertUserDoc
        {
            get
            {
                return @"insert into gm_user
                        (user_id, user_no, user_name, user_pwd, dept_id, status, create_by, create_date,doc_descript)
                        values
                        (?, ?, ?, '8888', ?, '1', ?, sysdate,?)";
            }
        }

        /// <summary>
        /// 把医生默认为用户的角色默认为Web借阅
        /// </summary>
        public static string SqlInsertDoctorRol
        {
            get
            {
                return @"insert into tr_user_role
                          (user_role_id, user_id, user_name, role_id, role_name, status, create_by, create_date)
                        values
                          (tr_user_role_seq.nextval, ?, ?, '1000000181', '档案借阅', '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 删除医生同时把用户表里的数据删除
        /// </summary>
        public static string SqlDeleteUserByNo
        {
            get
            {
                return @"update gm_user set status='0',update_by=?,update_date=sysdate where user_no=?";
            }
        }
        #endregion

        #region 用户权限维护
        /// <summary>
        /// 初始化查询绑定部门
        /// </summary>
        public static string SqlQueryDeptWithUser
        {
            get
            {
                return @"select * from gm_dept where status = '1'";
            }
        }

        /// <summary>
        /// 查询用户表的所有有效数据
        /// </summary>
        public static string SqlQueryUserByAll
        {
            get
            {
                return @"select tu.*, gd.dept_name, gu.*, gc.name doctor_descript_name
                          from gm_user gu,
                               gm_dept gd,
                               gm_code gc,
                               (select tu.user_id tu_user_id, wm_concat(tr.role_name) union_role
                                  from tr_user_role tu, tm_role tr
                                 where tu.role_id = tr.role_id
                                   and tu.status = '1'
                                   and tr.status = '1'
                                 group by tu.user_id) tu
                         where gu.user_id = tu.tu_user_id(+)
                           and gu.dept_id = gd.dept_id
                           and gu.doc_descript = gc.code
                           and gu.status = '1'
                           and gd.status = '1'";
            }
        }

        /// <summary>
        /// 查询下一个gm_user Sequence
        /// </summary>
        public static string SqlQueryNextUserSequence
        {
            get
            {
                return @"select gm_user_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入用户表
        /// </summary>
        public static string SqlInsertUser
        {
            get
            {
                return @"insert into gm_user
                        (user_id, user_no, user_name, user_pwd, dept_id, status, create_by, create_date,doc_descript)
                        values
                        (?, ?, ?, '8888', ?, '1', ?, sysdate,?)";
            }
        }
        public static string SqlInsertFavorites
        {
            get
            {
                return @"insert into gm_favorites
                      (favorites_id, user_id, favorites_name, create_by, create_date, status)
                    values
                      (gm_favorites_seq.nextval, ?, '我的收藏夹', ?, sysdate, '1')";
            }
        }
        /// <summary>
        /// 针对某用户操作时删除用户角色表
        /// </summary>
        public static string SqlDeleteRoleUserByUserId
        {
            get
            {
                return @"update tr_user_role a set a.status = '0' where a.user_id = ?";
            }
        }

        /// <summary>
        /// 插入用户角色表
        /// </summary>
        public static string SqlInsertRoleUser
        {
            get
            {
                return @"insert into tr_user_role
                          (user_role_id,
                           user_id,
                           user_name,
                           role_id,
                           role_name,
                           status,
                           create_by,
                           create_date)
                        values
                          (tr_user_role_seq.nextval,
                           ?,
                           ?,
                           ?,
                           ?,
                           '1',
                           ?,
                           sysdate)";
            }
        }

        /// <summary>
        /// 查询是否有相同用户编号
        /// </summary>
        public static string SqlQueryIsExistSameUserNo
        {
            get
            {
                return @"select user_no from gm_user where status = '1' and user_no = ?";
            }
        }

        /// <summary>
        /// 修改用户表
        /// </summary>
        public static string SqlUpdateUserById
        {
            get
            {
                return @"update gm_user
                           set user_no = ?,
                               user_name = ?,
                               dept_id = ?,
                               update_by = ?,
                               update_date = sysdate,
                               doc_descript = ?
                         where user_id = ?";
            }
        }

        /// <summary>
        /// 删除选中用户
        /// </summary>
        public static string SqlDeleteUserById
        {
            get
            {
                return @"update gm_user set status='0' where user_id=?";
            }
        }

        /// <summary>
        ///查询角色表tm_role
        /// </summary>
        public static string SqlQueryRoleFunction
        {
            get
            {
                return @"select * from tm_role where status='1'";
            }
        }

        /// <summary>
        /// 根据用户绑定所选用户权限
        /// </summary>
        public static string SqlQueryUserRoleFunctionByUserId
        {
            get
            {
                return @"select * from tr_user_role where user_id=? and status='1'";
            }
        }

        /// <summary>
        /// 根据用户输入信息搜索Grid
        /// </summary>
        public static string SqlQueryUserGridBySearch
        {
            get
            {
                return @"select tu.*, gd.dept_name, gu.*, gc.name doctor_descript_name
                          from gm_user gu,
                               gm_dept gd,
                               gm_code gc,
                               (select tu.user_id tu_user_id, wm_concat(tr.role_name) union_role
                                  from tr_user_role tu, tm_role tr
                                 where tu.role_id = tr.role_id
                                   and tu.status = '1'
                                   and tr.status = '1'
                                 group by tu.user_id) tu
                         where gu.user_id = tu.tu_user_id(+)
                           and gu.dept_id = gd.dept_id
                           and gu.doc_descript = gc.code
                           and gu.status = '1'
                           and gd.status = '1'
                           and (tu.union_role like ? or gd.dept_name like ? or gu.user_no like ? or
                               gu.user_name like ? or gc.name like ?)";
            }
        }

        #endregion

        #region 角色维护
        /// <summary>
        /// 查询角色功能
        /// </summary>
        public static string SqlQueryRoleFuncUnionRole
        {
            get
            {
                return @"select a.function_id,
                               a.function_name,
                               a.user_type,
                               b.name,
                               rpad(a.function_name, 16, '　') || lpad(' ', 2, ' ') || b.name role_func
                          from tm_function a, gm_code b
                         where a.user_type = b.code
                           and a.status = '1'";
            }
        }

        /// <summary>
        /// 查询用户类型
        /// </summary>
        public static string SqlQueryUserType
        {
            get
            {
                return @"select * from gm_code where code_type='USER_TYPE'";
            }
        }

        /// <summary>
        /// 查询角色表显示Grid
        /// </summary>
        public static string SqlQueryRoleUnionFunction
        {
            get
            {
                return @"select trf.*, tr.*
                         from tm_role tr,
                              (select trf.role_function_id,
                                      trf.role_id trf_role_id,
                                      tf.function_name,
                                      tf.user_type,
                                      gc.name
                                 from tr_role_function trf, tm_function tf, gm_code gc
                                where trf.function_id = tf.function_id
                                  and trf.status = '1'
                                  and tf.status = '1'
                                  and gc.code = tf.user_type) trf
                        where tr.role_id = trf.trf_role_id(+)
                          and tr.status = '1'
                        order by tr.role_id";
            }
        }


        /// <summary>
        /// 查询此次所保存的角色流水号
        /// </summary>
        public static string SqlQueryNextRoleSeq
        {
            get
            {
                return @"select tm_role_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        public static string SqlInsertRole
        {
            get
            {
                return @"insert into tm_role
                          (role_id,
                           role_name,
                           status,
                           create_by,
                           create_date)
                        values
                          (?,
                           ?,
                           '1',
                           ?,
                           sysdate)";
            }
        }



        /// <summary>
        /// 所要添加的角色名称是否存在相同的功能角色
        /// </summary>
        public static string SqlQueryIsExistSameRole
        {
            get
            {
                //                return @"select *
                //                             from tr_role_function
                //                            where role_name = ?
                //                              and function_id = ?
                //                              and status = '1'";
                return @"select * from tm_role where role_name=? and status='1'";
            }
        }


        /// <summary>
        /// 插入角色功能表
        /// </summary>
        public static string SqlInsertRoleFunction
        {
            get
            {
                return @"insert into tr_role_function
                          (role_function_id,
                           role_id,
                           role_name,
                           function_id,
                           status,
                           create_by,
                           create_date)
                        values
                          (tr_role_function_seq.nextval,
                           ?,
                           ?,
                           ?,
                           '1',
                           ?,
                           sysdate)";
            }
        }

        /// <summary>
        /// 修改角色表时查询所要修改的名字是否存在相同
        /// </summary>
        public static string SqlQueryIsExistSameRoleNameWhenUpdateRole
        {
            get
            {
                return @"select *
                          from tm_role
                         where role_name = ?
                           and role_id != ?
                           and status = '1'";
            }
        }

        /// <summary>
        /// 修改角色表
        /// </summary>
        public static string SqlUpdateRoleByRoleId
        {
            get
            {
                return @"update tm_role
                           set role_name   = ?,
                               update_by   = ?,
                               update_date = sysdate
                         where role_id = ?";
            }
        }

        /// <summary>
        /// 根据要修改的角色该角色所有权限
        /// </summary>
        public static string SqlDeleteRoleFounctionByRoleId
        {
            get
            {
                return @"update tr_role_function set status='0' where role_id = ?";
            }
        }

        /// <summary>
        /// 根据用户ID查询用户功能表（如果该角色只有一条数据则删除tm_role表角色）
        /// </summary>
        public static string SqlQueryRoleFunctionByRoleId
        {
            get
            {
                return @"select * from TR_ROLE_FUNCTION where role_id = ? and status='1'";
            }
        }

        /// <summary>
        /// 根据role_id删除角色
        /// </summary>
        public static string SqlDeleteRoleByRoleId
        {
            get
            {
                return @"update tm_role set status='0' where role_id=?";
            }
        }

        /// <summary>
        /// 根据功能角色ID删除所选中行
        /// </summary>
        public static string SqlDeleteRoleFunctionByRoleFunctionId
        {
            get
            {
                return @"update tr_role_function set status='0' where role_function_id = ?";
            }
        }

        /// <summary>
        /// 查询界面Grid所点击角色所拥有功能角色
        /// </summary>
        public static string SqlQueryRoleFunctionByFunctionId
        {
            get
            {
                return @"select *
                          from tr_role_function
                         where status = '1'
                           and role_name = ?";
            }
        }

        /// <summary>
        /// 模糊查询角色界面绑定Grid
        /// </summary>
        public static string SqlQuerySearchRoleByKeyWord
        {
            get
            {
                return @"select trf.*, tr.*
                          from tm_role tr,
                               (select trf.role_function_id,
                                       trf.role_id trf_role_id,
                                       tf.function_name,
                                       tf.user_type,
                                       gc.name
                                  from tr_role_function trf, tm_function tf, gm_code gc
                                 where trf.function_id = tf.function_id
                                   and trf.status = '1'
                                   and tf.status = '1'
                                   and gc.code = tf.user_type) trf
                         where tr.role_id = trf.trf_role_id(+)
                           and tr.status = '1'
                           and (function_name like ? or name like ? or role_name like ?)
                         order by tr.role_id";
            }
        }

        /// <summary>
        /// 新增时查询是否存在相同功能名称
        /// </summary>
        public static string SqlQueryWhenInsertIsExistSameFunctionName
        {
            get
            {
                return @"select * from tm_function where function_name=? and status='1'";
            }
        }

        /// <summary>
        /// 插入角色模块功能表
        /// </summary>
        public static string SqlInsertFunction
        {
            get
            {
                return @"insert into tm_function
                      (function_id,
                       function_name,
                       user_type,
                       status,
                       create_by,
                       create_date)
                    values
                      (tm_function_seq.nextval,
                       ?,
                       ?,
                       '1',
                       ?,
                       sysdate)";
            }
        }

        //        /// <summary>
        //        /// 修改时查询是否有相同名称
        //        /// </summary>
        //        public static string SqlQueryWhenUpdateIsExistSameFunctionName
        //        {
        //            get
        //            {
        //                return @"select *
        //                        from tm_function
        //                       where function_name = ?
        //                         and status = '1'
        //                         and function_name in
        //                             (select function_name
        //                                from tm_function
        //                               where function_name = ?)";
        //            }
        //        }

        /// <summary>
        /// 修改功能模块表
        /// </summary>
        public static string SqlUpdateFunction
        {
            get
            {
                return @"update tm_function
                           set function_name = ?,
                               user_type = ?,
                               update_by = ?,
                               update_date = sysdate
                         where function_id = ?";
            }
        }

        /// <summary>
        /// 删除功能模块表
        /// </summary>
        public static string SqlDeleteFunction
        {
            get
            {
                return @"update tm_function
                           set status='0' 
                          where function_id = ?";
            }
        }

        /// <summary>
        /// 查询绑定Grid
        /// </summary>
        public static string SqlQueryRoleFounction
        {
            get
            {
                return @"select a.function_id, a.function_name, a.role_id, b.*, c.name
                          from tm_function a, tr_role_function b, gm_code c
                         where a.status = '1'
                           and a.role_id = b.role_id
                           and c.code = b.user_type";
            }
        }

        /// <summary>
        /// 查询角色功能表并和用户类型关联
        /// </summary>
        public static string SqlQueryFunctionUnionUserType
        {
            get
            {
                return @"select a.*, b.name
                          from tm_function a, gm_code b
                         where a.user_type = b.code
                         and a.status = '1'";
            }
        }

        /// <summary>
        /// 关键字查询功能表
        /// </summary>
        public static string SqlSearchFunctionUnionUserType
        {
            get
            {
                return @"select a.*, b.name
                          from tm_function a, gm_code b
                         where a.user_type = b.code
                           and a.status = '1'
                           and (function_name like ? or name like ?)";
            }
        }

        /// <summary>
        /// 修改时是否存在相同名称
        /// </summary>
        public static string SqlQueryExistSameFunctionNameWhenUpdate
        {
            get
            {
                return @"select *
                          from tm_function
                         where function_name = ?
                           and function_id != ?
                           and user_type = ?
                           and status = '1'";
            }
        }
        #endregion

        #region【借阅批准】
        public static string SqlQueryBorrow
        {
            get
            {
                //                return @"select bor.borrow_list_id,bor.borrow_list_no,bor.apply_date,bor.applyer_id,bor.apply_reason,bordetail.borrow_id,bordetail.apply_date,bordetail.borrow_date,bordetail.return_date,bordetail.user_id,bordetail.health_id,people.user_name,dept.dept_name,patient.recordno
                //                          from st_borrow        bor,
                //                               st_borrow_detail bordetail,
                //                               gm_dept          dept,
                //                               gm_user          people,
                //                               gm_patient       patient
                //                         where bor.borrow_list_id = bordetail.borrow_list_id
                //                           and bor.applyer_id = people.user_id
                //                           and people.dept_id = dept.dept_id
                //                           and patient.id=bordetail.health_id
                //                           and bordetail.borrow_state='90'
                //                           and bor.status='1'
                //                           and bordetail.status='1'";

                //                return @"select people.user_no   tree_id,
                //                           people.user_name||'('||dept.dept_name||')' tree_name,
                //                           people.user_no   parent_id,
                //                           '1'                not_type
                //                      from st_borrow bor, gm_user people,gm_dept dept
                //                     where bor.applyer_id = people.user_id
                //                     and people.dept_id=dept.dept_id
                //                    union all
                //                    select bor.borrow_list_no tree_id,
                //                           bor.borrow_list_no tree_name,
                //                           people.user_no     parent_id,
                //                           '2'                not_type
                //                      from st_borrow bor, gm_user people
                //                     where bor.applyer_id = people.user_id
                //                    union all
                //                    select patient.recordno   tree_id,
                //                           patient.recordno||'('||patient.patient_name||')'   tree_name,
                //                           bor.borrow_list_no parent_id,
                //                           '3'                not_type
                //                      from st_borrow_detail bordetail, gm_patient patient, st_borrow bor
                //                     where bordetail.health_id = patient.id
                //                       and bor.borrow_list_id = bordetail.borrow_list_id
                //                       and bordetail.borrow_state='90'";

                //                return @"select decode(cod.code, '90', '1', '91', '2', '92', '3', '0') tree_id,
                //                               decode(cod.code, '90', '申请中', '91', '借阅中', '92', '已归还', 0) tree_name,
                //                               decode(cod.code, '90', '1', '91', '2', '92', '3', '0') parent_id,
                //                               '1' node_type
                //                          from gm_code cod
                //                         where cod.code_type = 'borrow_status'
                //                           and cod.code = '90'
                //                        union all
                //                        select people.user_no tree_id,
                //                               people.user_name || '(' || dept.dept_name || ')' tree_name,
                //                               '1' parent_id,
                //                               '2' not_type
                //                          from st_borrow bor, gm_user people, gm_dept dept
                //                         where bor.applyer_id = people.user_id
                //                           and people.dept_id = dept.dept_id
                //                        union all
                //                        select bor.borrow_list_no tree_id,
                //                               bor.borrow_list_no tree_name,
                //                               people.user_no parent_id,
                //                               '3' not_type
                //                          from st_borrow bor, gm_user people
                //                         where bor.applyer_id = people.user_id
                //                        union all
                //                        select patient.recordno tree_id,
                //                               patient.recordno || '(' || patient.patient_name || ')' tree_name,
                //                               bor.borrow_list_no parent_id,
                //                               '4' not_type
                //                          from st_borrow_detail bordetail, gm_patient patient, st_borrow bor
                //                         where bordetail.health_id = patient.id
                //                           and bor.borrow_list_id = bordetail.borrow_list_id
                //                           and bordetail.borrow_state = '90'";
                return @"select bor.borrow_list_id,
                               bor.borrow_list_no,
                               bordetail.health_id,
                               patient.recordno,
                               bor.apply_date,
                               bor.applyer_id,
                               bor.apply_reason,
                               bordetail.borrow_id,
                               bordetail.apply_date,
                               bordetail.borrow_date,
                               bordetail.return_date,
                               bordetail.user_id,      
                               people.user_name,
                               dept.dept_name       
                          from st_borrow        bor,
                               st_borrow_detail bordetail,
                               gm_dept          dept,
                               gm_patient       patient,
                               gm_user          people
                         where bor.borrow_list_id = bordetail.borrow_list_id
                           and bor.applyer_id = people.user_id
                           and people.dept_id = dept.dept_id
                           and bordetail.health_id=patient.id
                           and bordetail.borrow_state = '90'";
            }
        }

        /// <summary>
        /// 查询申请单
        /// </summary>
        public static string SqlQueryBorrowList
        {
            get
            {
                return @"select 
                         bor.borrow_list_id,
                         bor.borrow_list_no,
                         bor.apply_date,
                         bor.borrow_date,
                         bor.return_date,
                         bor.apply_reason,
                         bor.applyer_id,
                         people.user_name,
                         dept.dept_id,
                         dept.dept_name,
                         cod.name
                    from st_borrow bor, gm_user people, gm_dept dept,gm_code cod
                    where bor.applyer_id = people.user_id
                     and people.dept_id = dept.dept_id
                     and cod.code=people.doc_descript
                     and dept.status='1'
                     and people.status='1'
                     and bor.status = '1'  
                     and dept.dept_id like ?
                     and bor.apply_date between ? and ?
                     and bor.borrow_state=?
                    order by bor.apply_date";
            }
        }

        /// <summary>
        /// 查询病案信息
        /// </summary>
        public static string SqlQueryRecord
        {
            get
            {
                return @"select bordetail.borrow_id,
                               bordetail.borrow_list_id,
                               patient.id,
                               patient.recordno,
                               patient.patient_id,
                               patient.patient_name,
                               decode(patient.is_special,'0','否','1','是') is_special,
                               patient.shelfno,
                               patient.in_hospital_time,
                               cod.name GENDER,
                               patient.in_hospital_date,
                               (select dept_name from gm_dept where dept_id= patient.in_hospital_dept ) in_hospital_dept, 
                               (select doctor_name from gm_doctor where doctor_id = patient.in_hospital_doctor) in_hospital_doctor,
                               patient.out_hospital_date,
                               (select dept_name from gm_dept where dept_id= patient.out_hospital_dept ) out_hospital_dept
                          from st_borrow_detail bordetail, gm_patient patient,gm_code cod
                         where bordetail.status = '1'
                           and patient.status='1'
                           and cod.code=patient.gender
                           and bordetail.health_id = patient.id
                           and bordetail.borrow_list_id in
                               (select bor.borrow_list_id
                                  from st_borrow bor, gm_user people, gm_dept dept
                                 where bor.applyer_id = people.user_id
                                   and people.dept_id = dept.dept_id
                                   and bor.status = '1'
                                   and dept.status='1'
                                   and people.status='1'
                                   and dept.dept_id like ?
                                   and bor.apply_date between ? and ?
                                   and bor.borrow_state = ?)";

                //                return @"select bordetail.borrow_id,
                //                               bordetail.borrow_list_id,
                //                               patient.recordno,
                //                               patient.patient_id,
                //                               patient.patient_name,
                //                               decode(patient.is_special,'0','否','1','是') is_special,
                //                               patient.shelfno                              
                //                          from st_borrow_detail bordetail, gm_patient patient
                //                         where bordetail.status = '1'
                //                           and bordetail.health_id = patient.id
                //                           and bordetail.borrow_list_id in
                //                               (select bor.borrow_list_id
                //                                  from st_borrow bor, gm_user people, gm_dept dept
                //                                 where bor.applyer_id = people.user_id
                //                                   and people.dept_id = dept.dept_id
                //                                   and bor.status = '1'
                //                                   and dept.dept_id like ?
                //                                   and bor.apply_date between ? and ?
                //                                   and bor.borrow_state = ?)";
            }
        }

        /// <summary>
        /// 查询病案借阅状态
        /// </summary>
        public static string SqlQueryBorrowState
        {
            get
            {
                return @"select * from gm_code where code_type='borrow_status'";
            }
        }

        /// <summary>
        /// 批准借阅
        /// </summary>
        public static string SqlPassBorrow
        {
            get
            {
                return @"update st_borrow a
                           set a.borrow_state = '91',
                               a.agree_id     = ?,
                               a.agree_name   = ?,
                               a.update_by    =?,
                               a.update_date=sysdate,
                               a.borrow_date=sysdate,
                               a.return_date  = sysdate +(select lenth.time_lenth
                                                 from gm_borrow_time_lenth lenth,
                                                      gm_user              people,
                                                      st_borrow            bor
                                                where lenth.doc_descript_id = people.doc_descript
                                                  and bor.applyer_id = people.user_id
                                                  and lenth.status='1'
                                                  and people.status='1'
                                                  and bor.status='1'
                                                  and bor.borrow_list_id = ?)                    
                         where a.borrow_list_id =?";
            }
        }

        /// <summary>
        /// 拒绝借阅
        /// </summary>
        public static string SqlRefuseBorrow
        {
            get
            {
                return @"update st_borrow bor
                           set bor.borrow_state = '94',
                               bor.agree_id     = ?,
                               bor.agree_name   = ?,
                               bor.update_by    = ? ,
                               bor.update_date = sysdate
                         where bor.borrow_list_id = ?";
            }
        }
        #endregion

        #region【借阅时间维护】
        /// <summary>
        /// 查询借阅时间
        /// </summary>
        public static string SqlQueryBorrowTime
        {
            get
            {
                return @"select bow.borrow_time_id, DOC_DESCRIPT_ID,cod.name ,TIME_LENTH ||'(天)' TIME_LENTH 
                            from GM_BORROW_TIME_LENTH bow,gm_code cod 
                            where status='1'
                            and cod.code_type='DOCTOR_DESCRIPT'
                            and bow.doc_descript_id=cod.code";
            }
        }

        /// <summary>
        /// 查询医生职称
        /// </summary>
        public static string SqlQueryDocDes
        {
            get
            {
                return @"select *
                          from gm_code cod
                         where code_type = 'DOCTOR_DESCRIPT'";
            }
        }

        /// <summary>
        /// 查询借阅时间表中与当前职称相同的有几条数据
        /// </summary>
        public static string SqlCheckDesRepeat
        {
            get
            {
                return @"select count(*)
                          from GM_BORROW_TIME_LENTH
                         where doc_descript_id = ?
                           and borrow_time_id not in (?)
                           and status = '1'";
            }
        }

        /// <summary>
        /// 添加一条借阅时间数据
        /// </summary>
        public static string SqlInsertBorrowTime
        {
            get
            {
                return @"insert into gm_borrow_time_lenth
                        (borrow_time_id, doc_descript_id, time_lenth, status, create_by, creater_date)
                      values
                        (gm_borrow_time_lenth_seq.nextval, ?, ?, '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 修改借阅时间
        /// </summary>
        public static string SqlUpdateBorrowTime
        {
            get
            {
                return @"update gm_borrow_time_lenth
                          set          
                              time_lenth = ?,     
                              update_by = ?,
                              update_date = sysdate
                        where borrow_time_id=?";
            }
        }

        /// <summary>
        /// 删除借阅时间
        /// </summary>
        public static string SqlDeleteBorrowTime
        {
            get
            {
                return @"update gm_borrow_time_lenth
                          set          
                              status='0',    
                              update_by = ?,
                              update_date = sysdate
                        where borrow_time_id=?";
            }
        }
        #endregion

        #region【界面功能权限显示】
        /// <summary>
        /// 根据用户ID查询用户有哪些权限
        /// </summary>
        public static string SqlQueryNoFunction
        {
            get
            {
                return @" select function_id
                          from tm_function
                         where function_id not in (select distinct fun.function_id
                                                     from tm_function      fun,
                                                          tm_role          rol,
                                                          tr_role_function rolfun,
                                                          tr_user_role     userol
                                                    where rolfun.role_id = userol.role_id
                                                      and userol.role_id = rol.role_id
                                                      and rolfun.function_id = fun.function_id
                                                      and fun.status='1'
                                                      and rol.status='1'
                                                      and rolfun.status='1'
                                                      and userol.status='1'
                                                      and userol.user_id = ?)";
            }
        }
        #endregion

        #region 【档案打印】

        /// <summary>
        /// 根据病案号查询图片信息
        /// </summary>
        public static string SqlQueryPictureByHealthId
        {
            get
            {
                return @"select (sp.page_no || '/' || sp.subpage || ' ' ||
                       sp.pro_name) pic_info,
                       sp.*,
                       gc.name check_status_name,sp.storage_path || '\' || sp.picture_name src,GP.IS_PRINT pro_print,gp.is_look pro_look,gp.is_export pro_export
                  from st_picture sp, gm_code gc,GM_PROJECT GP
                 where sp.check_status = gc.code
                 AND SP.PRO_ID=GP.PRO_ID
                   and sp.health_id = ?
                   and sp.status = '1'
                 order by sp.page_no,sp.subpage";
            }
        }

        public static string SqlQueryPictureByProjectAndPage
        {
            get
            {
                return @"select sp.*, gc.name check_status_name
                  from st_picture sp, gm_code gc
                 where sp.check_status = gc.code
                   and sp.status = '1'
                   and sp.health_id = ?
                   and pro_id = ?
                   and sp.page_no between ? and ?
                   and (sp.subpage = '00' or sp.subpage between ? and ?)
                 order by sp.picture_name";
            }
        }
        #endregion

        #region 完成情况统计
        /// <summary>
        /// 登陆
        /// </summary>
        public static string SqlQueryCompleteDate
        {
            get
            {
                return @"select * from vw_mhis_complete mc
                                   where TO_CHAR(MC.IN_HOSPITAL_DATE, 'YYYY') = ?
                                    and (mc.RECORDNO between ? and ? or ? is null or ? is null)";
            }
        }
        #endregion

        public static string SqlModifyLogoContent
        {
            get
            {
                return @"update gm_parameter t set t.value=? WHERE t.value_type='LogoContent'";
            }
        }
        public static string SqlModifyLogoInclination
        {
            get
            {
                return @"update gm_parameter t set t.value=? WHERE t.value_type='LogoInclination'";
            }
        }
        public static string SqlQueryPatientByID
        {
            get
            {
                return @"select P.*, to_char(p.in_hospital_date,'yyyy/mm/dd') in_hospital_date2,to_char(p.out_hospital_date,'yyyy/mm/dd') out_hospital_date2,to_char(P.birthday,'yyyy/mm/dd') birthday2 from gm_patient_view p where P.id=?";
            }
        }
        public static string SqlQueryMyFovourite
        {
            get
            {
                return @"SELECT * FROM gm_FAVORITES t WHERE t.user_id=? and t.status='1'";
            }
        }
        public static string SqlAddFovouriteDetail
        {
            get
            {
                return @"insert into gm_favorites_detail
                        (id, favorites_id, health_id, favorites_date, create_by, create_date, status)
                      values
                        (gm_favorites_detail_seq.nextval, ?, ?, sysdate, ?, sysdate, '1')";
            }
        }
        public static string SqlQueryMyFovouriteByID
        {
            get
            {
                return @"SELECT pv.*,
                       ft.favorites_date,
                       ft.id ft_id,
                       to_char(pv.in_hospital_date, 'yyyy/mm/dd') in_hospital_date2,
                       to_char(pv.out_hospital_date, 'yyyy/mm/dd') out_hospital_date2
                  FROM gm_patient_view pv, gm_favorites_detail ft
                 WHERE ft.status = '1'
                   and ft.health_id = pv.id
                   and ft.favorites_id = ? ORDER BY ft.favorites_date desc";
            }
        }
        public static string SqlRemoveFovouriteDetail
        {
            get
            {
                return @"update gm_favorites_detail ft set ft.status='0' WHERE ft.id=?";
            }
        }

        /// <summary>
        /// 插入操作日志
        /// </summary>
        public static string SqlInsertTraceContext
        {
            get
            {
                return @"insert into gm_trace
                              (trace_code, trace_type, trace_context, trace_date,trace_user_id, trace_user_name)
                            values
                              (?, ?, ?, sysdate,?,?)";
            }
        }
    }
}
