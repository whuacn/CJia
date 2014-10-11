using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IReadExeTask : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<ReadExeTaskArgs> OnQueryExeTaskById;
        event EventHandler<ReadExeTaskArgs> OnInitTouchFiled;
        event EventHandler<ReadExeTaskArgs> OnInitExeTaskTitle;
        void ExeBindExeTask(DataTable dtExeTask);
        void ExeBindTouchFiled(DataTable dtTouchFiled);
        void ExeBindTaskTitle(DataTable dtTitleAnswer, string TitleID, string TitleName, string TitleContent, long CheckAnswerId, string TitleResult, string TitleAdvice);
    }

    public class ReadExeTaskArgs : EventArgs
    {
        /// <summary>
        /// 执行任务ID
        /// </summary>
        public long ExeTaskId;


        /// <summary>
        /// 题目ID
        /// </summary>
        public long TitleID;
    }
}
