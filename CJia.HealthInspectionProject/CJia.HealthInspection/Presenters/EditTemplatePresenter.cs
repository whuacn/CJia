using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class EditTemplatePresenter:Tools.PresenterPage<Models.EditTemplateModel,Views.IEditTemplate>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public EditTemplatePresenter(Views.IEditTemplate view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnBigTempChange += view_OnBigTempChange;
            view.OnMidTempChange += view_OnMidTempChange;
            view.OnSmlTemplateChange += view_OnSmlTemplateChange;
            view.OnEditSave += view_OnEditSave;
        }

        void view_OnEditSave(object sender, Views.AddTemplateArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                bool bol1 = Model.ModifyTemplate(trans.ID, e.TemplateName, User.UserData.Rows[0]["USER_ID"].ToString(), e.TemplateID);
                bool bol2 = Model.DeleteTitleFromTemp(trans.ID, User.UserData.Rows[0]["USER_ID"].ToString(), e.TemplateID);
                bool bol3 = true;
                if (e.CheckTitleToTempData != null && e.CheckTitleToTempData.Rows.Count > 0)
                {
                    foreach (DataRow dr in e.CheckTitleToTempData.Rows)
                    {
                        bol3 = Model.AddTitleToTemplate(trans.ID, e.TemplateID, dr["CHECK_TITLE_ID"].ToString(), User.UserData.Rows[0]["USER_ID"].ToString());
                        if (!bol3)
                        {
                            break;
                        }
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

        void view_OnSmlTemplateChange(object sender, Views.AddTemplateArgs e)
        {
            DataTable data = Model.GetCheckTitleByType(e.SmallTemplateID, e.OrganId);
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
            DataTable titleData = Model.GetTemplateByID(e.TemplateID);
            View.ExeBindTemplate(titleData);
        }
    }
}
