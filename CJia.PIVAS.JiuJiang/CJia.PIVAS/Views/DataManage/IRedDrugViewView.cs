using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    public interface IRedDrugViewView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// ��ʼ��load����
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar LoadData;

        /// <summary>
        /// ɾ��ѡ�е�ʱ����������
        /// </summary>
        event CJia.PIVAS.Tools.Delegate.NoResOnePar DeleteTimeSet;

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="dt"></param>
        void initData(DataTable dt);
    }
}