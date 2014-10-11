using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class DefaultPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.DefaultModel,Views.IDefault>
    {
        public DefaultPresenter(Views.IDefault view)
            : base(view)
        {
            view.OnQueryFunctionByUserId += view_OnQueryFunctionByUserId;
        }

        /// <summary>
        /// 查询登录用户不存在的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryFunctionByUserId(object sender, Views.DefaultArgs e)
        {
            e.UserFunction = Model.QueryLoginUserOwnFunction(e.LoginUserId);
        }
    }
}
