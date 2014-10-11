using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class ApprovalBorrowPresenter : CJia.Health.Tools.Presenter<Models.ApprovalBorrowModel, Views.IApprovalBorrowView>
    {
        public ApprovalBorrowPresenter(Views.IApprovalBorrowView view)
            : base(view)
        {
            view.OnQueryBorrow += view_OnQueryBorrow;
            view.OnQueryLoadData += view_OnQueryLoadData;
            view.OnPassBorrow += view_OnPassBorrow;
            view.OnRefuseBorrow += view_OnRefuseBorrow;
        }

        void view_OnRefuseBorrow(object sender, Views.ApprovalBorrowArgs e)
        {
            bool IsRefuse = true;
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string borrowListId in e.BorrowListId)
                {
                    IsRefuse = IsRefuse && Model.RefuseBorrow(trans.ID, borrowListId, User.UserData.Rows[0]["USER_ID"].ToString(), User.UserData.Rows[0]["USER_NAME"].ToString());
                }
                trans.Complete();
            }
            if (!IsRefuse)
            {
                Message.Show("拒绝失败");
            }
        }

        void view_OnPassBorrow(object sender, Views.ApprovalBorrowArgs e)
        {
            bool IsPass = true;
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (string borrowList in e.BorrowListId)
                {
                    IsPass = IsPass && Model.PassBorrow(trans.ID, borrowList, User.UserData.Rows[0]["USER_ID"].ToString(), User.UserData.Rows[0]["USER_NAME"].ToString());
                }
                trans.Complete();
            }
            if (!IsPass)
            {
                Message.Show("批准失败");
            }
        }

        void view_OnQueryLoadData(object sender, Views.ApprovalBorrowArgs e)
        {
            DataTable dtDept = Model.QueryDept();
            DataRow dr = dtDept.NewRow();
            dr["DEPT_NAME"] = "全院";
            dr["DEPT_ID"] = "";
            dtDept.Rows.Add(dr);
            DataTable dtBorrowState = Model.QueryBorrowState();
            for (int i = 0; i < dtBorrowState.Rows.Count; i++)
            {
                if (dtBorrowState.Rows[i]["CODE"].ToString() == "93")
                {
                    dtBorrowState.Rows.RemoveAt(i);
                }
            }
            View.ExeLoadData(dtDept, dtBorrowState);
        }

        void view_OnQueryBorrow(object sender, Views.ApprovalBorrowArgs e)
        {
            DataTable dtBorrowList = Model.QueryBorrowList(e.BeginDate,e.EndDate,e.DeptId,e.BorrowState);
            DataTable dtHealthFile = Model.QueryRecord(e.BeginDate, e.EndDate, e.DeptId, e.BorrowState);
            
            DataColumn isChecked = new DataColumn("ISCHECK", typeof(System.Boolean));
            isChecked.DefaultValue = false;
            dtBorrowList.Columns.Add(isChecked);
            View.ExeBindBorrow(dtBorrowList, dtHealthFile);
            
            
            
        }
    }
}
