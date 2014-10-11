using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ��Ӳ�����Ӧ�÷���M��
    /// </summary>
    public class AddDeptUsageModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDept);
        }

        /// <summary>
        /// ��ѯ��ǰ����δ���õ��÷�
        /// </summary>
        /// <param name="officeId">��ǰ����ID</param>
        /// <returns></returns>
        public DataTable QueryUsage(string officeId)
        {
            object[] ob = new object[] { officeId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUsage,ob);
        }

        /// <summary>
        /// ���벡����Ӧ�÷�����
        /// </summary>
        /// <param name="officeId">����ID</param>
        /// <param name="officeName">��������</param>
        /// <param name="usageId">�÷�Id</param>
        /// <param name="usageName">�÷�����</param>
        /// <param name="createBy">������Id</param>
        /// <returns></returns>
        public bool InsertPivas(string officeId, string officeName, long usageId, string usageName, long createBy)
        {
            object[] obInsert = new object[] { officeId, officeName, usageId, usageName, createBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertDeptUsage, obInsert) > 0 ? true : false;
        }

        /// <summary>
        /// �ж��Ƿ����ظ� ���û�з���true ���򷵻�false
        /// </summary>
        /// <param name="officeId">����Id</param>
        /// <param name="usageId">�÷�ID</param>
        /// <returns></returns>
        public bool QueryIsRepeat(string officeId,long usageId)
        {
            DataTable dt = new DataTable();
            object[] obIsRepeat = new object[] {officeId, usageId };
            dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsRepeat, obIsRepeat);
            if (dt != null&&dt.Rows!=null && dt.Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}