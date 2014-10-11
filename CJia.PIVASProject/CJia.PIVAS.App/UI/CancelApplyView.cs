//***************************************************
// 文件名（File Name）:      CancelApplyView.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.17
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
    /// 退药处理表示层
    /// </summary>
    public partial class CancelApplyView : Tools.View,Views.ICancelApplyView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public CancelApplyView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CancelApplyPresenter(this);
        }

        CancelApplyArgs cancelApplyArgs = new CancelApplyArgs();

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelApplyView_Load(object sender, EventArgs e)
        {
            PharmState();
            OfficeState();
            this.txtStartDate.Text = this.Sysdate.ToString("yyyy-MM-dd");
            this.txtEndDate.Text = this.Sysdate.AddDays(1).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 页面加载时冲药选择状态
        /// </summary>
        private void PharmState()
        {
            for (int i = 0; i < cbPharmState.Items.Count; i++)
            {
                this.cbPharmState.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
            }
        }

        /// <summary>
        /// 页面加载时病区选择状态
        /// </summary>
        private void OfficeState()
        {
            cbAllOffice.CheckState = CheckState.Checked;
            for (int i = 0; i < cbOfficeName.Items.Count; i++)
            {
                this.cbOfficeName.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
            }
        }

        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllOffice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllOffice.Checked)
            {
                for (int i = 0; i < cbOfficeName.Items.Count; i++)
                {
                    this.cbOfficeName.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
                }
            }
            else
            {
                for (int i = 0; i < cbOfficeName.Items.Count; i++)
                {
                    this.cbOfficeName.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        /// <summary>
        /// 退药申请列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string value = "";
            string Index = this.gridViewCancelApply.GetFocusedDataRow()["GROUP_INDEX"].ToString();
            value = this.gridViewCancelApply.GetFocusedDataRow()["isChecked"].ToString();
            DataTable dt = gridCancelApply.DataSource as DataTable;
            DataRow[] drs = dt.Select("GROUP_INDEX = " + Index);
            foreach (DataRow dr in drs)
            {
                if (value == "" || value == "False")
                {
                    dr["isChecked"] = true;
                }
                else
                {
                    dr["isChecked"] = false;
                }
            }
            this.gridCancelApply.RefreshDataSource();
        }


        /// <summary>
        /// 获取去重后界面所勾选瓶贴所属组号
        /// </summary>
        void GetDistinCheckedGroupIndex()
        {
            string group = "";
            DataTable dt = gridCancelApply.DataSource as DataTable;
            if (dt == null)
            {
                return;
            }
            DataRow[] drs = dt.Select("isChecked = " + true);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in drs)
            {
                if (sb.ToString().Contains(dr["GROUP_INDEX"].ToString()))
                {
                    dr.Delete();    //移除该行
                }
                else
                {
                    sb.Append(dr["GROUP_INDEX"].ToString());
                }
            }
            for (int i = 0; i < drs.Length; i++)
            {
                if (drs[i].RowState != DataRowState.Deleted)
                {
                    group += drs[i]["GROUP_INDEX"].ToString() + ",";
                }
            }
            if (group == "")
            {
                return;
            }
            //  截取最后一个逗号
            cancelApplyArgs.group_index = group.Remove(group.LastIndexOf(","), 1);
            
        }

        /// <summary>
        /// 确定退药事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOkCancel_Click(object sender, EventArgs e)
        {
            GetDistinCheckedGroupIndex();
            if (cancelApplyArgs.group_index == "")
            {
                return;
            }
            //  确认退药时如果选择打印退药单
            if (this.cbPrintRcp.Checked)
            {
                cancelApplyArgs.isPrint = true;
            }
            OnOkCancel(sender, cancelApplyArgs);
            btnCancelPreview_Click(null, null);
            cancelApplyArgs.group_index = "";
        }

        /// <summary>
        /// 拒绝退药事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuseApply_Click(object sender, EventArgs e)
        {
            GetDistinCheckedGroupIndex();
            if (cancelApplyArgs.group_index == "")
            {
                return;
            }
            OnRefuseApply(sender, cancelApplyArgs);
            btnCancelPreview_Click(null,null);
            cancelApplyArgs.group_index = "";
        }

        /// <summary>
        /// 预览退药事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelPreview_Click(object sender, EventArgs e)
        {
            string checkedPharmState = "";         // 所选冲药状态Id
            string checkedOfficeId = "";        // 所选病区Id
            //  是否选择冲药状态
            for (int i = 0; i < cbPharmState.Items.Count; i++)
            {
                if(this.cbPharmState.Items[i].CheckState == CheckState.Checked)
                {
                    checkedPharmState += "'"+this.cbPharmState.Items[i].Value+"'"+ ",";
                }
            }
            //  去除最后一个逗号
            checkedPharmState = checkedPharmState.Remove(checkedPharmState.LastIndexOf(","), 1);
            //  是否选择病区
            for(int j = 0; j < cbOfficeName.Items.Count; j++)
            {
                if(this.cbOfficeName.Items[j].CheckState == CheckState.Checked)
                {
                    checkedOfficeId += this.cbOfficeName.Items[j].Value + ",";
                }
            }
            checkedOfficeId = checkedOfficeId.Remove(checkedOfficeId.LastIndexOf(","), 1);
            if (this.txtStartDate.Text != "" && this.txtEndDate.Text != "" && checkedPharmState != "" && checkedOfficeId != "")
            {
                //cancelApplyArgs.queryStr = " AND B.PHARM_TIME BETWEEN to_date('" + this.txtStartDate.DateTime.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') AND to_date('" + this.txtEndDate.DateTime.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') AND B.EXE_STATUS IN(" + checkedPharmState + ") AND B.ILLFIELD_ID IN (" + checkedOfficeId + ") ORDER BY PHARM_TIME";
                cancelApplyArgs.queryDate = "BETWEEN to_date('" + this.txtStartDate.DateTime.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') AND to_date('" + this.txtEndDate.DateTime.AddDays(1).ToString("yyyy/MM/dd") + "','yyyy/mm/dd')";
                cancelApplyArgs.queryExeStatus = "(" + checkedPharmState + ")";
                cancelApplyArgs.queryIllFieldId = "(" + checkedOfficeId + ")";
                OnCancelPreview(sender,cancelApplyArgs);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 绑定申请退药列表
        /// </summary>
        /// <param name="dtCancelApply"></param>
        public void ExeBindGridCancelApply(DataTable dtCancelApply)
        {
            gridCancelApply.DataSource = dtCancelApply;
        }

        /// <summary>
        /// 绑定病区
        /// </summary>
        public void ExeBindOfficeName(DataTable dtOfficeName)
        {
            for(int i = 0; i<dtOfficeName.Rows.Count;i++)
            {
                this.cbOfficeName.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
                new DevExpress.XtraEditors.Controls.CheckedListBoxItem(dtOfficeName.Rows[i]["office_id"], dtOfficeName.Rows[i]["office_name"].ToString())});
            }
        }

        /// <summary>
        /// 绑定打印所勾选药品
        /// </summary>
        /// <param name="dtCheckedPharm"></param>
        public void ExeBindPrintApplyCancelPharm(DataTable dtCheckedPharm)
        {
            RCPReportView pharmReport = new RCPReportView();
            pharmReport.DataBind(dtCheckedPharm);
        }


        /// <summary>
        /// 确定退药事件
        /// </summary>
        public event EventHandler<Views.CancelApplyArgs> OnOkCancel;

        /// <summary>
        /// 拒绝退药事件
        /// </summary>
        public event EventHandler<Views.CancelApplyArgs> OnRefuseApply;

        /// <summary>
        /// 预览退药事件，即查询
        /// </summary>
        public event EventHandler<Views.CancelApplyArgs> OnCancelPreview;

    }
}
