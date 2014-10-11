using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IPatientSelectView : CJia.Editors.IView
    {
        /// <summary>
        /// 病人卡号查询事件
        /// </summary>
        event EventHandler<Views.PatientSelectArgs> OnSelectByNO;
        /// <summary>
        /// 病人姓名查询事件
        /// </summary>
        event EventHandler<Views.PatientSelectArgs> OnSelectByName;
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.PatientSelectArgs> OnSelect;
        /// <summary>
        /// 病人卡号输入框获得焦点
        /// </summary>
        void TxtPatientNOFocus();
        /// <summary>
        /// 病人姓名输入框获得焦点
        /// </summary>
        void TxtPatientNameFocus();
        /// <summary>
        /// 绑定病人信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPatient(DataTable data);
    }
    /// <summary>
    /// 病人查询参数
    /// </summary>
    public class PatientSelectArgs : EventArgs
    {
        /// <summary>
        /// 输入的病人卡号
        /// </summary>
        public string PatientNO = "";
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName = "";
    }
}
