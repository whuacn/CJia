using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// Sql语句定义
    /// </summary>
    public class SqlTools
    {
        #region 冲药SQL
        /// <summary>
        /// 获取给药时间为某天的瓶贴汇总
        /// </summary>
        public static string SqlQueryLabelCollect
        {
            get
            {
                return @"select spl.illfield_id, spl.illfield_name, spl.batch_name,
                     sum(decode(pivas_pharm_type, 1000201, 1, 0)) PTY,
                     sum(decode(pivas_pharm_type, 1000202, 1, 0)) JSY,
                     sum(decode(pivas_pharm_type, 1000203, 1, 0)) DMY,
                     sum(decode(pivas_pharm_type, 1000204, 1, 0)) GCY,
                     sum(decode(pivas_pharm_type, 1000205, 1, 0)) KSS,
                     count(*) subtotal
                     from st_pivas_label spl
                     where spl.LABEL_STATUS in (1000301, 1000302, 1000305)
           and spl.exe_status = '0'
                     and spl.PHARM_TIME between ? and ?
                     group by (spl.illfield_id, spl.illfield_name), rollup(spl.batch_name)";
            }
        }
        /// <summary>
        /// 获取给药时间为某天的瓶贴详情
        /// </summary>
        public static string SqlQueryLabelDetails
        {
            get
            {
                return @"select spl.*,spld.*, spl.GROUP_INDEX || '{' || spl.pivas_pharm_type_name || '}' || ':' || spl.label_no  group_no ,sc.user_id,sc.user_name,sc.check_date
                     from st_pivas_label spl,st_pivas_label_detail spld,st_check_detail scd,st_check sc
                     where SPL.EXE_STATUS='0'
                     and spl.group_index =  spld.group_index
                     and spld.group_index = scd.group_index
                     and scd.check_id = sc.check_id
                     and spl.PHARM_TIME between ? and ?
                     and spl.LABEL_STATUS in (1000301,1000302,1000305)";
            }
        }
        /// <summary>
        /// sql语句 查询出有多少次冲药,多少次拉单
        /// </summary>
        public static string SqlQueryTimeSet 
        {
            get
            {
                return @"select t.* 
                        from SM_TIME_SET t 
                        WHERE t.type=? and t.status='1'";
            }
        }
        /// <summary>
        /// 判断当天待冲药中有无待审退的瓶贴
        /// </summary>
        public static string SqlQueryLableApply
        {
            get
            {
                return @"select count(1) as amount from (select spl.*
                                                    from st_pivas_label spl
                        where spl.PHARM_TIME between ? and ?
                                                    and spl.LABEL_STATUS in (1000301,1000302,1000305) and spl.exe_status = '0') t
                                                    where exists (
                                                    select 1 from st_pivas_label_cancel_apply b where t.label_id=b.label_id
                                                    and b.LABEL_STATUS='1000302')";
            }
        }
        /// <summary>
        /// 获得发药单的seq值
        /// </summary>
        public static string SqlQueryPharmSendSeq
        {
            get
            {
                return @"select ST_PHARM_SEND_SEQ.nextval from dual";
            }
        }
        /// <summary>
        /// 根据冲药次数(第几次)修改当天待冲药瓶贴冲药状态及冲药信息
        /// </summary>
        public static string SqlUpdateTodayLable
        {
            get
            {
                return @"update st_pivas_label spl set spl.exe_status = '1',
                        spl.pharm_send_no=to_char(sysdate,'yyyymmdd')||'00'||?,
                        spl.user_id=?,spl.pharm_send_date=sysdate,spl.time_id=?,
                        PHARM_SEND_USER_NAME=?
                        where spl.PHARM_TIME between ? and ?
                                                    and spl.LABEL_STATUS in (1000301,1000302,1000305)
                                                    and spl.exe_status = '0'
                                                    and spl.batch_id in (select sbs.batch_id from sm_batch_set sbs,sm_time_set sts 
                                                    where sbs.time_id = sts.time_id 
                        and sbs.status = '1' and sts.status = '1' and sts.time_id =?)";
            }
        }
        /// <summary>
        /// 查询出当天待冲药的药品统计
        /// </summary>
        public static string SqlQueryTodayAllPharm
        {
            get
            {
                return @"select t.pharm_id,t.PHARM_NAME ,sum(t.pharm_amount)  from (select spl.*,spld.*
                                                    from st_pivas_arrange spa,st_pivas_label spl,st_pivas_label_detail spld
                                                    where spa.arrange_id = spl.arrange_id 
                                                    and SPL.EXE_STATUS='0'
                                                    and spl.label_id = spld.label_id
                        and spl.PHARM_TIME between ? and ?
                                                    and spl.LABEL_STATUS in (1000301,1000302,1000305)) t
                                                    GROUP BY t.PHARM_NAME,t.pharm_id";
            }
        }
        /// <summary>
        /// 查询当天配置中心药房库存不足的待冲药
        /// </summary>
        public static string SqlQueryTodayNoPharmStore
        {
            get
            {
                return @"select fro.*,
       decode(ppsv.real_account, null, '无此药品', '库存不足') as message
  from PM_PHARM_STORE_VIEW PPSV,
       (select t.pharm_id, t.PHARM_NAME, sum(t.pharm_amount) pharm_amount
          from (select spl.*, spld.*
                  from st_pivas_label spl, st_pivas_label_detail spld
                 where SPL.EXE_STATUS = '0'
                   and spl.group_index = spld.group_index
                   and spl.PHARM_TIME between ? and ?
                   and spl.LABEL_STATUS in (1000301, 1000302, 1000305)
                   and spl.batch_id in
                       (select sbs.batch_id
                          from sm_batch_set sbs, sm_time_set sts
                         where sbs.time_id = sts.time_id
                           and sbs.status = '1'
                           and sts.status = '1'
                           and sts.time_id = ?)) t
         GROUP BY t.PHARM_NAME, t.pharm_id) fro
 where ppsv.pharm_id(+) = fro.pharm_id
   and (ppsv.real_account < fro.pharm_amount or ppsv.real_account is null)";
            }
        }
        /// <summary>
        /// 获取某天的冲药单号
        /// </summary>
        public static string SqlQueryPharmSendNOBySendTime
        {
            get
            {
                return @"select distinct T.PHARM_SEND_NO,S.TIME_NAME,t.pharm_send_date from Sm_Time_Set S,
                        (select * from st_pivas_label spl 
                        WHERE spl.PHARM_TIME between ? and ?
                        and spl.exe_status = '1') T
                        WHERE S.TIME_ID=T.TIME_ID";
            }
        }
        /// <summary>
        /// 根据发药单号查询瓶贴明细
        /// </summary>
        public static string SqlQueryLableDetailByPharmSendNO
        {
            get 
            {
                return @"select  spl.*,spld.*, spl.GROUP_INDEX || '{' || spl.pivas_pharm_type_name || '}' || ' 瓶贴号:' || spl.label_no  group_no,SPLD.PHARM_AMOUNT||SPLD.AMOUNT_UNIT NEWAMOUNT
                        from st_pivas_label spl,st_pivas_label_detail spld
                        where spl.group_index = spld.group_index
                        and spl.pharm_send_no=?";
            }
        }
        /// <summary>
        /// 根据发药单号查询汇总药品统计
        /// </summary>
        public static string SqlQueryLabelStatByPharmSendNO
        {
            get
            {
                return @"select spl.pharm_send_no,spld.pharm_name,spld.spec, sum(spld.pharm_amount)||SPLD.AMOUNT_UNIT PHARM_TOTAL
                        from st_pivas_label spl,st_pivas_label_detail spld
                        where spl.group_index = spld.group_index
                        and spl.pharm_send_no=?
                        group by spld.pharm_name,spld.spec,spl.pharm_send_no,SPLD.AMOUNT_UNIT";
            }
        }
        /// <summary>
        /// 根据发药时间查询汇总药品统计
        /// </summary>
        public static string SqlQueryLabelCollectBySendTime
        {
            get 
            {
                return @"select spl.pharm_send_no,spld.pharm_name,spld.spec, sum(spld.pharm_amount)||SPLD.AMOUNT_UNIT PHARM_TOTAL
                        from st_pivas_label spl,st_pivas_label_detail spld
                        where  spl.group_index = spld.group_index
                        and spl.PHARM_TIME between ? and ?
                        AND spl.exe_status='1'
                        group by spld.pharm_name,spld.spec,spl.pharm_send_no,SPLD.AMOUNT_UNIT";
            }
        }
        /// <summary>
        /// 根据发药时间查询瓶贴信息及审核人信息
        /// </summary>
        public static string SqlQueryLabelAndCheckByPharmTime
        {
            get 
            {
                return @"select spl.*,spld.*,SPLD.PHARM_AMOUNT||SPLD.AMOUNT_UNIT NEWAMOUNT,sc.user_id,sc.user_name,sc.check_date
                        from st_pivas_label spl,st_pivas_label_detail spld,st_check_detail scd,st_check sc
                        where SPL.EXE_STATUS='1'
                        and spl.group_index = spld.group_index
                        and spld.group_index = scd.group_index
                        and scd.check_id = sc.check_id
                        and spl.PHARM_TIME between ? and ?";
            }
        }
        /// <summary>
        /// 根据条件统计发药单
        /// </summary>
        public static string SqlQueryPharmSendByCondition
        {
            get 
            {
                return @"select spld.pharm_name,spld.spec,p.factory_name,spld.amount_unit,p.form_name,sum(spld.pharm_amount) total,p.INHOS_PRICE
                        from st_pivas_label spl,st_pivas_label_detail spld,GM_PHARM_VIEW P
                        where  spl.group_index = spld.group_index
                        and spl.exe_status='1'
                        and p.pharm_id=spld.pharm_id
                        and spl.pharm_send_date between ? and ?";
            }
        }
        /// <summary>
        /// 库存不足，继续冲药（不包含库存不足的瓶贴）
        /// </summary>
        public static string SqlNotUpdateTodayNoStoreLabel
        {
            get 
            {
                return @"update st_pivas_label spl
    set spl.exe_status       = '1',
        spl.pharm_send_no    = to_char(sysdate, 'yyyymmdd') || '00' || ?,
        spl.user_id          = ?,
        spl.pharm_send_date  = sysdate,
        spl.time_id          = ?,
        PHARM_SEND_USER_NAME = ?
  where spl.PHARM_TIME between ? and ?
    and spl.LABEL_STATUS in (1000301, 1000302, 1000305)
    and spl.exe_status = '0'
    and spl.label_id not in
        (select fro.pivas_label_id
           from PM_PHARM_STORE_VIEW PPSV,
                (select t.pivas_label_id,
                        t.pharm_id,
                        t.PHARM_NAME,
                        sum(t.pharm_amount) pharm_amount
                   from (select spl.label_id pivas_label_id, spl.*, spld.*
                           from st_pivas_label spl, st_pivas_label_detail spld
                          where SPL.EXE_STATUS = '0'
                            and spl.group_index = spld.group_index
                            and spl.PHARM_TIME between ? and ?
                            and spl.LABEL_STATUS in
                                (1000301, 1000302, 1000305)
                            and spl.batch_id in
                                (select sbs.batch_id
                                   from sm_batch_set sbs, sm_time_set sts
                                  where sbs.time_id = sts.time_id
                                    and sbs.status = '1'
                                    and sts.status = '1'
                                    and sts.time_id = ?)) t
                  GROUP BY t.pivas_label_id, t.PHARM_NAME, t.pharm_id) fro
          where ppsv.pharm_id(+) = fro.pharm_id
            and (ppsv.real_account < fro.pharm_amount or
                 ppsv.real_account is null))
    and spl.batch_id in (select sbs.batch_id
                           from sm_batch_set sbs, sm_time_set sts
                          where sbs.time_id = sts.time_id
                            and sbs.status = '1'
                            and sts.status = '1'
                            and sts.time_id = ?)";            
            }
        }
        #endregion

        #region 审方SQL
        /// <summary>
        /// 获得病区数据
        /// </summary>
        public static string SqlSelectOffice
        {
            get
            {
                return @"SELECT distinct sps.office_id,sps.office_name FROM sr_pivas_set sps where sps.status = '1'";
            }
        }

        /// <summary>
        /// 获取医嘱
        /// </summary>
        public static string SqlSelectAdvice
        {
            get
            {
                return @"SELECT cav.* 
                         FROM Check_ADVICE_VIEW cav 
                         where cav.LIST_DATE between ? 
                         and ? 
                         and {0}";
            }
        }

        /// <summary>
        /// 查询组号
        /// </summary>
        public static string SqlSelectGroupIndex
        {
            get
            {
                return @"select group_index 
                         from Check_ADVICE_VIEW cav 
                         where where cav.LIST_DATE between ? 
                         and ? 
                         and {0}";
            }
        }

        /// <summary>
        /// 根据医嘱组编号查询审核明细
        /// </summary>
        public static string SqlSelectCheckDetailByGroupIndex
        {
            get 
            {
                return @"SELECT scd.* FROM st_check_detail scd WHERE scd.detail_status = '1' and scd.group_index = ? ";
            }

        }

        /// <summary>
        /// 获得审核表的seq值
        /// </summary>
        public static string SqlGetCheckSeq = @"select ST_CHECK_SEQ.Nextval from dual";

        /// <summary>
        /// 插入审核表数据
        /// </summary>
        public static string SqlInsertCheck
        {
            get
            {
                return @"insert into st_check
                            (check_id,user_id,check_date,user_code,user_name,dept_id,dept_name,create_by,create_date)
                        values
                            (?,?,sysdate,?,?,?,?,?,sysdate)";
            }
        }

        /// <summary>
        /// 获得审核明细表的seq值
        /// </summary>
        public static string SqlGetCheckDetailSeq = @"select ST_CHECK_DETAIL_SEQ.nextval from dual";
        
        /// <summary>
        /// 插入审核明细数据
        /// </summary>
        public static string SqlInsertCheckDetail
        {
            get
            {
                return @"insert into st_check_detail
                            (detail_id, check_id, group_index,original_pivas_status, check_pivas_status,original_pivas_batch_no, check_pivas_batch_no, detail_status, database_flag, create_by, create_date,cancel_reason)
                        values
                            (st_check_detail_seq.nextval, ?, ?, ?, ?, ?, ?, '1', 'W', ?, sysdate, ?)";
            }
        }

        /// <summary>
        /// 批量查询审核明细表中的未审医嘱
        /// </summary>
        public static string SqlCheckDetail
        {
            get
            {
                return @"SELECT scd.*
                          FROM st_check_detail scd
                         WHERE scd.detail_status = '1'
                           and scd.group_index In
                               (select cav.group_index
                                  from Check_ADVICE_VIEW cav
                                 where cav.LIST_DATE between ? and ?
                                   and check_pivas_status = 1000101
                                   and {0})";
            }
        }
        /// <summary>
        /// 批量查询审核明细表中的已审医嘱
        /// </summary>
        public static string SqlYesCheckDetail
        {
            get
            {
                return @"SELECT scd.*
                          FROM st_check_detail scd
                         WHERE scd.detail_status = '1'
                           and scd.group_index In
                               (select cav.group_index
                                  from Check_ADVICE_VIEW cav
                                 where cav.LIST_DATE between ? and ?
                                   and check_pivas_status =1000102
                                   and {0})";
            }
        }

        /// <summary>
        /// 查询需要批量插入的数据
        /// </summary>
        public static string SqlBatchData
        {
            get
            {
                return @"select distinct cav.group_index
                           from Check_ADVICE_VIEW cav
                           where cav.LIST_DATE between ? and ?
                           and check_pivas_status = 1000101
                           and {0}";
            }
        }

        /// <summary>
        /// 批量插入审核明细表
        /// </summary>
        public static string SqlBatchInsertCheckDetail
        {
            get
            {
                return @"insert into st_check_detail
                          (detail_id,
                           check_id,
                           group_index,
                           original_pivas_status,
                           check_pivas_status,
                           original_pivas_batch_no,
                           check_pivas_batch_no,
                           detail_status,
                           database_flag,
                           create_by,
                           create_date)
                          select st_check_detail_seq.nextval,
                                 ?,
                                 cav.group_index,
                                 cav.original_pivas_status,
                                 ?,
                                 cav.original_pivas_batch_no,
                                 cav.check_pivas_batch_no,
                                 '1',
                                 'W',
                                 ?,
                                 sysdate
                            from (select distinct cav.group_index,
                                 cav.original_pivas_status,
                                 cav.original_pivas_batch_no,
                                 cav.check_pivas_batch_no
                                                   from Check_ADVICE_VIEW cav
                                                  where cav.LIST_DATE between ? and ?
                                                    and check_pivas_status = 1000101
                                                    and {0}) cav";
            }
        }

        /// <summary>
        /// 根据组号查询明细ID
        /// </summary>
        public static string SqlSelectDetailIdByGroupIndex
        {
            get
            {
                return @"SELECT scd.detail_id FROM st_check_detail scd where scd.detail_status = '1' and scd.group_index = ?";
            }
        }

        /// <summary>
        /// 根据组号将审核明细表的数据置为无效
        /// </summary>
        public static string SqlUpdateCheckDetailToValid
        {
            get 
            {
                return @"update st_check_detail scd
                           set scd.detail_status = '0', scd.update_by = ?, scd.update_date = sysdate
                         where scd.group_index in (SELECT distinct scd.group_index
                                               FROM st_check_detail scd,Check_ADVICE_VIEW cav
                                                where scd.detail_status = '1'
                                                and cav.LIST_DATE between ? and ?
                                                and scd.check_pivas_status = 1000101
                                                and scd.group_index = cav.group_index
                                                and {0})";
            }
        }

        /// <summary>
        /// 根据组号将审核明细表的该数据置为无效
        /// </summary>
        public static string SqlUpdateCheckDetailValid
        {
            get
            {
                return @" update st_check_detail set detail_status = '0', update_by = ?,
                          update_date = sysdate where detail_id = ? ";
            }
        }

        /// <summary>
        /// 批量将审核明细表的数据置为无效
        /// </summary>
        public static string SqlBatchUpdateCheckDetailValid
        {
            get
            {
                return @"update st_check_detail
                                   set detail_status = '0', update_by = ?, update_date = sysdate
                                 where detail_id in
                                       (SELECT scd.detail_id
                                          FROM st_check_detail scd, Check_ADVICE_VIEW cav
                                         where scd.group_index = cav.GROUP_INDEX
                                           and scd.detail_status = '1'
                                           and scd.group_index in
                                               (select group_index
                                                  from advice_view cav
                                                 where cav.LIST_DATE between ? and ?
                                                    and check_pivas_status = 1000102
                                                    and {0} ))";
            }
        }

        /// <summary>
        /// 修改审核明细表
        /// </summary>
        public static string SqlUpdateCheckDetail
        {
            get 
            {
                return @"update st_check_detail
                         set cancel_check_id = ?,
                             original_pivas_status = ?,
                             check_pivas_status = ?,
                             ORIGINAL_PIVAS_BATCH_NO = ?,
                             CHECK_PIVAS_BATCH_NO = ?,
                             update_by = ?,
                             update_date = sysdate,
                             cancel_reason = ?
                        where detail_id = ?";
            }
        }

        /// <summary>
        /// 根据住院ID查询病人信息
        /// </summary>
        public static string SqlSelectPatientByInhosId
        {
            get
            {
                return @"select hpv.* from hm_patient_view hpv where to_char(hpv.inhos_id) = ?";
            }
        }

        /// <summary>
        /// 根据住院ID查询病人病史信息(医嘱)
        /// </summary>
        public static string SqlSelectPatientHistoryByInhosId
        {
            get
            {
                return @"SELECT phv.* FROM patient_history_view phv where to_char(phv.inhos_id) = ?";
            }
        }

        /// <summary>
        /// 根据审核明细ID查找明细
        /// </summary>
        public static string SqlSelectDetail
        {
            get
            {
                return @"select scd.* from st_check_detail scd where scd.detail_id = ? ";
            }
        }

        /// <summary>
        /// 审方修改批次
        /// </summary>
        public static string SqlUpdateBatch
        {
            get
            {
                return @"insert into st_check_detail
                          (detail_id,
                           check_id,
                           cancel_check_id,
                           group_index,
                           original_pivas_status,
                           check_pivas_status,
                           original_pivas_batch_no,
                           check_pivas_batch_no,
                           pivas_label_last_create_date,
                           detail_status,
                           database_flag,
                           create_by,
                           create_date,
                           cancel_reason)
                          select distinct ?,
                                          ?,
                                          scd.cancel_check_id,
                                          scd.group_index,
                                          scd.original_pivas_status,
                                          scd.check_pivas_status,
                                          scd.original_pivas_batch_no,
                                          ?,
                                          scd.pivas_label_last_create_date,
                                          scd.detail_status,
                                          scd.database_flag,
                                          ?,
                                          sysdate,
                                          scd.cancel_reason
                            from (SELECT detail_id,
                                         scd.cancel_check_id,
                                         scd.group_index,
                                         scd.original_pivas_status,
                                         scd.check_pivas_status,
                                         scd.original_pivas_batch_no,
                                         scd.pivas_label_last_create_date,
                                         scd.detail_status,
                                         scd.database_flag,
                                         scd.cancel_reason
                                    FROM st_check_detail scd
                                   WHERE scd.group_index = ?
                                     and scd.detail_status = '1') scd";
            }
        }

        /// <summary>
        /// 查询配置中心没有的药品信息
        /// </summary>
        public static string SqlSelectPharmNotInPivas
        {
            get
            {
                return @"SELECT cav.ADVICE_ID,cav.ADVICE_NAME FROM Check_ADVICE_VIEW cav
                    where cav.ADVICE_ID not in (SELECT gpv.PHARM_ID FROM gm_pharm_view gpv)";
            }
        }

        /// <summary>
        /// 删除固定瓶贴表
        /// </summary>
        public static string SqlDeleteCommonLabel
        {
            get
            {
                return @"delete st_common_label scl
                         where scl.check_detail_id in
                               (select scd.Detail_Id
                                  from st_check_detail scd
                                  {0})";
            }
        }

        /// <summary>
        /// 插入固定瓶贴
        /// </summary>
        public static string SqlInsertCommonLabel
        {
            get
            {
                return @"insert into st_common_label
                          (st_common_label_id,
                           database_flag,
                           check_detail_id,
                           pivas_pharm_type,
                           pivas_pharm_type_name,
                           label_detail,
                           usage_id,
                           usage_name,
                           frequency_id,
                           frequency_name,
                           frequency_memo,
                           times,
                           inhos_id,
                           pharm_id1,
                           pharm_dosage1,
                           pharm_id2,
                           pharm_dosage2,
                           create_by,
                           create_date,
                           update_by,
                           update_date,
                           pharm_seq,
                           batch_id,
                           batch_name,
                           s_no)
                          select st_common_label_seq.nextval common_label_id,
                                 lab.database_flag,
                                 lab.check_detail_id,
                                 lab.pivas_pharm_type,
                                 lab.pivas_pharm_type_name,
                                 lab.label_detail,
                                 lab.usage_id,
                                 lab.usage_name,
                                 lab.frequency_id,
                                 lab.frequency_name,
                                 lab.frequency_memo,
                                 lab.times,
                                 lab.inhos_id,
                                 lab.pharm_id1,
                                 lab.pharm_dosage1,
                                 lab.pharm_id2,
                                 lab.pharm_dosage2,
                                 lab.create_by,
                                 lab.create_date,
                                 lab.update_by,
                                 lab.update_date,
                                 lab.pharm_seq,
                                 sbs.batch_id,
                                 sbs.batch_name,
                                 get_s_no(lab.Check_Pivas_Batch_No,lab.Batch_num) s_no
                          from (select 
                                 slv.*,
                                 ? create_by, -- 创建人参数
                                 sysdate create_date,
                                 null update_by,
                                 null update_date,
                                 null pharm_seq,
                                 substr('-' || slv.Check_Pivas_Batch_No, rownum * 2, 1) Batch_num
                            from (select * from ST_LABEL_VIEW nslv where nslv.group_index = ? /*医嘱参数*/) slv
                          connect by rownum <= length(slv.Check_Pivas_Batch_No) / 2) lab
                                ,(select t.* , rownum batch_num from (select * from SM_BATCH_SET where status = '1' order by batch_time) t) sbs
                            where lab.Batch_num = sbs.batch_num
                            and lab.group_index = ? -- 医嘱参数 
                            -- 传多个组号是 因为存在只能把第一个组号的 1-2-3- 的批次信息转换成 1,2,3 
                            -- 其他组号对应的批次不能转换 所有该sql只能 一个组号 一个组号的插入瓶贴基表";
            }
        }

        /// <summary>
        /// 插入瓶贴详情
        /// </summary>
        public static string SqlInsertLabelDetail
        {
            get
            {
                return @"insert into st_pivas_label_detail
  (label_detail_id,
   label_id,
   label_no,
   group_index,
   database_flag,
   his_advice_id,
   pharm_id,
   pharm_name,
   spec,
   pharm_amount,
   amount_unit,
   pharm_dosage,
   dosage_unit,
   public1,
   pharm_common_name)
  select st_pivas_label_detail_seq.nextval LABEL_DETAIL_ID,
         null,
         null,
         hav.GROUP_INDEX,
         'w',
         hav.ADVICE_ID,
         hav.gm_advice_id,
         hav.ADVICE_NAME,
         hav.SPEC,
         hav.account,
         hav.account_unit,
         hav.DOSAGE,
         hav.DOSAGE_UNIT,
         null,
         hav.COMMON_NAME
    from ht_advice_view hav
    where hav.GROUP_INDEX = ?
      and ? not in (select spld.group_index from st_pivas_label_detail spld)
   ";
            }
        }

        #endregion

        #region 退药
        /// <summary>
        /// 关联瓶贴表、瓶贴明细表（医嘱Id）、医嘱视图（医嘱名称）和退药申请表找到查询瓶贴信息
        /// </summary>
        public static string SqlSelectCancelApply = @"SELECT A.LABEL_ID,
                                   A.LABEL_NO,
                                   (CASE
                                     WHEN B.EXE_STATUS = '0' THEN
                                      '未冲'
                                     ELSE
                                      '已冲'
                                   END) EXE_STATUS,
                                   B.ILLFIELD_ID,
                                   '[' || D.ILLCASE_NO || ']' || B.ILLFIELD_NAME ILLFIELD_NAME,
                                   B.PATIENT_NAME || '[' || B.BED_NAME || ']' PATIENT_NAME,
                                   B.GROUP_INDEX || '[' || B.PIVAS_PHARM_TYPE_NAME || ']' || '瓶贴号' ||
                                   A.LABEL_ID GROUP_INDEX_UNION,
                                   B.GROUP_INDEX,
                                   C.PHARM_NAME,
                                   C.SPEC,
                                   C.PHARM_AMOUNT,
                                   C.DOSAGE_UNIT,
                                   B.PIVAS_PHARM_TYPE_NAME,
                                   B.BATCH_NAME,
                                   DECODE(B.Exe_Status,'0','',to_char(B.PHARM_TIME, 'YYYY-MM-DD hh:mm')) PHARM_TIME
                              FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
                                   ST_PIVAS_LABEL              B,
                                   ST_PIVAS_LABEL_DETAIL       C,
                                   HM_PATIENT_VIEW             D
                             WHERE A.LABEL_STATUS = 1000302
                               AND A.LABEL_ID = B.LABEL_ID
                               AND B.GROUP_INDEX = C.GROUP_INDEX
                               AND B.INHOS_ID = D.INHOS_ID
                               AND B.PHARM_TIME {0} 
                               AND B.EXE_STATUS IN {1}  
                               AND B.ILLFIELD_ID IN {2}
                               ORDER BY PHARM_TIME";

        /// <summary>
        /// 查询上线病区
        /// </summary>
        public static string SqlSelectOfficeName = @"SELECT OFFICE_ID,OFFICE_NAME FROM SR_PIVAS_SET";

        /// <summary>
        /// 取得退药表下一个Id
        /// </summary>
        public static string SqlSelectNextCancelRCPId = @"SELECT to_char(sysdate, 'yyyymmdd') ||
                                   lpad(nvl(MAX(substr(A.CANCEL_RCP_ID, -4)), 0) + 1, 4, '0')
                              FROM ST_PIVAS_LABEL_CANCEL_RCP A
                             WHERE A.CANCEL_RCP_ID LIKE TO_CHAR(SYSDATE, 'YYYYMMDD') || '%'";
        /// <summary>
        /// 同意退药时插入退药表
        /// </summary>
        public static string SqlInsertCancelRCP = @"insert into st_pivas_label_cancel_rcp
                                            values
                                              (?,
                                               ?,
                                               ?,
                                               ?,
                                               ?,
                                               ?,
                                               sysdate,
                                               ?,
                                               sysdate,
                                               ?,
                                               sysdate)";

        /// <summary>
        /// 同意退药时修改瓶贴表中瓶贴状态
        /// </summary>
        public static string SqlUpdatePivasLabelStatus = @"UPDATE ST_PIVAS_LABEL
           SET LABEL_STATUS = 1000303, UPDATE_BY = ?, UPDATE_DATE = SYSDATE
         WHERE GROUP_INDEX IN ({0})";

        /// <summary>
        /// 同意退药时修改退药申请表
        /// </summary>
        public static string SqlUpdateCancelApply = @"UPDATE ST_PIVAS_LABEL_CANCEL_APPLY A
                   SET A.LABEL_STATUS  = 1000303,
                       A.CANCEL_RCP_ID = ?,
                       UPDATE_BY       = ?,
                       UPDATE_DATE     = SYSDATE
                 WHERE A.LABEL_STATUS = 1000302
                   AND A.LABEL_ID IN
                       (SELECT B.LABEL_ID FROM ST_PIVAS_LABEL B WHERE B.GROUP_INDEX IN ({0}))";

        /// <summary>
        /// 拒绝退药时修改退药申请表瓶贴状态(界面所选相同组号)
        /// </summary>
        public static string SqlUpdateRefuseApply = @"UPDATE ST_PIVAS_LABEL_CANCEL_APPLY A
                   SET A.LABEL_STATUS  = 1000305,
                       A.CANCEL_RCP_ID = ?,
                       UPDATE_BY       = ?,
                       UPDATE_DATE     = SYSDATE
                 WHERE A.LABEL_STATUS = 1000302
                   AND A.LABEL_ID IN (SELECT B.LABEL_ID
                                        FROM ST_PIVAS_LABEL B
                                       WHERE A.LABEL_ID = B.LABEL_ID
                                         AND B.GROUP_INDEX IN ({0}))";
        /// <summary>
        /// 查询所选日期所有退药单号（不包括拒绝退药单号）
        /// </summary>
        public static string SqlSelectDisTinCancelRCPID = @"SELECT D.CANCEL_RCP_ID, D.CHECK_TIME
                              FROM ST_PIVAS_LABEL_CANCEL_RCP D
                             WHERE TRUNC(D.CHECK_TIME) = TRUNC(?)";

        /// <summary>
        /// 查询退药单信息
        /// </summary>
        public static string SqlSelectRCP = @"SELECT D.CANCEL_RCP_ID,
                                       C.PHARM_NAME,
                                       C.SPEC,
                                       C.PHARM_AMOUNT,
                                       B.ILLFIELD_NAME,
                                       A.CANCEL_USER_NAME,
                                       TO_CHAR(D.CHECK_TIME, 'YYYY-MM-DD hh:mm') CHECK_TIME,
                                       DECODE(A.LABEL_STATUS, 1000303, '确认退药', 1000305, '拒绝申退') LABEL_STATUS,
                                       B.BATCH_NAME,
                                       B.PATIENT_NAME,
                                       B.GROUP_INDEX || '{' || B.PIVAS_PHARM_TYPE_NAME || '}' || '瓶贴号' ||
                                       A.LABEL_ID GROUP_INDEX_UNION
                                  FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
                                       ST_PIVAS_LABEL              B,
                                       ST_PIVAS_LABEL_DETAIL       C,
                                       ST_PIVAS_LABEL_CANCEL_RCP   D
                                 WHERE A.LABEL_STATUS = ?
                                   AND A.LABEL_ID = B.LABEL_ID
                                   AND A.CANCEL_RCP_ID = D.CANCEL_RCP_ID
                                   AND B.GROUP_INDEX = C.GROUP_INDEX
                                   AND TRUNC(D.CHECK_TIME) = TRUNC(?)";

        /// <summary>
        /// 选择单号后汇总查询退药信息
        /// </summary>
        public static string SqlSelectAllCancelRCPById = @"SELECT C.PHARM_NAME,
                                       C.SPEC,
                                       SUM(C.PHARM_AMOUNT) || C.AMOUNT_UNIT PHARM_AMOUNT
                                  FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
                                       ST_PIVAS_LABEL              B,
                                       ST_PIVAS_LABEL_DETAIL       C,
                                       ST_PIVAS_LABEL_CANCEL_RCP   D
                                 WHERE A.LABEL_STATUS = ?
                                   AND A.LABEL_ID = B.LABEL_ID
                                   AND A.CANCEL_RCP_ID = D.CANCEL_RCP_ID
                                   AND B.GROUP_INDEX = C.GROUP_INDEX
                                   AND TRUNC(D.CHECK_TIME) = TRUNC(?)
                                   AND A.CANCEL_RCP_ID = {0}
                                GROUP BY C.PHARM_NAME,
                                         C.SPEC,
                                         C.AMOUNT_UNIT";

        /// <summary>
        /// 退药汇总查询 
        /// </summary>
