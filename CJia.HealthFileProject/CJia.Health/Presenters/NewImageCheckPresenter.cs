﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class NewImageCheckPresenter : CJia.Health.Tools.Presenter<Models.NewImageCheckModel, Views.INewImageCheckView>
    {
        public NewImageCheckPresenter(Views.INewImageCheckView view)
            : base(view)
        {
            this.View.OnSreach += View_OnSreach;
            this.View.OnSelectPic += View_OnSelectPic;
            this.View.OnPass += View_OnPass;
            this.View.OnNoPass += View_OnNoPass;
            this.View.OnDelete += View_OnDelete;
            this.View.OnLockFunction += View_OnLockFunction;
            this.View.OnCheckReason += View_OnCheckReason;
            this.View.OnAddCheckReason += View_OnAddCheckReason;
            this.View.OnRemoveCheckReason += View_OnRemoveCheckReason;
        }

        void View_OnRemoveCheckReason(object sender, Views.NewImageCheckViewArgs e)
        {
            this.Model.DeleteCheckReason(e.checkReasonId);
        }

        void View_OnAddCheckReason(object sender, Views.NewImageCheckViewArgs e)
        {
            this.Model.InsertCheckReason(e.checkReason);
        }

        void View_OnCheckReason(object sender, Views.NewImageCheckViewArgs e)
        {
            this.View.ExeCheckReason(this.Model.SelectCheckReason());
        }

        void View_OnSreach(object sender, Views.NewImageCheckViewArgs e)
        {
            this.View.ExePatient(this.Model.SreahPatient(e.healthId));
        }

        void View_OnLockFunction(object sender, Views.NewImageCheckViewArgs e)
        {
            this.View.ExeLockFunction(this.Model.GetLockFunction(CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString()));
        }

        void View_OnDelete(object sender, Views.NewImageCheckViewArgs e)
        {
            if(this.Model.ModifPictureCheckStatus(e.pictureId, CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), "103"))
            {
                if(this.Model.InsertPictureCheckReason(e.pictureId, e.checkReasonId, e.checkReason, e.originalCheckStatus, "103", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString()))
                {
                    this.View.ExeDelete(true);
                    return;
                }
            }
            this.View.ExeDelete(false);
        }

        void View_OnNoPass(object sender, Views.NewImageCheckViewArgs e)
        {
            if(this.Model.ModifPictureCheckStatus(e.pictureId, CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), "102"))
            {
                if(this.Model.InsertPictureCheckReason(e.pictureId, e.checkReasonId, e.checkReason, e.originalCheckStatus, "102", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString()))
                {
                    this.View.ExeNoPass(true);
                    return;
                }
            }
            this.View.ExeNoPass(false);
       }

        void View_OnPass(object sender, Views.NewImageCheckViewArgs e)
        {
            if(this.Model.ModifPictureCheckStatus(e.pictureId, CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), "101"))
            {
                if(this.Model.InsertPictureCheckReason(e.pictureId, e.checkReasonId, e.checkReason, e.originalCheckStatus, "101", CJia.Health.User.UserData.Rows[0]["USER_ID"].ToString(), CJia.Health.User.UserData.Rows[0]["USER_NAME"].ToString()))
                {
                    this.View.ExePass(true);
                    return;
                }
            }
            this.View.ExePass(false);
        }

        void View_OnSelectPic(object sender, Views.NewImageCheckViewArgs e)
        {
            DataTable AllPicture = this.Model.SelectPic(e.healthId);
            this.View.ExePic(AllPicture);
        }

    }
}