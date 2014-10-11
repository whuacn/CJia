using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �޸�ʱ�����ݵĽӿڲ�
    /// </summary>
    public interface IEditTimeSetView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// �޸�TimeSet����
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnUpdateTimeSet;

        /// <summary>
        /// ����TimeSer����
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnInserttimeSet;

        /// <summary>
        /// �ж��ж��޸�ʱ���Ƿ����ص� ����true��ʾ���ص� true��ʾû���ص�
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnIsUpdateRepeat;

        /// <summary>
        /// �ж��ж����ʱ���Ƿ����ص� ����true��ʾ���ص� true��ʾû���ص�
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnIsInsertRepeat;

        /// <summary>
        /// ����ʱ����Ƿ����ص���ֵ��UI
        /// </summary>
        /// <param name="isRepeat"></param>
        void ExeIsRepeat(bool isRepeat);

    }

    /// <summary>
    /// �޸�ʱ��Ĳ�����
    /// </summary>
    public class EditTimeSetEventArgs : EventArgs
    {
        /// <summary>
        /// ���õ�ǰ���ĸ�ҳ�� 1�������� 2�����ҩ
        /// </summary>
        public int Whichpage;

        /// <summary>
        /// �������ĸ�����  1������� 2�����޸�
        /// </summary>
        public int WhichHandle;

        /// <summary>
        /// ʱ������
        /// </summary>
        public string TimeName;     

        /// <summary>
        /// ��ʵʱ��
        /// </summary>
        public string StartTime;    

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string OverTime;

        /// <summary>
        /// ������ʱ��Ϊ00:00ʱΪ��������һ�� ���ڽ���ʱ���ص��жϵ��ֶ� 
        /// </summary>
        public string EndTime;

        /// <summary>
        /// ��ǰ��¼�õ�ID
        /// </summary>
        public long UserId;         

        /// <summary>
        /// TimeID ����
        /// </summary>
        public long TimeId;         
    }
}