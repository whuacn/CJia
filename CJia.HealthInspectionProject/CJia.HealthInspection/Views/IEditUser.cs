using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditUser : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditUserArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditUserArgs> OnSave;

         /// <summary>
        /// 绑定界面所选监督人员相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeBindControl(DataTable dtTask);

        /// <summary>
        /// 绑定角色选择框
        /// </summary>
        /// <param name="dtOrganAllRole">某个组织所拥有的角色类型为“2”的全部角色</param>
        /// <param name="dtUserOwnRole">某用户所拥有的全角色</param>
        void ExeCheckBoxList(DataTable dtOrganAllRole, DataTable dtUserOwnRole);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditUserArgs : EventArgs
    {
        /// <summary>
        /// 用户流水号
        /// </summary>
        public string UserId;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 所选角色组
        /// </summary>
        public List<string> RoleArr = new List<string>();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable LoginUser;
    }
}
