using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class MyPatientInputModel : CJia.Health.Tools.Model
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
        /// 修改病案的审核状态
        /// </summary>
        /// <param name="healthID"></param>
        /// <param name="checkSate"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool ModifyCheckState(string transID, string healthID, string checkSate, string updateBy)
        {
            object[] sqlParams = new object[] { checkSate, updateBy, healthID };
            return CJia.DefaultOleDb.Execute(transID,SqlTools.SqlUpdatePatientCheckState, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除病人
        /// </summary>
        /// <param name="healthID"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool DeletePatient(string transID,string healthID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, healthID };
            return CJia.DefaultOleDb.Execute(transID,SqlTools.SqlDeletePatient, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 获得未审核的病案
        /// </summary>
        /// <param name="commitID"></param>
        /// <param name="checkSate"></param>
        /// <returns></returns>
        public DataTable GetPatientByCheckState(string commitID, string checkSate)
        {
            object[] sqlParams = new object[] { checkSate, commitID, commitID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryMyPatientByCheckState, sqlParams);
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
        /// 修改病案下对应的图片状态
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="healthID"></param>
        /// <param name="checkSate"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool ModifyPicStateByHealthID(string transID, string healthID, string checkSate, string updateBy)
        {
            string sql = @"update st_picture st
                        set st.check_status = ?, st.update_by = ?, st.update_date = sysdate
                      WHERE st.health_id = ?";
            object[] sqlParams = new object[] { checkSate, updateBy, healthID };
            return CJia.DefaultOleDb.Execute(transID, sql, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除病案下的图片
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="healthID"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public bool DeletePicByHealthID(string transID, string healthID, string updateBy)
        {
            string sql = @"update st_picture p
                    set p.status      = '0',
                        p.update_by   = ?,
                        p.update_date = sysdate
                  where p.health_id = ?";
            object[] sqlParams = new object[] { updateBy, healthID };
            return CJia.DefaultOleDb.Execute(transID, sql, sqlParams) > 0 ? true : false;
        }
    }
}
