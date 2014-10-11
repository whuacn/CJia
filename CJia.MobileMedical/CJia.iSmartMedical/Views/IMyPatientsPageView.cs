using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IMyPatientsPageView : IView
    {
        /// <summary>
        /// 请求显示我的病人列表
        /// </summary>
        event EventHandler OnShowMyPatientList;
        /// <summary>
        /// 请求显示科室病人列表
        /// </summary>
        event EventHandler OnShowOfficePatientList;
        /// <summary>
        /// 请求显示值班病人列表
        /// </summary>
        event EventHandler OnShowDutyPatientList;
        /// <summary>
        /// 请求显示近期查房病人列表
        /// </summary>
        event EventHandler OnShowTodayPatientList;
        /// <summary>
        /// 请求显示历史病人列表
        /// </summary>
        event EventHandler OnShowHistoryPatientList;
        /// <summary>
        /// 显示病人列表
        /// </summary>
        /// <param name="PatientList"></param>
        void ExeShowPatientList(List<Data.Patient> PatientList);
    }
}
