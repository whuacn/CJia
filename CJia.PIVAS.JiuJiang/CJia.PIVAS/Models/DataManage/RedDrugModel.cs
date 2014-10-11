using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ʱ��ά����M��
    /// </summary>
    public class RedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯʱ���������飨��ҩ��������
        /// </summary>
        /// <param name="whichpage">Ҫ���õ�ҳ�� 1�������� 2�����ҩ</param>
        /// <returns></returns>
        public DataTable GetRedDrug(string whichpage)
        {
            object[] ob = new object[] { whichpage };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTimeSet, ob);
        }


        /// <summary>
        /// ɾ��TimeSetѡ�е����� trueΪɾ���ɹ�
        /// </summary>
        /// <param name="updateBy">�޸���</param>
        /// <param name="timeId">TimeId</param>
        /// <returns></returns>
        public bool DeleteTimeSet(long updateBy,long timeId)
        {
            object[] ob = new object[] { updateBy,timeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteTimeSet, ob) > 0 ? true : false;
        }
    
    }
}