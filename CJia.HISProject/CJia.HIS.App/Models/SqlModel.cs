using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HIS.App.Models
{
    public static class SqlModel
    {
        /// <summary>
        /// 根据用户编号与密码返回用户信息 
        /// 1 用户编号 2 用户密码
        /// </summary>
        public static string loginSqlText
        {
            get
            {
                return "select * from gm_user where status = '1' and  user_no = :1 and user_pwd = :2";
            }
        }

        /// <summary>
        /// 获取该用户有权限访问的系统
        /// 1 用户流水号id
        /// </summary>
        public static string GetSystem
        {
            get
            {
                return @"select s.* 
from gm_user u,tr_user_role ur,tm_role r,tr_role_system ts,tm_system s
where u.user_id =  :1 and u.status = '1'
  and u.user_id = ur.user_id and ur.status = '1'
  and ur.role_id = r.role_id and r.status = '1'
  and r.role_id = ts.role_id and ts.status = '1'
  and ts.system_id = s.system_id and s.status = '1'";
            }
        }

        /// <summary>
        /// 获得登录用户查看的系统中的有权限查看的模块对应的菜单
        /// 1 用户流水号id 2 系统流水号id
        /// </summary>
        public static string GetMenu
        {
            get
            {
                return @"select me.* 
from tm_system s,tr_system_menu sm,tm_menu me 
where s.system_id = :1 and s.status = '1'
  and s.system_id = sm.system_id and sm.status = '1'
  and sm.menu_id = me.menu_id and me.status = '1'
  and (me.module_id is null
   or me.module_id not in (select rbm.module_id 
                             from gm_user u,tr_user_role ur,tm_role r,tr_role_ban_module rbm
                            where u.user_id = :2 and u.status = '1'
                              and u.user_id = ur.user_id and ur.status = '1'
                              and ur.role_id = r.role_id and r.status = '1'
                              and r.role_id = rbm.role_id and rbm.status = '1'))";
            }
        }

        /// <summary>
        /// 通过moduleid获取module
        /// </summary>
        public static string GetMoudle
        {
            get
            {
                return @"select * from tm_module where status = '1' and module_id = :1";
            }
        }

        /// <summary>
        /// 获得登录用户查看的系统中的有权限查看的模块对应的快捷工具栏
        /// 1 用户流水号id 2 系统流水号id
        /// </summary>
        public static string GetTool
        {
            get
            {
                return @"select t.* 
from tm_system s,tr_system_tool st,tm_tool t 
where s.system_id = :1 and s.status = '1'
  and s.system_id = st.system_id and st.status = '1'
  and st.tool_id = t.tool_id and t.status = '1'
  and t.module_id not in (select rbm.module_id 
                             from gm_user u,tr_user_role ur,tm_role r,tr_role_ban_module rbm
                            where u.user_id = :2 and u.status = '1'
                              and u.user_id = ur.user_id and ur.status = '1'
                               and ur.role_id = r.role_id and r.status = '1'
                              and r.role_id = rbm.role_id and rbm.status = '1')";
            }
        }

    }
}
