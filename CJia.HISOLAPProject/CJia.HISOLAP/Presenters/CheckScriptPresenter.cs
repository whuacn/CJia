using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HISOLAP.Presenters
{
    public class CheckScriptPresenter : Tools.Presenter<Models.CheckScriptModel, Views.ICheckScript>
    {
        public CheckScriptPresenter(Views.ICheckScript view)
            : base(view)
        {
            view.OnInitView += view_OnInitView;
            view.OnDelete += view_OnDelete;
            view.OnModify += view_OnModify;
            view.OnAdd += view_OnAdd;
            view.OnSearch += view_OnSearch;
            view.OnQueryCheckType += view_OnQueryCheckType;
        }

        void view_OnQueryCheckType(object sender, EventArgs e)
        {
            DataTable data = Model.GetCheckType();
            View.ExeBindCheckTypeData(data);
        }

        void view_OnSearch(object sender, Views.CheckScriptArgs e)
        {
            DataTable data = Model.GetScriptByKey(e.Key);
            View.ExeBindData(data);
        }

        void view_OnAdd(object sender, Views.CheckScriptArgs e)
        {
            DataTable data = Model.GetScriptByNO(e.NO);
            if (data != null && data.Rows.Count > 0)
            {
                View.ShowMessage("存在相同的编号！");
                View.ExeFocusNO();
            }
            else
            {
                if (Message.ShowQuery("确定添加？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    bool bol = Model.AddCheckScript(e.NO, e.Test, e.Error, e.CheckID, e.Level, e.Classify, User.UserID);
                    View.ExeIsSuccessAdd(bol);
                }
            }
        }

        void view_OnModify(object sender, Views.CheckScriptArgs e)
        {
            if (e.OldNO != e.NO)
            {
                DataTable data = Model.GetScriptByNO(e.NO);
                if (data != null && data.Rows.Count > 0)
                {
                    View.ShowMessage("存在相同的编号！");
                    View.ExeFocusNO();
                    return;
                }
            }
            if (Message.ShowQuery("确定保存？", Message.Button.OkCancel) == Message.Result.Ok)
            {
                bool bol = Model.ModifyCheckScript(e.NO, e.Test, e.Error, e.CheckID, e.Level, e.Classify, e.Status, User.UserID, e.ID);
                View.ExeIsSuccessModify(bol);
            }
        }

        void view_OnDelete(object sender, Views.CheckScriptArgs e)
        {
            bool bol = Model.DeleteCheckScript(e.ID, User.UserID);
            View.ExeIsSuccessDelete(bol);
        }

        void view_OnInitView(object sender, EventArgs e)
        {
            DataTable data = Model.GetAllScript();
            View.ExeBindData(data);
        }
    }
}
