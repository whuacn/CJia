using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IApprovalBorrowView : CJia.Health.Tools.IView
    {
        event EventHandler<ApprovalBorrowArgs> OnQueryBorrow;

        event EventHandler<ApprovalBorrowArgs> OnQueryLoadData;

        event EventHandler<ApprovalBorrowArgs> OnPassBorrow;

        event EventHandler<ApprovalBorrowArgs> OnRefuseBorrow;

        void ExeBindBorrow(DataTable dtBorrowList,DataTable dtRecord);

        void ExeLoadData(DataTable dtDept, DataTable dtBorrowState);

    }

    public class ApprovalBorrowArgs :EventArgs
    {
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime BeginDate;

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndDate;

        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 借阅状态
        /// </summary>
        public string BorrowState;

        /// <summary>
        /// 借阅单号集合
        /// </summary>
        public List<string> BorrowListId;
        /// <summary>
        /// 借阅归回时间
        /// </summary>
        public DateTime ReturnDate = DateTime.MinValue;
    }
}
