using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// �û�ά����M��
    /// </summary>
    public class UserModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// ��ѯ�������������û�
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllUser()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllUser);
        }

        /// <summary>
        /// ɾ���û�  ��״̬��Ϊ0
        /// </summary>
        /// <param name="updateBy"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(long updateBy,long userId)
        {
            object[] ob = new object[] { updateBy, userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteUser, ob) > 0 ? true : false;
        }
    }
}