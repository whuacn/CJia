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
    public partial class StorageQueryView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.IStorageQueryView
    {
        public StorageQueryView()
        {
            InitializeComponent();
            this.gridView1.IndicatorWidth = 40;
        }

        //重写创建P层的方法
        protected override object CreatePresenter()
        {
            return new Presenters.StorageQueryPresenter(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }


        #region

        public event EventHandler<Views.StorageQueryArgs> OnStorageQuery;

        public void ExeDataBind(DataTable dt)
        {
            StorageGrid.DataSource = dt;
        }
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnRefresh.Focus();
                    this.btnRefresh_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void btnPrintStorage_Click(object sender, EventArgs e)
        {
            DataTable dtStroage = (DataTable)StorageGrid.DataSource;
            DateTime nowTime = CJia.PIVAS.Tools.Helper.Sysdate;
            string DrugName = TxtDrugName.Text;
            string BatchNo = TxtDrugNo.Text ;
            string DrugFirm = TxtDrugFirm.Text;
            CJia.PIVAS.App.UI.StorageReport storageReport = new StorageReport();
            storageReport.DataBind(dtStroage, nowTime,DrugName,BatchNo,DrugFirm);
            
        }

        private void ceFilterZero_CheckedChanged(object sender, EventArgs e)
        {
            this.refresh();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void refresh()
        {
            string drugName = TxtDrugName.Text;
            string drugSpec = txtSpec.Text;
            string drugNo = TxtDrugNo.Text;
            string drugFirm = TxtDrugFirm.Text;
            bool filterZero = this.ceFilterZero.Checked;
            Views.StorageQueryArgs stroageQueryArgs = new Views.StorageQueryArgs();
            stroageQueryArgs.DrugName = drugName;
            stroageQueryArgs.DrugSpec = drugSpec;
            stroageQueryArgs.DrugNo = drugNo;
            stroageQueryArgs.DrugFirm = drugFirm;
            stroageQueryArgs.FilterZero = filterZero;
            this.OnStorageQuery(null, stroageQueryArgs);
        }

        private void TxtDrugName_EditValueChanged(object sender, EventArgs e)
        {
            this.refresh();
        }
        
    }
}
