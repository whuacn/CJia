using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class MyUndoPatientPresenter:CJia.Health.Tools.Presenter<Models.MyUndoPatientModel,Views.IMyUndoPatientView>
    {
        public MyUndoPatientPresenter(Views.IMyUndoPatientView view)
            : base(view)
        {
            view.OnLoadUndoPatient += view_OnLoadUndoPatient;
            view.OnDelete += view_OnDelete;
            view.OnCommit += view_OnCommit;
        }

        void view_OnCommit(object sender, Views.MyUndoPatientArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string str in e.HealthID)
                {
                    Model.ModifyCheckState(trans.ID, str, "103", User.UserData.Rows[0]["USER_ID"].ToString());
                }
                trans.Complete();
            }
        }

        void view_OnDelete(object sender, Views.MyUndoPatientArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string str in e.HealthID)
                {
                    Model.DeletePatient(trans.ID, str, User.UserData.Rows[0]["USER_ID"].ToString());
                }
                trans.Complete();
            }
        }

        void view_OnLoadUndoPatient(object sender, Views.MyUndoPatientArgs e)
        {
            DataTable data = Model.GetPatientByCheckState(User.UserData.Rows[0]["USER_ID"].ToString(), "102");
            View.ExeBindPatient(ChangeDate(data));
        }
        #region 内部调用方法
        public DataTable ChangeDate(DataTable data)
        {
            if (data != null)
            {
                DataColumn select = new DataColumn("ISCHECK", typeof(bool));
                data.Columns.Add(select);
                foreach (DataRow dr in data.Rows)
                {
                    dr["ISCHECK"] = false;
                }
                return data;
            }
            return null;
        }
        #endregion
    }
}
