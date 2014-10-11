using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppTest.iSmartMedical
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        CJia.Net.Business.MobileMedical.SyncHis2Mid sync = null;
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            sync = new CJia.Net.Business.MobileMedical.SyncHis2Mid();
            sync.Start();
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            if (sync != null) sync.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sync != null) sync.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (string ListenID in CJia.Net.Data.DefaultOracle.DictListen.Keys)
            {
                boxLog.AppendText(ListenID + ":");
                boxLog.AppendText(CJia.Net.Data.DefaultOracle.DictListen[ListenID]);
                this.boxLog.AppendText(System.Environment.NewLine);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CJia.Net.Data.DBConfig.Load();
        }
    }
}
