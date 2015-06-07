using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using CJia._3LevelReview.App;

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
                SplashScreenManager.ShowForm(typeof(SplashScreenMain));
                UI.MyPatientInputView uc = new UI.MyPatientInputView();
                SplashScreenManager.CloseForm();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }

        private void btnNoPass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string pageTitle = (sender as DevExpress.XtraNavBar.NavBarItem).Caption;
            if (!cJiaTabControl1.isExistPage(pageTitle))
            {
                SplashScreenManager.ShowForm(typeof(SplashScreenMain));
                UI.MyUndoPatientView uc = new UI.MyUndoPatientView();
                SplashScreenManager.CloseForm();
                cJiaTabControl1.ShowPage(pageTitle, uc);
            }
        }
    }
}
