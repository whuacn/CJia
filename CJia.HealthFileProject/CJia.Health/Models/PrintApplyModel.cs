using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class PrintApplyModel:CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询病人列表
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="patientId">病人ID</param>
        /// <param name="patientName">病人姓名</param>
        /// <param name="card">身份证号</param>
        /// <param name="recordNo">病案号</param>
        /// <returns></returns>
        public DataTable QueryPatient(DateTime startDate, DateTime endDate, string patientName, string recordNo)
        {
            object[] parames = new object[] { startDate, endDate, "%" + patientName + "%", "%" + recordNo + "%" };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSearchPatientData, parames);
            return result;
        }
        /// <summary>
        /// 根据录入时间查询病人
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="patientName"></param>
        /// <param name="recordNo"></param>
        /// <returns></returns>
        public DataTable QueryPatientByInputDate(DateTime startDate, DateTime endDate, string patientName, string recordNo)
        {
            object[] parames = new object[] { startDate, endDate, "%" + patientName + "%", "%" + recordNo + "%" };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSearchPatientDataByInputDate, parames);
            return result;
        }
        /// <summary>
        /// 查询病人图片
        /// </summary>
        /// <param name="healthId"></param>
        /// <returns></returns>
        public DataTable QueryPictureByHealthId(string healthId)
        {
            object[] parames = new object[] { healthId };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPictureByHealthId, parames);
            return result;
        }

        ///// <summary>
        ///// 查询所有项目
        ///// </summary>
        ///// <returns></returns>
        //public DataTable QueryProject()
        //{
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllProject);
        //}

        ///// <summary>
        ///// 根据搜索值,查询项目
        ///// </summary>
        ///// <param name="selectValue"></param>
        ///// <returns></returns>
        //public DataTable QueryProjectByPinYin(string selectValue)
        //{
        //    object[] sqlParams = new object[] { "%" + selectValue + "%" };
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlSelectProject, sqlParams);
            
        //}

        ///// <summary>
        ///// 根据项目和页码筛选图片
        ///// </summary>
        ///// <returns></returns>
        //public DataTable QueryProjectAndPageSearch(string healthId,string proId,string startPage,string endPage,string startSubpage,string endSubpage)
        //{
        //    List<object> sqlParams = new List<object>();
        //    sqlParams.Add(healthId);
        //    sqlParams.Add(proId);
        //    sqlParams.Add(startPage);
        //    sqlParams.Add(endPage);
        //    sqlParams.Add(startSubpage);
        //    sqlParams.Add(endSubpage);
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlQueryPictureByProjectAndPage,sqlParams);
        //}
    }
}
