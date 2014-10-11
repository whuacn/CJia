using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// ����û��Ľӿڲ�
    /// </summary>
    public interface IAddUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ���������ʧȥ����
        /// </summary>
        event EventHandler<addUsereventArgs> OnLeave;

        /// <summary>
        /// ����û�
        /// </summary>
        event EventHandler<addUsereventArgs> OnaddUser;

        /// <summary>
        /// ��¼�����Ƿ��Ѿ�����
        /// </summary>
        void ExeGetFocus();
    }

    /// <summary>
    /// ����û��Ĳ�����
    /// </summary>
    public class addUsereventArgs : EventArgs
    {
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserNo;

        /// <summary>
        /// Ҫ��ӵ��û�����
        /// </summary>
        public string UserName;

        /// <summary>
        /// Ҫ��ӵ��û�����
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
    }
}