using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 发药统计View层
    /// </summary>
    public interface IPharmSendStatSelectView : Tools.IView
    {
        /// <summary>
        /// 统计打印事件
        /// </summary>
        event EventHandler<PharmSendStatSelectArgs> OnStatPrint;
        /// <summary>
        /// 初始化绑定病区与批次
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        void ExeInit(DataTable data1, DataTable data2);
        /// <summary>
        /// 绑定统计报表
        /// </summary>
        /// <param name="data"></param>
        void ExeBindReport(DataTable data);
    }
    /// <summary>
    /// 发药统计参数类
    /// </summary>
    public class PharmSendStatSelectArgs : EventArgs
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Start;
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime End;
        /// <summary>
        /// 病区id
        /// </summary>
        public string OfficeID = "";
        /// <summary>
        /// 批次id
        /// </summary>
        public int BatchID = 0;
    }
}
