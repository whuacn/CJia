using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class ReadExeTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.ReadExeTaskModel, Views.IReadExeTask>
    {
        public ReadExeTaskPresenter(Views.IReadExeTask view)
            : base(view)
        {
            view.OnInitTouchFiled += view_OnInitTouchFiled;
            view.OnQueryExeTaskById += view_OnQueryExeTaskById;
            view.OnInitExeTaskTitle += view_OnInitExeTaskTitle;
        }

        void view_OnInitExeTaskTitle(object sender, Views.ReadExeTaskArgs e)
        {
            DataTable dtExeTaskTitle = Model.QueryExeTaskTitleById(e.ExeTaskId);
            if (dtExeTaskTitle != null)
            {
                //View.ExeBindExeCheckTitle(dtExeCheckTitle);
                for (int i = 0; i < dtExeTaskTitle.Rows.Count; i++)
                {
                    long titieId = Convert.ToInt64(dtExeTaskTitle.Rows[i]["CHECK_TITLE_ID"]);
                    string titleName = dtExeTaskTitle.Rows[i]["CHECK_TITLE_NAME"].ToString();
                    string titleContent = dtExeTaskTitle.Rows[i]["CHECK_TITLE_CONTENT"].ToString();
                    long checkAnswer = Convert.ToInt64(dtExeTaskTitle.Rows[i]["TITLE_ANSWER"]);
                    string titleResult = dtExeTaskTitle.Rows[i]["RESULT"].ToString();
                    string titleAdvice = dtExeTaskTitle.Rows[i]["ADVICE"].ToString();
                    DataTable dtAnswer = Model.QueryAnswerByTitleIDForRead(titieId);
                    //if (dtAnswer != null)
                    //{
                        View.ExeBindTaskTitle(dtAnswer, titieId.ToString(), titleName, titleContent, checkAnswer, titleResult, titleAdvice);
                    //}
                }
            }
        }

        void view_OnQueryExeTaskById(object sender, Views.ReadExeTaskArgs e)
        {
            DataTable dtExeTask = Model.QueryExeTaskById(e.ExeTaskId);
            if (dtExeTask != null)
            {
                View.ExeBindExeTask(dtExeTask);
            }
        }

        void view_OnInitTouchFiled(object sender, Views.ReadExeTaskArgs e)
        {
            DataTable dtTouchFiled = Model.QueryTouchFiled();
            if (dtTouchFiled != null)
            {
                View.ExeBindTouchFiled(dtTouchFiled);
            }
        }
    }
}
