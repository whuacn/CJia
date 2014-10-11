using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class AddCheckTitlePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.AddCheckTitleModel, Views.IAddCheckTitle>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AddCheckTitlePresenter(Views.IAddCheckTitle view)
            : base(view)
        {
            view.OnSave += view_OnSave;
            view.OnInit += View_OnInit;
            view.OnBigTempChange += view_OnBigTempChange;
            view.OnMidTempChange += View_OnMidTempChange;
        }


        void View_OnMidTempChange(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetSmallTemplateByMid(e.MiddleTemplateID);
            View.ExeBindSmallTemp(data,true);
        }

        void view_OnBigTempChange(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetMidTemplateByBig(e.BigTemplateID);
            View.ExeBindMidTemp(data, true);
        }

        void View_OnInit(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetBigTemplate();
            View.ExeBindBigTemp(data, true);
        }

        void view_OnSave(object sender, Views.AddCheckTitleArgs e)
        {
            string seq = Model.GetCheckTitleSeq();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                bool bol1 = Model.AddCheckTitle(trans.ID, seq, e.TitleName, e.TitleContent, e.IsChoice, User.UserData.Rows[0]["USER_ID"].ToString(), User.UserData.Rows[0]["organ_id"].ToString());
                bool bol2 = true;
                if (e.IsChoice == "1")//是选择题
                {
                    if (e.AnswersData != null && e.AnswersData.Rows.Count != 0)
                    {
                        foreach (DataRow dr in e.AnswersData.Rows)
                        {
                            bol2 = Model.AddCheckTitleAnswer(trans.ID, dr["AnswerName"].ToString(), seq, e.User.Rows[0]["USER_ID"].ToString(), dr["Result"].ToString(), dr["Advice"].ToString());
                            if (!bol2)
                            {
                                break;
                            }
                        }
                    }
                }
                bool bol3 = false;
                foreach (string str in e.SmallTemplateTypeIDList)
                {
                    bol3 = Model.AddTitleToTemplate(trans.ID, str, seq, e.User.Rows[0]["USER_ID"].ToString());
                    if (!bol3)
                    {
                        break;
                    }
                }
                if (bol1 && bol2 && bol3)
                {
                    isSuccess = true;
                }
                View.ExeIsSuccess(isSuccess);
                trans.Complete();
            }
        }
    }
}
