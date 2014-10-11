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
    public class AddUserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddUserModel,CJia.PIVAS.Views.DataManage.IAddUserView>
    {
        public AddUserPresenter(Views.DataManage.IAddUserView view)
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
        void View_OnLeave(object sender, Views.DataManage.addUsereventArgs e)
        {
            bool isUserRepeat=this.Model.IsUserRepeat(e.UserNo);
            if (isUserRepeat)
            {
                this.View.ExeGetFocus();
            }
            
        }

        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnaddUser(object sender, Views.DataManage.addUsereventArgs e)
        {
            bool IsInsert = this.Model.InsertUser(e.UserNo, e.UserName, e.Pwd,e.DeptId, e.DeptName, e.UserId);
            if (IsInsert)
            {
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("���ʧ��");
                this.View.ExeGetFocus();
            }
        }

        protected override void OnInitView()
        {

        }

    }
}