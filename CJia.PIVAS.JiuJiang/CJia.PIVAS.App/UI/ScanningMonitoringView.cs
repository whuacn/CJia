using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class ScanningMonitoringView : UserControl
    {
        int count = 14;
        public ScanningMonitoringView()
        {
            InitializeComponent();
            this.add();
            this.init();
        }

        private void add()
        {
            for(int i = 1; i <= count; i++)
            {
                CJia.PIVAS.App.UI.OneScanningMonitoringView oneScanningMonitoringView = new OneScanningMonitoringView(i.ToString());
                oneScanningMonitoringView.Name = "oneScanningMonitoringView" + i;
                this.Controls.Add(oneScanningMonitoringView);
            }

        }

        private void init()
        {
            int height = this.Size.Height;
            int width = this.Size.Width;

            int oneHeight = height / 2;
            int oneWidth = width / 7;

            for(int i = 1; i <= 14; i++)
            {
                CJia.PIVAS.App.UI.OneScanningMonitoringView oneScanningMonitoringView = this.Controls.Find("oneScanningMonitoringView" + i, false)[0] as CJia.PIVAS.App.UI.OneScanningMonitoringView;
                oneScanningMonitoringView.Height = oneHeight;
                oneScanningMonitoringView.Width = oneWidth;
                oneScanningMonitoringView.Location = new Point(oneWidth * ((i - 1) % (count / 2)), oneHeight * ((i - 1) / (count / 2)));
            }

        }

        public void sendScanningMes(string no, string labelBarId)
        {
            Control[] controls = this.Controls.Find("oneScanningMonitoringView" + no, false);
            if(controls != null && controls.Length > 0)
            {
                CJia.PIVAS.App.UI.OneScanningMonitoringView oneScanningMonitoringView = controls[0] as CJia.PIVAS.App.UI.OneScanningMonitoringView;
                oneScanningMonitoringView.Scanning(labelBarId);
            }
            else
            {

            }
        }

        private void ScanningMonitoringView_SizeChanged(object sender, EventArgs e)
        {
            this.init();
        }
    }
}
