
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
    public partial class NewCancelRCPView : Tools.View, Views.INewCancelRCPView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public NewCancelRCPView()
        {
            InitializeComponent();
            Load(null, null);
            DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
            this.dtStart.DateTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            this.dtEnd.DateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.NewCancelRCPPresenter(this);
        }

        NewCancelRCPEventArgs newCancelRCPEventArgs = new NewCancelRCPEventArgs();

        #region INewCancelRCPView成员
        //初次加载
        public event EventHandler Load;
        // 刷新事件
        public event EventHandler<NewCancelRCPEventArgs> OnRefresh;
        // 打印事件
        public event EventHandler<NewCancelRCPEventArgs> OnPrint;
        // 绑定退药药品详细信息
        public void ExeBindRCPDetail(DataTable dtRCPDetail)
        {
            gcCancel.MainView = gvCancel;
            gcCancel.DataSource = dtRCPDetail;
            this.repositoryItemLookUpEdit1.DataSource = dtRCPDetail;
            gvCancel.ExpandAllGroups();
        }
        // 绑定病区
        public void ExeBindIllfield(DataTable data)
        {
            DataRow dr = data.NewRow();
            dr["OFFICE_NAME"] = "< 全部 >";
            dr["OFFICE_ID"] = 0;
            data.Rows.InsertAt(dr, 0);
            this.cbIffield.DataSource = data;
            this.cbIffield.DisplayMember = "OFFICE_NAME";
            this.cbIffield.ValueMember = "OFFICE_ID";
        }
        // 绑定汇总药品
        public void ExeBindTotalCancelPharm(DataTable dtTotalCancelPharm)
        {
            gcCancel.MainView = gvStatPharm;
            gcCancel.DataSource = dtTotalCancelPharm;
        }
        // 打印退药汇总单
        public void ExePrintCancelPharm(DataTable dtPrintPharm)
        {
            if (dtPrintPharm != null && dtPrintPharm.Rows.Count > 0)
            {
                dtPrintPharm.DefaultView.Sort = " PHARM_NAME";
                dtPrintPharm = dtPrintPharm.DefaultView.ToTable();
            }
            string retreatStatus = string.Empty;
            if(this.rbSucceed.Checked)
            {
                retreatStatus = "Succeed";
            }
            else if(this.rbTurnDown.Checked)
            {
                retreatStatus = "TumDown";
            }
            else
            {
                retreatStatus = "No";
            }
            string dateStyle = "";
            if(this.rbPrintDate.Checked)
            {
                dateStyle = "Print";
            }
            else
            {
                dateStyle = "Check";
            }
            CancelPharmReport report = new CancelPharmReport();
            report.DataBind(dateStyle, dtPrintPharm, cbIffield.Text, Sysdate.ToString(), dtStart.DateTime.ToShortDateString(), dtEnd.DateTime.ToShortDateString(), retreatStatus);
        }
        public void ExePrintCancelPharmDetail(DataTable data)
        {
            string retreatStatus = string.Empty;
            if(this.rbSucceed.Checked)
            {
                retreatStatus = "Succeed";
            }
            else if(this.rbTurnDown.Checked)
            {
                retreatStatus = "TumDown";
            }
            else
            {
                retreatStatus = "No";
            }

            string dateStyle = "";
            if(this.rbPrintDate.Checked)
            {
                dateStyle = "Print";
            }
            else
            {
                dateStyle = "Check";
            }
            CancelPharmDetailReport report = new CancelPharmDetailReport();
            report.DataBind(dateStyle, data, cbIffield.Text, Sysdate.ToString(), dtStart.DateTime.ToShortDateString(), dtEnd.DateTime.ToShortDateString(), retreatStatus);
        }
        // 绑定拒绝退药药品详情
        public void ExeBindRefuseRCPDetail(DataTable data)
        {
            gcCancel.MainView = gvCancel;
            gcCancel.DataSource = data;
            this.repositoryItemLookUpEdit1.DataSource = data;
            gvCancel.ExpandAllGroups();
        }
        // 绑定拒绝退药汇总药品
        public void ExeBindRefuseTotalCancelPharm(DataTable data)
        {
            gcCancel.MainView = gvStatPharm;
            gcCancel.DataSource = data;
        }
        #endregion

        #region 界面事件
        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(OnRefresh != null)
            {
                newCancelRCPEventArgs.StartDate = dtStart.DateTime;
                newCancelRCPEventArgs.EndDate = dtEnd.DateTime;
                newCancelRCPEventArgs.IllfieldID = cbIffield.SelectedValue.ToString();
                newCancelRCPEventArgs.IsAllPharm = ckAllPharm.Checked;
                if(this.rbSucceed.Checked)
                {
                    newCancelRCPEventArgs.retreatStatus = "Succeed";
                }
                else if(this.rbTurnDown.Checked)
                {
                    newCancelRCPEventArgs.retreatStatus = "TumDown";
                }
                else
                {
                    newCancelRCPEventArgs.retreatStatus = "No";
                }

                if(this.rbPrintDate.Checked)
                {
                    newCancelRCPEventArgs.dateStyle = "Print";
                }
                else
                {
                    newCancelRCPEventArgs.dateStyle = "Check";
                }
                OnRefresh(sender, newCancelRCPEventArgs);
            }
        }
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(OnPrint != null)
            {
                newCancelRCPEventArgs.StartDate = dtStart.DateTime;
                newCancelRCPEventArgs.EndDate = dtEnd.DateTime;
                newCancelRCPEventArgs.IllfieldID = cbIffield.SelectedValue.ToString();
                newCancelRCPEventArgs.IsAllPharm = ckAllPharm.Checked;
                if(this.rbSucceed.Checked)
                {
                    newCancelRCPEventArgs.retreatStatus = "Succeed";
                }
                else if(this.rbTurnDown.Checked)
                {
                    newCancelRCPEventArgs.retreatStatus = "TumDown";
                }
                else
                {
                    newCancelRCPEventArgs.retreatStatus = "No";
                }
                if(this.rbPrintDate.Checked)
                {
                    newCancelRCPEventArgs.dateStyle = "Print";
                }
                else
                {
                    newCancelRCPEventArgs.dateStyle = "Check";
                }
                OnRefresh(sender, newCancelRCPEventArgs);
                OnPrint(null, newCancelRCPEventArgs);
            }
        }
        #endregion


    }
}
