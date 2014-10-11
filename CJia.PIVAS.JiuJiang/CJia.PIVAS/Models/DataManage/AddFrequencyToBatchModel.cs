using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ���Ƶ�ʶ�Ӧ���ε�M��
    /// </summary>
    public class AddFrequencyToBatchModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��Ƶ����ͼ�в�ѯδ�������ε�Ƶ����Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequency()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequency);
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatch);
        }

        /// <summary>
        /// ����Ƶ�ʶ�Ӧ����  true��ʾ����ɹ� 
        /// </summary>
        /// <param name="frequencyId">Ƶ��Id</param>
        /// <param name="frequencyName">Ƶ������</param>
        /// <param name="frequencyFilter">Ƶ�ʲ�ѯ��</param>
        /// <param name="batchsName">����</param>
        /// <param name="updateBy">������ID</param>
        /// <returns></returns>
        public bool InsertFrquencyBatch(long frequencyId, string frequencyName, string frequencyFilter, string batchsName, long updateBy, string Illfield, string IllfieldName)
        {
            object[] ob = new object[] { frequencyId, frequencyName, frequencyFilter, batchsName, updateBy, Illfield, IllfieldName };
            return CJia.DefaultOleDb.Execute(SqlTools.sqlInsertFrequencyBatch, ob) > 0 ? true : false;
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIllfield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// �Ƿ��Ѿ������˸�Ƶ��
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool QueryIllfieldFrequency(long frequencyId, string Illfield)
        {
            object[] ob = new object[] { Illfield, frequencyId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.DataManage.SqlTools.SqlQueryIllfieldFrequencyid, ob);
            if(result == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}