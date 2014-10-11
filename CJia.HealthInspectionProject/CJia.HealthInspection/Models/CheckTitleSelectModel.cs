using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class CheckTitleSelectModel : Tools.Model
    {
        /// <summary>
        /// 获得所有分类的父子关系
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemplate()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateType);
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
        /// 根据分类获得检查题目
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckTitleByType(string type, string organId)
        {
            object[] sqlParams = new object[] { organId,type, type, type };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryCheckTitle, sqlParams);
            return UpdateDataTable(dtResult);
        }
        /// <summary>
        /// 获得所有检查题目
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCheckTitle(string oragnId)
        {
            object[] sqlParams = new object[] { oragnId };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryAllCheckTitle,sqlParams);
            return UpdateDataTable(dtResult);
        }
        /// <summary>
        /// 删除检查题目
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public bool DeleteCheckTitle(string userID, string titleID)
        {
            object[] sqlParams = new object[] { userID, titleID};
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteCheckTitle, sqlParams) > 0 ? true : false;
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
                    for(int i=0;i<argDataTable.Columns.Count;i++)
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
