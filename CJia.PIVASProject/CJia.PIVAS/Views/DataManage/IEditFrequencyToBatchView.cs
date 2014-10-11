using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �޸�Ƶ�ʶ�Ӧ���εĽӿڲ�
    /// </summary>
    public interface IEditFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnInitLoadBatch;

        /// <summary>
        /// �޸�Ƶ�ʶ�Ӧ����
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnUpdateFrequencyBatch;

        /// <summary>
        /// ���޸�����
        /// </summary>
        event EventHandler<EditFrequencyToBatchEventArgs> OnUpdateCheckFrequencyBatch;

        /// <summary>
        /// Ϊ���ζ�ѡ�������
        /// </summary>
        /// <param name="dt">���ε�����Դ</param>
        void ExeInitLoadBatch(DataTable dt);
    }

    /// <summary>
    /// �޸�Ƶ�ʶ�Ӧ���εĲ�����
    /// </summary>
    public class EditFrequencyToBatchEventArgs : EventArgs
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string BatchsName;       

        /// <summary>
        /// ��ǰ��¼�û�ID
        /// </summary>
        public long UserId;             

        /// <summary>
        /// Ƶ�ʶ�Ӧ����ID
        /// </summary>
        public long FrequencyBatchId;

        /// <summary>
        /// ��ţ����ã�
        /// </summary>
        public string GroupIndex;
    }
}