using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// ����û���M��
    /// </summary>
    public class AddUserModel : CJia.PIVAS.Tools.Model
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
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsUserRepeat, obUserNo) == "0" ? false : true;
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
        public bool InsertUser(string userNo,string userName,string pwd,string deptId,string deptName, long createBy)
        {
            object[] obInsert = new object[] { userNo, userName, pwd,deptId,deptName, createBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertUser, obInsert) > 0 ? true : false;
        }
    }
}