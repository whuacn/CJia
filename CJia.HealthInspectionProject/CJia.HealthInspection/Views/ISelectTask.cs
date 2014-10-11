using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ISelectTask :CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<SelectTaskArgs> OnInitTask;
        event EventHandler<SelectTaskArgs> OnQueryTaskByID;
        void ExeBindTask(DataTable dtTask);
        void ExeGetSelectTask(DataTable dtTask);
    }

    public class SelectTaskArgs : EventArgs
    {
        /// <summary>
        /// 选择的任务ID
        /// </summary>
        public long TaskID;

        /// <summary>
        /// 组织ID
        /// </summary>
        public long OrganId;
    }
}
