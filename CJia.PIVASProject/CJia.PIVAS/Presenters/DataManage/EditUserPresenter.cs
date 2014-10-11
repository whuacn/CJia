using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �޸��û���ϢP��
    /// </summary>
    public class EditUserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditUserModel,CJia.PIVAS.Views.DataManage.IEditUserView>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="view"></param>
        public EditUserPresenter(Views.DataManage.IEditUserView view)
            : base(view)
        {
            this.View.OnUpdateUser += View_OnUpdateUser;
            this.View.OnCheckPwd += View_OnCheckPwd;
        }

        /// <summary>
        /// �жϾ������Ƿ���ȷ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCheckPwd(object sender, Views.DataManage.EditUsereventArgs e)
        {
            bool isOldPwdOk = this.Model.CheckOldPwd(e.OldPwd,e.UserId);
            this.View.ExeIsPwdOk(isOldPwdOk);
        }

        /// <summary>
        /// �޸ĸ���ϸϸ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateUser(object sender, Views.DataManage.EditUsereventArgs e)
        {
            bool isUpdate = this.Model.UpdateUser(e.NewPwd,e.UserId);
            if (isUpdate)
            {
                //this.View.ShowMessage("�޸ĳɹ�");
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("�޸�ʧ��");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}