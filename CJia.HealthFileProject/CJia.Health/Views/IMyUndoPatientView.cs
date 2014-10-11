using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IMyUndoPatientView:CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化加载数据
        /// </summary>
        event EventHandler<MyUndoPatientArgs> OnLoadUndoPatient;
        /// <summary>
        /// 重新提交审核
        /// </summary>
        event EventHandler<MyUndoPatientArgs> OnCommit;
        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<MyUndoPatientArgs> OnDelete;
        /// <summary>
        /// 初始化绑定数据
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPatient(DataTable data);
    }
    public class MyUndoPatientArgs : EventArgs
    {
        /// <summary>
        /// 病案表id
        /// </summary>
        public List<string> HealthID;
    }
}
