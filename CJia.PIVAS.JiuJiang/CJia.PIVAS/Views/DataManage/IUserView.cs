using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �û�ά���Ľӿڲ�
    /// </summary>
    public interface IUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        event EventHandler<UserEventArgs> OnLoadData;

        /// <summary>
        /// ɾ���û�  ��״̬��Ϊ0
        /// </summary>
        event EventHandler<UserEventArgs> OnDeleteUser;

        /// <summary>
        /// gridcontrol������Դ��
        /// </summary>
        /// <param name="dt">Ҫ�󶨵�����Դ</param>
        void ExeDataBind(DataTable dt);
    }

    /// <summary>
    /// �û�ά���Ĳ�����
    /// </summary>
    public class UserEventArgs : EventArgs
    {
        /// <summary>
        /// �޸���Id
        /// </summary>
        public long CreateBy;

        /// <summary>
        /// Ҫɾ�����û�Id
        /// </summary>
        public long UserId;
    }
}