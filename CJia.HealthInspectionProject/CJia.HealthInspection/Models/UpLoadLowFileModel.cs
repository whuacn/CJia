using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class UpLoadLowFileModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询法律法规类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetLowTemplate()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLowTemplate);
            if (dtResult != null && dtResult.Rows!=null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 插入法律法规文档
        /// </summary>
        /// <param name="LowFileName"></param>
        /// <param name="LowFileTypeID"></param>
        /// <param name="LowFileContent"></param>
        /// <param name="LowFilePath"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool InsertLowFile(string LowFileName,long LowFileTypeID,string LowFilePath,long UserId, string WordFileName, string HtmlFileName, string HtmlFilePath)
        {
            object[] ob = new object[] { LowFileName, LowFileTypeID, LowFilePath, UserId, WordFileName, HtmlFileName, HtmlFilePath };
            return  CJia.DefaultOleDb.Execute(SqlTools.SqlInsertLow, ob) > 0 ? true : false;
        }
    }
}
