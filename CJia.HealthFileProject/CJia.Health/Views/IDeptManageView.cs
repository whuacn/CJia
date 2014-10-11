using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IDeptManageView : CJia.Health.Tools.IView
    {
        event EventHandler<DeptArgs> OnQueryDept;

        event EventHandler<DeptArgs> OnUpdateDept;

        event EventHandler<DeptArgs> OnAddDept;

        event EventHandler<DeptArgs> OnDeleteDept;

        void ExeBindDept(DataTable dtDept);
    }

    public class DeptArgs : EventArgs
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KewWord;

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName;

        /// <summary>
        /// 科室编号
        /// </summary>
        public string DeptNo;

        /// <summary>
        /// 拼音查询码
        /// </summary>
        public string DeptPinYin;

        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserID;
    }
}
