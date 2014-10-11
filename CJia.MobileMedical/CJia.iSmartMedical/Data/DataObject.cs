using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class DataObject : INotifyPropertyChanged
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
            int fieldCount = field.Length;
            for (int i = 0; i < fieldCount; i++)
            {
                Fields.Add(field[i], i);
            }
            Data = new object[fieldCount];
        }
        public byte[] GetBytes([CallerMemberName] string MethodName = "")
        {
            object pValue = Data[Fields[MethodName]];
            return pValue as byte[];// == null ? new byte[0] : pValue as byte[];
        }

        public string Get([CallerMemberName] string MethodName = "")
        {
            object pValue = Data[Fields[MethodName]];
            return pValue == null ? "" : pValue.ToString();
        }
        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public string GetExtValue(string FieldName)
        {
            object pValue = Data[Fields[FieldName]];
            return pValue == null ? "" : pValue.ToString();
        }

        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public byte[] GetExtBytes(string FieldName)
        {
            object pValue = Data[Fields[FieldName]];
            return pValue == null ? null : pValue as byte[];
        }

        public decimal GetDecimal([CallerMemberName] string MethodName = "")
        {
            object pValue = Data[Fields[MethodName]];
            return pValue == null ? 0 : Convert.ToDecimal(pValue);
        }

        public int GetInt([CallerMemberName] string MethodName = "")
        {
            object pValue = Data[Fields[MethodName]];
            return pValue == null ? 0 : Convert.ToInt32(pValue);
        }

        public void Set(object Value, [CallerMemberName] string MethodName = "")
        {
            Data[Fields[MethodName]] = Value;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }  
        /// <summary>
        /// 获取过滤字段
        /// </summary>
        /// <returns></returns>
        public virtual string GetFilter()
        {
            return "";
        }

        public string[] FieldArray
        {
            get
            {
                return Fields.Keys.ToArray<string>();
            }
        }
    }
}
