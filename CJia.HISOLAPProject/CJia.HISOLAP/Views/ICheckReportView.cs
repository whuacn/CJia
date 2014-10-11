using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HISOLAP.Views
{
    public interface ICheckReportView:Tools.IView
    {
        event EventHandler OnInitView;
        event EventHandler<CheckReportArgs> OnSearch;
        event EventHandler<CheckReportArgs> OnCheckData;
        event EventHandler<CheckReportArgs> OnReportData;
        void ExeBindCheckType(DataTable data);
        void ExeBindSearchResult(DataTable data);
        void ExeBindCheckResult(DataTable data);
        bool ExeBindIsSuccessReport(bool bol);
    }
    public class CheckReportArgs : EventArgs
    {
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// 查询截止时间
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 需审核的数据
        /// </summary>
        public DataTable PatientData;
        /// <summary>
        /// 审核完的数据
        /// </summary>
        public DataTable CheckResultPatientData;
        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNO;
        /// <summary>
        /// 住院次数
        /// </summary>
        public string InHosTimes;
    }
}
