using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class ChangePasswordPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.ChangePasswordModel, Views.IChangePassword>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public ChangePasswordPresenter(Views.IChangePassword view)
            : base(view)
        {
            view.OnSave += view_OnSave;
        }

        void view_OnSave(object sender, Views.ChangePasswordArgs e)
        {
            bool bol = Model.ModifyPassword(e.UserData.Rows[0]["USER_ID"].ToString(), e.NewPassword);
            View.ExeIsSuccess(bol);
        }
    }
}
