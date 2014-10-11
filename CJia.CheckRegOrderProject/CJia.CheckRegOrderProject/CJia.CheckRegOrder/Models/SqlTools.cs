using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.CheckRegOrder.Models
{
    public class SqlTools
    {
        #region 对叫号系统操作SQL语句
        /// <summary>
        /// sql语句 获得系统时间
        /// </summary>
        public static string sqlSelectSystemDateTime=@"select getdate()";
        /// <summary>
        /// sql语句 根据工号和密码查询 
        /// </summary>
        public static string sqlSelectByUserNOAndPassword = "Select * From gm_user t Where  t.user_no = @1 and t.password=@2 and t.user_state='1'";
        /// <summary>
        /// sql语句 门诊登记插入病人
        /// </summary>
        public static string sqlAddClinicPatient = @"insert into gt_patient([patient_no] ,[patient_name] ,[gender] ,[birthday]
                                                ,[blood_type] ,[telephone],[address],[patient_type],[admissions_type],[invoice_no]
                                                ,[invoice_date],[cost_total],[cost_details],[register_by],[patient_state]
                                                ,[create_by],[state]) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,'1',@15,'1')";
        /// <summary>
        /// sql语句 检查登记插入病人
        /// </summary>
        public static string sqlAddCheckPatient = @"insert into gt_patient([patient_no] ,[patient_name] ,[gender] ,[birthday]
                                                ,[blood_type] ,[telephone],[address],[patient_type],[admissions_type],[invoice_no]
                                                ,[invoice_date],[cost_total],[cost_details],[register_by],[patient_state]
                                                ,[create_by],[state],[menses_first_age],[menses_cycle],[menses_last],[menses_last_age]
                                                ,[first_sex_age] ,[primiparity_age],[pregnancy_num],[birth_num] ,[suckle_state]
                                                ,[contraception_method],[cervicitis_severity],[cervicitis_cin] ,[cervical_cancer_stage]
                                                ,[cervical_treat_way] ,[cervical_treat_date] ,[is_tumour_history] ,[tumour_part] ,[leucorrhea_number]
                                                ,[is_hemolysis] ,[is_waist_ache]) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,'1',@15,'1'
                                                ,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35)";
        /// <summary>
        /// sql语句 根据数据类型字典中查询
        /// </summary>
        public static string sqlSelectCodeValueByType = @"select * from gm_code where code_type_name=@1 and code_state='1'";
        /// <summary>
        /// sql语句 登记排队视图中人病人卡号查询
        /// </summary>
        public static string sqlLineViewSelectByPatientNO = @"select * from RegisteLineView where patient_no=@1";
        /// <summary>
        /// sql语句 登记排队视图中人发票编号查询
        /// </summary>
        public static string sqlLineViewSelectByInvoiceNO = @"select * from RegisteLineView where invoice_no=@1";
        /// <summary>
        /// sql语句 登记未排队视图中病人卡号查询
        /// </summary>
        public static string sqlNotLineSelectByPatientNO = @"select * from RegisteNotLineView where patient_no=@1";
        /// <summary>
        /// sql语句 登记未排队视图中发票编号查询
        /// </summary>
        public static string sqlNotLineSelectByInvoiceNO = @"select * from RegisteNotLineView where invoice_no=@1";
        /// <summary>
        /// sql语句 根据病人卡号修改病人状态
        /// </summary>
        public static string sqlUpdatePatientStateByNO = @"update gt_patient set patient_state='1', queue_no=null where patient_no=@1";
        /// <summary>
        /// sql语句 修改病史
        /// </summary>
        public static string sqlUpdatePatientHistory = @"update gt_patient set [menses_first_age]=@1,[menses_cycle]=@2,[menses_last]=@3,[menses_last_age]=@4
                                                    ,[first_sex_age]=@5 ,[primiparity_age]=@6,[pregnancy_num]=@7,[birth_num]=@8,[suckle_state]=@9
                                                    ,[contraception_method]=@10,[cervicitis_severity]=@11,[cervicitis_cin]=@12 ,[cervical_cancer_stage]=@13
                                                    ,[cervical_treat_way]=@14 ,[cervical_treat_date]=@15 ,[is_tumour_history]=@16 ,[tumour_part]=@17 ,[leucorrhea_number]=@18
                                                    ,[is_hemolysis]=@19 ,[is_waist_ache]=@20,[update_by]=@21,[update_date]=GETDATE() where patient_id=@22";
        /// <summary>
        /// sql语句 查询出3天内登记排队检查完的病人病史
        /// </summary>
        public static string sqlSelectHistory = @"select a.*,b.code_value severity,c.code_value cin,d.code_value treatWay,e.code_value stage,f.code_value leucorrhea 
                                                    from gt_patient a left join gm_code b on a.cervicitis_severity=b.code_no
                                                    left join gm_code c on a.cervicitis_cin=c.code_no
                                                    left join gm_code d on a.cervical_treat_way=d.code_no
                                                    left join gm_code e on a.cervical_cancer_stage=e.code_no
                                                    left join gm_code f on a.leucorrhea_number=f.code_no
                                                    where a.state = '1' and a.patient_state in('1','2','3') and a.admissions_type='检查病人'
                                                    and a.register_date between GETDATE() - 30 and GETDATE()";
        /// <summary>
        /// sql语句 根据病人卡号查询病史
        /// </summary>
        public static string sqlSelectHistoryByNO = @"select a.*,b.code_value severity,c.code_value cin,d.code_value treatWay,e.code_value stage,f.code_value leucorrhea 
                                                    from gt_patient a left join gm_code b on a.cervicitis_severity=b.code_no
                                                    left join gm_code c on a.cervicitis_cin=c.code_no
                                                    left join gm_code d on a.cervical_treat_way=d.code_no
                                                    left join gm_code e on a.cervical_cancer_stage=e.code_no
                                                    left join gm_code f on a.leucorrhea_number=f.code_no
                                                    where  a.patient_no=@1 and a.state = '1' and a.patient_state in('1','2','3') and a.admissions_type='检查病人'";
        /// <summary>
        /// sql语句 根据病人姓名查询病史
        /// </summary>
        public static string sqlSelectHistoryByName = @"select a.*,b.code_value severity,c.code_value cin,d.code_value treatWay,e.code_value stage,f.code_value leucorrhea 
                                                    from gt_patient a left join gm_code b on a.cervicitis_severity=b.code_no
                                                    left join gm_code c on a.cervicitis_cin=c.code_no
                                                    left join gm_code d on a.cervical_treat_way=d.code_no
                                                    left join gm_code e on a.cervical_cancer_stage=e.code_no
                                                    left join gm_code f on a.leucorrhea_number=f.code_no
                                                    where  a.patient_name=@1 and a.state = '1' and a.patient_state in('1','2','3') and a.admissions_type='检查病人'";
        /// <summary>
        /// sql语句 查询出3天内就诊完的病人
        /// </summary>
        public static string sqlSelectPatient = @"select a.*,b.user_name,c.clinic_name
                                                from gt_patient a left join gm_user b on a.register_by=b.user_id
                                                left join gm_clinic c on a.clinic_id=c.clinic_id
                                                where a.state = '1' and a.patient_state='3' 
                                                and a.register_date between GETDATE() - 30 and GETDATE()
	                                            order by a.admissions_type";
        /// <summary>
        /// sql语句 根据病人卡号查询就诊完的病人
        /// </summary>
        public static string sqlSelectPatientByNO = @"select a.*,b.user_name,c.clinic_name
                                                from gt_patient a left join gm_user b on a.register_by=b.user_id
                                                left join gm_clinic c on a.clinic_id=c.clinic_id
                                                where a.state = '1' and a.patient_state='3' 
                                                and a.patient_no=@1
	                                            order by a.admissions_type";
        /// <summary>
        /// sql语句 根据病人姓名查询出就诊完的病人
        /// </summary>
        public static string sqlSelectPatientByName = @"select a.*,b.user_name,c.clinic_name
                                                from gt_patient a left join gm_user b on a.register_by=b.user_id
                                                left join gm_clinic c on a.clinic_id=c.clinic_id
                                                where a.state = '1' and a.patient_state='3' 
                                                and a.patient_name=@1
	                                            order by a.admissions_type";
        /// <summary>
        /// sql语句 登记未排队就诊的病人
        /// </summary>
        public static string sqlSelectRegNoCheck = @"select a.*,b.user_name
                                                from gt_patient a,gm_user b
                                                where a.register_by=b.user_id
                                                and a.state = '1' and a.patient_state='0'
	                                            order by a.admissions_type";
        /// <summary>
        /// sql语句 删除登记未检查病人
        /// </summary>
        public static string sqlDeleteRegNoCheck = @"update gt_patient set state='0' where patient_id=@1";
        /// <summary>
        /// sql语句 查询所有当天检查的病人报告
        /// </summary>
        public static string sqlSelectReport = @"SELECT *
                                                FROM ct_report
                                                WHERE (check_date BETWEEN CONVERT(date, GETDATE(), 23)
                                                AND dateadd(day,+1,CONVERT(date, GETDATE(), 23)))
                                                and state='1'";
        /// <summary>
        /// sql语句 根据病人姓名查询报告
        /// </summary>
        public static string sqlSelectReportByName = @"SELECT *
                                                FROM ct_report
                                                WHERE patient_name=@1
                                                and state='1'";
        /// <summary>
        /// sql语句 根据报告id修改病人报告信息
        /// </summary>
        public static string sqlUpdateReportByID = @"update ct_report
                                                    set print_state='1',print_date=getdate()
                                                    where report_id=@1";
        /// <summary>
        /// sql语句 查询出所有用户
        /// </summary>
        public static string sqlSelectAllUser = @"select a.*,b.user_name create_name from gm_user a  left join gm_user b
                                                on a.create_by=b.user_id
                                                where a.user_state='1'";
        /// <summary>
        /// sql语句  根据用户id查询用户
        /// </summary>
        public static string sqlSelectUserByID = @"select a.*,b.user_name create_name from gm_user a  left join gm_user b
                                                on a.create_by=b.user_id
                                                where a.user_state='1' and a.user_id=@1";
        public static string sqlInsertUser = @"insert into gm_user(user_no,user_name,user_type,create_by) values(@1,@2,@3,@4)";
        /// <summary>
        /// sql语句 根据病人编号查询用户
        /// </summary> 
        public static string sqlSelectUserByNO = @"select a.*,b.user_name create_name from gm_user a  left join gm_user b
                                                on a.create_by=b.user_id
                                                where a.user_state='1' and a.user_no=@1";
        /// <summary>
        /// sql语句 根据病人姓名查询用户
        /// </summary>
        public static string sqlSelectUserByName = @"select a.*,b.user_name create_name from gm_user a  left join gm_user b
                                                on a.create_by=b.user_id
                                                where a.user_state='1' and a.user_name=@1";
        /// <summary>
        /// sql语句 重置密码
        /// </summary>
        public static string sqlUpdateUserPswdByID = @"update gm_user
                                                set password='888888',update_date=getdate(),update_by=@1
                                                where user_id=@2";
        /// <summary>
        /// sql语句 修改用户
        /// </summary>
        public static string sqlUpdateUserByID = @"update gm_user
                                                set user_no=@1,user_name=@2,update_date=getdate(),update_by=@3,user_type=@4
                                                where user_id=@5";
        /// <summary>
        /// sql语句 删除用户
        /// </summary>
        public static string sqlDeleteUserByID = @"update gm_user
                                                set user_state='0',update_date=getdate(),update_by=@1
                                                where user_id=@2";
        #endregion

        #region 对HIS操作SQL语句
        /// <summary>
        /// sql语句 HIS中根据病人卡号或者发票编号查询
        /// </summary>
        public static string sqlHISSelect = "select * from patient_view where patient_no=:1 or invoice_no=:2";
        #endregion

        #region 排队
        /// <summary>
        /// sql语句查询登记未排队状态病人列表
        /// </summary>
        //        public static string sqlSelectByPatientNotExistQueue = @"select a.patient_id,a.queue_no,a.patient_name,a.clinic_id,b.code_value,a.register_date  
        //                                                              from gt_patient a,gm_code b 
        //                                    where patient_state=1 and state=1 and a.patient_state=b.code_no order by a.register_date";   ,decode(a.clinic_id,'','待定',''),nvl(a.clinic_id,'待定')
        public static string sqlSelectByPatientNotExistQueue = @"select a.*,b.code_value,
                                         (case when(a.clinic_id is null)then '待定' else '' end) as clinic_name
                                                              from gt_patient a,gm_code b 
                                    where patient_state='1' and state='1' and a.patient_state=b.code_no order by a.register_date";


        /// <summary>
        /// sql语句查询正在排队病人列表
        /// </summary>
        public static string sqlSelectByPatientExistQueue = @"select a.patient_id,b.clinic_name, a.queue_no,a.patient_name,a.clinic_id,c.code_value,a.register_date from gt_patient a,gm_clinic b,gm_code c 
                                  where a.clinic_id=b.clinic_id and a.patient_state=c.code_no
                                 and a.patient_state='2' and a.state='1' order by queue_no";

        /// <summary>
        /// 根据病人ID查找病人表
        /// </summary>
        public static string sqlSelectPatientById = @"select a.*,b.code_value severity,c.code_value cin,d.code_value treatWay,e.code_value stage,f.code_value leucorrhea 
                                                    from gt_patient a left join gm_code b on a.cervicitis_severity=b.code_no
                                                    left join gm_code c on a.cervicitis_cin=c.code_no
                                                    left join gm_code d on a.cervical_treat_way=d.code_no
                                                    left join gm_code e on a.cervical_cancer_stage=e.code_no
                                                    left join gm_code f on a.leucorrhea_number=f.code_no
                                                    where  a.patient_id=@1 and a.state = '1'";
        /// <summary>
        /// 查找所有诊室
        /// </summary>
        public static string sqlSelectClinicName = "select * from gm_clinic where clinic_state=1";

        /// <summary>
        /// 为病人分配诊室，修改病人状态、队列编号、诊室流水号
        /// </summary>
        public static string sqlUpdatePatientQueueById = @"update gt_patient 
                                                      set patient_state='2',queue_no=@1,clinic_id=@2
                                                      where patient_id=@3 and state='1'";

        /// <summary>
        /// 分配队列号
        /// </summary>
