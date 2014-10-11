using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IEditDept : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<EditDeptArgs> OnInitDept;
        event EventHandler<EditDeptArgs> OnUpdateDept;
        event EventHandler<EditDeptArgs> OnQueryDeptById;
        void ExeBingDept(DataTable dtDept);
        void ExeReturnUpdateMsg(bool isUpdate);
        void ExeBindParentDept(DataTable dtDept);
    }

    public class EditDeptArgs : EventArgs
    {
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId;
        /// <summary>
        /// 科室名称   
        /// </summary>
        public string DeptName;
        /// <summary>
        /// 父级科室ID
        /// </summary>
        public string ParentDeptID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId;
    }
}
