using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.CheckRegOrder.App
{
    public partial class Clinic : Form
    {
        public Clinic()
        {
            InitializeComponent();
           // LoadClinicChooseView();
        }

        public Clinic(DataRow dataRow)
        {
            InitializeComponent();
            LoadClinicChooseView(dataRow);
        }

        public void LoadClinicChooseView(DataRow datarow)
        {
            UI.ClinicChooseView clinicChooseUI = new UI.ClinicChooseView(datarow);
            this.Controls.Add(clinicChooseUI);
            clinicChooseUI.Dock = DockStyle.Fill;
        }
    }
}
