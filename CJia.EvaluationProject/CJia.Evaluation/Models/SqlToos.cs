using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models
{
    /// <summary>
    /// SQL语句定义
    /// </summary>
    public class SqlToos
    {
        public static string SqlQueryUser
        {
            get
            {
                return @"select * from gm_dept";
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        public static string SqlQueryUserByNOAndPwd
        {
            get
            {
                return @"select t.*,gd.dept_name from gm_user t,gm_dept gd where t.status='1'
                    and t.user_code=? and t.user_pwd=? and t.dept_id=gd.dept_id";
            }
        }

        #region【栏目管理】
        /// <summary>
        /// 查询用户没有的菜单权限
        /// </summary>
        public static string SqlQueryNoMenuComptence
        {
            get
            {
                return @"select gm.menu_id,gm.menu_name
                          from gm_menu gm
                         where gm.menu_id not in (select t.menu_id
                                                    from tm_competence t
                                                   where t.status = '1'
                                                     and t.menu_type = '0'
                                                     and t.user_id = ?)";
            }
        }

        /// <summary>
        /// 查询栏目树状数据
        /// </summary>
        public static string SqlQueryColum
        {
            get
            {
                return @"select t.column_tree_id,t.column_tree_name,t.column_description, t.parent_id from gm_column_tree t where t.status='1' order by t.column_no asc";
            }
        }

        /// <summary>
        /// 查询树状结构并指示有无权限
        /// </summary>
        public static string SqlQueryColumnAndCompetence
        {
            get
            {
                return @"select gct.column_tree_id,
                           gct.column_tree_name,
                           gct.parent_id,
                           nvl(tc.menu_id, 0) isHaveCompentence
                      from (select *
                              from gm_column_tree gct
                             where gct.status = '1'
                             start with gct.parent_id is null
                            connect by prior gct.column_tree_id = gct.parent_id) gct,
                           (select *
                              from tm_competence
                             where menu_type = '1'
                               and status = '1'
                               and user_id = ?) tc
                     where gct.column_tree_id = tc.menu_id(+)
                            order by gct.column_no asc";
            }
        }

        /// <summary>
        /// 根据栏目ID查询栏目级别
        /// </summary>
        public static string SqlQueryColumnLevel
        {
            get
            {
                return @"select level
                          from gm_column_tree t
                         where t.column_tree_id = ?
                         start with parent_id is null
                        connect by prior t.column_tree_id = parent_id";
            }
        }

        /// <summary>
        /// 查询栏目等级
        /// </summary>
        public static string SqlQueryColumnGrade
        {
            get
            {
                return @"select t.* from GM_CODE t where t.code_type='COLUMN_GRADE'";
            }
        }

        /// <summary>
        /// 查询栏目表SEQ
        /// </summary>
        public static string SqlQueryCloumnNextVal
        {
            get
            {
                return @"select gm_colum_tree_seq.nextval from dual";
            }
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        public static string SqlAddColumnTree
        {
            get
            {
                return @"insert into gm_column_tree
                          (column_tree_id, column_tree_name, column_description, column_no, column_grade, parent_id, status, creater_by, creater_date, check_way, score, score_standard)
                        values
                          (gm_colum_tree_seq.nextval, ?, ?, ?, ?, ?, '1', ?, sysdate, ?, ?, ?)";
            }
        }

        /// <summary>
        /// 添加栏目(如果是4级栏目)
        /// </summary>
        public static string SqlInsertColumnTree
        {
            get
            {
                return @"insert into gm_column_tree
                          (column_tree_id, column_tree_name, column_description, column_no, column_grade, parent_id, status, creater_by, creater_date, check_way, score, score_standard)
                        values
                          (?, ?, ?, ?, ?, ?, '1', ?, sysdate, ?, ?, ?)";
            }
        }

        /// <summary>
        /// 往审核表里插入4级栏目
        /// </summary>
        public static string SqlInsertCheck
        {
            get
            {
                return @"insert into tt_check
                          (check_id, tree_id, tree_name, check_state, status, creater_by, creater_date, description)
                        values
                          (tt_check_seq.nextval, ?, ?, '1201', '1', ?, sysdate, ?)";
            }
        }

        /// <summary>
        /// 根据节点ID查询该节点的详细信息
        /// </summary>
        public static string SqlQueryColumnNode
        {
            get
            {
                return @"select t1.column_tree_id,
                           t1.column_tree_name,
                           t1.column_description,
                           t1.column_no,
                           t1.column_grade,
                           t1.parent_id,
                           t1.check_way,
                           t1.score,
                           t1.score_standard,
                           t2.column_tree_name as parentname
                      from gm_column_tree t1,gm_column_tree t2
                     where t1.parent_id=t2.column_tree_id
                           and t1.column_tree_id = ?";
            }
        }

        /// <summary>
        /// 修改树状节点
        /// </summary>
        public static string SqlUpdateColumnTree
        {
            get
            {
                return @"update gm_column_tree
                           set column_tree_name   = ?,
                               column_description = ?,
                               column_no          = ?,
                               column_grade       = ?,
                               check_way=?,
                               score=?,
                               score_standard=?,
                               update_by          = ?,
                               update_date        = sysdate
                         where column_tree_id = ?";
            }
        }

        /// <summary>
        /// 删除树状节点
        /// </summary>
        public static string SqlDeleteColumnTree
        {
            get
            {
                return @"update gm_column_tree t
                           set t.status = '0',
                               t.update_by = ?,
                               t.update_date = sysdate
                         where t.column_tree_id = ?
                            or t.parent_id = ?";
            }
        }

        /// <summary>
        /// 删除审核表数据
        /// </summary>
        public static string SqlDeleteCheck
        {
            get
            {
                return @"update tt_check 
                           set status='0',
                               update_by = ?,
                               update_date = sysdate
                         where tree_id=?";
            }
        }

        /// <summary>
        /// 增加栏目责任科室和协助科室
        /// </summary>
        public static string SqlInsertDutyHelpDept
        {
            get
            {
                return @"insert into tt_duty_help_dept
                          (duty_help_dept_id, column_id, dept_id, dept_type, status, creater_by, creater_date)
                        values
                          (tt_duty_help_dept_seq.nextval, ?, ?, ?, '1', ?, sysdate)";
            }
        }

        /// <summary>
        /// 根据栏目ID查询责任科室
        /// </summary>
        public static string SqlSelectDutyDept
        {
            get
            {
                return @"select * from tt_duty_help_dept where status='1' and column_id=? and dept_type='1'";
            }
        }

        /// <summary>
        /// 根据栏目ID查询协助科室
        /// </summary>
        public static string SqlSelectHelpDept
        {
            get
            {
                return @"select * from tt_duty_help_dept where status='1' and column_id=? and dept_type='2'";
            }
        }

        /// <summary>
        /// 删除责任协助科室
        /// </summary>
        public static string SqlDeleteDutyHelpDept
        {
            get
            {
                return @"update tt_duty_help_dept
                       set 
                           status = '0',
                           update_by = ?,
                           update_date = sysdate
                     where column_id = ?";
            }
        }

        /// <summary>
        /// 修改审核表
        /// </summary>
        public static string SqlUpdatettCheck
        {
            get
            {
                return @"update tt_check
                           set 
                               tree_name = ?,
                               update_by = ?,
                               update_date = sysdate,
                               description = ?
                         where tree_id=?";
            }
        }
        #endregion

        #region【资料录入】
        /// <summary>
        /// 根据栏目ID查询所拥有的资料
        /// </summary>
        public static string QueryDataByColumnId
        {
            get
            {
                return @"select 
                           gd.data_id,
                           gd.data_name,
                           gct.column_tree_name,
                           gt.type_value              data_type,
                           gu.user_name         create_by,
                           gd.creater_date
                      from gm_column_tree gct, gm_data gd, gm_type gt, gm_user gu
                     where gd.column_tree_id = gct.column_tree_id
                       and gd.data_type = gt.type_id
                       and gd.creater_by = gu.user_id
                       and gt.type_code='10'
                       and gt.status='1'
                       and gd.status = '1'
                       and gd.column_tree_id in
                           (select t.column_tree_id
                              from gm_column_tree t
                              where t.status='1'
                             start with t.column_tree_id = ?
                            connect by prior t.column_tree_id = parent_id)
                     order by gd.creater_date desc";
            }
        }

        /// <summary>
        /// 查询资料类别
        /// </summary>
        public static string SqlQueryDataType
        {
            get
            {
                return @"select type_id,type_value from gm_type where type_code='10' and status='1'";
            }
        }

        /// <summary>
        /// 添加资料
        /// </summary>
        public static string SqlAddData
        {
            get
            {
                return @"insert into gm_data
                          (data_id, data_name, data_content, data_type, status, creater_by, creater_date, column_tree_id)
                        values
                          (gm_data_seq.nextval, ?, ?, ?, '1', ?, sysdate, ?)";
            }
        }

        /// <summary>
        /// 根据资料Id查询资料信息
        /// </summary>
        public static string SqlQueryDataById
        {
            get
            {
                return @"select * from gm_data t where t.data_id=?";
            }
        }

        /// <summary>
        /// 修改资料
        /// </summary>
        public static string SqlUpdateData
        {
            get
            {
                return @"update gm_data
                           set data_name = ?,
                               data_content = ?,
                               data_type = ?,    
                               status = '1',   
                               update_by = ?,
                               update_date = sysdate
                         where data_id = ?";
            }
        }

        /// <summary>
        /// 删除资料
        /// </summary>
        public static string SqlDeleteData
        {
            get
            {
                return @"update gm_data
                           set status = '0', update_by = ?, update_date = sysdate
                         where data_id = ?";
            }
        }
        #endregion

        #region【科室人员管理】
        /// <summary>
        /// 查询科室
        /// </summary>
        public static string SqlQueryAllDept
        {
            get
            {
                return @"select t.dept_id,t.dept_name,t.parent_id from gm_dept t where t.status='1'";
            }
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        public static string SqlInsertDept
        {
            get
            {
                return @"insert into gm_dept
                          (dept_id, dept_name, parent_id, create_date, create_by, status)
                        values
                          (gm_dept_seq.nextval, ?, ?, sysdate, ?, '1')";
            }
        }

        /// <summary>
        /// 根据科室Id查询人员
        /// </summary>
        public static string SqlQueryUserByDeptId
        {
            get
            {
                return @"select GU.*, GD.DEPT_NAME
                          from gm_user GU,
                               (select dept_id, DEPT_NAME
                                  from gm_dept
                                  where status='1'
                                 start with dept_id = ?
                                connect by prior dept_id = parent_id) GD
                         where GU.dept_id = GD.DEPT_ID and GU.status='1'
                                 order by DEPT_NAME";
            }
        }

        /// <summary>
        /// 修改科室
        /// </summary>
        public static string SqlUpdateDept
        {
            get
            {
                return @"update gm_dept
                           set 
                               dept_name = ?,
                               parent_id = ?,     
                               update_date = sysdate,
                               update_by = ?
                         where dept_id = ?";
            }
        }

        /// <summary>
        /// 根据Id查询科室信息
        /// </summary>
        public static string SqlQueryDeptByID
        {
            get
            {
                return @"select dept_id, dept_name, parent_id from gm_dept where dept_id=?";
            }
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        public static string SqlDeleteDept
        {
            get
            {
                return @"update gm_dept
                           set update_date = sysdate, update_by = ?, status = '0'
                         where dept_id = ?
                            or parent_id = ?";
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public static string SqlInsertUser
        {
            get
            {
                return @"insert into gm_user
                          (user_id, user_name, user_pwd, dept_id, create_date, create_by, user_code, status)
                        values
                          (gm_user_seq.nextval, ?, ?, ?, sysdate, ?, ?, '1')";
            }
        }

        /// <summary>
        /// 判断所选科室是否有子科室
        /// </summary>
        public static string SqlIsHaveChild
        {
            get
            {
                return @"select * from gm_dept t where t.parent_id=? and t.status='1'";
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        public static string SqlResetPwd
        {
            get
            {
                return @"update gm_user
                           set user_pwd = ?,
                               update_date = sysdate,
                               update_by = ?
                         where user_id=?";
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public static string SqlEditUser
        {
            get
            {
                return @"update gm_user
                           set 
                               user_name = ?,
                               dept_id = ?,
                               update_date = sysdate,
                               update_by = ?
                         where user_id=?";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static string SqlDeleteUser
        {
            get
            {
                return @"update gm_user
                           set  
                               update_date = sysdate,
                               update_by = ?,
                               status = '0'
                         where user_id=?";
            }
        }

        /// <summary>
        /// 验证此用户代码是否存在
        /// </summary>
        public static string SqlIsHaveUserCode
        {
            get
            {
                return @"select * from gm_user where user_code=? and status='1'";
            }
        }
        #endregion

        #region【权限控制】
        /// <summary>
        /// 查询用户栏目的权限
        /// </summary>
        public static string SqlQueryColumnCompetence
        {
            get
            {
                return @"select menu_id from tm_competence where user_id=? and menu_type='1' and status='1'";
            }
        }

        /// <summary>
        /// 查询功能菜单树状结构
        /// </summary>
        public static string SqlQueryMenuTree
        {
            get
            {
                return @"select t.menu_id,t.menu_name,t.parent_id from gm_menu t where t.status='1'";
            }
        }

        /// <summary>
        /// 查询用户菜单拥有的权限
        /// </summary>
        public static string SqlQueryMenuCompetence
        {
            get
            {
                return @"select menu_id from tm_competence where user_id=? and menu_type='0' and status='1'";
            }
        }

        /// <summary>
        /// 添加用户权限
        /// </summary>
        public static string SqlInsertCompetence
        {
            get
            {
                return @"insert into tm_competence
                          (competence_id, user_id, menu_id, menu_type, status, creater_by, creater_date)
                        values
                          (tm_competence_seq.nextval, ?, ?, ?, '1', ?, sysdate)";
            }
        }

        //        /// <summary>
        //        /// 添加用户栏目权限
        //        /// </summary>
        //        public static string SqlInsertColumnCompetence
        //        {
        //            get
        //            {
        //                return @"insert into tm_competence
        //                          (competence_id, user_id, menu_id, menu_type, status, creater_by, creater_date)
        //                        values
        //                          (tm_competence_seq.nextval, ?, ?, ?, '1', ?, sysdate)";
        //            }
        //        }

        /// <summary>
        /// 删除用户权限
        /// </summary>
        public static string SqlDeleteCompetence
        {
            get
            {
                return @"update tm_competence
                           set  
                               status = '0',
                               update_by = ?,
                               update_date = sysdate
                         where user_id = ?";
            }
        }
        #endregion

        #region 前台
        /// <summary>
        /// 获得树形列表
        /// </summary>
        public static string SqlQueryTreeList
        {
            get
            {
                return @"select * from (select level-1 lv,t.* from GM_COLUMN_TREE t where t.status='1'
                        start with PARENT_ID is null 
                        connect by prior COLUMN_TREE_ID=PARENT_ID)tr where tr.lv<4 and tr.lv>0";
            }
        }
        /// <summary>
        /// 根据id查询出所有子集
        /// </summary>
        public static string SqlQueryTreeByID
        {
            get
            {
                return @"select level lv, t.*
                      from GM_COLUMN_TREE t
                     where t.status = '1'
                     start with COLUMN_TREE_ID = ?
                    connect by prior COLUMN_TREE_ID = PARENT_ID
                    order by lv asc,COLUMN_NO asc";
            }
        }
        /// <summary>
        /// 根据id查询出父一级
        /// </summary>
        public static string SqlQueryPatTree
        {
            get
            {
                return @"select pt.*
                      from GM_COLUMN_TREE t, GM_COLUMN_TREE pt
                     where t.status = '1'
                       and t.parent_id = pt.column_tree_id
                       and t.COLUMN_TREE_ID = ?
                       and pt.status = '1'";
            }
        }
        /// <summary>
        /// 根据父级id查询出树形
        /// </summary>
        public static string SqlQueryTreeByPatID
        {
            get
            {
                return @"select tr.*,nvl2(tr.score,tr.score||'分，','')||tr.score_standard scr_std
                      from gm_column_tree tr
                     where tr.status = '1'
                       and tr.parent_id = ?
                     order by tr.column_no";
            }
        }
        /// <summary>
        /// 根据id查询出自己
        /// </summary>
        public static string SqlQueryTreeBySelfID
        {
            get
            {
                return @"select *
                      from gm_column_tree tr
                     where tr.status = '1'
                       and tr.COLUMN_TREE_ID = ?
                     order by tr.column_no";
            }
        }
        /// <summary>
        /// 根据id查询资料
        /// </summary>
        public static string SqlQueryZLByID
        {
            get
            {
                return @"select * from gm_data t where t.status='1' and t.column_tree_id=?";
            }
        }
        /// <summary>
        /// 根据id查询出所有父级
        /// </summary>
        public static string SqlQueryParentByID
        {
            get
            {
                return @"select level lv, t.*
                      from GM_COLUMN_TREE t
                     where t.status = '1'
                     start with COLUMN_TREE_ID = ?
                    connect by COLUMN_TREE_ID = prior PARENT_ID
                    order by lv desc,COLUMN_NO asc";
            }
        }
        #endregion

        #region 资料评审
        /// <summary>
        /// 获得评审状态
        /// </summary>
        public static string SqlQueryCheckState
        {
            get
            {
                return @"select t.* from GM_CODE t where t.code_type='CHECK_STATE'";
            }
        }
        public static string SqlQueryCheckResult
        {
            get
            {
                return @"select t.* from GM_CODE t where t.code_type='CHECK_RESULT'";
            }
        }
        /// <summary>
        /// 根据评审状态查询条款
        /// </summary>
        public static string SqlQueryCheckByState
        {
            get
            {
                return @"select t.*, c.name state_name,c1.name result_name
                      from TT_CHECK t, gm_code c,gm_code c1
                     where t.status = '1'
                       and {0}
                       and c.code = t.check_state
                       and c1.code(+)=t.check_result
                       order by t.tree_name";
            }
        }
        /// <summary>
        /// 修改条款状态
        /// </summary>
        public static string SqlModifyCheckState
        {
            get
            {
                return @"update tt_check set check_state = ?,submit_date=sysdate,update_by=?,update_date=sysdate where check_id = ?";
            }
        }
        /// <summary>
        /// 根据id获得条款
        /// </summary>
        public static string SqlQueryCheckByID
        {
            get
            {
                return @"select t.*, c.name state_name, c1.name result_name
                      from TT_CHECK t, gm_code c, gm_code c1
                     where t.status = '1'
                       and t.check_id=?
                       and c.code = t.check_state
                       and c1.code(+) = t.check_result";
            }
        }
        /// <summary>
        /// 评审
        /// </summary>
        public static string SqlModifyCheck
        {
            get
            {
                return @"update tt_check
                       set 
                           check_state = ?,
                           check_result = ?,
                           check_advice = ?,
                           rectification = ?,
                           end_date = ?,
                           check_user_id = ?,
                           check_user_name = ?,
                           check_date = ?,
                           update_by = ?,
                           update_date = sysdate
                           {0}
                     where check_id = ?";
            }
        }
        #endregion
    }
}
