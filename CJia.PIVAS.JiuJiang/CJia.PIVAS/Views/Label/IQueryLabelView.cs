using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// ��ѯƿ���ӿ�
    /// </summary>
    public interface IQueryLabelView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ѯ���в����������ε�ƿ�������¼�
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        /// <summary>
        /// ��ѯҩƿ������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryPharmCollect;

        /// <summary>
        /// ��ѯ��ҩ���¼�
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryArrangeEvent;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelDetails;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼� ��ƿ��������е�����
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelDetailsInfo;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnQueryLabelCollect;

        /// <summary>
        /// �޸İ�ҩ��id�б��������
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnModifFilterArrange;

        /// <summary>
        /// �޸�ƿ��������״̬
        /// </summary>
        event EventHandler<QueryLabelViewEventArgs> OnUpdateBarCode; 

        /// <summary>
        /// ��ȡƿ��������
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnGetLabelBarcode;

        /// <summary>
        /// �޸�ƿ����ӡ״̬
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnUpdateLabelPrintStatus;

        /// <summary>
        /// ɾ��ƿ��
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnDeleteLabel;

        /// <summary>
        /// �۷ѿۿ��
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnPharmFee;

        /// <summary>
        /// ��ȡ�۷�ʱ��
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnFeeTIME;

        /// <summary>
        /// ��ƿ������ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelDetails(DataTable result);

        /// <summary>
        /// ��ƿ������ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelDetailsInfo(DataTable result);

        /// <summary>
        /// ��ƿ�����ܻص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingLabelCollect(DataTable result);

        /// <summary>
        /// �󶨰�ҩ���ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingArrange(DataTable result);

        /// <summary>
        /// �����в�����������ƿ��������Ϣ�ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingAlllIffieldBachLabelCollect(DataTable result);

        /// <summary>
        /// ��ҩƷ������Ϣ�ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingPharmCollect(DataTable result);

    }

    /// <summary>
    /// ��ѯƿ���¼�����
    /// </summary>
    public class QueryLabelViewEventArgs : EventArgs
    {

        /// <summary>
        /// ѡ��Ĳ�ѯ�¼�
        /// </summary>
        public DateTime QueryTime;

        /// <summary>
        /// ѡ��İ�ҩ��id�б�
        /// </summary>
        public List<object> SelectArrangeIdList;

        /// <summary>
        /// ƿ��ҳ���
        /// </summary>
        public string LabelPageNo;

        /// <summary>
        /// ƿ��id
        /// </summary>
        public string LabelId;

    }



}