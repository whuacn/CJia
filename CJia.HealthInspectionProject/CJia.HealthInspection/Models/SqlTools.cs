using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    /// <summary>
    /// SQL语句定义
    /// </summary>
    public class SqlTools
    {

        #region 用户管理
        /// <summary>
        /// 登陆
        /// </summary>
        public static string SqlQueryUser
        {
            get
            {
                return @"select gu.*, gor.organ_no, gor.organ_name
                          from gm_user gu, gm_organ gor
                         where gu.status = '1'
                           and gu.organ_id = gor.organ_id(+)
                           and gu.user_no = ?
                           and gu.user_pwd = ?";
            }
        }
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
        /// 查询某个用户不存在的功能
        /// </summary>
        public static string SqlQueryLoginUserOwnFunction
        {
            get
            {
                return @" select tf.function_id, tf.function_name, tf.parent_id
                                  from tm_function      tf,
                                       tr_user_role     tur,
                                       tr_role_function trf,
                                       tm_role          tr
                                 where tf.function_id = trf.function_id
                                   and tr.role_id = tur.role_id
                                   and tur.role_id = trf.role_id
                                   and trf.status = '1'
                                   and tur.status = '1'
                                   and tur.user_id = ?";
            }
        }
        #endregion

        #region 单位管理
        /// <summary>
        /// 查询单位
        /// </summary>
        public static string SqlQueryUnit
        {
            get
            {
                return @"select * from st_unit where STATUS='1' and organ_id=?";
            }
        }
        /// <summary>
        /// 添加单位
        /// </summary>
        public static string SqlAddUnit
        {
            get
            {
                return @"insert into st_unit
                  (unit_id,
                   unit_name,
                   unit_address,
                   unit_code,
                   legal_person,
                   legal_license_no,
                   legal_license_type,
                   responsible_person,
                   responsible_license_type,
                   responsible_license_no,
                   create_by,
                   lesence,
                   unit_type,
                   is_household,
                   household_type,
                   county,
                   register_address,
                   eco_type,
                   contact,
                   telephone,
                   postcode,
                   issue_name,
                   apply_type,
                   permit_data,
                   start_data,
                   end_data,
                   status,
                   organ_id)
                values
                  (st_unit_seq.nextval,
                   ?,?,?,?,?,?,?,?,?,?,
                   ?,?,?,?,?,?,?,?,?,?,
                   ?,?,?,?,?,
                   '1',
                   ?)";
            }
        }
        /// <summary>
        /// 获得类型(各种类型，gm_code)
        /// </summary>
        public static string SqlQueryType
        {
            get
            {
                return @"select * from gm_code cod where cod.code_type=?";
            }
        }

        /// <summary>
        /// 删除单位
        /// </summary>
        public static string SqlDeleteUnitById
        {
            get
            {
                return @"update st_unit set status='0',update_by=?,update_date=sysdate
                         where unit_id=?";
            }
        }

        /// <summary>
        /// 查询单位信息
        /// </summary>
        public static string SqlQueryUnitBySearch
        {
            get
            {
                return @"select unit_id,
                           unit_name,
                           unit_address,
                           unit_code,
                           legal_person,
                           legal_license_no,
                           legal_license_type,
                           (select gc.name from gm_code gc where gc.code = legal_license_type) legal_license_type_name,
                           responsible_person,
                           responsible_license_type,
                           (select gc.name
                              from gm_code gc
                             where gc.code = responsible_license_type) responsible_license_type_name,
                           responsible_license_no,
                           create_by,
                           create_date,
                           update_by,
                           update_date,
                           lesence,
                           unit_type,
                           (select gc.name from gm_code gc where gc.code = unit_type) unit_type_name,
                           is_household,
                           household_type,
                           (select gc.name from gm_code gc where gc.code = household_type) household_type_name,
                           county,
                           register_address,
                           eco_type,
                           (select gc.name from gm_code gc where gc.code = eco_type) eco_type_name,
                           contact,
                           telephone,
                           postcode,
                           issue_name,
                           apply_type,
                           (select gc.name from gm_code gc where gc.code = apply_type) apply_type_name,
                           permit_data,
                           start_data,
                           end_data,
                           status,
                           organ_id
                      from st_unit where organ_id=? and status='1'";
            }
        }

        /// <summary>
        /// 根据类型查询code表
        /// </summary>
        public static string SqlQueryTypeFromCode
        {
            get
            {
                return @"select * from gm_code where code_type=?";
            }
        }

        /// <summary>
        /// 根据单位ID查询单位信息
        /// </summary>
        public static string SqlQueryUnitInfoByUnitId
        {
            get
            {
                return @"select su.* from st_unit su where su.unit_id=? and su.status='1'";
            }
        }

        /// <summary>
        /// 根据单位Id修改单位信息
        /// </summary>
        public static string SqlUpdateUnitByUnitId
        {
            get
            {
                return @"update st_unit
                        set unit_name                = ?,
                            unit_address             = ?,
                            unit_code                = ?,
                            legal_person             = ?,
                            legal_license_no         = ?,
                            legal_license_type       = ?,
                            responsible_person       = ?,
                            responsible_license_type = ?,
                            responsible_license_no   = ?,
                            lesence                  = ?,
                            unit_type                = ?,
                            is_household             = ?,
                            household_type           = ?,
                            county                   = ?,
                            register_address         = ?,
                            eco_type                 = ?,
                            contact                  = ?,
                            telephone                = ?,
                            postcode                 = ?,
                            issue_name               = ?,
                            apply_type               = ?,
                            permit_data              = ?,
                            start_data               = ?,
                            end_data                 = ?,
                            update_by                = ?,
                            update_date              = sysdate
                      where unit_id = ?";
            }
        }
        #endregion

        #region 题目管理
        /// <summary>
        /// 查询模板大分类
        /// </summary>
        public static string SqlQueryBigTemplate
        {
            get
            {
                return @"select * from gm_big_template_type big where big.status='1'";
            }
        }
        /// <summary>
        /// 查询模板中分类
        /// </summary>
        public static string SqlQueryMiddleTemplate
        {
            get
            {
                return @"select * from gm_middle_template_type mid where mid.status='1' and mid.big_template_id=?";
            }
        }
        /// <summary>
        /// 查询模板小分类
        /// </summary>
        public static string SqlQuerySmallTemplate
        {
            get
            {
                return @"select * from gm_small_template_type sml where sml.status='1' and sml.middle_template_id=?";
            }
        }
        /// <summary>
        /// 获得检查题目表SEQ
        /// </summary>
        public static string SqlQueryCheckTitleSeq
        {
            get
            {
                return @"select gm_check_title_seq.nextval from dual";
            }
        }
        /// <summary>
        /// 新增检查题目
        /// </summary>
        public static string SqlAddCheckTitle
        {
            get
            {
                return @"insert into gm_check_title
                        (check_title_id, check_title_name, check_title_content, is_choice, status, create_by,create_date,organ_id)
                        values
                        (?, ?, ?, ?, '1', ?, sysdate,?)";
            }
        }
        /// <summary>
        /// 新增检查题目对应的答案
        /// </summary>
        public static string SqlAddCheckTitleAnswer
        {
            get
            {
                return @"insert into gm_check_title_answer
                      (answer_id, answer_name, check_title_id, status, create_by, check_result, advice,create_date)
                    values
                      (gm_check_title_answer_seq.nextval, ?, ?, '1', ?, ?, ?, sysdate)";
            }
        }
        /// <summary>
        /// 新增检查题目对应的模板小分类类型关系
        /// </summary>
        public static string SqlAddTrTemplatetypeChecktitle
        {
            get
            {
                return @"insert into tr_templatetype_checktitle
                      (id, small_template_id, check_title_id, status, create_by,create_date)
                    values
                      (tr_templatetype_checktitle_seq.nextval, ?, ?, '1', ?,sysdate)";
            }
        }
        /// <summary>
        /// 获得所有分类，父子关系
        /// </summary>
        public static string SqlQueryTemplateType
        {
            get
            {
                return @"select big.big_template_id   id,
                       big.big_template_name name,
                       null   parentID
                  from gm_big_template_type big
                 where big.status = '1'
                union
                select mid.middle_template_id   id,
                       mid.middle_template_name name,
                       big.big_template_id      parentid
                  from gm_middle_template_type mid, gm_big_template_type big
                 where mid.status = '1'
                   and big.status = '1'
                   and mid.big_template_id = big.big_template_id
                union
                select sml.small_template_id   id,
                       sml.small_template_name name,
                       mid.middle_template_id  parentID
                  from gm_small_template_type sml, gm_middle_template_type mid
                 where sml.status = '1'
                   and mid.status = '1'
                   and sml.middle_template_id = mid.middle_template_id";
            }
        }
//        /// <summary>
//        /// 根据不同分类获得检查题目
//        /// </summary>
//        public static string SqlQueryCheckTitle
//        {
//            get 
//            {
//                return @"select distinct tit.*,u.*
//                  from gm_check_title tit, tr_templatetype_checktitle tr,gm_user u
//                 WHERE tit.status = '1'
//                   and tr.status = '1'
//                   and tit.check_title_id = tr.check_title_id
//                   and tit.create_by=u.user_id
//                   and tr.small_template_id in
//                       (select sml.small_template_id
//                          from gm_big_template_type    big,
//                               gm_middle_template_type mid,
//                               gm_small_template_type  sml
//                         WHERE big.status = '1'
//                           and mid.status = '1'
//                           and sml.status = '1'
//                           and big.big_template_id = mid.big_template_id
//                           and mid.middle_template_id = sml.middle_template_id
//                           and (big.big_template_id = ? or
//                               mid.middle_template_id = ? or
//                               sml.small_template_id = ?))";
//            }
//        }
        /// <summary>
        /// 根据不同分类获得检查题目
        /// </summary>
        public static string SqlQueryCheckTitle
        {
            get 
            {
                return @"select distinct tit.*,u.*
                  from gm_check_title tit, tr_templatetype_checktitle tr,gm_user u
                 WHERE tit.status = '1'
                   and tr.status = '1'
                   and tit.check_title_id = tr.check_title_id
                   and tit.create_by=u.user_id
                   and tit.organ_id=?
                   and tr.small_template_id in
                       (select sml.small_template_id
                          from gm_big_template_type    big,
                               gm_middle_template_type mid,
                               gm_small_template_type  sml
                         WHERE big.status = '1'
                           and mid.status = '1'
                           and sml.status = '1'
                           and big.big_template_id = mid.big_template_id
                           and mid.middle_template_id = sml.middle_template_id
                           and (big.big_template_id = ? or
                               mid.middle_template_id = ? or
                               sml.small_template_id = ?))";
            }
        }
        /// <summary>
        /// 获得所有检查题目
        /// </summary>
        public static string SqlQueryAllCheckTitle
        {
            get
            {
                return @"select * from gm_check_title tit,gm_user u 
                          where tit.status='1' and tit.create_by=u.user_id and tit.organ_id=?";
            }
        }
        /// <summary>
        /// 删除检查题目
        /// </summary>
        public static string SqlDeleteCheckTitle
        {
            get
            {
                return @"update gm_check_title
                  set status = '0',
                      update_by = ?,
                      update_date = sysdate
                where check_title_id = ?";
            }
        }
        /// <summary>
        /// 根据id，查询检查题目详细信息
        /// </summary>
        public static string SqlQueryCheckTitleByID
        {
            get
            {
                return @"select *
                  from gm_check_title tit,
                       (select * from gm_check_title_answer where status = '1') ans
                 where tit.check_title_id = ?
                   and tit.check_title_id = ans.check_title_id(+)";
            }
        }
        /// <summary>
        /// 根据id，查询检查题目小分类类型
        /// </summary>
        public static string SqlQueryCheckTitleTypeByID
        {
            get
            {
                return @"select * from gm_small_template_type sml,tr_templatetype_checktitle tr
                where tr.check_title_id=?
                and tr.small_template_id=sml.small_template_id";
            }
        }
        /// <summary>
        /// 修改检查题目信息
        /// </summary>
        public static string SqlUpdateCheckTitle
        {
            get
            {
                return @"update gm_check_title
                   set check_title_name = ?,
                       check_title_content = ?,
                       is_choice = ?,
                       update_by = ?,
                       update_date = sysdate
                 where check_title_id = ?";
            }
        }
        /// <summary>
        /// 删除检查题目答案
        /// </summary>
        public static string SqlDeleteCheckTitleAnswers
        {
            get
            {
                return @"update gm_check_title_answer
                   set status = '0',
                       update_by = ?,
                       update_date = sysdate
                 where check_title_id = ?";
            }
        }
        #endregion

        #region 模板管理
        /// <summary>
        /// 查询出所有模板
        /// </summary>
        public static string SqlQueryAllTemplate
        {
            get
            {
                return @"select tem.*,sml.small_template_name,u.user_name from gm_template tem, gm_small_template_type sml, gm_user u
                    where tem.status='1'
                    and tem.small_template_id = sml.small_template_id
                    and tem.create_by = u.user_id";
            }
        }

        /// <summary>
        /// 查询出所有模板
        /// </summary>
        public static string SqlQueryAllTemplateForExeCheck
        {
            get
            {
                return @"select tem.*,sml.small_template_name from gm_template tem, gm_small_template_type sml
                    where tem.status='1'
                    and tem.small_template_id = sml.small_template_id
                    and tem.organ_id=?";
            }
        }

        /// <summary>
        /// 修改模板信息
        /// </summary>
        public static string SqlUpdateTemplate
        {
            get
            {
                return @"update gm_template
                   set template_name = ?,
                       update_by = ?,
                       update_date = sysdate
                 where template_id = ?";
            }
        }
        /// <summary>
        /// 从模板中删除检查题目
        /// </summary>
        public static string SqlDeleteTitleFromTemp
        {
            get
            {
                return @"update tr_template_checktitle
                    set status = '0',
                        update_by = ?,
                        update_date = sysdate
                  where template_id = ?";
            }
        }
        /// <summary>
        /// 根据模板id，查询模板详细信息
        /// </summary>
        public static string SqlQueryTemplateByID
        {
            get
            {
                return @" select tem.*,
                    big.big_template_name,
                    mid.middle_template_name,
                    sml.small_template_name,
                    tit.*
               from gm_template             tem,
                    gm_big_template_type    big,
                    gm_middle_template_type mid,
                    gm_small_template_type  sml,
                    （SELECT                *
               FROM tr_template_checktitle
              where status = '1') tr, gm_check_title tit
              where tem.template_id = ?
                and tem.small_template_id = sml.small_template_id
                and mid.big_template_id = big.big_template_id
                and sml.middle_template_id = mid.middle_template_id
                and tem.template_id = tr.template_id
                and tr.check_title_id = tit.check_title_id";
            }
        }
        /// <summary>
        /// 根据分类查询出模板
        /// </summary>
        public static string SqlQueryTemplateByOrganIdAndType
        {
            get
            {
                return @"select *
                from gm_template tem, gm_small_template_type sml, gm_user u
               where tem.status = '1'
                 and tem.organ_id = ?
                 and tem.small_template_id = sml.small_template_id
                 and tem.small_template_id in
                     (select sml.small_template_id
                        from gm_big_template_type    big,
                             gm_middle_template_type mid,
                             gm_small_template_type  sml
                       WHERE big.status = '1'
                         and mid.status = '1'
                         and sml.status = '1'
                         and big.big_template_id = mid.big_template_id
                         and mid.middle_template_id = sml.middle_template_id
                         and (big.big_template_id = ? or mid.middle_template_id = ? or
                             sml.small_template_id = ?))";
            }
        }
        /// <summary>
        /// 查询出所有模板
        /// </summary>
        public static string SqlQueryTemplateByOrganId
        {
            get
            {
                return @"select tem.*,sml.small_template_name from gm_template tem, gm_small_template_type sml
                    where tem.status='1'
                    and tem.small_template_id = sml.small_template_id
                    and tem.organ_id= ?";
            }
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        public static string SqlDeleteTemplate
        {
            get
            {
                return @"update gm_template
                    set status = '0',
                        update_date = sysdate
                    where template_id = ?";
            }
        }
        /// <summary>
        /// 将检查题目对应于模板
        /// </summary>
        public static string SqlAddTitleToTemplate
        {
            get
            {
                return @"insert into tr_template_checktitle
                      (id, template_id, check_title_id, status, create_by)
                    values
                      (tr_template_checktitle_seq.nextval, ?, ?, '1', ?)";
            }
        }
        /// <summary>
        /// 获得模板Seq
        /// </summary>
        public static string SqlQueryTemplateSeq
        {
            get
            {
                return @"select GM_TEMPLATE_SEQ.NEXTVAL from dual";
            }
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        public static string SqlAddTemplate
        {
            get
            {
                return @"insert into gm_template
                  (template_id, template_name, small_template_id, status, create_by,organ_id)
                values
                  (?, ?, ?, '1', ?, ?)";
            }
        }
        #endregion

        #region 【任务管理】
        /// <summary>
        /// 根据分类查询出模板
        /// </summary>
        public static string SqlQueryTemplateByTypeId
        {
            get
            {
                return @"select tem.*,sml.small_template_name,u.user_name
                from gm_template tem, gm_small_template_type sml, gm_user u
               where tem.status = '1'
                 and tem.small_template_id = sml.small_template_id
                 and tem.create_by = u.user_id
                 and tem.small_template_id in
                     (select sml.small_template_id
                        from gm_big_template_type    big,
                             gm_middle_template_type mid,
                             gm_small_template_type  sml
                       WHERE big.status = '1'
                         and mid.status = '1'
                         and sml.status = '1'
                         and big.big_template_id = mid.big_template_id
                         and mid.middle_template_id = sml.middle_template_id
                         and (big.big_template_id = ? or mid.middle_template_id = ? or
                             sml.small_template_id = ?))";
            }
        }

        /// <summary>
        /// 查询所有任务类型
        /// </summary>
        public static string SqlQueryAllTaskType
        {
            get
            {
                return @"select * from gm_task_type where status='1'";
            }
        }

        /// <summary>
        /// 查询任务表Seq
        /// </summary>
        public static string SqlQueryTaskSeq
        {
            get
            {
                return @"select gm_task_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入任务表
        /// </summary>
        public static string SqlInsertTask
        {
            get
            {

                return @"insert into gm_task
                      (task_id, task_name,template_id,
                       start_date, end_date, give_user_id, give_user_name,
                       status, create_by, create_date,task_type_id, 
                       organ_name,check_scode,remark,organ_id)
                    values
                      (?, ?, ?, ?, ?, ?,?,
                       '1', ?, sysdate, ?, ?, ?, ?, ?)";
            }
        }

        ///// <summary>
        ///// 查询文件Sequence
        ///// </summary>
        //public static string SqlQueryFileSeq
        //{
        //    get
        //    {
        //        return @"select file_seq.nextval from dual";
        //    }
        //}

        /// <summary>
        /// 插入文件信息表
        /// </summary>
        public static string SqlInserFiles
        {
            get
            {
                return @"insert into st_files
                  (file_id, file_name, file_path, project_id, status, create_by, create_date)
                values
                  (st_files_seq.nextval, ?, ?, ?, '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 根据模版名称查找模版ID
        /// </summary>
        public static string SqlQueryTemplateNameById
        {
            get
            {
                return @"select template_name from gm_template gt where status='1' and gt.template_id = ?";
            }
        }

        /// <summary>
        /// 根据Id查询任务类型
        /// </summary>
        public static string SqlQueryTaskTypeById
        {
            get
            {
                return @"select * from gm_task_type gt 
                         where gt.task_type_id=? and gt.is_exist_oragn='1' and gt.status='1'";
            }
        }

        /// <summary>
        /// 根据组织ID查询所有任务
        /// </summary>
        public static string SqlQueryTaskByOrganId
        {
            get
            {
                return @"select gt.task_id,
                       gt.task_name,
                       to_char(gt.start_date, 'yyyy/MM/dd') start_date,
                       to_char(gt.end_date, 'yyyy/MM/dd') end_date,
                       gt.create_date,
                       gt.update_date,
                       gt.organ_name,
                       gt.check_scode,
                       gt.remark,
                       gu.user_name,
                       gtt.task_type_name,
                       (select gp.template_name
                          from gm_template gp
                         where gp.template_id = gt.template_id) template_name
                  from gm_task gt, gm_user gu, gm_task_type gtt
                 where gt.give_user_id = gu.user_id
                   and gt.task_type_id = gtt.task_type_id
                   and gt.organ_id = ?
                   and gt.status = '1'
                   and gu.status = '1'
                   and gtt.status = '1'";
            }
        }

        /// <summary>
        /// 根据所选条件查询任务
        /// </summary>
        public static string SqlQueryTaskBySearch
        {
            get
            {
                return @"select gt.task_id,
                           gt.task_name,
                           to_char(gt.start_date, 'yyyy/MM/dd') start_date,
                           to_char(gt.end_date, 'yyyy/MM/dd') end_date,
                           gt.create_date,
                           gt.update_date,
                           gt.organ_name,
                           gt.check_scode,
                           gt.remark,
                           gu.user_name,
                           gtt.task_type_name,
                           gg.template_name
                      from gm_task gt,
                           gm_user gu,
                           gm_task_type gtt,
                           gm_template gg
                     where gt.give_user_id = gu.user_id
                       and gt.task_type_id = gtt.task_type_id
                       and gg.template_id(+) = gt.template_id
                       and gt.organ_id = ?
                       and gt.status = '1'
                       and gu.status = '1'
                       and gtt.status = '1'";
            }
        }

        /// <summary>
        /// 根据任务ID删除任务
        /// </summary>
        public static string SqlDeleteTaskById
        {
            get
            {
                return @"update gm_task set status='0',update_by=?,update_date=sysdate where task_id=?";
            }
        }

        /// <summary>
        /// 根据任务ID查询任务
        /// </summary>
        public static string SqlQueryTaskById
        {
            get
            {
                return @"select gt.*, gtt.task_type_name, gp.template_name
                          from gm_task gt, gm_task_type gtt, gm_template gp
                         where gt.template_id = gp.template_id
                           and gt.task_type_id = gtt.task_type_id
                           and gt.status = '1' and gt.task_id=?";
            }
        }

        /// <summary>
        /// 根据ID修改任务
        /// </summary>
        public static string SqlUpdateTaskById
        {
            get
            {
                return @"update gm_task
                       set task_name = ?,
                           template_id = ?,
                           start_date = ?,
                           end_date = ?,
                           give_user_id = ?,
                           give_user_name = ?,
                           update_by = ?,
                           update_date = sysdate,
                           task_type_id = ?,
                           organ_name = ?,
                           check_scode = ?,
                           remark = ?
                     where task_id = ?";
            }
        }

        /// <summary>
        /// 根据任务ID查询所属文件
        /// </summary>
        public static string SqlQueryFilesByTaskId
        {
            get
            {
                return @"select * from st_files where project_id=? and status='1'";
            }
        }

        /// <summary>
        /// 根据文件ID删除文件
        /// </summary>
        public static string SqlDeleteFilesByFileId
        {
            get
            {
                return @"update st_files set status='0',update_by=?,update_date=sysdate 
                          where file_id=?";
            }
        }
        #endregion

        #region【法律法规】
        /// <summary>
        /// 查询法律法规类型
        /// </summary>
        public static string SqlQueryLowTemplate
        {
            get
            {
                return @"select t.low_type_id,t.low_type_name from gm_low_type t where t.status='1'";
            }
        }

        /// <summary>
        /// 查询法律法规父子关系
        /// </summary>
        public static string SqlQueryLowFather
        {
            get
            {
                return @"select low_type_id id, low_type_name name, null parentID
                          from gm_low_type
                         where status = '1'
                        union
                        select low_id id, low_name name, low_type_id parentID
                          from gm_low
                         where status = '1'";
            }
        }

        /// <summary>
        /// 插入法律法规
        /// </summary>
        public static string SqlInsertLow
        {
            get
            {
                return @"insert into gm_low 
                          (low_id, low_name, low_type_id, low_file_path, status, create_by, create_date, word_file_name, html_file_name, html_file_path )
                        values
                          (gm_low_seq.nextval, ?, ?, ?, '1', ?, sysdate, ?, ?, ?)";
            }
        }

        /// <summary>
        /// 根据ID查询法律法规文件
        /// </summary>
        public static string SqlSelectLowByID
        {
            get
            {
                return @"select * from gm_low where low_id=? and status='1'";
            }
        }
        #endregion

        #region【监督人员】
        /// <summary>
        /// 根据组织流水号查询部门信息
        /// </summary>
        public static string SqlQueryDeptByOrganId
        {
            get
            {
                return @"select gd.*,gor.organ_no,gor.organ_name from gm_dept gd,gm_organ gor 
                         where gd.organ_id=gor.organ_id and gor.organ_id=? and gd.status='1'";
            }
        }

        /// <summary>
        /// 新增加时是否存在相同用户名
        /// </summary>
        public static string SqlQueryExistSameUserNoWhenAdd
        {
            get
            {
                return @"select user_no from gm_user where user_no=? and status='1'";
            }
        }

//        /// <summary>
//        /// 新增普通用户时查询某组织是否存在相同用户名
//        /// </summary>
//        public static string SqlQueryExistSameUserByOrganIdAndUserTypeWhenAdd
//        {
//            get
//            {
//                return @"select user_no from gm_user 
//                         where user_no=? and organ_id=? and user_type='3' and status='1'";
//            }
//        }

        /// <summary>
        /// 查询用户Sequence
        /// </summary>
        public static string SqlQueryUserSeq
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
                          (user_id,
                           user_no,
                           user_name,
                           user_pwd,
                           status,
                           create_by,
                           create_date,
                           organ_id,
                           user_type)
                        values
                          (?,
                           ?,
                           ?,
                           '8888',
                           '1',
                           ?,
                           sysdate,
                           ?,
                           ?)";
            }
        }

        /// <summary>
        /// 插入用户角色表
        /// </summary>
        public static string SqlInsertUserRole
        {
            get
            {
                return @"insert into tr_user_role
                          (user_role_id, user_id, role_id, status, create_by, create_date)
                        values
                          (tr_user_role_seq.nextval, ?, ?, '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 根据部门ID查询部门名称
        /// </summary>
        public static string SqlQueryDeptNameById
        {
            get
            {
                return @"select dept_name from gm_dept where dept_id=? and status='1'";
            }
        }

        /// <summary>
        /// 查询超级管理员和组织管理员
        /// </summary>
        public static string SqlQueryAllAdminUser
        {
            get
            {
                return @"select gu.*,
                           gor.organ_no,
                           gor.organ_name,
                           (case user_type
                             when '2' then
                              '普通管理员'
                             when '3' then
                              '普通用户'
                             else
                              '超级管理员'
                           end) user_type_name
                      from gm_user gu, gm_organ gor
                     where gu.organ_id = gor.organ_id(+)
                       and (gu.user_type = '0' or gu.user_type = '1' or gu.user_type='2')
                       and gu.status = '1'";
            }
        }

        /// <summary>
        /// 查询某组织所有管理员和所有普通用户
        /// </summary>
        public static string SqlQueryNormalUserByOrganId
        {
            get
            {
                return @"select gu.*,
                               gor.organ_no,
                               gor.organ_name,
                               (case user_type
                                 when '2' then
                                  '管理员'
                                 when '3' then
                                  '普通用户'
                                 else
                                  '超级管理员'
                               end) user_type_name,
                               (select tm.role_name
                                  from tm_role tm, tr_user_role tur
                                 where gu.user_id = tur.user_id
                                   and tm.role_id = tur.role_id
                                   and tur.status = '1'
                                   and tm.status = '1') role_name
                          from gm_user gu, gm_organ gor
                         where gu.organ_id = gor.organ_id(+)
                           and gu.organ_id = 1000000061
                           and (gu.user_type = '2' or gu.user_type = '3')
                           and gu.status = '1'";
            }
        }

        /// <summary>
        /// 根据用户ID查询名称
        /// </summary>
        public static string SqlQueryUserNameById
        {
            get
            {
                return @"select user_name from gm_user where user_id=?";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static string SqlDeleteUserById
        {
            get
            {
                return @"update gm_user set status='0',update_by=?,update_date=sysdate where user_id=?";
            }
        }

        /// <summary>
        /// 根据用户ID删除用户角色表
        /// </summary>
        public static string SqlDeleteUserRoleByUserId
        {
            get
            {
                return @"update tr_user_role set status='0',update_by=?,update_date=sysdate where user_id=?";
            }
        }

        /// <summary>
        /// 根据Id查询用户信息
        /// </summary>
        public static string SqlQueryUserById
        {
            get
            {
                return @"select gu.*, gor.organ_no, gor.organ_name, tur.role_id
                          from gm_user gu, gm_organ gor, tr_user_role tur
                         where gor.organ_id(+) = gu.organ_id
                           and gu.user_id = tur.user_id
                           and gu.status = '1'
                           and gu.user_id = ?";
            }
        }

        /// <summary>
        /// 查询某个普通用户所拥有的角色
        /// </summary>
        public static string SqlQueryUserOwnRoleByUserId
        {
            get
            {
                return @"select tr.*
                            from tm_role tr, gm_user gu, tr_user_role tur
                            where gu.user_id = tur.user_id
                            and tr.role_id = tur.role_id
                            and gu.user_id = ?
                            and tr.status = '1'
                            and tur.status = '1'
                            and gu.user_type = '3'";
            }
        }

        /// <summary>
        /// 查询某个用户所拥有的功能
        /// </summary>
        public static string SqlQueryUserIdOwnFunction
        {
            get
            {
                return @"select tf.function_id,
                           tf.function_name,
                           tf.parent_id
                      from tm_function tf, tr_user_role tur, tr_role_function trf, tm_role tr
                     where tf.function_id = trf.function_id
                       and tr.role_id = tur.role_id
                       and tur.role_id = trf.role_id
                       and trf.status = '1'
                       and tur.status = '1'
                       and tur.user_id = ?";
            }
        }

        /// <summary>
        /// 修改时是否存在相同用户名
        /// </summary>
        public static string SqlQueryIsExistSameUserNoUpdate
        {
            get
            {
                return @"select user_no from gm_user where status='1' and user_id!=? and user_no=?";
            }
        }

        /// <summary>
        /// 根据用户ID修改用户
        /// </summary>
        public static string SqlUpdateUserByUserId
        {
            get
            {
                return @"update gm_user set user_no=?,user_name=?,update_by=?,update_date=sysdate
                          where user_id=?";
            }
        }
        public static string SqlUpdateUserByOrganAndUserId
        {
            get
            {
                return @"update gm_user set user_no=?,user_name=?,organ_id=?,update_by=?,update_date=sysdate
                          where user_id=?";
            }
        }

      
        #endregion

        #region【执行监督任务】
        /// <summary>
        /// 根据分类查询出模板
        /// </summary>
        public static string SqlQueryTemplateByTypeIdForExeCheck
        {
            get
            {
                return @"select tem.*,sml.small_template_name
                from gm_template tem, gm_small_template_type sml
               where tem.status = '1'
                 and tem.organ_id=?
                 and tem.small_template_id = sml.small_template_id
                 and tem.small_template_id in
                     (select sml.small_template_id
                        from gm_big_template_type    big,
                             gm_middle_template_type mid,
                             gm_small_template_type  sml
                       WHERE big.status = '1'
                         and mid.status = '1'
                         and sml.status = '1'
                         and big.big_template_id = mid.big_template_id
                         and mid.middle_template_id = sml.middle_template_id  
                         and big.big_template_id like ? 
                         and mid.middle_template_id like ? 
                         and sml.small_template_id like ?)";
            }
        }

        /// <summary>
        /// 模糊查询单位
        /// </summary>
        public static string SqlQueryUnitByKey
        {
            get
            {
                return @"select t.unit_id, t.unit_name,t.unit_address,t.unit_code,t.legal_person,t.responsible_person,t.county
                          from st_unit t
                         where status = '1'
                           and t.organ_id=?
                           and (t.unit_name like ? or t.unit_address like ? or t.unit_code like ? or
                               t.legal_person like ? or t.responsible_person like ?)";
            }
        }

        /// <summary>
        /// 根据单位ID查询单位信息
        /// </summary>
        public static string SqlQueryUnitByID
        {
            get
            {
                return @"select t.unit_id, t.unit_name, t.unit_address from st_unit t where t.unit_id = ? and t.status='1'";
            }
        }

        /// <summary>
        /// 根据模板查询题目
        /// </summary>
        public static string SqlQueryCheckTitleByTempID
        {
            get
            {
                return @"select gct.check_title_id, gct.check_title_name, gct.check_title_content
                          from tr_template_checktitle ttc, gm_template gt, gm_check_title gct
                         where ttc.template_id = gt.template_id
                           and ttc.check_title_id = gct.check_title_id
                           and ttc.status = '1'
                           and gt.status = '1'
                           and gct.status = '1'
                           and gt.template_id = ?";
            }
        }

        /// <summary>
        /// 插图监督的答题
        /// </summary>
        public static string SqlInsertCheckTitle
        {
            get
            {
                return @"insert into tr_singe_check_title
                          (single_id, check_id, check_title_id, status, create_by, create_date, title_answer, type, result, advice)
                        values
                          (tr_singe_check_title_seq.nextval, ?, ?, '1', ?, sysdate, ?, '1', ?, ?)";
            }
        }

        /// <summary>
        /// 获取执行监督ID
        /// </summary>
        public static string SqlGetCheckSeq
        {
            get
            {
                return @"select st_check_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入执行监督记录
        /// </summary>
        public static string SqlAddCheck
        {
            get
            {
                return @"insert into st_check
                          (check_id, unit_id, unit_name, template_id, template_name, is_license, is_filing, start_datetime, end_datetime, check_point, is_rectification, review_date, is_review, rectification_result_id, involve_content, remark, check_result, check_one, check_one_name, check_two, check_two_name, check_notes, check_opinion, status, create_by, create_date, organ_id)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, '1', ?, sysdate,?)";
            }
        }

        /// <summary>
        /// 根据题目ID查询题目答案
        /// </summary>
        public static string SqlQueryAnswerByTitleID
        {
            get
            { 
                return @"select t.answer_id, t.answer_name, t.check_result, t.advice
                          from gm_check_title_answer t
                         where t.status = '1'
                           and t.check_title_id = ?
                           order by t.answer_id";
            }
        }

        /// <summary>
        /// 根据题目答案id查询笔录和建议
        /// </summary>
        public static string SqlQueryAnswerResultById
        {
            get
            {
                return @"select t.check_result,t.advice from gm_check_title_answer t where t.answer_id=?";
            }
        }

        /// <summary>
        /// 根据小分类查询题目信息
        /// </summary>
        public static string SqlQueryTitleBySmallType
        {
            get
            {
                return @"select gct.*
                          from gm_check_title gct, tr_templatetype_checktitle ttc
                         where gct.status = '1'
                           and gct.organ_id = ?
                           and gct.check_title_id = ttc.check_title_id
                           and ttc.small_template_id in
                               (select sml.small_template_id
                                  from gm_big_template_type    big,
                                       gm_middle_template_type mid,
                                       gm_small_template_type  sml
                                 WHERE big.status = '1'
                                   and mid.status = '1'
                                   and sml.status = '1'
                                   and big.big_template_id = mid.big_template_id
                                   and mid.middle_template_id = sml.middle_template_id
                                   and big.big_template_id like ?
                                   and mid.middle_template_id like ?
                                   and sml.small_template_id like ?)";
            }
        }

        /// <summary>
        /// 查询专业条线（静态数据）
        /// </summary>
        public static string SqlQueryTouchFiled
        {
            get
            {
                return @"select code,name from gm_code where code_type='TOUCH_FILED'";
            }
        }

        /// <summary>
        /// 查询检查结果（静态数据）
        /// </summary>
        public static string SqlQueryCheckRusult
        {
            get
            {
                return @"select code,name from gm_code where code_type='CHECK_RESULT_type'";
            }
        }
        
        /// <summary>
        /// 查询本组织单位的监督人员
        /// </summary>
        public static string SqlQueryChecker
        {
            get
            {
                return @"select * from gm_user where organ_id=? and user_id<>?  and status='1'";
            }
        }
        #endregion

        #region【部门】
        /// <summary>
        /// 添加单位时查询是否存在相同单位编号
        /// </summary>
        public static string SqlQueryIsExistSameDeptNoAdd
        {
            get
            {
                return @"select dept_no from gm_dept where dept_no=? and organ_id=? and status='1'";
            }
        }

        /// <summary>
        /// 插入部门表
        /// </summary>
        public static string SqlInsertDept
        {
            get
            {
                return @"insert into gm_dept
                          (dept_id, dept_no, dept_name, status, create_by, create_date, organ_id)
                        values
                          (gm_dept_seq.nextval, ?, ?, '1', ?, sysdate, ?)";
            }
        }

        ///// <summary>
        ///// 查询组织
        ///// </summary>
        //public static string SqlQueryAllOrgan
        //{
        //    get
        //    {
        //        return @"select * from gm_organ where status='1'";
        //    }
        //}

        /// <summary>
        /// 根据组织ID查询组织名称
        /// </summary>
        public static string SqlQueryOrganNameById
        {
            get
            {
                return @"select organ_name from gm_organ where organ_id=? and status='1'";
            }
        }

        /// <summary>
        /// 根据组织ID删除组织
        /// </summary>
        public static string SqlDeleteDeptById
        {
            get
            {
                return @"update gm_dept set status='0',update_by=?,update_date=sysdate where dept_id=?";
            }
        }

        /// <summary>
        /// 根据部门ID查询部门信息
        /// </summary>
        public static string SqlQueryDeptById
        {
            get
            {
                return @"select gd.*,gor.organ_no,gor.organ_name from gm_dept gd,gm_organ gor 
                       where gd.organ_id=gor.organ_id and gd.dept_id=? and gd.status='1'";
            }
        }
        
        /// <summary>
        /// 编辑时查询是否有相同部门编号
        /// </summary>
        public static string SqlQueryIsExistSameDeptNoWhenEdit
        {
            get
            {
                return @"select * from gm_dept where dept_no=? and dept_id!=? and organ_id=?";
            }
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        public static string SqlUpdateDeptById
        {
            get
            {
                return @"update gm_dept set dept_no=?,dept_name=?,organ_id=?,update_by=?,update_date=sysdate
                         where dept_id=?";
            }
        }
        #endregion

        #region【角色】

        /// <summary>
        /// 查询除超级设置外的所有功能
        /// </summary>
        public static string SqlQueryAllFunctionExceptSup
        {
            get
            {
                return @"select *
                          from tm_function
                         where function_id != 10
                           and function_id != 43
                           and function_id != 44
                           and status = '1'";
            }
        }

        /// <summary>
        /// 查询角色表Sequence
        /// </summary>
        public static string SqlQueryRoleSeq
        {
            get
            {
                return @"select tm_role_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 查询某组织下角色类型为“组织管理员添加”是否存在相同角色名
        /// </summary>
        public static string SqlQueryExistSameRoleNameByOrganIdAndRoleType
        {
            get
            {
                return @"select *
                          from tm_role
                         where role_name = ?
                           and organ_id = ?
                           and role_type = '2'
                           and status = '1'";
            }
        }

        /// <summary>
        /// 查询是否存在超级管理员角色（ID为1000000001的角色为超级管理员）
        /// </summary>
        public static string SqlQueryExistSuperRole
        {
            get
            {
                return @"select * from tm_role where role_id=1000000001";
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
                          (role_id, role_name, status, create_by, create_date,organ_id,role_type)
                        values
                          (?, ?, '1', ?, sysdate,?,?)";
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
                          (role_function_id, role_id, function_id, status, create_by, create_date)
                        values
                          (tr_role_function_seq.nextval, ?, ?, '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 查询有效角色
        /// </summary>
        public static string SqlQueryAllRole
        {
            get
            {
                return @"select * from tm_role where status='1'";
            }
        }
               
        /// <summary>
        /// 查询某个组织下普通管理员所建的角色
        /// </summary>
        public static string SqlQueryRoleByOrganId
        {
            get
            {
                return @"select * from tm_role where organ_id=? and role_type='2' and status='1'";
            }
        }

        /// <summary>
        /// 查询某个角色ID所拥有权限
        /// </summary>
        public static string SqlQueryRoleFunctionByRoleId
        {
            get
            {
                return @"select tr.role_id, tr.role_name, tf.function_id, tf.function_name
                          from tm_role tr, tm_function tf, tr_role_function trf
                         where tr.role_id = trf.role_id
                           and tf.function_id = trf.function_id
                           and tr.role_id =?
                           and tr.status = '1'
                           and trf.status = '1'";
            }
        }

        /// <summary>
        /// 根据角色ID查找角色名称
        /// </summary>
        public static string SqlQueryRoleNameById
        {
            get
            {
                return @"select role_name from tm_role where role_id=?";
            }
        }

        /// <summary>
        /// 修改角色名称时查询该组织下所建角色中是否存在相同角色名称
        /// </summary>
        public static string SqlQueryExistSameRoleNameWhenUpdate
        {
            get
            {
                return @"select * from tm_role 
                           where role_id!=? and role_name=? and organ_id=? and role_type='2'";
            }
        }

        /// <summary>
        /// 根据角色ID修改角色表信息
        /// </summary>
        public static string SqlUpdateRoleById
        {
            get
            {
                return @"update tm_role set role_name=?,update_by=?,update_date=sysdate where role_id=?";
            }
        }

        /// <summary>
        /// 删除某一角色的所拥有的全部权限
        /// </summary>
        public static string SqlDeleteRoleFunctionByRoleId
        {
            get
            {
                return @"update tr_role_function set status='0',update_by=?,update_date=sysdate 
                         where role_id=?";
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public static string SqlDeleteRoleById
        {
            get
            {
                return @"update tm_role set status='0',update_by=?,update_date=sysdate where role_id=?";
            }
        }
        #endregion

        #region【组织】
        /// <summary>
        /// 查询所有有效组织
        /// </summary>
        public static string SqlQueryAllOrgan
        {
            get
            {
                return @"select gor.*,ga.area_code,ga.area_name from gm_organ gor,gm_area ga 
                         where gor.area_id=ga.area_id and gor.status='1'";
            }
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        public static string SqlDeleteOrganById
        {
            get
            {
                return @"update gm_organ set status='0',update_by=?,update_date=sysdate where organ_id=?";
            }
        }

        /// <summary>
        /// 查询树状区域
        /// </summary>
        public static string SqlQueryAllArea
        {
            get
            {
                return @"select ga.* from gm_area ga 
                          start with ga.parent_id is null connect by prior ga.area_id=ga.parent_id";
            }
        }

        /// <summary>
        /// 保存时查询是否存在相同组织编号
        /// </summary>
        public static string SqlQueryExistSameOrganNoWhenAdd
        {
            get
            {
                return @"select * from gm_organ where organ_no=? and status='1'";
            }
        }

        /// <summary>
        /// 插入组织信息表
        /// </summary>
        public static string SqlInsertOrgan
        {
            get
            {
                return @"insert into gm_organ
                          (organ_id, organ_no, organ_name, status, create_by, create_date, area_id)
                        values
                          (gm_organ_seq.nextval, ?, ?, '1', ?, sysdate, ?)";
            }
        }

        /// <summary>
        /// 根据ID查询组织
        /// </summary>
        public static string SqlQueryOrganById
        {
            get
            {
                return @"select gor.*,ga.area_code,ga.area_name from gm_organ gor,gm_area ga 
                         where gor.area_id=ga.area_id and organ_id=?";
            }
        }

        /// <summary>
        /// 修改组织时查询是否存在相同名称
        /// </summary>
        public static string SqlQueryExistSameOrganNoWhenUpdate
        {
            get
            {
                return @"select * from gm_organ where organ_id != ? and organ_no=? and status='1'";
            }
        }

        /// <summary>
        /// 根据组织流水号修改组织信息
        /// </summary>
        public static string SqlUpdateOrganById
        {
            get
            {
                return @"update gm_organ set organ_no=?,organ_name=?,area_id=?,update_by=?,update_date=sysdate
                           where organ_id=?";
            }
        }
        #endregion

        #region【执行任务】
        /// <summary>
        /// 查询涉及条线（执行任务）
        /// </summary>
        public static string SqlQueryTouchFiledTask
        {
            get
            {
                return @"select code,name from gm_code where code_type='TOUCH_FILED'";
            }
        }

        /// <summary>
        /// 查询任务信息
        /// </summary>
        public static string SqlQueryTask
        {
            get
            {
                return @"select gt.task_id,
                       gt.task_name,
                       gt.template_id,
                       gt.start_date,
                       gt.end_date,
                       gt.organ_name,
                       gt.check_scode,
                       gt.remark
                  from gm_task gt, gm_task_type gtt
                 where gt.task_type_id = gtt.task_type_id
                 and gt.organ_id=?
                 and sysdate >=trunc(gt.start_date) and sysdate<trunc(gt.end_date)+1
                   and gt.status = '1'";
            }
        }

        /// <summary>
        /// 根据任务ID查询任务信息
        /// </summary>
        public static string SqlQueryTaskByIdForExe
        {
            get
            {
                return @"select gt.task_id,
                           gt.task_name,
                           gt.template_id,
                           gt.start_date,
                           gt.end_date,
                           gt.organ_name,
                           gt.check_scode,
                           gt.remark
                      from gm_task gt, gm_task_type gtt
                     where gt.task_type_id = gtt.task_type_id
                       and gt.status = '1'
                       and gt.task_id=?";
            }
        }

        /// <summary>
        /// 根据任务选择的模板ID查询任务题目
        /// </summary>
        public static string SqlQueryTaskTitle
        {
            get
            {
                return @"select gct.check_title_id, gct.check_title_name, gct.check_title_content
                          from tr_template_checktitle ttc, gm_template gt, gm_check_title gct
                         where ttc.template_id = gt.template_id
                           and ttc.check_title_id = gct.check_title_id
                           and ttc.status = '1'
                           and gt.status = '1'
                           and gct.status = '1'
                           and gt.template_id = ?";
            }
        }

        /// <summary>
        /// 查询下一个执行任务的ID
        /// </summary>
        public static string SqlQueryExeCheckID
        {
            get
            {
                return @"select st_exetask_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 插入执行任务记录
        /// </summary>
        public static string SqlInsertExeTask
        {
            get
            {
                return @"insert into st_exetask
                          (exetask_id, unit_id, unit_name, task_id, task_name, is_license, is_filing, start_datetime, end_datetime, check_point, is_rectification, review_date, is_review, rectification_result_id, involve_content, remark, check_result, check_one, check_one_name, check_two, check_two_name, check_notes, check_opinion, status, create_by, create_date, organ_id)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, '1', ?, sysdate, ?)";
            }
        }

        /// <summary>
        /// 插图执行任务的答题
        /// </summary>
        public static string SqlInsertExeTaskTitle
        {
            get
            {
                return @"insert into tr_singe_check_title
                          (single_id, check_id, check_title_id, status, create_by, create_date, title_answer, type, result, advice)
                        values
                          (tr_singe_check_title_seq.nextval, ?, ?, '1', ?, sysdate, ?, '2', ?, ?)";
            }
        }
        #endregion

        #region【查询监督记录】
        /// <summary>
        /// 根据关键字查询监督记录
        /// </summary>
        public static string SqlQueryCheckByKey
        {
            get
            {
                return @"select sc.check_id,su.unit_name, sc.template_name, decode(sc.check_result,1201,'合格',1202,'不合格',1203,'不确定',1204,'未完成',' ') check_result,sc.start_datetime,sc.end_datetime
                          from st_check sc, st_unit su
                         where sc.status = '1'
                         and sc.unit_id = su.unit_id
                         and sc.organ_id=?
                           and (su.unit_name like ? or sc.template_name like ?)
                            order by sc.end_datetime desc";
            }
        }

        /// <summary>
        /// 根据Id查询监督记录
        /// </summary>
        public static string SqlQueryCheckById
        {
            get
            {
                return @"select sc.*, gc.name check_result_name
                          from st_check sc, gm_code gc
                         where sc.check_result = gc.code
                           and check_id = ?
                           and status = '1'";
            }
        }

        /// <summary>
        /// 根据检查Id查询检查题目
        /// </summary>
        public static string SqlQueryExeCheckTitleByID
        {
            get
            {
                return @"select tsct.check_title_id,gct.check_title_name,gct.check_title_content,tsct.title_answer, tsct.result, tsct.advice
                          from tr_singe_check_title tsct, gm_check_title gct
                         where tsct.check_title_id = gct.check_title_id
                            and tsct.type='1'
                           and tsct.check_id =? ";
            }
        }

        /// <summary>
        /// 根据题目ID查询题目答案
        /// </summary>
        public static string SqlQueryAnswerByTitleIDForRead
        {
            get
            {
                return @"select t.answer_id, t.answer_name, t.check_result, t.advice
                          from gm_check_title_answer t
                         where t.status = '1'
                           and t.check_title_id = ?";
            }
        }
        #endregion

        #region【查询执行任务】
        public static string SqlQueryExeTaskByKeyWord
        {
            get
            {
                return @"select se.exetask_id,se.task_id, su.unit_name, se.task_name, decode(se.check_result,1201,'合格',1202,'不合格',1203,'不确定',1204,'未完成',' ') check_result,se.start_datetime,se.end_datetime, gt.organ_name,gt.check_scode
                          from st_exetask se, st_unit su, gm_task gt
                         where se.status = '1'
                         and se.unit_id = su.unit_id
                         and se.task_id=gt.task_id
                         and se.organ_id=?
                           and (su.unit_name like ? or se.task_name like ?)
                            order by se.end_datetime desc";
            }
        }

        /// <summary>
        /// 根据ID查询执行任务详细信息
        /// </summary>
        public static string SQlQueryExeTaskByID
        {
            get
            {
                return @"select se.*, gc.name check_result_name
                          from st_exetask se, gm_code gc
                         where se.check_result = gc.code
                           and se.exetask_id = ?
                           and se.status = '1'";
            }
        }

        /// <summary>
        /// 根据任务ID查询任务题目
        /// </summary>
        public static string SqlQueryExeTaskTitleByTaskId
        {
            get
            {
                return @"select gct.check_title_id,gct.check_title_name,gct.check_title_content from gm_task gt,tr_template_checktitle ttc,gm_check_title gct
                            where gt.template_id=ttc.template_id 
                            and ttc.check_title_id=gct.check_title_id
                            and gt.task_id=?";
            }
        }

        /// <summary>
        /// 根据执行任务Id查询检查题目
        /// </summary>
        public static string SqlQueryExeTaskTitleByID
        {
            get
            {
                return @"select tsct.check_title_id,gct.check_title_name,gct.check_title_content,tsct.title_answer, tsct.result, tsct.advice
                          from tr_singe_check_title tsct, gm_check_title gct
                         where tsct.check_title_id = gct.check_title_id
                            and tsct.type='2'
                           and tsct.check_id =? ";
            }
        }
        #endregion

    }
}
