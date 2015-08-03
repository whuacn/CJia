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
    public interface IQueryPrintLabelView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// ��ʼ������
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitIffield;

        /// <summary>
        /// ��ʼ������
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitBacth;

        /// <summary>
        /// ��ʼ����ҩ;��
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitUsage;

        /// <summary>
        /// ��ѯ���в����������ε�ƿ�������¼�
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        /// <summary>
        /// ��ѯҩƿ������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryPharmCollect;

        /// <summary>
        /// ��ѯ��ҩ���¼�
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryArrangeEvent;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelDetails;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼� ��ƿ��������е�����
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelDetailsInfo;

        /// <summary>
        /// ��ѯƿ��������Ϣ�¼�
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnQueryLabelCollect;

        /// <summary>
        /// �޸İ�ҩ��id�б��������
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnModifFilterArrange;

        /// <summary>
        /// �޸�ƿ��������״̬
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnUpdateBarCode;

        /// <summary>
        /// ��ӡƿ��
        /// </summary>
        event EventHandler<QueryPrintLabelViewEventArgs> OnGenLabel;

        /// <summary>
        /// �޸�ƿ����ҩ״̬
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        /// <summary>
        /// ����ƿ���᲻��ʹҩƷ��治��
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnLabelPharmCount;


        /// <summary>
        /// ��ʼ�������󶨻ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

        /// <summary>
        /// ��ʼ�������󶨻ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeInitUsage(DataTable result);

        /// <summary>
        /// ��ʼ�����ΰ󶨻ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeInitBacth(DataTable result);

        /// <summary>
        /// ��ȡƿ��������
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResThreePar OnGetLabelBarcode;

        /// <summary>
        /// �޸�ƿ����ӡ״̬
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResTwoPar OnUpdateLabelPrintStatus;

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
        /// ƿ���ƷѴ���
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.ResOnePar OnLabelIsFee;

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
    public class QueryPrintLabelViewEventArgs : EventArgs
    {

        /// <summary>
        /// 0 �������  1��������
        /// </summary>
        public int selectDate;

        /// <summary>
        /// 0������  1�������
        /// </summary>
        public int grOrDr;

        public int labelCount;
        /// <summary>
        /// ������ʱ��־
        /// </summary>
        public string longTemporary;

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

        /// <summary>
        /// ����id
        /// </summary>
        public string IllfieldId;

        /// <summary>
        /// ��ҩ;��id
        /// </summary>
        public string UsageId;

        /// <summary>
        /// ����id
        /// </summary>
        public string batchid;

        /// <summary>
        /// ��ӡ���� 1:�����ӡƴ�� 0:����ӡƿ��
        /// </summary>
        public string printType;

        /// <summary>
        /// ��Ҫ����ƿ���Ĳ�����������
        /// </summary>
        public DataTable groupIndexBatchid;

        /// <summary>
        /// �Ƿ�ʹ�����ʱ�����
        /// </summary>
        public bool useCheckData;

        /// <summary>
        /// ��ʼ���ʱ��
        /// </summary>
        public DateTime CheckDataStart;

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime CheckDataEnd;


    }



}