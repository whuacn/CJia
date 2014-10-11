using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// ��¼����ӿڲ�
    /// </summary>
    public interface ILoginView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// ��¼
        /// </summary>
        event EventHandler<LoginEventArgs> OnLogin;

        /// <summary>
        /// ��¼ʧ��
        /// </summary>
        void ExeLoginFail();

    }

    /// <summary>
    /// ��¼ҳ�������
    /// </summary>
    public class LoginEventArgs : EventArgs
    {
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserNo;       

        /// <summary>
        /// �û�����
        /// </summary>
        public string Password;     
    }
}
