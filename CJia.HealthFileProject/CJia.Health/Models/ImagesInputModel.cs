using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class ImagesInputModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetSysdate()
        {
            return DateTime.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlSysdate));
        }
        /// <summary>
        /// 修改图片信息
        /// </summary>
        /// <param name="pictureID"></param>
        /// <param name="pictureName"></param>
        /// <param name="page"></param>
        /// <param name="subPage"></param>
        /// <param name="proID"></param>
        /// <param name="proName"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool ModifyPictureByID(string pictureID, string page, string subPage, string proID, string proName, string updateBy)
        {
            object[] sqlParams = new object[] { proID, page, updateBy, subPage, proName, pictureID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdatePictureByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="pictureID"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool DeletePictureByID(string pictureID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, pictureID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeletePictureByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据病人表id查询图片信息
        /// </summary>
        /// <param name="healthID"></param>
        /// <returns></returns>
        public DataTable GetPictureByHealthID(string healthID)
        {
            object[] sqlParams = new object[] { healthID };
            string sql = string.Format(SqlTools.SqlQueryMyPictureByID, " and 1=1 ");
            DataTable dtResult = CJia.DefaultOleDb.Query(sql, sqlParams);
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
        /// 查询病案号
        /// </summary>
        /// <param name="selectValue"></param>
        /// <returns></returns>
        public DataTable GetRecordNO(string selectValue)
        {
            object[] sqlParams = new object[] { "%" + selectValue + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryRecordNO, sqlParams);
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
        /// 获得项目基本信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProject()
        {
            object[] sqlParams = new object[] { "%%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectProject, sqlParams);
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
        /// 根据搜索值,查询项目
        /// </summary>
        /// <param name="selectValue"></param>
        /// <returns></returns>
        public DataTable GetProject(string selectValue)
        {
            object[] sqlParams = new object[] { "%" + selectValue + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectProject, sqlParams);
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
        /// 插入图片
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="dict"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public bool AddPicture(string transID, DataRow dict, string createBy, string createrName, DateTime addDate)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(dict["Pic_Name"]);
            sqlParams.Add(dict["HEALTH_ID"]);
            sqlParams.Add(dict["Pic_ProjectID"]);
            sqlParams.Add(dict["Pic_Page"]);
            sqlParams.Add(dict["STORAGE_PATH"]);
            sqlParams.Add(dict["LOGIC_PATH"]);
            sqlParams.Add(createBy);
            sqlParams.Add(dict["Pic_SubPage"]);
            sqlParams.Add(dict["Pic_ProjectName"]);
            sqlParams.Add(createBy);
            sqlParams.Add(createrName);
            sqlParams.Add(addDate);
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddPicture, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改病人基本信息的审核状态
        /// </summary>
        /// <param name="healthID"></param>
        /// <param name="checkSate"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool ModifyPatientInfoCheckState(string transID, string healthID, string checkSate, string updateBy)
        {
            object[] sqlParams = new object[] { checkSate, updateBy, healthID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdatePatientCheckState, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改图片表审核状态
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="healthID"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool ModifyPictureCheckState(string transID, string healthID, string updateBy, string checkState)
        {
            object[] sqlParams = new object[] { updateBy, checkState, healthID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdatePictureCheckState, sqlParams) > 0 ? true : false;
        }
        public bool ModifyPictureCheckStateByCase(string transID, string healthID, string updateBy, string checkState)
        {
            object[] sqlParams = new object[] { updateBy, checkState, healthID };
            string sql = SqlTools.SqlUpdatePictureCheckState + " AND PIC.CHECK_STATUS IN (100,102,104)";
            return CJia.DefaultOleDb.Execute(transID, sql, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除病案的某一页
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="healthID"></param>
        /// <param name="updateBy"></param>
        /// <param name="page"></param>
        /// <param name="subPage"></param>
        /// <returns></returns>
        public bool DeletePicByPage(string transID, string healthID, string updateBy, string page, string subPage)
        {
            object[] sqlParams = new object[] { updateBy, healthID, page, subPage };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdatePictureCheckStateByPage, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据快捷键查询项目分类
        /// </summary>
        /// <param name="shortKey"></param>
        /// <returns></returns>
        public DataTable GetProjectByShortKey(string shortKey)
        {
            object[] sqlParams = new object[] { shortKey };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectProjectByShortKey, sqlParams);
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
