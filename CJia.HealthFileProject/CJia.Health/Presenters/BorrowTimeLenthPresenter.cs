using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class BorrowTimeLenthPresenter : CJia.Health.Tools.Presenter<Models.BorrowTimeLenthModel, Views.IBorrowTimeLenthView>
    {
        public BorrowTimeLenthPresenter(Views.IBorrowTimeLenthView view)
            : base(view)
        {
            view.OnQueryBorrowTime += view_OnQueryBorrowTime;
            view.OnQueryDocDescript += view_OnQueryDocDescript;
            view.OnInsertBorrowTime += view_OnInsertBorrowTime;
            view.OnUpdateBorrowTime += view_OnUpdateBorrowTime;
            view.OnDeleteBorrowTime += view_OnDeleteBorrowTime;
        }

        void view_OnDeleteBorrowTime(object sender, Views.BorrowTimeLenthArgs e)
        {
            bool IsDelete = Model.DeleteBorrowTime(User.UserData.Rows[0]["USER_ID"].ToString(), e.BorrowTimeId);
            if (!IsDelete)
            {
                View.ShowWarning("删除失败");
            }
        }

        void view_OnUpdateBorrowTime(object sender, Views.BorrowTimeLenthArgs e)
        {
            bool IsUpdate = Model.UpdateBorrowTime(e.BorrowTime, User.UserData.Rows[0]["USER_ID"].ToString(), e.BorrowTimeId);
            if (!IsUpdate)
            {
                View.ShowWarning("修改失败");
            }
        }

        void view_OnInsertBorrowTime(object sender, Views.BorrowTimeLenthArgs e)
        {
            bool IsInsert = Model.InsertBorrowTime(e.DocDes, e.BorrowTime, User.UserData.Rows[0]["USER_ID"].ToString());
            if (!IsInsert)
            {
                View.ShowWarning("添加失败");
            }
        }

        void view_OnQueryDocDescript(object sender, Views.BorrowTimeLenthArgs e)
        {
            View.ExeBindDocDescript(Model.QueryDocDescript());
        }

        void view_OnQueryBorrowTime(object sender, Views.BorrowTimeLenthArgs e)
        {
            DataTable dt = Model.QueryBorrowTime();
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                View.ExeBindData(dt);
            }
        }
    }
}
