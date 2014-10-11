using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// Ƶ�ʶ�Ӧ���ε�M��
    /// </summary>
    public class FrequencyToBatchModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯƵ�ʶ�Ӧ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequencyToBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequencyBatch);
        }

        /// <summary>
        ///  ��Ƶ����ͼ�в�ѯδ�������ε�Ƶ����Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequency()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequency);
        }

        /// <summary>
        /// ɾ��FrequencyBatch
        /// </summary>
        /// <param name="userId">�޸���Id</param>
        /// <param name="frequencyBatchId">Ƶ�ʶ�Ӧ����Id</param>
        /// <returns></returns>
        public bool DeleteFrequencyBatch(long userId, long frequencyBatchId)
        {
            object[] ob = new object[] { userId, frequencyBatchId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteFrequencyBatch, ob) > 0 ? true : false;
        }
    }
}