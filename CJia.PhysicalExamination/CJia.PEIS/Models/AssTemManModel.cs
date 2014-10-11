//***************************************************
// 文件名（File Name）:      InteAssManModel.cs（模板维护Model层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.7
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Models
{
    /// <summary>
    /// 评估模板维护Model层
    /// </summary>
    public class AssTemManModel : CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deptId"></param>
        /// <param name="gender"></param>
        /// <param name="py"></param>
        /// <param name="remark"></param>
        /// <param name="updateBy"></param>
        /// <param name="assTemId"></param>
        public void UpdateAssTem(string content, int deptId, int gender, string py, string remark, string updateBy, int assTemId)
        {
            object[] sqlParams = new object[] { content, deptId, gender, py, remark, updateBy, assTemId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateAssTem, sqlParams);
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deptId"></param>
        /// <param name="gender"></param>
        /// <param name="py"></param>
        /// <param name="remark"></param>
        /// <param name="creatBy"></param>
        public void AddAssTem(int assTemId,string content,int deptId,int gender,string py,string remark,string createBy)
        {
            object[] sqlParams = new object[] { assTemId, content, deptId, gender, py, remark, createBy };
            CJia.DefaultPostgre.Execute(SqlTools.SqlInsertAssTem, sqlParams);
        }
        /// <summary>
        /// 判断模板Id是否存在模板表中，返回true/false
        /// </summary>
        /// <param name="assTemId"></param>
        /// <returns></returns>
        public bool IsInAssTem(int assTemId)
        {
            object[] sqlParams = new object[] { assTemId };
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectAssTemId, sqlParams);
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
        /// 取得模板内容的下一个Seq值
        /// </summary>
        /// <returns>下一排序号</returns>
        public int GetNextNextAssTemSeq()
        {
            return int.Parse(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectNextAssTemSeq));
        }
        /// <summary>
        /// 将模板内容置为无效
        /// </summary>
        /// <param name="assTemId"></param>
        /// <returns></returns>
        public void UpdateAssTemToInvalid(int assTemId)
        {
            object[] sqlParams = new object[] { assTemId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateAssTemToInvalid, sqlParams);
        }
        /// <summary>
        /// 将模板内容置为有效
        /// </summary>
        /// <param name="assTemId"></param>
        /// <returns></returns>
        public void UpdateAssTemToValid(int assTemId)
        {
            object[] sqlParams = new object[] { assTemId };
            CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateAssTemToValid, sqlParams);
        }
        /// <summary>
        /// 根据模板内容首拼、适用科室、适用性别查询模板
        /// </summary>
        /// <param name="contentPY">模板内容首拼</param>
        /// <param name="deptId">科室</param>
        /// <param name="gender">性别</param>
        /// <returns></returns>
        public DataTable GetAssTem(string contentPY, int deptId, int gender,bool isStopAss)
        {
            object[] sqlParams = new object[] { deptId, gender};
            string sqlSelectAssTem = CJia.PEIS.Models.SqlTools.SqlSelectAssTem;
            if (isStopAss)
            {
                sqlSelectAssTem = string.Format(sqlSelectAssTem, "and eat.status = '0'");
            }
            else
            {
                sqlSelectAssTem = string.Format(sqlSelectAssTem, "and eat.status = '1'");
            }
            if (contentPY != "")
            {
                sqlSelectAssTem = sqlSelectAssTem + " and eat.assess_tem_py like '%" + contentPY + "%'";
            }
            DataTable dtResult = CJia.DefaultPostgre.Query(sqlSelectAssTem, sqlParams);
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
        /// 获得全部有效模板
        /// </summary>
        /// <returns></returns>
        public DataTable GetAssTem2()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(CJia.PEIS.Models.SqlTools.SqlSelectAssTem2);
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
        /// 查询科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetDept()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(CJia.PEIS.Models.SqlTools.SqlSelectDept);
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
    }
}
