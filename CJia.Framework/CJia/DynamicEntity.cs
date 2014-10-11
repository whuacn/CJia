using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia
{
    /// <summary>
    /// 动态实体
    /// </summary>
    public class DynamicEntity : IDisposable
    {
        string SqlText = "";
        string TableName = "";
        object[] QueryParams = null;
        DataTable dtResult;
        DataAdapter _ETDataAdapter = null;
        ORM.DatabaseType deDBType = ORM.DatabaseType.Oracle;
        /// <summary>
        /// 实体数据访问适配器
        /// </summary>
        protected DataAdapter EntityAdapter
        {
            get
            {
                if (_ETDataAdapter == null)
                    return DefaultData.DefaultAdapter;
                return _ETDataAdapter;
            }
            set { _ETDataAdapter = value; }
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="SqlQuery"></param>
        public DynamicEntity(string SqlQuery)
        {
            SqlText = SqlQuery;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="SqlQuery"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(string SqlQuery, object[] SqlParams)
        {
            SqlText = SqlQuery;
            QueryParams = SqlParams;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="deAdapter"></param>
        /// <param name="SqlQuery"></param>
        public DynamicEntity(DataAdapter deAdapter, string SqlQuery)
        {
            _ETDataAdapter = deAdapter;
            SqlText = SqlQuery;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="deAdapter"></param>
        /// <param name="SqlQuery"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(DataAdapter deAdapter, string SqlQuery, object[] SqlParams)
        {
            _ETDataAdapter = deAdapter;
            SqlText = SqlQuery;
            QueryParams = SqlParams;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="deAdapter"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlWhere"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(DataAdapter deAdapter, string tableName, string sqlWhere, object[] SqlParams)
        {
            _ETDataAdapter = deAdapter;
            TableName = tableName;
            SqlText = BuildFillSql(tableName, sqlWhere);
            QueryParams = SqlParams;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sqlWhere"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(string tableName, string sqlWhere, object[] SqlParams)
        {
            TableName = tableName;
            SqlText = BuildFillSql(tableName, sqlWhere);
            QueryParams = SqlParams;
        }

        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="SqlQuery"></param>
        public DynamicEntity(ORM.DatabaseType DBType, string SqlQuery)
        {
            SqlText = SqlQuery;
            deDBType = DBType;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="SqlQuery"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(ORM.DatabaseType DBType, string SqlQuery, object[] SqlParams)
        {
            SqlText = SqlQuery;
            QueryParams = SqlParams;
            deDBType = DBType;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="deAdapter"></param>
        /// <param name="SqlQuery"></param>
        public DynamicEntity(ORM.DatabaseType DBType, DataAdapter deAdapter, string SqlQuery)
        {
            _ETDataAdapter = deAdapter;
            SqlText = SqlQuery;
            deDBType = DBType;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="deAdapter"></param>
        /// <param name="SqlQuery"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(ORM.DatabaseType DBType, DataAdapter deAdapter, string SqlQuery, object[] SqlParams)
        {
            _ETDataAdapter = deAdapter;
            SqlText = SqlQuery;
            QueryParams = SqlParams;
            deDBType = DBType;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="deAdapter"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlWhere"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(ORM.DatabaseType DBType, DataAdapter deAdapter, string tableName, string sqlWhere, object[] SqlParams)
        {
            _ETDataAdapter = deAdapter;
            TableName = tableName;
            SqlText = BuildFillSql(tableName, sqlWhere);
            QueryParams = SqlParams;
            deDBType = DBType;
        }
        /// <summary>
        /// 动态实体
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlWhere"></param>
        /// <param name="SqlParams"></param>
        public DynamicEntity(ORM.DatabaseType DBType, string tableName, string sqlWhere, object[] SqlParams)
        {
            TableName = tableName;
            SqlText = BuildFillSql(tableName, sqlWhere);
            QueryParams = SqlParams;
            deDBType = DBType;
        }
        string BuildFillSql(string tableName, string sqlWhere)
        {
            string sqlText = String.Format("Select * From {0} ", tableName);
            if (sqlWhere.Length > 0)
            {
                if (sqlWhere.ToUpper().IndexOf("WHERE") == -1)
                {
                    sqlText += "Where " + sqlWhere;
                }
                else
                {
                    sqlText += sqlWhere;
                }
            }
            return sqlText;
        }
        dynamic dataEntity = null;
        /// <summary>
        /// 数据实体
        /// </summary>
        public dynamic DataEntity
        {
            get
            {
                if (dataEntity == null)
                {
                    dataEntity = BuildObject();
                    dataEntity.EntitySet = dtResult;
                }
                return dataEntity;
            }
        }
        string csCode;
        /// <summary>
        /// 源代码
        /// </summary>
        public string SourceCode
        {
            get { return csCode; }
        }
        private dynamic BuildObject()
        {
            dtResult = EntityAdapter.Query(SqlText, QueryParams);
            csCode = BuildCsCode(dtResult);
            return CJia.Compiler.BuildDynamicObject(csCode);
        }
        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName;
        private string BuildCsCode(DataTable dtData)
        {
            StringBuilder sbCode = new StringBuilder();
            sbCode.AppendLine("using System;");
            sbCode.AppendLine("using CJia.ORM;");
            sbCode.AppendLine("namespace CJia");
            sbCode.AppendLine("{");
            string readOnly = TableName.Length == 0 ? "true" : "false";
            sbCode.AppendLine("  [Table(Name = \"" + TableName + "\" , ReadOnly = " + readOnly + " , DBType=ORM.DatabaseType." + deDBType.ToString() + ")]");
            ClassName = "DE" + (new Random()).Next().ToString();
            sbCode.AppendLine("  public class " + ClassName + " : DataEntity<" + ClassName + "> ");
            sbCode.AppendLine("  {");
            ClassName = "CJia." + ClassName;
            string ColumnName = "";
            for (int i = 0; i < dtData.Columns.Count; i++)
            {
                DataColumn dc = dtData.Columns[i];
                ColumnName = dc.ColumnName.ToUpper();
                sbCode.Append("\t[Field(Name=\"" + ColumnName + "\", Caption=\"" + ColumnName + "\"");
                switch (dc.DataType.ToString())
                {
                    case "System.Decimal": sbCode.Append(",DataType=typeof(decimal)"); break;
                    case "System.DateTime": sbCode.Append(",DataType=typeof(DateTime)"); break;
                }
                sbCode.Append(")]\n");
                sbCode.Append("\tpublic string " + ColumnName + "\n");
                sbCode.Append("\t{\n");
                sbCode.Append("\t\tget { return Get(\"" + ColumnName + "\"); }\n");
                sbCode.Append("\t\tset { Set(\"" + ColumnName + "\", value); }\n");
                sbCode.Append("\t}\n");
            }
            sbCode.AppendLine("  }");
            sbCode.AppendLine("}");
            return sbCode.ToString();
        }
        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (Entity.DictField.ContainsKey(ClassName))
                Entity.DictField.Remove(ClassName);
            if (Entity.DictTable.ContainsKey(ClassName))
                Entity.DictTable.Remove(ClassName);
        }
    }
}
