using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// ���Ƶ�ʶ�Ӧ���εĽӿڲ�
    /// </summary>
    public interface IBatchToRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        event EventHandler<BatchToRedDrugEventArgs> OnLoadData;

        /// <summary>
        /// ��ʼ���޸�ҳ��
        /// </summary>
        event EventHandler<BatchToRedDrugEventArgs> OnInitEdit;

        /// <summary>
        /// ��ʼ��gridcontrol����
        /// </summary>
        /// <param name="dt">Ƶ�ʶ������ε�����Դ</param>
        void ExeinitData(DataTable dt);    

        /// <summary>
        /// ��ʼ���༭����
        /// </summary>
        /// <param name="dt">��ҩ����Դ</param>
        void ExeinitEditData(DataTable dt); 
    }

    /// <summary>
    /// ������
    /// </summary>
    public class BatchToRedDrugEventArgs : EventArgs
    {
        /// <summary>
        /// ʱ������  ��ҩ������
        /// </summary>
        public string TimeType;     
    }
}