//        public static string sqlSelectPatientMaxQueueNo = @"select max(queue_no) from gt_patient 
//                                                            where register_date=getdate() and patient_state='2'";
        public static string sqlSelectPatientMaxQueueNo = @"select
         (case when max(queue_no) is null then '1' else max(queue_no)+1 end) as next_queue 
          from gt_patient 
          where DateDiff(dd,register_date,getdate())=0 and patient_state='2'";
        

        /// <summary>
        /// 修改诊室
        /// </summary>
        public static string sqlUpdatePatientByClinic = @"update gt_patient
                                                          set clinic_id=@1
                                                          where patient_id=@2";
        /// <summary>
        /// 取消排队
        /// </summary>
        public static string sqlUpdateByCancleQueue = @"update gt_patient 
                                                        set clinic_id=null,queue_no=null,patient_state=1 
                                                        where patient_id=@1";

        /// <summary>
        /// 登记未排队病人取消等待
        /// </summary>
        public static string sqlUpdateByCancleWait = @"update gt_patient set patient_state=0 
                                                       where patient_id=@1";

        /// <summary>
        /// 登记页面排队列表
        /// </summary>
        public static string sqlSelectByPatientRegisterQueue = @"select b.clinic_name,a.patient_id, a.queue_no,a.patient_name,a.clinic_id,c.code_value,a.register_date from gt_patient a 
                       left join gm_clinic b on a.clinic_id=b.clinic_id 
                      left join gm_code c on a.patient_state=c.code_no
               where a.patient_state in(1,2) and a.state='1' order by code_value desc,queue_no";

        /// <summary>
        /// radioGroup 筛选诊室选择病人排队数据
        /// </summary>
        public static string sqlSelectPatientByFilterClinicId = @"select a.patient_id,b.clinic_name, a.queue_no,a.patient_name,a.clinic_id,c.code_value,a.register_date 
                                 from gt_patient a,gm_clinic b,gm_code c 
                                  where a.clinic_id=b.clinic_id and a.patient_state=c.code_no
                                 and a.patient_state='2' and a.state='1' and b.clinic_id=@1 order by queue_no";

        /// <summary>
        /// 排队时插入阴道镜系统病人信息
        /// </summary>
        public static string sqlInsertColposcopyToSickData = @"INSERT INTO SickData 
             ( SickNum,SickName ,Sex ,Birthday ,BloodType,Telephone  ,Createtime ,
               Address ,IDType ,IDCode )
               VALUES 
             ( @1 ,@2 ,@3 ,@4 ,@5 ,@6 ,@7 ,@8 ,@9 ,@10 )";

        /// <summary>
        /// 插入阴道镜系统病人病史表
        /// </summary>
        public static string sqlInsertColposcopyToSickHistoryData = @"INSERT INTO SickHistoryData
           ( CheckNum ,SickNum ,Age ,pregnantedTime ,procreatedTime ,AbortedTime ,SexFriendNum,
             Married ,HCG,Lastedcatamenia ,contraceptMode ,SmokedHistory ,Occupation,SickSource,
            CheckDrName ,CheckTime ,SickHistoryNote ,Evaluatescore ,EvaluatesResult,
            PlanexamineRecord ,ImageFlag,checkNO ,CheckOwnNum )
           VALUES
           (@1 ,@2 ,@3 ,@4 ,@5 ,@6 ,@7 ,@8 ,@9 ,@10 ,@11 ,@12 ,@13 ,@14 ,@15 ,@16 ,@17,
             @18 , @19 ,@20 ,@21 ,@22 ,@23)";

        /// <summary>
        /// 从阴道镜系统病人表查询病人卡号
        /// </summary>
        public static string sqlSelectSickNumFromSickData = @"select SickNum from SickData 
                                      where SickNum=@1";
        #endregion
    }

}
