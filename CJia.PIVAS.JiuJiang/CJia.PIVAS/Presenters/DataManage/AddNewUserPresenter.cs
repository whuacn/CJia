using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// ����û�P��
    /// </summary>
    public class AddNewUserPresenter : PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.NewAddUserModel, CJia.PIVAS.Views.DataManage.INewAddUserView>
    {
        public AddNewUserPresenter(Views.DataManage.INewAddUserView view)
            : base(view)
        {
            this.View.OnLeave += View_OnLeave;
            this.View.OnaddUser += View_OnaddUser;
        }

        /// <summary>
        /// ���������ʧȥ���� �ж�������������������Ƿ����ظ����ж���His���Ƿ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLeave(object sender, Views.DataManage.NewaddUsereventArgs e)
        {
            bool isUserRepeat = this.Model.IsUserRepeat(e.UserNo);
            this.View.ExeGetFocus(isUserRepeat);
        }

        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnaddUser(object sender, Views.DataManage.NewaddUsereventArgs e)
        {
            bool IsInsert = this.Model.InsertUser(e.UserNo, e.Pwd, e.UserId, e.IsAdmin,e.role);
            if(IsInsert)
            {
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("���ʧ��");
                this.View.ExeGetFocus(true);
            }
        }

        protected override void OnInitView()
        {

        }

    }
}