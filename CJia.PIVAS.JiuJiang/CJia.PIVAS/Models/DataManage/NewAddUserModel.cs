using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ����û���M��
    /// </summary>
    public class NewAddUserModel : CJia.PIVAS.Tools.Model
    {
        ///// <summary>
        ///// �ж�His���Ƿ��е�ǰ�����  �з���true
        ///// </summary>
        ///// <param name="userNo"></param>
        ///// <returns></returns>
        //public bool IsUserExit(string userNo)
        //{
        //    object[] obUser = new object[] { userNo };
        //    DataTable dtUser = CJia.DefaultOleDb.Query(SqlTools.SqlIsUserExit, obUser);
        //    if (dtUser != null && dtUser.Rows != null && dtUser.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// �жϵ�ǰ�������û������Ƿ����ظ�  trueΪ���ظ�  falseΪ���ظ�
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public bool IsUserRepeat(string userNo)
        {
            object[] obUserNo = new object[] { userNo };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryHisUser, obUserNo) == "0" ? false : true;
        }


        /// <summary>
        /// �������û�
        /// </summary>
        /// <param name="userNo">�û�����</param>
        /// <param name="userName">�û�����</param>
        /// <param name="pwd">�û�����</param>
        /// <param name="deptId"></param>
        /// <param name="deptName"></param>
        /// <param name="createBy">������</param>
        /// <returns></returns>
        public bool InsertUser(string userNo,string pwd, long createBy,string isAdmin,string role)
        {
            object[] obInsert = new object[] { pwd, createBy, isAdmin, role, userNo };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlNewInsertUser, obInsert) > 0 ? true : false;
        }
    }
}