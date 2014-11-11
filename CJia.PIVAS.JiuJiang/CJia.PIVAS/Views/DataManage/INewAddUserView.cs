using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �����û��Ľӿڲ�
    /// </summary>
    public interface INewAddUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ���������ʧȥ����
        /// </summary>
        event EventHandler<NewaddUsereventArgs> OnLeave;

        /// <summary>
        /// �����û�
        /// </summary>
        event EventHandler<NewaddUsereventArgs> OnaddUser;

        /// <summary>
        /// ��¼�����Ƿ��Ѿ�����
        /// </summary>
        void ExeGetFocus(bool have);
    }

    /// <summary>
    /// �����û��Ĳ�����
    /// </summary>
    public class NewaddUsereventArgs : EventArgs
    {
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserNo;

        /// <summary>
        /// Ҫ���ӵ��û�����
        /// </summary>
        public string UserName;

        /// <summary>
        /// Ҫ���ӵ��û�����
        /// </summary>
        public string Pwd;

        /// <summary>
        /// ��ǰ��¼�û���Id
        /// </summary>
        public long UserId;

        /// <summary>
        /// ���ű��
        /// </summary>
        public string DeptId;

        /// <summary>
        /// ��������
        /// </summary>
        public string DeptName;

        /// <summary>
        /// �Ƿ��ǹ���Ա
        /// </summary>
        public string IsAdmin;

        /// <summary>
        /// ��ɫ
        /// </summary>
        public string role;
    }
}