using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �޸��û���Ϣ�ӿڲ�
    /// </summary>
    public interface IEditUserView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// �޸ĸ�����Ϣ
        /// </summary>
        event EventHandler<EditUsereventArgs> OnUpdateUser;

        /// <summary>
        /// ȷ���޸�����ʱ ����ľ������Ƿ���ȷ
        /// </summary>
        event EventHandler<EditUsereventArgs> OnCheckPwd;

        /// <summary>
        /// ��ֵ����UI��
        /// </summary>
        /// <param name="isPwdOk"></param>
        void ExeIsPwdOk(bool isPwdOk);
    }

    /// <summary>
    /// ������
    /// </summary>
    public class EditUsereventArgs:EventArgs
    {
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserName;

        /// <summary>
        /// ������
        /// </summary>
        public string OldPwd;

        /// <summary>
        /// ������
        /// </summary>
        public string NewPwd;

        /// <summary>
        /// �����ǵ�¼�û�iD
        /// </summary>
        public long UserId;
    }
}