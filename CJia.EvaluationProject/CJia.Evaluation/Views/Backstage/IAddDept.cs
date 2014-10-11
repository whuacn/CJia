using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IAddDept :CJia .Evaluation.Tools.IPage
    {
        event EventHandler<AddDeptArgs> OnQueryAllDept;
        event EventHandler<AddDeptArgs> OnInsertDept;
        void ExeBindDept(DataTable dtDept);
        void ExeReturnAddDeptMsg(bool isInsert);
    }
    public class AddDeptArgs : EventArgs
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName;
        /// <summary>
        /// 父级科室Id
        /// </summary>
        public string ParentId;
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId;
    }
}
