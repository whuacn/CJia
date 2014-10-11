using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class SqlTools
    {
        #region 【登录】
        /// <summary>
        /// 查询登录用户
        /// </summary>
        public static string SqlSelectLoginUser
        {
            get
            {
                return @"select * from gm_user where user_no=:1 and user_pwd=:2 and status='1'";
            }
        }
        #endregion

        #region 【楼层区域维护】

        #region 【楼层】
        /// <summary>
        /// 查询是否存在相同楼层号
        /// </summary>
        public static string SqlSelectIsExistSameFloorNo
        {
            get
            {
                return @"select * from gm_floor where floor_no=:1 and status='1'";
            }
        }

        /// <summary>
        /// 插入楼层表
        /// </summary>
        public static string SqlInsertFloor
        {
            get
            {
                return @"insert into gm_floor(floor_no,status,create_by,create_date)
                         values(:1,'1',:2,current_timestamp)";
            }
        }

        /// <summary>
        /// 查询楼层表的有效数据
        /// </summary>
        public static string SqlSelectFloor
        {
            get
            {
                return @"select * from gm_floor where status='1'";
            }
        }

        /// <summary>
        /// 删除时楼层时查询区域信息表中是否有存在正在使用的楼层流水号
        /// </summary>
        public static string SqlSelectIsExistUsingFloorIdWhenDelete
        {
            get
            {
                return @"select * from gm_area where floor_id=:1 and status='1'";
            }
        }

        /// <summary>
        /// 删除选中楼层
        /// </summary>
        public static string SqlDeleteFloor
        {
            get
            {
                return @"update gm_floor set status='0',update_by=:1,update_date=current_timestamp where floor_id=:2";
            }
        }

        /// <summary>
        /// 修改楼层信息表数据
        /// </summary>
        public static string SqlUpdateFloor
        {
            get
            {
                return @"update gm_floor set floor_no=:1,update_by=:2,update_date=current_timestamp where floor_id=:3";
            }
        }
        #endregion

        #region 【区域】

        /// <summary>
        /// 查询是否存在相同区域号
        /// </summary>
        public static string SqlSelectIsExistSameAreaNo
        {
            get
            {
                return @"select * from gm_area where area_no=:1 and floor_id=:2 and status='1'";
            }
        }

        /// <summary>
        /// 插入区域表
        /// </summary>
        public static string SqlInsertArea
        {
            get
            {
                return @"insert into gm_area(area_no,floor_id,status,create_by,create_date)
                         values(:1,:2,'1',:3,current_timestamp)";
            }
        }

        /// <summary>
        /// 查询区域表的有效数据
        /// </summary>
        public static string SqlSelectArea
        {
            get
            {
                return @"select ga.*,gf.floor_no from gm_area ga,gm_floor gf
                        where ga.floor_id=:1 and gf.floor_id=ga.floor_id 
                        and ga.status='1' and gf.status='1'";
            }
        }

        /// <summary>
        /// 删除时区域时查询车位信息表中是否有存在正在使用的区域流水号
        /// </summary>
        public static string SqlSelectIsExistUsingAreaIdWhenDelete
        {
            get
            {
                return @"select * from gm_park_info where area_id=:1 and status='1'";
            }
        }

        /// <summary>
        /// 删除选中区域
        /// </summary>
        public static string SqlDeleteArea
        {
            get
            {
                return @"update gm_area set status='0',update_by=:1,update_date=current_timestamp where area_id=:2";
            }
        }

        /// <summary>
        /// 修改区域表信息
        /// </summary>
        public static string SqlUpdateArea
        {
            get
            {
                return @"update gm_area set area_no=:1,update_by=:2,update_date=current_timestamp where area_id=:3";
            }
        }
        #endregion

        #region 【车位】
        /// <summary>
        /// 查询是否存在相同车位号
        /// </summary>
        public static string SqlSelectIsExistSameParkNo
        {
            get
            {
                return @"select * from gm_park_info where park_no=:1 and status='1'";
            }
        }

        /// <summary>
        /// 插入车位信息表
        /// </summary>
        public static string SqlInsertParkInfo
        {
            get
            {
                return @"insert into gm_park_info(park_no,area_id,camera_no,park_status,status,create_by,create_date) 
                         values(:1,:2,:3,'1','1',:4,current_timestamp)";
            }
        }

        /// <summary>
        /// 查询车位信息
        /// </summary>
        public static string SqlSelectParkInfo
        {
            get
            {
                return @"SELECT
	                        gpi.*, ga.area_no,
	                        gf.floor_no,
	                        (
		                        CASE
		                        WHEN gpi.park_status = '1' THEN
			                        '空闲'
		                        ELSE
			                        '占用'
		                        END
	                        ) park_status_name
                        FROM
	                        gm_park_info gpi,
	                        gm_area ga,
	                        gm_floor gf
                        WHERE
	                        gpi.area_id = ga.area_id
                        AND ga.floor_id = gf.floor_id
                        AND gpi.area_id = :1
                        AND gpi.status = '1'
                        AND ga.status = '1'
                        AND gf.status = '1'";
            }
        }

        /// <summary>
        /// 删除车位信息
        /// </summary>
        public static string SqlDeleteParkInfo
        {
            get
            {
                return @"update gm_park_info set status='0',update_by=:1,update_date=current_timestamp where park_id=:2";
            }
        }

        /// <summary>
        /// 修改车位信息
        /// </summary>
        public static string SqlUpdateParkInfo
        {
            get
            {
                return @"update gm_park_info set park_no=:1,camera_no=:2,update_by=:3,
                             update_date=current_timestamp 
                         where park_id=:4";
            }
        }
        #endregion

        #endregion

        #region【车辆寻路】
        #region
        /// <summary>
        /// 车牌查询
        /// </summary>
        public static string SqlLicenceQuery
        {
            get
            {
                return @"select res.* 
                        from  
		                        (select row_number() over() rownumber,* 
		                        from vt_park 
		                        where  substring(plate_no from 3) like :1 
		                        and park_status='2' 
		                        and status='1' 
		                        order by in_park_date desc) res
                        where rownumber BETWEEN :2 and :3  ";
            }
        }

        /// <summary>
        /// 车位查询
        /// </summary>
        public static string SqlParkQuery
        {
            get
            {
                return @"select res.*
                        from 
                            (SELECT row_number() over() rownumber,* 
                            from vt_park
                            where park_no like :1
                            and park_status='2' 
                            and status='1'
                            order by in_park_date desc) res
                        where rownumber BETWEEN :2 and :3";
            }
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        public static string SqlFastQuery
        {
            get
            {
                return @"select kd.* from 
                            (select row_number() over() rownumber, res.* 
                             from 
                                (select * from vt_park 
                                where  plate_no=:1 or park_no = :2
                                UNION 
                                select * from vt_park 
                                where plate_no like :3  or park_no like :4 
                                UNION 
                                select * from vt_park
                                where plate_no like :5 or park_no like :6
                                UNION  
                                select * from vt_park 
                                where (plate_no like :7 and plate_no like :8 and plate_no like :9 and plate_no like :10 and plate_no like :11)
                                or (park_no like :12 and park_no like :13 and park_no like :14 and park_no like :15 and park_no like :16)) res 
                            where park_status='2' 
                            and status='1') kd
                            where rownumber BETWEEN :17 and :18";
            }
        }

        /// <summary>
        /// 查询所有的点
        /// </summary>
        public static string SqlQueryPoint
        {
            get
            {
                return "select DISTINCT point_id, point_no,\"point_X\",\"point_Y\" from gm_point where status='1'";
            }
        }

        public static string SqlQueryAllPoint
        {
            get
            {
                return @"select * from gm_point order by point_no";
            }
        }
        
        /// <summary>
        /// 查询两点之间距离
        /// </summary>
        public static string SqlQueryPointToPoint
        {
            get 
            {
                return @"select * from vt_point_to_point where point_id=:1 ";
            }
        }

        /// <summary>
        /// 根据点的编号查询其坐标
        /// </summary>
        public static string SqlQueryPointByPointNo
        {
            get
            { 
                return @"select * from gm_point  where point_no=:1 and status='1'";
            }
        }
        
        #endregion
        #endregion

        #region 【用户角色】

        #region 【角色】
        /// <summary>
        /// 查询角色表
        /// </summary>
        public static string SqlSelectRole
        {
            get
            {
                return @"select * from gm_role where status='1'";
            }
        }

        /// <summary>
        /// 查询是否存在相同角色名
        /// </summary>
        public static string SqlSelectIsExistSameRoleName
        {
            get
            {
                return @"select * from gm_role where role_name=:1 and status='1'";
            }
        }

        /// <summary>
        /// 插入角色表
        /// </summary>
        public static string SqlInsertRole
        {
            get
            {
                return @"insert into gm_role(role_name,status,create_by,create_date) 
                         values(:1,'1',:2,current_timestamp)";
            }
        }

        /// <summary>
        /// 修改角色表
        /// </summary>
        public static string SqlUpdateRole
        {
            get
            {
                return @"update gm_role set role_name=:1,
                              update_by=:2,update_date=current_timestamp 
                         where role_id=:3";
            }
        }

        /// <summary>
        /// 删除时角色时查询用户角色关联表中是否有存在正在使用的角色流水号
        /// </summary>
        public static string SqlSelectIsExistUsingRoleIdWhenDelete
        {
            get
            {
                return @"select * from tr_user_role where role_id=:1 and status='1'";
            }
        }
        
        /// <summary>
        /// 删除角色表
        /// </summary>
        public static string SqlDeleteRole
        {
            get
            {
                return @"update gm_role set status='0', update_by=:1,update_date=current_timestamp
                         where role_id=:2";
            }
        }
        #endregion

        #region 【用户】
        /// <summary>
        /// 查询用户信息
        /// </summary>
        public static string SqlSelectUser
        {
            get
            {
                return @"select tur.*,gu.* from gm_user gu left join            
     (select tur.user_id tur_user_id,
             array_to_string(ARRAY(SELECT unnest(array_agg(gr.role_name))),',') union_role_name
                                  from tr_user_role tur, gm_role gr
                                 where tur.role_id = gr.role_id
                                   and tur.status = '1'
                                   and gr.status = '1'
                                 group by tur.user_id)tur 
     on tur.tur_user_id=gu.user_id
       where gu.status='1'";
            }
        }

        /// <summary>
        /// 查询是否存在相同用户名
        /// </summary>
        public static string SqlSelectIsExistSameUserNo
        {
            get
            {
                return @"select * from gm_user where user_no=:1 and status='1'";
            }
        }

        /// <summary>
        /// 查询用户表sequence
        /// </summary>
        public static string SqlSelectUserSeq
        {
            get
            {
                return @"select nextval('gm_user_user_id_seq')";
            }
        }

        /// <summary>
        /// 插入用户表
        /// </summary>
        public static string SqlInsertUser
        {
            get
            {
                return @"insert into gm_user(user_id,user_name,user_no,user_pwd,status,create_by,create_date)
                         values(:1,:2,:3,'8888','1',:4,current_timestamp)";
            }
        }

        /// <summary>
        /// 插入用户角色关联表
        /// </summary>
        public static string SqlInsertUserRole
        {
            get
            {
                return @"insert into tr_user_role(user_id,role_id,status,create_by,create_date)
                         values(:1,:2,'1',:3,current_timestamp)";
            }
        }

        /// <summary>
        /// 删除用户角色关联表
        /// </summary>
        public static string SqlDeleteUserRole
        {
            get
            {
                return @"update tr_user_role set status='0' where user_id=:1";
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public static string SqlUpdateUser
        {
            get
            {
                return @"update gm_user set user_name=:1,user_no=:2,user_pwd=:3,
                            update_by=:4,update_date=current_timestamp where user_id=:5";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static string SqlDeleteUser
        {
            get
            {
                return @"update gm_user set status='0' where user_id=:1";
            }
        }

        /// <summary>
        /// 根据用户绑定所选用户权限
        /// </summary>
        public static string SqlSelectUserRoleByUserId
        {
            get
            {
                return @"select * from tr_user_role where user_id=:1 and status='1'";
            }
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        public static string SqlUpdateUserPassword
        {
            get
            {
                return @"update gm_user set user_pwd=:1,update_by=:2,update_date=current_timestamp 
                         where user_id=:3";
            }
        }
        #endregion

        #endregion

        #region 【会员类型维护】
        /// <summary>
        /// 查询会员类型表
        /// </summary>
        public static string SqlSelectMemType
        {
            get
            {
                return @"select * from gm_mem_type where status='1'";
            }
        }

        /// <summary>
        /// 查询是否存在相同会员类型名
        /// </summary>
        public static string SqlSelectIsExistSameMemType
        {
            get
            {
                return @"select * from gm_mem_type where mem_type=:1 and status='1'";
            }
        }

        /// <summary>
        /// 插入会员类型表
        /// </summary>
        public static string SqlInsertMemType
        {
            get
            {
                return @"insert into gm_mem_type(mem_type,price,status,create_by,create_date)
                         values(:1,:2,'1',:3,current_timestamp)";
            }
        }

        /// <summary>
        /// 修改会员类型表
        /// </summary>
        public static string SqlUpdateMemType
        {
            get
            {
                return @"update gm_mem_type set mem_type=:1,price=:2,
                                                update_by=:3,update_date=current_timestamp
                         where mem_type_id=:4";
            }
        }

        /// <summary>
        /// 删除会员类型表数据
        /// </summary>
        public static string SqlDeleteMemType
        {
            get
            {
                return @"update gm_mem_type set status='0',update_by=:1,update_date=current_timestamp
                         where mem_type_id=:2";
            }
        }
        #endregion

        #region 【会员维护】
        /// <summary>
        /// 查询会员缴费信息
        /// </summary>
        public static string SqlSelectMember
        {
            get
            {
                return @"select * from gm_member where status='1'";
            }
        }
        
        /// <summary>
        /// 查询是否存在相同会员编号
        /// </summary>
        public static string SqlSelectIsExistSameMemberNo
        {
            get
            {
                return @"select * from gm_member where mem_no=:1 and status='1'";
            }
        }

        /// <summary>
        /// 查询是否存在相同车牌号
        /// </summary>
        public static string SqlSelectIsExistSamePlateNo
        {
            get
            {
                return @"select * from gm_member where plate_no=:1 and status='1'";
            }
        }

        /// <summary>
        /// 插入会员表
        /// </summary>
        public static string SqlInsertMember
        {
            get
            {
                return @"insert into gm_member(mem_no,mem_name,plate_no,check_date,
                                                status,create_by,create_date)
                         values(:1,:2,:3,current_date,'1',:4,current_timestamp)";
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        public static string SqlUpdateMember
        {
            get
            {
                return @"update gm_member set mem_no=:1,mem_name=:2,plate_no=:3,
                          update_by=:4,update_date=current_timestamp where mem_id=:5";
            }
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        public static string SqlDeleteMember
        {
            get
            {
                return @"update gm_member set status='0',update_by=:1,update_date=current_timestamp
                         where mem_id=:2";
            }
        }
        #endregion

        #region 【会员缴费】
        /// <summary>
        /// 查询所选会员所有未过期的充值记录
        /// </summary>
        public static string SqlSelectMemPaylogByMemId
        {
            get
            {
                return @"select gm.*,pl.start_date,pl.effective_date,pay_amount,pay_date 
                        from gm_member gm,pt_pay_log pl 
                        where gm.mem_id=:1
                              and gm.mem_id=pl.mem_id 
                              and effective_date>=current_date
                              and gm.status='1' 
                              and pl.status='1'";
            }
        }

        /// <summary>
        /// 同一会员时间段不能重叠
        /// </summary>
        public static string SqlSelectIsExistSameTime
        {
            get
            {
                return @"select * from pt_pay_log where :1 between start_date and effective_date 
                and status='1' and mem_id=:2";
            }
        }
               
        /// <summary>
        /// 插入会员缴费日志表
        /// </summary>
        public static string SqlInsertPayLog
        {
            get
            {
                return @"insert into pt_pay_log(mem_id,mem_type_id,free_time,pay_amount,pay_date,
                          start_date,effective_date,status,create_by,create_date)
                         values(:1,:2,:3,:4,current_date,:5,:6,'1',:7,current_timestamp)";
            }
        }
        #endregion

        #region 【缴费查询】
        /// <summary>
        /// 缴费记录查询
        /// </summary>
        public static string SqlSelectMemberPaylog
        {
            get
            {
                return @"select gm.*,pl.start_date,pl.effective_date,pay_amount,pay_date 
                        from gm_member gm,pt_pay_log pl 
                        where gm.mem_id=pl.mem_id 
                              and gm.status='1' 
                              and pl.status='1'
                              {0}/*查询条件*/";
            }
        }
        #endregion

        #region【界面功能权限显示】
        /// <summary>
        /// 查询登录用户所拥有权限
        /// </summary>
        public static string SqlQueryLoginUserRoles
        {
            get
            {
                return @"select role_id from gm_role where role_id not in 
                            (select distinct gr.role_id from gm_role gr,gm_user gu,tr_user_role tur 
                            where gr.role_id=tur.role_id 
                            and gu.user_id=tur.user_id 
                            and gr.status='1'
                            and gu.status='1' 
                            and tur.user_id=:1)";
            }
        }

        #endregion

        #region 【临时停车收费设置】
        /// <summary>
        /// 查询临时停车收费表数据
        /// </summary>
        public static string SqlQueryTemporaryCharge
        {
            get
            {
                return @"select * from gm_temporary_charge where status='1'";
            }
        }

        /// <summary>
        /// 插入临时停车收费表数据
        /// </summary>
        public static string SqlInsertTemporaryCharge
        {
            get
            {
                return @"insert into gm_temporary_charge(free_hour,hour_set,hour_set_fee,
                            upper_hour,upper_hour_fee,status,create_by,create_date)
                         values(:1,:2,:3,:4,:5,'1',:6,current_timestamp)";

            }
        }

        /// <summary>
        /// 修改临时停车收费表数据
        /// </summary>
        public static string SqlUpdateTemporaryCharge
        {
            get
            {
                return @"update gm_temporary_charge set free_hour=:1,hour_set=:2,
                 hour_set_fee=:3,upper_hour=:4,upper_hour_fee=:5";
            }
        }
        #endregion
    }
}
