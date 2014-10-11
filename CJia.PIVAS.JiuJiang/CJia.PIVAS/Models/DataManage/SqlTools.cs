using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 静态数据维护SQL
    /// </summary>
    public class SqlTools
    {

        #region【静态数据维护】

        #region【SM_TIME_SET】
        ///<summary>
        ///SM_TIME_SET 查询
        ///</summary> 
        public static string SqlQueryTimeSet 
        {
            get
            {
                return @"select * from sm_time_set t where t.type=? and t.status='1' order by start_time";
            }
        }

        /// <summary>
        /// 修改时间时 判断要修改的时间段与其他的时间段是否重叠
        /// </summary>
        public static string SqlIsUpdateRepeat
        {
            get
            {
                return @"select 1
                          from 
                          (select rownum num, b.* from (select a.* from sm_time_set a where status='1' and type=? ORDER BY start_time )b)c1,
                          (select rownum num, b.* from (select a.* from sm_time_set a where status='1' and type=? ORDER BY start_time )b)c2,
                          (select rownum num, b.* from (select a.* from sm_time_set a where status='1' and type=? ORDER BY start_time )b)c3
                          where c2.num-1=c1.num(+)
                          and c2.num+1=c3.num(+)
                          and c2.time_id=?
                          and ?>=decode(c1.num,null,'00:00',c1.over_time)
                          and ?<=decode(c3.num,null,'23:59',c3.start_time)";
            }
        }

        /// <summary>
        /// 添加时间时 判断要修改的时间段与其他的时间段是否重叠
        /// </summary>
        public static string SqlIsInsertRepeat
        {
            get
            {
                return @"select 1
                        from sm_time_set sts
                        where sts.type = ?
                          and sts.status='1'
                          and (? > nvl(sts.start_time,'00:00') and ? < nvl(sts.over_time,'23:59')  
                          or ? > nvl(sts.start_time,'00:00') and ? < nvl(sts.over_time,'23:59')
                          or ? < nvl(sts.start_time,'00:00') and  ? > nvl(sts.over_time,'23:59'))";
            }
        }

        /// <summary>
        /// SM_TIme_SET添加数据
        /// </summary>
        public static string SqlInsertTimeSet 
        {
            get
            {
                return @"insert into sm_time_set
                            (time_id, time_name, start_time, over_time, type, status, create_by, create_date)
                        values
                            (sm_time_set_seq.nextval, ?, ?, ?, ?, '1', ?, sysdate)";
            }
        }
                                            
        /// <summary>
        /// SM_TIme_SET修改数据
        /// </summary>
        public static string SqlUpdateTimeSet
        {
            get
            {
                return @"update sm_time_set
                        set time_name = ?,
                            start_time = ?,
                            over_time = ?, 
                            update_by = ?,
                            update_date = sysdate
                        where time_id = ?";
            }
        }

        /// <summary>
        /// 删除时间数据
        /// </summary>
        public static string SqlDeleteTimeSet
        {
            get
            {
                return @" update sm_time_set
                           set                  
                               status = '0',             
                               update_by = ?,
                               update_date = sysdate
                         where time_id = ?";
            }
        }

        #endregion

        #region【用户表】

//        /// <summary>
//        /// 查询当前登录用户的信息(登录) 关联到His
//        /// </summary>
//        public static string SqlQueryUser
//        {
//            get
//            {
//                return @"select  b.user_id,b.user_no,b.user_name,b.user_password,a.dept_id,a.dept_name,sysdate
//                         from sm_user_view a,sm_user b 
//                         where a.user_code=b.user_no and b.user_no=? and b.user_password=? and b.status='1'";
//            }
//        }

//        /// <summary>
//        /// 查询配置中心的所有用户信息   关联到His的
//        /// </summary>
//        public static string SqlQueryAllUser
//        {
//            get
//            {
//                return @"select a.USER_CODE,a.DEPT_NAME,a.JOB_TITLE_NAME,a.HEAD_SHIP_NAME,a.EXPERT_TYPE_NAME,b.user_id,b.user_no,b.user_name,b.user_password
//                        from sm_user_view a,sm_user b 
//                        where a.user_code=b.user_no  and b.status='1'";
//            }
//        }

        /// <summary>
        /// 查询当前登录用户的信息(登录)
        /// </summary>
        public static string SqlQueryUser
        {
            get
            {
                return @"select us.user_id,us.user_no,us.user_name,us.user_password,us.dept_id,us.dept_name,sysdate as loginTime,us.is_admin,us.his_user_id,us.role from  sm_user us where  status='1' and user_no=? and user_password=?";
            }
        }

        /// <summary>
        /// 查询配置中心的所有用户信息 
        /// </summary>
        public static string SqlQueryAllUser
        {
            get
            {
                return @"select US.*,DECODE(US.IS_ADMIN,'1','管理员','') is_admin_name,decode(us.role,'1','药师','2','简单药师','护士') role_name from  sm_user us where  status='1'";
            }
        }

        ///// <summary>
        ///// 查询His中是否有当前工号
        ///// </summary>
        //public static string SqlIsUserExit
        //{
        //    get
        //    {
        //        return @"select * from sm_user_view where user_code=? ";
        //    }
        //}

        /// <summary>
        /// 查询当前用户表中是否有此工号
        /// </summary>
        public static string SqlIsUserRepeat
        {
            get
            {
                return @"select count(*) from sm_user where user_no=? and status='1'";
            }
        }

        public static string SqlQueryHisUser
        {
            get
            {
                return @"select count(1) from (select * from sm_user tsu where tsu.status = '1') su, gm_his_user_view ghuv
where su.his_user_id(+) = ghuv.user_id 
  and su.user_id is null
  and ghuv.user_account = ?";
            }
        }

        /// <summary>
        /// 插入新用户
        /// </summary>
        public static string SqlInsertUser
        {
            get
            {
                return @"insert into sm_user
                          (user_id, user_no, user_name, user_password,dept_id,dept_name, status, create_by, create_date,IS_ADMIN)
                        values
                          (sm_user_seq.nextval, ?, ?, ?, ?, ?, '1', ?, sysdate,?)";
            }
        }


        /// <summary>
        /// 插入新用户
        /// </summary>
        public static string SqlNewInsertUser
        {
            get
            {
                return @"insert into sm_user
  (user_id,
   user_no,
   user_name,
   user_password,
   dept_id,
   dept_name,
   status,
   create_by,
   create_date,
   IS_ADMIN,
   HIS_USER_ID,
   role)
  select sm_user_seq.nextval,
         ghuv.user_account,
         ghuv.user_name,
         ?,
         ghuv.user_dept_id,
         ghuv.user_dept_name,
         '1',
         ?,
         sysdate,
         ?,
         ghuv.user_id,
         ?
    from gm_his_user_view ghuv
    where ghuv.user_account = ?";
            }
        }

        /// <summary>
        /// 用户修改自己密码
        /// </summary>
        public static string SqlChangePwd
        {
            get
            {
                return @"update sm_user
                           set        
                               user_password =? ,         
                               update_by = ?,
                               update_date = sysdate
                         where user_id = ?";
            }
        }

        /// <summary>
        /// 删除用户  把状态改为0
        /// </summary>
        public static string SqlDeleteUser
        {
            get
            {
                return @"update sm_user
                           set                  
                               status = '0',             
                               update_by = ?,
                               update_date = sysdate     
                         where user_id = ?";
            }
        }

        /// <summary>
        /// 修改密码时 确认输入的旧密码是否正确
        /// </summary>
        public static string SqlCheckOldPwd
        {
            get
            {
                return @"select 1 
                        from sm_user us
                        where us.user_password=? and us.user_id=? and status='1'";
            }
        }

        #endregion

        #region【SM_BATCH_SET】

        /// <summary>
        /// 查询批次表对应冲药
        /// </summary>
        public static string SqlQueryBatchSet
        {
            get
            {
                return @"select * from sm_batch_set a ,sm_time_set b where a.status='1' and a.time_id=b.time_id order by batch_time";
            }
        }

        /// <summary>
        /// 查询批次
        /// </summary>
        public static string SqlQueryBatch
        {
            get
            {
                return @"select * from SM_BATCH_SET SBS WHERE SBS.STATUS = '1' ORDER BY SBS.batch_time";
            }
        }

        /// <summary>
        /// 修改批次表 修改时间和对应的冲药
        /// </summary>
        public static string SqlUpdateBatchSet
        {
            get
            {
                return @"update sm_batch_set
                           set     
                               batch_time = ?,
                               time_id = ?,           
                               update_date = sysdate,
                               update_by = ?
                         where batch_id = ?";
            }
        }

        /// <summary>
        /// 判断修改的批次执行时间是否有重叠
        /// </summary>
        public static string SqlIsRepeat
        {
            get
            {
                return @"select 1
                        from (select rownum num, nsbs.* from (select nnSBS.* from SM_BATCH_SET nnSBS where nnSBS.status='1' ORDER BY BATCH_TIME)nsbs) sbs1,
                        (select rownum num, nsbs.* from (select nnSBS.* from SM_BATCH_SET nnSBS where nnSBS.status='1' ORDER BY BATCH_TIME)nsbs) sbs2,
                        (select rownum num, nsbs.* from (select nnSBS.* from SM_BATCH_SET nnSBS where nnSBS.status='1' ORDER BY BATCH_TIME)nsbs) sbs3
                        where sbs2.num - 1 = sbs1.num(+) 
                        and sbs2.num + 1 = sbs3.num(+) 
                        and sbs2.batch_id = ?
                        and ? > decode(sbs1.num,null,'00:00',sbs1.batch_time)
                        and ? < decode(sbs3.num,null,'23:59',sbs3.batch_time)";
            }
        }
        #endregion

        #region【SR_FREQUENCY_BATCH】

        /// <summary>
        /// /查询频率对应批次
        /// </summary>
        public static string SqlQueryFrequencyBatch
        {
            get
            {
                return @"select frequency_batch_id,
                           frequency_id,
                           frequency_name,
                           frequency_filter,
                           batchs_name,
                           ILLFIELD_ID,
                           ILLFIELD_NAME
                      from sr_frequency_batch_set
                     where status = '1'";
            }
        }

        /// <summary>
        /// 修改频率的批次
        /// </summary>
        public static string SqlUpdateFrequencyBatch
        {
            get
            {
                return @"update sr_frequency_batch_set
                           set  
                               batchs_name = ?,
                               update_by = ?,
                               update_date = sysdate
                         where frequency_batch_id = ?";
            }
        }

        /// <summary>
        /// 添加频率对应批次
        /// </summary>
        public static string sqlInsertFrequencyBatch
        {
            get
            {
                return @"insert into sr_frequency_batch_set
                          (frequency_batch_id, frequency_id, frequency_name, frequency_filter, batchs_name, status, create_by, create_date,ILLFIELD_ID,ILLFIELD_NAME)
                        values
                          (sr_frequency_batch_set_seq.nextval, ?, ?, ?, ?, '1', ?, sysdate,?,?)";
            }
        }

        /// <summary>
        /// 判断该频率是否已经设置
        /// </summary>
        public static string SqlQueryIllfieldFrequencyid
        {
            get
            {
                return @"select count(*)
  from sr_frequency_batch_set sfbs
 where sfbs.illfield_id = ?
   and sfbs.frequency_id = ?
   and sfbs.status = '1'";
            }
        }

        /// <summary>
        /// 从频率视图中查询未配置批次的频率信息
        /// </summary>
        public static string SqlQueryFrequency
        {
            get
            {
                return @"select *  from gm_frequency_view ";
            }
        }


        /// <summary>
        /// 删除数据  把状态改为0
        /// </summary>
        public static string SqlDeleteFrequencyBatch
        {
            get
            {
                return @"update sr_frequency_batch_set
                        set 
                            status = '0',       
                            update_by = ?,
                            update_date = sysdate
                      where frequency_batch_id = ?";
            }
        }

        #endregion

        #region【SR_PIVAS_SET】

        /// <summary>
        /// 查询所有病区
        /// </summary>
        public static string SqlQueryPivas
        {
            get
            {
                return @"select sps.*,decode(sps.long_time_status,'1','长期','0','临时','10','长期、临时') long_time_name  from sr_pivas_set sps where  sps.status='1'";
            }
        }

        #endregion

        #region【SR_PIVAS_SET】

        #region【GM_DEPT_VIEW】

        /// <summary>
        /// 查询病区
        /// </summary>
        public static string SqlQueryDept
        {
            get
            {
                return @"select * from gm_dept_view";
            }
        }

        #endregion

        #region【GM_USAGE_VIEW】

        /// <summary>
        /// 查询当前病区未配置的用法
        /// </summary>
        public static string SqlQueryUsage
        {
            get
            {
                return @"select * 
                        from gm_usage_view 
                        where usage_id not in(select usage_id from sr_pivas_set where office_id=? and status='1')";
            }
        }

        #endregion

        /// <summary>
        /// 病区对应用法的添加
        /// </summary>
        public static string SqlInsertDeptUsage
        {
            get
            {
                return @"insert into sr_pivas_set
  (pivas_set_id,
   office_id,
   office_name,
   usage_id,
   usage_name,
   status,
   create_by,
   create_date,
   LONG_TIME_STATUS)
values
  (sr_pivas_set_seq.nextval, ?, ?, ?, ?, '1', ?, sysdate,?)
";
            }
        }

        /// <summary>
        /// 查询待添加的数据是否有重复
        /// </summary>
        public static string SqlQueryIsRepeat
        {
            get
            {
                return @"select * from sr_pivas_set where office_id=? and usage_id=? and status='1'";
            }
        }

        /// <summary>
        /// 删除病区对应用法  把status改为0
        /// </summary>
        public static string SqlDeleteDeptUsage
        {
            get
            { 
                return  @"update sr_pivas_set
                       set
                           status = '0',      
                           update_by = ?,
                           update_date = sysdate
                     where pivas_set_id = ?";
            }
        }

        #endregion

        #endregion
    }
}
