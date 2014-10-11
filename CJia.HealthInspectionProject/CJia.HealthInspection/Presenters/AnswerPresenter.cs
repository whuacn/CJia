using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class AnswerPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.AnswerModel, Views.IAnswer>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AnswerPresenter(Views.IAnswer view)
            : base(view)
        {
            view.OnQueryAnswerByTitleID += view_OnQueryAnswerByTitleID;
            view.OnQueryAnswerResultByID += view_OnQueryAnswerResultByID;
        }

        void view_OnQueryAnswerResultByID(object sender, Views.AnswerArgs e)
        {
            DataTable dtResult = Model.QueryAnswerRusultByID(e.AnswerID);
            View.ExeBindAnswerResult(dtResult);
        }

        void view_OnQueryAnswerByTitleID(object sender, Views.AnswerArgs e)
        {
            DataTable dtAnswers = Model.QuyerAnswerByTitleID(e.CheckTitleID);
            View.ExeBindAnswer(dtAnswers);

        }
    }
}
