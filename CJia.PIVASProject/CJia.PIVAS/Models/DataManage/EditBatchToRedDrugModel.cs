using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// �޸����ζ�Ӧ��ҩM��
    /// </summary>
    public class EditBatchToRedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatchSet);
        }

        /// <summary>
        /// �޸����α��ʱ��Ͷ�Ӧ�ĳ�ҩ  true�����޸ĳɹ�
        /// </summary>
        /// <param name="batchTime">ִ��ʱ��</param>
        /// <param name="timeId">��Ӧ��ҩID</param>
        /// <param name="updateBy"></param>
        /// <param name="batchId">����ID</param>
        /// <returns></returns>
        public bool UpdateBatchSet(string batchTime, long timeId, long updateBy, long batchId)
        {
            object[] ob = new object[] { batchTime, timeId, updateBy, batchId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateBatchSet, ob) > 0 ? true : false;
        }

        /// <summary>
        /// �ж��޸ĵ�����ִ��ʱ���Ƿ����ص�
        /// </summary>
        /// <param name="batchId">����ID</param>
        /// <param name="batchTime">����ִ��ʱ��</param>
        /// <returns>true��ʾ���ص���false��ʾû���ص�</returns>
        public bool IsRepeat(long batchId, string batchTime)
        {
            object[] ob = new object[] { batchId, batchTime, batchTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsRepeat, ob) == "1" ? false : true;
        }

    }
}