//        public static string SqlSelectAllCancelPharm = @"SELECT C.PHARM_ID,
//                                           C.PHARM_NAME,
//                                           C.SPEC,
//                                           SUM(C.PHARM_AMOUNT) || C.AMOUNT_UNIT PHARM_AMOUNT,
//                                           D.CHECK_TIME,
//                                           D.CANCEL_RCP_ID
//                                      FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
//                                           ST_PIVAS_LABEL              B,
//                                           ST_PIVAS_LABEL_DETAIL       C,
//                                           ST_PIVAS_LABEL_CANCEL_RCP   D
//                                     WHERE A.LABEL_STATUS = 1000303
//                                       AND A.LABEL_ID = B.LABEL_ID
//                                       AND A.CANCEL_RCP_ID = D.CANCEL_RCP_ID
//                                       AND B.LABEL_ID = C.LABEL_ID
//                                       AND D.CHECK_TIME = ?
//                                     GROUP BY C.PHARM_ID,
//                                              C.PHARM_NAME,
//                                              C.SPEC,
//                                              C.AMOUNT_UNIT,
//                                              D.CHECK_TIME,
//                                              D.CANCEL_RCP_ID";
        public static string SqlSelectAllCancelPharm = @"SELECT PHARM_ID,
                                       PHARM_NAME,
                                       SPEC,
                                       SUM(PHARM_AMOUNT) || AMOUNT_UNIT PHARM_AMOUNT,
                                       CHECK_TIME,
                                       CANCEL_RCP_ID
                                  FROM CANCEL_APPLY_COMMON_VIEW
                                  WHERE TRUNC(CHECK_TIME) = TRUNC(?)
                                  GROUP BY PHARM_ID,
                                           PHARM_NAME,
                                           SPEC,
                                           AMOUNT_UNIT,
                                           CHECK_TIME,
                                           CANCEL_RCP_ID";

        /// <summary>
        /// 退药申请界面打印，打印所勾选的瓶贴药品
        /// </summary>
