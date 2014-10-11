using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IReportView : CJia.Editors.IView
    {
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.ReportArgs> OnSelect;
        /// <summary>
        /// 查看报告
        /// </summary>
        event EventHandler<Views.ReportArgs> OnPrint;
        /// <summary>
        /// 绑定病人报告
        /// </summary>
        /// <param name="data"></param>
        void BindReport(DataTable data);
        /// <summary>
        /// 病人姓名输入框获得焦点
        /// </summary>
        void TxtPatientNameFocus();
    }
    /// <summary>
    /// 报告查询参数
    /// </summary>
    public class ReportArgs : EventArgs
    {
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName = "";
        /// <summary>
        /// 报告地址
        /// </summary>
        public string SavePath = "";
        /// <summary>
        /// 报告id
        /// </summary>
        public int ReportID = 0;
    }
}
