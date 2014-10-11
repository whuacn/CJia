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
    public partial class MatchPharmView : CJia.HIS.View,Views.IMatchPharmView
    {
        public MatchPharmView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MatchPharmPresenter(this);
        }

        

    }
}
