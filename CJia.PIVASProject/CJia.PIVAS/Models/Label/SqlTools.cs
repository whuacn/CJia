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
                return @"select spld.pharm_id,spld.pharm_name,spld.pharm_common_name, sum(spld.pharm_amount) all_pharm_amount, spld.amount_unit  ,spld.spec
from  ({0}) spl,st_pivas_label_detail spld
where spl.group_index = spld.group_index
group by spld.pharm_id,spld.pharm_name,spld.pharm_common_name,spld.spec,spld.amount_unit";
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
       spl.illfield_id || ' ' || spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.INHOS_ID INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       hav.doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_NAME BATCH_NAME,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
       decode(substr(to_char(spld.pharm_dosage),0,1),'.','0' || to_char(spld.pharm_dosage),to_char(spld.pharm_dosage))
       || spld.DOSAGE_UNIT DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT
  from st_pivas_arrange spa,
       st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select distinct nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        nhav.list_date
          from ht_advice_view nhav) hav,
       st_check_detail scd,
       st_check sc
 where spa.arrange_id = spl.arrange_id
   and spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index
   and spl.group_index = scd.group_index
   and scd.check_pivas_status = 1000102
   and scd.check_id = sc.check_id
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
                return @"select * from sm_batch_set sbs where sbs.status = '1'";
            }
        }

        /// <summary>
        /// 查询生成瓶贴的次数
        /// </summary>
        public static string SqlQueryListCount
        {
            get
            {
                return @"select * from sm_time_set where type = '1' and status = '1' order by start_time asc   ";
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
                return @"  select distinct sps.office_id,sps.office_name{0}
 from sr_pivas_set sps,( select * from st_pivas_arrange where to_char(arr_date,'yyyy-mm-dd') = to_char(sysdate,'yyyy-mm-dd')) spa
 where sps.office_id = spa.illfield_id(+)";
            }
        }

        /// <summary>
        /// 删除原临时瓶贴表中该用户的数据
        /// </summary>
        public static string SqlDeleteTempLabel
        {
            get
            {
                return @"delete st_temp_pivas_label stpl
 where stpl.create_user_id = ?";
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
    from st_temp_pivas_label_view--该视图取出所有现在能生成的瓶贴
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
from st_temp_pivas_label stpl
where stpl.create_user_id = ?";
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
 where stpl.create_user_id = ?
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
                return @"insert into st_pivas_arrange
  (arrange_id, user_id, illfield_id, illfield_name, arr_type, arr_date, create_by, create_date, update_by, update_date)
select ?, ?/*生成人*/, ?, ?, sts.rowno /*第几次摆药*/, sysdate, ?/*创建人*/, sysdate, null, null
from (select nsts.*,rownum rowno from sm_time_set nsts where nsts.type = '1' and nsts.status = '1' order by nsts.start_time asc) sts
where sts.time_id = ?";
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
where stpl.illfield_id = ?
and stpl.create_user_id = ?";
            }
        }

        /// <summary>
        ///查询今天有没有生成该批次瓶贴
        /// </summary>
        public static string SqlQueryIsGenArrange
        {
            get
            {
                return @"select 1 from st_pivas_arrange spa
where to_char(spa.arr_date,'yyyy-mm-dd') = to_char(sysdate,'yyyy-mm-dd')
and spa.arr_type in (select sts.rowno
from (select nsts.*,rownum rowno from (select nnsts.* from sm_time_set nnsts where nnsts.type = '1' and nnsts.status = '1' order by nnsts.start_time asc) nsts) sts
where sts.time_id = ?)
and spa.illfield_id = ?";
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
   set spl.print_status = '1'
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
                return @"select distinct sps.office_id,sps.office_name from sr_pivas_set sps where sps.status = '1'";
            }
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        public static string SqlQueryAllBacthLabel
        {
            get
            {
                return @"select sbs.batch_id,sbs.batch_name from sm_batch_set sbs where sbs.status = '1'";
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
        spl.illfield_name illfield_name,
       spl.batch_name batch_name,
       spl.bed_name bed_name,
       spl.patient_name patient_name,
       spl.group_index group_index,
       spl.pivas_pharm_type_name pharm_type_name,
       '第' || gb.label_page_no || '/' || gb.label_all_page_no || '页' page_no,
       gb.gen_time gen_time,
       gb.status status,
       gc.name label_type
  from gm_barcode gb, st_pivas_label spl, gm_code gc
 where gb.label_id = spl.label_id
   and gb.status = gc.code
   {0}
 order by spl.illfield_name asc,
          spl.batch_name    asc,
          spl.bed_id        asc,
          spl.group_index   asc,
          gb.label_page_no  asc
";
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
       spl.illfield_id || ' ' || spl.illfield_name ILLFIELD,
       SPL.USAGE_ID USAGE_ID,
       SPL.USAGE_NAME USAGE_NAME,
       '[' || spl.usage_name || ']' USAGE,
       SPL.BED_ID BED_ID,
       SPL.BED_NAME BED_NAME,
       SPL.INHOS_ID INHOS_ID,
       SPL.PATIENT_NAME PATIENT_NAME,
       SPL.GENDER GENDER,
       SPL.AGE AGE,
       SPL.INHOS_ID INHOS_ID,
       SPL.GROUP_INDEX GROUP_INDEX,
       decode(spl.pivas_pharm_type,1000201,'普',1000202,'精',1000203,'麻',1000204,'贵',1000205,'抗','普') PHARM_TYPE,--加上所有药品类型
       hav.doctor_name DOCTOR_NAME,
       hav.list_date LIST_DATE,
       SC.USER_NAME CHECK_NAME,
       SPL.BATCH_ID BATCH_ID,
       SPL.BATCH_NAME BATCH_NAME,
       SPLD.PHARM_NAME PHARM_NAME,
       SPLD.SPEC || '/' ||  SPLD.AMOUNT_UNIT SPEC_UNIT,
       decode(substr(to_char(spld.pharm_dosage),0,1),'.','0' || to_char(spld.pharm_dosage),to_char(spld.pharm_dosage))
       || spld.DOSAGE_UNIT DOSAGE,
       spld.spec || '/' ||  spld.amount_unit specUnit,
       gpv.factory_name factory_name,
       spld.pharm_amount || spld.amount_unit AMOUNT,
       gb.*
  from st_pivas_arrange spa,
       st_pivas_label spl,
       ST_PIVAS_LABEL_DETAIL spld,
       gm_pharm_view gpv,
       (select distinct nhav.group_index      group_index,
                        nhav.list_doctor_name doctor_name,
                        nhav.list_date
          from ht_advice_view nhav) hav,
       st_check_detail scd,
       st_check sc,
       gm_barcode gb
 where spa.arrange_id = spl.arrange_id
   and spl.group_index = spld.group_index
   and spld.pharm_id = gpv.PHARM_ID
   and spl.group_index = hav.group_index
   and spl.group_index = scd.group_index
   and scd.check_pivas_status = 1000102
   and scd.check_id = sc.check_id
   and gb.label_bar_id = ?
   and gb.label_id = spl.label_id
  order by  spld.his_advice_id  asc ";
            }
        }

        /// <summary>
        /// 修改条形码状态
        /// </summary>
        public static string SqlUpdateBarCodeStatus
        {
            get
            {
                return @"update gm_barcode
   set status = ?
 where label_bar_id = ?";
            }
        }

        /// <summary>
        /// 复制条形码信息
        /// </summary>
        public static string SqlCopeBarCode
        {
            get
            {
                return @"insert into gm_barcode
  (label_bar_id,
   label_page_no,
   gen_time,
   status,
   create_by,
   create_time,
   update_by,
   update_time,
   label_id,
   label_all_page_no,
   gen_date)
select ?,
       label_page_no,
       to_char(sysdate,'yyyy/mm/dd'),
       status,
       ?,
       sysdate,
       update_by,
       update_time,
       label_id,
       label_all_page_no,
       sysdate
  from gm_barcode
 where label_bar_id = ?";
            }
        }
    }
}
