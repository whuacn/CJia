using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IMyPatientInputView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<MyPatientInputArgs> OnDelete;
        /// <summary>
        /// 提交审核事件
        /// </summary>
        event EventHandler<MyPatientInputArgs> OnCommit;
        /// <summary>
        /// 撤销审核事件 
        /// </summary>
        event EventHandler<MyPatientInputArgs> OnUndo;
        /// <summary>
        /// 审核状态改变事件
        /// </summary>
        event EventHandler<MyPatientInputArgs> OnCheckSateChanged;
        /// <summary>
        /// 绑定我的病人
        /// </summary>
        /// <param name="data"></param>
        void ExeBindMyPatient(DataTable data);
    }
    public class MyPatientInputArgs : EventArgs
    {
        /// <summary>
        /// 病人表id
        /// </summary>
        public List<string> HealthID;
        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckSate;
    }
}
