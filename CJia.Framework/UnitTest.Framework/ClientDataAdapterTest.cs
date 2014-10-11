using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJia.Net.Data;
using CJia.Net.Service;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace UnitTest.Framework
{
    /// <summary>
    /// ClientDataAdapterTest
    /// </summary>
    [TestClass]
    public class ClientDataAdapterTest
    {
        CJia.Net.IServerApplication serverApp;
        CJia.Net.Business.DataAdapter dataAdapter;
        string ServerIP = "127.0.0.1";
        //string ServerIP = "192.168.1.205";
        //string ServerIP = "192.168.1.207";
        int Port = 10920;

        /// <summary>
        /// 初始化测试参数
        /// </summary>
        [TestInitialize()]
        public void InitTest()
        {
            //CJia.Net.CJiaEndPoint netEP = new CJia.Net.CJiaEndPoint(Port);
            //serverApp = CJia.Net.CJiaServerBuilder.CreateServerApplication(netEP);
            //CJia.Net.Data.DBConfig.Load();
            //dataAdapter = new CJia.Net.Business.DataAdapter();
            //serverApp.AddService<CJia.Net.Service.IDataAdapter, CJia.Net.Business.DataAdapter>(dataAdapter);
            //serverApp.Start();

            CJia.ClientConfig.ServerPort = Port;
            CJia.ClientConfig.ServerIP = ServerIP;
            CJia.ClientConfig.SystemNo = "CJiaJJPIVASSystem";
            CJia.ClientConfig.ClientNo = "CJiaJJPIVASClient";
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
        public void QueryScalar_检查数据库时间与本地时间_一致()
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string dbDate = CJia.DefaultSQL.QueryScalar("Select * From gm_code");
            Assert.AreEqual(strDate, dbDate, "数据库时间与本地时间不一致");
        }
        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void QueryScalar_检查是否根据参数数组返回指定值_一致()
        {
            string UserCode = "10000";
            object[] SqlParams = new object[] { UserCode };
            string dbUserCode = CJia.DefaultData.QueryScalar("Select Code From Web_User t Where t.Code = :1 And t.Status = 1", SqlParams);
            Assert.AreEqual(UserCode, dbUserCode, "未找到指定数据");
        }
        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void QueryScalar_检查是否根据参数列表返回指定值_一致()
        {
            string UserCode = "10000";
            List<object> listParams = new List<object>();
            listParams.Add(UserCode);
            string dbUserCode = CJia.DefaultData.QueryScalar("Select Code From Web_User t Where t.Code = :1 And t.Status = 1", listParams);
            Assert.AreEqual(UserCode, dbUserCode, "未找到指定数据");
        }
        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void Query_检查是否返回数据表_有数据()
        {
            DataTable dtResult = CJia.DefaultData.Query("Select * From WEB_USER2");
            Assert.IsNotNull(dtResult, "未查询到数据");
        }
        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void Query_检查根据参数数组查询_返回指定数据()
        {
            string UserCode = "10000";
            string dbUserCode = "";
            object[] SqlParams = new object[] { UserCode };
            DataTable dtResult = CJia.DefaultData.Query("Select * From Web_User t Where t.Code = :1 And t.Status = 1", SqlParams);
            if(dtResult != null && dtResult.Rows.Count > 0)
            {
                dbUserCode = dtResult.Rows[0]["CODE"].ToString();
            }
            Assert.AreEqual(UserCode, dbUserCode, "未找到指定数据");
        }
        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void Query_检查根据参数列表查询_返回指定数据()
        {
            string UserCode = "10000";
            string dbUserCode = "";
            List<object> listParams = new List<object>();
            listParams.Add(UserCode);
            DataTable dtResult = CJia.DefaultData.Query("Select * From Web_User t Where t.Code = :1 And t.Status = 1", listParams);
            if(dtResult != null && dtResult.Rows.Count > 0)
            {
                dbUserCode = dtResult.Rows[0]["CODE"].ToString();
            }
            Assert.AreEqual(UserCode, dbUserCode, "未找到指定数据");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Insert_插入一条数据_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b,c) values (2,'cc',to_date('2012-12-01','YYYY-MM-DD'))";
            int Result = CJia.DefaultData.Execute(SqlInsert);
            Assert.AreEqual(1, Result, "插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Insert_根据参数数值插入一条数据_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b,c) values (:1,:2,to_date(:3,'YYYY-MM-DD'))";
            object[] sqlParams = new object[] { 1, "bb", "2012-10-01" };
            int Result = CJia.DefaultData.Execute(SqlInsert, sqlParams);
            Assert.AreEqual(1, Result, "插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入一条数据1个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a) values (:1)";
            List<object> listParams1 = new List<object>();
            listParams1.Add(44);
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1);
            Assert.AreEqual(1, Result, "批量插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入多条数据1个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a) values (:1)";
            List<object> listParams1 = new List<object>();
            listParams1.Add(44);
            listParams1.Add(55);
            listParams1.Add(66);
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1);
            Assert.AreEqual(listParams1.Count, Result, "批量插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入一条数据2个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b) values (:1,:2)";
            List<object> listParams1 = new List<object>();
            listParams1.Add(55);
            List<object> listParams2 = new List<object>();
            listParams2.Add("YYY");
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1, listParams2);
            Assert.AreEqual(1, Result, "批量插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入多条数据2个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b) values (:1,:2)";
            List<object> listParams1 = new List<object>();
            listParams1.Add(555);
            listParams1.Add(666);
            listParams1.Add(777);
            List<object> listParams2 = new List<object>();
            listParams2.Add("YYY");
            listParams2.Add("ZZZ");
            listParams2.Add("XXX");
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1, listParams2);
            Assert.AreEqual(listParams1.Count, Result, "批量插入失败");
        }

        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入一条数据3个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b,c) values (:1,:2,to_date(:3,'YYYY-MM-DD'))";
            List<object> listParams1 = new List<object>();
            listParams1.Add(55);
            List<object> listParams2 = new List<object>();
            listParams2.Add("YYY");
            List<object> listParams3 = new List<object>();
            listParams3.Add("2000-12-01");
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1, listParams2, listParams3);
            Assert.AreEqual(1, Result, "批量插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入多条数据3个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b,c) values (:1,:2,to_date(:3,'YYYY-MM-DD'))";
            List<object> listParams1 = new List<object>();
            listParams1.Add(555);
            listParams1.Add(666);
            listParams1.Add(777);
            List<object> listParams2 = new List<object>();
            listParams2.Add("YYY");
            listParams2.Add("ZZZ");
            listParams2.Add("XXX");
            List<object> listParams3 = new List<object>();
            listParams3.Add("2000-12-01");
            listParams3.Add("2001-12-01");
            listParams3.Add("2002-12-01");
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, listParams1, listParams2, listParams3);
            Assert.AreEqual(listParams1.Count, Result, "批量插入失败");
        }

        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void BatchInsert_批量插入N条数据N个参数_返回正确影响行()
        {
            string SqlInsert = @"insert into temp_test (a,b,c) values (:1,:2,to_date(:3,'YYYY-MM-DD'))";
            List<object> listParams1 = new List<object>();
            listParams1.Add(555);
            listParams1.Add(666);
            listParams1.Add(777);
            List<object> listParams2 = new List<object>();
            listParams2.Add("YYY");
            listParams2.Add("ZZZ");
            listParams2.Add("XXX");
            List<object> listParams3 = new List<object>();
            listParams3.Add("2000-12-01");
            listParams3.Add("2001-12-01");
            listParams3.Add("2002-12-01");
            List<object>[] sqlParams = new List<object>[] { listParams1, listParams2, listParams3 };
            int Result = CJia.DefaultData.BatchExecute(SqlInsert, sqlParams);
            Assert.AreEqual(listParams1.Count, Result, "批量插入失败");
        }

        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void Transaction_检查事务是否有效_有效()
        {
            using(CJia.Transaction trans = new CJia.Transaction())
            {
                string SqlDelete = @"delete from temp_test where a = 10000";
                CJia.DefaultData.Execute(trans.ID, SqlDelete);
                string SqlInsert = @"insert into temp_test (a,b,c) values (10000,'cc',to_date('2012-12-01','YYYY-MM-DD'))";
                int Result = CJia.DefaultData.Execute(trans.ID, SqlInsert);
                string SqlQuery = @"select count(1) from temp_test where a = 10000";
                string count = CJia.DefaultData.QueryScalar(trans.ID, SqlQuery);
                Assert.AreEqual("1", count, "事务无效");
                trans.Complete();
            }
        }

        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void Transaction_检查事务回滚是否有效_有效()
        {
            string SqlCount = @"select count(1) from temp_test";
            string count_2 = "";
            string count_1 = CJia.DefaultData.QueryScalar(SqlCount);
            using(CJia.Transaction trans = new CJia.Transaction())
            {

                string SqlInsert = @"insert into temp_test (a,b,c) values (10000,'cc',to_date('2012-12-01','YYYY-MM-DD'))";
                int Result = CJia.DefaultData.Execute(trans.ID, SqlInsert);
                count_2 = CJia.DefaultData.QueryScalar(trans.ID, SqlCount);
                //不调用Complete即自动回滚
                //trans.Complete();
            }
            string count_3 = CJia.DefaultData.QueryScalar(SqlCount);
            Assert.AreEqual(count_3, count_1, "事务未回滚。");
            Assert.AreEqual(count_2, (Convert.ToInt32(count_1) + 1).ToString(), "未进行事务操作。");

        }

        /// <summary>
        /// 测试查询第一行第一列
        /// </summary>
        [TestMethod]
        public void Transaction_检查事务提交是否有效_有效()
        {
            string SqlCount = @"select count(1) from temp_test";
            string count_2 = "";
            string count_1 = CJia.DefaultData.QueryScalar(SqlCount);
            using(CJia.Transaction trans = new CJia.Transaction())
            {

                string SqlInsert = @"insert into temp_test (a,b,c) values (10000,'cc',to_date('2012-12-01','YYYY-MM-DD'))";
                int Result = CJia.DefaultData.Execute(trans.ID, SqlInsert);
                count_2 = CJia.DefaultData.QueryScalar(trans.ID, SqlCount);
                //调用Complete后将自动提交事务
                trans.Complete();
            }
            string count_3 = CJia.DefaultData.QueryScalar(SqlCount);
            Assert.AreEqual(count_3, count_2, "事务未提交。");
            Assert.AreEqual(count_2, (Convert.ToInt32(count_1) + 1).ToString(), "未进行事务操作。");
        }

        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Sql数据库查询()
        {
            string SqlQuery = @"select * from Table_A";
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            DataTable Result = sqlAdapter.Query(SqlQuery);
            Assert.IsNotNull(Result, "查询失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Sql数据库插入数据_仅字符串()
        {
            string SqlInsert = @"insert into Table_A (colA,colB,colC,colD,colE) values (@1,@2,@3,@4,@5)";
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            object[] SqlParams = new object[] { "11", "22", "aa", "bb", "**" };
            int Result = sqlAdapter.Execute(SqlInsert, SqlParams);
            Assert.AreEqual(1, Result, "插入失败");
        }

        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Sql数据库插入数据_数字日期()
        {
            string SqlInsert = @"insert into Table_C (A,B,C,D) values (@1,@2,@3,@4)";
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            object[] SqlParams = new object[] { 11, 22.225, "2012-12-22 12:32:56", "bb" };
            int Result = sqlAdapter.Execute(SqlInsert, SqlParams);
            Assert.AreEqual(1, Result, "插入失败");
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Sql数据库插入数据_数字日期_空值()
        {
            string SqlInsert = @"insert into Table_C (A,B,C,D) values (@1,@2,@3,@4)";
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            object[] SqlParams = new object[] { DBNull.Value, DBNull.Value, DBNull.Value, "gg" };
            int Result = 0;
            string exMsg = "";
            try
            {
                Result = sqlAdapter.Execute(SqlInsert, SqlParams);
            }
            catch(Exception ex)
            {
                exMsg = ex.Message;
            }
            Assert.AreEqual(1, Result, exMsg);
        }
        /// <summary>
        /// 测试数据插入
        /// </summary>
        [TestMethod]
        public void Sql数据库插入数据_数字日期_批量插入()
        {
            string SqlInsert = @"insert into Table_C (A) values (@1)";
            CJia.DataAdapter sqlAdapter = new CJia.DataAdapter(CJia.DbConfigName.SqlDB.ToString());
            List<object> listParams = new List<object>();
            listParams.Add(22);
            listParams.Add(33);
            listParams.Add(44);
            int Result = sqlAdapter.BatchExecute(SqlInsert, listParams);
            Assert.AreEqual(3, Result, "批量插入失败");
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        [TestMethod]
        public void 执行存储过程_存储过程_正确执行()
        {
            CJia.DefaultData.Query("select 1 from dual");
            Dictionary<string, object> Paras = new Dictionary<string, object>();
            Paras.Add("v_id", 123456);
            Paras.Add("v_value", null);
            CJia.DefaultData.ExecuteProcedure("get_gaolu", ref Paras);
            Assert.AreEqual("gaolue", Paras["v_value"].ToString());
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        [TestMethod]
        public void postgre数据库访问()
        {
            for(int i = 0; i < 5; i++)
            {
                ThreadStart ts = new ThreadStart(thread);
                Thread tr = new Thread(ts);
                tr.Start();
            }
        }

        [TestMethod]
        public void postgred数据库访问()
        {
            for(int i = 10; i < 100; i++)
            {
                using(CJia.Transaction tran = new CJia.Transaction())
                {
                    for(int j = i * 1000; j < (i + 1) * 1000; j++)
                    {
                        string sql = string.Format(@"insert into gm_user (user_id,user_no,user_name,user_pwd)
values ({0},'{0}','{0}','{0}')", j);
                        CJia.DefaultPostgre.Execute(tran.ID,sql);
                    }
                    tran.Complete();
                }
            }
        }
        [TestMethod]
        public void thread()
        {
            CJia.DefaultPostgre.Query("select * from gm_user");
        }

        [TestMethod]
        public void postgrdded数据库访问()
        {
           DataTable d =  CJia.DefaultPostgre.Query("select * from gm_user");
           int i = 0;
        }
        [TestMethod]
        public void QueryProcedure_执行返回数据集的存储过程()
        {
           DataTable dt = CJia.DefaultPostgre.QueryProcedure("function1");
           int i = 0;
        }
        [TestMethod]
        public void QueryProcedure_执行返回数据集的存储过程_oracle()
        {
            Dictionary<string,object> Params = new Dictionary<string,object>();
            Params.Add("I_CODE", 1000000102);
            DataTable dt = CJia.DefaultData.QueryProcedure("PR_GM_CODE", Params);
            int i = 0;
        }

        [TestMethod]
        public void QueryPaging_执行返回数据集的存储过程_postgre()
        {
            int padingId = CJia.DefaultPostgre.QueryPaging("select * from gm_user");
            CJia.DataAdapter dataAdapter = new CJia.DataAdapter("Postgre");
            DataTable result = dataAdapter.QueryPagingData(padingId, 1000);
        }
        [TestMethod]
        public void QueryPaging_执行d返回数据集的存储过程_postgre()
        {
            Dictionary<string,object> param = new Dictionary<string,object>();
            param.Add("I_A","撒的发生的");
            param.Add("I_B","DSFD");
            param.Add("O_C","");
            CJia.DefaultOleDb.ExecuteProcedure("A", ref param);

            string SA = param["O_C"].ToString();
        }
    }
}
