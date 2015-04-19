using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.PIVAS.Presenters;

namespace CJia.PIVAS.App.UI
{
    public partial class PharmEconomizeUI : Tools.View, Views.IPharmEconomizeVw
    {
        PharmEconomizeUIP _Presenter;
        DataTable _dtDept = null;
        DataTable _dtPharm = null;
        DataTable _dtWaitingImport = null;
        DataTable _dtImportRecord = null;
        CJia.PIVAS.App.UI.PharmFilterView pharmFilterView = new PharmFilterView();
        public PharmEconomizeUI()
        {
            InitializeComponent();
            _Presenter = new PharmEconomizeUIP(this);
            Initial();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PharmEconomizeUIP(this);
        }

        void Initial()
        {
            this.Dock = DockStyle.Fill;
             _Presenter.GetDetpData();
            
            cbIffield.DataSource = _dtDept;
            this.cbIffield.DisplayMember = "OFFICE_NAME";
            this.cbIffield.ValueMember = "OFFICE_ID";
            _Presenter.GetPharmData();
            //for (int i = 0; i < _dtPharm.Rows.Count; i++)
            //{
            //    ckcePharm.Properties.Items.Add(_dtPharm.Rows[i]["office_id"].ToString(), _dtPharm.Rows[i]["office_name"].ToString(), CheckState.Checked, true);
            //}
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _Presenter.PharmEconomizeQuery();
            gcPharm.DataSource = _dtWaitingImport;
            gcAddPharm.DataSource = _dtImportRecord;
        }
       
        #region 接口实现
        DateTime Views.IPharmEconomizeVw.BeginDate
        {
            get { return dtpStartTime.Value; }
        }

        DateTime Views.IPharmEconomizeVw.EndDate
        {
            get { return dtpEndTime.Value; }
        }

        DataTable Views.IPharmEconomizeVw.DtDept
        {
            set { _dtDept = value; }
        }

        DataTable Views.IPharmEconomizeVw.DtPharm
        {
            set { _dtPharm = value; }
        }

        DataTable Views.IPharmEconomizeVw.DtWaitingImport
        {
            set { _dtWaitingImport = value; }
        }

        DataTable Views.IPharmEconomizeVw.DtImportRecord
        {
            set { _dtImportRecord = value; }
        }

        DataTable Views.IPharmEconomizeVw.FilterPharm
        {
            get {
                //string selectPharm = "";
                //foreach (string illList in ckcePharm.Properties.Items.GetCheckedValues())
                //{
                //    selectPharm += "'" + illList + "',";
                //}
                //if (selectPharm != "")
                //{
                //    return selectPharm.Substring(0, selectPharm.Length - 1);
                //}
                //return "";
                return pharmFilterView.selectPharm;
            }
        }

        string Views.IPharmEconomizeVw.FilterDept
        {
            get { return cbIffield.SelectedValue.ToString(); }
        }

        DateTime Tools.IView.Sysdate
        {
            get { throw new NotImplementedException(); }
        }

        event EventHandler Tools.IView.Load
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void Tools.IView.ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        void Tools.IView.ShowWarning(string message)
        {
            throw new NotImplementedException();
        }

        void Tools.IView.CloseWindow()
        {
            throw new NotImplementedException();
        }

        void Tools.IView.ShowAsWindow(string Caption)
        {
            throw new NotImplementedException();
        }

        void Tools.IView.ShowAsWindow(string Caption, UserControl UControl)
        {
            throw new NotImplementedException();
        }


        #endregion

        private void btnFilterPharm_Click(object sender, EventArgs e)
        {
            _Presenter.GetPharmData();
            pharmFilterView.BindData(_dtPharm, cbIffield.SelectedValue.ToString());
            this.ShowAsWindow(this.cbIffield.Text + " 药品筛选", pharmFilterView);
        }
    }
}
