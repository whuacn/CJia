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
    public partial class SendPharm :  Tools.View, Views.ISendPharmView
    {

        protected override object CreatePresenter()
        {
            return new Presenters.SendPharmPresenter(this);
        }

        public SendPharm()
        {
            InitializeComponent();
            this.Init();
        }

        #region 属性

        /// <summary>
        /// 参数
        /// </summary>
        CJia.PIVAS.Views.SendPharmEventArgs sendPharmEventArgs = new Views.SendPharmEventArgs();

        //查询的瓶贴汇总
        private DataTable LabelCollect = null;

        //查询的瓶贴详情
        private DataTable LabelDetail = null;

        //查询的瓶贴详情信息
        private DataTable LabelDetailInfo = null;

        // 瓶贴id列表
        private List<string> LabelIDList;

        //未冲药瓶贴id列表
        private List<string> NoExeLabelIDList;

        //所有瓶贴数
        private int AllLabelAcount = 0;

        //已打印瓶贴数
        private int YESLabelAcount = 0;

        //未打印瓶贴数
        private int NOLabelAcount = 0;

        //选择的病区
        private string SelectIffleld;

        //选择的摆药次数
        private string SelectList;

        ////选择的批次
        //private string SelectBatch
        //{
        //    get
        //    {
        //        return this.GetSelectBatch();
        //    }
        //}

        #endregion

        #region 界面事件

        //刷新事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        //冲药
        private void btnSendPharm_Click(object sender, EventArgs e)
        {
            this.Refresh();
            DateTime date = Sysdate;
            foreach(string labelId in this.NoExeLabelIDList)
            {
                DataRow[] labelInfos = this.LabelDetail.Select("LABEL_ID = " + labelId);
                if(labelInfos != null && labelInfos.Length != 0)
                {
                    string GroupIndex = labelInfos[0]["GROUP_INDEX"].ToString();
                    this.PharmFee(GroupIndex, labelId, date);
                }
            }
        }
        //打印摆药单
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if(this.NOLabelAcount != 0)
            {
                Message.ShowWarning("有未冲的药物！请冲药后再打印校对单！");
                return;
            }
            else
            {
                DataTable data = (DataTable)this.gcPharm.DataSource;
                CJia.PIVAS.App.UI.NewSendPharmCollectReport newSendPharmCollectReport = new CJia.PIVAS.App.UI.NewSendPharmCollectReport();
                int allaCount = 0;
                foreach(DataRow row in data.Rows)
                {
                    allaCount += int.Parse(row["AMOUNT"].ToString());
                }
                newSendPharmCollectReport.DataBind(data, this.cbIffield.Text, this.cbBatch.Text, allaCount);
            }
        }

        // 冲药未冲药选择改变
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.FilterExe();
        }


        // 冲药过的瓶贴变色
        private void gvLabel_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                string stutas = this.gvLabel.GetDataRow(e.RowHandle)["ISEXE"].ToString();
                if(stutas == "1")
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        //冲药过的药品变色
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                int allAmount = int.Parse(this.gridView1.GetDataRow(e.RowHandle)["AMOUNT"].ToString());
                int printAmount = int.Parse(this.gridView1.GetDataRow(e.RowHandle)["PRINT_AMOUNT"].ToString());
                if(allAmount == printAmount)
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else if(printAmount != 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }
        #endregion


        #region ISendPharmView 成员

        //初始化病区
        public event EventHandler<Views.SendPharmEventArgs> OnInitIffield;

        //初始化批次事件
        public event EventHandler<Views.SendPharmEventArgs> OnInitBacth;

        //查询瓶贴
        public event EventHandler<Views.SendPharmEventArgs> OnSelectLabel;

        //查询药品汇总
        public event EventHandler<Views.SendPharmEventArgs> OnSelectPharmColloet;

        //冲药
        public event EventHandler<Views.SendPharmEventArgs> OnSendPharm;

        //打印摆药单
        public event EventHandler<Views.SendPharmEventArgs> OnPrintPharm;

        //修改瓶贴冲药状态
        public event Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        // 冲药
        public event Tools.Delegate.ResThreePar OnPharmFee;

        //扣库存
        public event Tools.Delegate.ResOnePar OnFeeTIME;

        //初始化瓶贴信息
        public void ExeInitLabel(DataTable result)
        {
            this.LabelDetail = result;
            gcLable.DataSource = this.LabelDetail;
            gvLabel.ExpandAllGroups();
            this.GetPrintAount();
            this.PrintCount();
        }

        //初始化药品汇总信息
        public void ExeInitPharmColloet(DataTable result)
        {
            //gcPharmColloet.DataSource = result;
        }

        //初始化病区回调函数
        public void ExeInitIffield(DataTable result)
        {
            DataRow dr = result.NewRow();
            dr["OFFICE_NAME"] = "< 全部 >";
            dr["OFFICE_ID"] = 0;
            result.Rows.InsertAt(dr, 0);
            this.cbIffield.DataSource = result;
            this.cbIffield.DisplayMember = "OFFICE_NAME";
            this.cbIffield.ValueMember = "OFFICE_ID";
        }

        //初始化批次回调函数
        public void ExeInitBacth(DataTable result)
        {
            DataRow dr = result.NewRow();
            dr["BATCH_NAME"] = "< 全部 >";
            dr["BATCH_ID"] = 0;
            result.Rows.InsertAt(dr, 0);
            this.cbBatch.DataSource = result;
            this.cbBatch.DisplayMember = "BATCH_NAME";
            this.cbBatch.ValueMember = "BATCH_ID";
        }

        //绑定库存不足的药
        public void ExeBindTodayNoPharmStore(DataTable data, string iffieldID)
        {
            PharmSendForm pafuc = new PharmSendForm(data, iffieldID);
            pafuc.ShowDialog();
        }

        //绑定冲药结果
        public void ExeBindTodayPharmSend(DataTable data1, DataTable data2)
        {
            SendPharmMessage uc = new SendPharmMessage(data1, data2);
            System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
            frmBase.Text = "冲药结果";
            frmBase.FormBorderStyle = FormBorderStyle.FixedDialog;
            //frmBase.MaximizeBox = false;
            //frmBase.MinimizeBox = false;
            frmBase.Size = new System.Drawing.Size(uc.Width + 5, uc.Height + 5);
            frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(uc);
            uc.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            frmBase.ShowDialog();
        }


        #endregion

        #region 补助方法

        /// <summary>
        /// 获取药品汇总
        /// </summary>
        /// <returns></returns>
        private DataTable GetPharmCollect()
        {
            DataTable date = this.LabelDetail;
            if(date != null && date.Rows != null && date.Rows.Count > 0)
            {
                DataTable result = new DataTable();
                DataColumn cl1 = new DataColumn("PHARM_ID");
                DataColumn cl2 = new DataColumn("PHARM_NAME");
                DataColumn cl3 = new DataColumn("PHARM_SPEC");
                DataColumn cl4 = new DataColumn("PHARM_FACTION");
                DataColumn cl5 = new DataColumn("AMOUNT");
                DataColumn cl6 = new DataColumn("UNITS");
                DataColumn cl7 = new DataColumn("PRINT_AMOUNT");
                result.Columns.Add(cl1);
                result.Columns.Add(cl2);
                result.Columns.Add(cl3);
                result.Columns.Add(cl4);
                result.Columns.Add(cl5);
                result.Columns.Add(cl6);
                result.Columns.Add(cl7);
                foreach(DataRow dr in date.Rows)
                {
                    if(this.rbAll.Checked)
                    {
                    }
                    else if(this.rbYes.Checked)
                    {
                        if(dr["ISEXE"].ToString() != "1")
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if(dr["ISEXE"].ToString() != "0")
                        {
                            continue;
                        }
                    }
                    DataRow[] rows = result.Select(" PHARM_ID = '" + dr["PHARM_ID"].ToString() + "'");
                    if(rows != null && rows.Length > 0)
                    {
                        rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                        rows[0]["PRINT_AMOUNT"] = int.Parse(rows[0]["PRINT_AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString()) * int.Parse(dr["ISEXE"].ToString());
                    }
                    else
                    {
                        DataRow newRow = result.NewRow();
                        newRow["PHARM_ID"] = dr["PHARM_ID"];
                        newRow["PHARM_NAME"] = dr["PHARM_NAME"];
                        newRow["PHARM_SPEC"] = dr["SPEC"];
                        newRow["PHARM_FACTION"] = dr["PHARM_FACTION"];
                        newRow["AMOUNT"] = dr["PHARM_AMOUNT"];
                        newRow["UNITS"] = dr["AMOUNT_UNIT"];
                        newRow["PRINT_AMOUNT"] = int.Parse(dr["PHARM_AMOUNT"].ToString()) * int.Parse(dr["ISEXE"].ToString());
                        result.Rows.Add(newRow);
                    }
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 过滤打印未打印
        /// </summary>
        private void FilterExe()
        {
            if(this.LabelDetail != null && this.LabelDetail.Rows != null && this.LabelDetail.Rows.Count > 0)
            {
                if(this.rbAll.Checked)
                {
                    this.gcLable.DataSource = this.LabelDetail;
                    this.gvLabel.ExpandAllGroups();
                    this.gcPharm.DataSource = this.GetPharmCollect();
                }
                else if(this.rbYes.Checked)
                {
                    this.gcLable.DataSource = this.GetDataSource(this.LabelDetail.Select(" ISEXE = '1' "));
                    this.gvLabel.ExpandAllGroups();
                    this.gcPharm.DataSource = this.GetPharmCollect();
                }
                else if(this.rbNo.Checked)
                {
                    this.gcLable.DataSource = this.GetDataSource(this.LabelDetail.Select(" ISEXE = '0' "));
                    this.gvLabel.ExpandAllGroups();
                    this.gcPharm.DataSource = this.GetPharmCollect();
                }
            }
        }

        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] rows)
        {
            if(rows != null && rows.Length != 0)
            {
                DataTable result = rows[0].Table.Clone();
                for(int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }

        /// <summary>
        ///设置打印瓶贴数
        /// </summary>
        private void GetPrintAount()
        {
            this.NoExeLabelIDList = new List<string>();
            DataTable result = new DataTable();
            DataColumn cl1 = new DataColumn("GROUP_INDEX");
            DataColumn cl2 = new DataColumn("BATCH_ID");
            DataColumn cl3 = new DataColumn("NEW_GROUP_INDEX_NO");
            DataColumn cl4 = new DataColumn("ISEXE");
            result.Columns.Add(cl1);
            result.Columns.Add(cl2);
            result.Columns.Add(cl3);
            result.Columns.Add(cl4);
            foreach(DataRow row in this.LabelDetail.Rows)
            {
                string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "' and   NEW_GROUP_INDEX_NO = '" + row["NEW_GROUP_INDEX_NO"].ToString() + "'";
                DataRow[] rows = result.Select(SelectSql);
                if(rows != null && rows.Length > 0)
                {
                    //rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                }
                else
                {
                    DataRow newRow = result.NewRow();
                    newRow["GROUP_INDEX"] = row["GROUP_INDEX"];
                    newRow["BATCH_ID"] = row["BATCH_ID"];
                    newRow["NEW_GROUP_INDEX_NO"] = row["NEW_GROUP_INDEX_NO"];
                    newRow["ISEXE"] = row["ISEXE"];
                    result.Rows.Add(newRow);
                    if( newRow["ISEXE"] .ToString() != "1")
                    {
                        this.NoExeLabelIDList.Add(row["LABEL_ID"].ToString());
                    }
                }
            }

            this.AllLabelAcount = int.Parse(result.Rows.Count.ToString());
            this.YESLabelAcount = int.Parse(result.Select(" ISEXE = '1' ").Length.ToString());
            this.NOLabelAcount = int.Parse(result.Select(" ISEXE = '0' ").Length.ToString());
        }

        /// <summary>
        /// 更新打印数
        /// </summary>
        private void PrintCount()
        {
            this.rbAll.Text = "全部(" + this.AllLabelAcount.ToString() + ")";
            this.rbYes.Text = "已冲药(" + this.YESLabelAcount.ToString() + ")";
            this.rbNo.Text = "未冲药(" + this.NOLabelAcount.ToString() + ")";
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        private void Init()
        {
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
        }

        /// <summary>
        /// 获取赛选条件
        /// </summary>
        private void GetFilter()
        {
            this.sendPharmEventArgs.IffieldID = this.cbIffield.SelectedValue.ToString();
            this.sendPharmEventArgs.barchID = this.cbBatch.SelectedValue.ToString();
        }

        /// <summary>
        /// 刷新查询结果
        /// </summary>
        private void Refresh()
        {
            this.GetFilter();
            this.OnSelectLabel(null, sendPharmEventArgs);
            this.gcPharm.DataSource = this.GetPharmCollect();
            this.FilterExe();
        }

        /// <summary>
        /// 冲药
        /// </summary>
        private void PharmFee(string GroupIndex, string LabelId,DateTime date)
        {
            if((bool)this.OnFeeTIME("1"))//查询当前是否需要扣除费用
            {
                string flag = this.OnPharmFee(GroupIndex, date, 1).ToString();
                if(flag != "Successed")
                {
                    Message.Show("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag);
                }
                else
                {
                    this.OnUpdateLabelExeStatus(LabelId);
                }
            }
        }

        #endregion




        #region ISendPharmView 成员


        public void ExeBindTodayPharmSendReport(DataTable data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
