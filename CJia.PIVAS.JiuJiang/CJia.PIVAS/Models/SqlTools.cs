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
        public static string SqlQueryError
        {
            get
            {
                return @"select * from VW_HT_ADVICE_ERROR t";
            }
        }
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
                          and spl.PRINT_STATUS = '1'
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
       (select nog.PHARM_ID,nog.PHARM_NAME,nog.SPEC,pv.FACTORY_NAME,sum(nog.ACCOUNT*nog.TIMES) 
total,nog.ACCOUNT_UNIT
from st_pivas_no_group_view nog,st_check ck,st_check_detail ckd,gm_pharm_view pv
where ck.check_id=ckd.check_id
and nog.GROUP_INDEX=ckd.group_index
and nog.PHARM_ID=pv.PHARM_ID
and ckd.detail_status='1'
and ckd.check_pivas_status=1000102
{0}/*病区*/
group by nog.pharm_id,
       nog.pharm_name,
       nog.spec,
       pv.FACTORY_NAME,
       nog.ACCOUNT_UNIT) fro
 where ppsv.pharm_id(+) = fro.pharm_id
   and (ppsv.real_account < fro.total or ppsv.real_account is null)";
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
                            and spl.PHARM_TIME between ? and ?s
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

        /// <summary>
        /// 查询所有病区
        /// </summary>
        public static string SqlQueryAllIffield
        {
            get
            {
                return @"select distinct sps.office_id,sps.office_name from sr_pivas_set sps where sps.status = '1' order by sps.office_name, sps.office_id";
            }
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        public static string SqlQueryAllBacthLabel
        {
            get
            {
                return @"select * from SM_BATCH_SET SBS ORDER BY SBS.BATCH_TIME";
            }
        }

        /// <summary>
        /// 查询以冲药瓶贴
        /// </summary>
        public static string SqlSendALLQueryLable
        {
            get
            {
                return @"select t.*,
       rpad(t.group_index, t.rn + length(t.group_index) - 1, ' ') new_group_index,
       t.illfield_id || LPAD(REPLACE(t.bed_id,'+','a'), 4, 0) || LPAD(t.PATIENT_ID, 10, 0) ILLFILED_BED_PATIENT_CODE,
       t.group_index || t.rn new_group_index_no,
       (case
         when t.fee_count > 1 then
          decode(fn_pharm_is_save(t.pharm_id),
                 1,
                 ceil(t.fee_count * t.pharm_dosage / t.dose_per_unit),
                 t.fee_count * t.amount)
         when t.fee_count = 1 then
          t.amount
         else
          0
       end) pharm_amount
  from (select spl.*,
               spld.pharm_id,
               spld.pharm_name,
               spld.spec,
               gpv.FACTORY_NAME  PHARM_FACTION,
               gpv.FLAG          flag,
               gpv.dose_per_unit,
               spld.pharm_amount amount,
               spld.amount_unit,
               spld.pharm_dosage,
               spld.dosage_unit
          from (select t.*,
                       row_number() over(partition by t.group_index, t.batch_id order by t.batch_id) rn
                  from (select nspl.label_id,
                               gb.label_bar_id,
                               nspl.group_index,
                               nspl.illfield_id,
                               nspl.illfield_name,
                               nspl.batch_id,
                               nspl.batch_name,
                               nspl.bed_id,
                               nspl.bed_name,
                               nspl.inhos_id,
                               nspl.patient_id,
                               nspl.PATIENT_NAME,
                               '[' || nspl.Bed_Id || '床]' || nspl.PATIENT_NAME || ' ' ||
                               nspl.patient_id NAME,
                               nspl.exe_status,
                               DECODE(nspl.exe_status, 1, '已计费', '未计费') exe_status_name,
                               nspl.pharm_send_date,
                               nspl.pharm_send_user_name,
                               gc.code bar_status,
                               gc.name bar_status_name,
                               fn_is_print(nspl.group_index) is_group,
                               nspl.long_time_status long_time_status,
                               nspl.fee_count,
                               gb.gen_name,
                               gb.gen_date,
                               nspl.pharm_time,
                               nspl.list_doctor_name,
                               nspl.list_doctor_date
                          from st_pivas_label nspl,
                               (select --to_char(WMSYS.WM_CONCAT(NGB.LABEL_BAR_ID)) label_bar_id,
                                        min(NGB.LABEL_BAR_ID) label_bar_id,
                                       ngb.label_id,
                                       max(ngb.status) status,
                                       ngb.gen_name,
                                       max(ngb.gen_date) gen_date
                                  from gm_barcode ngb
                                 where ngb.status != 1000603
                                 group by --ngb.label_bar_id,
                                          ngb.label_id,
                                          ngb.gen_name
                                           --,
                                          --ngb.gen_date
                                        ) gb,
                               gm_code gc
                         where nspl.label_id = gb.label_id
                           and gb.status = gc.code
                           and nspl.label_status in
                               (1000301, 1000302, 1000305)
                           {0}
                           and {1}
                           and {2}) t) spl,
               st_pivas_label_detail spld,
               gm_pharm_view gpv
         where spl.group_index = spld.group_index
           and spld.pharm_id = gpv.PHARM_ID) t
 order by t.illfield_name, t.illfield_id, t.bed_id";
            }
        }

        /// <summary>
        /// 查询已冲药瓶贴汇总
        /// </summary>
        public static string SqlSendALLQueryLableSum
        {
            get
            {
                return @"SELECT nvl(NSPL.ILLFIELD_NAME,'全部病区') ILLFIELD_NAME,
       SUM(DECODE(BATCH_ID, 1000000000, 1, 0)) BATCH_LABEL_COUNT1,
       SUM(DECODE(BATCH_ID, 1000000001, 1, 0)) BATCH_LABEL_COUNT2,
       SUM(DECODE(BATCH_ID, 1000000002, 1, 0)) BATCH_LABEL_COUNT3,
       SUM(DECODE(BATCH_ID, 1000000003, 1, 0)) BATCH_LABEL_COUNT4,
       SUM(DECODE(BATCH_ID, 1000000006, 1, 0)) BATCH_LABEL_COUNT5,
       SUM(DECODE(BATCH_ID, 1000000007, 1, 0)) BATCH_LABEL_COUNT6,
       SUM(DECODE(BATCH_ID, 2000000021, 1, 0)) BATCH_LABEL_COUNTZ, --zsp
       SUM(DECODE(BATCH_ID, 2000000020, 1, 0)) BATCH_LABEL_COUNTW, --db2
       SUM(DECODE(BATCH_ID, 1000000004, 1, 0)) BATCH_LABEL_COUNTB, --db
       SUM(DECODE(BATCH_ID, 1000000005, 1, 0)) BATCH_LABEL_COUNTL, --ls
       COUNT(*) ALL_BATCH_LABEL_COUNT
  FROM ST_PIVAS_LABEL NSPL,
       (SELECT NGB.LABEL_BAR_ID,
               NGB.LABEL_ID,
               MAX(NGB.STATUS) STATUS,
               NGB.GEN_NAME,
               NGB.GEN_DATE
          FROM GM_BARCODE NGB
         WHERE NGB.STATUS != 1000603
         GROUP BY NGB.LABEL_BAR_ID, NGB.LABEL_ID, NGB.GEN_NAME, NGB.GEN_DATE) GB
 WHERE NSPL.LABEL_ID = GB.LABEL_ID
   AND NSPL.LABEL_STATUS IN (1000301, 1000302, 1000305)
   {0}
                           and {1}
                           and {2}
 GROUP BY ROLLUP(ILLFIELD_NAME)
 ";
            }
        }

        /// <summary>
        /// 查询配置的医嘱
        /// </summary>
        public static string SqlSendYesQueryLabel
        {
            get
            {
                return @"select spl.group_index,
        null advice_id,
        null ORDER_NO,
        null ORDER_SUB_NO,
        null patient_id,--病人id
        spl.inhos_id,--病人住院id
        spl.patient_name,--姓名
        spl.bed_id,--床位号
        spl.illfield_id illfield_id,--病区id
        spl.illfield_name illfield_name,--病区名
        spl.office_id office_id,--科室id
        spl.office_name office_name,--科室名
        spld.pharm_id pharm_ID, --药品id
        spld.pharm_name pharm_name,--药品名称
        spld.spec pharm_spec,--药品规格
        gpv.FACTORY_NAME pharm_faction,--厂商
        spld.pharm_amount amount,--数量
        spld.amount_unit units,--单位
        su.user_name user_name,--冲药人
        gb.update_time send_date,--冲药时间
        spl.batch_id,
        spl.batch_name,
        '[' || spl.bed_id || '床]' || spl.patient_name name,
        to_char(gb.update_time,'yyyy/mm/dd') senddate,0 isgroup
   from gm_barcode gb, st_pivas_label spl, st_pivas_label_detail spld, gm_pharm_view gpv, sm_user su
  where gb.label_id = spl.label_id
    and spl.group_index = spld.group_index
    and spld.pharm_id = gpv.PHARM_ID
    and gb.update_by = su.user_id
    and (gb.status != 1000603 and
        0 in
        (select gp.value from gm_parameters gp where gp.code = 1000000000))
     or (gb.status = 1000602 and
        1 in
        (select gp.value from gm_parameters gp where gp.code = 1000000000))
    and gb.update_time between ? and ? 
    {0} 
    {1}";
            }
        }

        /// <summary>
        /// 查询不成组的医嘱
        /// </summary>
        public static string SqlSendNoQueryLabel
        {
            get
            {
                return @"select sspv.*,null batch_id,null batch_name, '[' || sspv.bed_id || '床]' || sspv.patient_name name
               ,to_char(sspv.send_date,'yyyy/mm/dd') senddate,0 isgroup
  from st_send_pharm_view sspv
 where fn_is_print(sspv.GROUP_INDEX ) = 0
         and sspv.send_date between ? and ? 
         {0} ";
            }
        }

        /// <summary>
        /// 查询已冲药药品汇总
        /// </summary>
        public static string SqlSendAllPharmColloct
        {
            get
            {
                return @"      select sspv.pharm_id,
         sspv.pharm_name, --药品名称
         sspv.pharm_spec, --药品规格
         sspv.pharm_faction, --厂商
         sum(sspv.amount) amount, --数量
         sspv.units, --单位
         1 isgroup 
    from st_send_pharm_view sspv
   where fn_is_print(sspv.GROUP_INDEX )  = 1
        and sspv.send_date between ? and ? 
         {0} 
   group by sspv.pharm_id,
            sspv.pharm_name, --药品名称
            sspv.pharm_spec, --药品规格
            sspv.pharm_faction, --厂商
            sspv.units --单位
   union all
         select sspv.pharm_id,
         sspv.pharm_name, --药品名称
         sspv.pharm_spec, --药品规格
         sspv.pharm_faction, --厂商
         sum(sspv.amount) amount, --数量
         sspv.units, --单位
         0 isgroup
  from (select spl.group_index,
               null advice_id,
               null ORDER_NO,
               null ORDER_SUB_NO,
               null patient_id, --病人id
               spl.inhos_id, --病人住院id
               spl.patient_name, --姓名
               spl.bed_id, --床位号
               spl.illfield_id illfield_id, --病区id
               spl.illfield_name illfield_name, --病区名
               spl.office_id office_id, --科室id
               spl.office_name office_name, --科室名
               spld.pharm_id pharm_ID, --药品id
               spld.pharm_name pharm_name, --药品名称
               spld.spec pharm_spec, --药品规格
               gpv.FACTORY_NAME pharm_faction, --厂商
               spld.pharm_amount amount, --数量
               spld.amount_unit units, --单位
               su.user_name user_name, --冲药人
               gb.update_time send_date, --冲药时间
               spl.batch_id,
               spl.batch_name,
               '[' || spl.bed_id || '床]' || spl.patient_name name,
               to_char(gb.update_time, 'yyyy/mm/dd') senddate,
               0 isgroup
          from gm_barcode            gb,
               st_pivas_label        spl,
               st_pivas_label_detail spld,
               gm_pharm_view         gpv,
               sm_user               su
         where gb.label_id = spl.label_id
           and spl.group_index = spld.group_index
           and spld.pharm_id = gpv.PHARM_ID
           and gb.update_by = su.user_id
           and (gb.status != 1000603 and
               0 in (select gp.value
                        from gm_parameters gp
                       where gp.code = 1000000000))
            or (gb.status = 1000602 and
               1 in (select gp.value
                        from gm_parameters gp
                       where gp.code = 1000000000))
        and gb.update_time between ? and ? 
         {1} ) sspv
 group by sspv.pharm_id,
          sspv.pharm_name, --药品名称
          sspv.pharm_spec, --药品规格
          sspv.pharm_faction, --厂商
          sspv.units --单位";
            }
        }

        /// <summary>
        /// 查询成组药品汇总
        /// </summary>
        public static string SqlSendYesPharmColloct
        {
            get
            {
                return @"select sspv.pharm_id,
       sspv.pharm_name, --药品名称
       sspv.pharm_spec, --药品规格
       sspv.pharm_faction, --厂商
       sum(sspv.amount) amount, --数量
       sspv.units, --单位
       1 isgroup
  from (select spl.group_index,
               null advice_id,
               null ORDER_NO,
               null ORDER_SUB_NO,
               null patient_id, --病人id
               spl.inhos_id, --病人住院id
               spl.patient_name, --姓名
               spl.bed_id, --床位号
               spl.illfield_id illfield_id, --病区id
               spl.illfield_name illfield_name, --病区名
               spl.office_id office_id, --科室id
               spl.office_name office_name, --科室名
               spld.pharm_id pharm_ID, --药品id
               spld.pharm_name pharm_name, --药品名称
               spld.spec pharm_spec, --药品规格
               gpv.FACTORY_NAME pharm_faction, --厂商
               spld.pharm_amount amount, --数量
               spld.amount_unit units, --单位
               su.user_name user_name, --冲药人
               gb.update_time send_date, --冲药时间
               spl.batch_id,
               spl.batch_name,
               '[' || spl.bed_id || '床]' || spl.patient_name name,
               to_char(gb.update_time, 'yyyy/mm/dd') senddate,
               0 isgroup
          from gm_barcode            gb,
               st_pivas_label        spl,
               st_pivas_label_detail spld,
               gm_pharm_view         gpv,
               sm_user               su
         where gb.label_id = spl.label_id
           and spl.group_index = spld.group_index
           and spld.pharm_id = gpv.PHARM_ID
           and gb.update_by = su.user_id
           and (gb.status != 1000603 and
               0 in (select gp.value
                        from gm_parameters gp
                       where gp.code = 1000000000))
            or (gb.status = 1000602 and
               1 in (select gp.value
                        from gm_parameters gp
                       where gp.code = 1000000000))
        and gb.update_time between ? and ? 
          {0} 
          {1} ) sspv
 group by sspv.pharm_id,
          sspv.pharm_name, --药品名称
          sspv.pharm_spec, --药品规格
          sspv.pharm_faction, --厂商
          sspv.units --单位";
            }
        }

        /// <summary>
        /// 查询不成组的医嘱
        /// </summary>
        public static string SqlSendNoPharmColloct
        {
            get
            {
                return @" select sspv.pharm_id,
         sspv.pharm_name, --药品名称
         sspv.pharm_spec, --药品规格
         sspv.pharm_faction, --厂商
         sum(sspv.amount) amount, --数量
         sspv.units, --单位
         0 isgroup 
    from st_send_pharm_view sspv
   where fn_is_print(sspv.GROUP_INDEX )  = 0
        and sspv.send_date between ? and ? 
        {0} 
   group by sspv.pharm_id,
            sspv.pharm_name, --药品名称
            sspv.pharm_spec, --药品规格
            sspv.pharm_faction, --厂商
            sspv.units --单位";
            }
        }

        /// <summary>
        /// 查询药品
        /// </summary>
        public static string SqlSelectPharm
        {
            get
            {
                return @"select LPAD(sv.DRUG_CODE, 10, '0') ||
               LPAD(sv.DRUG_SPEC || sv.FIRM_ID, 30, '0') PHARM_ID,
       sv.drug_name pharm_name,
       sv.drug_spec pharm_spec,
       sv.FIRM_ID   pharm_factior
  from storage_view sv
 where sv.drug_name like {0}
    or sv.flag like {1}
";
            }
        }

        /// <summary>
        /// 查询瓶贴
        /// </summary>
        public static string SqlQueryLable
        {
            get
            {
                return @"  select spl.*,
         spld.pharm_id,
         spld.pharm_name,
         spld.spec,
         gpv.FACTORY_NAME PHARM_FACTION,
         spld.pharm_amount,
         spld.amount_unit,
         spld.pharm_dosage,
         spld.dosage_unit,
         rpad(spl.group_index, spl.rn + length(spl.group_index) - 1, ' ') new_group_index,
         spl.group_index || spl.rn new_group_index_no
    from (select t.*,
                 row_number() over(partition by t.group_index, t.batch_id order by t.batch_id) rn
            from (select  spl.label_id,
                         spl.group_index,
                         spl.illfield_id,
                         spl.illfield_name,
                         spl.batch_id,
                         spl.batch_name,
                         spl.bed_id,
                         spl.bed_name,
                         spl.inhos_id,
                         spl.PATIENT_NAME,
                         '[' || spl.bed_id || '床]' || spl.PATIENT_NAME NAME,
                         spl.exe_status isexe
                    from st_pivas_label spl
                   where spl.label_status in (1000301, 1000302, 1000305)
                     and spl.create_date between trunc(sysdate - 1) and
                         trunc(sysdate)
                     and fn_is_print(spl.group_index) = 0) t) spl,
         st_pivas_label_detail spld,
         gm_pharm_view gpv
   where spl.group_index = spld.group_index
     and spld.pharm_id = gpv.PHARM_ID
      {0}
      {1}";
            }
        }

        /// <summary>
        /// 查询药品汇总
        /// </summary>
        public static string SqlQueryPharmColloct
        {
            get
            {
                return @"select nog.PHARM_ID,nog.PHARM_NAME,nog.SPEC,nog.illfield_name,pv.FACTORY_NAME,sum(nog.ACCOUNT*nog.TIMES) total,nog.ACCOUNT_UNIT
                    from (select *
          from (select count(*) over(partition by ph.group_index) cn, ph.*
                  from (select hav.advice_id,
                               advice_name        pharm_name,
                               hav.gm_advice_id   pharm_id,
                               hav.spec,
                               hav.account_unit,
                               hav.group_index,
                               hav.inhos_id,
                               hpv.PATIENT_NAME,
                               hpv.illfield_id,
                               hpv.illfield_name,
                               hpv.office_id,
                               hpv.office_name,
                               hpv.bed_id         bed_code,
                               hpv.bed_name,
                               hav.usage_code,
                               hav.frequency_code,
                               hav.frequency_name,
                               hav.frequency_memo,
                               hpv.GENDER,
                               hav.patient_age    age,
                               hav.account,
                               gfv.times
                          from (select nhav.*,
                                       decode(nhav.PRE_START_FLAG,
                                              '1',
                                              nhav.PRE_START_TIME,
                                              nhav.LIST_DATE) start_date,
                                       decode(nhav.PRE_STOP_FLAG,
                                              '1',
                                              nhav.PRE_STOP_TIME,
                                              null) end_date
                                  from ht_advice_view nhav) hav,
                               gm_frequency_view gfv,
                               hm_patient_view hpv
                         where hav.FREQUENCY_CODE = gfv.FREQUENCY_ID
                           and hav.patient_id = hpv.patient_id
                           and hav.visit_id = hpv.visit_id
                           and ? between hav.start_date and
                               nvl(hav.end_date, ? )
                           and is_gen_label_date(?,
                                                 gfv.WEEK_FLAG,
                                                 hav.start_date,
                                                 gfv.days,
                                                 gfv.FREQUENCY_ID) = 1) ph)
         where cn = 1) nog,st_check ck,st_check_detail ckd,gm_pharm_view pv
                    where ck.check_id=ckd.check_id
                    and nog.GROUP_INDEX=ckd.group_index
                    and nog.PHARM_ID=pv.PHARM_ID
                    and ckd.detail_status='1'
                    and ckd.check_pivas_status=1000102
                    {0}/*病区*/
                    group by nog.pharm_id,
                    nog.pharm_name,
                   nog.spec,
                   pv.FACTORY_NAME,
                   nog.ACCOUNT_UNIT,
                    nog.illfield_name";
            }
        }

        /// <summary>
        /// 查询药品库存
        /// </summary>
        public static string SqlStorageQuery
        {
            get
            {
                return @"select sv.*,gpv.INHOS_PRICE price
                            from storage_View sv,gm_pharm_view gpv
                            where sv.PHARM_ID = gpv.PHARM_ID(+)
                            and sv.units = gpv.UNITS(+)
                            and (sv.drug_name like ? 
                            or sv.FLAG like ? )
                            and sv.drug_spec like ?
                            and sv.batch_no like ? 
                            and sv.firm_id like ?
                            {0}
                            ";

            }
        }

        /// <summary>
        /// 获得当天要冲的单组的药
        /// </summary>
        public static string SqlQueryTodayPharmSend
        {
            get
            {
                return @"select nog.*,ck.user_name,pv.FACTORY_NAME,
       '[' || nog.BED_NAME || ']' || nog.PATIENT_NAME PATIENT_INFO 
from st_pivas_no_group_view nog,st_check ck,st_check_detail ckd,GM_PHARM_VIEW PV
where ck.check_id=ckd.check_id
and nog.GROUP_INDEX=ckd.group_index
AND pv.PHARM_ID = nog.PHARM_ID
and ckd.detail_status='1'
and ckd.check_pivas_status=1000102 
{0}/*病区*/";

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
                return @"SELECT distinct sps.office_id,sps.office_name FROM sr_pivas_set sps where sps.status = '1' order by sps.office_name, sps.office_id";
            }
        }

        /// <summary>
        /// 获取医嘱
        /// </summary>
        public static string SqlSelectAdvice
        {
            get
            {
                return @"SELECT cav.*,
       fn_get_pwjj(CAV.GROUP_INDEX) IS_PWJJ,
       DECODE(CAV.STANDING_FLAG, '1', '长期', '0', '临时', '') LONG_TIME_NAME,
       length( cav.CHECK_PIVAS_BATCH_NO) / 2 label_count,
       length( cav.CHECK_PIVAS_BATCH_NO) / 2 * CAV.ACCOUNT PHARM_COUNT
  FROM Check_ADVICE_VIEW cav
 where cav.LIST_DATE between ? and ?
   and {0}   ";
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
   create_date,
   cancel_reason,
   long_time_status)
values
  (st_check_detail_seq.nextval, ?, ?, ?, ?, ?, ?, '1', 'W', ?, sysdate, ?, ?)
";
            }
        }

        /// <summary>
        /// 批量查询审核明细表中的未审医嘱
        /// </summary>
        public static string SqlCheckDetail
        {
            get
            {
                //                return @"SELECT scd.*
                //                          FROM st_check_detail scd
                //                         WHERE scd.detail_status = '1'
                //                           and scd.group_index In
                //                               (select cav.group_index
                //                                  from Check_ADVICE_VIEW cav
                //                                 where cav.LIST_DATE between ? and ?
                //                                   and check_pivas_status = 1000101
                //                                   and {0}";
                return @"                           
                           SELECT scd.*
                          FROM st_check_detail scd
                         WHERE scd.detail_status = '1'
                           and scd.group_index In
                               (select cav.group_index
                                  from Check_ADVICE_VIEW cav
                                 where cav.LIST_DATE between ? and ?
                                   and check_pivas_status = 1000101
                                   and cav.PHARM_STATUS = '1'
                                   and fn_get_pwjj(CAV.GROUP_INDEX) = '1'
                                   and {0}";
            }
        }
        /// <summary>
        /// 批量查询审核明细表中的已审医嘱
        /// </summary>
        public static string SqlYesCheckDetail
        {
            get
            {
                //                return @"SELECT scd.*
                //                          FROM st_check_detail scd
                //                         WHERE scd.detail_status = '1'
                //                           and scd.group_index In
                //                               (select cav.group_index
                //                                  from Check_ADVICE_VIEW cav
                //                                 where cav.LIST_DATE between ? and ?
                //                                   and check_pivas_status =1000102
                //                                   and {0}";
                return @"SELECT scd.*
                          FROM st_check_detail scd
                         WHERE scd.detail_status = '1'
                           and scd.group_index In
                               (select cav.group_index
                                  from Check_ADVICE_VIEW cav
                                 where cav.LIST_DATE between ? and ?
                                   and check_pivas_status =1000102
                                   and cav.PHARM_STATUS = '1'
                                   and fn_get_pwjj(CAV.GROUP_INDEX) = '1'
                                   and {0}";
            }
        }

        /// <summary>
        /// 查询需要批量插入的数据
        /// </summary>
        public static string SqlBatchData
        {
            get
            {
                //                return @"select distinct cav.group_index ,cav.CHECK_PIVAS_BATCH_NO
                //                           from Check_ADVICE_VIEW cav
                //                           where cav.LIST_DATE between ? and ?
                //                           and check_pivas_status = 1000101
                //                           and {0}";
                return @"select distinct cav.group_index ,cav.CHECK_PIVAS_BATCH_NO
                           from Check_ADVICE_VIEW cav
                           where cav.LIST_DATE between ? and ?
                           and check_pivas_status = 1000101
                           and cav.PHARM_STATUS = '1'
                           and fn_get_pwjj(CAV.GROUP_INDEX) = '1'
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
                           create_date,
                           LONG_TIME_STATUS)
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
                                 sysdate,
                                 cav.STANDING_FLAG
                            from (select distinct cav.group_index,
                                 cav.original_pivas_status,
                                 cav.original_pivas_batch_no,
                                 cav.check_pivas_batch_no,
                                 cav.STANDING_FLAG
                                                   from Check_ADVICE_VIEW cav
                                                  where cav.LIST_DATE between ? and ?
                                                    and check_pivas_status = 1000101
                                                    and {0}";
            }
        }

        /// <summary>
        /// 查询需要插入的审核明细
        /// </summary>
        public static string SqlSelectInsertCheckDetail
        {
            get
            {
                return @"select st_check_detail_seq.nextval,
                                 ?,
                                 cav.group_index,
                                 cav.original_pivas_status,
                                 ?,
                                 cav.original_pivas_batch_no,
                                 cav.check_pivas_batch_no,
                                 '1',
                                 'W',
                                 ?,
                                 sysdate,
                                 cav.STANDING_FLAG
                            from (select distinct cav.group_index,
                                 cav.original_pivas_status,
                                 cav.original_pivas_batch_no,
                                 cav.check_pivas_batch_no,
                                 cav.STANDING_FLAG
                                                   from Check_ADVICE_VIEW cav
                                                  where cav.LIST_DATE between ? and ?
                                                    and check_pivas_status = 1000101
                                                    and {0}";
            }
        }

        /// <summary>
        /// 插入审核明细
        /// </summary>
        public static string SqlInsertInsertCheckDetail
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
                           create_date,
                           LONG_TIME_STATUS)
                             values(
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?,
                                ?
                              )";
            }
        }

        /// <summary>
        /// 判断该医嘱审核后药品是否会库存不足
        /// </summary>
        public static string SqlQueryGroupIndexPharm
        {//by dh
            get
            {
                return @"select pharm.*,
       sv.FIRM_ID,
       nvl(sv.quantity, 0) quantity,
       nvl(sv.quantity, 0) - pharm.all_count diff_count
  from (select 
         apharm.pharm_id,
         apharm.pharm_name,
         apharm.spec,
         sum(apharm.pharm_amount) all_count,
         apharm.amount_unit,
         apharm.factory_name
         from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
                 spld.pharm_id,
                 spld.pharm_name,
                 spld.spec,
                 spld.pharm_amount,
                 spld.amount_unit,
                 spld.factory_name
               from (select GROUP_INDEX from VW_ON_JM
                union all
               select nspl.group_index
                 from st_pivas_label nspl
                where nspl.create_date between trunc(sysdate) and sysdate
                  and nspl.label_status in (1000301, 1000302, 1000305)
                  and nspl.exe_status = '0') spl,
               st_pivas_label_detail spld
         where spl.group_index = spld.group_index
                  union 
                   select hav.gm_advice_id pharm_id,
                          hav.advice_name  pharm_name,
                          hav.spec         spec,
                          hav.account      pharm_amount,
                          hav.account_unit amount_unit,
                          hav.FACTORY_NAME
                     from ht_advice_view hav
                    where hav.group_index = ?
                  ) apharm
          group by  apharm.pharm_id,
               apharm.pharm_name,
               apharm.spec,
                apharm.amount_unit,
                apharm.factory_name) pharm,
       storage_view sv
 where pharm.pharm_id = sv.PHARM_ID(+)
   and pharm.amount_unit = sv.units(+)
   and pharm.all_count > nvl(sv.quantity, 0)
   and pharm.pharm_id in (select hav.gm_advice_id from ht_advice_view hav where hav.group_index =  ?)";
//                return @"select pharm.*,
//       sv.FIRM_ID,
//       nvl(sv.quantity, 0) quantity,
//       nvl(sv.quantity, 0) - pharm.all_count diff_count
//  from (select 
//         apharm.pharm_id,
//         apharm.pharm_name,
//         apharm.spec,
//         sum(apharm.pharm_amount) all_count,
//         apharm.amount_unit,
//         apharm.factory_name
//         from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
//                 spld.pharm_id,
//                 spld.pharm_name,
//                 spld.spec,
//                 spld.pharm_amount,
//                 spld.amount_unit,
//                 spld.factory_name
//               from (select group_index
//                  from ST_NEW_JIN_PIVAS_LABEL_VIEW
//                union all
//                   select group_index
//                  from st_old_jin_pivas_label_view stpl
//                union all
//                select group_index
//                  from st_old_ming_pivas_label_view stpl
//                union all
//               select nspl.group_index
//                 from st_pivas_label nspl
//                where nspl.create_date between trunc(sysdate) and sysdate
//                  and nspl.label_status in (1000301, 1000302, 1000305)
//                  and nspl.exe_status = '0') spl,
//               st_pivas_label_detail spld
//         where spl.group_index = spld.group_index
//                  union 
//                   select hav.gm_advice_id pharm_id,
//                          hav.advice_name  pharm_name,
//                          hav.spec         spec,
//                          hav.account      pharm_amount,
//                          hav.account_unit amount_unit,
//                          hav.FACTORY_NAME
//                     from ht_advice_view hav
//                    where hav.group_index = ?
//                  ) apharm
//          group by  apharm.pharm_id,
//               apharm.pharm_name,
//               apharm.spec,
//                apharm.amount_unit,
//                apharm.factory_name) pharm,
//       storage_view sv
// where pharm.pharm_id = sv.PHARM_ID(+)
//   and pharm.amount_unit = sv.units(+)
//   and pharm.all_count > nvl(sv.quantity, 0)
//   and pharm.pharm_id in (select hav.gm_advice_id from ht_advice_view hav where hav.group_index =  ?)";
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
        /// 根据组号将审核明细表的该数据置为无效
        /// </summary>
        public static string SqlUpdateCheckDetailValidGroupIndex
        {
            get
            {
                return @"update st_check_detail scd
   set scd.detail_status = '0', scd.update_by = ?, scd.update_date = sysdate
 where scd.detail_status = '1'
   and scd.group_index = ?";
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
                                          '1',
                                          scd.database_flag,
                                          ?,
                                          sysdate,
                                          scd.cancel_reason
                            from (SELECT detail_id,
                                         scd.check_id,
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
                                   WHERE scd.detail_id = ? ) scd";
            }
        }

        /// <summary>
        /// 根据频率获取批次
        /// </summary>
        public static string SqlQueryFrequencytoBatch
        {
            get
            {
                return @"select spbs.batchs_name from SR_FREQUENCY_BATCH_SET spbs where spbs.frequency_name = ? and spbs.illfield_id = ?";
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
                         where scl.group_index in ({0})";
            }
        }

        /// <summary>
        /// 插入固定瓶贴
        /// </summary>
        public static string SqlInsertCommonLabel
        {
            get
            {
                //                return @"insert into st_common_label
                //  (st_common_label_id,
                //   database_flag,
                //   check_detail_id,
                //   pivas_pharm_type,
                //   pivas_pharm_type_name,
                //   label_detail,
                //   usage_id,
                //   usage_name,
                //   frequency_id,
                //   frequency_name,
                //   frequency_memo,
                //   times,
                //   inhos_id,
                //   pharm_id1,
                //   pharm_dosage1,
                //   pharm_id2,
                //   pharm_dosage2,
                //   create_by,
                //   create_date,
                //   update_by,
                //   update_date,
                //   pharm_seq,
                //   batch_id,
                //   batch_name,
                //   s_no,
                //   LONG_TIME_STATUS,
                //   FEE_COUNT,
                //   GROUP_INDEX)
                //  select st_common_label_seq.nextval common_label_id,
                //         lab.database_flag,
                //         lab.check_detail_id,
                //         lab.pivas_pharm_type,
                //         lab.pivas_pharm_type_name,
                //         lab.label_detail,
                //         lab.usage_id,
                //         lab.usage_name,
                //         lab.frequency_id,
                //         lab.frequency_name,
                //         lab.frequency_memo,
                //         lab.times,
                //         lab.inhos_id,
                //         lab.pharm_id1,
                //         lab.pharm_dosage1,
                //         lab.pharm_id2,
                //         lab.pharm_dosage2,
                //         lab.create_by,
                //         lab.create_date,
                //         lab.update_by,
                //         lab.update_date,
                //         lab.pharm_seq,
                //         sbs.batch_id,
                //         sbs.batch_name,
                //         get_s_no(lab.Check_Pivas_Batch_No, lab.Batch_num) s_no,
                //         lab.LONG_TIME_STATUS,
                //         decode(rownum,
                //                1,
                //                decode(fn_group_index_is_save(lab.group_index),
                //                       1,
                //                       fn_batch_count(lab.group_index),
                //                       1),
                //                decode(fn_group_index_is_save(lab.group_index), 1, 0, 1)) FEE_COUNT,
                //         lab.group_index GROUP_INDEX
                //    from (select slv.*,
                //                 ? create_by, -- 创建人参数
                //                 sysdate create_date,
                //                 null update_by,
                //                 null update_date,
                //                 null pharm_seq,
                //                 substr('-' || slv.Check_Pivas_Batch_No, rownum * 2, 1) Batch_num
                //            from (select *
                //                    from ST_LABEL_VIEW nslv
                //                   where nslv.group_index = ? /*医嘱参数*/
                //                  ) slv
                //          connect by rownum <= length(slv.Check_Pivas_Batch_No) / 2) lab,
                //         (select t.*, rownum batch_num
                //            from (select *
                //                    from SM_BATCH_SET
                //                   where status = '1'
                //                   order by batch_time) t) sbs
                //   where lab.Batch_num = sbs.batch_num
                //     and lab.group_index = ? -- 医嘱参数 
                //  -- 传多个组号是 因为存在只能把第一个组号的 1-2-3- 的批次信息转换成 1,2,3 
                //  -- 其他组号对应的批次不能转换 所有该sql只能 一个组号 一个组号的插入瓶贴基表";
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
   s_no,
   LONG_TIME_STATUS,
   FEE_COUNT,
   GROUP_INDEX)
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
         get_s_no(lab.Check_Pivas_Batch_No, lab.Batch_num) s_no,
         lab.LONG_TIME_STATUS,
               (case
                 when rownum = 1 and fn_group_index_is_save(group_index) = 1 then
                  fn_batch_count(group_index)
                 when rownum > 1 and fn_group_index_is_save(group_index) = 1 then
                  0
                 else
                  1
               end) FEE_COUNT,
         lab.group_index GROUP_INDEX
    from (select slv.*,
                 ? create_by, -- 创建人参数
                 sysdate create_date,
                 null update_by,
                 null update_date,
                 null pharm_seq,
                 substr('-' || slv.Check_Pivas_Batch_No, rownum * 2, 1) Batch_num
            from (select *
                    from ST_LABEL_VIEW nslv
                   where nslv.group_index = ? /*医嘱参数*/
                  ) slv
          connect by rownum <= length(slv.Check_Pivas_Batch_No) / 2) lab,
         sm_batch_set sbs
   where lab.Batch_num = sbs.batch_no
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
   pharm_common_name,
   FACTORY_NAME)
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
         hav.COMMON_NAME,
         gpv.FACTORY_NAME
    from ht_advice_view hav,gm_pharm_view gpv
    where hav.GROUP_INDEX = ?
      and hav.gm_advice_id = gpv.PHARM_ID(+)
      and hav.account_unit = gpv.UNITS(+)
      and ? not in (select spld.group_index from st_pivas_label_detail spld)
   ";
            }
        }

        /// <summary>
        /// 是否有未审核医嘱
        /// </summary>
        public static string SqlQueryNoCheckAdvice
        {
            get
            {
                return @"SELECT count(*) FROM Check_ADVICE_VIEW cav
where cav.CHECK_PIVAS_STATUS = 1000101";
            }
        }

        /// <summary>
        /// 查询出异常的瓶贴
        /// </summary>
        public static string SqlQueryExcpitionLabel
        {
            get
            {
                return @"SELECT GB.*,
       SPL.*,
       SPLD.*,
       GC.NAME LABEL_STATUS_NAME,
       GC.CODE LABEL_STATUS_CODE,
       SPL.BED_ID || SPL.PATIENT_NAME NAME
  FROM (SELECT *
          FROM GM_BARCODE NGB
         WHERE ((SYSDATE > (TRUNC(SYSDATE) + 13 / 24) AND
               NGB.GEN_DATE BETWEEN (TRUNC(SYSDATE) + 13 / 24) AND SYSDATE) OR
               (SYSDATE < (TRUNC(SYSDATE) + 13 / 24) AND
               NGB.GEN_DATE BETWEEN (TRUNC(SYSDATE - 1) + 13 / 24) AND
               SYSDATE))
           AND NGB.STATUS NOT IN (1000603, 1000602, 1000602)) GB,
       ST_PIVAS_LABEL SPL,
       ST_PIVAS_LABEL_DETAIL SPLD,
       GM_CODE GC
 WHERE GB.LABEL_ID = SPL.LABEL_ID
   AND SPL.GROUP_INDEX = SPLD.GROUP_INDEX
   AND GB.STATUS = GC.CODE
   AND (SPL.GROUP_INDEX NOT IN
       (SELECT HAV.GROUP_INDEX FROM HT_ADVICE_VIEW HAV) OR
       SPL.GROUP_INDEX NOT IN
       (SELECT SCD.GROUP_INDEX
           FROM ST_CHECK_DETAIL SCD
          WHERE SCD.CHECK_PIVAS_STATUS = 1000102
            AND SCD.DETAIL_STATUS = '1') OR
       FN_CHECK_ERROR_LABEL(SPL.LABEL_ID, SPL.PHARM_TIME) = 0)";
            }
        }

        /// <summary>
        /// 是否有未审核医嘱
        /// </summary>
        public static string SqlQueryStorage
        {
            get
            {
                return @"select pharm.*,
       sv.FIRM_ID,
       nvl(sv.quantity, 0) quantity,
       nvl(sv.quantity, 0) - pharm.all_count diff_count
  from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
         spld.pharm_id,
         spld.pharm_name,
         spld.spec,
         sum(spld.pharm_amount) all_count,
         spld.amount_unit
          from (select stpl.group_index
                  from st_new_jin_pivas_label_view stpl
                union all
                select sotpl.group_index
                  from st_old_jin_pivas_label_view sotpl
                union all
                select sotpl.group_index
                  from st_old_ming_pivas_label_view sotpl
                union all
                select nspl.group_index
                  from st_pivas_label nspl
                 where nspl.create_date between trunc(sysdate) and sysdate
                   and nspl.label_status in (1000301, 1000302, 1000305)
                   and nspl.exe_status = '0') spl,
               st_pivas_label_detail spld
         where spl.group_index = spld.group_index
         group by spld.pharm_id,
                  spld.pharm_name,
                  spld.spec,
                  spld.amount_unit) pharm,
       storage_view sv
 where pharm.pharm_id = sv.PHARM_ID(+)
   and pharm.amount_unit = sv.units(+)
   and pharm.all_count > nvl(sv.quantity, 0)";
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

        #region 扣费

        /// <summary>
        /// 获取扣费时间
        /// </summary>
        public static string SqlQueryFeeTime
        {
            get
            {
                return @"select gp.value from gm_parameters gp where gp.code = 1000000000";
            }
        }

        /// <summary>
        /// 获取退费时间
        /// </summary>
        public static string SqlQueryCancelFeeTimeLabelId
        {
            get
            {
                return @"select count(*) from gm_barcode gb,st_pivas_label spl,gm_code gc
where gb.label_id = spl.label_id
  and gb.status = gc.code
  and gb.label_id = ?
  and spl.exe_status = '1'
  and spl.label_status in (1000301,1000302,1000305)
  and gc.uc_code >= (select ngc.uc_code from gm_parameters gp,gm_code ngc
where ngc.code = gp.value
  and gp.code = 1000000000)";
            }
        }

        /// <summary>
        /// 获取退费时间
        /// </summary>
        public static string SqlQueryCancelFeeTime
        {
            get
            {
                return @"select count(*) from gm_barcode gb,st_pivas_label spl,gm_code gc
where gb.label_id = spl.label_id
  and gb.status = gc.code
  and gb.label_bar_id = ?
  and spl.exe_status = '1'
  and spl.label_status in (1000301,1000302,1000305)
  and gc.uc_code >= (select ngc.uc_code from gm_parameters gp,gm_code ngc
where ngc.code = gp.value
 and gp.code = '1000000000')";
            }
        }

        /// <summary>
        /// 根据组号获取单个医嘱
        /// </summary>
        public static string SqlQueryAdviceIdByGroupIndex
        {
            get
            {
                return @"select spld.his_advice_id ADVICE_ID,spld.pharm_name from st_pivas_label_detail spld where spld.group_index = ?";
            }
        }

        public static string SqlUpdateLabel
        {
            get
            {
                return @"update st_pivas_label spl
set spl.exe_status = '1',
    user_id = ?,
    pharm_send_date = sysdate,
    PHARM_SEND_USER_NAME = ?
where spl.label_id = ?";
            }
        }

        #endregion

        #region 退药申请
        /// <summary>
        /// 根据病区及床号获取病人医嘱
        /// </summary>
        public static string SqlQueryAdviceByIllfieldAndBedNO
        {
            get
            {
                return @"select l.*,
       d.*,
       GB.LABEL_BAR_ID,
       '[' || l.bed_id || '床' || ']' || l.patient_name || ' ' ||
       l.patient_id patient_info,
       l.illfield_id || LPAD(REPLACE(l.bed_id,'+','a'),4,0) || LPAD(L.PATIENT_ID,10,0) ILLFILED_BED_PATIENT_CODE
  from (select NGB.LABEL_ID, MIN(NGB.LABEL_BAR_ID) LABEL_BAR_ID
          from GM_BARCODE NGB
         GROUP BY NGB.LABEL_ID) GB,
       ST_PIVAS_LABEL l,
       st_pivas_label_detail d
 where GB.LABEL_ID = L.LABEL_ID
   and l.group_index = d.group_index
   and l.exe_status = '1'
   and l.LABEL_STATUS in (1000301, 1000305)
   and l.create_date between ? and ? {0} /*病区*/
 {1} /*病床*/
 {2}
 {3}
 order by l.patient_name, gb.label_bar_id";
            }
        }
        /// <summary>
        /// 根据条形码或者医嘱id获取病人医嘱
        /// </summary>
        public static string SqlQueryAdviceByBarCodeNOOrAdviceID
        {
            get
            {
                return @"";
            }
        }
        /// <summary>
        /// 插入退药申请表
        /// </summary>
        public static string SqlAddCancelApply
        {
            get
            {
                return @"insert into st_pivas_label_cancel_apply
                  (apply_id, label_id, cancel_type, cancel_user_id, cancel_user_name, cancel_dept_id, cancel_dept_name, cancel_time,CANCEL_REASON, create_by, create_date,label_bar_id,is_fee)
                values
                  (st_pivas_label_cancel_rcp_seq.nextval, ?, 1000402, ?, ?, ?, ?, sysdate,?, ?, sysdate,?,?)";
            }
        }
        /// <summary>
        /// 插入退药申请表,改为已退
        /// </summary>
        public static string SqlAddCancelApply2
        {
            get
            {
                return @"insert into st_pivas_label_cancel_apply
                  (apply_id, label_id,LABEL_STATUS, cancel_type, cancel_user_id, cancel_user_name, cancel_dept_id, cancel_dept_name, cancel_time,CANCEL_REASON, create_by, create_date,label_bar_id,is_fee)
                values
                  (st_pivas_label_cancel_rcp_seq.nextval, ?,1000302, 1000402, ?, ?, ?, ?, sysdate,?, ?, sysdate,?,?)";
            }
        }
        /// <summary>
        /// 删除瓶贴id对应的退药申请
        /// </summary>
        public static string SqlDelectCancelApply
        {
            get
            {
                return @"delete st_pivas_label_cancel_apply splca where splca.label_id = ?";
            }
        }
        /// <summary>
        /// 根据部门id获得部门名称
        /// </summary>
        public static string SqlQueryDeptNameByID
        {
            get
            {
                return @"select * from gm_dept_view gd
                    where gd.DEPT_ID=?";
            }
        }
        /// <summary>
        /// 根据瓶贴id修改瓶贴状态
        /// </summary>
        public static string SqlUpdateLabelStatusByID
        {
            get
            {
                return @"UPDATE ST_PIVAS_LABEL l
                    SET l.label_status = ?, l.update_by = ?, l.UPDATE_DATE = SYSDATE
                    WHERE l.label_id=?";
            }
        }
        /// <summary>
        /// 根据瓶贴id修改条形码状态
        /// </summary>
        public static string SqlUpdateBarCodeStatusByID
        {
            get
            {
                return @"UPDATE gm_barcode bar
                    SET bar.status =1000603, bar.update_by = ?, bar.update_time = SYSDATE
                    WHERE bar.label_id=?";
            }
        }

        /// <summary>
        /// 根据瓶贴号增加扫描记录
        /// </summary>
        public static string SqlAddSanning
        {
            get
            {
                return @"insert into st_scanning
  (scanning_id,
   scanning_type,
   scanning_date,
   scanning_by,
   scanning_name,
   barcode_id)
  select st_scanning_seq.nextval,
         ?,
         sysdate,
         ?,
         ?,
         gb.label_bar_id
  from gm_barcode gb where gb.label_id = ?";
            }
        }

        /// <summary>
        /// 根据时间和病区获取待处理的退药申请
        /// </summary>
        public static string SqlQueryApplyLabelByIllfield
        {
            get
            {
                return @"select l.*,
          d.*,
          p.*,
           l.illfield_id || LPAD(REPLACE(l.bed_id,'+','a'),4,0) || LPAD(L.PATIENT_ID,10,0) ILLFILED_BED_PATIENT_CODE,
          '[' || l.bed_id || '床' || ']' || l.patient_name patient_info,
       (case
         when l.fee_count > 1 then
           decode(fn_pharm_is_save(d.pharm_id),1,ceil(l.fee_count * d.pharm_dosage / gpv.dose_per_unit),d.pharm_amount)
         when l.fee_count = 1 then
           d.pharm_amount
         else
           0
       end) new_pharm_amount
     from ST_PIVAS_LABEL              l,
          st_pivas_label_detail       d,
          st_pivas_label_cancel_apply p,
          GM_PHARM_VIEW GPV
    where l.group_index = d.group_index
      and l.label_id = p.label_id
      and d.pharm_id = gpv.PHARM_ID
      and l.exe_status = '1'
      and l.LABEL_STATUS in (1000302)
      and p.cancel_rcp_id is null
      and l.create_date between ? and ? {0} /*病区*/
      order by l.patient_name,p.label_bar_id";
            }
        }
        /// <summary>
        /// 根据时间和病区获取待处理的退药申请
        /// </summary>
        public static string SqlNewQueryApplyLabelByIllfield
        {
            get
            {
                return @"select l.*,
          d.*,
          p.*,
          l.illfield_id || LPAD(REPLACE(l.bed_id,'+','a'),4,0) || LPAD(L.PATIENT_ID,10,0) ILLFILED_BED_PATIENT_CODE,
          '[' || l.bed_id || '床' || ']' || l.patient_name || ' ' || l.patient_id patient_info,
       (case
         when l.fee_count > 1 then
           decode(fn_pharm_is_save(d.pharm_id),1,ceil(l.fee_count * d.pharm_dosage / gpv.dose_per_unit),d.pharm_amount)
         when l.fee_count = 1 then
           d.pharm_amount
         else
           0
       end) new_pharm_amount
     from ST_PIVAS_LABEL              l,
          st_pivas_label_detail       d,
          st_pivas_label_cancel_apply p,
          GM_PHARM_VIEW GPV
    where l.group_index = d.group_index
      and l.label_id = p.label_id
      and d.pharm_id = gpv.PHARM_ID
      and l.exe_status = '1'
      and l.LABEL_STATUS in (1000302)
      and p.cancel_rcp_id is null
      and l.create_date between  ? and ?
       {0} /*病区*/
      order by l.patient_name,p.label_bar_id";
            }
        }
        /// <summary>
        /// 在申请退药表中修改退药单号
        /// </summary>
        public static string SqlUpdateApplyLabel
        {//a.label_status  = 1000305  by dh add
            get
            {
                return @"UPDATE ST_PIVAS_LABEL_CANCEL_APPLY A
                    SET a.label_status  = ?,
                        A.CANCEL_RCP_ID = ?,
                        A.UPDATE_BY     = ?,
                        A.UPDATE_DATE   = SYSDATE,
                        IS_FEE          = ?
                  WHERE A.LABEL_ID = ? and a.label_status=1000302";
            }
        }
        /// <summary>
        /// 往退药单表中插入退药详情
        /// </summary>
        public static string SqlAddCancelApplyRCP
        {
            get
            {
                return @"insert into st_pivas_label_cancel_rcp
                    (cancel_rcp_id, check_user_id, check_user_name, check_dept_id, check_dept_name, check_time, create_by)
                    values
                    (?, ?, ?, ?, ?, sysdate, ?)";
            }
        }
        /// <summary>
        /// 根据时间和病区查询出退药详情
        /// </summary>
        public static string SqlQueryCancelByIllfieldIDAndDate
        {
            get
            {
                return @"select l.*,l.create_date label_create_date,
       d.*,
       lca.*,
       lcr.*,
       gc.name,
       l.illfield_id || LPAD(REPLACE(l.bed_id,'+','a'),4,0) || LPAD(L.PATIENT_ID,10,0) ILLFILED_BED_PATIENT_CODE,
       '[' || l.bed_id || '床' || ']' || l.patient_name || ' ' || l.patient_id patient_info,
       (case
         when l.fee_count > 1 then
           decode(fn_pharm_is_save(d.pharm_id),1,ceil(l.fee_count * d.pharm_dosage / gpv.dose_per_unit),L.FEE_COUNT)
         when l.fee_count = 1 then
           d.pharm_amount
         else
           0
       end) new_pharm_amount
  from st_pivas_label              l,
       st_pivas_label_detail       d,
       st_pivas_label_cancel_apply lca,
       st_pivas_label_cancel_rcp   lcr,
       gm_code                     gc,
       GM_PHARM_VIEW GPV
 where lca.label_status = ?
   and l.group_index = d.group_index
   and d.pharm_id = gpv.PHARM_ID
   and l.label_id = lca.label_id
   and lca.cancel_rcp_id = lcr.cancel_rcp_id
   and lca.is_fee = ?
   and gc.code = lca.label_status {0} /*病区*/
   {1}
   order by l.patient_name,lca.label_bar_id";
            }
        }
        /// <summary>
        /// 根据时间和病区查询出退药汇总
        /// </summary>
        public static string SqlQueryCancelStatByIllfieldIDAndDate
        {//by dh l.label_status modify lca.label_status = ?
            get
            {
                return @"   select d.pharm_id,
          d.pharm_name,
          d.spec,
          pv.FACTORY_NAME,
       sum((case
         when l.fee_count > 1 then
           decode(fn_pharm_is_save(d.pharm_id),1,ceil(l.fee_count * d.pharm_dosage / pv.dose_per_unit),L.FEE_COUNT)
         when l.fee_count = 1 then
           d.pharm_amount
         else
           0
       end)) total,
          d.amount_unit
     from st_pivas_label              l,
          st_pivas_label_detail       d,
          st_pivas_label_cancel_apply lca,
          st_pivas_label_cancel_rcp   lcr,
          gm_pharm_view               pv
    where lca.label_status = ?
      and l.group_index = d.group_index
      and l.label_id = lca.label_id
      and lca.cancel_rcp_id = lcr.cancel_rcp_id
      and d.pharm_id = pv.PHARM_ID
      and lca.is_fee = ?
      {0} /*病区*/
      {1}
    group by d.pharm_id,
             d.pharm_name,
             d.spec,
             pv.FACTORY_NAME,
             d.amount_unit";
            }
        }
        /// <summary>
        /// 根据条形码查询瓶贴信息
        /// </summary>
        public static string SqlQueryLabelByBarCodeList
        {
            get
            {
                return @"select t.label_bar_id,
       t.status,
       l.*,
       ld.*,
       l.illfield_id || LPAD(l.bed_id, 4, 0) || LPAD(L.PATIENT_ID, 10, 0) ILLFILED_BED_PATIENT_CODE,
       '[' || l.bed_id || '床' || ']' || l.patient_name || ' ' ||
       l.patient_id patient_info,
       (case
         when l.fee_count > 1 then
          decode(fn_pharm_is_save(ld.pharm_id),
                 1,
                 ceil(l.fee_count * ld.pharm_dosage / gpv.dose_per_unit),
                 ld.pharm_amount)
         when l.fee_count = 1 then
          ld.pharm_amount
         else
          0
       end) new_pharm_amount
  from (select sub.label_id, sub.label_bar_id, sub.status
  from (select lead(t.label_bar_id, label_page_no - 1, t.label_bar_id) over(partition by t.label_id order by t.label_bar_id desc) parent_bar_id,
               label_bar_id
          from GM_BARCODE t
         where label_id in
               (select bc.label_id
                  from gm_barcode bc
                 where bc.label_bar_id in ({0}))) par,
       GM_BARCODE sub
 where par.label_bar_id in ({1})
   and par.parent_bar_id = sub.label_bar_id
) t,
       st_pivas_label l,
       st_pivas_label_detail ld,
       gm_pharm_view gpv
 where t.label_id = l.label_id
   and l.group_index = ld.group_index
   and ld.pharm_id = gpv.PHARM_ID
 order by l.patient_name, t.label_bar_id";
            }
        }


        /// <summary>
        /// 根据条形码查询瓶贴信息
        /// </summary>
        public static string SqlQueryLabelByBarCodeID
        {
            get
            {
                return @"select t.label_bar_id,
       t.status,
       l.*,
       ld.*,
       l.illfield_id || LPAD(l.bed_id, 4, 0) || LPAD(L.PATIENT_ID, 10, 0) ILLFILED_BED_PATIENT_CODE,
       '[' || l.bed_id || '床' || ']' || l.patient_name || ' ' ||
       l.patient_id patient_info,
       (case
         when l.fee_count > 1 then
          decode(fn_pharm_is_save(ld.pharm_id),
                 1,
                 ceil(l.fee_count * ld.pharm_dosage / gpv.dose_per_unit),
                 ld.pharm_amount)
         when l.fee_count = 1 then
          ld.pharm_amount
         else
          0
       end) new_pharm_amount
  from (select sub.label_id, sub.label_bar_id, sub.status
  from (select lead(t.label_bar_id, label_page_no - 1, t.label_bar_id) over(partition by t.label_id order by t.label_bar_id desc) parent_bar_id,
               label_bar_id
          from GM_BARCODE t
         where label_id in
               (select bc.label_id
                  from gm_barcode bc
                 where bc.label_bar_id in (?))) par,
       GM_BARCODE sub
 where par.label_bar_id in (?)
   and par.parent_bar_id = sub.label_bar_id
) t,
       st_pivas_label l,
       st_pivas_label_detail ld,
       gm_pharm_view gpv
 where t.label_id = l.label_id
   and l.group_index = ld.group_index
   and ld.pharm_id = gpv.PHARM_ID
 order by l.patient_name, t.label_bar_id
";
            }
        }
        #endregion

        #region 节约用药查询

        /// <summary>
        /// 查询过滤用药品信息
        /// </summary>
        public static string SqlSelectFilterPharm
        {
            get
            {
                return @" select distinct  sv.PHARM_ID,
       sv.drug_name PHARM_NAME,
       sv.drug_spec PHARM_SPEC,
       sv.firm_id   PHARM_FACTION,
       sv.FLAG,
       sv.units,
       decode(hifp.pharm_id,null,1,0) filter_pharm
  from storage_view sv,(select * from  ht_illfield_filter_pharm nhifp {0}) hifp
  where sv.PHARM_ID = hifp.pharm_id(+)
  order by sv.drug_name ";
            }
        }

        /// <summary>
        /// 查询节约用药信息
        /// </summary>
        public static string SqlSelectPharmEconomize
        {
            get
            {
                //                return @"select t.*,
                //       round(t.all_fee_pharm_amount - t.all_reality_pharm_amount,2) all_economize_pharm_amount ,floor(t.all_fee_pharm_amount - t.all_reality_pharm_amount) add_pharm_count
                //  from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
                //         gpv.DRUG_CODE,
                //         gpv.INHOS_PRICE,
                //         gpv.FLAG,
                //         spld.pharm_id,
                //         spld.pharm_name,
                //         spld.spec pharm_spec,
                //         gpv.FACTORY_NAME pharm_factory,
                //         round(sum(spld.pharm_dosage / gpv.DOSE_PER_UNIT),2) all_reality_pharm_amount,
                //         round(sum((case
                //               when spl.fee_count > 1 then
                //                decode(fn_pharm_is_save(spld.pharm_id),
                //                       1,
                //                       ceil(spl.fee_count * spld.pharm_dosage / gpv.dose_per_unit),
                //                       spld.pharm_amount)
                //               when spl.fee_count = 1 then
                //                spld.pharm_amount
                //               else
                //                0
                //             end)),2) all_fee_pharm_amount,
                //         spld.amount_unit pharm_unit
                //          from (select nspl.group_index, nspl.fee_count,nspl.illfield_id
                //                  from st_pivas_label nspl
                //                 where nspl.create_date between ? and ?
                //                   and nspl.label_status in (1000301, 1000302, 1000305)
                //                   and nspl.exe_status = '1') spl,
                //               st_pivas_label_detail spld,
                //               gm_pharm_view gpv
                //         where spl.group_index = spld.group_index
                //           and spld.pharm_id = gpv.PHARM_ID
                //           {0}
                //           {1}
                //         group by gpv.DRUG_CODE,
                //                  gpv.INHOS_PRICE,
                //                  gpv.flag,
                //                  spld.pharm_id,
                //                  spld.pharm_name,
                //                  spld.spec,
                //                  spld.amount_unit,
                //                  gpv.FACTORY_NAME) t";
                //                return @"select t.*,
                //       round(t.all_fee_pharm_amount - t.all_reality_pharm_amount,2) all_economize_pharm_amount ,floor(t.all_fee_pharm_amount - t.all_reality_pharm_amount) add_pharm_count,
                //       round(t.all_fee_pharm_amount - t.all_reality_pharm_amount, 2) * t.inhos_price all_money
                //  from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
                //         gpv.DRUG_CODE,
                //         gpv.INHOS_PRICE,
                //         gpv.FLAG,
                //         spld.pharm_id,
                //         spld.pharm_name,
                //         spld.spec pharm_spec,
                //         gpv.FACTORY_NAME pharm_factory,
                //         round(sum(spld.pharm_dosage * spl.fee_count / gpv.DOSE_PER_UNIT),2) all_reality_pharm_amount,
                //         round(sum((case
                //               when spl.fee_count > 1 then
                //                decode(fn_pharm_is_save(spld.pharm_id),
                //                       1,
                //                       ceil(spl.fee_count * spld.pharm_dosage / gpv.dose_per_unit),
                //                       spl.fee_count * spld.pharm_amount)
                //               when spl.fee_count = 1 then
                //                spld.pharm_amount
                //               else
                //                0
                //             end)),2) all_fee_pharm_amount,
                //         spld.amount_unit pharm_unit
                //          from (select nspl.group_index, nspl.fee_count,nspl.illfield_id,nspl.pharm_send_date
                //                  from st_pivas_label nspl
                //                 where nspl.label_status in (1000301, 1000302, 1000305)
                //                   and nspl.exe_status = '1') spl,
                //               st_pivas_label_detail spld,
                //               gm_pharm_view gpv
                //         where spl.group_index = spld.group_index
                //           and spld.pharm_id = gpv.PHARM_ID
                //           and spld.amount_unit = gpv.UNITS
                //           and is_economize(spld.pharm_id,spld.amount_unit,spl.pharm_send_date,spl.illfield_id) = 1
                //           and spl.pharm_send_date between ? and ?
                //           {0}
                //           {1}
                //         group by gpv.DRUG_CODE,
                //                  gpv.INHOS_PRICE,
                //                  gpv.flag,
                //                  spld.pharm_id,
                //                  spld.pharm_name,
                //                  spld.spec,
                //                  spld.amount_unit,
                //                  gpv.FACTORY_NAME) t";
//                return @"select tt.*,
//       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) all_economize_pharm_amount,
//       floor(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount) add_pharm_count,
//       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) *
//       tt.inhos_price all_money
//  from (select t.DRUG_CODE,
//                  t.INHOS_PRICE,
//                  t.flag,
//                  t.pharm_id,
//                  t.pharm_name,
//                  t.pharm_spec,
//                  t.pharm_unit,
//                  t.pharm_factory,
//               sum(t.reality_pharm_amount) all_reality_pharm_amount,
//               sum(t.fee_pharm_amount) all_fee_pharm_amount
//          from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
//                 gpv.DRUG_CODE,
//                 gpv.INHOS_PRICE,
//                 gpv.FLAG,
//                 spld.pharm_id,
//                 spld.pharm_name,
//                 spld.spec pharm_spec,
//                 gpv.FACTORY_NAME pharm_factory,
//                 ceil(round(sum(spld.pharm_dosage * spl.fee_count /
//                                gpv.DOSE_PER_UNIT),
//                            2)) reality_pharm_amount,
//                 round(sum((case
//                             when spl.fee_count > 1 then
//                              decode(fn_pharm_is_save(spld.pharm_id),
//                                     1,
//                                     ceil(spl.fee_count * spld.pharm_dosage /
//                                          gpv.dose_per_unit),
//                                     spl.fee_count * spld.pharm_amount)
//                             when spl.fee_count = 1 then
//                              spld.pharm_amount
//                             else
//                              0
//                           end)),
//                       2) fee_pharm_amount,
//                 spld.amount_unit pharm_unit,
//                 spl.create_date
//                  from (select nspl.group_index,
//                               nspl.fee_count,
//                               nspl.illfield_id,
//                               nspl.pharm_send_date,
//                               nspl.pharm_time,
//                               trunc(nspl.create_date) create_date
//                          from st_pivas_label nspl
//                         where nspl.label_status in
//                               (1000301, 1000302, 1000305)
//                           and nspl.exe_status = '1'
//                           and trunc(nspl.list_doctor_date) != trunc(nspl.pharm_time)
//                           and nspl.batch_id != 1000000004) spl,
//                       st_pivas_label_detail spld,
//                       gm_pharm_view gpv
//                 where spl.group_index = spld.group_index
//                   and spld.pharm_id = gpv.PHARM_ID
//                   and spld.amount_unit = gpv.UNITS
//                   and is_economize(spld.pharm_id,
//                                    spld.amount_unit,
//                                    spl.pharm_send_date,
//                                    spl.illfield_id) = 1
//                   and spl.pharm_time between ? and ? {0} {1}
//                 group by gpv.DRUG_CODE,
//                          gpv.INHOS_PRICE,
//                          gpv.flag,
//                          spld.pharm_id,
//                          spld.pharm_name,
//                          spld.spec,
//                          spld.amount_unit,
//                          gpv.FACTORY_NAME,
//                          spl.create_date) t
//         group by t.DRUG_CODE,
//                  t.INHOS_PRICE,
//                  t.flag,
//                  t.pharm_id,
//                  t.pharm_name,
//                  t.pharm_spec,
//                  t.pharm_unit,
//                  t.pharm_factory) tt";
                return @"select tt.*,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) all_economize_pharm_amount,
       floor(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount) add_pharm_count,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) *
       tt.inhos_price all_money
  from (select t.DRUG_CODE,
               t.INHOS_PRICE,
               t.flag,
               t.pharm_id,
               t.pharm_name,
               t.pharm_spec,
               t.pharm_unit,
               t.pharm_factory,
               sum(t.reality_pharm_amount) all_reality_pharm_amount,
               sum(t.fee_pharm_amount) all_fee_pharm_amount
          from (select DRUG_CODE,
                       INHOS_PRICE,
                       FLAG,
                       pharm_id,
                       pharm_name,
                       pharm_spec,
                       pharm_factory,
                       ceil(sum(reality_pharm_amount)) reality_pharm_amount,
                       sum(fee_pharm_amount) fee_pharm_amount,
                       pharm_unit,
                       create_date,
                       CHECK_BATCH_ID
                  from pt_pharm_send_view_new 
                  where  pharm_time between ? and ? {0} {1}
                 group by DRUG_CODE,
                          INHOS_PRICE,
                          flag,
                          pharm_id,
                          pharm_name,
                          pharm_spec,
                          pharm_unit,
                          pharm_factory,
                          create_date,
                          CHECK_BATCH_ID) t
         group by t.DRUG_CODE,
                  t.INHOS_PRICE,
                  t.flag,
                  t.pharm_id,
                  t.pharm_name,
                  t.pharm_spec,
                  t.pharm_unit,
                  t.pharm_factory) tt
";
            }
        }

        /// <summary>
        /// 查询节约用药信息
        /// </summary>
        public static string SqlSelectPharmEconomize2
        {
            get
            {
                return @"select tt.*,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) all_economize_pharm_amount,
       floor(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount) add_pharm_count,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) *
       tt.inhos_price all_money,LAST_ECONOMIZE_TIME
  from (select t.DRUG_CODE,
               t.INHOS_PRICE,
               t.flag,
               t.pharm_id,
               t.pharm_name,
               t.pharm_spec,
               t.pharm_unit,
               t.pharm_factory,LAST_ECONOMIZE_TIME,
               sum(t.reality_pharm_amount) all_reality_pharm_amount,
               sum(t.fee_pharm_amount) all_fee_pharm_amount
          from (select DRUG_CODE,
                       INHOS_PRICE,
                       FLAG,
                       pharm_id,
                       pharm_name,
                       pharm_spec,
                       pharm_factory,
                       ceil(sum(reality_pharm_amount)) reality_pharm_amount,
                       sum(fee_pharm_amount) fee_pharm_amount,
                       pharm_unit,
                       create_date,
                       CHECK_BATCH_ID,
                       FN_LAST_ECONOMIZE_TIME(PHARM_ID, PHARM_UNIT, ?) LAST_ECONOMIZE_TIME
                  from pt_pharm_send_view_JP 
                  where PHARM_SEND_DATE between ? and ? 
                   AND IS_ECONOMIZE(PHARM_ID, PHARM_UNIT, PHARM_SEND_DATE, ? ) = 1
                    AND (illfield_id = ? or ? = '0' )
                    {0}
                 group by DRUG_CODE,
                          INHOS_PRICE,
                          flag,
                          pharm_id,
                          pharm_name,
                          pharm_spec,
                          pharm_unit,
                          pharm_factory,
                          create_date,
                          CHECK_BATCH_ID,
                          FN_LAST_ECONOMIZE_TIME(PHARM_ID, PHARM_UNIT, ?)) t
         group by t.DRUG_CODE,
                  t.INHOS_PRICE,
                  t.flag,
                  t.pharm_id,
                  t.pharm_name,
                  t.pharm_spec,
                  t.pharm_unit,
                  t.pharm_factory,LAST_ECONOMIZE_TIME) tt
";
            }
        }

        /// <summary>
        /// 查询节约用药信息
        /// </summary>
        public static string SqlSelectPharmEconomizeInput
        {
            get
            {
                return @"select tt.*,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) all_economize_pharm_amount,
       floor(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount) add_pharm_count,
       round(tt.all_fee_pharm_amount - tt.all_reality_pharm_amount, 2) *
       tt.inhos_price all_money,LAST_ECONOMIZE_TIME
  from (select t.DRUG_CODE,
               t.INHOS_PRICE,
               t.flag,
               t.pharm_id,
               t.pharm_name,
               t.pharm_spec,
               t.pharm_unit,
               t.pharm_factory,LAST_ECONOMIZE_TIME,
               sum(t.reality_pharm_amount) all_reality_pharm_amount,
               sum(t.fee_pharm_amount) all_fee_pharm_amount
          from (select DRUG_CODE,
                       INHOS_PRICE,
                       FLAG,
                       pharm_id,
                       pharm_name,
                       pharm_spec,
                       pharm_factory,
                       ceil(sum(reality_pharm_amount)) reality_pharm_amount,
                       sum(fee_pharm_amount) fee_pharm_amount,
                       pharm_unit,
                       create_date,
                       CHECK_BATCH_ID,
                       FN_LAST_ECONOMIZE_TIME(PHARM_ID, PHARM_UNIT, ?) LAST_ECONOMIZE_TIME
                  from pt_pharm_send_view_JP 
                  where PHARM_SEND_DATE > nvl(FN_LAST_ECONOMIZE_TIME(PHARM_ID, PHARM_UNIT, ?), to_date('19000101','yyyymmdd'))
                     and PHARM_SEND_DATE <= ? 
                   AND IS_ECONOMIZE(PHARM_ID, PHARM_UNIT, PHARM_SEND_DATE, ? ) = 1
                    AND (illfield_id = ? or ? = '0' )
                    {0}
                 group by DRUG_CODE,
                          INHOS_PRICE,
                          flag,
                          pharm_id,
                          pharm_name,
                          pharm_spec,
                          pharm_unit,
                          pharm_factory,
                          create_date,
                          CHECK_BATCH_ID,
                          FN_LAST_ECONOMIZE_TIME(PHARM_ID, PHARM_UNIT, ?)) t
         group by t.DRUG_CODE,
                  t.INHOS_PRICE,
                  t.flag,
                  t.pharm_id,
                  t.pharm_name,
                  t.pharm_spec,
                  t.pharm_unit,
                  t.pharm_factory,LAST_ECONOMIZE_TIME) tt
";
            }
        }

        /// <summary>
        /// 药品入库记录详情查询
        /// </summary>
        public static string SqlSelectAddPharmDetail
        {
            get
            {
                return @"select spe.*,sped.*,gpv.*,sped.economize_count * gpv.INHOS_PRICE all_money  from st_pharm_economize spe,st_pharm_economize_detail sped,gm_pharm_view gpv
where spe.economize_id = sped.economize_id
  and sped.pharm_id = gpv.PHARM_ID
  and sped.pharm_units = gpv.UNITS
  {0}
  {1}
  and spe.economize_date between ? and ?";
            }
        }

        /// <summary>
        /// 药品入库记录详情查询
        /// </summary>
        public static string SqlSelectAddPharmDetail2
        {
            get
            {
                return @"select spe.*,sped.*,gpv.*,sped.economize_count * gpv.INHOS_PRICE all_money  from st_pharm_economize spe,st_pharm_economize_detail sped,gm_pharm_view gpv
where spe.economize_id = sped.economize_id
  and sped.pharm_id = gpv.PHARM_ID
  and sped.pharm_units = gpv.UNITS
  {0}
  and spe.economize_date between ? and ?
  and (spe.economize_illfield = ? or ?='0') ";
            }
        }

        /// <summary>
        /// 增加药品过滤
        /// </summary>
        public static string SqlAddFilterPharm
        {
            get
            {
                return @"insert into ht_illfield_filter_pharm
  (filter_pharm_id, pharm_id, illfield_id)
values
  (ht_illfield_filter_pharm_seq.nextval, ?, ?)";
            }
        }

        /// <summary>
        /// 减少药品过滤
        /// </summary>
        public static string SqlDeleteFilterPharm
        {
            get
            {
                return @"delete ht_illfield_filter_pharm hifp
 where hifp.illfield_id = ? and hifp.pharm_id = ?";
            }
        }

        /// <summary>
        /// 药品入库汇总查询
        /// </summary>
        public static string SqlSelectAddPharm2
        {
            get
            {
                return @"select gpv.PHARM_ID,
       gpv.PHARM_NAME,
       gpv.SPEC,
       gpv.FACTORY_NAME,
       sum(sped.economize_count) economize_count,
       gpv.UNITS,
       gpv.INHOS_PRICE,
       sum(sped.economize_count) * gpv.INHOS_PRICE all_money
  from st_pharm_economize        spe,
       st_pharm_economize_detail sped,
       gm_pharm_view             gpv
 where spe.economize_id = sped.economize_id
   and sped.pharm_id = gpv.PHARM_ID
   and sped.pharm_units = gpv.UNITS {0} 
   and spe.economize_date between ? and ?
  and (spe.economize_illfield = ? or ?='0') 
 group by gpv.PHARM_ID,
          gpv.PHARM_NAME,
          gpv.SPEC,
          gpv.FACTORY_NAME,
          gpv.UNITS,
          gpv.INHOS_PRICE";
            }
        }

        /// <summary>
        /// 药品入库汇总查询
        /// </summary>
        public static string SqlSelectAddPharm
        {
            get
            {
                return @"select gpv.PHARM_ID,
       gpv.PHARM_NAME,
       gpv.SPEC,
       gpv.FACTORY_NAME,
       sum(sped.economize_count) economize_count,
       gpv.UNITS,
       gpv.INHOS_PRICE,
       sum(sped.economize_count) * gpv.INHOS_PRICE all_money
  from st_pharm_economize        spe,
       st_pharm_economize_detail sped,
       gm_pharm_view             gpv
 where spe.economize_id = sped.economize_id
   and sped.pharm_id = gpv.PHARM_ID
   and sped.pharm_units = gpv.UNITS {0} {1}
   and spe.economize_date between ? and ?
 group by gpv.PHARM_ID,
          gpv.PHARM_NAME,
          gpv.SPEC,
          gpv.FACTORY_NAME,
          gpv.UNITS,
          gpv.INHOS_PRICE";
            }
        }


        public static string QueryPharmEconomizeId
        {
            get
            {
                return @"select st_pharm_economize_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入药品节约主表
        /// </summary>
        public static string InsertPharmEconomize
        {
            get
            {
                return @"insert into st_pharm_economize
  (economize_id, economize_by, economize_name, economize_date,economize_illfield)
values
  (?, ?, ?, sysdate,?)";
            }
        }

        /// <summary>
        /// 插入药品节约明细表
        /// </summary>
        public static string InsertPharmEconomizeDetail
        {
            get
            {
                return @"insert into st_pharm_economize_detail
    (economize_detail_id, pharm_id, economize_count, economize_id, pharm_units)
  values
    (st_pharm_economize_detail_seq.nextval, ?, ?, ?, ?)";
            }
        }

        /// <summary>
        /// 插入药品节约最后时间表
        /// </summary>
        public static string InsertPharmEconomizeLastDate
        {
            get
            {
                return @"insert into st_pharm_economize_last_date
    (last_date_id, pharm_id, last_date, pharm_units,illfield_id)
  values
    (st_pharm_economize_date_seq.nextval, ?, sysdate, ?,?)";
            }
        }

        /// <summary>
        /// 修改药品节约最后时间表
        /// </summary>
        public static string UpdatePharmEconomizeLastDate
        {
            get
            {
                return @"update st_pharm_economize_last_date speld
     set speld.last_date = sysdate
   where speld.pharm_id = ?
     and speld.pharm_units = ?
     and speld.illfield_id = ?";
            }
        }

        #endregion


        #region 查询未打印瓶贴

        /// <summary>
        /// 查询未打印瓶贴
        /// </summary>
        public static string SqlQueryNoPrintLabel
        {
            get
            {
//                return @"select count(*) from (select '0' isprint
//  from st_new_jin_pivas_label_view stpl
//union all
//select '0' isprint
//  from st_old_jin_pivas_label_view sotpl
//union all
//select '0' isprint
//  from st_old_ming_pivas_label_view sotpl
//union all
//select nspl.print_status isprint
//  from st_pivas_label nspl
// where nspl.create_date between trunc(sysdate) and sysdate
//   and nspl.label_status in (1000301, 1000302, 1000305)) t
//   where t.isprint = '0'
//      or t.isprint is null";
                return @"SELECT *
  FROM (SELECT ILLFIELD_NAME,
               BED_NAME,
               CHECK_BATCH_NAME BATCH_NAME,
               PATIENT_ID,
               '[' || BED_NAME || ']' || PATIENT_NAME PATIENT_NAME,
               GROUP_INDEX,
               LABEL_DETAIL,
               '今日' SRC
          FROM ST_NEW_JIN_PIVAS_LABEL_VIEW STPL
        UNION ALL
        SELECT ILLFIELD_NAME,
               BED_NAME,
               CHECK_BATCH_NAME BATCH_NAME,
               PATIENT_ID,
               '[' || BED_NAME || ']' || PATIENT_NAME PATIENT_NAME,
               GROUP_INDEX,
               LABEL_DETAIL,
               '隔日-今日' SRC
          FROM ST_OLD_JIN_PIVAS_LABEL_VIEW SOTPL
        UNION ALL
        SELECT ILLFIELD_NAME,
               BED_NAME,
               CHECK_BATCH_NAME BATCH_NAME,
               PATIENT_ID,
               '[' || BED_NAME || ']' || PATIENT_NAME PATIENT_NAME,
               GROUP_INDEX,
               LABEL_DETAIL,
               '隔日-明日' SRC
          FROM ST_OLD_MING_PIVAS_LABEL_VIEW SOTPL
        UNION ALL
        SELECT ILLFIELD_NAME,
               BED_NAME,
               CHECK_BATCH_NAME BATCH_NAME,
               PATIENT_ID,
               '[' || BED_NAME || ']' || PATIENT_NAME PATIENT_NAME,
               GROUP_INDEX,
               LABEL_DETAIL,
               '今日' SRC
          FROM ST_PIVAS_LABEL NSPL
         WHERE NSPL.CREATE_DATE BETWEEN TRUNC(SYSDATE) AND SYSDATE
           AND NSPL.LABEL_STATUS IN (1000301, 1000302, 1000305)
           AND (NSPL.PRINT_STATUS = '0' OR NSPL.PRINT_STATUS IS NULL))
 ORDER BY SRC, ILLFIELD_NAME, BED_NAME, GROUP_INDEX
";
            }
        }

        /// <summary>
        /// 获取当前库存
        /// </summary>
        public static string SqlStoragePharm
        {
            get
            {
                return @"select sv.*,
       sv.FIRM_ID,
       nvl(sv.quantity, 0) quantity,
       nvl(sv.quantity, 0) - nvl(pharm.all_count,0) diff_count
  from (select /*+index(spld IN_LABEL_DETAIL_GROUP_INDEX)*/
         spld.pharm_id,
         spld.pharm_name,
         spld.spec,
         sum(spld.pharm_amount) all_count,
         spld.amount_unit
          from (select group_index
                  from ST_NEW_JIN_PIVAS_LABEL_VIEW
                union all
                   select group_index
                  from st_old_jin_pivas_label_view stpl
                union all
                select group_index
                  from st_old_ming_pivas_label_view stpl
                union all
                select nspl.group_index
                  from st_pivas_label nspl
                 where nspl.create_date between trunc(sysdate) and sysdate
                   and nspl.label_status in (1000301, 1000302, 1000305)
                   and nspl.exe_status = '0') spl,
               st_pivas_label_detail spld
         where spl.group_index = spld.group_index
         group by spld.pharm_id,
                  spld.pharm_name,
                  spld.spec,
                  spld.amount_unit) pharm,
       storage_view sv
 where pharm.pharm_id(+) = sv.PHARM_ID
   and pharm.amount_unit(+) = sv.units";
            }
        }
        #endregion

        #region 日志写入

        public static string SqlWriteLog
        {
            get
            {
                return @"insert into gm_log
  (log_id, log_value, log_by, log_name, log_date, log_ip)
values
  (gm_log_seq.nextval, ?, ?,?, sysdate,?)";
            }
        }

        #endregion

        #region 扫描登录

        /// <summary>
        /// 检查用户是否正确
        /// </summary>
        public static string SqlLogin
        {
            get
            {
                return @"select * from SM_USER su where su.user_no = ? and su.user_password = ? and su.status = '1' and su.role = '1'";
            }
        }

        /// <summary>
        /// 检查该用户是否已经登录
        /// </summary>
        public static string SqlExamineUser
        {
            get
            {
                return @"select count(1)
  from dual
 where ? not in (select gls.user_id
  from gm_login_scanning gls
 where gls.out_date is null)";
            }
        }

        /// <summary>
        /// 检查操作台是否正确
        /// </summary>
        public static string SqlExamineOperation
        {
            get
            {
                return @"select count(1)
  from dual
 where ? not in (select gls.operation_no
  from gm_login_scanning gls
 where gls.out_date is null)";
            }
        }

        /// <summary>
        /// 插入扫描登录表
        /// </summary>
        public static string SqlInsertLoginScanning
        {
            get
            {
                return @"insert into gm_login_scanning
  (login_scanning_id, user_id, user_name, operation_no, login_date, out_date)
values
  (gm_login_scanning_seq.nextval, ?, ?, ?, sysdate, null)";
            }
        }

        /// <summary>
        /// 修改扫描奥登录表
        /// </summary>
        public static string SqlOuntLoginScanning
        {
            get
            {
                return @"  
update gm_login_scanning gls
set gls.out_date = sysdate
where gls.user_id = ?
  and gls.operation_no = ?";
            }
        }

        /// <summary>
        /// 查询登录情况
        /// </summary>
        public static string SqlSelectLogin
        {
            get
            {
                return @"select gls.*,su.* from gm_login_scanning gls,sm_user su where gls.out_date is null and gls.user_id = su.user_id and gls.operation_no = ?";
            }
        }

        #endregion



    }
}

