using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class ChangePwdPresenter : CJia.Parking.Tools.Presenter<Models.ChangePwdModel,Views.IChangePwdView>
    {
        public ChangePwdPresenter(Views.IChangePwdView view)
            : base(view)
        {
            view.OnSavePwd += view_OnSavePwd;
        }

        /// <summary>
        /// 保存更改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSavePwd(object sender, Views.ChangePwdArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            if (Model.UpdateUserPwd(e.NewPassword, userId, userId))
            {
                Message.Show("修改成功！");
            }
        }
    }
}
