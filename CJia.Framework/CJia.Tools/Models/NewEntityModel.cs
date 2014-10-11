using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.Tools.Models
{
    public class NewEntityModel
    {
        public Dictionary<string, List<string>> GetDBConfig()
        {
            return CJia.DefaultData.QueryDBConfig();
        }

        public DataTable GetTableList(string DataSource, string SchemaName)
        {
            using (CJia.DataAdapter ada = new DataAdapter(DataSource))
            {
                DataTable Result = ada.Query(SqlTools.SqlQueryTable, new object[] { SchemaName.ToUpper() });
                return Result;
            }
        }

        public DataTable GetTableSchema(string DataSource, string SchemaName, string TableName)
        {
            using (CJia.DataAdapter ada = new DataAdapter(DataSource))
            {
                DataTable Result = ada.Query( SqlTools.SqlQueryTableStruct, new object[] { SchemaName.ToUpper(), TableName.ToUpper() });
                return Result;
            }
        }

        public DataTable GetTable(string DataSource, string SchemaName, string TableName)
        {
            using(CJia.DataAdapter ada = new DataAdapter(DataSource))
            {
                DataTable Result = ada.Query(SqlTools.GetTable, new object[] { SchemaName.ToUpper(), TableName.ToUpper() });
                return Result;
            }
        }

        public string GetColsFieldCode(DataTable cols)
        {
            return "";
        }

        public string GetColsAttributeCode(DataTable cols)
        {
            StringBuilder sbCode = new StringBuilder();
            foreach(DataRow dr in cols.Rows)
            {
                sbCode.AppendLine("");
                sbCode.AppendLine("\t\t/// <summary>");
                sbCode.AppendLine("\t\t///" + dr["COMMENTS"].ToString());
                sbCode.AppendLine("\t\t/// </summary>");
                sbCode.Append("\t\t[CJia.ORM.Field(");
                sbCode.Append(" Name = \"" + dr["COLUMN_NAME"].ToString() + "\"");
                sbCode.Append(", Caption = \"" + dr["COMMENTS"].ToString() + "\"");
                sbCode.Append(", DataType = typeof(" + GetDataType(dr["DATA_TYPE"].ToString()) + ")");
                sbCode.Append(", MaxLength = " + dr["DATA_LENGTH"].ToString());
                if(dr["CONSTRAINT_TYPE"].ToString() == "P")
                {
                    sbCode.Append(", isPrimaryKey = true");
                }
                if(dr["NULLABLE"].ToString() == "Y")
                {
                    sbCode.Append(", Nullable = true");
                }
                if(dr["DATA_DEFAULT"].ToString().Length != 0)
                {
                    sbCode.Append(", DefaultValue = \"" + dr["DATA_DEFAULT"].ToString() + "\"");
                }
                sbCode.AppendLine(")]");
                sbCode.AppendLine("\t\tpublic string " + GetFieldName(dr["COLUMN_NAME"].ToString()));
                sbCode.AppendLine("\t\t{");
                sbCode.AppendLine("\t\t\tset");
                sbCode.AppendLine("\t\t\t{");
                sbCode.AppendLine("\t\t\t\tSet(\"" + dr["COLUMN_NAME"].ToString() + "\", value);");
                sbCode.AppendLine("\t\t\t}");
                sbCode.AppendLine("\t\t\tget");
                sbCode.AppendLine("\t\t\t{");
                sbCode.AppendLine("\t\t\t\treturn Get(\"" + dr["COLUMN_NAME"].ToString() + "\");");
                sbCode.AppendLine("\t\t\t}");
                sbCode.AppendLine("\t\t}");
            }
            return sbCode.ToString();
        }


        public string GetFieldName(string name)
        {
            string[] strs = name.Split(new char[]{'_'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach(string str in strs)
            {
                result.Append(str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower());
            }
            return result.ToString();
        }

        private string GetDataType(string typestr)
        {
            if(typestr.ToLower().IndexOf("number") >= 0)
            {
                return "int";
            }
            if(typestr.ToLower().IndexOf("long") >= 0)
            {
                return "long";
            }
            if(typestr.ToLower().IndexOf("int") >= 0)
            {
                return "int";
            }
            if(typestr.ToLower().IndexOf("double") >= 0)
            {
                return "double";
            }
            if(typestr.ToLower().IndexOf("float") >= 0)
            {
                return "float";
            }
            if(typestr.ToLower().IndexOf("char") >= 0)
            {
                return "string";
            }
            if(typestr.ToLower().IndexOf("date") >= 0)
            {
                return "DateTime";
            }
            return "string";
        }
    }
}
