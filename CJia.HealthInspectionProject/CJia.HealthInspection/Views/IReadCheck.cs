using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IReadCheck : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<ReadCheckArgs> OnQueryExeCheckById;
        event EventHandler<ReadCheckArgs> OnInitTouchFiled;
        event EventHandler<ReadCheckArgs> OnInitExeCheckTitle;
        //event EventHandler<ReadCheckArgs> OnQueryTitleAnswer;
        void ExeBindExeCheck(DataTable dtExeCheck);
        void ExeBindTouchFiled(DataTable dtTouchFiled);
        void ExeBindExeCheckTitle(DataTable dtTitleAnswer, string TitleID, string TitleAnswerName, long CheckAnswerId, string TitleResult, string TitleAdvice );
        //void ExeBindTitleAnswer(DataTable dtAnswer);
    }

    public class ReadCheckArgs : EventArgs
    {
        /// <summary>
        /// 监督Id
        /// </summary>
        public long ExeCheckId;

        /// <summary>
        /// 题目ID
        /// </summary>
        public long TitleID;
    }
}
