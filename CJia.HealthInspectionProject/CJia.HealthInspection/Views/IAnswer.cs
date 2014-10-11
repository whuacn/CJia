using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IAnswer : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<AnswerArgs> OnQueryAnswerByTitleID;
        event EventHandler<AnswerArgs> OnQueryAnswerResultByID;
        void ExeBindAnswer(DataTable dtAnswer);
        void ExeBindAnswerResult(DataTable dtRusult);
    }

    public class AnswerArgs : EventArgs
    {
        /// <summary>
        /// 要回到的问题ID 
        /// </summary>
        public long CheckTitleID;

        /// <summary>
        /// 题目结果ID
        /// </summary>
        public long AnswerID;
    }
}
