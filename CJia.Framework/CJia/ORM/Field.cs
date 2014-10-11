using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.ORM
{
    /// <summary>
    /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FieldAttribute : System.Attribute
    {
        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        public FieldAttribute()
        {

        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        public FieldAttribute(string FieldName,string FieldCaption)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        /// <param name="PrimaryKey">�Ƿ�����</param>
        public FieldAttribute(string FieldName, string FieldCaption, bool PrimaryKey)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _isPrimaryKey = PrimaryKey;
        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        /// <param name="Length">��󳤶�</param>
        public FieldAttribute(string FieldName, string FieldCaption, int Length)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _MaxLength = Length;
        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        /// <param name="FieldType">�ֶ�����(Ĭ���ַ���)</param>
        public FieldAttribute(string FieldName, string FieldCaption, Type FieldType)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _DataType = FieldType;
        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        /// <param name="FieldType">�ֶ�����(Ĭ���ַ���)</param>
        /// <param name="isAllowNull">�Ƿ�����Ϊ��</param>
        public FieldAttribute(string FieldName, string FieldCaption, Type FieldType, bool isAllowNull)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _DataType = FieldType;
            _Nullable = isAllowNull;
        }

        /// <summary>
        /// ORM��ʵ�����Զ�Ӧ�ı��ֶ���Ϣ
        /// </summary>
        /// <param name="FieldName">�ֶ�����</param>
        /// <param name="FieldCaption">�ֶα���</param>
        /// <param name="isAllowNull">�Ƿ�����Ϊ��</param>
        /// <param name="Length">��󳤶�</param>
        public FieldAttribute(string FieldName, string FieldCaption, bool isAllowNull, int Length)
        {
            _Name = FieldName;
            _Caption = FieldCaption;
            _Nullable = isAllowNull;
            _MaxLength = Length;
        }

        private string _Name = string.Empty;
        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string Name
        {
            get { return _Name.ToUpper(); }
            set { _Name = value; }
        }

        private string _Caption = string.Empty;
        /// <summary>
        /// ���⣨������ʾ��
        /// </summary>
        public string Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }

        private Type _DataType = Type.GetType("System.String");
        /// <summary>
        /// �������ͣ�Ĭ��Ϊ�ַ�����
        /// </summary>
        public Type DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        private int _MaxLength = int.MaxValue;
        /// <summary>
        /// ��󳤶�
        /// </summary>
        public int MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private bool _isPrimaryKey = false;
        /// <summary>
        /// ��ʶ�Ƿ�ؼ��ֶΣ�Ĭ��Ϊ�ǹؼ��ֶ�False��
        /// </summary>
        public bool isPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        private bool _isCLOB = false;
        /// <summary>
        /// ��ʶ�Ƿ�CLOB����
        /// </summary>
        public bool isCLOB
        {
            get { return _isCLOB; }
            set { _isCLOB = value; }
        }

        private bool _Nullable = true;
        /// <summary>
        /// ��ʶ�Ƿ�����Ϊ�գ�Ĭ������Ϊ��True��
        /// </summary>
        public bool Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }

        private bool _isQuery = false;
        /// <summary>
        /// ��ʶ�Ƿ��ѯ�ֶΣ�Ĭ��ΪFalse������ֻ��ѯ����������ֶΣ�
        /// </summary>
        public bool isQuery
        {
            get { return _isQuery; }
            set { _isQuery = value; }
        }
        private object _DefaultValue = null;
        /// <summary>
        /// �ֶε�ȱʡֵ
        /// </summary>
        public object DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }
    }
}
