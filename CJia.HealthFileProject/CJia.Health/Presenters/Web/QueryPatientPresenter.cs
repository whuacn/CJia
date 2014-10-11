using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class QueryPatientPresenter : CJia.Health.Tools.PresenterPage<Models.Web.QueryPatientModel, Views.Web.IQueryPatientView>
    {
        public QueryPatientPresenter(Views.Web.IQueryPatientView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnProviceChanged += view_OnProviceChanged;
            view.OnDeptChanged += view_OnDeptChanged;
            view.OnSelect += view_OnSelect;
        }

        void view_OnSelect(object sender, Views.Web.QueryPatientArgs e)
        {
            DataTable recordData = Model.QueryPatient(e.Patient);
            DataTable applyData = Model.GetApply(e.UserData.Rows[0]["USER_ID"].ToString());
            if (recordData != null && applyData == null)
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
                View.ExeBindSelectRecord(recordData);
            }
            else if (recordData != null && applyData != null)
            {
                View.ExeBindSelectRecord(isApply(recordData, applyData));
            }
            else
            {
                View.ExeBindSelectRecord(null);
            }
        }

        void view_OnDeptChanged(object sender, Views.Web.QueryPatientArgs e)
        {
            DataTable data = Model.QueryDoctor(e.DeptID);
            View.ExeBIndDoctor(data, e.i);
        }

        void view_OnProviceChanged(object sender, Views.Web.QueryPatientArgs e)
        {
            DataTable data = Model.QueryCity(e.ProviceID);
            View.ExeBindCity(data);
        }

        void view_OnInit(object sender, EventArgs e)
        {
            DataTable icdData = Model.QueryICDCode();
            DataTable zlData = Model.QueryTreatResult();
            DataTable dept = Model.QueryDept();
            DataTable provice = Model.QueryProvince();
            View.ExeBind(icdData, zlData, dept, provice);
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
