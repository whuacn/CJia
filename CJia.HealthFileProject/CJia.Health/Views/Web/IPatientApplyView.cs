using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IPatientApplyView : CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 提交借阅申请
        /// </summary>
        event EventHandler<PatientApplyArgs> OnApply;
        /// <summary>
        /// 绑定病案
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPatient(DataTable data);
    }
    public class PatientApplyArgs : EventArgs
    {
        /// <summary>
        /// 病案号
        /// </summary>
        public List<string> HealthIDList;
        /// <summary>
        /// 查询条件
        /// </summary>
        public MyPatient Patient;
        /// <summary>
        /// 借阅原因
        /// </summary>
        public string Reason;
        public DataTable UserData;
    }
}
