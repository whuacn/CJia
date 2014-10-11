using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class PatientApplyPresenter : CJia.Health.Tools.PresenterPage<Models.Web.PatientApplyModel, Views.Web.IPatientApplyView>
    {
        public PatientApplyPresenter(Views.Web.IPatientApplyView view)
            : base(view)
        {
            view.OnApply += view_OnApply;
        }

        void view_OnApply(object sender, Views.Web.PatientApplyArgs e)
        {
            if (e.HealthIDList.Count > 0)
            {
                string borrowSeq = Model.GetBorrowSeq();
                string borrowNO = Model.GetBorrowNO();
                using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    bool bolBorrow = Model.AddBorrow(trans.ID, borrowSeq, borrowNO, e.Reason, e.UserData.Rows[0]["USER_ID"].ToString(), e.UserData.Rows[0]["USER_NAME"].ToString());
                    for (int i = 0; i < e.HealthIDList.Count; i++)
                    {
                        bool bolBorrowDetail = Model.AddBorrowDetail(trans.ID, e.HealthIDList[i], borrowSeq, e.UserData.Rows[0]["USER_ID"].ToString());
                    }
                    trans.Complete();
                }
                DataTable recordData = Model.QueryPatient(e.Patient);
                DataTable applyData = Model.GetApply(e.UserData.Rows[0]["USER_ID"].ToString());
                if (applyData == null)
                {
                    DataColumn dc = new DataColumn("FLAG", typeof(String));
                    DataColumn dc1 = new DataColumn("ENABLE", typeof(Boolean));
                    recordData.Columns.Add(dc);
                    recordData.Columns.Add(dc1);
                    foreach (DataRow dr in recordData.Rows)
                    {
                        dr["ENABLE"] = true;
                        dr["FLAG"] = "";
                    }
                    View.ExeBindPatient(recordData);
                }
                else if (recordData != null && applyData != null)
                {
                    View.ExeBindPatient(isApply(recordData, applyData));
                }
            }
        }
        #region 内部调用方法
        /// <summary>
        /// 数据整合
        /// </summary>
        /// <param name="recordData"></param>
        /// <param name="applyData"></param>
        /// <returns></returns>
        public DataTable isApply(DataTable recordData, DataTable applyData)
        {
            DataColumn dc = new DataColumn("FLAG", typeof(String));
            DataColumn dc1 = new DataColumn("ENABLE", typeof(Boolean));
            recordData.Columns.Add(dc);
            recordData.Columns.Add(dc1);
            foreach (DataRow dr in recordData.Rows)
            {
                bool isExit = false;
                string recordNO = dr["ID"].ToString();
                foreach (DataRow dr1 in applyData.Rows)
                {
                    string recordNO1 = dr1["HEALTH_ID"].ToString();
                    if (recordNO == recordNO1)
                    {
                        isExit = true;
                    }
                }
                if (isExit)
                {
                    dr["FLAG"] = "已申请";
                    dr["ENABLE"] = false;
                }
                else
                {
                    dr["FLAG"] = " ";
                    dr["ENABLE"] = true;
                }
            }
            return recordData;
        }
        #endregion
    }
}
