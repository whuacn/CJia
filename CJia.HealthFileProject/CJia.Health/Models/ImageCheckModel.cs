using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class ImageCheckModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询图片信息
        /// </summary>
        /// <param name="healthId"></param>
        /// <param name="BigPicture"></param>
        /// <param name="SmallPicture"></param>
        /// <param name="AllPicture"></param>
        public void SelectPic(string healthId, ref DataTable BigPicture, ref DataTable SmallPicture, ref DataTable AllPicture)
        {
            object[] parames = new object[] { healthId };
            BigPicture = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectBigPicture, parames);
            SmallPicture = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectSmallPicture, parames);
            AllPicture = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectAllPicture, parames);
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="healthId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ModifCheckStatus(string healthId, string status)
        {
            object[] parames = new object[] { status, healthId };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifCheckStatis, parames);
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改图片审核状态
        /// </summary>
        /// <param name="pictureId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ModifPictureCheckStatus(string pictureId, string userId, string status)
        {
            object[] parames1 = new object[] { status, userId, pictureId };
            int result1 = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifPictureCheckStatis, parames1);
            object[] parames2 = new object[] { pictureId, pictureId };
            int result2 = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifPatientCheckStatis, parames2);
            if(result1 > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        /// <param name="healthId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ModifLockStatus(string healthId, string status)
        {
            object[] parames = new object[] { status, healthId };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifLockStatus, parames);
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public bool GetLockFunction(string userid)
        {
            object[] parames = new object[] { userid };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.Health.Models.SqlTools.SqlQueryLockFunction, parames);
            if(result != "0")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 插入审核
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        public bool InsertPictureCheckReason(string pictureId, string checkReasonId, string checkReason, string originalCheckStatus, string checkStatus, string userID, string userName)
        {
            object[] parames = new object[] { pictureId };
            CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlDeletePictureCheckReason, parames);
            object[] parames1 = new object[] { pictureId, checkStatus, userID, userName, checkReasonId, checkReason, originalCheckStatus };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlInsertPictureCheckReason, parames1);

            if(result > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询病案号
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable SreahPatient(string selectValue)
        {
            object[] sqlParams = new object[] { "%" + selectValue + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSearchPatient, sqlParams);
            if(dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询审核原因
        /// </summary>
        /// <returns></returns>
        public DataTable SelectCheckReason()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectCheckReason);
            return result;
        }


        /// <summary>
        /// 增加审核原因
        /// </summary>
        /// <returns></returns>
        public bool InsertCheckReason(string checkReason)
        {
            object[] sqlParams = new object[] { checkReason };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlInsertCheckReasonData, sqlParams);
            if(result == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除审核原因
        /// </summary>
        /// <param name="checkReasonId"></param>
        /// <returns></returns>
        public bool DeleteCheckReason(string checkReasonId)
        {
            object[] sqlParams = new object[] { checkReasonId };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlDeleteCheckReasonData, sqlParams);
            if(result == 1)
            {
                return true;
            }
            return false;
        }
    }
}
