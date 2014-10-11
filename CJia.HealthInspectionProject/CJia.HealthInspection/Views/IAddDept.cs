using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IAddDept : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.AddDeptArgs> OnSave;

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        void ExeMessage(string message);
    }

    public class AddDeptArgs : EventArgs
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptNo;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName;

        /// <summary>
        /// 组织流水号
        /// </summary>
        public string OrganId;

        /// <summary>
        /// 登录用户流水号
        /// </summary>
        public string UserId;
        
    }
}
