//***************************************************
// 文件名（File Name）:      InteAssManModel.cs（智能评估Model层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.9
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Models
{
    /// <summary>
    /// 智能评估Model层
    /// </summary>
    public class InteAssManModel: CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 查询性别
        /// </summary>
        /// <returns></returns>
        public DataTable GetGender()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(CJia.PEIS.Models.SqlTools.SqlSelectGender);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询全部评估
        /// </summary>
        /// <returns></returns>
        public DataTable GetInteAss()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(Models.SqlTools.SqlSelectInteAss);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据评估首拼查询评估
        /// </summary>
        /// <returns></returns>
        public DataTable GetInteAssByPY(string inteAssPY)
        {
            string sqlSelectInteAss = Models.SqlTools.SqlSelectInteAss;
            if (inteAssPY != "")
            {
                sqlSelectInteAss = sqlSelectInteAss + " and eia.inte_assess_py like '%" + inteAssPY + "%'";
            }
            DataTable dtResult = CJia.DefaultPostgre.Query(sqlSelectInteAss);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询全部的部门项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptPro()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(Models.SqlTools.SqlSelectDeptPro);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据部门或项目首拼查询全部
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptProByPY(string deptProPY)
        {
            string sqlSelectDeptPro = Models.SqlTools.SqlSelectDeptPro;
            if (deptProPY != "")
            {
                sqlSelectDeptPro = "select key_id,display_name,parent_id,py from ("
                                   +sqlSelectDeptPro + " ) as dept_pro where dept_pro.py like '%"
                                   + deptProPY + "%'";
            }
            DataTable dtResult = CJia.DefaultPostgre.Query(sqlSelectDeptPro);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 将评估改为有效
        /// </summary>
        /// <param name="inteAssId"></param>
        public void UpdateInteAssToValid(int inteAssId)
        {
            object[] sqlParams = new object[] { inteAssId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateInteAssToValid, sqlParams);
        }
        /// <summary>
        /// 将评估改为无效
        /// </summary>
        /// <param name="inteAssId"></param>
        public void UpdateInteAssToInvalid(int inteAssId)
        {
            object[] sqlParams = new object[] { inteAssId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateInteAssToInvalid, sqlParams);
        }
        /// <summary>
        /// 取得评估的下一个Seq值
        /// </summary>
        /// <returns></returns>
        public int GetNextInteAssSeq()
        {
            return int.Parse(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectNextInteAssSeq));
        }
        /// <summary>
        /// 判断评估Id是否存在评估表中
        /// </summary>
        /// <param name="inteAssId"></param>
        /// <returns></returns>
        public bool GetInteAssId(int inteAssId)
        {
            object[] sqlParams = new object[] { inteAssId };
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectInteAssId, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 新增评估
        /// </summary>
        /// <param name="inteAssId"></param>
        /// <param name="inteAssName"></param>
        /// <param name="gender"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <param name="assTemId"></param>
        /// <param name="inteAssPY"></param>
        /// <param name="remark"></param>
        /// <param name="createBy"></param>
        public void AddInteAss(int inteAssId,string inteAssName,int gender,int minAge,int maxAge,string assTem,string inteAssPY,string remark,string createBy)
        {
            object[] sqlParams = new object[] { inteAssId, inteAssName, gender, minAge, maxAge, assTem, inteAssPY, remark, createBy };
            CJia.DefaultPostgre.Execute(SqlTools.SqlInsertInteAss, sqlParams);
        }
        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="inteAssName"></param>
        /// <param name="gender"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <param name="assTemId"></param>
        /// <param name="inteAssPY"></param>
        /// <param name="remark"></param>
        /// <param name="updateBy"></param>
        /// <param name="inteAssId"></param>
        public void UpdateInteAss(string inteAssName, int gender, int minAge, int maxAge, string assTem, string inteAssPY, string remark, string updateBy, int inteAssId)
        {
            object[] sqlParams = new object[] { inteAssName, gender, minAge, maxAge, assTem, inteAssPY, remark, updateBy,inteAssId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateInteAss, sqlParams);
        }
    }
}
