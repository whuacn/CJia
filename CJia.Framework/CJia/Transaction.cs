using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia
{
    /// <summary>
    /// 客户端事务
    /// </summary>
    public sealed class Transaction : IDisposable
    {
        DataAdapter ada = null;
        /// <summary>
        /// 客户端事务
        /// </summary>
        public Transaction()
        {
            TransactionID = System.Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 客户端事务
        /// </summary>
        public Transaction(DataAdapter Adapter)
        {
            ada = Adapter;
            TransactionID = System.Guid.NewGuid().ToString();
        }
        private string TransactionID = string.Empty;
        /// <summary>
        /// 事务ID
        /// </summary>
        public string ID
        {
            get { return TransactionID; }
        }
        /// <summary>
        /// 完成标志
        /// </summary>
        private bool isComplete = false;
        /// <summary>
        /// 事务完成
        /// </summary>
        public void Complete()
        {
            isComplete = true;
        }
        #region IDisposable 成员
        /// <summary>
        ///  清理所有正在使用的资源
        /// </summary>
        public void Dispose()
        {
            if (isComplete)
            {//事务完成，没有发生任何异常
                if (ada == null)
                    DefaultData.CommitTransaction(TransactionID);
                else
                    ada.CommitTransaction(TransactionID);
            }
            else
            {//客户端发生异常，导致无法继续，事务回滚
                if (ada == null)
                    DefaultData.RollbackTransaction(TransactionID);
                else
                    ada.RollbackTransaction(TransactionID);
            }
        }
        #endregion
    }
}
