using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    public class PharmStoreMessagePresenter : Tools.Presenter<Models.PharmStoreMessageModel, Views.IPharmStoreMessageView>
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public PharmStoreMessagePresenter(Views.IPharmStoreMessageView view)
            : base(view)
        {
            view.OnGoPharmSend += view_OnGoPharmSend;
        }

        void view_OnGoPharmSend(object sender, Views.PharmStoreMessageArgs e)
        {
            string seq = Model.GetPharmSendSeq();
            bool bol = Model.ModifyExeStatusByTimeID(seq, User.UserId, e.timeID, User.UserName);
            if (bol) { View.ShowMessage("继续冲药成功"); }
        }
    }
}
