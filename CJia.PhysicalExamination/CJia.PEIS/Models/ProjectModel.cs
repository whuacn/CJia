//***************************************************
// 文件名（File Name）:      DeptMode.cs
//
// 表（Tables）:            gm_dept（科室表），
//                          gm_project（体检项目表）,
//
// 视图（Views）:           
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
    public class ProjectModel:CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 查询科室表和项目表信息绑定科室名称、项目名称到TreeList中
        /// </summary>
        /// <returns></returns>
        public DataTable SelectDeptProBindTree()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectDeptProBindTree);
        }

        /// <summary>
        /// 插入项目表
        /// </summary>
        /// <param name="sqlParams">表字段参数</param>
        /// <returns></returns>
        public bool InsertProject(List<object> sqlParams)
        {
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertProject,sqlParams) >0 ? true:false;
        }

        /// <summary>
        /// 取得下一个排序号
        /// </summary>
        /// <returns></returns>
        public long GetNextProSortNo()
        {
            return long.Parse(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectNextProjectSortNo));
        }

        /// <summary>
        /// 查询项目数据绑定Grid网格
        /// </summary>
        /// <param name="deptId">所属科室Id</param>
        /// <returns></returns>
        public DataTable SelectProBindGridProject(long deptId)
        {
            object[] sqlParams = new object[] { deptId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectBindGridProFromProject,sqlParams);
        }

        /// <summary>
        /// 插入控件预设表
        /// </summary>
        /// <param name="controlDefaultName">控件预设值名称</param>
        /// <param name="proId">所属项目（该字段如为0则说明不属于任何项目，是在点击新增后所添加，无任何用处）</param>
        /// <param name="isDefaultValue">是否为项目默认值</param>
        /// <param name="isChecked">是否被勾选中</param>
        /// <returns></returns>
        //public bool InsertControlDefault(string controlDefaultName,long proId,string isDefaultValue,string isChecked)
        //{
        //    List<object> sqlParams = new List<object>();
        //    sqlParams.Add(controlDefaultName);
        //    sqlParams.Add(proId);
        //    sqlParams.Add(isDefaultValue);
        //    sqlParams.Add(isChecked);
        //    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
        //    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
        //    return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertControlDefault,sqlParams) > 0 ? true :false;
        //}
        public bool InsertControlDefault(DataTable dtInsertData)
        {
            bool isSuccess = false;
            for (int i = 0; i < dtInsertData.Rows.Count; i++)
            {
                List<object> sqlParams = new List<object>();
                DataRow dr = dtInsertData.Rows[i];
                sqlParams.Add(dr["control_default_id"]);
                sqlParams.Add(dr["control_default_name"]);
                sqlParams.Add(dr["pro_id"]);
                sqlParams.Add(dr["is_checked"]);
                sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                isSuccess = CJia.DefaultPostgre.Execute(SqlTools.SqlInsertControlDefault, sqlParams) > 0 ? true : false;
            }
            return isSuccess;
        }

        /// <summary>
        /// 加载项目对应的控件预设值
        /// </summary>
        /// <param name="proId">所选择项目</param>
        /// <returns></returns>
        public DataTable SelectControlsDefaultByProId(long proId)
        {
            object[] sqlParams = new object[] { proId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectControlsDefaultByProId,sqlParams);
        }

        /// <summary>
        /// 删除控件预设值
        /// </summary>
        /// <param name="controlDefaultId">控件预设值Id</param>
        /// <returns></returns>
        public bool DeleteControlsDefaultById(long controlDefaultId)
        {
            object[] sqlParams = new object[] { controlDefaultId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteControlsDefaultById,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改控件预设值勾选状态
        /// </summary>
        /// <param name="controlDefaultId">控件预设值Id</param>
        /// <param name="isCheckedStatus">勾选状态</param>
        /// <returns></returns>
        public bool UpdateControlsDefaultCheckedStatusById(long controlDefaultId ,string isCheckedStatus)
        {
            object[] sqlParams = new object[] { isCheckedStatus, controlDefaultId};
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateControlDefaultCheckedStatusById,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询控件预设值表流水号
        /// </summary>
        /// <returns></returns>
        public long SelectControlsDefaultNextSeq()
        {
            return  long.Parse(CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectControlDefaultSeq));
        }

        /// <summary>
        /// 修改项目表
        /// </summary>
        /// <param name="sqlParams">所需修改表字段</param>
        /// <returns></returns>
        public bool UpdateProject(List<object> sqlParams)
        {
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateProject,sqlParams) > 0 ? true :false;
        }

        /// <summary>
        /// 停用项目
        /// </summary>
        /// <param name="proId">所选项目ID</param>
        /// <returns></returns>
        public bool UpdateProjectByStop(long proId)
        {
            object[] sqlParams = new object[] { proId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateProjectByStop,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 启用项目
        /// </summary>
        /// <param name="proId">所选项目ID</param>
        /// <returns></returns>
        public bool UpdateProjectByReStart(long proId)
        {
            object[] sqlParams = new object[] { proId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateProjectByReStart, sqlParams) > 0 ? true : false;
        }

        

        /// <summary>
        /// 查询项目状态（启用或者停用）
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public string SelectProStatusByProId(long proId)
        {
            object[] sqlParams = new object[] { proId };
            return CJia.DefaultPostgre.QueryScalar(SqlTools.SqlSelectProStatusByProId, sqlParams);
        }

        #region 查询界面下拉框数据

        /// <summary>
        /// 查询项目类别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindProType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectProjectType);
        }

        /// <summary>
        /// 查询绑定下拉短信设置
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindSmsSet()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectSmsSet);
        }

        /// <summary>
        /// 绑定下拉是否餐前项目
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindBeforeMeal()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectBeforeMeal);
        }

        /// <summary>
        /// 绑定下拉适用性别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindApplyGender()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectApplyGender);
        }

        /// <summary>
        /// 绑定下拉费用类别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindCostType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectCostType);
        }

        /// <summary>
        /// 绑定下拉标本种类
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindSpeciesType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectSpeciesType);
        }

        /// <summary>
        /// 绑定下拉计量单位
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindUnitMeasurement()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectUnitMeasurement);
        }

        /// <summary>
        /// 绑定常用项目类别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindCommonProType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectCommonProType);
        }

        /// <summary>
        /// 绑定控件类型
        /// </summary>
        /// <returns></returns>
        public DataTable SelectBindControlType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectControlType);
        }
        #endregion
    }
}
