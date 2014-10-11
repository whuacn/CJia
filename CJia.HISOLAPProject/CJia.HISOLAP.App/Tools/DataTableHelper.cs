using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.Tools
{
    public static class DataTableHelper
    {
        /// <summary>
        /// 只获取表格中需要的行
        /// </summary>
        /// <param name="oldData">原数据</param>
        /// <param name="selectColNo">需要的行编号</param>
        /// <returns>新数据</returns>
        public static DataTable SelectCols(DataTable oldData, List<int> selectColNo)
        {
            DataTable newData = new DataTable();
            for(int i = 0; i < oldData.Columns.Count; i++)
            {
                if(selectColNo.Contains(i))
                {
                    newData.Columns.Add(oldData.Columns[i].ColumnName, oldData.Columns[i].DataType);
                }
            }
            for(int i = 0; i < oldData.Rows.Count; i++)
            {
                List<object> newRowList = new List<object>();
                for(int j = 0; j < oldData.Columns.Count; j++)
                {
                    if(selectColNo.Contains(j))
                    {
                        newRowList.Add(oldData.Rows[i][j]);
                    }
                }
                DataRow newRow = newData.NewRow();
                newRow.ItemArray = newRowList.ToArray();
                newData.Rows.Add(newRow);
            }
            return newData;
        }


        /// <summary>
        /// 去除表格中某些行
        /// </summary>
        /// <param name="oldData">原数据</param>
        /// <param name="selectColNo">需要去除的行编号</param>
        /// <returns>新数据</returns>
        public static DataTable NoSelectCols(DataTable oldData, List<int> noSelectColNo)
        {
            DataTable newData = new DataTable();
            for(int i = 0; i < oldData.Columns.Count; i++)
            {
                if(!noSelectColNo.Contains(i))
                {
                    newData.Columns.Add(oldData.Columns[i].ColumnName, oldData.Columns[i].DataType);
                }
            }
            for(int i = 0; i < oldData.Rows.Count; i++)
            {
                List<object> newRowList = new List<object>();
                for(int j = 0; j < oldData.Columns.Count; j++)
                {
                    if(!noSelectColNo.Contains(j))
                    {
                        newRowList.Add(oldData.Rows[i][j]);
                    }
                }
                DataRow newRow = newData.NewRow();
                newRow.ItemArray = newRowList.ToArray();
                newData.Rows.Add(newRow);
            }
            return newData;
        }

        /// <summary>
        /// 获取真实的列名  
        /// 如 BI查出的列名为 [messdd].[里的水解放路的设计费] 真实的列名为 里的水解放路的设计费
        /// 就是以最后一个 [ ] 内的字符作为新列名
        /// </summary>
        /// <param name="oldData">源表格数据</param>
        /// <returns>新表格数据</returns>
        public static DataTable GetRealColName(DataTable oldData)
        {
            DataTable newData = oldData.Copy();
            for(int i = 0; i < newData.Columns.Count; i++)
            {
                string columnName = newData.Columns[i].ColumnName;
                if(columnName.IndexOf('[') != -1 && columnName.IndexOf(']') != -1)
                {
                    string[] colStrs = columnName.Split('.');
                    string newColumnName = colStrs[colStrs.Length - 1].Replace("&", "").Replace("[", "").Replace("]", "");
                    newData.Columns[i].ColumnName = newColumnName;
                }
            }
            return newData;
        }

        /// <summary>
        /// 修改表格中的列名
        /// </summary>
        /// <param name="oldData">源数据</param>
        /// <param name="colNames">列编号与新列名的对应字典</param>
        /// <returns>新表格数据</returns>
        public static DataTable UpdateColName(DataTable oldData, Dictionary<int, string> colNames)
        {
            DataTable newData = oldData.Copy();
            List<int> colNos = colNames.Keys.ToList();
            for(int i = 0; i < colNos.Count; i++)
            {
                newData.Columns[i].ColumnName = colNames[colNos[i]];
            }
            return newData;
        }

        /// <summary>
        /// 修改表格中的列名并设置各列的宽度
        /// </summary>
        /// <param name="oldData"></param>
        /// <param name="colNames"></param>
        /// <param name="colWidth"></param>
        /// <returns></returns>
        public static DataTable UpdateColName(DataTable oldData, Dictionary<int, string> colNames, Dictionary<int, string> colWidth)
        {
            if (colNames.Count != colWidth.Count)
            {
                throw new Exception("别名个数与别名宽度设置个数不一致");
            }
            DataTable newData = oldData.Copy();
            List<int> colNos = colNames.Keys.ToList();
            for (int i = 0; i < colNos.Count; i++)
            {
                newData.Columns[i].ColumnName = colNames[colNos[i]] + "$" + colWidth[colNos[i]];
            }
            return newData;
        }

        /// <summary>
        /// 修改表格使数据各级别合并
        /// </summary>
        /// <param name="oldData">源数据</param>
        /// <param name="levels">级别对应的列编号</param>
        /// <returns>新表格数据</returns>
        public static DataTable MergeLevel(DataTable oldData, List<int> levels)
        {
            DataTable newData = oldData.Copy();
            for(int i = 0; i < newData.Rows.Count; i++)
            {
                for(int j = 1; j < levels.Count; j++)
                {
                    if(newData.Rows[i][levels[j]] != null && newData.Rows[i][levels[j]].ToString() != "")
                    {
                        newData.Rows[i][levels[j - 1]] = newData.Rows[i][levels[j]];
                    }
                }
            }
            levels.RemoveAt(0);
            newData = NoSelectCols(newData, levels);
            return newData;
        }

        /// <summary>
        /// 将两个datatable根据某列进行合并
        /// </summary>
        /// <param name="data1">表格1</param>
        /// <param name="data2">表格2</param>
        /// <param name="mergeColName">根据合并的列名</param>
        /// <returns>合并后的数据</returns>
        public static DataTable MergeDataTable(DataTable data1, string data1ColName, DataTable data2, string data2ColName)
        {
            DataTable newData = new DataTable();
            foreach(DataColumn col in data1.Columns)
            {
                newData.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach(DataColumn col in data2.Columns)
            {
                if(col.ColumnName != data2ColName)
                {
                    newData.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            foreach(DataRow row1 in data1.Rows)
            {
                DataRow newRow = newData.NewRow();
                foreach(DataColumn col1 in data1.Columns)
                {
                    newRow[col1.ColumnName] = row1[col1.ColumnName];
                }
                foreach(DataRow row2 in data2.Rows)
                {
                    if(row1[data1ColName].ToString() == row2[data2ColName].ToString())
                    {
                        foreach(DataColumn col2 in data2.Columns)
                        {
                            if(col2.ColumnName != data2ColName)
                            {
                                newRow[col2.ColumnName] = row2[col2.ColumnName];
                            }
                        }
                    }
                }
                newData.Rows.Add(newRow);
            }
            return newData;
        }


        /// <summary>
        /// 修改表格中某行的数据
        /// </summary>
        /// <param name="oldData">久数据源</param>
        /// <param name="updateColName">需要修改的列</param>
        /// <param name="oldToNew">旧新对照表</param>
        /// <returns>新数据行</returns>
        public static DataTable UpdateDataRow(DataTable oldData, string updateColName, Dictionary<string, string> oldToNew)
        {
            DataTable newData = oldData.Copy();
            foreach(DataRow row in newData.Rows)
            {
                if(oldToNew.ContainsKey(row[updateColName].ToString()))
                {
                    row[updateColName] = oldToNew[row[updateColName].ToString()];
                }
            }
            return newData;
        }

        /// <summary>
        /// 对表格列进行排序
        /// </summary>
        /// <param name="oldData">旧数据</param>
        /// <param name="orderColNameList">排序列名</param>
        /// <returns>新数据</returns>
        public static DataTable ColOrder(DataTable oldData, List<string> orderColNameList)
        {
            DataTable newData = oldData.Copy();
            for(int i = 0; i < orderColNameList.Count; i++)
            {
                newData.Columns[orderColNameList[i]].SetOrdinal(i);
            }
            return newData;
        }

        /// <summary>
        /// 将列相同的Data合并
        /// </summary>
        /// <param name="data1">需要合并的Data1</param>
        /// <param name="data2">需要合并的Data2</param>
        /// <returns>合并后的Data</returns>
        public static DataTable MergeDataTabelColSame(DataTable data1, DataTable data2)
        {
            DataTable newData = new DataTable();
            if(data1 != null && data1.Columns != null && data1.Columns.Count > 0)
            {
                if(data2 != null && data2.Columns != null && data2.Columns.Count > 0)
                {
                    if(data1.Columns.Count == data2.Columns.Count)
                    {
                        foreach(DataColumn col in data1.Columns)
                        {
                            newData.Columns.Add(col.ColumnName, typeof(string));
                        }
                    }
                    else
                    {
                        throw new Exception("两DataTable列数不相同");
                    }
                }
                else
                {
                    foreach(DataColumn col in data1.Columns)
                    {
                        newData.Columns.Add(col.ColumnName, typeof(string));
                    }
                }
            }
            else
            {
                if(data2 != null && data2.Columns != null && data2.Columns.Count > 0)
                {
                    foreach(DataColumn col in data2.Columns)
                    {
                        newData.Columns.Add(col.ColumnName, typeof(string));
                    }
                }
                else
                {
                    return newData;
                }
            }

            if(data1 != null && data1.Rows != null && data1.Rows.Count > 0)
            {
                foreach(DataRow row in data1.Rows)
                {
                    DataRow newRow = newData.NewRow();
                    for(int i = 0; i < newData.Columns.Count; i++)
                    {
                        newRow[newData.Columns[i].ColumnName] = row[data1.Columns[i].ColumnName];
                    }
                    newData.Rows.Add(newRow);
                }
            }

            if(data2 != null && data2.Rows != null && data2.Rows.Count > 0)
            {
                foreach(DataRow row in data2.Rows)
                {
                    DataRow newRow = newData.NewRow();
                    for(int i = 0; i < data2.Columns.Count; i++)
                    {
                        newRow[newData.Columns[i].ColumnName] = row[data2.Columns[i].ColumnName];
                    }
                    newData.Rows.Add(newRow);
                }
            }

            return newData;
        }

        /// <summary>
        /// 根据某列的值对所有行进行排序
        /// </summary>
        /// <param name="oldData">源数据表</param>
        /// <param name="colName">根据某列的值排序，某列名</param>
        /// <param name="orderRowNameList">列值的顺序</param>
        /// <returns>排序后的数据表</returns>
        public static DataTable RowOrder(DataTable oldData, string colName, List<string> orderRowNameList)
        {
            if(oldData != null && oldData.Rows != null && oldData.Rows.Count > 0)
            {
                DataTable newNullData = oldData.Clone();
                DataTable newAllData = oldData.Copy();
                foreach(string rowValue in orderRowNameList)
                {
                    for(int i = 0; i < newAllData.Rows.Count; i++)
                    {
                        if(rowValue == newAllData.Rows[i][colName].ToString())
                        {
                            newNullData.Rows.Add(newAllData.Rows[i].ItemArray);
                            newAllData.Rows.RemoveAt(i);
                            i = i - 1;
                        }
                    }
                }

                if(newAllData.Rows.Count > 0)
                {
                    foreach(DataRow seleteRow in newAllData.Rows)
                    {
                        newNullData.Rows.Add(seleteRow.ItemArray);
                    }
                }

                return newNullData;
            }
            return oldData;
        }

        /// <summary>
        /// 将某些列合并 合并后的列为String类型 列明为第一个需要合并的列名
        /// </summary>
        /// <param name="oldData">源数据</param>
        /// <param name="colNameList">需要合并的列的编号</param>
        /// <returns>合并后的数据</returns>
        public static DataTable MergeCol(DataTable oldData, List<int> colNoList)
        {
            if(oldData != null && oldData.Rows != null && oldData.Rows.Count > 0)
            {
                DataTable newData = oldData.Copy();
                foreach(DataRow row in newData.Rows)
                {
                    for(int i = 1; i < colNoList.Count; i++)
                    {
                        row[colNoList[0]] = row[colNoList[0]].ToString() + row[i].ToString();
                    }
                }
                if(colNoList != null && colNoList.Count > 0)
                {
                    colNoList.RemoveAt(0);
                }
                newData = NoSelectCols(newData, colNoList);
                return newData;
            }
            return oldData;
        }


    }
}
