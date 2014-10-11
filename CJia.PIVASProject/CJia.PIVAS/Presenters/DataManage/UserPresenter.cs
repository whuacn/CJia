using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �û�ά����P��
    /// </summary>
    public class UserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.UserModel,CJia.PIVAS.Views.DataManage.IUserView>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="view"></param>
        public UserPresenter(Views.DataManage.IUserView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnDeleteUser += View_OnDeleteUser;
        }

        //��ʼ��gridcontrol����
        void View_OnLoadData(object sender, Views.DataManage.UserEventArgs e)
        {
            DataTable dtAllUser = this.Model.QueryAllUser();
            this.View.ExeDataBind(dtAllUser);
        }

        //ɾ���û�  ��״̬����0
        void View_OnDeleteUser(object sender, Views.DataManage.UserEventArgs e)
        {
            bool IsDelete = this.Model.DeleteUser(e.CreateBy, e.UserId);
            if (IsDelete)
            {
                //this.View.ShowMessage("ɾ���ɹ�");
            }
            else
            {
                this.View.ShowMessage("ɾ��ʧ��");
            }
        }

        //��ʼ��View��
        protected override void OnInitView()
        {

        }

    }
}