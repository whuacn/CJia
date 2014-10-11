using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.ORM
{
    /// <summary>
    /// ORM��ʵ���Ӧ�ı�����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableAttribute : System.Attribute
    {
        /// <summary>
        /// ORM��ʵ���Ӧ�������
        /// </summary>
        public TableAttribute()
        {
           
        }

        private string _Name;
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private bool _ReadOnly = false;
        /// <summary>
        /// ֻ�����ԣ�����ִ��Save������
        /// </summary>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }

        private DatabaseType dbType = DatabaseType.Oracle;
        /// <summary>
        /// ���ݿ����Ĭ��ΪOracle��
        /// </summary>
        public DatabaseType DBType
        {
            get { return dbType; }
            set { dbType = value; }
        }
    }
    /// <summary>
    /// ���ݿ����
    /// </summary>
    public enum DatabaseType
    { 
        /// <summary>
        /// Oracle���ݿ�
        /// </summary>
        Oracle,
        /// <summary>
        /// Sql Server���ݿ�
        /// </summary>
        SqlServer
    }
}
