using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI
{
    public partial class PharmSendStatSelectView : CJia.PIVAS.Tools.View, Views.IPharmSendStatSelectView
    {
        public PharmSendStatSelectView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PharmSendStatSelectPresenter(this);
        }
        /// <summary>
        /// 发药统计参数
        /// </summary>
        Views.PharmSendStatSelectArgs pharmSendStatSelectArgs = new Views.PharmSendStatSelectArgs();

        #region IPharmSendStatSelectView成员
        //初始化事件
        public event EventHandler Load;
        //统计打印事件
        public event EventHandler<Views.PharmSendStatSelectArgs> OnStatPrint;
        //绑定病区与批次
        public void ExeInit(DataTable data1, DataTable data2)
        {
            dateStart.EditValue = DateTime.Parse(this.Sysdate.ToShortDateString() + " 00:00:00");
            dateEnd.EditValue = this.Sysdate;
            glIllFieldName.Properties.DataSource = data1;
            glIllFieldName.Properties.DisplayMember = "OFFICE_NAME";
            glIllFieldName.Properties.ValueMember = "OFFICE_ID";
            InitGridLookUpEdit(glIllFieldName);
            glBatch.Properties.DataSource = data2;
            glBatch.Properties.DisplayMember = "BATCH_NAME";
            glBatch.Properties.ValueMember = "BATCH_ID";
            InitGridLookUpEdit(glBatch);
        }
        //打印统计报表
        public void ExeBindReport(DataTable data)
        {
            PharmSendStatReport report = new PharmSendStatReport();
            string officeName = "";
            string batchName = "";
            if (gvIllfieldName.GetFocusedDataRow() != null && !ckOffice.Checked)
                officeName = gvIllfieldName.GetFocusedDataRow()["OFFICE_NAME"].ToString();
            if (gvBatchName.GetFocusedDataRow() != null && !ckbatch.Checked)
                batchName = gvBatchName.GetFocusedDataRow()["BATCH_NAME"].ToString();
            report.DataBind(data, officeName, batchName, dateStart.EditValue.ToString(), dateEnd.EditValue.ToString(), this.Sysdate.ToString());
        }
        #endregion

        #region 窗体事件
        //checkEdit改变事件
        private void ckOffice_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOffice.Checked == true) { glIllFieldName.Enabled = false; }
            if (ckOffice.Checked == false) { glIllFieldName.Enabled = true; }
        }
        //checkEdit改变事件
        private void ckbatch_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbatch.Checked == true) { glBatch.Enabled = false; }
            if (ckbatch.Checked == false) { glBatch.Enabled = true; }
        }
        //打印事件
        private void btnStat_Click(object sender, EventArgs e)
        {
            pharmSendStatSelectArgs.Start = DateTime.Parse(dateStart.EditValue.ToString());
            pharmSendStatSelectArgs.End = DateTime.Parse(dateEnd.EditValue.ToString());
            if (!ckOffice.Checked && gvIllfieldName.GetFocusedDataRow() != null)
                pharmSendStatSelectArgs.OfficeID = gvIllfieldName.GetFocusedDataRow()["OFFICE_ID"].ToString();
            else pharmSendStatSelectArgs.OfficeID = "";
            if (!ckbatch.Checked && gvBatchName.GetFocusedDataRow() != null)
                pharmSendStatSelectArgs.BatchID = int.Parse(gvBatchName.GetFocusedDataRow()["BATCH_ID"].ToString());
            else pharmSendStatSelectArgs.BatchID = 0;
            OnStatPrint(sender, pharmSendStatSelectArgs);
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 初始化GridLookUpEdit
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public void InitGridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            gridLookUpEdit.Properties.View.BestFitColumns();                                                   //glIllFieldName.Properties.View.OptionsView.ShowAutoFilterRow = true; 
            gridLookUpEdit.Properties.ShowFooter = false;                                                      //显示不显示grid上第一个空行,也是用于检索的应用(上面的注释)
            gridLookUpEdit.Properties.ImmediatePopup = true;
            gridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.
        }
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnStat.Focus();
                    btnStat_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
