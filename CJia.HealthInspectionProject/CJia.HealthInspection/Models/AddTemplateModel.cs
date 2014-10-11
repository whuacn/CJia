using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class AddTemplateModel : Models.AddCheckTitleModel
    {
        /// <summary>
        /// 根据分类获得检查题目
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckTitleByType(string type, string organId)
        {
            object[] sqlParams = new object[] {organId, type, type, type };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryCheckTitle, sqlParams);
            return UpdateDataTable(dtResult);
        }
        /// <summary>
        /// 获得模板Seq
        /// </summary>
        /// <returns></returns>
        public string GetTemplateSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryTemplateSeq);
        }
        /// <summary>
        /// 新增模板
        /// </summary>
        /// <param name="tempName"></param>
        /// <param name="typeID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddTemplate(string transID, string seq, string tempName, string typeID, string userID, string organId)
        {
            object[] sqlParams = new object[] { seq, tempName, typeID, userID ,organId};
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddTemplate, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 将检查题目对应于模板
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="tempID"></param>
        /// <param name="titleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddTitleToTemplate(string transID, string tempID, string titleID, string userID)
        {
            object[] sqlParams = new object[] { tempID, titleID, userID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddTitleToTemplate, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改数据表DataTable某一列的类型和记录值
        /// </summary>
        /// <param name="argDataTable">数据表DataTable</param>
        /// <returns>数据表DataTable</returns>
        private DataTable UpdateDataTable(DataTable argDataTable)
        {
            DataTable dtResult = new DataTable();
            dtResult = argDataTable.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "IS_CHOICE")
                {
                    col.DataType = typeof(bool);
                }
            }
            if (argDataTable != null && argDataTable.Rows.Count > 0)
            {
                foreach (DataRow row in argDataTable.Rows)
                {
                    DataRow rowNew = dtResult.NewRow();
                    for (int i = 0; i < argDataTable.Columns.Count; i++)
                    {
                        int j = argDataTable.Columns.IndexOf("IS_CHOICE");
                        if (row[j].ToString() == "1")
                        {
                            rowNew[j] = true;
                        }
                        else
                        {
                            rowNew[j] = false;
                        }
                        if (i != j)
                        {
                            rowNew[i] = row[i];
                        }
                    }
                    dtResult.Rows.Add(rowNew);
                }
            }
            return dtResult;
        }

    }
}
