using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class MyPatientHandelView : DevExpress.XtraEditors.XtraUserControl
    {
        public MyPatientHandelView()
        {
            InitializeComponent();
        }

        private void btnCommit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyPatientInputView uc = new UI.MyPatientInputView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnNoPass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                UI.MyUndoPatientView uc = new UI.MyUndoPatientView();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }
    }
}
