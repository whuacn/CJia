using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class ChangePwdPresenter : CJia.Health.Tools.Presenter<Models.ChangePwdModel, Views.IChangePwdView>
    {
        public ChangePwdPresenter(Views.IChangePwdView view)
            : base(view)
        {
            view.OnCheckOldPwd += view_OnCheckOldPwd;
            view.OnUpdatePwd += view_OnUpdatePwd;
        }

        void view_OnUpdatePwd(object sender, Views.ChangePwdArgs e)
        {
            bool IsUpdate = Model.UpdatePwd(e.NewPwd, e.UserId);
            if (IsUpdate)
            {
                View.ShowMessage("修改成功");
            }
            else
            {
                View.ShowWarning("修改失败");
            }
        }

        void view_OnCheckOldPwd(object sender, Views.ChangePwdArgs e)
        {
            bool bo = Model.CheckOldPwd(e.UserId, e.OldPwd);
            View.ExeCheckOldPwd(bo);
        }
    }
}
