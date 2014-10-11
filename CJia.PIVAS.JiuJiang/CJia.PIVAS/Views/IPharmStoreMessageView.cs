using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    public interface IPharmStoreMessageView : Tools.IView
    {
        /// <summary>
        /// 继续冲药事件
        /// </summary>
        event EventHandler<PharmStoreMessageArgs> OnGoPharmSend;
    }
    /// <summary>
    /// 库存不足，继续冲药
    /// </summary>
    public class PharmStoreMessageArgs : EventArgs
    {
        /// <summary>
        /// 第N次冲药id
        /// </summary>
        public int timeID;
    }

}
