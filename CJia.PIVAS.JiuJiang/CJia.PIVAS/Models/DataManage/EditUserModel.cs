using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// �޸ĸ�����ϢM��
    /// </summary>
    public class EditUserModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// �޸ĸ�����Ϣ  ����
        /// </summary>
        /// <param name="userName">�û�����</param>
        /// <param name="pwd">������ ����Md5���ܹ�������</param>
        /// <param name="userId">��ǰ��½�û���Id</param>
        /// <returns></returns>
        public bool UpdateUser(string pwd,long userId)
        {
            object[] ob = new object[] { pwd, userId, userId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlChangePwd, ob) > 0 ? true : false;
        }

        /// <summary>
        /// �ж��޸�����������ľ������Ƿ���ȷ
        /// </summary>
        /// <param name="userId">��ǰ��¼���û�Id</param>
        /// <param name="OldPwd">������</param>
        /// <returns></returns>
        public bool CheckOldPwd(string OldPwd,long userId)
        {
            object[] ob = new object[] { OldPwd, userId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckOldPwd, ob) == "1" ? true : false;
        }
    }
}