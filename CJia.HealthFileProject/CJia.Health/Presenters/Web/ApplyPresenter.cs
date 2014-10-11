using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class ApplyPresenter : CJia.Health.Tools.PresenterPage<Models.Web.ApplyModel, Views.Web.IApplyView>
    {
        public ApplyPresenter(Views.Web.IApplyView view)
            : base(view)
        {
            view.OnSelectRecord += view_OnSelectRecord;
            view.OnApply += view_OnApply;
        }

        void view_OnApply(object sender, Views.Web.ApplyEventArgs e)
        {
            Model.AddApplyInfo(e.RecordNO, e.UserData.Rows[0]["USER_ID"].ToString(), e.UserData.Rows[0]["USER_NAME"].ToString());
        }

        void view_OnSelectRecord(object sender, Views.Web.ApplyEventArgs e)
        {
            DataTable applyData = Model.GetApply(e.UserData.Rows[0]["USER_ID"].ToString());
            DataTable recordData = Model.GetRecordByPatientInfo(e.PatientName);
            if (applyData != null && recordData != null)
            {
                View.ExeBindRecord(isApply(recordData, applyData));
            }
            else if (recordData != null && applyData == null)
            {
                DataColumn dc = new DataColumn("FLAG", typeof(String));
                recordData.Columns.Add(dc);
                foreach (DataRow dr in recordData.Rows)
                {
                    dr["FLAG"] = "提交申请";
                }
                View.ExeBindRecord(recordData);
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
                string recordNO = dr["RECORDNO"].ToString();
                foreach (DataRow dr1 in applyData.Rows)
                {
                    string recordNO1 = dr1["RECORDNO"].ToString();
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
                    dr["FLAG"] = "提交申请";
                    dr["ENABLE"] = true;
                }
            }
            return recordData;
        }
        #endregion
    }
}
