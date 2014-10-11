using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJia.HISOLAP.App;
using System.IO;
using System.Data;

namespace CJia.HISOLAP.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("1");
            dt1.Columns.Add("02");
            dt1.Columns.Add("03");
            dt1.Columns.Add("04");
            dt1.Rows.Add("1", "2", "3", "4");
            DataTable dt2= new DataTable();
            dt2.Columns.Add("1");
            dt2.Columns.Add("2");
            dt2.Columns.Add("3");
            dt2.Columns.Add("4");
            dt2.Rows.Add("1", "2", "3", "4");
            DataTable dt3 = CJia.HISOLAP.App.Tools.DataTableHelper.MergeDataTable(dt1,"1",dt2,"1");
        }



        [TestMethod]
        public void TestMethod2()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("[1].[]");
            dt1.Columns.Add("2");
            dt1.Rows.Add("1", "1");
            dt1.Rows.Add("2", "2");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("[1].[]");
            dt2.Columns.Add("3");
            dt2.Rows.Add("6", "6");
            dt2.Rows.Add("4", "4");
            dt2.Rows.Add("3", "3");
            dt2.Rows.Add("5", "5");
            DataTable dt3 = CJia.HISOLAP.App.Tools.DataTableHelper.MergeDataTabelColSame(dt1,dt2);

            dt3 = CJia.HISOLAP.App.Tools.DataTableHelper.RowOrder(dt3, "[1].[]", new System.Collections.Generic.List<string>() { "1", "2", "3", "4", "5", "6" });
            dt3 = CJia.HISOLAP.App.Tools.DataTableHelper.MergeCol(dt3,new System.Collections.Generic.List<int>(){0,1 });
        }
    }
}
