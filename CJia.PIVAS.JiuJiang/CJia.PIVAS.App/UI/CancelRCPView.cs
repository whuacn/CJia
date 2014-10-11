//***************************************************
// 文件名（File Name）:      CancelRCPView.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.26
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CJia.PIVAS.Views;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 退药查询表示层
    /// </summary>
    public partial class CancelRCPView : Tools.View,Views.ICancelRCPView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public CancelRCPView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CancelRCPPresenter(this);
        }

        CancelRCPArgs cancelRCPArgs = new CancelRCPArgs();

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelRCPView_Load(object sender, EventArgs e)
        {
            this.txtDate.Text = this.Sysdate.ToString("yyyy - MM - dd");
        }


        /// <summary>
        /// 键盘触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelRCPView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.btnRefresh.Focus();
                btnRefresh_Click(null,null);
            }
            if (e.KeyCode == Keys.F8)
            {
                this.btnPrint.Focus();
                btnPrint_Click(null,null);
            }
        }

        /// <summary>
        /// 汇总药品Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllPharm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllPharm.CheckState == CheckState.Checked)
            {
                cbRefuseCancel.Enabled = false;
                cbRefuseCancel.CheckState = CheckState.Unchecked;
            }
            else
            {
                cbRefuseCancel.Enabled = true;
            }
        }

        /// <summary>
        /// 拒绝退药Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRefuseCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRefuseCancel.Checked)
            {
                cbAllPharm.Enabled = false;
                cbAllPharm.CheckState = CheckState.Unchecked;
            }
            else
            {
                cbAllPharm.Enabled = true;
            }
        }

        /// <summary>
        /// 选择左侧gridControl单号绑定相应单号瓶贴数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRCPId_Click(object sender, EventArgs e)
        {
            if (gridViewRCPId.FocusedRowHandle < 0)
            {
                return;
            }
            string selectedCancelRCPId = gridViewRCPId.GetFocusedDataRow()["CANCEL_RCP_ID"].ToString();
            cancelRCPArgs.queryDate = DateTime.Parse(this.txtDate.DateTime.ToShortDateString());
            // 汇总查询
            if (cancelRCPArgs.selectValue == "1")
            {
                cancelRCPArgs.selectedRCPId = selectedCancelRCPId;
            }
            else
            {
                cancelRCPArgs.selectedRCPId = " AND A.CANCEL_RCP_ID = " + selectedCancelRCPId;
            }
            OnSelecteRCPId(sender, cancelRCPArgs);
        }

        /// <summary>
        /// 刷新事件（即时间搜索）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.txtDate.Text == "")
            {
                return;
            }
            // 汇总查询
            if (cbAllPharm.Checked)
            {
                cancelRCPArgs.selectValue = "1";
                this.gridRCPDetail.MainView = gridViewTotalPharm;
            }
            // 拒绝查询
            else if (cbRefuseCancel.Checked)
            {
                cancelRCPArgs.selectValue = "2";
                this.gridRCPDetail.MainView = gridViewDetail;
            }
            // 退药查询
            else
            {
                cancelRCPArgs.selectValue = "";
                this.gridRCPDetail.MainView = gridViewDetail;
            }
            cancelRCPArgs.queryDate = DateTime.Parse(this.txtDate.DateTime.ToShortDateString());
            OnRefresh(sender, cancelRCPArgs);
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.txtDate.Text == "")
            {
                return;
            }
            cancelRCPArgs.queryDate = DateTime.Parse(this.txtDate.DateTime.ToShortDateString());
            OnPrint(sender,cancelRCPArgs);
        }

        /// <summary>
        /// 绑定退药单药品详细信息
        /// </summary>
        /// <param name="dtRCPDetail"></param>
        public void ExeBindGridRCPDetail(DataTable dtRCPDetail)
        {
            this.gridRCPDetail.DataSource = dtRCPDetail;
        }

        /// <summary>
        /// 绑定退药单号Id和退药时间
        /// </summary>
        /// <param name="dtRCPId"></param>
        public void ExeBindGridRCPId(DataTable dtRCPId)
        {
            this.gridRCPId.DataSource = dtRCPId;
        }

        /// <summary>
        /// 绑定汇总药品显示
        /// </summary>
        /// <param name="dtTotalCancelPharm"></param>
        public void ExeBindGridTotalCancelPharm(DataTable dtTotalCancelPharm)
        {
            this.gridRCPDetail.DataSource = dtTotalCancelPharm;
        }

        /// <summary>
        /// 打印退药单
        /// </summary>
        /// <param name="dtPrintPharm"></param>
        public void ExeBindPrintCancelPharm(DataTable dtPrintPharm)
        {
            RCPReportView pharmReport = new RCPReportView();
            pharmReport.DataBind(dtPrintPharm);
        }

        /// <summary>
        /// 刷新事件
        /// </summary>
        public event EventHandler<Views.CancelRCPArgs> OnRefresh;

        /// <summary>
        /// 打印事件
        /// </summary>
        public event EventHandler<Views.CancelRCPArgs> OnPrint;

        /// <summary>
        /// 选择左侧gridControl单号绑定相应单号瓶贴数据事件
        /// </summary>
        public event EventHandler<Views.CancelRCPArgs> OnSelecteRCPId;
    
      
    }
}
