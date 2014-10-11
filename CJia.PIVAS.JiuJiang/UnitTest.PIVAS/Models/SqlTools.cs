using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.PIVAS.Models
{
    public class SqlTools
    {
        #region 退药测试Sql语句
        /// <summary>
        /// 插入退药申请表记录
        /// </summary>
        public static string sqlInsertCancelApply
        {
            get
            {
                return @"insert into ST_PIVAS_LABEL_CANCEL_APPLY
                                              (APPLY_ID,
                                               LABEL_ID,
                                               LABEL_NO,
                                               LABEL_STATUS,
                                               CANCEL_TYPE,
                                               CANCEL_USER_ID,
                                               CANCEL_USER_CODE,
                                               CANCEL_USER_NAME,
                                               CANCEL_DEPT_ID,
                                               CANCEL_DEPT_NAME,
                                               CANCEL_TIME,
                                               CANCEL_RCP_ID,
                                               CREATE_BY,
                                               CREATE_DATE,
                                               UPDATE_BY,
                                               UPDATE_DATE)
                                            values
                                              (20000143,
                                               9000000000,
                                               '2020022200002000000040',
                                               {0},
                                               1000402,
                                               null,
                                               null,
                                               null,
                                               null,
                                               null,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                               null,
                                               1000000001,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                               1000000001,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'))";
            }
        }

        /// <summary>
        /// 删除退药申请表记录
        /// </summary>
        public static string sqlDeleteCancelApply
        {
            get
            {
                return @"delete from ST_PIVAS_LABEL_CANCEL_APPLY t
                                     where t.label_no = '2020022200002000000040'";
            }
        }

        /// <summary>
        /// 插入瓶贴表记录
        /// </summary>
        public static string sqlInsertLabel
        {
            get
            {
                return @"insert into ST_PIVAS_LABEL
                                          (LABEL_ID,
                                           LABEL_NO,
                                           GROUP_INDEX,
                                           DATABASE_FLAG,
                                           ARRANGE_ID,
                                           PIVAS_PHARM_TYPE,
                                           PIVAS_PHARM_TYPE_NAME,
                                           PHARM_TIME,
                                           BATCH_ID,
                                           BATCH_NAME,
                                           S_NO,
                                           INHOS_ID,
                                           PATIENT_NAME,
                                           ILLFIELD_ID,
                                           ILLFIELD_NAME,
                                           OFFICE_ID,
                                           OFFICE_NAME,
                                           BED_ID,
                                           BED_NAME,
                                           USAGE_ID,
                                           USAGE_NAME,
                                           FREQUENCY_ID,
                                           FREQUENCY_NAME,
                                           FREQUENCY_MEMO,
                                           TIMES,
                                           GENDER,
                                           AGE,
                                           LABEL_DETAIL,
                                           EXE_STATUS,
                                           LABEL_STATUS,
                                           PHARM_ID1,
                                           PHARM_DOSAGE1,
                                           PHARM_ID2,
                                           PHARM_DOSAGE2,
                                           CREATE_BY,
                                           CREATE_DATE,
                                           UPDATE_BY,
                                           UPDATE_DATE,
                                           PHARM_SEQ,
                                           PRINT_STATUS,
                                           PHARM_SEND_NO,
                                           USER_ID,
                                           PHARM_SEND_DATE,
                                           TIME_ID,
                                           PHARM_SEND_USER_NAME)
                                        values
                                          (9000000000,
                                           '2020022200002000000040',
                                           9000000000,
                                           'W',
                                           2000000048,
                                           1000204,
                                           '普通药',
                                           to_date('02-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                           1000000000,
                                           '第1批',
                                           null,
                                           1000108724,
                                           '保健对象2831',
                                           1000000673,
                                           '7号楼九楼病区',
                                           1000000250,
                                           '普外科',
                                           1000001991,
                                           '201803',
                                           1000000077,
                                           '静脉输液',
                                           1000000326,
                                           'Bid',
                                           '8-18',
                                           2,
                                           '其他',
                                           '7',
                                           '天地欣(1mg)1ml; 5%葡萄糖注射液(250ml)250ml; ',
                                           '0',
                                           1000301,
                                           1000000000,
                                           1.0000,
                                           1000000001,
                                           250.0000,
                                           1000000001,
                                           to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                           1000000001,
                                           sysdate,
                                           1000000001,
                                           '0',
                                           sysdate,
                                           null,
                                           null,
                                           null,
                                           null)";
            }
        }

        /// <summary>
        /// 删除瓶贴表记录
        /// </summary>
        public static string sqlDeleteLabel
        {
            get
            {
                return @"delete from ST_PIVAS_LABEL t where t.label_no = '2020022200002000000040'";
            }
        }

        /// <summary>
        /// 插入瓶贴明细表记录
        /// </summary>
        public static string sqlInsertLabelDetail
        {
            get
            {
                return @"insert into ST_PIVAS_LABEL_DETAIL
                                          (LABEL_DETAIL_ID,
                                           LABEL_ID,
                                           LABEL_NO,
                                           GROUP_INDEX,
                                           DATABASE_FLAG,
                                           HIS_ADVICE_ID,
                                           PHARM_ID,
                                           PHARM_NAME,
                                           SPEC,
                                           PHARM_AMOUNT,
                                           AMOUNT_UNIT,
                                           PHARM_DOSAGE,
                                           DOSAGE_UNIT,
                                           PUBLIC1,
                                           PHARM_COMMON_NAME)
                                        values
                                          (9000000000,
                                           null,
                                           null,
                                           9000000000,
                                           'w',
                                           1000000002,
                                           1000001629,
                                           '力扑素',
                                           '30mg',
                                           1,
                                           '瓶',
                                           30,
                                           'mg',
                                           null,
                                           '注射用紫杉醇脂质体G')";
            }
        }

        /// <summary>
        /// 删除瓶贴明细表记录
        /// </summary>
        public static string sqlDeleteLabelDetail
        {
            get
            {
                return @"delete from ST_PIVAS_LABEL_DETAIL t where t.group_index=9000000000";
            }
        }

        /// <summary>
        /// 插入病区表
        /// </summary>
        public static string sqlInsertPIVAS_Set
        {
            get
            {
                return @"insert into SR_PIVAS_SET
                                          (PIVAS_SET_ID,
                                           OFFICE_ID,
                                           OFFICE_NAME,
                                           USAGE_ID,
                                           USAGE_NAME,
                                           STATUS,
                                           CREATE_BY,
                                           CREATE_DATE,
                                           UPDATE_BY,
                                           UPDATE_DATE)
                                        values
                                          (2000000000,
                                           1000000679,
                                           '9号楼9楼病区',
                                           1000000075,
                                           '静脉输血',
                                           '1',
                                           9999999999,
                                           null,
                                           null,
                                           null)";
            }
        }

        /// <summary>
        /// 删除添加病区
        /// </summary>
        public static string sqlDeletePIVAS_Set
        {
            get
            {
                return @"delete from SR_PIVAS_SET t where t.pivas_set_id = 2000000000";
            }
        }

        /// <summary>
        /// 插入退药表记录
        /// </summary>
        public static string sqlInsertRCP
        {
            get
            {
                return @"insert into ST_PIVAS_LABEL_CANCEL_RCP
                                          (CANCEL_RCP_ID,
                                           CHECK_USER_ID,
                                           CHECK_USER_CODE,
                                           CHECK_USER_NAME,
                                           CHECK_DEPT_ID,
                                           CHECK_DEPT_NAME,
                                           CHECK_TIME,
                                           CREATE_BY,
                                           CREATE_DATE,
                                           UPDATE_BY,
                                           UPDATE_DATE)
                                        values
                                          (202002250001,
                                           1000000001,
                                           'huyang',
                                           '胡洋',
                                           '1000000062',
                                           '配置中心药房',
                                           to_date('25-02-2013 15:23:00', 'dd-mm-yyyy hh24:mi:ss'),
                                           1000000001,
                                           to_date('25-02-2013 15:23:00', 'dd-mm-yyyy hh24:mi:ss'),
                                           1000000001,
                                           to_date('25-02-2013 15:23:00', 'dd-mm-yyyy hh24:mi:ss'))";
            }
        }

        /// <summary>
        /// 删除退药表记录
        /// </summary>
        public static string sqlDeleteRCP
        {
            get
            {
                return @"delete from ST_PIVAS_LABEL_CANCEL_RCP t where t.cancel_rcp_id = 202002250001";
            }
        }

        /// <summary>
        /// 插入退药申请表记录（有退药单号）
        /// </summary>
        public static string sqlInsertCancelApplyWithRCP
        {
            get
            {
                return @"insert into ST_PIVAS_LABEL_CANCEL_APPLY
                                              (APPLY_ID,
                                               LABEL_ID,
                                               LABEL_NO,
                                               LABEL_STATUS,
                                               CANCEL_TYPE,
                                               CANCEL_USER_ID,
                                               CANCEL_USER_CODE,
                                               CANCEL_USER_NAME,
                                               CANCEL_DEPT_ID,
                                               CANCEL_DEPT_NAME,
                                               CANCEL_TIME,
                                               CANCEL_RCP_ID,
                                               CREATE_BY,
                                               CREATE_DATE,
                                               UPDATE_BY,
                                               UPDATE_DATE)
                                            values
                                              (20000143,
                                               2000000040,
                                               '2020022200002000000040',
                                               {0},
                                               1000402,
                                               null,
                                               null,
                                               null,
                                               null,
                                               null,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                               202002250001,
                                               1000000001,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'),
                                               1000000001,
                                               to_date('01-01-2020 09:00:00', 'dd-mm-yyyy hh24:mi:ss'))";
            }
        }

        #endregion
    }
}
