using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IImageCheckView : CJia.Health.Tools.IView
    {
        event EventHandler<ImageCheckViewArgs> OnSreach;

        event EventHandler<ImageCheckViewArgs> OnSelectPic;

        event EventHandler<ImageCheckViewArgs> OnPass;

        event EventHandler<ImageCheckViewArgs> OnNoPass;

        event EventHandler<ImageCheckViewArgs> OnDelete;

        event EventHandler<ImageCheckViewArgs> OnLockFunction;

        event EventHandler<ImageCheckViewArgs> OnCheckReason;

        event EventHandler<ImageCheckViewArgs> OnAddCheckReason;

        event EventHandler<ImageCheckViewArgs> OnRemoveCheckReason;



        void ExeLock(bool result);

        void ExeOpenLock(bool result);

        void ExePass(bool result);

        void ExeNoPass(bool result);

        void ExeDelete(bool result);

        void ExePic(DataTable BigPicture, DataTable SmallPicture, DataTable AllPicture);

        void ExePatient(DataTable result);

        void ExeLockFunction(bool result);

        void ExeCheckReason(DataTable result);
       
       
    }
    public class ImageCheckViewArgs : EventArgs
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
