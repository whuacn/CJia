using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// ���Ƶ�ʶ�Ӧ���εĽӿ�
    /// </summary>
    public interface IAddFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ��ҳ������Ƶ�ʺ���������
        /// </summary>
        event EventHandler<AddFrequencyToBatchEventArgs> OnInitLoadData;

        /// <summary>
        /// ���Ƶ�ʶ�Ӧ�÷�
        /// </summary>
        event EventHandler<AddFrequencyToBatchEventArgs> OnAddFrequencyBatch;

        /// <summary>
        /// ΪƵ�ʵ�����������εĶ�ѡ�������Դ
        /// </summary>
        /// <param name="dtFrequency">Ƶ������Դdatatable</param>
        /// <param name="dtBatch">��������Դ</param>
        void ExeGridLookUpDataBind(DataTable dtFrequency,DataTable dtBatch);

    }

    /// <summary>
    /// ���Ƶ�ʶ�Ӧ���εĲ�����
    /// </summary>
    public class AddFrequencyToBatchEventArgs : EventArgs
    {
        /// <summary>
        /// Ƶ��Id
        /// </summary>
        public long FrequencyId;

        /// <summary>
        /// Ƶ������
        /// </summary>
        public string FrequencyName;

        /// <summary>
        /// Ƶ�ʲ�ѯ��
        /// </summary>
        public string FrequencyFilter;

        /// <summary>
        /// ��������
        /// </summary>
        public string BatchsName;

        /// <summary>
        /// ��ǰ��¼�û�Id
        /// </summary>
        public long UserId;
    }
}