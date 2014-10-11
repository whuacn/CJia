using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class MainFromModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ�Ƿ���δ���ҽ��
        /// </summary>
        /// <returns></returns>
        public bool QueryNoCheckAdvice()
        {
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryNoCheckAdvice);
            if(result == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ��ѯ�쳣ƿ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryExpetionLabel()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryExcpitionLabel);
            return result;
        }

        /// <summary>
        /// ��ѯ��治��ҩ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStorage()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryStorage);
            return result;
        }

        /// <summary>
        /// ��ѯδ��ӡƿ��
        /// </summary>
        /// <returns></returns>
        public int QueryNoPrintLabel()
        {
            return int.Parse(CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryNoPrintLabel));
        }
    }
}

