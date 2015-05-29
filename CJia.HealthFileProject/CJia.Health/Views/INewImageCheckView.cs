﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface INewImageCheckView : CJia.Health.Tools.IView
    {
        event EventHandler<NewImageCheckViewArgs> OnSreach;

        event EventHandler<NewImageCheckViewArgs> OnSelectPic;

        event EventHandler<NewImageCheckViewArgs> OnPass;

        event EventHandler<NewImageCheckViewArgs> OnNoPass;

        event EventHandler<NewImageCheckViewArgs> OnDelete;

        event EventHandler<NewImageCheckViewArgs> OnLockFunction;

        event EventHandler<NewImageCheckViewArgs> OnCheckReason;

        event EventHandler<NewImageCheckViewArgs> OnAddCheckReason;

        event EventHandler<NewImageCheckViewArgs> OnRemoveCheckReason;

        event EventHandler<NewImageCheckViewArgs> OnYesLook;

        event EventHandler<NewImageCheckViewArgs> OnNOLook;

        event EventHandler<NewImageCheckViewArgs> OnPrint;

        event EventHandler<NewImageCheckViewArgs> OnExport;

        event EventHandler<NewImageCheckViewArgs> OnLock;

        event EventHandler<NewImageCheckViewArgs> OnUnLock;

        void ExeUnLock(bool result);

        void ExePrint(bool result);

        void ExeExport(bool result);

        void ExeYesLook(bool result);

        void ExeNoLook(bool result);

        void ExeLock(bool result);

        void ExeOpenLock(bool result);

        void ExePass(bool result);

        void ExeNoPass(bool result);

        void ExeDelete(bool result);

        void ExePic(DataTable AllPicture);

        void ExePatient(DataTable result);

        void ExeLockFunction(bool result);

        void ExeCheckReason(DataTable result);
       
       
    }
    public class NewImageCheckViewArgs : EventArgs
    {
        /// <summary>
        /// 图片id
        /// </summary>
        public string pictureId = "";

        /// <summary>
        /// 病案号
        /// </summary>
        public string healthId = "";

        /// <summary>
        /// 原审核状态
        /// </summary>
        public string originalCheckStatus = "";

        /// <summary>
        /// 审核原因
        /// </summary>
        public string checkReason = "";

        /// <summary>
        /// 审核原因
        /// </summary>
        public string checkReasonId = "";
    }
}
