using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class AddTemplatePresenter : Tools.PresenterPage<Models.AddTemplateModel, Views.IAddTemplate>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AddTemplatePresenter(Views.IAddTemplate view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnBigTempChange += view_OnBigTempChange;
            view.OnMidTempChange += view_OnMidTempChange;
            view.OnSmlTemplateChange += view_OnSmlTemplateChange;
            view.OnSaveTemplate += view_OnSaveTemplate;
        }

        void view_OnSaveTemplate(object sender, Views.AddTemplateArgs e)
        {
            string seq = Model.GetTemplateSeq();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                bool bol = Model.AddTemplate(trans.ID, seq, e.TemplateName, e.SmallTemplateID, User.UserData.Rows[0]["USER_ID"].ToString(),e.OrganId);
                bool bol1 = true;
                if (e.CheckTitleToTempData != null && e.CheckTitleToTempData.Rows.Count > 0)
                {
                    foreach (DataRow dr in e.CheckTitleToTempData.Rows)
                    {
                        bol1 = Model.AddTitleToTemplate(trans.ID, seq, dr["CHECK_TITLE_ID"].ToString(), User.UserData.Rows[0]["USER_ID"].ToString());
                        if (!bol1)
                        {
                            break;
                        }
                    }
                }
                if (bol && bol1)
                {
                    isSuccess = true;
                }
                View.ExeIsSuccess(isSuccess);
                trans.Complete();
            }
        }

        void view_OnSmlTemplateChange(object sender, Views.AddTemplateArgs e)
        {
            DataTable data = Model.GetCheckTitleByType(e.SmallTemplateID,e.OrganId);
            View.ExeBindCheckTitle(data);
        }

        void view_OnMidTempChange(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetSmallTemplateByMid(e.MiddleTemplateID);
            View.ExeBindSmallTemp(data, e.isFirst);
        }

        void view_OnBigTempChange(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetMidTemplateByBig(e.BigTemplateID);
            View.ExeBindMidTemp(data, e.isFirst);
        }

        void view_OnInit(object sender, Views.AddCheckTitleArgs e)
        {
            DataTable data = Model.GetBigTemplate();
            View.ExeBindBigTemp(data, true);
        }
    }
}
