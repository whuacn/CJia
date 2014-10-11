using System;
using CJia;
using CJia.ORM;
using System.Data;
namespace UnitTest.Framework
{
    [Table(Name = "TABLE_C", DBType = DatabaseType.SqlServer)]
    public class SqlTestDataEntity : DataEntity<SqlTestDataEntity>
    {
        /// <summary>
        /// SQL测试实体
        /// </summary>
        public SqlTestDataEntity() : base() { }
        public SqlTestDataEntity(DataRow drData) : base(drData) { }
        public SqlTestDataEntity(DataRow[] drcData) : base(drcData) { }
        public SqlTestDataEntity(DataAdapter adapter) : base(adapter) { }
        public SqlTestDataEntity(DataAdapter adapter, DataRow drData) : base(adapter, drData) { }
        public SqlTestDataEntity(DataAdapter adapter, DataRow[] drcData) : base(adapter, drcData) { }
        /// <summary>
        /// 字段A（Int32）
        /// </summary>
        [Field(Name = "A", Caption = "字段A", DataType = typeof(Int32))]
        public string AFild
        {
            get { return Get("A"); }
            set { Set("A", value); }
        }
        /// <summary>
        /// 字段B
        /// </summary>
        [CJia.ORM.Field(Name = "B", Caption = "字段B", DataType = typeof(Decimal))]
        public string BFild
        {
            get { return Get("B"); }
            set { Set("B", value); }
        }
        /// <summary>
        /// 字段C（DateTime）
        /// </summary>
        [CJia.ORM.Field(Name = "C", Caption = "字段C", DataType = typeof(DateTime))]
        public string CFild
        {
            get { return Get("C"); }
            set { Set("C", value); }
        }
        /// <summary>
        /// 字段D
        /// </summary>
        [CJia.ORM.Field(Name = "D", Caption = "字段D")]
        public string DFild
        {
            get { return Get("D"); }
            set { Set("D", value); }
        }
    }
}
