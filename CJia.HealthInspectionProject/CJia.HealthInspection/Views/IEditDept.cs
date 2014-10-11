using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditDept : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditDeptArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditDeptArgs> OnSave;

        /// <summary>
        /// 绑定界面所选监督人员相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeBindControl(DataTable dtTask);

         /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditDeptArgs : EventArgs
    {
        /// <summary>
        /// 所编辑的部门ID
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 所编辑部门编号
        /// </summary>
        public string DeptNo;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName;

        /// <summary>
        /// 所属组织
        /// </summary>
        public string OrganId;

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;
    }
}