//        public static string SqlSelectPrintApplyCancelPharm = @"SELECT C.PHARM_ID,
//               D.CANCEL_RCP_ID CANCEL_RCP_ID,
//               D.CHECK_TIME CHECK_TIME,
//               B.ILLFIELD_ID,
//               B.ILLFIELD_NAME,
//               B.BATCH_NAME || '{' || B.PIVAS_PHARM_TYPE_NAME || '}' || '瓶贴号：' ||
//               A.LABEL_ID || '，' || B.PATIENT_NAME || '，' || '住院号：' || B.INHOS_ID || '第' ||
//               B.BED_NAME || '床' || '，' || B.OFFICE_NAME LABEL_NO,
//               C.PHARM_NAME,
//               C.SPEC SPEC,
//               C.PHARM_AMOUNT || C.AMOUNT_UNIT PHARM_AMOUNT
//          FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
//               ST_PIVAS_LABEL              B,
//               ST_PIVAS_LABEL_DETAIL       C,
//               ST_PIVAS_LABEL_CANCEL_RCP   D
//         WHERE A.LABEL_STATUS = 1000303
//           AND A.LABEL_ID = B.LABEL_ID
//           AND A.CANCEL_RCP_ID = D.CANCEL_RCP_ID
//           AND B.LABEL_ID = C.LABEL_ID
//           AND B.GROUP_INDEX IN ({0})";
        public static string SqlSelectPrintApplyCancelPharm = @"SELECT PHARM_ID,
                                   CANCEL_RCP_ID,
                                   TO_CHAR(CHECK_TIME, 'YYYY-MM-DD hh:mm') CHECK_TIME,
                                   ILLFIELD_ID,
                                   ILLFIELD_NAME,
                                   LABEL_NO,
                                   PHARM_NAME,
                                   SPEC,
                                   PHARM_AMOUNT || AMOUNT_UNIT PHARM_AMOUNT
                              FROM CANCEL_APPLY_COMMON_VIEW
                              WHERE GROUP_INDEX IN ({0})";


        /// <summary>
        /// 退药单查询界面打印
        /// </summary>
