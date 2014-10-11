using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// ����ƿ���ӿ�
    /// </summary>
    public interface IGenLabelView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// Ԥ��ƿ���¼�
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnPreviewLabelEven;

        /// <summary>
        /// ����ƿ���¼�
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnGenLabelEven;

        /// <summary>
        /// ��ѯ����
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnQueryIffield;

        /// <summary>
        /// ��Ԥ��ƿ�����ܻص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingCollect(DataTable result);

        /// <summary>
        /// ��Ԥ��ƿ������ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingInfo(DataTable result);

        /// <summary>
        /// �󶨲����ص�����
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingIffield(DataTable result);

        /// <summary>
        /// ���ɲ����ص�����
        /// </summary>
        /// <param name="result">���ɵ�ƿ��</param>
        void ExeGenLabel(DataTable result);

        /// <summary>
        /// ���»��������ص�����
        /// </summary>
        /// <param name="max"></param>
        void ExeInitSchedule(int max);

        /// <summary>
        /// �������ߵ���һ���ص�����
        /// </summary>
        void ExeNextSchedule();
        
    }

    /// <summary>
    /// ����ƿ���¼�����
    /// </summary>
    public class GenLabelEventArgs : EventArgs
    {

        /// <summary>
        /// ѡ�ŵĲ���
        /// </summary>
        public List< DataRow> Illfieldids;


    }
}