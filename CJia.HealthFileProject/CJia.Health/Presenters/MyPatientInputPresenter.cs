using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class MyPatientInputPresenter : CJia.Health.Tools.Presenter<Models.MyPatientInputModel, Views.IMyPatientInputView>
    {
        public MyPatientInputPresenter(Views.IMyPatientInputView view)
            : base(view)
        {
            view.OnDelete += view_OnDelete;
            view.OnCommit += view_OnCommit;
            view.OnUndo += view_OnUndo;
            view.OnCheckSateChanged += view_OnCheckSateChanged;
        }

        void view_OnCheckSateChanged(object sender, Views.MyPatientInputArgs e)
        {
            DataTable data = Model.GetPatientByCheckState(User.UserData.Rows[0]["USER_ID"].ToString(), e.CheckSate);
            View.ExeBindMyPatient(ChangeDate(data));
        }

        void view_OnUndo(object sender, Views.MyPatientInputArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string str in e.HealthID)
                {
                    Model.ModifyCheckState(trans.ID, str, "104", User.UserData.Rows[0]["USER_ID"].ToString());
                    Model.ModifyPicStateByHealthID(trans.ID, str, "100", User.UserData.Rows[0]["USER_ID"].ToString());
                }
                trans.Complete();
            }
        }

        void view_OnCommit(object sender, Views.MyPatientInputArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string str in e.HealthID)
                {
                    Model.ModifyCheckState(trans.ID, str, "103", User.UserData.Rows[0]["USER_ID"].ToString());
                    //将病案下对应的图片一并提交
                    Model.ModifyPicStateByHealthID(trans.ID, str, "103", User.UserData.Rows[0]["USER_ID"].ToString());
                }
                trans.Complete();
            }
        }

        void view_OnDelete(object sender, Views.MyPatientInputArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string str in e.HealthID)
                {
                    Model.DeletePatient(trans.ID, str, User.UserData.Rows[0]["USER_ID"].ToString());
                    Model.DeletePicByHealthID(trans.ID, str, User.UserData.Rows[0]["USER_ID"].ToString());
                }
                trans.Complete();
            }
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
