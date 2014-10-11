using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 瓶贴sql语句静态类
    /// </summary>
    public static class SqlTools
    {

        /// <summary>
        /// 获取某天的摆药单汇总
        /// </summary>
        public static string SqlQueryArrangeCollect
        {
            get
            {
                return @"select t.all_ill || '{' || sum(cnt) over() || '}' || '{' || decode(avg(print_status) over(), 1, '全部已打印', 0, '全部未打印', null, '无可打印瓶贴', '部分已打印') || '}' all_ill,
       t.illfield_id,
       t.illfield_name || '{' || sum(cnt) over(partition by t.illfield_id) || '}' || '{' || decode(avg(print_status) over(partition by t.illfield_id), 1, '全部已打印', 0, '全部未打印', null, '无可打印瓶贴', '部分已打印') || '}' illfield_name,
       t.illfield_name illfield,
       t.arr_type,
       t.arrange_id,
       t.cnt,
       decode(t.print_status,
              1,
              '全部已打印',
              0,
              '全部未打印',
              null,
              '无可打印瓶贴',
              '部分已打印') PRINT_STATUE
  from (select '全院' all_ill,
               spa.illfield_name,
               spa.illfield_id,
               spa.arr_type,
               spa.arrange_id,
               count(spl.label_id) cnt,
               avg(print_status) print_status
          from st_pivas_arrange spa,
               (select *
                  from st_pivas_label nspl
                 where nspl.label_status in (1000301, 1000302)) spl
         where spa.arrange_id = spl.arrange_id(+)
        and to_char(spa.arr_date,'yyyy-mm-dd') = to_char(?,'yyyy-mm-dd')
         group by spa.illfield_id,
                  spa.illfield_name,
                  spa.arr_type,
                  spa.arrange_id) t";
            }
        }

        /// <summary>
        /// 查询所有病房批次的瓶贴汇总
        /// </summary>
        public static string SqlQueryAllIllfieldBacthLabelCollect
        {
            get
            {
                return @"select ob.office_id,
       ob.office_name,
       ob.batch_id,
       ob.batch_name,
       sum(decode(pivas_pharm_type, 1000201, 1, 0)) PTY,
       sum(decode(pivas_pharm_type, 1000202, 1, 0)) JSY,
       sum(decode(pivas_pharm_type, 1000203, 1, 0)) DMY,
       sum(decode(pivas_pharm_type, 1000204, 1, 0)) GCY,
       sum(decode(pivas_pharm_type, 1000205, 1, 0)) KSS,
       sum(decode(spl.pivas_pharm_type, null, 0, 1)) subtotal
  from ({0}) spl,
       (select distinct sps.office_id,
                        sps.office_name,
                        sbs.batch_id,
                        sbs.batch_name
          from sr_pivas_set sps, sm_batch_set sbs
         where sps.status = '1'
           and sbs.status = '1') ob
 where ob.office_id = spl.illfield_id(+)
   and ob.batch_id = spl.batch_id(+)
 group by ob.office_id, ob.office_name, ob.batch_id, ob.batch_name
 order by ob.office_name";
            }
        }

        /// <summary>
        /// 查询药品汇总信息
        /// </summary>
        public static string SqlQueryPharmCollect
        {
            get
            {
                return @"select spld.pharm_id,spld.pharm_name,spld.pharm_common_name, sum(spld.pharm_amount) all_pharm_amount, gpv.units amount_unit,gpv.FACTORY_NAME,spld.spec
from  ({0}) spl,st_pivas_label_detail spld,gm_pharm_view gpv
where spl.group_index = spld.group_index
  and spld.pharm_id = gpv.PHARM_ID
group by spld.pharm_id,spld.pharm_name,spld.pharm_common_name,spld.spec,gpv.units,gpv.FACTORY_NAME";
            }
        }

        /// <summary>
        /// 查询瓶贴详情根据摆药单id
        /// </summary>
        public static string SqlQueryLabelDetailByArrangeId
        {
            get
            {
                return @" select spl.* 
 from st_pivas_arrange spa,st_pivas_label spl
 where spa.arrange_id = spl.arrange_id
 and spl.LABEL_STATUS in (1000301,1000302,1000305)
 and {0}
 and {1} 
 and {2}
 and {3} 
 {4}";
            }
        }

        /// <summary>
        /// 查询瓶贴详情根据摆药单id
        /// </summary>
        public static string SqlQueryLabelDetailInfoByArrangeId
        {
            get
            {
                return @"select spl.label_id LABEL_ID,
       spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
/*       SPL.INHOS_ID INHOS_ID,*/
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       spl.list_doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
              case
         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
          decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
         else
          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
       end DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       decode(spl.long_time_status,'0','[临]','1','[长]','')  LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_arrange spa,
       st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       st_check_detail scd,
       st_check sc,
       HM_PATIENT_VIEW HPV
 where spa.arrange_id = spl.arrange_id
   and spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index
   and scd.check_pivas_status = 1000102
   and scd.detail_status = '1'
   and scd.check_id = sc.check_id
   AND SPL.INHOS_ID = HPV.inhos_id
 and spl.LABEL_STATUS in (1000301,1000302,1000305)
 and {0}
 and {1} 
 and {2}
 and {3} 
 {4}";
            }
        }

        /// <summary>
        /// 查询瓶贴汇总信息根据摆药单id
        /// </summary>
        public static string SqlQueryLabelCollectByArrangeId
        {
            get
            {
                return @"
select spa.illfield_id,
       spa.illfield_name,
       spl.batch_id,
       spl.batch_name,
       sum(decode(pivas_pharm_type, 1000201, 1, 0)) PTY,
       sum(decode(pivas_pharm_type, 1000202, 1, 0)) JSY,
       sum(decode(pivas_pharm_type, 1000203, 1, 0)) DMY,
       sum(decode(pivas_pharm_type, 1000204, 1, 0)) GCY,
       sum(decode(pivas_pharm_type, 1000205, 1, 0)) KSS,
       count(*) subtotal
  from st_pivas_arrange spa, st_pivas_label spl
 where spa.arrange_id = spl.arrange_id
   and spl.LABEL_STATUS in (1000301, 1000302, 1000305)
   and {0}
   and {1}
   and {2}
   and {3}
 group by spa.illfield_id, spa.illfield_name, spl.batch_id, spl.batch_name
";
            }
        }

        /// <summary>
        /// 查询所有的药品类型
        /// </summary>
        public static string SqlQueryAllPharmType
        {
            get
            {
                return @"select * from gm_code where code_type = 'PIVAS_PHARM_TYPE'";
            }
        }

        /// <summary>
        /// 查询所有的批次信息
        /// </summary>
        public static string SqlQueryAllBacth
        {
            get
            {
                return @"select * from sm_batch_set sbs where sbs.status = '1' ORDER BY SBS.BATCH_TIME";
            }
        }


        /// <summary>
        ///查询每次生成瓶贴的开始于结束时间
        /// </summary>
        public static string SqlQueryListTime
        {
            get
            {
                return @"select start_time,over_time from sm_time_set where time_id = ? and status = '1'";
            }
        }

        /// <summary>
        /// 查询病区以及该病区下生成的摆药单
        /// </summary>
        public static string SqlQueryIffield
        {
            get
            {
                //                return @" select sps.office_id,
                //                 sps.office_name,
                //                 sum(decode(spa.arr_type, '1', spa.arrange_id, '')) CREATE_ARRANGE_1,
                //                 sum(decode(spa.arr_type, '2', spa.arrange_id, '')) CREATE_ARRANGE_2,
                //                 sum(decode(spa.arr_type, '3', spa.arrange_id, '')) CREATE_ARRANGE_3,
                //                 sum(decode(spa.arr_type, '4', spa.arrange_id, '')) CREATE_ARRANGE_4
                //   from (select distinct nsps.office_id,nsps.office_name from sr_pivas_set nsps) sps,
                //        (select *
                //           from st_pivas_arrange
                //          where to_char(arr_date, 'yyyy-mm-dd') =
                //                to_char(sysdate, 'yyyy-mm-dd')) spa
                //  where sps.office_id = spa.illfield_id(+)
                //  group by sps.office_id,sps.office_name";
                return @"select distinct nsps.office_id,nsps.office_name from sr_pivas_set nsps";
            }
        }

        /// <summary>
        /// 删除原临时瓶贴表中该用户的数据
        /// </summary>
        public static string SqlDeleteTempLabel
        {
            get
            {
                return @"delete st_temp_pivas_label ";
            }
        }

        /// <summary>
        /// 插入瓶贴信息到临时瓶贴表
        /// </summary>
        public static string SqlInsertTempLabel
        {
            get
            {
                return @"insert into st_temp_pivas_label
  (create_id,
   temp_label_no,
   group_index,
   database_flag,
   pivas_pharm_type,
   pivas_pharm_type_name,
   pharm_time,
   batch_id,
   batch_name,
   s_no,
   inhos_id,
   patient_name,
   illfield_id,
   illfield_name,
   office_id,
   office_name,
   bed_id,
   bed_name,
   usage_id,
   usage_name,
   frequency_id,
   frequency_name,
   frequency_memo,
   times,
   gender,
   age,
   label_detail,
   pharm_id1,
   pharm_dosage1,
   pharm_id2,
   pharm_dosage2,
   create_by,
   create_date,
   update_by,
   update_date,
   pharm_seq,
   create_user_id,
   create_user_name)
  select st_temp_pivas_label_seq.nextval,
         st_pivas_label_seq.nextval,
         group_index,
         database_flag,
         pivas_pharm_type,
         pivas_pharm_type_name,
         pharm_time,
         batch_id,
         batch_name,
         s_no,
         inhos_id,
         patient_name,
         illfield_id,
         illfield_name,
         office_id,
         office_name,
         bed_code,
         bed_name,
         usage_id,
         usage_name,
         frequency_id,
         frequency_name,
         frequency_memo,
         times,
         gender,
         age,
         label_detail,
         pharm_id1,
         pharm_dosage1,
         pharm_id2,
         pharm_dosage2,
         ? creater_by ,--用户id,
         creater_date,
         update_by,
         update_date,
         pharm_seq,
         ? creater_user_id, --用户id,
         creater_user_name
    from st_temp_pivas_label_view stplv--该视图取出所有现在能生成的瓶贴
    where fn_is_print(stplv.group_index) = '1'
    {0} --病区赛选";
            }
        }

        /// <summary>
        /// 查询临时瓶贴详情信息
        /// </summary>
        public static string SqlQueryTempLabelDetail
        {
            get
            {
                return @"select * 
from st_temp_pivas_label stpl";
            }
        }

        /// <summary>
        /// 查询临时瓶贴汇总信息
        /// </summary>
        public static string SqlQueryTempLabelCollect
        {
            get
            {
                return @"select stpl.illfield_id,
       stpl.illfield_name,
       stpl.batch_id,
       stpl.batch_name,
       sum(decode(pivas_pharm_type, 1000201, 1, 0)) PTY,
       sum(decode(pivas_pharm_type, 1000202, 1, 0)) JSY,
       sum(decode(pivas_pharm_type, 1000203, 1, 0)) DMY,
       sum(decode(pivas_pharm_type, 1000204, 1, 0)) GCY,
       sum(decode(pivas_pharm_type, 1000205, 1, 0)) KSS,
       count(*) subtotal
  from st_temp_pivas_label stpl
  group by stpl.illfield_id,
          stpl.illfield_name,
          stpl.batch_id,
          stpl.batch_name
";
            }
        }

        /// <summary>
        /// 查询到瓶贴的seq
        /// </summary>
        public static string SqlQueryArrangeSeq
        {
            get
            {
                return @"select st_pivas_arrange_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入摆药单
        /// </summary>
        public static string SqlInsertArrange
        {
            get
            {
                //                return @"insert into st_pivas_arrange
                //  (arrange_id, user_id, illfield_id, illfield_name, arr_type, arr_date, create_by, create_date, update_by, update_date)
                //select ?, ?/*生成人*/, ?, ?, sts.rowno /*第几次摆药*/, sysdate, ?/*创建人*/, sysdate, null, null
                //from (select nsts.*,rownum rowno from sm_time_set nsts where nsts.type = '1' and nsts.status = '1' order by nsts.start_time asc) sts
                //where sts.time_id = ?";
                return @"insert into st_pivas_arrange
  (arrange_id, user_id, illfield_id, illfield_name, arr_date, create_by, create_date, update_by, update_date)
  values( ?, ?/*生成人*/, ?, ?, sysdate, ?/*创建人*/, sysdate, null, null)";
            }
        }

        /// <summary>
        /// 插入瓶贴
        /// </summary>
        public static string SqlInsertLabel
        {
            get
            {
                return @"insert into st_pivas_label
  (label_id, label_no, group_index, database_flag, arrange_id, pivas_pharm_type, pivas_pharm_type_name, pharm_time, batch_id, batch_name, s_no, inhos_id, patient_name, illfield_id, illfield_name, office_id, office_name, bed_id, bed_name, usage_id, usage_name, frequency_id, frequency_name, frequency_memo, times, gender, age, label_detail, exe_status, label_status, pharm_id1, pharm_dosage1, pharm_id2, pharm_dosage2, create_by, create_date, update_by, update_date, pharm_seq, print_status )
select stpl.temp_label_no
       ,to_char(sysdate,'yyyymmdd')||'0000'||to_char(stpl.temp_label_no)
       ,stpl.group_index
       ,stpl.database_flag
       ,? --摆药单id  需修改
       ,stpl.pivas_pharm_type
       ,stpl.pivas_pharm_type_name
       ,stpl.pharm_time
       ,stpl.batch_id
       ,stpl.batch_name
       ,stpl.s_no
       ,stpl.inhos_id
       ,stpl.patient_name
       ,stpl.illfield_id
       ,stpl.illfield_name
       ,stpl.office_id
       ,stpl.office_name
       ,stpl.bed_id
       ,stpl.bed_name
       ,stpl.usage_id
       ,stpl.usage_name
       ,stpl.frequency_id
       ,stpl.frequency_name
       ,stpl.frequency_memo
       ,stpl.times
       ,stpl.gender
       ,stpl.age
       ,stpl.label_detail
       ,'0'--冲药说明 未冲
       ,1000301 --瓶贴状态 正常
       ,stpl.pharm_id1
       ,stpl.pharm_dosage1
       ,stpl.pharm_id2
       ,stpl.pharm_dosage2
       ,? create_id  --创建者 需修改
       ,sysdate create_date
       ,null update_id
       ,null update_name
       ,stpl.pharm_seq
       ,'0' --打印状态 未打印
from st_temp_pivas_label stpl
where stpl.illfield_id = ?";
            }
        }


        /// <summary>
        /// 查询刚生成的瓶贴
        /// </summary>
        public static string SqlQueryGenLabel
        {
            get
            {
                return @"select spa.illfield_id,spa.illfield_name,spl.batch_name,spl.patient_name
       ,decode(spl.group_index,null,null,'组' || spl.group_index || '[' || spl.pivas_pharm_type_name || ']:' || spl.label_no) group_index
       ,spld.pharm_name,spld.SPEC,spld.pharm_amount,spld.Amount_Unit,spld.pharm_dosage || spld.dosage_unit dosage
from st_pivas_arrange spa,st_pivas_label spl,st_pivas_label_detail spld
where spa.arrange_id = spl.arrange_id(+)
and spl.group_index = spld.group_index(+)
{0}";
            }
        }

        /// <summary>
        /// 获取条形码表seq
        /// </summary>
        public static string SqlQueryBarcodeSeq
        {
            get
            {
                return @"select GM_barcode_SEQ.NEXTVAL from dual ";
            }
        }

        /// <summary>
        /// 插入瓶贴条形码
        /// </summary>
        public static string SqlInsertLabelBarcode
        {
            get
            {
                return @"insert into gm_barcode
  (label_bar_id,
   label_page_no,
   label_all_page_no,
   gen_time,
   gen_date,
   GEN_BY,
   GEN_NAME,
   status,
   create_by,
   create_time,
   update_by,
   update_time,
   label_id)
select ?,
       ?,
       ?,
       to_char(sysdate,'yyyy/mm/dd'),
        sysdate,
       ?,
       ?,
       1000501,
       ?,
       sysdate,
       null,
       null,
       spl.label_id
from st_pivas_label spl
where spl.label_id = ?";
            }
        }

        /// <summary>
        /// 根据条形码id 差条形码表
        /// </summary>
        public static string SqlQueryBarCode
        {
            get
            {
                return @"select * from gm_barcode gb where gb.label_bar_id = ?";
            }
        }

        /// <summary>
        /// 修改瓶贴打印状态
        /// </summary>
        public static string SqlUpdateLabelPrintStatus
        {
            get
            {
                return @"update st_pivas_label spl
   set spl.print_status = '1',
       spl.last_print_date = ?
 where spl.label_id = ?";
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
                return @"select * from SM_BATCH_SET SBS WHERE SBS.STATUS = '1' ORDER BY SBS.BATCH_TIME";
            }
        }

        /// <summary>
        /// 获取打印瓶贴列表
        /// </summary>
        public static string SqlQueryPrintLableList
        {
            get
            {
                return @"select gb.label_bar_id,
       spl.patient_id,
       spl.illfield_name illfield_name,
       spl.batch_name batch_name,
       spl.bed_id bed_id,
       lpad(REPLACE(spl.bed_id,'+','a'),4,'0') bed_no,
       spl.bed_name bed_name,
       spl.patient_name patient_name,
       spl.group_index group_index,
       spl.pivas_pharm_type_name pharm_type_name,
       spl.pharm_time,
       '第' || gb.label_page_no || '/' || gb.label_all_page_no || '页' page_no,
       gb.gen_date gen_date,
       gb.status status,
       gc.name label_type,
       gb.create_time,
       fn_is_group(spl.group_index) is_group,
       sts.scanning_name scnning_name,
       sts.scanning_date scnning_date,
       gb.gen_name
  from gm_barcode gb, st_pivas_label spl, gm_code gc,(select * from st_scanning nsts where nsts.scanning_type = ?) sts
 where gb.label_id = spl.label_id
   and gb.status = gc.code
   and gb.label_bar_id = sts.barcode_id(+)
   and spl.LONG_TIME_STATUS = ?
   {0}
   {1}
 order by spl.illfield_name asc,
          spl.batch_name    asc,
          spl.bed_id        asc,
          spl.group_index   asc,
          gb.label_page_no  asc";
            }
        }

        /// <summary>
        /// 根据条形码id返回瓶贴信息
        /// </summary>
        public static string SqlQueryBarCodeLable
        {
            get
            {
                return @"select spl.label_id LABEL_ID,
       spl.illfield_id illfield_id,
       spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
/*       SPL.INHOS_ID INHOS_ID,*/
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       spl.list_doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_ID BATCH_ID,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
              case
         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
          decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
         else
          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
       end DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       gb.*,
       decode(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       (select * from st_check_detail nscd where nscd.check_pivas_status = 1000102 and nscd.detail_status = '1') scd,
       st_check sc,
       gm_barcode gb,
       HM_PATIENT_VIEW HPV
 where  spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index(+)
   and scd.check_id = sc.check_id(+)
   and gb.label_bar_id = ?
   and gb.label_id = spl.label_id
   AND SPL.INHOS_ID = HPV.inhos_id
  order by  spld.his_advice_id  asc";
            }
        }

        /// <summary>
        /// 修改条形码状态
        /// </summary>
        public static string SqlUpdateBarCodeStatus
        {
            get
            {
                return @"update gm_barcode gb
   set gb.status = ?,
       gb.update_by = ?,
       gb.update_time = ?
 where gb.label_bar_id = ?";
            }
        }

        /// <summary>
        /// 修改条形码状态
        /// </summary>
        public static string SqlUpdateBarCodeScanning
        {
            get
            {
//                return @"update gm_barcode gb
//   set gb.scnning_date = sysdate,
//       gb.scnning_by = ?,
//       gb.scnning_name = ?
// where gb.label_bar_id = ?";
                return @"insert into st_scanning
  (scanning_id, scanning_type, scanning_date, scanning_by, scanning_name, barcode_id)
values
  (st_scanning_seq.nextval, ?, ?, ?, ?, ?)";
            }
        }

        /// <summary>
        /// 根据瓶贴瓶贴id 修改条形码状态
        /// </summary>
        public static string SqlUpdateBarCodeStatusByLabelId
        {
            get
            {
                return @"update gm_barcode gb
   set gb.status = ?
 where gb.label_id = ?";
            }
        }

        /// <summary>
        /// 复制条形码信息
        /// </summary>
        public static string SqlCopeBarCode
        {
            get
            {
                return @"insert into gm_barcode gb
  (label_bar_id,
   label_page_no,
   gen_time,
   status,
   create_by,
   create_time,
   label_id,
   label_all_page_no,
   gen_date,
   GEN_BY,
   GEN_NAME,
   UPDATE_BY,
   UPDATE_TIME,
   SCNNING_DATE,
   SCNNING_BY,
   SCNNING_NAME )
select ?,
       label_page_no,
       gen_time,
       status,
       create_by,
       create_time,
       label_id,
       label_all_page_no,
       gen_date,
      GEN_BY,
      GEN_NAME,
       ?,
       ?,
   SCNNING_DATE,
   SCNNING_BY,
   SCNNING_NAME
  from gm_barcode
 where label_bar_id = ?";
            }
        }

        /// <summary>
        /// 修改扫描表中对应瓶贴号
        /// </summary>
        public static string SqlUpdateScanningBarID
        {
            get
            {
                return @"update st_scanning sts
set sts.barcode_id = ?
where sts.barcode_id = ?";
            }
        }

        /// <summary>
        /// 作废瓶贴
        /// </summary>
        public static string SqlDeleteLabel
        {
            get
            {
                return @"update st_pivas_label spl
   set spl.label_status = 1000304,
       spl.update_by    = ?,
       spl.update_date  = sysdate
 where spl.label_id = ?";
            }
        }

        /// <summary>
        /// 作废已经打印的瓶贴
        /// </summary>
        public static string SqlDeletePrintLable
        {
            get
            {
                return @"update gm_barcode gb
   set gb.status = 1000603,
   gb.update_by    = ?,
   gb.update_time  = sysdate
 where gb.label_id = ?";
            }
        }

        /// <summary>
        /// 查询瓶贴对应的医嘱状态
        /// </summary>
        public static string SqlQueryLabelGroupIndex
        {
            get
            {
                return @"select 1
  from gm_barcode gb, st_pivas_label spl, ht_advice_view hav,st_check_detail scd
 where gb.label_id = spl.label_id
   and spl.group_index = hav.group_index
   and spl.group_index = scd.group_index
   and scd.check_pivas_status = 1000102
   and scd.detail_status = '1'
   and gb.label_bar_id = ?";
            }
        }

        /// <summary>
        /// 作废打印了的瓶贴
        /// </summary>
        public static string SqlDelectPrintedLabelByDarCode
        {
            get
            {
                return @"update gm_barcode gb
   set gb.status = 1000603,
   gb.update_by    = ?,
   gb.update_time  = sysdate
 where gb.label_bar_id = ?";
            }
        }

        /// <summary>
        /// 作废打印了的瓶贴
        /// </summary>
        public static string SqlDelectLabelByDarCode
        {
            get
            {
                return @"update st_pivas_label spl
   set spl.label_status = 1000304,
       spl.update_by    = ?,
       spl.update_date  = sysdate
 where spl.label_id in (select gb.label_id from gm_barcode gb where gb.label_bar_id = ?)";
            }
        }

        ///// <summary>
        ///// 根据组号获取单个医嘱
        ///// </summary>
        //public static string SqlQueryAdviceIdByGroupIndex
        //{
        //    get
        //    {
        //        return @"select hav.advice_id from ht_advice_view hav where hav.group_index = ?";
        //    }
        //}

        /// <summary>
        /// 检查该瓶贴是否会使药品库存不足
        /// </summary>
        public static string SqlQueryLabelPharmCount
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
          from (select nspl.group_index
                  from st_pivas_label nspl
                 where nspl.create_date between trunc(sysdate) and sysdate
                   and nspl.label_status in (1000301, 1000302, 1000305)
                   and nspl.exe_status = '0'
                   and (nspl.print_status = '1' or nspl.label_id = ?)) spl,
               st_pivas_label_detail spld
         where spl.group_index = spld.group_index
           and spld.pharm_id in
               (select spld.pharm_id
                  from st_pivas_label spl, st_pivas_label_detail spld
                 where spl.group_index = spld.group_index
                   and spl.label_id = ?)
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


        #region 新拼贴打印

        /// <summary>
        /// 医嘱打印界面查询医嘱
        /// </summary>
        public static string SqlNewQueryLabelDetail
        {
            get
            {
//                return @"select t.*,
//         (case
//         when t.fee_count > 1 then
//           decode(fn_pharm_is_save(t.pharm_id),1,ceil(t.fee_count * t.pharm_dosage / t.dose_per_unit),t.fee_count * t.amount)
//         when t.fee_count = 1 then
//           t.amount
//         else
//           0
//       end) pharm_amount,
//       rpad(t.group_index, t.rn + length(t.group_index) - 1, ' ') new_group_index,
//       t.group_index ||  t.rn  new_group_index_no,
//       t.long_time_status LONG_TEMPORARY_STATUS,
//       scd.check_date,
//       scd.user_name
//  from (select spl.*,
//               spld.pharm_id,
//               spld.pharm_name,
//               spld.spec,
//               gpv.FACTORY_NAME PHARM_FACTION,
//               gpv.dose_per_unit,
//               spld.pharm_amount amount,
//               spld.amount_unit,
//               spld.pharm_dosage,
//               spld.dosage_unit
//          from (select t.*,
//                       row_number() over(partition by t.group_index, t.batch_id order by t.batch_id) rn
//                  from (select 0 label_id,
//                               stpl.group_index,
//                               stpl.illfield_id,
//                               stpl.illfield_name,
//                               stpl.batch_id,
//                               stpl.batch_name,
//                               stpl.bed_code bed_id,
//                               stpl.bed_name,
//                               stpl.inhos_id,
//                               stpl.PATIENT_NAME,
//                               '[' || stpl.bed_code || '床]' ||
//                               stpl.PATIENT_NAME || ' ' || stpl.patient_id NAME,
//                               '0' isprint,
//                               stpl.LONG_TIME_STATUS,
//                               stpl.fee_count
//                          from st_temp_pivas_label_view stpl
//                        union all
//                        select nspl.label_id,
//                               nspl.group_index,
//                               nspl.illfield_id,
//                               nspl.illfield_name,
//                               nspl.batch_id,
//                               nspl.batch_name,
//                               nspl.bed_id,
//                               nspl.bed_name,
//                               nspl.inhos_id,
//                               nspl.PATIENT_NAME,
//                               '[' || nspl.Bed_Id || '床]' || nspl.PATIENT_NAME || ' ' || nspl.patient_id NAME,
//                               nspl.print_status isprint,
//                               nspl.long_time_status,
//                               nspl.fee_count
//                          from st_pivas_label nspl
//                         where nspl.create_date between trunc(sysdate) and
//                               sysdate
//                           and nspl.label_status in (1000301,1000302,1000305)) t) spl,
//               st_pivas_label_detail spld,
//               gm_pharm_view gpv
//         where spl.group_index = spld.group_index
//           and spld.pharm_id = gpv.PHARM_ID) t,
//         (select * from st_check sc, st_check_detail scd where sc.check_id = scd.check_id and scd.check_pivas_status = 1000102 and scd.detail_status = '1') scd
// where fn_is_print(t.group_index) = ?
//   and scd.group_index = t.group_index
//   and t.long_time_status = ? {0} {1} {2}
// order by t.illfield_name,t.illfield_id, t.bed_id";
                return @"select t.*,
          t.illfield_id || LPAD(REPLACE(t.bed_id,'+','a'),4,0) || LPAD(t.patient_id,10,0) ILLFILED_BED_PATIENT_CODE,
         (case
         when t.fee_count > 1 then
           decode(fn_pharm_is_save(t.pharm_id),1,ceil(t.fee_count * t.pharm_dosage / t.dose_per_unit),t.fee_count * t.amount)
         when t.fee_count = 1 then
           t.amount
         else
           0
       end) pharm_amount,
       rpad(t.group_index, t.rn + length(t.group_index) - 1, ' ') new_group_index,
       t.group_index ||  t.rn  new_group_index_no,
       t.long_time_status LONG_TEMPORARY_STATUS,
       scd.check_date,
       scd.user_name
  from (select spl.*,
               spld.pharm_id,
               spld.pharm_name,
               spld.spec,
               gpv.FACTORY_NAME PHARM_FACTION,
               gpv.dose_per_unit,
               spld.pharm_amount amount,
               spld.amount_unit,
               spld.pharm_dosage,
               spld.dosage_unit
          from (select t.*,
                       row_number() over(partition by t.group_index, t.batch_id order by t.batch_id) rn
                  from (select 0 label_id,
                               stpl.group_index,
                               stpl.illfield_id,
                               stpl.illfield_name,
                               stpl.batch_id,
                               stpl.batch_name,
                               stpl.bed_code bed_id,
                               stpl.bed_name,
                               stpl.inhos_id,
                               stpl.patient_id,
                               stpl.PATIENT_NAME,
                               '[' || stpl.bed_code || '床]' ||
                               stpl.PATIENT_NAME || ' ' || stpl.patient_id NAME,
                               '0' isprint,
                               stpl.LONG_TIME_STATUS,
                               stpl.fee_count
                          from {0} stpl
                        union all
                        select nspl.label_id,
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
                               '[' || nspl.Bed_Id || '床]' || nspl.PATIENT_NAME || ' ' || nspl.patient_id NAME,
                               nspl.print_status isprint,
                               nspl.long_time_status,
                               nspl.fee_count
                          from st_pivas_label nspl
                         where nspl.pharm_time between trunc({1}) and
                               trunc({2} + 1)
                           and  {3}
                           and exists (select group_index from ht_advice_view hav where nspl.group_index=hav.group_index)
                           and nspl.label_status in (1000301,1000302,1000305)) t) spl,
               st_pivas_label_detail spld,
               gm_pharm_view gpv
         where spl.group_index = spld.group_index
           and spld.pharm_id = gpv.PHARM_ID) t,
         (select * from st_check sc, st_check_detail scd where sc.check_id = scd.check_id and scd.check_pivas_status = 1000102 and scd.detail_status = '1') scd
 where {4}
   and scd.group_index = t.group_index
   and t.long_time_status = ? {5} {6} {7}
 order by t.illfield_name,t.illfield_id, t.bed_id";
            }
        }

        //        /// <summary>
        //        /// 新插入瓶贴临时表
        //        /// </summary>
        //        public static string SqlNewInsertTempLabel
        //        {
        //            get
        //            {
        //                return @"insert into st_temp_pivas_label
        //  (create_id,
        //   temp_label_no,
        //   group_index,
        //   database_flag,
        //   pivas_pharm_type,
        //   pivas_pharm_type_name,
        //   pharm_time,
        //   batch_id,
        //   batch_name,
        //   s_no,
        //   inhos_id,
        //   patient_name,
        //   illfield_id,
        //   illfield_name,
        //   office_id,
        //   office_name,
        //   bed_id,
        //   bed_name,
        //   usage_id,
        //   usage_name,
        //   frequency_id,
        //   frequency_name,
        //   frequency_memo,
        //   times,
        //   gender,
        //   age,
        //   label_detail,
        //   pharm_id1,
        //   pharm_dosage1,
        //   pharm_id2,
        //   pharm_dosage2,
        //   create_by,
        //   create_date,
        //   update_by,
        //   update_date,
        //   pharm_seq,
        //   create_user_id,
        //   create_user_name)
        //  select st_temp_pivas_label_seq.nextval,
        //         st_pivas_label_seq.nextval,
        //         group_index,
        //         database_flag,
        //         pivas_pharm_type,
        //         pivas_pharm_type_name,
        //         pharm_time,
        //         batch_id,
        //         batch_name,
        //         s_no,
        //         inhos_id,
        //         patient_name,
        //         illfield_id,
        //         illfield_name,
        //         office_id,
        //         office_name,
        //         bed_code,
        //         bed_name,
        //         usage_id,
        //         usage_name,
        //         frequency_id,
        //         frequency_name,
        //         frequency_memo,
        //         times,
        //         gender,
        //         age,
        //         label_detail,
        //         pharm_id1,
        //         pharm_dosage1,
        //         pharm_id2,
        //         pharm_dosage2,
        //         1 creater_by ,--用户id,
        //         creater_date,
        //         update_by,
        //         update_date,
        //         pharm_seq,
        //         1 creater_user_id, --用户id,
        //         creater_user_name
        //    from st_temp_pivas_label_view stplv--该视图取出所有现在能生成的瓶贴
        //    where fn_is_print(stplv.group_index) = ? {0} {1}";
        //            }
        //        }
        /// <summary>
        /// 新插入瓶贴临时表
        /// </summary>
        public static string SqlNewInsertTempLabel
        {
            get
            {
                return @"insert into st_temp_pivas_label
  (create_id,
   temp_label_no,
   group_index,
   database_flag,
   pivas_pharm_type,
   pivas_pharm_type_name,
   pharm_time,
   batch_id,
   batch_name,
   check_batch_id,
   check_batch_name,
   s_no,
   inhos_id,
   patient_name,
   illfield_id,
   illfield_name,
   office_id,
   office_name,
   bed_id,
   bed_name,
   usage_id,
   usage_name,
   frequency_id,
   frequency_name,
   frequency_memo,
   times,
   gender,
   age,
   label_detail,
   pharm_id1,
   pharm_dosage1,
   pharm_id2,
   pharm_dosage2,
   create_by,
   create_date,
   update_by,
   update_date,
   pharm_seq,
   create_user_id,
   create_user_name,
   LONG_TIME_STATUS,
   fee_count,
   LIST_DOCTOR_NAME,
   patient_id,
   LIST_DOCTOR_DATE
)
 select st_temp_pivas_label_seq.nextval,
         st_pivas_label_seq.nextval,t.* from (select 
         group_index,
         database_flag,
         pivas_pharm_type,
         pivas_pharm_type_name,
         pharm_time,
         batch_id,
         batch_name,
         check_batch_id,
         check_batch_name,
         s_no,
         inhos_id,
         patient_name,
         illfield_id,
         illfield_name,
         office_id,
         office_name,
         bed_code,
         bed_name,
         usage_id,
         usage_name,
         frequency_id,
         frequency_name,
         frequency_memo,
         times,
         gender,
         age,
         label_detail,
         pharm_id1,
         pharm_dosage1,
         pharm_id2,
         pharm_dosage2,
         1 creater_by ,--用户id,
         creater_date,
         update_by,
         update_date,
         pharm_seq,
         1 creater_user_id, --用户id,
         creater_user_name,
         stplv.LONG_TIME_STATUS,
         fee_count,
         LIST_DOCTOR_NAME,
         patient_id,
         LIST_DOCTOR_DATE
    from {0} stplv--该视图取出所有现在能生成的瓶贴
    where stplv.group_index = ? and stplv.batch_id = ?) t";
            }
        }

        /// <summary>
        /// 新插入瓶贴
        /// </summary>
        public static string SqlNewInsertLabel
        {
            get
            {
                return @"insert into st_pivas_label
  (label_id,
   label_no,
   group_index,
   database_flag,
   arrange_id,
   pivas_pharm_type,
   pivas_pharm_type_name,
   pharm_time,
   batch_id,
   batch_name,
   check_batch_id,
   check_batch_name,
   s_no,
   inhos_id,
   patient_name,
   illfield_id,
   illfield_name,
   office_id,
   office_name,
   bed_id,
   bed_name,
   usage_id,
   usage_name,
   frequency_id,
   frequency_name,
   frequency_memo,
   times,
   gender,
   age,
   label_detail,
   exe_status,
   label_status,
   pharm_id1,
   pharm_dosage1,
   pharm_id2,
   pharm_dosage2,
   create_by,
   create_date,
   update_by,
   update_date,
   pharm_seq,
   print_status,
   LONG_TIME_STATUS,
   fee_count,
   LIST_DOCTOR_NAME,
   patient_id,
   LIST_DOCTOR_DATE)
  select stpl.temp_label_no,
         to_char(sysdate, 'yyyymmdd') || '0000' ||
         to_char(stpl.temp_label_no),
         stpl.group_index,
         stpl.database_flag,
         null --摆药单id  需修改
        ,
         stpl.pivas_pharm_type,
         stpl.pivas_pharm_type_name,
         stpl.pharm_time,
         stpl.batch_id,
         stpl.batch_name,
         stpl.check_batch_id,
         stpl.check_batch_name,
         stpl.s_no,
         stpl.inhos_id,
         stpl.patient_name,
         stpl.illfield_id,
         stpl.illfield_name,
         stpl.office_id,
         stpl.office_name,
         stpl.bed_id,
         stpl.bed_name,
         stpl.usage_id,
         stpl.usage_name,
         stpl.frequency_id,
         stpl.frequency_name,
         stpl.frequency_memo,
         stpl.times,
         stpl.gender,
         stpl.age,
         stpl.label_detail,
         '0' --冲药说明 未冲
        ,
         1000301 --瓶贴状态 正常
        ,
         stpl.pharm_id1,
         stpl.pharm_dosage1,
         stpl.pharm_id2,
         stpl.pharm_dosage2,
         1 create_id --创建者 需修改
        ,
         sysdate create_date,
         null update_id,
         null update_name,
         stpl.pharm_seq,
         '0' --打印状态 未打印
        ,
         LONG_TIME_STATUS,
         stpl.fee_count,
          LIST_DOCTOR_NAME,
          patient_id,
          LIST_DOCTOR_DATE
    from st_temp_pivas_label stpl
";
            }
        }

        /// <summary>
        /// 查询刚生成的瓶贴
        /// </summary>
        public static string SqlNewQueryLabel
        {
            get
            {
                return @"select spl.label_id LABEL_ID,
       spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
       SPL.FREQUENCY_NAME,
/*       SPL.INHOS_ID INHOS_ID,*/
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       spl.list_doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
              case
         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
          decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
         else
          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
       end DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       spl.print_status,
       decode(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       st_check_detail scd,
       st_check sc,
       st_temp_pivas_label stpl,
       HM_PATIENT_VIEW HPV
 where stpl.temp_label_no = spl.label_id
   and spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index
   AND SPL.INHOS_ID = HPV.inhos_id
   and scd.check_pivas_status = 1000102
   and scd.detail_status = '1'
   and scd.check_id = sc.check_id";
            }
        }

        /// <summary>
        /// 新删除原临时瓶贴表中该用户的数据
        /// </summary>
        public static string SqlNewDeleteTempLabel
        {
            get
            {
                return @"delete st_temp_pivas_label ";
            }
        }

        /// <summary>
        /// 查询未打印的瓶贴
        /// </summary>
        public static string SqlNewQueryGenLabel
        {
            get
            {
//                return @"select spl.label_id LABEL_ID,
//       spl.illfield_name ILLFIELD,
//       SPL.USAGE_ID USAGE_ID,
//       SPL.USAGE_NAME USAGE_NAME,
//       '[' || spl.usage_name || ']' USAGE,
//       SPL.BED_ID BED_ID,
//       SPL.BED_NAME BED_NAME,
//       SPL.FREQUENCY_NAME,
///*       SPL.INHOS_ID INHOS_ID,*/
//       HPV.patient_id INHOS_ID,
//       SPL.PATIENT_NAME PATIENT_NAME,
//       SPL.GENDER GENDER,
//       SPL.AGE AGE,
//       SPL.INHOS_ID INHOS_ID,
//       SPL.GROUP_INDEX GROUP_INDEX,
//       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
//       hav.doctor_name DOCTOR_NAME,
//       hav.list_date LIST_DATE,
//       SC.USER_NAME CHECK_NAME,
//       SPL.BATCH_NAME BATCH_NAME,
//       SPL.PHARM_TIME PHARM_TIME,
//       SPLD.HIS_ADVICE_ID,
//       SPLD.PHARM_NAME PHARM_NAME,
//       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
//              case
//         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
//          decode(substr(to_char(spld.pharm_dosage), 0, 1),
//              '.',
//              '0' || to_char(spld.pharm_dosage),
//              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
//         else
//          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
//              '.',
//              '0' || to_char(spld.pharm_dosage),
//              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
//       end DOSAGE,
//       spld.spec || '/' ||  spld.amount_unit specUnit,
//       gpv.factory_name factory_name,
//       spld.pharm_amount || spld.amount_unit AMOUNT,
//       spl.print_status,
//       DECODE(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
//       spl.create_date
//  from st_pivas_label spl,
//       ST_PIVAS_LABEL_DETAIL spld,
//       gm_pharm_view gpv,
//       (select nhav.group_index      group_index,
//                        nhav.list_doctor_name doctor_name,
//                        max(nhav.list_date) list_date,
//                        nhav.STANDING_FLAG
//          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
//       st_check_detail scd,
//       st_check sc,
//       HM_PATIENT_VIEW HPV
// where  spl.group_index = spld.group_index
//   and spld.pharm_id = gpv.PHARM_ID
//   and spl.group_index = hav.group_index(+)
//   and spl.group_index = scd.group_index
//   and scd.check_pivas_status = 1000102
//   and scd.detail_status = '1'
//   and scd.check_id = sc.check_id
//   AND SPL.INHOS_ID = HPV.inhos_id
//   and spl.LABEL_STATUS in (1000301,1000302,1000305)
//   and spl.create_date between trunc(sysdate) and sysdate + 1
//-- and spl.print_status = '0'
//   and fn_is_print(spl.group_index) = ? {0} {1} {2}";
                return @"select spl.label_id LABEL_ID,
       spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
/*       SPL.INHOS_ID INHOS_ID,*/
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       spl.list_doctor_name DOCTOR_NAME, 
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
              case
         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
          decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
         else
          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
       end DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       spl.print_status,
       DECODE(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       st_check_detail scd,
       st_check sc,
       HM_PATIENT_VIEW HPV
 where  spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index
   and scd.check_pivas_status = 1000102
   and scd.detail_status = '1'
   and scd.check_id = sc.check_id
   AND SPL.INHOS_ID = HPV.inhos_id
   and spl.LABEL_STATUS in (1000301,1000302,1000305)
   and spl.pharm_time between trunc({0}) and trunc({1} + 1)
   and {2}
-- and spl.print_status = '0'
    {3} {4} {5} {6}";
            }
        }

        /// <summary>
        /// 查询瓶贴扣费次数
        /// </summary>
        public static string SqlLabelTimes
        {
            get
            {
                return @"select spl.fee_count from st_pivas_label spl where spl.label_id = ?";
            }
        }

        #endregion

        #region 瓶贴重打

        /// <summary>
        /// 通过时间差寻瓶贴
        /// </summary>
        public static string SqlSelectLabel
        {
            get
            {
                return @"select spl.illfield_id,
       spl.illfield_name,
       spl.patient_name || '[' || spl.bed_name || ']' patient_name,
       gb.label_bar_id,
       spld.pharm_name,
       spld.spec,
       gpv.FACTORY_NAME,
       spld.pharm_dosage || spld.dosage_unit dosage,
       spl.batch_name
  from gm_barcode gb, st_pivas_label spl, st_pivas_label_detail spld,gm_pharm_view gpv
 where gb.label_id = spl.label_id
   and spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and gb.status != 1000603
   and gb.gen_date between ? and ?
   and gb.label_bar_id between ? and ?
   {0}
   order by gb.label_bar_id";
            }
        }

//        /// <summary>
//        /// 通过瓶贴号查瓶贴
//        /// </summary>
//        public static string SqlSelectLabelByBarId
//        {
//            get
//            {
//                return @"select spl.illfield_id,
//       spl.illfield_name,
//       spl.patient_name || '[' || spl.bed_name || ']' patient_name,
//       gb.label_bar_id,
//       spld.pharm_name,
//       spld.spec,
//       gpv.FACTORY_NAME,
//       spld.pharm_dosage || spld.dosage_unit dosage,
//       spl.batch_name
//  from gm_barcode gb, st_pivas_label spl, st_pivas_label_detail spld,gm_pharm_view gpv
// where gb.label_id = spl.label_id
//   and spl.group_index = spld.group_index
//   and spld.pharm_id = gpv.PHARM_ID
//   and gb.status != 1000603
//   and gb.label_bar_id between ? and ?
//   order by gb.label_bar_id";
//            }
//        }

        
        /// <summary>
        /// 根据条形码号查瓶贴
        /// </summary>
        public static string SqlSelectLabelInfo
        {
            get
            {
                return @"select spl.label_id LABEL_ID,
       spl.illfield_id illfield_id,
       spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
/*       SPL.INHOS_ID INHOS_ID,*/
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       spl.list_doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_ID BATCH_ID,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
              case
         when mod(spld.pharm_dosage, gpv.DOSE_PER_UNIT) = 0 then
          decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT
         else
          '【'|| decode(substr(to_char(spld.pharm_dosage), 0, 1),
              '.',
              '0' || to_char(spld.pharm_dosage),
              to_char(spld.pharm_dosage)) || spld.DOSAGE_UNIT || '】'
       end DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       gb.*,
       decode(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       (select * from st_check_detail nscd where nscd.check_pivas_status = 1000102 and nscd.detail_status = '1') scd,
       st_check sc,
       gm_barcode gb,
       HM_PATIENT_VIEW HPV
 where  spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index(+)
   and scd.check_id = sc.check_id(+)
   and gb.label_bar_id in {0}
   and gb.label_id = spl.label_id
   AND SPL.INHOS_ID = HPV.inhos_id
  order by  spld.his_advice_id  asc";
            }
        }

        #endregion


        #region 打印瓶贴明细

        /// <summary>
        /// 打印瓶贴明细
        /// </summary>
        public static string QueryPrintLabelDetail
        {
            get
            {
//                return @"select spl.label_id LABEL_ID,
//       spl.illfield_id illfield_id,
//       spl.illfield_name,
//       SPL.USAGE_ID USAGE_ID,
//       SPL.USAGE_NAME USAGE_NAME,
//       '[' || spl.usage_name || ']' USAGE,
//       SPL.BED_ID BED_ID,
//       SPL.BED_NAME BED_NAME,
//       SPL.FREQUENCY_NAME,
///*       SPL.INHOS_ID INHOS_ID,*/
//       HPV.patient_id INHOS_ID,
//       SPL.PATIENT_NAME PATIENT_NAME,
//       SPL.GENDER GENDER,
//       SPL.AGE AGE,
//       SPL.INHOS_ID INHOS_ID,
//       SPL.GROUP_INDEX GROUP_INDEX,
//       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
//       hav.doctor_name DOCTOR_NAME,
//       hav.list_date LIST_DATE,
//       SC.USER_NAME CHECK_NAME,
//       SPL.BATCH_ID BATCH_ID,
//       SPL.BATCH_NAME BATCH_NAME,
//       SPL.PHARM_TIME PHARM_TIME,
//       SPLD.HIS_ADVICE_ID,
//       SPLD.PHARM_NAME PHARM_NAME,
//       '[' || SPL.BED_ID || ']' || SPL.PATIENT_NAME NAME,
//       spld.pharm_dosage ,
//       spld.Dosage_Unit,
//       spld.spec || '/' ||  spld.amount_unit spec,
//       gpv.factory_name PHARM_FACTION,
//       spld.pharm_amount,
//       spld.amount_unit,
//       gb.*,
//       decode(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
//       spl.create_date
//  from st_pivas_label spl,
//       ST_PIVAS_LABEL_DETAIL spld,
//       gm_pharm_view gpv,
//       (select nhav.group_index      group_index,
//                        nhav.list_doctor_name doctor_name,
//                        max(nhav.list_date) list_date,
//                        nhav.STANDING_FLAG
//          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
//       (select * from st_check_detail nscd where nscd.check_pivas_status = 1000102 and nscd.detail_status = '1') scd,
//       st_check sc,
//       gm_barcode gb,
//       HM_PATIENT_VIEW HPV
// where  spl.group_index = spld.group_index
//   and spld.pharm_id = gpv.PHARM_ID
//   and spl.group_index = hav.group_index(+)
//   and spl.group_index = scd.group_index(+)
//   and scd.check_id = sc.check_id(+)
//   {0}
//   and gb.label_id = spl.label_id
//   AND SPL.INHOS_ID = HPV.inhos_id
//  order by  spld.his_advice_id  asc";
                return @"select spl.label_id LABEL_ID,
       spl.illfield_id illfield_id,
       spl.illfield_name,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.FREQUENCY_NAME,
                                 
       HPV.patient_id INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,          
       spl.list_doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_ID BATCH_ID,
       SPL.BATCH_NAME BATCH_NAME,
       SPL.PHARM_TIME PHARM_TIME,
       SPLD.HIS_ADVICE_ID,
       SPLD.PHARM_NAME PHARM_NAME,
       '[' || SPL.BED_ID || ']' || SPL.PATIENT_NAME NAME,
       spld.pharm_dosage ,
       spld.Dosage_Unit,
       spld.spec || '/' ||  spld.amount_unit spec,
       gpv.factory_name PHARM_FACTION,
       spld.pharm_amount,
       spld.amount_unit,
       gb.*,
       decode(spl.long_time_status,'0','[临]','1','[长]','') LONG_TEMPORARY_NAME,
       spl.create_date
  from st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        max(nhav.list_date) list_date,
                        nhav.STANDING_FLAG
          from ht_advice_view nhav group by nhav.group_index,nhav.list_doctor_name,nhav.STANDING_FLAG) hav,
       (select * from st_check_detail nscd where nscd.check_pivas_status = 1000102 and nscd.detail_status = '1') scd,
       st_check sc,
       gm_barcode gb,
       HM_PATIENT_VIEW HPV
where spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index(+)
   and spl.group_index = scd.group_index(+)
   and scd.check_id = sc.check_id(+)
   and gb.status != 1000603
   and spl.pharm_time between trunc(?) and trunc(?)
   and gb.label_id = spl.label_id
   AND SPL.INHOS_ID = HPV.inhos_id
   and spl.illfield_id = ?
   {0}
   {1}
   {2}
   {3}
order by  spld.his_advice_id  asc";
            }
        }

        #endregion



    }
}
