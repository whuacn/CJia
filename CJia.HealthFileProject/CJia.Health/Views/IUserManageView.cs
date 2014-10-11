using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views 
{
    public interface IUserManageView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.UserArgs> OnInit;

        /// <summary>
        /// 新增用户事件
        /// </summary>
        event EventHandler<UserArgs> OnInsertUser;

        /// <summary>
        /// 模糊查询部门
        /// </summary>
        event EventHandler<Views.UserArgs> OnQueryDept;

        /// <summary>
        /// 更新用户
        /// </summary>
        event EventHandler<Views.UserArgs> OnUpdateUser;

        /// <summary>
        /// 删除用户
        /// </summary>
        event EventHandler<Views.UserArgs> OnDeleteUser;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        event EventHandler<Views.UserArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        event EventHandler<Views.UserArgs> OnSearch;

        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="dtDocDept"></param>
        void ExeBindDept(DataTable dtDocDept);

         /// <summary>
        /// 绑定医生职称
        /// </summary>
        /// <param name="dtDoctorDescript"></param>
        void ExeBindDoctorDescript(DataTable dtDoctorDescript);

        /// <summary>
        /// 绑定界面角色选择框
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeBindRole(DataTable dtRole);

        /// <summary>
        /// 绑定Grid
        /// </summary>
        /// <param name="dtUser"></param>
        void ExeBindGridUser(DataTable dtUser);

        /// <summary>
        /// 设定用户权限选择状态
        /// </summary>
        /// <param name="dtRole"></param>
        void ExeSetRoleChecked(DataTable dtRole);
    }

    public class UserArgs : EventArgs
    {
        /// <summary>
        /// 插入操作是否成功
        /// </summary>
        public bool IsInsertSuccess = true;

        /// <summary>
        /// 所选角色ID
        /// </summary>
        public List<object> ListRoleId = new List<object>();

        /// <summary>
        /// 所选角色Name
        /// </summary>
        public List<object> ListRoleName = new List<object>();

        /// <summary>
        /// 根据userId搜索到的数据从Model层传到页面绑定
        /// </summary>
        public DataTable TableUserRole = null;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 用户流水号
        /// </summary>
        public long UserId;

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord;

        /// <summary>
        /// 存在原名程度
        /// </summary>
        public string ExistName;

        /// <summary>
        /// 医生职称
        /// </summary>
        public string DoctorDescript;
    }
}
