using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IFeeListPageView : IView
    {
        /// <summary>
        /// 显示病人费用信息
        /// </summary>
        event EventHandler<FeeListEventArgs> OnShowPatientFee;
        /// <summary>
        /// 显示病人费用信息
        /// </summary>
        /// <param name="FeeList"></param>
        /// <param name="PrepayList"></param>
        void ExeShowPatientFee(List<Data.PatientFee> FeeList,List<Data.PatientPrepay> PrepayList);
    }
    public class FeeListEventArgs : EventArgs
    {
        public FeeListEventArgs(string PatientInhosID)
        {
            InhosID = PatientInhosID;
        }
        public string InhosID;
    }
}
