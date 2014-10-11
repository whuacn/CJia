using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Framework.Data
{
    public class DataObject
    {
        public Dictionary<string, int> Fields = new Dictionary<string, int>();
        public object[] Data = null;

        public DataObject() { }

        public DataObject(params object[] Values)
        {
            this.Data = Values;
        }

        public void InitFields(params string[] field)
        {
            Fields.Clear();
            for (int i = 0; i < field.Length; i++)
            {
                Fields.Add(field[i], i);
            }
        }

        public object Get(string Name)
        {
            return Data[Fields[Name]];
        }

        public int GetInt(string Name)
        { 
            object pValue = Data[Fields[Name]];
            return Convert.ToInt32(pValue);
        }

        public void Set(string Name,object Value)
        {
            Data[Fields[Name]] = Value;
        }

        #region 反序列化
        /// <summary>
        /// 将byte[]反序列化DataTable
        /// </summary>
        /// <param name="ListData"></param>
        /// <returns></returns>
        public static List<T> Deserialize<T>(byte[] ListData) where T : DataObject, new()
        {
            if (ListData == null) return null;
            List<T> DataList = new List<T>();
            using (CJia.Net.Serialization.SerializationReader sr = new CJia.Net.Serialization.SerializationReader(ListData))
            {
                T dataObject = new T();
                BuildFieldDict(sr, dataObject.Fields);
                while (sr.BytesRemaining != 0)
                {
                    dataObject.Data = sr.ReadOptimizedObjectArray();
                    DataList.Add(dataObject);
                }
            }
            return DataList;
        }
        /// <summary>
        /// 根据表结构创建数据表
        /// </summary>
        /// <param name="dataFields">数据字典</param>
        /// <returns></returns>
        static void BuildFieldDict(CJia.Net.Serialization.SerializationReader sr, Dictionary<string, int> dataFields)
        {
            dataFields.Clear();
            string colName, colType, tableName = "";
            string[] arySchema;
            int rowsCount = sr.ReadOptimizedInt32();
            int colsCount = 0;
            Dictionary<string, int> listColumn = new Dictionary<string, int>(rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                arySchema = sr.ReadOptimizedStringArray();
                tableName = arySchema[0];
                colName = arySchema[1];
                colType = arySchema[2];

                if (!listColumn.TryGetValue(colName, out colsCount))
                {
                    listColumn.Add(colName, 1);
                }
                else
                {
                    listColumn[colName] = colsCount + 1;
                    colName = colName + "_" + colsCount.ToString();
                }

                dataFields.Add(colName, i);
            }
            listColumn.Clear();
            listColumn = null;
        }
        #endregion
    }
}
