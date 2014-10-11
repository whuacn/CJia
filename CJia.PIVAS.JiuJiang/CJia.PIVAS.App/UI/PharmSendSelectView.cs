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
    public partial class PharmSendSelectView : Tools.View, Views.IPharmSendSelectView
    {
        public PharmSendSelectView()
        {
            InitializeComponent();
            datePharmSend.EditValue = this.Sysdate;
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PharmSendSelectPresenter(this);
        }
        /// <summary>
        /// 冲药查询参数
        /// </summary>
        Views.PharmSendSelectArgs pharmSendSelectArgs = new Views.PharmSendSelectArgs();

        #region IPharmSendSelectView成员
        //刷新事件
        public event EventHandler<Views.PharmSendSelectArgs> OnRefresh;
        //grid单击事件
        public event EventHandler<Views.PharmSendSelectArgs> OnGridClick;
        //打印事件
        public event EventHandler<Views.PharmSendSelectArgs> OnPrint;
        //绑定冲药单号
        public void ExeBindPharmSendNO(DataTable data)
        {
            gcPharmSendNO.DataSource = data;
            gvPharmSendNO.ExpandAllGroups();
        }
        //绑定冲药单信息
        public void ExeBindLabel(DataTable data1, DataTable data2)
        {
            gcLabel.DataSource = data1;
            gvlabel.ExpandAllGroups();
            gcLabelStat.DataSource = data2;
            gvLabelStat.ExpandAllGroups();
        }
        //打印冲药单明细报表
        public void ExeBindReport(DataTable data)
        {
            PharmSendDetailReport report = new PharmSendDetailReport();
            report.DataBind(data, this.Sysdate.ToString());
        }
        //打印冲药单统计报表
        public void ExeBindCollectReport(DataTable data)
        {
            PharmSendCollectReport report = new PharmSendCollectReport();
            report.DataBind(data, this.Sysdate.ToString());
        }
        #endregion

        #region 窗体事件
        //刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NewRefresh();
        }
        //grid单击
        private void gcPharmSendNO_Click(object sender, EventArgs e)
        {
            if (OnGridClick == null) return;
            if (gvPharmSendNO.GetFocusedDataRow() == null) return;
            if (gvPharmSendNO.FocusedRowHandle < 0) return;
            string pharmSendNO = gvPharmSendNO.GetFocusedDataRow()["PHARM_SEND_NO"].ToString();
            pharmSendSelectArgs.PharmSendNO = pharmSendNO;
            OnGridClick(sender, pharmSendSelectArgs);
        }
        //冲药时间改变
        private void datePharmSend_EditValueChanged(object sender, EventArgs e)
        {
            NewRefresh();
        }
        //checkBox改变
        private void ckDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (gcLabel.Visible == true) { gcLabel.Visible = false; gcLabelStat.Visible = true; return; }
            if (gcLabel.Visible == false) { gcLabel.Visible = true; gcLabelStat.Visible = false; }
        }
        //打印按钮
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (OnPrint == null) return;
            DateTime date = DateTime.Parse(datePharmSend.EditValue.ToString());
            bool isChecked = ckDetail.Checked;
            pharmSendSelectArgs.PharmSendTime = date;
            pharmSendSelectArgs.isChecked = isChecked;
            OnPrint(sender, pharmSendSelectArgs);
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 刷新某天的发药单号
        /// </summary>
        public void NewRefresh()
        {
            if (OnRefresh == null) return;
            if (datePharmSend.EditValue == null) return;
            DateTime date = DateTime.Parse(datePharmSend.EditValue.ToString());
            pharmSendSelectArgs.PharmSendTime = date;
            OnRefresh(null, pharmSendSelectArgs);
            gcLabel.DataSource = null;
            gcLabelStat.DataSource = null;
        }
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnRefresh.Focus();
                    NewRefresh();
                    return true;
                case Keys.F6:
                    btnPrint.Focus();
                    btnPrint_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
