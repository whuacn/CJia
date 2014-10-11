using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    public class DeptUsageModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ���в���
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDeptUsage()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryPivas);
        }

        /// <summary>
        /// ɾ��������Ӧ�÷�  ��status��Ϊ0
        /// </summary>
        /// <param name="userId">��ǰ��¼�û�</param>
        /// <param name="pivasSetId">ID</param>
        /// <returns></returns>
        public bool DeleteDeptUsage(long userId, long pivasSetId)
        {
            object[] ob = new object[] { userId, pivasSetId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteDeptUsage, ob) > 0 ? true : false;
        }
    }
}