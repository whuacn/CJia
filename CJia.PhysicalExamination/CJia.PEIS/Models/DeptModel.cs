//***************************************************
// 文件名（File Name）:      DeptMode.cs
//
// 表（Tables）:            gm_dept（科室表），
//                          gm_dept_type（科室类型表）,
//
// 视图（Views）:           gm_dept_dept_type_view(科室信息视图)
//                          
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.8
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//***************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Models
{
    /// <summary>
    /// 科室维护
    /// </summary>
    public class DeptMode : CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 插入科室表
        /// </summary>
        /// <param name="deptName">科室名称</param>
        /// <param name="SortNo">排序号</param>
        /// <param name="deptEnglishName">科室英文名</param>
        /// <param name="deptFirstPinyin">科室首拼</param>
        /// <param name="deptType">科室类别</param>
        /// <param name="remark">备注</param>
        /// <returns>true：插入成功； false：插入失败</returns>
        public bool InsertDept(string deptName, long SortNo, long deptType, string deptEnglishName,string deptFirstPinyin, string remark)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(deptName);
            sqlParams.Add(SortNo);
            sqlParams.Add(deptType);
            sqlParams.Add(deptEnglishName);
            sqlParams.Add(deptFirstPinyin);
            sqlParams.Add(remark);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertDept,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 从sequence中取得下一排序号
        /// </summary>
        /// <returns>下一排序号</returns>
        public long GetNextSortNo()
        {
            return long.Parse(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectDeptNextSortNoSeq));
        }

        /// <summary>
        /// 从科室类别表（gm_dept_type）中获取科室类别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectDeptType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectDeptType);
        }

        /// <summary>
        /// 查询科室表数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectGridDept()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectGridDept);
        }

        /// <summary>
        /// 修改科室
        /// </summary>
        /// <param name="deptName">科室名称</param>
        /// <param name="SortNo">排序号</param>
        /// <param name="deptEnglishName">科室英文名</param>
        /// <param name="deptFirstPinyin">科室首拼</param>
        /// <param name="deptType">科室类别</param>
        /// <param name="remark">备注</param>
        /// <param name="deptId">科室ID</param>
        /// <returns>true：插入成功； false：插入失败</returns>
        public bool UpdateDept(string deptName, long SortNo, long deptType, string deptEnglishName,string deptFirstPinyin, string remark, long deptId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(deptName);
            sqlParams.Add(SortNo);
            sqlParams.Add(deptType);
            sqlParams.Add(deptEnglishName);
            sqlParams.Add(deptFirstPinyin); // 首字母
            sqlParams.Add(remark);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(deptId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateDeptBySelect,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 停用科室
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <returns>true：插入成功； false：插入失败</returns>
        public bool UpdateDeptByStop(long deptId)
        {
            object[] sqlParams = new object[] { deptId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateDeptByStop,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="txtSearch">界面输入搜索值</param>
        /// <param name="isCheckedStopDept">是否显示停用科室</param>
        /// <returns></returns>
        public DataTable SelectDeptBySearch(string strSearchCondition, string isCheckedStopDept)
        {
            string sqlSearch = string.Format(SqlTools.SqlSelectBySearch,isCheckedStopDept);
            List<object> sqlParams = new List<object>();
            strSearchCondition = "%"+strSearchCondition+"%";
            sqlParams.Add(strSearchCondition);
            sqlParams.Add(strSearchCondition);
            sqlParams.Add(strSearchCondition);
            sqlParams.Add(strSearchCondition);
            sqlParams.Add(strSearchCondition);
            return CJia.DefaultPostgre.Query(sqlSearch,sqlParams);
        }
    }
}
