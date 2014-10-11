using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.Models
{
    public class SqlTools
    {
        /// <summary>
        /// 获得审核脚本
        /// </summary>
        public static string SqlQueryCheckScript
        {
            get
            {
                return @"select t.*,gc.name check_name,decode(t.status,'1','','无效') status_name from HM_CHECK_SCRIPT t,gm_code gc
                        where t.check_id=gc.code {0}
                        order by t.bit_flag";
            }
        }
        /// <summary>
        /// 根据编号查询审核脚本
        /// </summary>
        public static string SqlQueryCheckScriptByNO
        {
            get
            {
                return @"select t.*,gc.name check_name,decode(t.status,'1','','无效') status_name from HM_CHECK_SCRIPT t,gm_code gc
                        where t.check_id=gc.code
                        and t.cs_no=?";
            }
        }
        /// <summary>
        /// 根据关键字搜索审核脚本
        /// </summary>
        public static string SqlQueryCheckScriptByKey
        {
            get
            {
                return @"select t.*,
                           gc.name check_name,
                           decode(t.status, '1', '', '无效') status_name
                      from HM_CHECK_SCRIPT t, gm_code gc
                     where t.check_id = gc.code
                       and (t.cs_no like ? or t.cs_text like ? or t.cs_error like ? or
                           t.check_level like ? or gc.name like ? or
                           t.check_classify like ?)
                     order by t.cs_no";
            }
        }
        /// <summary>
        /// 删除审核脚本
        /// </summary>
        public static string SqlDeleteCheckScript
        {
            get
            {
                return @"update hm_check_script
                       set status = '0',
                           update_by = ?,
                           update_date = sysdate
                     where id=?";
            }
        }
        /// <summary>
        /// 修改审核脚本
        /// </summary>
        public static string SqlModifyCheckScript
        {
            get
            {
                return @"update hm_check_script
                       set cs_no = ?,
                           cs_text = ?,
                           cs_error = ?,
                           check_id = ?,
                           check_level = ?,
                           check_classify = ?,
                           status = ?,
                           update_by = ?,
                           update_date = sysdate
                     where id=?";
            }
        }
        /// <summary>
        /// 新增审核脚本
        /// </summary>
        public static string SqlAddCheckScript
        {
            get
            {
                return @"insert into hm_check_script
                      (id, cs_no, cs_text, cs_error, check_id, check_level, check_classify, status, creater_by, creater_date)
                    values
                      (hm_check_script_seq.nextval, ?, ?, ?, ?, ?, ?, '1', ?, sysdate)";
            }
        }
        /// <summary>
        /// 查询出审核类型
        /// </summary>
        public static string SqlQueryCheckType
        {
            get
            {
                return @"select * from GM_CODE t
                        where t.code_type='check_type'";
            }
        }
        /// <summary>
        /// 查询病人视图，获得出院病人信息（根据时间）
        /// </summary>
        public static string SqlQueryPatient
        {
            get
            {
                return @"select * from HQMS_PATIENT_INFO t where t.input_date between ? and ?";
                //                return @"select * from hqms_patient_info t
                //                        where t.input_date between To_Date(?, 'yyyy-mm-dd hh24:mi:ss')
                //                        and To_Date(?, 'yyyy-mm-dd hh24:mi:ss')";
            }
        }
        /// <summary>
        /// 获得本地库出院病人信息（根据入病案时间）
        /// </summary>
        public static string SqlQueryMyPatientByDate
        {
            get
            {
                return @"select * from ht_hqms_master t where t.input_date between ? and ?";
            }
        }
        /// <summary>
        /// 根据病案号和住院次数在本地库中查询是否有此病人
        /// </summary>
        public static string SqlQueryMyPatient
        {
            get
            {
                return @"select * from HT_HQMS_MASTER t
                        where t.p3=? and t.p2=?";
            }
        }
        /// <summary>
        /// 根据病案号和住院次数在视图中查询是否有此病人
        /// </summary>
        public static string SqlQueryPatientInView
        {
            get
            {
                return @"select * from TMP_HQMS_MASTER
                        where p3=? and p2=? {0} ";
            }
        }
        /// <summary>
        /// 将上报成功的病案插入主表
        /// </summary>
        public static string SqlInsertPatientReport
        {
            get
            {
                return @"insert into ht_hqms_master
                      (p900, p6891, p686, p800, p1, p2, p3, p4, p5, p6, p7, p8, p9, p101, p102, p103, p11, p12, p13, p801, p802, p803, p14, p15, p16, p17, p171, p18, p19, p20, p804, p21, p22, p23, p231, p24, p25, p26, p261, p27, p28, p281, p29, p30, p301, p31, p321, p322, p805, p323, p324, p325, p806, p326, p327, p328, p807, p329, p3291, p3292, p808, p3293, p3294, p3295, p809, p3296, p3297, p3298, p810, p3299, p3281, p3282, p811, p3283, p3284, p3285, p812, p3286, p3287, p3288, p813, p3289, p3271, p3272, p814, p3273, p3274, p3275, p815, p3276, p689, p351, p352, p816, p353, p354, p817, p355, p356, p818, p361, p362, p363, p364, p365, p366, p371, p372, p38, p39, p40, p411, p412, p413, p414, p415, p421, p422, p687, p688, p431, p432, p433, p434, p819, p435, p436, p437, p438, p44, p45, p46, p47, p490, p491, p820, p492, p493, p494, p495, p496, p497, p498, p4981, p499, p4910, p4911, p4912, p821, p4913, p4914, p4915, p4916, p4917, p4918, p4919, p4982, p4920, p4921, p4922, p4923, p822, p4924, p4925, p4526, p4527, p4528, p4529, p4530, p4983, p4531, p4532, p4533, p4534, p823, p4535, p4536, p4537, p4538, p4539, p4540, p4541, p4984, p4542, p4543, p4544, p4545, p824, p4546, p4547, p4548, p4549, p4550, p4551, p4552, p4985, p4553, p4554, p45002, p45003, p825, p45004, p45005, p45006, p45007, p45008, p45009, p45010, p45011, p45012, p45013, p45014, p45015, p826, p45016, p45017, p45018, p45019, p45020, p45021, p45022, p45023, p45024, p45025, p45026, p45027, p827, p45028, p45029, p45030, p45031, p45032, p45033, p45034, p45035, p45036, p45037, p45038, p45039, p828, p45040, p45041, p45042, p45043, p45044, p45045, p45046, p45047, p45048, p45049, p45050, p45051, p829, p45052, p45053, p45054, p45055, p45056, p45057, p45058, p45059, p45060, p45061, p561, p562, p563, p564, p6911, p6912, p6913, p6914, p6915, p6916, p6917, p6918, p6919, p6920, p6921, p6922, p6923, p6924, p6925, p57, p58, p581, p60, p611, p612, p613, p59, p62, p63, p64, p651, p652, p653, p654, p655, p656, p66, p681, p682, p683, p684, p685, p67, p731, p732, p733, p734, p72, p830, p831, p741, p742, p743, p782, p751, p752, p754, p755, p756, p757, p758, p759, p760, p761, p762, p763, p764, p765, p767, p768, p769, p770, p771, p772, p773, p774, p775, p776, p777, p778, p779, p780, p781, check_state, report_state,INPUT_DATE)
                    values
                      (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, '0', '1',?)";
            }
        }
        /// <summary>
        /// 将审核通过的病案插入主表中
        /// </summary>
        public static string SqlInsertPatientCheck
        {
            get
            {
                return @"insert into ht_hqms_master
                      (p900, p6891, p686, p800, p1, p2, p3, p4, p5, p6, p7, p8, p9, p101, p102, p103, p11, p12, p13, p801, p802, p803, p14, p15, p16, p17, p171, p18, p19, p20, p804, p21, p22, p23, p231, p24, p25, p26, p261, p27, p28, p281, p29, p30, p301, p31, p321, p322, p805, p323, p324, p325, p806, p326, p327, p328, p807, p329, p3291, p3292, p808, p3293, p3294, p3295, p809, p3296, p3297, p3298, p810, p3299, p3281, p3282, p811, p3283, p3284, p3285, p812, p3286, p3287, p3288, p813, p3289, p3271, p3272, p814, p3273, p3274, p3275, p815, p3276, p689, p351, p352, p816, p353, p354, p817, p355, p356, p818, p361, p362, p363, p364, p365, p366, p371, p372, p38, p39, p40, p411, p412, p413, p414, p415, p421, p422, p687, p688, p431, p432, p433, p434, p819, p435, p436, p437, p438, p44, p45, p46, p47, p490, p491, p820, p492, p493, p494, p495, p496, p497, p498, p4981, p499, p4910, p4911, p4912, p821, p4913, p4914, p4915, p4916, p4917, p4918, p4919, p4982, p4920, p4921, p4922, p4923, p822, p4924, p4925, p4526, p4527, p4528, p4529, p4530, p4983, p4531, p4532, p4533, p4534, p823, p4535, p4536, p4537, p4538, p4539, p4540, p4541, p4984, p4542, p4543, p4544, p4545, p824, p4546, p4547, p4548, p4549, p4550, p4551, p4552, p4985, p4553, p4554, p45002, p45003, p825, p45004, p45005, p45006, p45007, p45008, p45009, p45010, p45011, p45012, p45013, p45014, p45015, p826, p45016, p45017, p45018, p45019, p45020, p45021, p45022, p45023, p45024, p45025, p45026, p45027, p827, p45028, p45029, p45030, p45031, p45032, p45033, p45034, p45035, p45036, p45037, p45038, p45039, p828, p45040, p45041, p45042, p45043, p45044, p45045, p45046, p45047, p45048, p45049, p45050, p45051, p829, p45052, p45053, p45054, p45055, p45056, p45057, p45058, p45059, p45060, p45061, p561, p562, p563, p564, p6911, p6912, p6913, p6914, p6915, p6916, p6917, p6918, p6919, p6920, p6921, p6922, p6923, p6924, p6925, p57, p58, p581, p60, p611, p612, p613, p59, p62, p63, p64, p651, p652, p653, p654, p655, p656, p66, p681, p682, p683, p684, p685, p67, p731, p732, p733, p734, p72, p830, p831, p741, p742, p743, p782, p751, p752, p754, p755, p756, p757, p758, p759, p760, p761, p762, p763, p764, p765, p767, p768, p769, p770, p771, p772, p773, p774, p775, p776, p777, p778, p779, p780, p781, check_state, report_state,INPUT_DATE)
                    values
                      (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, '1', '0',?)";
            }
        }
        /// <summary>
        /// 修改病人审核状态为审核通过
        /// </summary>
        public static string SqlUpdatePatientCheckState
        {
            get
            {
                return @"update ht_hqms_master t
                       set t.check_state = '1'
                     where t.p3=? and t.p2=?";
            }
        }
        /// <summary>
        /// 修改病人上报状态为上报成功
        /// </summary>
        public static string SqlUpdatePatientReportState
        {
            get
            {
                return @"update ht_hqms_master t
                       set t.REPORT_STATE = '1'
                     where t.p3=? and t.p2=?";
            }
        }
        /// <summary>
        /// 删除临时表中数据
        /// </summary>
        public static string SqlDeleteTable
        {
            get
            {
                return @"delete TMP_HQMS_MASTER ";
            }
        }
        /// <summary>
        /// 插入临时表
        /// </summary>
        public static string SqlInsertInTimeTable
        {
            get
            {
                return @"insert into TMP_HQMS_MASTER
                      (p900, p6891, p686, p800, p1, p2, p3, p4, p5, p6, p7, p8, p9, p101, p102, p103, p11, p12, p13, p801, p802, p803, p14, p15, p16, p17, p171, p18, p19, p20, p804, p21, p22, p23, p231, p24, p25, p26, p261, p27, p28, p281, p29, p30, p301, p31, p321, p322, p805, p323, p324, p325, p806, p326, p327, p328, p807, p329, p3291, p3292, p808, p3293, p3294, p3295, p809, p3296, p3297, p3298, p810, p3299, p3281, p3282, p811, p3283, p3284, p3285, p812, p3286, p3287, p3288, p813, p3289, p3271, p3272, p814, p3273, p3274, p3275, p815, p3276, p689, p351, p352, p816, p353, p354, p817, p355, p356, p818, p361, p362, p363, p364, p365, p366, p371, p372, p38, p39, p40, p411, p412, p413, p414, p415, p421, p422, p687, p688, p431, p432, p433, p434, p819, p435, p436, p437, p438, p44, p45, p46, p47, p490, p491, p820, p492, p493, p494, p495, p496, p497, p498, p4981, p499, p4910, p4911, p4912, p821, p4913, p4914, p4915, p4916, p4917, p4918, p4919, p4982, p4920, p4921, p4922, p4923, p822, p4924, p4925, p4526, p4527, p4528, p4529, p4530, p4983, p4531, p4532, p4533, p4534, p823, p4535, p4536, p4537, p4538, p4539, p4540, p4541, p4984, p4542, p4543, p4544, p4545, p824, p4546, p4547, p4548, p4549, p4550, p4551, p4552, p4985, p4553, p4554, p45002, p45003, p825, p45004, p45005, p45006, p45007, p45008, p45009, p45010, p45011, p45012, p45013, p45014, p45015, p826, p45016, p45017, p45018, p45019, p45020, p45021, p45022, p45023, p45024, p45025, p45026, p45027, p827, p45028, p45029, p45030, p45031, p45032, p45033, p45034, p45035, p45036, p45037, p45038, p45039, p828, p45040, p45041, p45042, p45043, p45044, p45045, p45046, p45047, p45048, p45049, p45050, p45051, p829, p45052, p45053, p45054, p45055, p45056, p45057, p45058, p45059, p45060, p45061, p561, p562, p563, p564, p6911, p6912, p6913, p6914, p6915, p6916, p6917, p6918, p6919, p6920, p6921, p6922, p6923, p6924, p6925, p57, p58, p581, p60, p611, p612, p613, p59, p62, p63, p64, p651, p652, p653, p654, p655, p656, p66, p681, p682, p683, p684, p685, p67, p731, p732, p733, p734, p72, p830, p831, p741, p742, p743, p782, p751, p752, p754, p755, p756, p757, p758, p759, p760, p761, p762, p763, p764, p765, p767, p768, p769, p770, p771, p772, p773, p774, p775, p776, p777, p778, p779, p780, p781, check_state, report_state,INPUT_DATE)
                    values
                      (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, '0', '0',?)";
            }
        }
        /// <summary>
        /// 主表和临时表关联，查出需要审核的病案
        /// </summary>
        public static string SqlQueryTempData
        {
            get
            {
                return @"select t.* from TMP_HQMS_MASTER t where not exists (select * from ht_hqms_master ht
                        where t.p2=ht.p2 and t.p3=ht.p3)";
            }
        }
    }
}
