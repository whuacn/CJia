using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// Ƶ�ʶ�Ӧ���εĽӿڲ�
    /// </summary>
    public interface IFrequencyToBatchView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ������
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnLoadData;

        /// <summary>
        /// ���Ƶ�ʶ�Ӧ����
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnAddFrequencyToBatch;

        /// <summary>
        /// ɾ��Ƶ�ʶ�Ӧ����
        /// </summary>
        event EventHandler<FrequencyToBatchEventArgs> OnDeleteFrequencyBatch;

        //event EventHandler<FrequencyToBatchEventArgs> OnEditFrequencyToBatch;

        /// <summary>
        /// ��ʼ��gridcontrol����
        /// </summary>
        /// <param name="dt"></param>
        void ExeinitData(DataTable dt);    

    }

    /// <summary>
    /// ������
    /// </summary>
    public class FrequencyToBatchEventArgs:EventArgs
    {
        /// <summary>
        /// Ƶ�ʶ�Ӧ���α��ID
        /// </summary>
        public long FrequencyBatchId;   

        /// <summary>
        /// ��ǰ��¼�û���ID
        /// </summary>
        public long UserId;            
    }
}