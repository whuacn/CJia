using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    /// <summary>
    /// 根据关键字查询医生信息
    /// </summary>
    public class DoctorManageModel : CJia.Health.Tools.Model
    {
        public DataTable QueryDoctor(string KeyWord)
        {
            if (KeyWord == "" || KeyWord == null)
            {
                return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllDoctor);
            }
            else
            {
                object[] ob = new object[] { "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%" };
                return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDoctor, ob);
            }
        }

        /// <summary>
        /// 查询医生职称
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDocDescript(string KeyWord)
        {
            object[] ob = new object[] {  "%" + KeyWord + "%", "%" + KeyWord + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDocDescript, ob);
        }

        /// <summary>
        /// 查询科室信息绑到下拉框
        /// </summary>
        /// <param name="KeyWod"></param>
        /// <returns></returns>
        public DataTable QueryDept(string KeyWord)
        {
            object[] ob = new object[] { "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDept, ob);
        }

        /// <summary>
        /// 添加医生信息
        /// </summary>
        /// <param name="DoctorName"></param>
        /// <param name="DoctorNo"></param>
        /// <param name="Pinyin"></param>
        /// <param name="DeptId"></param>
        /// <param name="DescriptId">职称</param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool AddDoctor(string DoctorName, string DoctorNo, string Pinyin, string DeptId, string DescriptId, string UserId)
        {
            object[] ob = new object[] { DoctorName, DeptId, Pinyin, DescriptId, DoctorNo, UserId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertDoctor, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 修改医生信息
        /// </summary>
        /// <param name="DoctorName"></param>
        /// <param name="DoctorNo"></param>
        /// <param name="Pinyin"></param>
        /// <param name="DeptId"></param>
        /// <param name="DescriptId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool UpdateDoctor(string DoctorName, string DoctorNo, string Pinyin, string DeptId, string DescriptId, string UserId)
        {
            object[] ob = new object[] { DoctorName, DeptId, Pinyin, UserId, DescriptId, DoctorNo };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateDoctor, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 删除医生信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        public bool DeleteDoctor(string transID, string UserId, string DoctorId, string DoctorNo)
        {
            bool IsDelete;
            object[] ob = new object[] { UserId, DoctorId };
            IsDelete = CJia.DefaultOleDb.Execute(transID,SqlTools.SqlDeleteDoctor, ob) > 0 ? true : false;
            object[] ob1 = new object[] { UserId, DoctorNo };
            IsDelete=IsDelete&& CJia.DefaultOleDb.Execute(transID,SqlTools.SqlDeleteUserByNo, ob1) >= 0 ? true : false;
            return IsDelete;
        }

       
        /// <summary>
        /// 查询医生表里有几条与当前编号一样的数据
        /// </summary>
        /// <param name="DoctorNo"></param>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        public int CheckDocIsRepeat(string DoctorNo, string DoctorId)
        {
            object[] ob = new object[] { DoctorNo, DoctorId };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckDoctorIsRepeat, ob));
        }

        /// <summary>
        /// 判断此工号在用户表里是否存在
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        public bool CheckUserNo(string DocNo)
        {
            object[] ob = new object[] { DocNo };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckUserNo,ob)) > 0 ? true : false;
        }

        /// <summary>
        /// 获取到当前User表的seq
        /// </summary>
        /// <returns></returns>
        public int GetUserSeq()
        {
            return Convert.ToInt32(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryUserSeq));
        }

        /// <summary>
        /// 往用户表和医生表里同时插入数据
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="DoctorName"></param>
        /// <param name="DoctorNo"></param>
        /// <param name="Pinyin"></param>
        /// <param name="DeptId"></param>
        /// <param name="DescriptId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool InsertDocUser(string transID, string DoctorName, string DoctorNo, string Pinyin, string DeptId, string DescriptId, string UserId)
       {
            int userSeq = GetUserSeq();
            object[] ob = new object[] { DoctorName, DeptId, Pinyin, DescriptId, DoctorNo, UserId };
            bool IsInsertDoc = CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertDoctor, ob) > 0 ? true : false;
            object[] ob1 = new object[] {userSeq, DoctorNo, DoctorName, DeptId, UserId, DescriptId };
            bool IsInsertUser = CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertUserDoc, ob1) > 0 ? true : false;
            object[] ob2 = new object[] { userSeq, DoctorName, UserId };
            bool IsInsertRol = CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertDoctorRol, ob2) > 0 ? true : false;
            return IsInsertDoc && IsInsertUser && IsInsertRol;
        }
    }

}
