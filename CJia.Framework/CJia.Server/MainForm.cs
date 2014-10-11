using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJia.Net;
using CJia.Net.Service;
using CJia.Net.Data;
using CJia.Net.Communication.Messages;
using System.Security.Cryptography;
using System.IO;
using CJia.Net.Service.MobileMedical;
using CJia.Net.Business.MobileMedical;

namespace CJia.Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This object is used to host Chat Service on a SCS server.
        /// </summary>
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

        void server_ClientConnected(object sender, Net.Server.ServerClientEventArgs e)
        {
            e.Client.MessageReceived += Client_MessageReceived;
            this.Invoke(new Action(() => ShowConnection()));
        }

        void Client_MessageReceived(object sender, Net.Communication.Messages.MessageEventArgs e)
        {
            CJiaRemoteInvokeMessage oMsg = (CJiaRemoteInvokeMessage)e.Message;
            string msg = oMsg.ServiceClassName + " " + oMsg.MethodName;
            this.Invoke(new Action(() => ShowMsg(msg)));

        }

        void ShowConnection()
        {
            this.boxLog.AppendText("连接成功。");
            this.boxLog.AppendText(System.Environment.NewLine);
        }

        void ShowMsg(string msg)
        {
            this.boxLog.AppendText(msg);
            this.boxLog.AppendText(System.Environment.NewLine);
        }

        void StartServer()
        {
            //Create a Scs Service application that runs on 10048 TCP port.
            serverApp = CJiaServerBuilder.CreateServerApplication(new CJiaEndPoint(10920));
            oraAdapter = new Net.Business.DataAdapter();

            Doctor doctor = new Doctor();
            serverApp.AddService<IDoctor, Doctor>(doctor);
            serverApp.AddService<CJia.Net.Service.IDataAdapter, Net.Business.DataAdapter>(oraAdapter);
            //Start server
            serverApp.ClientConnected += serverApp_ClientConnected;
            serverApp.ClientDisconnected += serverApp_ClientDisconnected;
            serverApp.Start();

            this.Text = "服务器已启动";
        }

        void serverApp_ClientDisconnected(object sender, ServiceClientEventArgs e)
        {
            this.Invoke(new Action(() => DisConnection()));
        }
        void DisConnection()
        {
            this.boxLog.AppendText("连接断开。");
            this.boxLog.AppendText(System.Environment.NewLine);
        }
        void serverApp_ClientConnected(object sender, ServiceClientEventArgs e)
        {
            this.Invoke(new Action(() => ShowConnection()));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message.ShowWarning("本程序为静脉药物配置中心系统提供数据访问服务！关闭本程序将使静脉药物配置中心系统无法正常运行！");
            e.Cancel = true;

            //try
            //{
            //    if(serverApp != null)
            //        serverApp.Stop();
            //    if(server != null)
            //        server.Stop();
            //    CJia.Net.Data.DefaultOracle.StopListen();
            //}
            //catch
            //{
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            this.InitGrdListenTable(appStrings);

            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();

            //CJia.Message.Show(Int16.MaxValue.ToString());
        }

        private Dictionary<string, Dictionary<string, DBConnection>> ConvertDBConfig(Dictionary<string, string> appStrings)
        {
            Dictionary<string, Dictionary<string, DBConnection>> dicDBConfig = new Dictionary<string, Dictionary<string, DBConnection>>();
            foreach(string key in appStrings.Keys)
            {
                string strSystemNO = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBName = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                string strDBType = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBConection = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                bool isExist = false;
                foreach(string DBConfigKey in dicDBConfig.Keys)
                {
                    if(DBConfigKey == strSystemNO)
                    {
                        isExist = true;
                    }
                }
                if(isExist)
                {
                    dicDBConfig[strSystemNO].Add(strDBName, new DBConnection(strDBType, strDBConection));
                }
                else
                {
                    Dictionary<string,DBConnection> dicDBConnection = new Dictionary<string,DBConnection>();
                    dicDBConnection.Add(strDBName,new DBConnection(strDBType,strDBConection));
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
            foreach(string key in appStrings.Keys)
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

        private void InitGrdListenTable(Dictionary<string, string> appStrings)
        {
            this.grdListenTable.DataSource = this.ConvertDataTable(appStrings);
        }

        private void btnAddSystemNO_Click(object sender, EventArgs e)
        {
            AddSystemNO addSystemNO = new AddSystemNO();
            addSystemNO.ShowDialog();
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            this.InitGrdListenTable(appStrings);
            if(serverApp != null)
                serverApp.Stop();
            if(server != null)
                server.Stop();
            CJia.Net.Data.DefaultOracle.StopListen();
            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();
        }

        private void btnAddDBName_Click(object sender, EventArgs e)
        {
            AddDBName addDBName = new AddDBName();
            addDBName.ShowDialog();
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            this.InitGrdListenTable(appStrings);
            if(serverApp != null)
                serverApp.Stop();
            if(server != null)
                server.Stop();
            CJia.Net.Data.DefaultOracle.StopListen();
            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();
        }


        private void btnDeleteSystemNO_Click(object sender, EventArgs e)
        {
            DeleteSystemNO deleteSystemNO = new DeleteSystemNO();
            deleteSystemNO.ShowDialog();
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            this.InitGrdListenTable(appStrings);
            if(serverApp != null)
                serverApp.Stop();
            if(server != null)
                server.Stop();
            CJia.Net.Data.DefaultOracle.StopListen();
            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();
        }

        private void btnDeleteDBName_Click(object sender, EventArgs e)
        {
            DeleteDBName deleteDBName = new DeleteDBName();
            deleteDBName.ShowDialog();
            Dictionary<string, string> appStrings = CJia.Server.ConfigHelper.GetAllAppStrings();
            this.InitGrdListenTable(appStrings);
            if(serverApp != null)
                serverApp.Stop();
            if(server != null)
                server.Stop();
            CJia.Net.Data.DefaultOracle.StopListen();
            CJia.Net.Data.DBConfig.Load(this.ConvertDBConfig(appStrings));
            //StartCustomServer();
            StartServer();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StartCustomServer();
        }


        /// <summary>
        /// use sha1 to encrypt string
        /// </summary>
        public string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //this.boxLog.AppendText(SHA1_Encrypt("cN809201"));
        }
        CJia.Net.Business.MobileMedical.SyncHis2Mid sync = null;
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            //CJia.Net.Data.DefaultOracle.StartListen("Select * From cj_sync_data");
            //CJia.Net.Data.DefaultOracle.StartListen("Select * From V_GM_PATIENT");
            sync = new Net.Business.MobileMedical.SyncHis2Mid();
            sync.Start();
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            //CJia.Net.Data.DefaultOracle.StopListen();
            //sync.Dispose();
            sync.Stop();
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

        private void 同步病人到中间库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步病人？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitMidPatientFromHiS();
            CJia.Message.Show(Result);
        }

        private void 同步医嘱到中间库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步医嘱？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitMidPatientAdviceFromHiS();
            CJia.Message.Show(Result);
        }

        private void 同步EMR病人IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步病人ID？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitEMRPatientID();
            CJia.Message.Show(Result);
        }

        private void 同步LIS结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步LIS结果？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitLisResult();
            CJia.Message.Show(Result);
        }

        private void 同步费用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步病人费用？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitPatientFee();
            CJia.Message.Show(Result);
        }

        private void 同步检查结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CJia.Message.ShowQuery("确定要同步检查结果？") == Message.Result.Cancel) return;
            CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new SyncHis2Mid();
            string Result = sync.InitCheckResult();
            CJia.Message.Show(Result);
        }
    }
}
