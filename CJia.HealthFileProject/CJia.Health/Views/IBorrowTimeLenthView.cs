using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IBorrowTimeLenthView : CJia.Health.Tools.IView
    {
        event EventHandler<BorrowTimeLenthArgs> OnQueryBorrowTime;

        event EventHandler<BorrowTimeLenthArgs> OnQueryDocDescript;

        event EventHandler<BorrowTimeLenthArgs> OnInsertBorrowTime;

        event EventHandler<BorrowTimeLenthArgs> OnUpdateBorrowTime;

        event EventHandler<BorrowTimeLenthArgs> OnDeleteBorrowTime;

        void ExeBindData(DataTable dt);

        void ExeBindDocDescript(DataTable dt);
    }
    public class BorrowTimeLenthArgs : EventArgs
    {
        /// <summary>
        /// 借阅时间Id 
        /// </summary>
        public string BorrowTimeId;

        /// <summary>
        /// 职称ID
        /// </summary>
        public string DocDes;

        /// <summary>
        /// 借阅天数
        /// </summary>
        public int BorrowTime;
    }
}
