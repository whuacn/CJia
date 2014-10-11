using System;
using CJia;
using CJia.ORM;
namespace UnitTest.Framework
{
    [Table(Name = "TEST_TABLE")]
    public class TestDataEntity : DataEntity<TestDataEntity>
    {
        /// <summary>
        /// 字段A（Int32）
        /// </summary>
        [Field(Name = "A", Caption = "字段A", DataType = typeof(Int32), isPrimaryKey = true)]
        public string AFild
        {
            get { return Get("A"); }
            set { Set("A", value); }
        }
        /// <summary>
        /// 字段B
        /// </summary>
        [CJia.ORM.Field(Name = "B", Caption = "字段B")]
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
        [CJia.ORM.Field(Name = "D", Caption = "字段D", Nullable = false)]
        public string DFild
        {
            get { return Get("D"); }
            set { Set("D", value); }
        }
    }
}
