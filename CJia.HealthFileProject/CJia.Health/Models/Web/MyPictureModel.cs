using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class MyPictureModel : CJia.Health.Tools.Model
    {
        /// <summary>
        ///根据id查询病案信息及图片信息
        /// </summary>
        /// <param name="healthID"></param>
        /// <returns></returns>
        public DataTable GetMyPicture(string healthID)
        {
            object[] sqlParams = new object[] { healthID };
            string sql = string.Format(CJia.Health.Models.SqlTools.SqlQueryMyPictureByID, " and 1=1");
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
        /// 查询所有图片项目
        /// </summary>
        /// <param name="healthID"></param>
        /// <returns></returns>
        public DataTable GetMyPictureProject(string healthID)
        {
            object[] sqlParams = new object[] { healthID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryMyPictureProjectByID, sqlParams);
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
        /// 根据id和项目id查询图片信息
        /// </summary>
        /// <param name="healthID"></param>
        /// <param name="proID"></param>
        /// <returns></returns>
        public DataTable GetMyPictureByProID(string healthID, string proID)
        {
            object[] sqlParams = new object[] { healthID };
            string sql = string.Format(CJia.Health.Models.SqlTools.SqlQueryMyPictureByID, " and pic.pro_id='" + proID + "'");
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

        public DataTable GetPatientInfoByID(string patientID)
        {
            object[] sqlParams = new object[] { patientID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryPatientByID, sqlParams);
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
