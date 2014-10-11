using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Models
{
    /// <summary>
    /// SQL语句定义
    /// </summary>
    public class SqlTools
    {
        #region 用户操作SQL
        /// <summary>
        /// 根据用户名和密码查询用户
        /// </summary>
        public static string SqlQueryUser
        {
            get
            {
                return @"SELECT * FROM gm_user t WHERE t.user_no=:1 and t.user_pwd=:2 and t.status=9";
            }
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        public static string SqlInsertUser
        {
            get
            {
                return @"insert into gm_user(user_id,user_no,user_name,user_gender,user_phone,user_workunit,create_by,user_image,user_sign,status,user_name_spell) 
                        values(nextval('gm_user_user_id_seq'),:1,:2,:3,:4,:5,:6,:7,:8,:9,:10)";
            }
        }
        /// <summary>
        /// 获得所有用户
        /// </summary>
        public static string SqlSelectAllUser
        {
            get
            {
                return @"SELECT b.*,d.code_name gender,e.user_name create_name,f.code_name user_status from gm_user b 
                        LEFT OUTER JOIN gm_user e 
                        on b.create_by=e.user_id,gm_code d,gm_code f
                        WHERE  b.user_gender=d.code_id 
						and b.status=f.code_id";
            }
        }
        /// <summary>
        /// 根据用户id获得其所有信息
        /// </summary>
        public static string SqlSelectUserByUserID
        {
            get
            {
                return @"SELECT b.*,d.code_name gender,e.user_name create_name,f.code_name user_status from gm_user b 
                        LEFT OUTER JOIN gm_user e 
                        on b.create_by=e.user_id,gm_code d,gm_code f
                        WHERE  b.user_gender=d.code_id 
						and b.status=f.code_id 
                        and b.user_id=:1";
            }
        }
        /// <summary>
        /// 获得用户状态信息
        /// </summary>
        public static string SqlSelectUserStatus
        {
            get
            {
                return @"SELECT * from gm_code b WHERE b.code_type='user_status'
                        and b.status='1'";
            }
        }
        /// <summary>
        /// 根据用户id删除用户
        /// </summary>
        public static string SqlDeleteUserByUserID
        {
            get
            {
                return @"UPDATE gm_user SET status=10,update_by=:1,update_date=now()
                        WHERE user_id=:2";
            }
        }
        /// <summary>
        /// 重置用户密码
        /// </summary>
        public static string SqlResetPasswordByUserID
        {
            get
            {
                return @"UPDATE gm_user SET user_pwd='8888',update_by=:1,update_date=now()
                        WHERE user_id=:2";
            }
        }
        /// <summary>
        /// 根据用户编号查询用户
        /// </summary>
        public static string SqlSelectUserByUserNO
        {
            get
            {
                return @"SELECT * FROM gm_user b where b.user_no=:1";
            }
        }
        /// <summary>
        /// 根据用户id修改用户基本信息
        /// </summary>
        public static string SqlUpdataUserByUserID
        {
            get
            {
                return @"UPDATE gm_user SET user_no=:1,user_name=:2,user_gender=:3,user_phone=:4,user_workunit=:5,status=:6,
                        {0} user_name_spell=:7,update_by=:8,update_date=now()
                        WHERE user_id=:9";
            }
        }
        
        #endregion

        #region 评估模板SQL
        /// <summary>
        /// 查询科室
        /// </summary>
        public static string SqlSelectDept
        {
            get
            {
                return @"select gd.dept_id,gd.dept_name from gm_dept gd";
            }
        }
        /// <summary>
        /// 查询性别
        /// </summary>
        public static string SqlSelectGender
        {
            get
            {
                return @"SELECT gc.code_id,gc.code_name,gc.code_type,gc.uc_code 
from gm_code gc
where gc.code_type = 'gender'
and gc.uc_code in ('1','3')";
            }
        }
        /// <summary>
        /// 查询所有模板内容
        /// </summary>
        public static string SqlSelectAssTem2
        {
            get
            {
                return @"SELECT eat.*,gc.code_name as gender,gd.dept_name
                           ,( CASE
		                        WHEN eat.status = '0' THEN
			                        '停用'
		                        ELSE
			                        '使用'
		                        END
	                        ) ass_tem_status
FROM et_assess_template eat,gm_code gc,gm_dept gd
WHERE eat.suit_gender = gc.code_id
and eat.suit_dept_id = gd.dept_id
and eat.status = '1'";
            }
        }
        /// <summary>
        /// 根据模板内容首拼、适用科室、适用性别查询模板
        /// </summary>
        public static string SqlSelectAssTem
        {
            get
            {
                return @"SELECT eat.*,gc.code_name as gender,gd.dept_name 
		                     ,( CASE
		                        WHEN eat.status = '0' THEN
			                        '停用'
		                        ELSE
			                        '使用'
		                        END
	                        ) ass_tem_status
FROM et_assess_template eat,gm_code gc,gm_dept gd
WHERE eat.suit_gender = gc.code_id
and eat.suit_dept_id = gd.dept_id
and eat.suit_dept_id = :1
and eat.suit_gender = :2 {0}";
            }
        }
        /// <summary>
        /// 将模板状态改为有效
        /// </summary>
        public static string SqlUpdateAssTemToValid
        {
            get
            {
                return @"update et_assess_template
set status = '1'
where assess_tem_id = :1";
            }
        }
        /// <summary>
        /// 将模板状态改为无效
        /// </summary>
        public static string SqlUpdateAssTemToInvalid
        {
            get
            {
                return @"update et_assess_template
set status = '0'
where assess_tem_id = :1";
            }
        }
        /// <summary>
        ///  取得模板内容的下一个Seq值
        /// </summary>
        public static string SqlSelectNextAssTemSeq
        {
            get
            {
                return @"SELECT nextval('et_assess_template_assess_tem_id_seq')";
            }
        }
        /// <summary>
        /// 判断模板Id是否存在模板表中
        /// </summary>
        public static string SqlSelectAssTemId
        {
            get
            {
                return @"select eat.assess_tem_id
from et_assess_template eat
where eat.assess_tem_id = :1";
            }
        }
        /// <summary>
        /// 新增模板
        /// </summary>
        public static string SqlInsertAssTem
        {
            get
            {
                return @"insert into et_assess_template
values
(:1,:2,:3,:4,:5,null,:6,'1',:7,now())";
            }
        }
        /// <summary>
        /// 修改模板
        /// </summary>
        public static string SqlUpdateAssTem
        {
            get
            {
                return @"update et_assess_template
set assess_tem_content =:1
		,suit_dept_id =:2
		,suit_gender = :3
		,assess_tem_py = :4
		,remark = :5
		,update_by =:6
		,update_date = now()
where assess_tem_id =:7";
            }
        }
        #endregion

        #region 智能评估SQL
        /// <summary>
        /// 查询科室/项目列表
        /// </summary>
        public static string SqlSelectDeptPro
        {
            get
            {
                return @" SELECT  --科室：一级父节点
  	                            dept.dept_id key_id,
	                              dept.dept_name display_name,
  	                            dept.dept_id parent_id,
                                dept.dept_first_pinyin py
                              FROM
  	                            gm_dept dept
                            UNION
	                            SELECT  --项目：二级子节点（所属科室置为父，parent_id为空）
		                            pro.pro_id key_id,
		                            pro.pro_name display_name,
		                            pro.dept_id parent_id,
                                    pro_first_pinyin py
	                            FROM
		                            gm_project pro
	                            WHERE
		                            pro.parent_id IS NULL
                            UNION
	                            SELECT --项目：三级子节点（parent_id所存数据为父节点）
		                            pro.pro_id key_id,
		                            pro.pro_name display_name,
		                            pro.parent_id parent_id,
									pro_first_pinyin py
	                            FROM
		                            gm_project pro
	                            WHERE
		                            pro.parent_id IS NOT NULL";
            }
        }
        /// <summary>
        /// 查询评估列表
        /// </summary>
        public static string SqlSelectInteAss
        {
            get
            {
                return @"select eia.*,gc.code_name,eia.assess_tem
,( CASE
		                        WHEN eia.status = '0' THEN
			                        '停用'
		                        ELSE
			                        '使用'
		                        END
	                        ) inte_ass_status
from et_intelligent_assess eia,gm_code gc
where eia.suit_gender = gc.code_id";
            }
        }
        /// <summary>
        /// 将评估改为有效
        /// </summary>
        public static string SqlUpdateInteAssToValid
        {
            get
            {
                return @"update et_intelligent_assess
set status = '1'
where inte_assess_id = :1";
            }
        }
        /// <summary>
        /// 将评估改为无效
        /// </summary>
        public static string SqlUpdateInteAssToInvalid
        {
            get
            {
                return @"update et_intelligent_assess
set status = '0'
where inte_assess_id = :1";
            }
        }
        /// <summary>
        ///  取得评估的下一个Seq值
        /// </summary>
        public static string SqlSelectNextInteAssSeq
        {
            get
            {
                return @"SELECT nextval('et_inte_assess_rule_assess_rule_id_seq')";
            }
        }
        /// <summary>
        /// 判断评估Id是否存在评估表中
        /// </summary>
        public static string SqlSelectInteAssId
        {
            get
            {
                return @"select eia.inte_assess_id
from et_intelligent_assess eia
where eia.inte_assess_id = :1";
            }
        }
        /// <summary>
        /// 新增评估
        /// </summary>
        public static string SqlInsertInteAss
        {
            get
            {
                return @"insert into et_intelligent_assess
(inte_assess_id,inte_assess_name,suit_gender,suit_min_age,suit_max_age,assess_tem,inte_assess_py,remark,status,create_by,create_date)
values
(:1,:2,:3,:4,:5,:6,:7,:8,'1',:9,now())";
            }
        }
        /// <summary>
        /// 修改评估
        /// </summary>
        public static string SqlUpdateInteAss
        {
            get
            {
                return @"update et_intelligent_assess
set inte_assess_name =:1
		,suit_gender = :2
		,suit_min_age = :3
		,suit_max_age =:4
		,assess_tem = :5
		,inte_assess_py = :6
		,remark = :7
		,update_by =:8
		,update_date = now()
where inte_assess_id =:9";
            }
        }
        #endregion

        #region 预约登记

        #region 科室设置
        /// <summary>
        /// 插入科室表
        /// </summary>
        public static string SqlInsertDept
        {
            get
            {
                return @"INSERT INTO gm_dept
                        VALUES
	                        (
		                        nextval('gm_dept_dept_id_seq'),
		                        :1,
		                        :2,
		                        :3,
		                        :4,
		                        :5,
		                        :6,
		                        '1',
		                        :7,
		                        CURRENT_TIMESTAMP,
		                        :8,
		                        CURRENT_TIMESTAMP)";
            }
        }

        /// <summary>
        ///  从sequence中取得科室下一个排序号
        /// </summary>
        public static string SqlSelectDeptNextSortNoSeq
        {
            get
            {
                return @"SELECT nextval('gm_dept_sort_no_seq')";
            }
        }

        /// <summary>
        /// 从科室类别表（gm_dept_type）中获取科室类别
        /// </summary>
        public static string SqlSelectDeptType
        {
            get
            {
                return @"SELECT
	                        dept_type_id,
	                        dept_type_name
                        FROM
	                        gm_dept_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 初始化时查询科室信息
        /// </summary>
        public static string SqlSelectGridDept
        {
            get
            {
                return @"SELECT
	                        *, (
		                        CASE
		                        WHEN status = '0' THEN
			                        '停用'
		                        ELSE
			                        '使用'
		                        END
	                        ) dept_status
                        FROM
	                        gm_dept_dept_type_view
                        ORDER BY
	                        sort_no ";
            }
        }

        /// <summary>
        /// 修改科室
        /// </summary>
        public static string SqlUpdateDeptBySelect
        {
            get
            {
                return @"UPDATE gm_dept
                        SET dept_name =:1,
                            sort_no =:2,
                            dept_type =:3,
                            dept_english_name =:4,
                            dept_first_pinyin =:5,
                            remark =:6,
                            update_by =:7,
                            update_date = CURRENT_TIMESTAMP
                        WHERE
	                        dept_id =:8";
            }
        }

        /// <summary>
        /// 停用所选科室
        /// </summary>
        public static string SqlUpdateDeptByStop
        {
            get
            {
                return @"UPDATE gm_dept
                        SET status = '0'
                        WHERE
	                        dept_id =:1";
            }
        }

        /// <summary>
        /// 条件搜索
        /// </summary>
        public static string SqlSelectBySearch
        {
            get
            {
                return @"SELECT
	                        *, (
		                        CASE
		                        WHEN status = '0' THEN
			                        '停用'
		                        ELSE
			                        '使用'
		                        END
	                        ) dept_status
                        FROM
	                        gm_dept_dept_type_view
                        WHERE
	                        (
		                        dept_name LIKE :1
                                OR CAST ('sort_no' AS VARCHAR) LIKE :2
		                        OR dept_english_name LIKE :3
		                        OR dept_first_pinyin LIKE :4
		                        OR CAST ('dept_type' AS VARCHAR) LIKE :5
	                        )
                        AND status IN ('{0}')
                        ORDER BY
	                        sort_no";
            }
        }
        #endregion

        #region 项目设置
        /// <summary>
        /// 查询科室信息名称(绑定treeList)
        /// </summary>
        public static string SqlSelectDeptProBindTree
        {
            get
            {
                return @"SELECT
	                        --科室：一级父节点
	                        dept.dept_id key_id,
	                        dept.dept_name display_name,
	                        dept.dept_id parent_id,
	                        dept.dept_id dept_id
                        FROM
	                        gm_dept dept
                        UNION
	                        SELECT
		                        --项目：二级子节点（所属科室置为父，parent_id和dept_id相等）
		                        pro.pro_id key_id,
		                        pro.pro_name display_name,
		                        pro.dept_id parent_id,
		                        pro.dept_id
	                        FROM
		                        gm_project pro
	                        WHERE
		                        pro.parent_id = pro.dept_id
	                        UNION
		                        SELECT
			                        --项目：三级子节点（科室ID和项目ID不同）
			                        pro.pro_id key_id,
			                        pro.pro_name display_name,
			                        pro.parent_id parent_id,
			                        pro.dept_id
		                        FROM
			                        gm_project pro
		                        WHERE
			                        pro.parent_id != pro.dept_id";
            }
        }

        /// <summary>
        /// 插入项目表
        /// </summary>
        public static string SqlInsertProject
        {
            get
            {
                return @"INSERT INTO gm_project
                        VALUES
	                        (
		                        nextval('gm_project_pro_id_seq') ,:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,:16,:17,
                                :18,:19,:20,:21,:22,:23,:24,:25,:26,:27,:28,:29,:30,:31,:32,:33,:34,:35,:36,:37,:38,:39,
                                :40,:41,:42,:43,:44,:45,:46,:47,
                                '1',
		                        :48,
                                CURRENT_TIMESTAMP,
		                        :49,
                                CURRENT_TIMESTAMP
	                        )";
            }
        }

        /// <summary>
        ///  查询项目表信息,绑定Grid
        /// </summary>
        public static string SqlSelectBindGridProFromProject
        {
            get
            {
                return @"SELECT * FROM gm_project_view where dept_id=:1";
            }
        }

        /// <summary>
        /// 取得项目表下一个排序号
        /// </summary>
        public static string SqlSelectNextProjectSortNo
        {
            get
            {
                return @"SELECT nextval('gm_project_sort_no_seq')";
            }
        }

        /// <summary>
        /// 插入控件预设值表
        /// </summary>
        public static string SqlInsertControlDefault
        {
            get
            {
                return @"INSERT INTO gm_controls_default
                        VALUES
	                        (
                                :1 ,:2 ,:3 ,:4,
		                        '1',
                                :5,
		                        CURRENT_TIMESTAMP ,
                                :6,
		                        CURRENT_TIMESTAMP
	                        )";
            }
        }

        /// <summary>
        /// 加载项目对应的控件预设值
        /// </summary>
        public static string SqlSelectControlsDefaultByProId
        {
            get
            {
                return @"SELECT
	                        control_default_id,control_default_name,pro_id,is_checked
                        FROM
	                        gm_controls_default
                        WHERE
	                        pro_id =:1
                        AND status = '1'";
            }
        }

        /// <summary>
        /// 根据Id删除控件预设值
        /// </summary>
        public static string SqlDeleteControlsDefaultById
        {
            get
            {
                return @"UPDATE gm_controls_default
                        SET status = '0'
                        WHERE
	                        control_default_id =:1";
            }
        }

        /// <summary>
        /// 根据Id修改控件预设值勾选状态
        /// </summary>
        public static string SqlUpdateControlDefaultCheckedStatusById
        {
            get
            {
                return @"UPDATE gm_controls_default
                        SET is_checked =:1
                        WHERE
	                        control_default_id =:2";
            }
        }

        /// <summary>
        /// 查询控件预设值表流水号
        /// </summary>
        public static string SqlSelectControlDefaultSeq
        {
            get
            {
                return @"select nextval('gm_controls_default_control_id_seq')";
            }
        }

        /// <summary>
        /// 修改项目表
        /// </summary>
        public static string SqlUpdateProject
        {
            get
            {
                return @"UPDATE gm_project
                        SET pro_name =:1,
                         pro_first_pinyin =:2,
                         pro_english_name =:3,
                         pro_type =:4,
                         common_project_type =:5,
                         default_value =:6,
                         unit_measurement =:7,
                         apply_gender =:8,
                         cost_type =:9,
                         control_type =:10,
                         control_value =:11,
                         control_type_width =:12,
                         is_input_pro =:13,
                         is_fee_pro =:14,
                         is_before_meal =:15,
                         sms_set =:16,
                         is_read_data_direct =:17,
                         reference_price =:18,
                         execute_price =:19,
                         is_numerical_pro =:20,
                         species_type =:21,
                         is_sum_must =:22,
                         reference_ceiling_mail =:23,
                         reference_ceiling_femail =:24,
                         reference_ceiling_prompt =:25,
                         reference_lower_mail =:26,
                         reference_lower_femail =:27,
                         reference_lower_prompt =:28,
                         alarm_ceiling_mail =:29,
                         alarm_ceiling_femail =:30,
                         alarm_ceiling_prompt =:31,
                         alarm_lower_mail =:32,
                         alarm_lower_femail =:33,
                         alarm_lower_prompt =:34,
                         update_by =:35,
                         update_date =CURRENT_TIMESTAMP
                        WHERE
	                        pro_id =:36";
            }
        }

        /// <summary>
        /// 停用所选项目
        /// </summary>
        public static string SqlUpdateProjectByStop
        {
            get
            {
                return @"update gm_project set status='0' where pro_id=:1";
            }
        }

        /// <summary>
        /// 启用所选项目
        /// </summary>
        public static string SqlUpdateProjectByReStart
        {
            get
            {
                return @"update gm_project set status='1' where pro_id=:1";
            }
        }


        /// <summary>
        /// 查询项目状态（启用或者停用）
        /// </summary>
        public static string SqlSelectProStatusByProId
        {
            get
            {
                return @"SELECT status FROM gm_project WHERE pro_id =:1";
            }
        }

        #region 类别下拉查询
        /// <summary>
        /// 从项目类别表（gm_project_type）中获取科室类别
        /// </summary>
        public static string SqlSelectProjectType
        {
            get
            {
                return @"SELECT
	                        pro_type_id,
	                        pro_type_name
                        FROM
	                        gm_project_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 短信设置下拉查询
        /// </summary>
        public static string SqlSelectSmsSet
        {
            get
            {
                return @"SELECT
	                        sms_set_id,
	                        sms_set_name
                        FROM
	                        gm_sms_set
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 餐前项目下拉绑定
        /// </summary>
        public static string SqlSelectBeforeMeal
        {
            get
            {
                return @"SELECT
	                        is_before_meal_id,
	                        is_before_meal_name
                        FROM
	                        gm_before_meal
                        where status='1'";
            }
        }

        /// <summary>
        /// 绑定下拉性别
        /// </summary>
        public static string SqlSelectApplyGender
        {
            get
            {
                return @"SELECT
	                        code_id,
	                        code_name
                        FROM
	                        gm_code
                        WHERE
	                        code_type = 'gender'
                        AND status = '1'";
            }
        }

        /// <summary>
        /// 绑定下拉费用归类
        /// </summary>
        public static string SqlSelectCostType
        {
            get
            {
                return @"SELECT
	                        cost_type_id,
	                        cost_type_name
                        FROM
	                        gm_cost_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 绑定下拉标本种类
        /// </summary>
        public static string SqlSelectSpeciesType
        {
            get
            {
                return @"SELECT
	                        species_type_id,
	                        species_type_name
                        FROM
	                        gm_species_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 绑定下拉计量单位
        /// </summary>
        public static string SqlSelectUnitMeasurement
        {
            get
            {
                return @"SELECT
	                        unit_id,
	                        unit_name
                        FROM
	                        gm_unit_measurement
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 绑定下拉常用项目类别
        /// </summary>
        public static string SqlSelectCommonProType
        {
            get
            {
                return @"SELECT
	                        common_pro_type_id,
	                        common_pro_type_name
                        FROM
	                        gm_common_project_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 绑定下拉控件类型
        /// </summary>
        public static string SqlSelectControlType
        {
            get
            {
                return @"SELECT
	                        control_id,
	                        control_name
                        FROM
	                        em_controls
                        WHERE
	                        status = '1'";
            }
        }

        #endregion
        #endregion

        #region 单位维护
        /// <summary>
        /// 查询上级单位
        /// </summary>
        public static string SqlSelectHigherIns
        {
            get
            {
                return @"SELECT
	                        ins_id,
	                        ins_name
                        FROM
	                        gm_institution_info
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 查询单位性质名称
        /// </summary>
        public static string SqlSelectInsType
        {
            get
            {
                return @"SELECT
	                        ins_type_id,
	                        ins_type_name
                        FROM
	                        gm_institution_type
                        WHERE
	                        status = '1'";
            }
        }

        /// <summary>
        /// 插入单位表
        /// </summary>
        public static string SqlInsertInstitution
        {
            get
            {
                return @"INSERT INTO gm_institution_info
                        VALUES
	                        (
		                        nextval('gm_institution_info_ins_id_seq') ,:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,
                                :11,:12,:13,:14,:15,:16,
                                '1',
                                :17,
                                CURRENT_TIMESTAMP,
                                :18,
                                CURRENT_TIMESTAMP
	                         )";
            }
        }

        /// <summary>
        /// 查询单位信息绑定Grid
        /// </summary>
        public static string SqlSelectInstitutionBindGrid
        {
            get
            {
                return @"select * from gm_institution_info_view";
            }
        }

        /// <summary>
        /// 根据ID修改单位信息
        /// </summary>
        public static string SqlUpdateInstitutionById
        {
            get
            {
                return @"UPDATE gm_institution_info
                        SET ins_name =:1,
                         ins_type =:2,
                         higher_level_id =:3,
                         ins_first_pinyin =:4,
                         ins_addr =:5,
                         ins_phone =:6,
                         ins_fax =:7,
                         ins_postcode =:8,
                         ins_num =:9,
                         contact_name =:10,
                         contact_dept =:11,
                         contact_phone =:12,
                         contact_mobile_phone =:13,
                         contact_fax =:14,
                         contact_email =:15,
                         remark =:16,
                         update_by =:17,
                         update_date = CURRENT_TIMESTAMP
                        WHERE
	                        ins_id =:18";
            }
        }
        #endregion

        #endregion
    }
}
