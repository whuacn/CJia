using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class ApprovalBorrowView : CJia.Health.Tools.View, CJia.Health.Views.IApprovalBorrowView
    {
        CJia.Health.Views.ApprovalBorrowArgs approvalArgs = new Views.ApprovalBorrowArgs();
        public ApprovalBorrowView()
        {
            InitializeComponent();
            //ccAllSelect.Size = new System.Drawing.Size(40, 10);
            //cdBeginDate.EditValue = DateTime.Now.Date.AddDays(-7);
            //cdEndDate.EditValue = DateTime.Now.Date;
            InitDate();
            OnQueryLoadData(null, null);
            //QueryBorrowList();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ApprovalBorrowPresenter(this);
        }

        #region【事件处理】

        private void QueryBorrowList()
        {
            DateTime beginDate, endTime;
            beginDate = DateTime.Parse(cdBeginDate.EditValue.ToString());
            endTime = DateTime.Parse(cdEndDate.EditValue.ToString());
            approvalArgs.BeginDate = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day, 0, 0, 0);
            approvalArgs.EndDate = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);
            approvalArgs.BorrowState = cbBorrowState.EditValue.ToString();
            approvalArgs.DeptId = cbDept.EditValue.ToString();
            OnQueryBorrow(null, approvalArgs);
        }


        /// <summary>
        /// 全选反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gcBorrow.DataSource;
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["ISCHECK"] = ccAllSelect.Checked;
                }
            }
            this.gcBorrow.DataSource = dt;
        }

        /// <summary>
        /// 或得已选择的申请单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string value = "";
            string Index = this.gvBorrowList.GetFocusedDataRow()["BORROW_LIST_ID"].ToString();
            value = this.gvBorrowList.GetFocusedDataRow()["ISCHECK"].ToString();
            DataTable dt = gcBorrow.DataSource as DataTable;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BORROW_LIST_ID"].ToString() == Index)
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
            this.gcBorrow.RefreshDataSource();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryBorrowList();
            if (cbBorrowState.EditValue.ToString() == "90")
            {
                btnPass.Enabled = true;
                btnRefuse.Enabled = true;
            }
            else
            {
                btnPass.Enabled = false;
                btnRefuse.Enabled = false;
            }
        }

        /// <summary>
        /// 批准借阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            List<string> listBorrow = GetCheckedList();
            if (listBorrow == null || listBorrow.Count == 0)
            {
                MessageBox.Show("没有选择病案！");
                return;
            }
            if (listBorrow.Count > 0)
            {
                if (Health.Tools.Message.ShowQuery("是否批准选中的申请单？", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                {
                    approvalArgs.BorrowListId = listBorrow;
                    OnPassBorrow(null, approvalArgs);
                    QueryBorrowList();
                }
                else { return; }
            }
            else 
            {
                MessageBox.Show("请选中借阅单在操作！");
            }
        }

        /// <summary>
        /// 拒绝借阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuse_Click(object sender, EventArgs e)
        {
            List<string> listBorrow = GetCheckedList();
            if (listBorrow == null || listBorrow.Count == 0)
            {
                MessageBox.Show("没有选择病案！");
                return;
            }
            if (listBorrow.Count > 0)
            {
                if (Health.Tools.Message.ShowQuery("是否拒绝选中的申请单？", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                {
                    approvalArgs.BorrowListId = listBorrow;
                    OnRefuseBorrow(null, approvalArgs);
                    QueryBorrowList();
                }
            }
        }
        #endregion

        #region【接口实现】
        public event EventHandler<Views.ApprovalBorrowArgs> OnQueryBorrow;

        public event EventHandler<Views.ApprovalBorrowArgs> OnQueryLoadData;

        public event EventHandler<Views.ApprovalBorrowArgs> OnPassBorrow;

        public event EventHandler<Views.ApprovalBorrowArgs> OnRefuseBorrow;
        
        public void ExeBindBorrow(DataTable dtBorrowList, DataTable dtRecord)
        {
            DataSet ds = new DataSet();
            if (dtBorrowList != null && dtBorrowList.Rows != null && dtBorrowList.Rows.Count > 0)
            {
                ds.Tables.Add(dtBorrowList);
                ds.Tables.Add(dtRecord);
                ds.Tables[0].TableName = "gvBorrowList";
                ds.Tables[1].TableName = "gvHealthFile";
                ////不显示分组的面板
                gvBorrowList.OptionsView.ShowGroupPanel = false;
                gvHealthFile.OptionsView.ShowGroupPanel = false;
                gvBorrowList.OptionsDetail.ShowDetailTabs = false;
                gvHealthFile.OptionsDetail.ShowDetailTabs = false;
                gvBorrowList.OptionsSelection.MultiSelect = true;

                gvBorrowList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                //gvBorrowList.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
                //gvBorrowList.OptionsDetail.EnableDetailToolTip = false;

                DataRelation relation = new DataRelation("gvHealthFile",
                                            ds.Tables["gvBorrowList"].Columns["BORROW_LIST_ID"],
                                            ds.Tables["gvHealthFile"].Columns["BORROW_LIST_ID"]);
                ds.Relations.Add(relation);
                gcBorrow.DataSource = ds.Tables[0];
            }
            else
            {
                gcBorrow.DataSource = null;
                return;
            }
        }

        public void ExeLoadData(DataTable dtDept, DataTable dtBorrowState)
        {
            cbBorrowState.Properties.DataSource = dtBorrowState;
            cbBorrowState.Properties.DisplayMember = "NAME";
            cbBorrowState.Properties.ValueMember = "CODE";
            //cbBorrowState.Text = dtBorrowState.Rows[0]["NAME"].ToString();
            //cbBorrowState.EditValue = dtBorrowState.Rows[0]["CODE"].ToString();
            cbBorrowState.EditValue = "90";
            cbDept.Properties.DataSource = dtDept;
            cbDept.Properties.DisplayMember = "DEPT_NAME";
            cbDept.Properties.ValueMember = "DEPT_ID";
            cbDept.Text = dtDept.Rows[dtDept.Rows.Count - 1]["DEPT_NAME"].ToString();
            cbDept.EditValue = dtDept.Rows[dtDept.Rows.Count - 1]["DEPT_ID"].ToString();

        }
        #endregion
        

        #region【普通方法】

        /// <summary>
        /// 初始化日期控件时间
        /// </summary>
        private void InitDate()
        {
            DateTime now = Sysdate;
            this.cdBeginDate.EditValue = new DateTime(now.AddDays(-7).Year, now.AddDays(-7).Month, now.AddDays(-7).Day, 0, 0, 0);
            this.cdEndDate.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        /// <summary>
        /// 获取到已勾选的申请单的id
        /// </summary>
        /// <returns></returns>
        private List<string> GetCheckedList()
        {
            DataTable dt = (DataTable)gcBorrow.DataSource;
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<string> listBorrow = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["ISCHECK"] == true)
                {
                    listBorrow.Add(dt.Rows[i]["BORROW_LIST_ID"].ToString());
                }
            }
            return listBorrow;
        }


        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnSearch.Focus();
                    this.QueryBorrowList();
                    return true;
                case Keys.F1:
                    btnPass.Focus();
                    this.btnPass_Click(null,null);
                    return true;
                case Keys.F2:
                    btnRefuse.Focus();
                    this.btnRefuse_Click(null,null);
                    return true;
                default:
                    break;
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
   
}
