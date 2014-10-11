using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IRegNoCheckView : CJia.Editors.IView
    {
        /// <summary>
        /// 删除登记未排队的病人
        /// </summary>
        event EventHandler<Views.RegNoCheckArgs> OnDelete;
        /// <summary>
        /// 绑定登记未排队就诊病人
        /// </summary>
        /// <param name="data"></param>
        void ExeBindRegNoCheckPatient(DataTable data);
    }
    /// <summary>
    /// 登记未排队检查参数
    /// </summary>
    public class RegNoCheckArgs : EventArgs
    {
        /// <summary>
        /// 病人id
        /// </summary>
        public int? PatientID = null;
    }
}
