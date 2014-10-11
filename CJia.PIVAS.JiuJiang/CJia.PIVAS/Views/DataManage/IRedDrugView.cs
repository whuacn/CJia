using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// ʱ��ά���Ľӿڲ�
    /// </summary>
    public interface IRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ������
        /// </summary>
        event EventHandler<RedDrugEventArgs> OnLoadData;

        /// <summary>
        /// ɾ��ѡ������
        /// </summary>
        event EventHandler<RedDrugEventArgs> OnDeleteTimeSet;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        void ExeInitData(DataTable dt);

        /// <summary>
        /// ������������ĸ�ҳ��  1��������2�����ҩ
        /// </summary>
        int WhichPage
        {
            get;
            set;
        }

    }

    /// <summary>
    /// ʱ��ά���Ĳ�����
    /// </summary>
    public class RedDrugEventArgs : EventArgs
    {
        /// <summary>
        /// ����ҳ������
        /// </summary>
        public int Whichpage;   

        /// <summary>
        /// ʱ��ID
        /// </summary>
        public long TimeId;

        /// <summary>
        /// ��ǰ��¼�û�Id
        /// </summary>
        public long UserId;
    }
}