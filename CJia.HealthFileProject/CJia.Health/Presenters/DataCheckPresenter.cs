using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class DataCheckPresenter : CJia.Health.Tools.Presenter<Models.DataCheckModel, Views.IDataCheckView>
    {
        public DataCheckPresenter(Views.IDataCheckView view)
            : base(view)
        {
            this.View.OnSreach += View_OnSreach;
            this.View.OnSelectPic += View_OnSelectPic;
            this.View.OnLock += View_OnLock;
            this.View.OnOpenLock += View_OnOpenLock;
            this.View.OnPass += View_OnPass;
            this.View.OnNoPass += View_OnNoPass;
            this.View.OnDelete += View_OnDelete;
            this.View.OnLockFunction += View_OnLockFunction;
        }

        void View_OnLockFunction(object sender, Views.DataCheckArgs e)
        {
            this.View.ExeLockFunction(this.Model.GetLockFunction(CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString()));
        }

        void View_OnDelete(object sender, Views.DataCheckArgs e)
        {
            this.View.ExeDelete(this.Model.ModifCheckStatus(e.healthId, "100"));
            this.Model.InsertCheckReason(e.healthId, e.CheckReason, e.checkStatus, "100", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString());
        }

        void View_OnNoPass(object sender, Views.DataCheckArgs e)
        {
            this.View.ExeNoPass(this.Model.ModifCheckStatus(e.healthId, "102"));
            this.Model.InsertCheckReason(e.healthId, e.CheckReason, e.checkStatus, "102", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString());
        }

        void View_OnPass(object sender, Views.DataCheckArgs e)
        {
            this.View.ExePass(this.Model.ModifCheckStatus(e.healthId, "101"));
            this.Model.InsertCheckReason(e.healthId, e.CheckReason, e.checkStatus, "101", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString());
        }

        void View_OnOpenLock(object sender, Views.DataCheckArgs e)
        {
            this.View.ExeOpenLock(this.Model.ModifLockStatus(e.healthId, "110"));
        }

        void View_OnLock(object sender, Views.DataCheckArgs e)
        {
            this.View.ExeLock(this.Model.ModifLockStatus(e.healthId, "111"));
        }

        void View_OnSelectPic(object sender, Views.DataCheckArgs e)
        {
            this.View.ExePic(this.Model.SelectPic(e.healthId));
        }

        void View_OnSreach(object sender, Views.DataCheckArgs e)
        {
            this.View.ExePatient(this.Model.Sreach(e.start, e.end, e.search));
        }
    }
}
