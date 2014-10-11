using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.ORM
{
    /// <summary>
    /// ORM中实体属性对应的表字段信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FieldAttribute : System.Attribute
    {
        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        public FieldAttribute()
        {

        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        public FieldAttribute(string FieldName,string FieldCaption)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        /// <param name="PrimaryKey">是否主键</param>
        public FieldAttribute(string FieldName, string FieldCaption, bool PrimaryKey)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _isPrimaryKey = PrimaryKey;
        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        /// <param name="Length">最大长度</param>
        public FieldAttribute(string FieldName, string FieldCaption, int Length)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _MaxLength = Length;
        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        /// <param name="FieldType">字段类型(默认字符串)</param>
        public FieldAttribute(string FieldName, string FieldCaption, Type FieldType)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _DataType = FieldType;
        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        /// <param name="FieldType">字段类型(默认字符串)</param>
        /// <param name="isAllowNull">是否允许为空</param>
        public FieldAttribute(string FieldName, string FieldCaption, Type FieldType, bool isAllowNull)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _DataType = FieldType;
            _Nullable = isAllowNull;
        }

        /// <summary>
        /// ORM中实体属性对应的表字段信息
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="FieldCaption">字段标题</param>
        /// <param name="isAllowNull">是否允许为空</param>
        /// <param name="Length">最大长度</param>
        public FieldAttribute(string FieldName, string FieldCaption, bool isAllowNull, int Length)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _Nullable = isAllowNull;
            _MaxLength = Length;
        }

        private string _Name = string.Empty;
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name
        {
            get { return _Name.ToUpper(); }
            set { _Name = value; }
        }

        private string _Caption = string.Empty;
        /// <summary>
        /// 标题（中文显示）
        /// </summary>
        public string Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }

        private Type _DataType = Type.GetType("System.String");
        /// <summary>
        /// 数据类型（默认为字符串）
        /// </summary>
        public Type DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        private int _MaxLength = int.MaxValue;
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private bool _isPrimaryKey = false;
        /// <summary>
        /// 标识是否关键字段（默认为非关键字段False）
        /// </summary>
        public bool isPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        private bool _isCLOB = false;
        /// <summary>
        /// 标识是否CLOB类型
        /// </summary>
        public bool isCLOB
        {
            get { return _isCLOB; }
            set { _isCLOB = value; }
        }

        private bool _Nullable = true;
        /// <summary>
        /// 标识是否允许为空（默认允许为空True）
        /// </summary>
        public bool Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }

        private bool _isQuery = false;
        /// <summary>
        /// 标识是否查询字段（默认为False，用于只查询不做插入的字段）
        /// </summary>
        public bool isQuery
        {
            get { return _isQuery; }
            set { _isQuery = value; }
        }
        private object _DefaultValue = null;
        /// <summary>
        /// 字段的缺省值
        /// </summary>
        public object DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }
    }
}
