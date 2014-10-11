using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class ReadCheckPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.ReadCheckModel,Views.IReadCheck>
    {
        public ReadCheckPresenter(Views.IReadCheck view)
            : base(view)
        {
            view.OnQueryExeCheckById += view_OnQueryExeCheckById;
            view.OnInitTouchFiled += view_OnInitTouchFiled;
            view.OnInitExeCheckTitle += view_OnInitExeCheckTitle;
            //view.OnQueryTitleAnswer += view_OnQueryTitleAnswer;
        }

        //void view_OnQueryTitleAnswer(object sender, Views.ReadCheckArgs e)
        //{
        //    DataTable dtAnswer = Model.QueryAnswerByTitleIDForRead(e.TitleID);
        //    if (dtAnswer != null)
        //    {
        //        View.ExeBindTitleAnswer(dtAnswer);
        //    }
        //}

        void view_OnInitExeCheckTitle(object sender, Views.ReadCheckArgs e)
        {
            try
            {
                DataTable dtExeCheckTitle = Model.QueryExeCheckTitleById(e.ExeCheckId);
                if (dtExeCheckTitle != null)
                {
                    //View.ExeBindExeCheckTitle(dtExeCheckTitle);
                    for (int i = 0; i < dtExeCheckTitle.Rows.Count; i++)
                    {
                        long titieId = Convert.ToInt64(dtExeCheckTitle.Rows[i]["CHECK_TITLE_ID"]);
                        string titleName = dtExeCheckTitle.Rows[i]["CHECK_TITLE_NAME"].ToString();
                        long checkAnswer = Convert.ToInt64(dtExeCheckTitle.Rows[i]["TITLE_ANSWER"]);
                        string titleResult = dtExeCheckTitle.Rows[i]["RESULT"].ToString();
                        string titleAdvice = dtExeCheckTitle.Rows[i]["ADVICE"].ToString();
                        DataTable dtAnswer = Model.QueryAnswerByTitleIDForRead(titieId);
                        //if (dtAnswer != null)
                        //{
                            View.ExeBindExeCheckTitle(dtAnswer, titieId.ToString(), titleName, checkAnswer, titleResult, titleAdvice);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ExtAspNet.Alert.ShowInTop(ex.Message);
            }
            
        }

        void view_OnInitTouchFiled(object sender, Views.ReadCheckArgs e)
        {
            DataTable dtTouchFiled = Model.QueryTouchFiled();
            if (dtTouchFiled != null)
            {
                View.ExeBindTouchFiled(dtTouchFiled);
            }
        }

        void view_OnQueryExeCheckById(object sender, Views.ReadCheckArgs e)
        {
            DataTable dtExeCheck = Model.QueryExeCheckById(e.ExeCheckId);
            if (dtExeCheck != null)
            {
                View.ExeBindExeCheck(dtExeCheck);
            }
        }
    }
}
