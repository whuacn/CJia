using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CJia.ORM
{
    /// <summary>
    /// ORM中实体对应的表属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableAttribute : System.Attribute
    {
        /// <summary>
        /// ORM中实体对应表的属性
        /// </summary>
        public TableAttribute()
        {
           
        }

        private string _Name;
        /// <summary>
        /// 表名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private bool _ReadOnly = false;
        /// <summary>
        /// 只读属性（不能执行Save操作）
        /// </summary>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }

        private DatabaseType dbType = DatabaseType.Oracle;
        /// <summary>
        /// 数据库类别（默认为Oracle）
        /// </summary>
        public DatabaseType DBType
        {
            get { return dbType; }
            set { dbType = value; }
        }
    }
    /// <summary>
    /// 数据库类别
    /// </summary>
    public enum DatabaseType
    { 
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle,
        /// <summary>
        /// Sql Server数据库
        /// </summary>
        SqlServer
    }
}
