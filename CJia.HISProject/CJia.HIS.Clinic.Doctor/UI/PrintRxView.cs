using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.HIS.Clinic.Pharm.UI
{
    public partial class PrintRxView : CJia.HIS.View,Views.IPrintRxView
    {
        public PrintRxView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PrintRxPresenter(this);
        }

    }
}
