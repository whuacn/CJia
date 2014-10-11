using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CJia.ORM;

namespace CJia
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class Entity : IDisposable
    {
        #region Cache
        /// <summary>
        /// 表字典
        /// </summary>
        public static Dictionary<string, TableAttribute> DictTable = new Dictionary<string, TableAttribute>();
        /// <summary>
        /// 字段字典
        /// </summary>
        public static Dictionary<string, Dictionary<string, FieldAttribute>> DictField = new Dictionary<string, Dictionary<string, FieldAttribute>>();
        private const string MSG_DELETE_FAIL = "删除失败，您提交的数据已被修改，请刷新后重试。";
        private const string MSG_UPDATE_FAIL = "更新失败，您提交的数据已被修改，请刷新后重试。";
        private const string MSG_READONLY = "该数据实体为只读，不能进行保存操作。";
        #endregion

        #region Field
        /// <summary>
        /// 通过序号获取实体
        /// </summary>
        public Entity this[int i]
        {
            get
            {
                EntityData = this.EntitySet.Rows[i];
                return this;
            }
        }
        /// <summary>
        /// 通过行获取实体
        /// </summary>
        /// <param name="drData">数据行</param>
        /// <returns>实体</returns>
        public Entity this[DataRow drData]
        {
            get
            {
                EntityData = drData;
                return this;
            }
        }
        /// <summary>
        /// 实体数据
        /// </summary>
        public DataRow EntityData;
        DataTable _EntitySet = null;
        /// <summary>
        /// 实体集
        /// </summary>
        public DataTable EntitySet
        {
            get
            {
                if (_EntitySet == null)
                    _EntitySet = NewTable();
                return _EntitySet;
            }
            set
            {
                _EntitySet = value;
                if (_EntitySet.Rows.Count > 0)
                    EntityData = _EntitySet.Rows[0];
            }
        }
        /// <summary>
        /// 主键字段
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// 数据表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 标识是否为只读
        /// </summary>
        public bool isReadOnly { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 数据库类别
        /// </summary>
        public ORM.DatabaseType DBType { get; set; }
        /// <summary>
        /// 参数标识符
        /// </summary>
        public string ParamToken { get; set; }
        /// <summary>
        /// 实体数
        /// </summary>
        public int Count
        {
            get
            {
                return this.EntitySet.Rows.Count;
            }
        }
        DataAdapter _ETDataAdapter = null;
        /// <summary>
        /// 实体数据访问适配器
        /// </summary>
        public DataAdapter EntityAdapter
        {
            get
            {
                if (_ETDataAdapter == null)
                    return DefaultData.DefaultAdapter;
                return _ETDataAdapter;
            }
            set { _ETDataAdapter = value; }
        }
        #endregion

        #region Get Set
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <returns></returns>
        protected string Get(string FieldName)
        {
            return EntityData[FieldName].ToString();
        }
        /// <summary>
        /// 设置实体数据
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="value"></param>
        protected void Set(string FieldName, object value)
        {
            EntityData[FieldName] = value;
        }
        #endregion

        #region Add
        /// <summary>
        /// 新增数据行
        /// </summary>
        public void Add()
        {
            DataRow dr = EntitySet.NewRow();
            this.EntitySet.Rows.Add(dr);
            EntityData = dr;
        }
        /// <summary>
        /// 新增记录(自动设置行为添加状态)
        /// </summary>
        /// <param name="drData">行数据</param>
        public void Add(DataRow drData)
        {
            if (drData.RowState == DataRowState.Detached && drData.Table.TableName == this.EntitySet.TableName)
                this.EntitySet.Rows.Add(drData);
            else
                EntitySet.ImportRow(drData);
            if (EntitySet.Rows.Count == 0) return;
            int RowIndex = EntitySet.Rows.Count - 1;
            EntitySet.Rows[RowIndex].AcceptChanges();
            EntitySet.Rows[RowIndex].SetAdded();
            EntityData = EntitySet.Rows[RowIndex];
        }
        /// <summary>
        /// 新增多条记录(自动设置行为添加状态)
        /// </summary>
        /// <param name="drcData">行数据集</param>
        public void Add(DataRow[] drcData)
        {
            foreach (DataRow dr in drcData)
            {
                Add(dr);
            }
        }
        #endregion

        #region Import
        /// <summary>
        /// 导入记录(维持原行状态)
        /// </summary>
        /// <param name="drData">行数据</param>
        public void Import(DataRow drData)
        {
            EntitySet.ImportRow(drData);
            EntityData = EntitySet.Rows[EntitySet.Rows.Count - 1];
        }
        /// <summary>
        /// 导入记录(维持原行状态)
        /// </summary>
        /// <param name="drcData">行数据集</param>
        public void Import(DataRow[] drcData)
        {
            foreach (DataRow dr in drcData)
            {
                Import(dr);
            }
        }
        /// <summary>
        /// 导入记录(维持原行状态)
        /// </summary>
        /// <param name="drcData">行数据集</param>
        public void Import(DataRowCollection drcData)
        {
            foreach (DataRow dr in drcData)
            {
                Import(dr);
            }
        }
        #endregion

        #region Remove Delete
        /// <summary>
        /// 移除当前记录(彻底删除)
        /// </summary>
        public void Remove()
        {
            EntitySet.Rows.Remove(EntityData);//此方法找不到已删除的行，彻底删除；
        }

        /// <summary>
        /// 移除当前记录(在行上作删除标记，保存之后，将数据库中的数据删除)
        /// </summary>
        public void Delete()
        {
            EntityData.Delete();
        }

        /// <summary>
        /// 移除指定记录(在行上作删除标记，保存之后，将数据库中的数据删除)
        /// </summary>
        public void Delete(DataRow drDelete)
        {
            drDelete.Delete();
        }

        /// <summary>
        /// 移除指定记录(在行上作删除标记，保存之后，将数据库中的数据删除)
        /// </summary>
        public void Delete(DataRow[] drsDelete)
        {
            foreach (DataRow dr in drsDelete)
            {
                Delete(dr);
            }
        }

        /// <summary>
        /// 移除所有记录
        /// </summary>
        public void Clear()
        {
            this.EntitySet.Clear();
        }
        #endregion

        #region Change
        /// <summary>
        /// 获取实体改变过的数据
        /// </summary>
        public DataTable GetChanges()
        {
            if (EntitySet == null) return null;
            return EntitySet.GetChanges();
        }
        /// <summary>
        /// 获取实体改变过的数据
        /// </summary>
        public DataTable GetChanges(DataRowState rowState)
        {
            if (EntitySet == null) return null;
            return EntitySet.GetChanges(rowState);
        }
        #endregion

        #region Get Set Value
        /// <summary>
        /// 通过序行列序号获取值
        /// </summary>
        public string GetValue(int IndexRow, int IndexColumn)
        {
            return EntitySet.Rows[IndexRow][IndexColumn].ToString();
        }
        /// <summary>
        /// 通过序行列序号设置值
        /// </summary>
        public void SetValue(int IndexRow, int IndexColumn, object Value)
        {
            EntitySet.Rows[IndexRow][IndexColumn] = Value;
        }
        /// <summary>
        /// 获取DataRow
        /// </summary>
        public DataRow GetData(int IndexRow)
        {
            return EntitySet.Rows[IndexRow];
        }
        #endregion

        #region Find Select
        /// <summary>
        /// 通过主键数据，获取行号(必须预设定主键)
        /// </summary>
        /// <param name="PrimaryData">主键数据</param>
        /// <returns></returns>
        public int IndexOf(object PrimaryData)
        {
            if ((EntitySet.PrimaryKey == null) || (EntitySet.PrimaryKey.Length == 0))
            {
                EntitySet.PrimaryKey = new DataColumn[] { EntitySet.Columns[this.PrimaryKey] };
            }
            int index = EntitySet.Rows.IndexOf(EntitySet.Rows.Find(PrimaryData));
            EntitySet.PrimaryKey = null;
            return index;
        }
        /// <summary>
        /// 通过主键数据，定位数据行
        /// </summary>
        /// <param name="PrimaryData">主键数据</param>
        /// <returns></returns>
        public DataRow Find(object PrimaryData)
        {
            if ((EntitySet.PrimaryKey == null) || (EntitySet.PrimaryKey.Length == 0))
            {
                EntitySet.PrimaryKey = new DataColumn[] { EntitySet.Columns[this.PrimaryKey] };
            }
            DataRow dr = EntitySet.Rows.Find(PrimaryData);
            EntitySet.PrimaryKey = null;
            return dr;
        }
        /// <summary>
        /// 过滤数据
        /// </summary>
        /// <param name="FilterExpression">表达式</param>
        /// <returns>数据行集</returns>
        public DataRow[] Select(string FilterExpression)
        {
            return EntitySet.Select(FilterExpression);
        }
        #endregion

        #region Table
        /// <summary>
        /// 新建表
        /// </summary>
        /// <returns></returns>
        protected DataTable NewTable()
        {
            DataTable dt = new DataTable();
            Dictionary<string, FieldAttribute> Fields = DictField[EntityName];
            foreach (FieldAttribute field in Fields.Values)
            {
                dt.Columns.Add(NewColumn(field));
            }
            return dt;
        }

        private DataColumn NewColumn(ORM.FieldAttribute field)
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = field.Name;
            dc.DataType = field.DataType;
            dc.Caption = field.Caption;
            if (field.DefaultValue != null)
            {
                dc.DefaultValue = field.DefaultValue;
            }
            if (field.DataType.ToString() == "System.String")
            {
                dc.MaxLength = field.MaxLength;
            }
            return dc;
        }
        #endregion

        #region Fill
        /// <summary>
        /// 默认的查询SQL
        /// </summary>
        protected string sqlSelect = string.Empty;
        /// <summary>
        /// Select SQL
        /// </summary>
        protected string FillSql
        {
            get
            {
                if (String.IsNullOrEmpty(sqlSelect))
                {
                    sqlSelect = GetSelectSql();
                }
                return sqlSelect;
            }
            set
            {
                sqlSelect = value;
            }
        }
        /// <summary>
        /// 生成查询SQL
        /// </summary>
        /// <returns></returns>
        private string GetSelectSql()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append("SELECT ");
            foreach (FieldAttribute fa in DictField[this.EntityName].Values)
            {
                //忽略查询字段(数据库中没有的字段)
                if (fa.isQuery) continue;
                sb.Append(fa.Name);
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" FROM ");
            sb.Append(TableName);
            return sb.ToString();
        }
        /// <summary>
        /// 填充数据到实体集(适用小数据实体)
        /// </summary>
        public DataTable Fill()
        {
            return Fill("");
        }

        /// <summary>
        /// 填充数据到实体集(适用小数据实体)
        /// </summary>
        /// <param name="StrWhere">Where查询条件</param>
        public DataTable Fill(string StrWhere)
        {
            return Fill("", StrWhere, null);
        }
        /// <summary>
        /// 填充数据到实体集(适用小数据实体)
        /// </summary>
        /// <param name="StrWhere">Where查询条件</param>
        /// <param name="Params">SQL参数</param>
        public DataTable Fill(string StrWhere, object[] Params)
        {
            return Fill("", StrWhere, Params);
        }
        /// <summary>
        /// 填充数据到实体集【优化】
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <param name="StrWhere">Where查询条件</param>
        /// <param name="Params">SQL参数</param>
        public DataTable Fill(string TransId, string StrWhere, object[] Params)
        {
            string SqlText = FillSql;
            if (StrWhere.Length > 0)
            {
                if (StrWhere.ToUpper().IndexOf("WHERE") == -1)
                {
                    SqlText += " WHERE " + StrWhere;
                }
                else
                {
                    SqlText += " " + StrWhere;
                }
            }
            this.EntitySet = EntityAdapter.Query(TransId, SqlText, Params);
            return EntitySet;
        }
        #endregion

        #region Query
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        public DataTable Query(string SqlText)
        {
            return Query("", SqlText, null);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <param name="SqlText">SQL文本</param>
        public DataTable Query(string TransId, string SqlText)
        {
            return Query(TransId, SqlText, null);
        }
        /// <summary>
        /// 查询【优化】
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        public DataTable Query(string SqlText, object[] Params)
        {
            return Query("", SqlText, Params);
        }
        /// <summary>
        /// 查询【优化】
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        public DataTable Query(string TransId, string SqlText, object[] Params)
        {
            this.EntitySet = EntityAdapter.Query(TransId, SqlText, Params);
            return EntitySet;
        }
        #endregion

        #region Insert
        private string sqlInsert = string.Empty;
        /// <summary>
        /// Insert SQL
        /// </summary>
        private string InsertSql
        {
            get
            {
                if (String.IsNullOrEmpty(sqlInsert))
                {
                    sqlInsert = GetInsertSql();
                }
                return sqlInsert;
            }
        }
        /// <summary>
        /// 获取Insert SQL
        /// </summary>
        /// <returns></returns>
        private string GetInsertSql()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append(this.TableName);
            sb.Append(" (");
            sbValue.Append(") VALUES (");
            //foreach (FieldAttribute fa in DictField[this.EntityName].Values)
            Dictionary<string, FieldAttribute> Fields = DictField[this.EntityName];
            int i = 1;
            foreach (FieldAttribute fa in Fields.Values)
            {
                if (fa.isQuery) continue;

                sb.Append(fa.Name);
                sb.Append(",");
                if (fa.DataType.ToString() == "System.DateTime")
                {
                    if (DBType == DatabaseType.Oracle)
                        sbValue.Append("To_Date(:" + i.ToString() + ",'YYYY-MM-DD HH24:MI:SS'),");
                    else if (DBType == DatabaseType.SqlServer)
                        sbValue.Append("@" + i.ToString() + ",");
                }
                else
                {
                    sbValue.Append(this.ParamToken);
                    sbValue.Append(i.ToString());
                    sbValue.Append(",");
                }
                i++;
            }
            sb.Remove(sb.Length - 1, 1);
            sbValue.Remove(sbValue.Length - 1, 1);
            sbValue.Append(")");
            return sb.ToString() + sbValue.ToString();
        }
        /// <summary>
        /// 获取Insert SQL 参数
        /// </summary>
        /// <param name="dtNew">新行表</param>
        /// <returns></returns>
        private List<object>[] GetInsertParams(DataTable dtNew)
        {
            Dictionary<string, List<object>> alParams = new Dictionary<string, List<object>>();

            Dictionary<string, FieldAttribute> Fields = DictField[this.EntityName];

            foreach (DataRow drNew in dtNew.Rows)
            {
                foreach (FieldAttribute fa in Fields.Values)
                {
                    if (fa.isQuery) continue;
                    if (!alParams.ContainsKey(fa.Name))
                    {
                        alParams.Add(fa.Name, new List<object>());
                    }
                    if (fa.DataType.ToString() == "System.DateTime")
                    {
                        if (drNew[fa.Name].ToString().Length == 0)
                        {
                            alParams[fa.Name].Add(DBNull.Value);
                        }
                        else
                        {
                            alParams[fa.Name].Add(((DateTime)drNew[fa.Name]).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    else
                    {
                        if (drNew[fa.Name].ToString().Length == 0)
                        {
                            alParams[fa.Name].Add(DBNull.Value);
                        }
                        else
                        {
                            alParams[fa.Name].Add(drNew[fa.Name]);
                        }
                    }
                }
            }
            List<List<object>> insertParams = new List<List<object>>();
            foreach (string key in alParams.Keys)
            {
                insertParams.Add(alParams[key]);
            }
            return insertParams.ToArray();
        }
        #endregion

        #region Delete
        /// <summary>
        /// 获取删除SQL
        /// </summary>
        /// <param name="drDelete">要删除的数据行</param>
        /// <param name="SqlText">删除脚本</param>
        /// <returns>ArrayList中除最后一项是SQL外，其余均为该SQL参数</returns>
        private List<object> GetDeleteSql(DataRow drDelete, ref string SqlText)
        {
            StringBuilder sb = new StringBuilder();
            List<object> alParams = new List<object>();

            sb.Append("DELETE ");
            sb.Append(this.TableName);
            sb.Append(" WHERE ");
            Dictionary<string, FieldAttribute> Fields = DictField[this.EntityName];
            int i = 1;
            foreach (FieldAttribute fa in Fields.Values)
            {
                if (fa.isQuery) continue;
                if (drDelete[fa.Name, System.Data.DataRowVersion.Original].ToString().Length == 0)
                {
                    //为空则填充Null
                    sb.Append(fa.Name);
                    sb.Append(" is null and ");
                }
                else if (fa.DataType.ToString() == "System.DateTime")
                {
                    string dateTime = ((DateTime)drDelete[fa.Name, System.Data.DataRowVersion.Original]).ToString("yyyy-MM-dd HH:mm:ss");
                    sb.Append(fa.Name);
                    if (DBType == DatabaseType.Oracle)
                        sb.Append("=To_Date(:" + i.ToString() + ",'YYYY-MM-DD HH24:MI:SS') and ");
                    else if (DBType == DatabaseType.SqlServer)
                        sb.Append("=@" + i.ToString()+" and ");
                    alParams.Add(dateTime);
                    i++;
                }
                else
                {
                    sb.Append(fa.Name);
                    sb.Append("="+this.ParamToken);
                    sb.Append(i.ToString());
                    sb.Append(" and ");
                    alParams.Add(drDelete[fa.Name, System.Data.DataRowVersion.Original]);
                    i++;
                }
            }
            SqlText = sb.ToString().Substring(0, sb.Length - 4);
            return alParams;
        }
        #endregion

        #region Update
        /// <summary>
        /// 获取更新SQL
        /// </summary>
        /// <param name="drUpdate">更新的数据行</param>
        /// <param name="SqlText">更新脚本</param>
        /// <returns>ArrayList中除最后一项是SQL外，其余均为该SQL参数</returns>
        private List<object> GetUpdataSql(DataRow drUpdate, ref string SqlText)
        {
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            List<object> alParams = new List<object>();
            List<object> alWhere = new List<object>();

            sbSql.Append("UPDATE ");
            sbSql.Append(this.TableName);
            sbSql.Append(" SET ");
            Dictionary<string, FieldAttribute> Fields = DictField[this.EntityName];
            int i = 1;
            foreach (FieldAttribute fa in Fields.Values)
            {
                if (fa.isQuery) continue;
                if (fa.isPrimaryKey) continue;//忽略主键字段

                if (drUpdate[fa.Name].ToString().Length == 0)
                {
                    //为空则填充Null
                    sbSql.Append(fa.Name);
                    sbSql.Append("=null,");
                    continue;
                }
                else if (fa.DataType.ToString() == "System.DateTime")
                {
                    sbSql.Append(fa.Name);
                    if (this.DBType == DatabaseType.Oracle)
                        sbSql.Append("=To_Date(:" + i.ToString() + ",'YYYY-MM-DD HH24:MI:SS'),");
                    else if (this.DBType == DatabaseType.SqlServer)
                        sbSql.Append("=@" + i.ToString() + ",");
                    alParams.Add(((DateTime)drUpdate[fa.Name]).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    sbSql.Append(fa.Name);
                    sbSql.Append("="+this.ParamToken);
                    sbSql.Append(i.ToString());
                    sbSql.Append(",");

                    alParams.Add(drUpdate[fa.Name]);
                }
                i++;
            }
            foreach (FieldAttribute fa in Fields.Values)
            {
                if (fa.isQuery) continue;

                if (drUpdate[fa.Name, System.Data.DataRowVersion.Original].ToString().Length == 0)
                {
                    //为空则填充Null
                    sbWhere.Append(fa.Name);
                    sbWhere.Append(" is null and ");
                    continue;
                }
                else if (fa.DataType.ToString() == "System.DateTime")
                {
                    sbWhere.Append(fa.Name);
                    if (this.DBType == DatabaseType.Oracle)
                        sbWhere.Append("=To_Date(:" + i.ToString() + ",'YYYY-MM-DD HH24:MI:SS') and ");
                    else if (this.DBType == DatabaseType.SqlServer)
                        sbWhere.Append("=@" + i.ToString() + " and ");

                    alWhere.Add(((DateTime)drUpdate[fa.Name, System.Data.DataRowVersion.Original]).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    sbWhere.Append(fa.Name);
                    sbWhere.Append("=" + this.ParamToken);
                    sbWhere.Append(i.ToString());
                    sbWhere.Append(" and ");

                    alWhere.Add(drUpdate[fa.Name, System.Data.DataRowVersion.Original]);
                }
                i++;
            }

            alParams.AddRange(alWhere);
            SqlText = sbSql.Remove(sbSql.Length - 1, 1) + " WHERE " + sbWhere.ToString().Substring(0, sbWhere.Length - 4);
            return alParams;
        }
        #endregion

        #region Validate
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="dt">待检查的数据表</param>
        private void Validate(DataTable dt)
        {
            NullCheck(dt);
            PrimaryCheck(dt);
        }
        /// <summary>
        /// 检查空值
        /// </summary>
        /// <param name="dt">待检查的数据表</param>
        private void NullCheck(DataTable dt)
        {
            Dictionary<string, FieldAttribute> Fields = DictField[this.EntityName];
            foreach (FieldAttribute fa in Fields.Values)
            {
                if (fa.isQuery) continue;
                if (fa.Nullable) continue;
                try
                {
                    dt.Columns[fa.Name].AllowDBNull = false;
                }
                catch
                {
                    throw new Exception("列【" + fa.Caption + "】不允许为空。");
                }
                finally
                {
                    dt.Columns[fa.Name].AllowDBNull = true;
                }
            }
        }
        /// <summary>
        /// 检查主键
        /// </summary>
        /// <param name="dt">待检查的数据表</param>
        private void PrimaryCheck(DataTable dt)
        {
            try
            {
                if (String.IsNullOrEmpty(PrimaryKey)) return;
                dt.PrimaryKey = new DataColumn[] { dt.Columns[PrimaryKey] };  //主键一个就行了
            }
            finally
            {
                dt.PrimaryKey = null;
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// 保存修改
        /// </summary>
        ///<returns>-1:不可修改或无更改，否则为更新影响的行数</returns>
        public int Save()
        {
            return Save("");
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="TransID">事务ID</param>
        ///<returns>-1:不可修改或无更改，否则为更新影响的行数</returns>
        public int Save(string TransID)
        {
            //如果具有只读属性，则不允许修改
            if (isReadOnly)
                throw new Exception(MSG_READONLY);
            DataTable dtChange = this.EntitySet.GetChanges();
            if (dtChange == null) return -1;

            Validate(dtChange);

            int ExeResult = 0;

            ExeResult += RunDelete(TransID);
            ExeResult += RunUpdate(TransID);
            ExeResult += RunInsert(TransID);

            if (TransID.Length == 0)
                Commit();

            return ExeResult;
        }

        /// <summary>
        /// 保存新行
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <returns>影响的行数</returns>
        private int RunInsert(string TransId)
        {
            DataTable dtInsert = this.EntitySet.GetChanges(System.Data.DataRowState.Added);
            if (dtInsert != null)
            {
                string SqlInsert = InsertSql;
                List<object>[] InsertParams = GetInsertParams(dtInsert);
                int Result = EntityAdapter.BatchExecute(TransId, InsertSql, InsertParams);
                return Result;
            }
            return 0;
        }
        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <returns>影响的行数</returns>
        private int RunDelete(string TransId)
        {
            DataTable dtDelete = this.EntitySet.GetChanges(System.Data.DataRowState.Deleted);
            if (dtDelete != null)
            {
                string SqlDelete = "";
                int Result = 0;
                foreach (DataRow drDelete in dtDelete.Rows)
                {
                    List<object> deleteParams = this.GetDeleteSql(drDelete, ref SqlDelete);

                    Result += EntityAdapter.Execute(TransId, SqlDelete, deleteParams);
                }

                if (Result != dtDelete.Rows.Count)
                {
                    throw new Exception(MSG_DELETE_FAIL);
                }
                return Result;
            }
            return 0;
        }
        /// <summary>
        /// 更新行
        /// </summary>
        /// <param name="TransId">事务ID</param>
        /// <returns>影响的行数</returns>
        private int RunUpdate(string TransId)
        {
            DataTable dtUpdate = this.EntitySet.GetChanges(System.Data.DataRowState.Modified);
            if (dtUpdate != null)
            {
                string SqlUpdate = "";
                int Result = 0;
                foreach (DataRow drUpdate in dtUpdate.Rows)
                {
                    List<object> updateParams = this.GetUpdataSql(drUpdate, ref SqlUpdate);

                    Result += EntityAdapter.Execute(TransId, SqlUpdate, updateParams);
                }

                if (Result != dtUpdate.Rows.Count)
                {
                    throw new Exception(MSG_UPDATE_FAIL);
                }
                return Result;
            }
            return 0;
        }
        /// <summary>
        /// 提交实体更改
        /// </summary>
        public void Commit()
        {
            this.EntitySet.AcceptChanges();
        }
        /// <summary>
        /// 放弃保存，撤销所有修改
        /// </summary>
        public void Cancel()
        {
            this.EntitySet.RejectChanges();
        }
        #endregion

        #region Dispose
        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            this._EntitySet.Clear();
            this._EntitySet.Dispose();
            this._EntitySet = null;
        }
        #endregion
    }
}
