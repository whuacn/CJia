using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �����÷����ýӿڶ���
    /// </summary>
    public interface IDeptUsageView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        event EventHandler<DeptUsageEventArgs> OnInitLoadData;

        /// <summary>
        /// ɾ������
        /// </summary>
        event EventHandler<DeptUsageEventArgs> OnDeleteDeptUsage;

        /// <summary>
        /// ������Դ 
        /// </summary>
        /// <param name="dt">������Ӧ�÷�������Դ</param>
        void ExeDataBinds(DataTable dt);
    }

    /// <summary>
    /// ������
    /// </summary>
    public class DeptUsageEventArgs : EventArgs
    {
        /// <summary>
        /// ��ǰ��¼�û��ɣ�
        /// </summary>
        public long UserId;         

        /// <summary>
        /// ���β����÷�ID
        /// </summary>
        public long PivasSetId;     
    }
}