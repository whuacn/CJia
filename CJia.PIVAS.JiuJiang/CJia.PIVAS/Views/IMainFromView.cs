using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    public interface IMainFromView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 查询是否有未审核的医嘱
        /// </summary>
        event EventHandler<MainFromEventArgs> OnQueryNoCheckAdvice;

        /// <summary>
        /// 查询有无未审核医嘱回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryNoCheckAdvice(bool result);

        /// <summary>
        /// 查询是否有未审核的医嘱
        /// </summary>
        event EventHandler<MainFromEventArgs> OnQueryExceptionLabel;

        /// <summary>
        /// 判断库存
        /// </summary>
        event EventHandler<MainFromEventArgs> OnQueryStorage;

        /// <summary>
        /// 查询未打印瓶贴
        /// </summary>
        event EventHandler<MainFromEventArgs> OnQueryNoPrintLabel;

        /// <summary>
        /// 查询有无未审核医嘱回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryExceptionLabel(DataTable result);

        /// <summary>
        /// 返回库存情况
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryStorage(DataTable result);

        /// <summary>
        /// 返回未打印瓶贴情况
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryNoPrintLabel(DataTable result);
    }
    
    /// <summary>
    /// 接口类
    /// </summary>
    public class MainFromEventArgs : EventArgs
    { 
       
    }
}
