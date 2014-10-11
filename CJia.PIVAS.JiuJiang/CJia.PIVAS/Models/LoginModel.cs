using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class LoginModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ��ǰ��¼�û�����Ϣ
        /// </summary>
        /// <param name="userNo">�û�����</param>
        /// <param name="password">����</param>
        /// <returns></returns>
        public DataTable SelectUser( string userNo, string password )
        {
            object[] ob = new object[] { userNo, password };
            return CJia.DefaultOleDb.Query(CJia.PIVAS.Models.DataManage.SqlTools.SqlQueryUser, ob);
        }
    }
}

