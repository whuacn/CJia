using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class PrinterSet : CJia.Health.Tools.View
    {
        public PrinterSet()
        {
            InitializeComponent();
            InitPrinter();
        }
        private void InitPrinter()
        {
            List<string> localprintName = new List<string>();
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (!localprintName.Contains(printerName))
                {
                    cbPrintName.Properties.Items.Add(printerName);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string selectPrinter = cbPrintName.Text;
            if (selectPrinter.Length > 0)
            {
                Tools.ConfigHelper.UpdateAppStrings("Printer", selectPrinter);
                MessageBox.Show("条码打印机设置成功");
                this.ParentForm.Close();
            }
        }
    }
}
