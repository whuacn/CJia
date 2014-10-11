using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditSupervise : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditSuperviseArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditSuperviseArgs> OnSave;

         /// <summary>
        /// 绑定界面所选监督人员相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeBindControl(DataTable dtTask);

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree">所有功能</param>
        /// <param name="dtFun">该用户所拥有功能</param>
        void ExeBindTree(DataTable dtTree, DataTable dtFun);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditSuperviseArgs : EventArgs
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
        /// 所属组织ID
        /// </summary>
        public string OrganId;

        /// <summary>
        /// 用户所拥有角色流水号
        /// </summary>
        public string RoleId;

        /// <summary>
        /// 所选功能权限
        /// </summary>
        public List<string> ListFunction = new List<string>();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable LoginUser;
    }
}
