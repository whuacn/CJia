using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Framework
{
    [TestClass]
    public class EntityTest
    {
        CJia.Net.IServerApplication serverApp;
        CJia.Net.Business.DataAdapter dataAdapter;
        string ServerIP = "192.168.13.124";//"127.0.0.1";//
        int Port = 10920;

        /// <summary>
        /// 初始化测试参数
        /// </summary>
        [TestInitialize()]
        public void InitTest()
        {
            //CJia.Net.Data.DBConfig.Load();
            //CJia.Net.CJiaEndPoint netEP = new CJia.Net.CJiaEndPoint(Port);
            //serverApp = CJia.Net.CJiaServerBuilder.CreateServerApplication(netEP);
            //dataAdapter = new CJia.Net.Business.DataAdapter();
            //dataAdapter.LoadDatabaseConfig();
            //serverApp.AddService<CJia.Net.Service.IDataAdapter, CJia.Net.Business.DataAdapter>(dataAdapter);
            //serverApp.Start();

            CJia.ClientConfig.ServerPort = Port;
            CJia.ClientConfig.ServerIP = ServerIP;
        }
        /// <summary>
        /// 结束测试
        /// </summary>
        [TestCleanup()]
        public void EndTest()
        {
            //serverApp.Stop();
        }
        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void MobileMedical_获取用户登录信息_一致()
        {
            object i = 1000000000;
            int  x = Convert.ToInt32(i);
            CJia.Net.Business.MobileMedical.Doctor doctor = new CJia.Net.Business.MobileMedical.Doctor();
            byte[] result = doctor.Login("U0001", "8888", "");
            //CJia.Net.Business.Data.DataObject dataObject = new CJia.Net.Business.Data.DataObject();
            //dataObject.Deserialize(result);
            List<Data.User> userList = Data.DataObject.Deserialize<Data.User>(result);

            //int fieldCount = userList.Count;
            int rowCount = userList.Count;
            //Assert.AreEqual(6, fieldCount, "字段数不一致");
            Assert.AreEqual(1, rowCount, "记录数不一致");
        }
        [TestMethod]
        public void TestNewEntity_测试实体删除_添加_查询_保存()
        {
            TestDataEntity de = new TestDataEntity();
            de.Fill();
            for (int i = 0; i < de.Count; i++)
            {
                de[i].Delete();
            }
            int result = de.Save();

            de.Add();
            de.AFild = "1";
            de.BFild = "AA";
            //de.CFild = "2012-10-11";
            de.DFild = "WW";
            de.Add();
            de.AFild = "2";
            de.BFild = "BB";
            de.CFild = "2012-10-12";
            de.DFild = "QQ";
            de.Add();
            de.AFild = "3";
            de.BFild = "CC";
            de.CFild = "2012-10-13";
            de.DFild = "EE";
            DataRow dr = de.EntitySet.NewRow();
            dr["A"] = "4";
            dr["B"] = "DD";
            dr["C"] = "2012-10-13";
            dr["D"] = "FF";
            de.Add(dr);
            using (CJia.Transaction trans = new CJia.Transaction())
            {
                result = de.Save(trans.ID);
                string count = CJia.DefaultData.QueryScalar(trans.ID, "select count(1) from TEST_TABLE");
                Assert.AreEqual("4", count, "实体事务保存失败");
                //trans.Complete();
                //de.Commit();
            }
            Assert.AreEqual(4, result, "实体保存失败");
            string count2 = CJia.DefaultData.QueryScalar("select count(1) from TEST_TABLE");
            Assert.AreEqual("0", count2, "实体事务回滚保存失败");
        }

        [TestMethod]
        public void TestDynamicEntity_测试根据SQL动态创建实体()
        {
            using (CJia.DynamicEntity de = new CJia.DynamicEntity("select * from TEST_TABLE"))
            {
                dynamic result = de.DataEntity;
                int i = result.Count;
                string AValue = result.A;
                Assert.AreEqual(true, de.DataEntity.isReadOnly);
                //result.Save();
            }
        }
        [TestMethod]
        public void TestDynamicTableEntity_测试根据表名动态创建实体()
        {
            using (CJia.DynamicEntity de = new CJia.DynamicEntity("TEST_TABLE", "", null))
            {
                dynamic result = de.DataEntity;
                int i = result.Count;

                string entityName = result.EntityName;
                string AValue = result.A;
                Assert.AreNotEqual(0, AValue.Length);
                result.B = "12345";
                int count = result.Save();
                Assert.AreEqual(false, de.DataEntity.isReadOnly);
                Assert.AreEqual(1, count);
            }
        }
        [TestMethod]
        public void Test_动态生成升级程序()
        {
            string csCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace CJia.Updater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
             System.IO.File.WriteAllText(@""D:\Log.txt"", ""OK"");
        }
    }
}
";
            string exeFileName = @"D:\CJia.Updater.exe";

            bool success = CJia.Compiler.BuildApp(csCode, exeFileName);
            if (success)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = exeFileName;
                p.Start();
                p.Close();
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SQL数据库_测试实体删除_添加_查询_保存()
        {
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            SqlTestDataEntity de = new SqlTestDataEntity(sqlAdapter);
            de.Fill();
            for (int i = 0; i < de.Count; i++)
            {
                de[i].Delete();
            }
            int result = de.Save();

            de.Add();
            de.AFild = "1";
            //de.BFild = "11.22";
            de.CFild = "2012-10-11";
            de.DFild = "WW";
            de.Add();
            de.AFild = "2";
            de.BFild = "33.44";
            //de.CFild = "";
            de.DFild = "QQ";
            de.Add();
            de.AFild = "3";
            de.BFild = "44.55";
            de.CFild = "2012-10-13";
            de.DFild = "";
            result = de.Save();
            Assert.AreEqual(3, result, "实体保存失败");
        }

        [TestMethod]
        public void SQL数据库_TestDynamicTableEntity_测试根据表名动态创建实体()
        {
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            using (CJia.DynamicEntity de = new CJia.DynamicEntity(CJia.ORM.DatabaseType.SqlServer, sqlAdapter, "TABLE_W", "", null))
            {
                dynamic result = de.DataEntity;
                int i = result.Count;

                string entityName = result.EntityName;
                string AValue = result.A;
                Assert.AreNotEqual(0, AValue.Length);
                result.B = "12345";
                result.EntityAdapter = sqlAdapter;
                int count = result.Save();
                Assert.AreEqual(false, de.DataEntity.isReadOnly);
                Assert.AreEqual(1, count);
            }
        }
    }
}