//        public static string SqlSelectPrintCancelPharm = @"SELECT C.PHARM_ID,
//                           D.CANCEL_RCP_ID CANCEL_RCP_ID,
//                           D.CHECK_TIME CHECK_TIME,
//                           B.ILLFIELD_ID,
//                           B.ILLFIELD_NAME,
//                           B.BATCH_NAME || '{' || B.PIVAS_PHARM_TYPE_NAME || '}' || '瓶贴号：' ||
//                           A.LABEL_ID || '，' || B.PATIENT_NAME || '，' || '住院号：' || B.INHOS_ID || '第' ||
//                           B.BED_NAME || '床' || '，' || B.OFFICE_NAME LABEL_NO,
//                           C.PHARM_NAME,
//                           C.SPEC SPEC,
//                           SUM(C.PHARM_AMOUNT) || C.AMOUNT_UNIT PHARM_AMOUNT
//                      FROM ST_PIVAS_LABEL_CANCEL_APPLY A,
//                           ST_PIVAS_LABEL              B,
//                           ST_PIVAS_LABEL_DETAIL       C,
//                           ST_PIVAS_LABEL_CANCEL_RCP   D
//                     WHERE A.LABEL_STATUS = 1000303
//                       AND A.LABEL_ID = B.LABEL_ID
//                       AND A.CANCEL_RCP_ID = D.CANCEL_RCP_ID
//                       AND B.LABEL_ID = C.LABEL_ID
//                       AND D.CHECK_TIME = ?
//                     GROUP BY C.PHARM_ID,
//                              D.CANCEL_RCP_ID,
//                              C.PHARM_NAME,
//                              C.SPEC,
//                              CHECK_TIME,
//                              C.AMOUNT_UNIT,
//                              B.ILLFIELD_ID,
//                              ILLFIELD_NAME,
//                              B.BATCH_NAME,
//                              B.PIVAS_PHARM_TYPE_NAME,
//                              A.LABEL_ID,
//                              B.PATIENT_NAME,
//                              B.INHOS_ID,
//                              B.BED_NAME,
//                              B.OFFICE_NAME";
        public static string SqlSelectPrintCancelPharm = @"SELECT PHARM_ID,
                           CANCEL_RCP_ID,
                           TO_CHAR(CHECK_TIME, 'YYYY-MM-DD hh:mm') CHECK_TIME,
                           ILLFIELD_ID,
                           ILLFIELD_NAME,
                           LABEL_NO,
                           PHARM_NAME,
                           SPEC,
                           SUM(PHARM_AMOUNT) || AMOUNT_UNIT PHARM_AMOUNT
                      FROM CANCEL_APPLY_COMMON_VIEW
                     WHERE TRUNC(CHECK_TIME) = TRUNC(?)
                     GROUP BY PHARM_ID,
                              CANCEL_RCP_ID,
                              CHECK_TIME,
                              ILLFIELD_ID,
                              ILLFIELD_NAME,
                              LABEL_NO,
                              PHARM_NAME,
                              SPEC,
                              AMOUNT_UNIT";

       #endregion

        #region【用户】
        /// <summary>
        /// 查询登录用户
        /// </summary>
        public static string SelectUser
        {
            get
            {
                return @"select * 
                         from sm_user 
                         where user_no=? and user_password=? ";
            }
        }
        #endregion
    }
}

