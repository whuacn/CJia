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
    /// 退药申请表示层
    /// </summary>
    public partial class CancelLabelView : Tools.View, Views.ICancelLabelView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public CancelLabelView()
        {
            InitializeComponent();
            Init();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CancelLabelPresenter(this);
        }

        CancelLabeEventArgs cancelLabeEventArgs = new CancelLabeEventArgs();

        #region ICancelLabelView 成员
        //绑定病区事件
        public event EventHandler<CancelLabeEventArgs> OnInitIffield;
        //查询
        public event EventHandler<CancelLabeEventArgs> OnSelect;
        //查询
        public event EventHandler<CancelLabeEventArgs> OnSelectByNO;
        //提交申请
        public event EventHandler<CancelLabeEventArgs> OnBtnOK;
        //刷新
        public event EventHandler<CancelLabeEventArgs> OnBtnRefresh;
        //绑定病区
        public void ExeBindAllIffield(DataTable data, DataTable piciData)
        {
            DataRow dr = data.NewRow();
            dr["OFFICE_NAME"] = "< 全部 >";
            dr["OFFICE_ID"] = 0;
            data.Rows.InsertAt(dr, 0);
            this.cbIffield.DataSource = data;
            this.cbIffield.DisplayMember = "OFFICE_NAME";
            this.cbIffield.ValueMember = "OFFICE_ID";
            this.cbIffield.SelectedValue = User.DeptId;
            this.cbIffield.Enabled = false;

            //apiciData = this.GetDataSource(piciData.Select(" BATCH_ID <> 1000000005 "));
            piciData.DefaultView.Sort = " BATCH_TIME ASC ";
            piciData = piciData.DefaultView.ToTable();
            DataRow dr1 = piciData.NewRow();
            dr1["BATCH_NAME"] = "< 全部 >";
            dr1["BATCH_ID"] = 0;
            piciData.Rows.InsertAt(dr1, 0);
            this.cbBatch.DataSource = piciData;
            this.cbBatch.DisplayMember = "BATCH_NAME";
            this.cbBatch.ValueMember = "BATCH_ID";
        }
        private DataTable GetDataSource(DataRow[] rows)
        {
            if (rows != null && rows.Length != 0)
            {
                DataTable result = rows[0].Table.Clone();
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }
        //绑定医嘱
        public void ExeBindAdvice(DataTable data)
        {
            gridCancelApply.DataSource = data;
            this.repositoryItemLookUpEdit1.DataSource = data;
            gridViewCancelApply.ExpandAllGroups();
        }
        //绑定医嘱
        public void ExeBindAdviceNO(DataTable data)
        {
            gridCancelApply.DataSource = data;
            gridViewCancelApply.ExpandAllGroups();
        }
        //绑定待处理的申退医嘱
        public void ExeBindCancelApply(DataTable data)
        {
            gcCancel.DataSource = data;
            this.repositoryItemLookUpEdit2.DataSource = data;
        }
        #endregion

        #region 界面事件
        //查询
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (OnSelect != null)
            {
                this.cancelLabeEventArgs.Date = this.dtpQueryTime.Value;
                this.cancelLabeEventArgs.IffieldID = this.cbIffield.SelectedValue.ToString();
                this.cancelLabeEventArgs.BedNO = this.txtBedNO.Text.Trim();
                this.cancelLabeEventArgs.barCode = this.txtBarCode.Text.Trim();
                this.cancelLabeEventArgs.PiCi = this.cbBatch.SelectedValue.ToString();
                OnSelect(sender, cancelLabeEventArgs);
            }
        }
        //查询
        private void btnSelectByNO_Click(object sender, EventArgs e)
        {
            //    string barCode = this.txtBarCode.Text.Trim().ToString();
            //    string adviceID = this.txtAdviceID.Text.Trim().ToString();
            //    if (barCode.Length > 0 || adviceID.Length > 0)
            //    {
            //        if (OnSelectByNO != null)
            //        {
            //            this.cancelLabeEventArgs.BarCodeNO = barCode;
            //            this.cancelLabeEventArgs.AdviceNO = adviceID;
            //            OnSelectByNO(sender, cancelLabeEventArgs);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("请输入条形码或者病人医嘱号！");
            //        txtBarCode.Focus();
            //    }
        }
        //提交申请
        private void btnOk_Click(object sender, EventArgs e)
        {
            string reason = txtApplyReason.Text;
            if(reason.Trim().Length == 0 || txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请填写申退理由与申退人！");
            }
            else
            {
                if(gridViewCancelApply.GetFocusedDataRow() != null && OnBtnOK != null)
                {
                    this.GetLabelInfo();
                    if(this.labelList.Count > 0)
                    {
                        if(reason.Length < 200)
                        {
                            this.cancelLabeEventArgs.LabelID = this.labelList;
                            this.cancelLabeEventArgs.LabelBarID = this.labelBarList;
                            this.cancelLabeEventArgs.ApplyReason = reason;
                            this.cancelLabeEventArgs.ApplyName = this.txtName.Text.Trim();
                            OnBtnOK(sender, cancelLabeEventArgs);
                            btnSelect_Click(null, null);
                            btnRefresh_Click(null, null);
                        }
                        else
                        {
                            Message.Show("请精简你的退药申请理由！");
                        }
                    }
                    else
                    {
                        Message.Show("请钩选病人要退的医嘱！");
                    }
                }
            }
        }
        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OnBtnRefresh != null)
            {
                this.cancelLabeEventArgs.Date = this.dtpQueryTime.Value;
                this.cancelLabeEventArgs.IffieldID = this.cbIffield.SelectedValue.ToString();
                OnBtnRefresh(sender, cancelLabeEventArgs);
            }
        }
        //点击单选框
        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string value = "";
            string Index = this.gridViewCancelApply.GetFocusedDataRow()["LABEL_NO"].ToString();
            value = this.gridViewCancelApply.GetFocusedDataRow()["ISCHECK"].ToString();
            DataTable dt = gridCancelApply.DataSource as DataTable;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["LABEL_NO"].ToString() == Index)
                {
                    if (value == "" || value == "False")
                    {
                        dr["ISCHECK"] = true;
                    }
                    else
                    {
                        dr["ISCHECK"] = false;
                    }
                }
            }
            this.gridCancelApply.RefreshDataSource();
        }

        #endregion

        #region 内部调用方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (OnInitIffield != null)
            {
                OnInitIffield(null, null);
            }
            dtpQueryTime.Value = Sysdate;
        }

        private List<string> labelList;
        private List<string> labelBarList;
        /// <summary>
        /// 获得选择的瓶贴id信息
        /// </summary>
        public void GetLabelInfo()
        {
            List<string> list = new List<string>();
            List<string> bar = new List<string>();
            int count = gridViewCancelApply.RowCount;
            for (int i = 0; i < count; i++)
            {
                if (gridViewCancelApply.GetDataRow(i)["ISCHECK"].ToString() == "True")
                {
                    string labelID = gridViewCancelApply.GetDataRow(i)["LABEL_ID"].ToString();
                    string labelBarID = gridViewCancelApply.GetDataRow(i)["LABEL_BAR_ID"].ToString();
                    list.Add(labelID);
                    bar.Add(labelBarID);
                }
            }
            List<string> newList = new List<string>();
            List<string> newbar = new List<string>();
            for (int j = 0; j < list.Count; j++)
            {
                if (newList.Count != 0)
                {
                    bool bol = false;
                    for (int k = 0; k < newList.Count; k++)
                    {
                        if (list[j] == newList[k])
                        {
                            bol = true;
                        }
                    }
                    if (!bol)
                    {
                        newList.Add(list[j]);
                        newbar.Add(bar[j]);
                    }
                }
                else
                {
                    newList.Add(list[j]);
                    newbar.Add(bar[j]);
                }
            }
            this.labelList = newList;
            this.labelBarList = newbar;
        }
        #endregion









    }
}
