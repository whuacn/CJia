using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// ��Ӳ�����Ӧ�÷��ӿ�
    /// </summary>
    public interface IAddDeptUsageView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ҳ���ʼ����������������
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnInitLoadDept;

        /// <summary>
        /// ����һ��������Ӧ�÷�����
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnInsertData;

        /// <summary>
        /// ��������������һ�д���  ���ݻ�ȡ���ò���id���õ���Ӧû������÷�ID
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnRowClick;

        /// <summary>
        /// ҳ���ʼ�����벡������
        /// </summary>
        /// <param name="dtDept"></param>
        void ExeInitLoadDept(DataTable dtDept);

        /// <summary>
        /// ҳ���ʼ�������÷�����
        /// </summary>
        /// <param name="dtUsage"></param>
        void ExtLoadUsage(DataTable dtUsage);
    }

    public class AddDeptUsageEventArgs : EventArgs
    {
        /// <summary>
        /// ����Id
        /// </summary>
        public string OfficeId; 
        
        /// <summary>
        /// ��������
        /// </summary>
        public string OfficeName;   

        /// <summary>
        /// �÷�Id
        /// </summary>
        public long UsageId;        

        /// <summary>
        /// �÷�����
        /// </summary>
        public string UsageName;   

        /// <summary>
        /// ��ǰ��¼�û�Id
        /// </summary>
        public long UserId;

        /// <summary>
        /// �Ƿ�ѡ���˳���
        /// </summary>
        public bool ChecdLong;

        /// <summary>
        /// �Ƿ�ѡ������ʱ
        /// </summary>
        public bool ChecdTemporary;
    }
}