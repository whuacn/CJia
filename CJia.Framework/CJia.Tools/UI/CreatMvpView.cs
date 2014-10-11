using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace CJia.Tools.UI
{
    public partial class CreatMvpView : DevExpress.XtraEditors.XtraUserControl,Views.ICreateMvpView
    {
        public CreatMvpView()
        {
            InitializeComponent();
            this.CreatePresenter();
        }

        protected object CreatePresenter()
        {
            return new Presenters.CreateMvpPresenter(this);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Create(sender, e);
        }

        private void btnOpenDire_Click(object sender, EventArgs e)
        {
            fbdSelectDire.ShowDialog();
            this.txbProjectPath.Text = fbdSelectDire.SelectedPath;
        }

        private void txbProjectPath_TextChanged(object sender, EventArgs e)
        {
            this.txtProjectName.Text = Path.GetFileName(this.txbProjectPath.Text);
        }

        private void CreatMvpView_Load(object sender, EventArgs e)
        {
            this.txtUI.Text = ConfigHelper.GetAppStrings("UIFormWork");
            this.txtViews.Text = ConfigHelper.GetAppStrings("ViewsFormWork");
            this.txtPresenters.Text = ConfigHelper.GetAppStrings("PresentersFormWork");
            this.txtModels.Text = ConfigHelper.GetAppStrings("ModelsFormWork");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppStrings("UIFormWork", this.txtUI.Text);
            ConfigHelper.UpdateAppStrings("ViewsFormWork", this.txtViews.Text);
            ConfigHelper.UpdateAppStrings("PresentersFormWork", this.txtPresenters.Text);
            ConfigHelper.UpdateAppStrings("ModelsFormWork", this.txtModels.Text);
            MessageBox.Show("模板修改保存成功");
        }

        #region ICreateMvpView 成员
        public string UIName
        {
            get
            {
                return this.txbUIName.Text;
            }
        }

        public string ProjectPath
        {
            get
            {
                return this.txbProjectPath.Text;
            }
        }

        public string ProjectName
        {
            get
            {
                return this.txtProjectName.Text;
            }
        }

        public string UIFormWork
        {
            get
            {
                return this.txtUI.Text;
            }
        }
        
        public string ViewsFormWork
        {
            get
            {
                return this.txtViews.Text;
            }
        }

        public string PresentersFormWork
        {
            get
            {
                return this.txtPresenters.Text;
            }
        }

        public string ModelsFormWork
        {
            get
            {
                return this.txtModels.Text;
            }
        }


        public event EventHandler Create;

        public void ShowMessage(string mess)
        {
            MessageBox.Show(mess);
        }



        public bool ShowAwrn(string mess)
        {
            if(MessageBox.Show(mess, "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        #endregion


    }
}
