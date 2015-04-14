using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.Net;
using CJia.Net.Service;
using CJia.Net.Data;
using CJia.Net.Communication.Messages;
using System.Security.Cryptography;
using System.IO;

namespace CJia.Server.Service
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            //InitGrdListenTable(appStrings);
            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();
            Console.WriteLine("服务器已启动 ");
        }

        protected override void OnStop()
        {

        }

        public void Start(string[] args)
        {
            OnStart(args);
        }

        public void Stop()
        {
            OnStop();
        }


        private IServerApplication serverApp;
        private CJia.Net.Business.DataAdapter oraAdapter;

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        CJia.Net.Server.IServer server;
        void StartCustomServer()
        {
            server = CJia.Net.Server.ServerFactory.CreateServer(new CJiaEndPoint(10920));
            server.WireProtocolFactory = new CJia.Net.Communication.Protocols.BinarySerialization.BinarySerializationProtocolFactory(); // new CJia.Net.Communication.Protocols.CustomProtocol.TextProtocolFactory();
            server.ClientConnected += server_ClientConnected;
            server.Start();
        }

        void server_ClientConnected(object sender, CJia.Net.Server.ServerClientEventArgs e)
        {
            e.Client.MessageReceived += Client_MessageReceived;
            //this.Invoke(new Action(() => ShowConnection()));
            ShowConnection();
        }

        void Client_MessageReceived(object sender, CJia.Net.Communication.Messages.MessageEventArgs e)
        {
            CJiaRemoteInvokeMessage oMsg = (CJiaRemoteInvokeMessage)e.Message;
            string msg = oMsg.ServiceClassName + " " + oMsg.MethodName;
            //this.Invoke(new Action(() => ShowMsg(msg)));
            ShowMsg(msg);

        }

        void ShowConnection()
        {
            Console.WriteLine("连接成功。");
            Console.WriteLine(System.Environment.NewLine);
        }

        void ShowMsg(string msg)
        {
             Console.WriteLine(msg);
             Console.WriteLine(System.Environment.NewLine);
        }

        void StartServer()
        {
            //Create a Scs Service application that runs on 10048 TCP port.
            serverApp = CJiaServerBuilder.CreateServerApplication(new CJiaEndPoint(10920));
            oraAdapter = new CJia.Net.Business.DataAdapter();

            //Doctor doctor = new Doctor();
            //serverApp.AddService<IDoctor, Doctor>(doctor);
            serverApp.AddService<CJia.Net.Service.IDataAdapter, CJia.Net.Business.DataAdapter>(oraAdapter);
            //Start server
            serverApp.ClientConnected += serverApp_ClientConnected;
            serverApp.ClientDisconnected += serverApp_ClientDisconnected;
            serverApp.Start();

            //this.Text = "服务器已启动";
        }

        void serverApp_ClientDisconnected(object sender, ServiceClientEventArgs e)
        {
            //this.Invoke(new Action(() => DisConnection()));
            DisConnection();
        }
        void DisConnection()
        {
            Console.WriteLine("连接断开。");
            Console.WriteLine(System.Environment.NewLine);
            //this.boxLog.AppendText("连接断开。");
            //this.boxLog.AppendText(System.Environment.NewLine);
        }
        void serverApp_ClientConnected(object sender, ServiceClientEventArgs e)
        {
            //this.Invoke(new Action(() => ShowConnection()));
            ShowConnection();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
          

            //CJia.Message.Show(Int16.MaxValue.ToString());
        }

        private Dictionary<string, Dictionary<string, DBConnection>> ConvertDBConfig(Dictionary<string, string> appStrings)
        {
            Dictionary<string, Dictionary<string, DBConnection>> dicDBConfig = new Dictionary<string, Dictionary<string, DBConnection>>();
            foreach (string key in appStrings.Keys)
            {
                string strSystemNO = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBName = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                string strDBType = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBConection = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                bool isExist = false;
                foreach (string DBConfigKey in dicDBConfig.Keys)
                {
                    if (DBConfigKey == strSystemNO)
                    {
                        isExist = true;
                    }
                }
                if (isExist)
                {
                    dicDBConfig[strSystemNO].Add(strDBName, new DBConnection(strDBType, strDBConection));
                }
                else
                {
                    Dictionary<string, DBConnection> dicDBConnection = new Dictionary<string, DBConnection>();
                    dicDBConnection.Add(strDBName, new DBConnection(strDBType, strDBConection));
                    dicDBConfig.Add(strSystemNO, dicDBConnection);
                }
            }
            return dicDBConfig;
        }

        private DataTable ConvertDataTable(Dictionary<string, string> appStrings)
        {
            DataTable appStringsTable = new DataTable();
            DataColumn systemNO = new DataColumn("SystemNO");
            DataColumn dbName = new DataColumn("DBName");
            DataColumn dbType = new DataColumn("DBType");
            DataColumn dbConection = new DataColumn("DBConection");
            appStringsTable.Columns.Add(systemNO);
            appStringsTable.Columns.Add(dbName);
            appStringsTable.Columns.Add(dbType);
            appStringsTable.Columns.Add(dbConection);
            foreach (string key in appStrings.Keys)
            {
                string strSystemNO = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBName = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                string strDBType = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBConection = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                DataRow newRow = appStringsTable.NewRow();
                newRow["SystemNO"] = strSystemNO;
                newRow["DBName"] = strDBName;
                newRow["DBType"] = strDBType;
                newRow["DBConection"] = strDBConection;
                appStringsTable.Rows.Add(newRow);
            }
            return appStringsTable;
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            //foreach (string ListenID in CJia.Net.Data.DefaultOracle.DictListen.Keys)
            //{
            //    boxLog.AppendText(ListenID + ":");
            //    boxLog.AppendText(CJia.Net.Data.DefaultOracle.DictListen[ListenID]);
            //    this.boxLog.AppendText(System.Environment.NewLine);
            //}
        }

    }
}
