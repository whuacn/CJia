using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ���ζ�Ӧ��ҩ��M��
    /// </summary>
    public class BatchToRedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ���ζ�Ӧ��ҩ
        /// </summary>
        /// <returns></returns>
        public  DataTable QueryBatchSet()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatchSet);
        }
    }
}