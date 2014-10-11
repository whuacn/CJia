using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IMyBorrowView:CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 初始化
        /// </summary>
        event EventHandler<MyBorrowArgs> OnLoadBorrow;
        /// <summary>
        /// 详情
        /// </summary>
        event EventHandler<MyBorrowArgs> OnDetail;
        /// <summary>
        /// 初始化绑定
        /// </summary>
        /// <param name="data"></param>
        void ExeInit(DataTable data);
        /// <summary>
        /// 绑定详情
        /// </summary>
        /// <param name="data"></param>
        void ExeDetail(DataTable data);

    }
    public class MyBorrowArgs : EventArgs
    {
        /// <summary>
        /// 申请单id
        /// </summary>
        public string ListID;
        public DataTable UserData;
    }
}
