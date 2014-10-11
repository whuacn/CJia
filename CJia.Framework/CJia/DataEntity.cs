using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using CJia.ORM;

namespace CJia
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataEntity<T> : Entity where T : DataEntity<T>, new()
    {
        /// <summary>
        /// 业务/数据实体
        /// </summary>
        /// <param name="adapter">指定数据访问适配器</param>
        public DataEntity(DataAdapter adapter)
        {
            EntityAdapter = adapter;
            InitEntity();
        }
        /// <summary>
        /// 业务/数据实体
        /// </summary>
        /// <param name="adapter">指定数据访问适配器</param>
        /// <param name="drData">初始化一条记录</param>
        public DataEntity(DataAdapter adapter, DataRow drData)
        {
            EntityAdapter = adapter;
            InitEntity();
            Add(drData);
        }
        /// <summary>
        /// 业务/数据实体
        /// </summary>
        /// <param name="adapter">指定数据访问适配器</param>
        /// <param name="drcData">初始化多条记录</param>
        public DataEntity(DataAdapter adapter, DataRow[] drcData)
        {
            EntityAdapter = adapter;
            InitEntity();
            Add(drcData);
        }
        /// <summary>
        /// 业务/数据实体（使用缺省数据访问组件）
        /// </summary>
        public DataEntity()
        {
            InitEntity();
        }

        /// <summary>
        /// 业务/数据实体
        /// </summary>
        /// <param name="drData">初始化一条记录</param>
        public DataEntity(DataRow drData)
        {
            InitEntity();
            Add(drData);
        }
        /// <summary>
        /// 业务/数据实体
        /// </summary>
        /// <param name="drcData">初始化多条记录</param>
        public DataEntity(DataRow[] drcData)
        {
            InitEntity();
            Add(drcData);
        }

        void InitEntity()
        {
            EntityName = typeof(T).FullName;
            if (DictTable.ContainsKey(EntityName))
            {
                TableAttribute ta = DictTable[EntityName];
                InitTableAttribute(ta);
                return;
            }
            System.Reflection.MemberInfo info = typeof(T);
            //获取表结构定义
            object[] aryCA = info.GetCustomAttributes(false);
            foreach (object ca in aryCA)
            {
                if (ca is ORM.TableAttribute)
                {
                    TableAttribute ta = ca as ORM.TableAttribute;
                    InitTableAttribute(ta);
                    DictTable.Add(EntityName, ta);
                }
            }
            //获取属性
            PropertyInfo[] aryPI = typeof(T).GetProperties();
            foreach (PropertyInfo pi in aryPI)
            {
                object[] aryFA = pi.GetCustomAttributes(Type.GetType("CJia.ORM.FieldAttribute"), false);
                if (aryFA.Length == 0) continue;

                if (aryFA[0] is ORM.FieldAttribute)
                {
                    ORM.FieldAttribute field = aryFA[0] as ORM.FieldAttribute;
                    if (!DictField.ContainsKey(EntityName))
                    {
                        DictField.Add(EntityName, new Dictionary<string, FieldAttribute>());
                    }
                    if (field.isPrimaryKey)
                        PrimaryKey = field.Name;
                    DictField[EntityName].Add(pi.Name, field);
                }
            }
        }

        void InitTableAttribute(TableAttribute ta)
        {
            this.TableName = ta.Name;
            this.isReadOnly = ta.ReadOnly;
            this.DBType = ta.DBType;
            if (this.DBType == DatabaseType.Oracle)
                this.ParamToken = ":";
            else if (this.DBType == DatabaseType.SqlServer)
                this.ParamToken = "@";
        }
    }
}
