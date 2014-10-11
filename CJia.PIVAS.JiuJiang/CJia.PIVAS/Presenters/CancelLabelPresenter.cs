using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 退药申请P层
    /// </summary>
    public class CancelLabelPresenter : Tools.Presenter<Models.CancelLabelModel, Views.ICancelLabelView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view"></param>
        public CancelLabelPresenter(Views.ICancelLabelView view)
            : base(view)
        {
            view.OnInitIffield += view_OnInitIffield;
            view.OnSelect += view_OnSelect;
            view.OnBtnOK += view_OnBtnOK;
            view.OnBtnRefresh += view_OnBtnRefresh;
        }

        void view_OnBtnRefresh(object sender, Views.CancelLabeEventArgs e)
        {
            DataTable data = Model.GetCancelApplyByIllfiedID(e.Date, e.IffieldID);
            View.ExeBindCancelApply(data);
        }

        void view_OnBtnOK(object sender, Views.CancelLabeEventArgs e)
        {
            string deptID = CJia.PIVAS.User.DeptId;
            string deptName = Model.GetDeptNameByID(deptID).Rows[0]["DEPT_NAME"].ToString();
            if (e.LabelID.Count > 0)
            {
                if (Message.ShowQuery("是否确定提交退药申请？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    for (int i = 0; i < e.LabelID.Count; i++)
                    {
                        bool bol = Model.AddCancelApply(e.LabelID[i], e.LabelBarID[i], User.UserId.ToString(), e.ApplyName, deptID, deptName, e.ApplyReason, User.UserId.ToString(),"1");
                        bool bol1 = Model.ModifyLabelStatusByID(e.LabelID[i], User.UserId.ToString());
                        if (!bol || !bol1)
                        {
                            View.ShowMessage("退药申请提交失败！");
                            return;
                        }
                    }
                    View.ShowMessage("退药申请提交成功！");
                }
            }
        }

        void view_OnSelect(object sender, Views.CancelLabeEventArgs e)
        {
            DataTable data = Model.GetAdviceByIffieldAndBedNO(e.Date, e.IffieldID, e.BedNO,e.barCode,e.PiCi);
            if (data != null)
            {
                DataColumn isChecked = new DataColumn("ISCHECK", typeof(System.Boolean));
                data.Columns.Add(isChecked);
            }
            View.ExeBindAdvice(data);
        }

        void view_OnInitIffield(object sender, Views.CancelLabeEventArgs e)
        {
            DataTable data = Model.QueryAllIffield();
            DataTable piciData = Model.QueryAllBatch();
            View.ExeBindAllIffield(data, piciData);
        }
    }
}
