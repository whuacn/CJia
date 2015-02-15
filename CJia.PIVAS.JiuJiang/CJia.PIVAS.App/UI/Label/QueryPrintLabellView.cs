using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing.Printing;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 查询打印瓶贴用户控件
    /// </summary>
    public partial class QueryPrintLabellView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.Label.IQueryPrintLabelView
    {
        /// <summary>
        /// 查询瓶贴构造函数
        /// </summary>
        public QueryPrintLabellView()
        {
            InitializeComponent();
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
            this.init();

        }

        private void init()
        {
            DateTime now = Sysdate;
            DateTime next = now.AddDays(1);
            this.dtStart.DateTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            this.dtEnd.DateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            this.rbOldDate.Text = "今日(" + now.Year + "/" + now.Month + "/" + now.Day + ")";
            this.rbNewDate.Text = "明日(" + next.Year + "/" + next.Month + "/" + next.Day + ")";
            if (User.role == "2")
            {
                this.rbLong.Checked = true;
                //this.rbLong.Enabled = false;
                //this.rbTemporary.Enabled = false;

                this.btnPrintCollect.Enabled = false;

                this.rbNew.Checked = true;
                this.rbNew.Enabled = false;
                this.rbOld.Enabled = false;
                this.rbOldDate.Checked = true;
                this.rbOldDate.Enabled = false;
                this.rbNewDate.Enabled = false;

                this.rbAllPrint.Checked = true;
                this.rbYesPrint.Enabled = false;
                this.rbNoPrint.Enabled = false;
                this.rbAllPrint.Enabled = false;

                this.cbCheckData.Enabled = false;
                this.dtStart.Enabled = false;
                this.dtEnd.Enabled = false;
                this.labelControl2.Visible = false;
                //this.cbIffield.Enabled = false;
                //this.cbIffield.Visible = false;
                this.ckceIllfield.Enabled = false;
                this.ckceIllfield.Visible = false;
                this.labelControl3.Visible = false;
                //this.cbBatch.Enabled = false;
                //this.cbBatch.Visible = false;
                this.ckceBatch.Enabled = false;
                this.ckceBatch.Visible = false;
                this.btnFilter.Visible = false;
                this.btnRefresh.Location = new Point(601, this.btnRefresh.Location.Y);


            }

        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.QueryPrintLabelPresenter(this);
        }

        #region 字段 属性

        //查询的瓶贴汇总
        private DataTable LabelCollect = null;

        //查询的瓶贴详情
        private DataTable LabelDetail = null;

        //查询的瓶贴详情信息
        private DataTable LabelDetailInfo = null;

        //选着的病人
        private List<string> selectPatient
        {
            get
            {
                return this.filterPatientView.selectPatient;
            }
        }

        //选着的病人
        private DataTable selectPharm
        {
            get
            {
                return this.filterPharmView.selectPharm;
            }
        }

        //瓶贴id列表
        private List<string> NoPrintLabelIDList;

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

        //选择的批次
        private string SelectBatch
        {
            get
            {
                return this.GetSelectBatch();
            }
        }

        //病人过滤窗体
        private CJia.PIVAS.App.UI.Label.FilterPatientView filterPatientView = new FilterPatientView();


        /// <summary>
        /// 药品过滤
        /// </summary>
        private CJia.PIVAS.App.UI.Label.FilterPharmView filterPharmView = new Label.FilterPharmView();

        #endregion

        #region 界面事件

        // 审核时间是否使用
        private void cbCheckData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckData.Checked)
            {
                this.dtStart.Enabled = true;
                this.dtEnd.Enabled = true;
            }
            else
            {
                this.dtStart.Enabled = false;
                this.dtEnd.Enabled = false;
            }
        }

        // 配置与单组切换
        private void Group_CheckedChanged(object sender, EventArgs e)
        {
            this.rbYesPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbYesPrint.ForeColor = System.Drawing.Color.Black;
            this.rbNoPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbNoPrint.ForeColor = System.Drawing.Color.Black;
            this.rbAllPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbAllPrint.ForeColor = System.Drawing.Color.Black;
            ((RadioButton)sender).Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Blue;
            //if(this.rbYesPrint.Checked)
            //{
            //    this.btnPrintLabel.Enabled = true;
            //    this.btnPrintCollect.Enabled = false;
            //}
            //else
            //{
            //    this.btnPrintLabel.Enabled = false;
            //    this.btnPrintCollect.Enabled = true;
            //}
        }

        private void rbLongTemporary_CheckedChanged(object sender, EventArgs e)
        {
            this.rbLong.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbLong.ForeColor = System.Drawing.Color.Black;
            this.rbTemporary.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbTemporary.ForeColor = System.Drawing.Color.Black;
            ((RadioButton)sender).Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Red;
            if (this.rbLong.Checked)
            {
                //this.cbBatch.Enabled = true;
                this.ckceBatch.Enabled = true;
                this.rbOld.Enabled = true;
                this.rbNew.Enabled = true;
                this.rbOld.Checked = true;
                this.rbOldDate.Enabled = true;
                this.rbNewDate.Enabled = true;
                this.rbNewDate.Checked = true;
            }
            else
            {
                //this.cbBatch.Enabled = false;
                this.ckceBatch.Enabled = false;
                this.rbOld.Enabled = false;
                this.rbNew.Enabled = true;
                this.rbNew.Checked = true;
                this.rbOldDate.Enabled = true;
                this.rbNewDate.Enabled = false;
                this.rbOldDate.Checked = true;
            }

            if (User.role == "2")
            {
                this.rbNew.Checked = true;
                this.rbNew.Enabled = false;
                this.rbOld.Enabled = false;
                this.rbOldDate.Checked = true;
                this.rbOldDate.Enabled = false;
                this.rbNewDate.Enabled = false;

                this.cbCheckData.Enabled = false;
                this.dtStart.Enabled = false;
                this.dtEnd.Enabled = false;
                //this.cbIffield.Enabled = false;
                this.ckceIllfield.Enabled = false;
                //this.cbBatch.Enabled = false;
                this.ckceBatch.Enabled = false;
            }
        }

        //当日隔日切换
        private void rbOldNew_CheckedChanged(object sender, EventArgs e)
        {
            this.rbNew.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbNew.ForeColor = System.Drawing.Color.Black;
            this.rbOld.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbOld.ForeColor = System.Drawing.Color.Black;
            ((RadioButton)sender).Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Green;
            if (this.rbNew.Checked)
            {
                this.rbOldDate.Enabled = true;
                this.rbNewDate.Enabled = false;
                this.rbOldDate.Checked = true;
            }
            else
            {
                this.rbOldDate.Enabled = true;
                this.rbNewDate.Enabled = true;
                this.rbNewDate.Checked = true;
            }
        }

        //刷新按钮单机事件绑定方法
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            rbAll.Checked = true;//by dh
            //this.OnQueryPharmCollect(null, eventArgs);
        }

        //打印瓶贴
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            this.PrintLabel();
            CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs eventArgs = this.GetFilter();
            this.OnQueryLabelDetails(null, eventArgs);
            this.FilterPrint(this.FilterPharm(this.LabelDetail, false), false);
            //this.FilterPrint(this.LabelDetail); //by dh
        }

        // 打印未打印过滤
        private void rbPrint_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = ((RadioButton)sender);
            if (rb.Checked)
            {
                this.FilterPharm(this.FilterPrint(this.LabelDetail, false), false);
            }
        }

        //打印汇总
        private void btnPrintCollect_Click(object sender, EventArgs e)
        {
            //this.Refresh(); //by dh zhushi
            //add by lp
            string strIllfieldName = "";
            int selectedIll = ckceIllfield.Properties.Items.GetCheckedValues().Count();
            int selectall = ckceIllfield.Properties.Items.Count;
            if (selectedIll == selectall)
            {
                strIllfieldName = "<全部>";
            }
            else if (selectedIll != 1)
            {
                MessageBox.Show("请选择单一的病区进行汇总打印", "提示");
                return;
            }
            else if (selectedIll == 1)
            {
                strIllfieldName = ckceIllfield.Text;
            }

            string strBatchName = "";
            int selectedBatch = ckceBatch.Properties.Items.GetCheckedValues().Count();
            int selectAllBatch = ckceBatch.Properties.Items.Count;
            if (selectedBatch == selectAllBatch)
            {
                strBatchName = "<全部>";
            }
            else
            {
                strBatchName = ckceBatch.Text;
            }
            //end

            DataTable data = (DataTable)this.gcPharm.DataSource;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                CJia.PIVAS.App.UI.Label.NewPharmCollectReport newPharmCollectReport = new NewPharmCollectReport();
                int allaCount = 0;
                foreach (DataRow row in data.Rows)
                {
                    allaCount += int.Parse(row["AMOUNT"].ToString());
                }

                int labelCount = 0;
                if (this.rbAll.Checked)
                {
                    labelCount = this.AllLabelAcount;
                }
                else if (this.rbYes.Checked)
                {
                    labelCount = this.YESLabelAcount;
                }
                else if (this.rbNo.Checked)
                {
                    labelCount = this.NOLabelAcount;
                }
                string type = "";
                if (rbYesPrint.Checked)
                {
                    type = rbYesPrint.Text;
                }
                if (rbNoPrint.Checked)
                {
                    type = rbNoPrint.Text;
                }
                if (rbAllPrint.Checked)
                {
                    type = rbAllPrint.Text;
                }
                string longTemporary = "";
                if (this.rbLong.Checked)
                {
                    longTemporary = "长期";
                }
                else
                {
                    longTemporary = "临时";
                }
                string drGr = "";
                if (this.rbNew.Checked)
                {
                    drGr = this.rbNew.Text;
                }
                else
                {
                    drGr = this.rbOld.Text;
                }
                string zrMr = "";
                if (this.rbOldDate.Checked)
                {
                    zrMr = this.rbOldDate.Text;
                }
                else
                {
                    zrMr = this.rbNewDate.Text;
                }
                newPharmCollectReport.DataBind(data, strIllfieldName, strBatchName, allaCount, labelCount, type, longTemporary, drGr, zrMr);
            }
        }

        // 打印过的瓶贴变色
        private void gvLabel_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string stutas = this.gvLabel.GetDataRow(e.RowHandle)["ISPRINT"].ToString();
                if (stutas == "1")
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        //打印过的药品变色
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int allAmount = int.Parse(this.gridView1.GetDataRow(e.RowHandle)["AMOUNT"].ToString());
                int printAmount = int.Parse(this.gridView1.GetDataRow(e.RowHandle)["PRINT_AMOUNT"].ToString());
                if (allAmount == printAmount)
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else if (printAmount != 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        //作废已打印瓶贴
        private void delectLabel_Click(object sender, EventArgs e)
        {
            string labelId = this.gvLabel.GetFocusedDataRow()["LABEL_ID"].ToString();
            this.OnDeleteLabel(labelId);
        }

        //打印未打印瓶贴
        private void printLabel_Click(object sender, EventArgs e)
        {
            string GroupIndex = this.gvLabel.GetFocusedDataRow()["GROUP_INDEX"].ToString();
            string labelId = this.gvLabel.GetFocusedDataRow()["LABEL_ID"].ToString();
            DateTime date = Sysdate;
            CJia.PIVAS.App.UI.Label.SmallPrintLabelReport labelReport = new CJia.PIVAS.App.UI.Label.SmallPrintLabelReport();
            if (this.gvLabel.GetFocusedDataRow()["ISPRINT"].ToString() == "1")
            {
                if (Message.ShowQuery("该瓶贴已经打印是否重打！重打将把原瓶贴作废并重新打印一张一模一样的瓶贴！", Message.Button.YesNo) == Message.Result.Yes)
                {
                    CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs queryPrintLabelViewEventArgs = new Views.Label.QueryPrintLabelViewEventArgs()
                    {
                        LabelId = labelId
                    };
                    this.OnUpdateBarCode(null, queryPrintLabelViewEventArgs);
                    DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId);
                    this.OnUpdateLabelPrintStatus(labelId, date);
                    int allLabelCount = (labelInfos.Length - 1) / 4 + 1;
                    for (int j = 1; j <= allLabelCount; j++)
                    {
                        DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                        DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                        labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["GEN_DATE"]);
                        labelReport.LabelPrint();
                    }
                }
            }
            else
            {
                CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs queryPrintLabelViewEventArgs = new Views.Label.QueryPrintLabelViewEventArgs()
                {
                    LabelId = labelId
                };
                this.OnUpdateBarCode(null, queryPrintLabelViewEventArgs);
                DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId);
                if (this.SendPharm(GroupIndex, labelId, date))
                {
                    this.OnUpdateLabelPrintStatus(labelId, date);
                    int allLabelCount = (labelInfos.Length - 1) / 4 + 1;
                    for (int j = 1; j <= allLabelCount; j++)
                    {
                        DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                        DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                        labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["GEN_DATE"]);
                        labelReport.LabelPrint();
                    }
                }
            }
            this.Refresh();
        }

        //病人过滤按钮
        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow("病人过滤", filterPatientView);
            this.GetPrintAount(this.LabelDetail);
            //this.FilterPharm(this.FilterPrint(this.LabelDetail, true), true);//by dh zhushi
            this.FilterPharm(this.FilterPrint(this.NewLabelDetail, true), true);// by dh add
        }

        #endregion

        #region IView 成员

        //初始化病区
        public event EventHandler<Views.SendPharmSelectEventArgs> OnInitIffield;

        //初始化批次
        public event EventHandler<Views.SendPharmSelectEventArgs> OnInitBacth;

        //查询瓶贴详情事件
        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryLabelDetails;

        //修改瓶贴冲药状态
        public event Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        //生成瓶贴
        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnGenLabel;


        //查询药品汇总事件
        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryPharmCollect;


        //获取扣费时间
        public event Tools.Delegate.ResOnePar OnFeeTIME;

        //扣费扣库存
        public event Tools.Delegate.ResThreePar OnPharmFee;

        //修改瓶贴打印状态
        public event Tools.Delegate.NoResTwoPar OnUpdateLabelPrintStatus;

        //获取瓶贴条形码
        public event Tools.Delegate.ResThreePar OnGetLabelBarcode;

        //删除瓶贴
        public event Tools.Delegate.NoResOnePar OnDeleteLabel;

        //瓶贴计费次数
        public event Tools.Delegate.ResOnePar OnLabelIsFee;





        //绑定瓶贴详情回调方法
        public void ExeBindingLabelDetails(DataTable result)
        {
            this.LabelDetail = result;
            this.NewLabelDetail = result;//by dh add
            this.gcLable.DataSource = this.LabelDetail;
            this.repositoryItemLookUpEdit1.DataSource = result;
            this.gvLabel.ExpandAllGroups();
            this.GetPrintAount(this.LabelDetail);
            this.PrintCount();
        }

        //绑定瓶贴详情回调方法
        public void ExeBindingLabelDetailsInfo(DataTable result)
        {
            this.LabelDetailInfo = result;
            //this.NoPrintLabelIDList = new List<string>();
            //DataTable selectData = (DataTable)this.gcLable.DataSource;
            //DataTable noPrint = this.GetDataSource(selectData.Select(" ISPRINT = '0' "));
            //if(noPrint != null && noPrint.Rows != null && noPrint.Rows.Count > 0)
            //{
            //    foreach(DataRow row in noPrint.Rows)
            //    {
            //        string labelId = row["LABEL_ID"].ToString();
            //        bool haveLabel = false;
            //        if(this.NoPrintLabelIDList.Count > 0)
            //        {
            //            foreach(string labelID in this.NoPrintLabelIDList)
            //            {
            //                if(labelID == labelId)
            //                {
            //                    haveLabel = true;
            //                }
            //            }
            //        }
            //        if(!haveLabel)
            //        {
            //            this.NoPrintLabelIDList.Add(labelId);
            //        }
            //    }
            //}
        }

        //绑定药品汇总回调方法
        public void ExeBindingPharmCollect(DataTable result)
        {
        }

        //初始化病区回调函数
        public void ExeInitIffield(DataTable result)
        {
            for (int i = 0; i < result.Rows.Count; i++)
            {
                ckceIllfield.Properties.Items.Add(result.Rows[i]["office_id"].ToString(), result.Rows[i]["office_name"].ToString(), CheckState.Checked, true);

            }

            //DataRow dr = result.NewRow();
            //dr["OFFICE_NAME"] = "< 全部 >";
            //dr["OFFICE_ID"] = 0;
            //result.Rows.InsertAt(dr, 0);
            //this.cbIffield.DataSource = result;
            //this.cbIffield.DisplayMember = "OFFICE_NAME";
            //this.cbIffield.ValueMember = "OFFICE_ID";
        }

        //初始化批次回调函数
        public void ExeInitBacth(DataTable result)
        {
            result = this.GetDataSource(result.Select(" BATCH_ID <> 1000000005 "));
            result.DefaultView.Sort = " BATCH_TIME ASC ";
            result = result.DefaultView.ToTable();

            for (int i = 0; i < result.Rows.Count; i++)
            {
                ckceBatch.Properties.Items.Add(result.Rows[i]["BATCH_ID"].ToString(), result.Rows[i]["BATCH_NAME"].ToString(), CheckState.Checked, true);

            }

            //DataRow dr = result.NewRow();
            //dr["BATCH_NAME"] = "< 全部 >";
            //dr["BATCH_ID"] = 0;
            //result.Rows.InsertAt(dr, 0);
            //this.cbBatch.DataSource = result;
            //this.cbBatch.DisplayMember = "BATCH_NAME";
            //this.cbBatch.ValueMember = "BATCH_ID";
        }

        #endregion

        #region 补助方法

        /// <summary>
        /// 刷新方法
        /// </summary>
        private void Refresh()
        {
            CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs eventArgs = this.GetFilter();
            this.OnQueryLabelDetails(null, eventArgs);
            DataTable pharmCollect = this.GetPharmCollect();
            this.gcPharm.DataSource = pharmCollect;
            this.filterPharmView.BindData(pharmCollect);
            this.InitPatient();
        }

        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private Views.Label.QueryPrintLabelViewEventArgs GetFilter()
        {
            Views.Label.QueryPrintLabelViewEventArgs queryPrintLabelViewEventArgs = new Views.Label.QueryPrintLabelViewEventArgs();
            //queryPrintLabelViewEventArgs.IllfieldId = this.cbIffield.SelectedValue.ToString();
            //add by lip
            string strIllfield = "";
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            if (strIllfield == "")
            {
                queryPrintLabelViewEventArgs.IllfieldId = "''";
            }
            else
            {
                queryPrintLabelViewEventArgs.IllfieldId = strIllfield.Substring(0, strIllfield.Length - 1);
            }
            //end
            //queryPrintLabelViewEventArgs.batchid = this.cbBatch.SelectedValue.ToString();
          

            queryPrintLabelViewEventArgs.selectDate = this.rbNewDate.Checked ? 1 : 0;
            queryPrintLabelViewEventArgs.grOrDr = this.rbNew.Checked ? 0 : 1;
            if (this.rbYesPrint.Checked)
            {
                queryPrintLabelViewEventArgs.printType = "1";
            }
            if (this.rbNoPrint.Checked)
            {
                queryPrintLabelViewEventArgs.printType = "0";
            }
            if (this.rbAllPrint.Checked)
            {
                queryPrintLabelViewEventArgs.printType = "10";
            }
            if (this.rbLong.Checked)
            {
                queryPrintLabelViewEventArgs.longTemporary = "1";
            }
            else
            {
                queryPrintLabelViewEventArgs.longTemporary = "0";
            }

            //add by lip
            string strBatch = "";
            if (queryPrintLabelViewEventArgs.longTemporary == "1")
            {
                foreach (string illList in ckceBatch.Properties.Items.GetCheckedValues())
                {
                    strBatch += illList + ",";
                }
                if (strBatch == "")
                {
                    queryPrintLabelViewEventArgs.batchid = "''";
                }
                else
                {
                    queryPrintLabelViewEventArgs.batchid = strBatch.Substring(0, strBatch.Length - 1);
                }
            }
            else
            {
                queryPrintLabelViewEventArgs.batchid = "";
            }
            //end
            queryPrintLabelViewEventArgs.useCheckData = this.cbCheckData.Checked;
            queryPrintLabelViewEventArgs.CheckDataStart = this.dtStart.DateTime;
            queryPrintLabelViewEventArgs.CheckDataEnd = this.dtEnd.DateTime;
            return queryPrintLabelViewEventArgs;
        }
        /// <summary>
        /// 刷新产生的数据
        /// </summary>
        public DataTable NewLabelDetail = null;

        /// <summary>
        /// 过滤病人
        /// </summary>
        private DataTable FilterPrint(DataTable labelDetail, bool bol)
        {
            if (this.LabelDetail != null && this.LabelDetail.Rows != null && this.LabelDetail.Rows.Count > 0)
            {
                DataTable result = labelDetail;
                DataTable newResult = null;
                if (result != null)
                {
                    newResult = result.Clone();
                }
                if (this.selectPatient != null && this.selectPatient.Count > 0)
                {
                    foreach (string inhos_id in this.selectPatient)
                    {
                        if (result != null && result.Rows != null && result.Rows.Count > 0)
                        {
                            this.DataAddRow(newResult, result.Select(" INHOS_ID = '" + inhos_id + "'"));
                        }
                    }
                }

                if (bol)//by dh
                {
                    LabelDetail = newResult;//by dh add
                    this.GetPrintAount(newResult);
                }
                else
                {
                    this.GetPrintAount(LabelDetail);//by dh
                }
                this.PrintCount();
                //if (this.rbAll.Checked)
                //{
                //    //newResult = newResult;
                //}
                //else if (this.rbYes.Checked && newResult != null)//newResult != null by dh add
                //{
                //    newResult = this.GetDataSource(newResult.Select(" ISPRINT = '1' "));
                //}
                //else if (this.rbNo.Checked && newResult != null)
                //{
                //    newResult = this.GetDataSource(newResult.Select(" ISPRINT = '0' "));
                //}//by dh zhushi

                this.gcLable.DataSource = newResult;
                this.gvLabel.ExpandAllGroups();
                this.gcPharm.DataSource = this.GetPharmCollect();

                return newResult;
            }
            return null;
        }

        /// <summary>
        /// 过滤药品
        /// </summary>
        private DataTable FilterPharm(DataTable labelDetail, bool bol)
        {
            if (this.LabelDetail != null && this.LabelDetail.Rows != null && this.LabelDetail.Rows.Count > 0)
            {
                DataTable result = labelDetail;
                DataTable newResult = null;
                if (result != null)
                {
                    newResult = result.Clone();
                }
                List<string> pharmList = new List<string>();
                if (this.selectPharm != null && this.selectPharm.Rows != null && this.selectPharm.Rows.Count > 0)
                {
                    foreach (DataRow row in this.selectPharm.Rows)
                    {
                        pharmList.Add(row["PHARM_ID"].ToString());
                    }
                }
                List<string> groupList = new List<string>();
                if (result != null && result.Rows != null && result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        if (pharmList.Contains(row["PHARM_ID"].ToString()))
                        {
                            groupList.Add(row["GROUP_INDEX"].ToString());
                        }
                    }
                }
                if (result != null && result.Rows != null && result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        if (groupList.Contains(row["GROUP_INDEX"].ToString()))
                        {
                            this.DataAddRow(newResult, new DataRow[] { row });
                        }
                    }
                }

                if (bol)//by dh
                {
                    LabelDetail = newResult;//by dh add
                    this.GetPrintAount(newResult);
                }
                else
                {
                    this.GetPrintAount(LabelDetail);//by dh
                }
                this.PrintCount();
                if (this.rbAll.Checked)
                {
                    //newResult = newResult;
                }
                else if (this.rbYes.Checked && newResult != null)//newResult != null by dh add
                {
                    newResult = this.GetDataSource(newResult.Select(" ISPRINT = '1' "));
                }
                else if (this.rbNo.Checked && newResult != null)//newResult != null by dh add
                {
                    newResult = this.GetDataSource(newResult.Select(" ISPRINT = '0' "));
                }

                this.gcLable.DataSource = newResult;
                this.gvLabel.ExpandAllGroups();
                this.gcPharm.DataSource = this.GetPharmCollect();

                return newResult;
            }
            return null;
        }


        /// <summary>
        /// 获取药品汇总
        /// </summary>
        /// <returns></returns>
        private DataTable GetPharmCollect()
        {
            DataTable date = (DataTable)this.gcLable.DataSource;
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                DataTable result = new DataTable();
                DataColumn cl1 = new DataColumn("PHARM_ID");
                DataColumn cl2 = new DataColumn("PHARM_NAME");
                DataColumn cl3 = new DataColumn("PHARM_SPEC");
                DataColumn cl4 = new DataColumn("PHARM_FACTION");
                DataColumn cl5 = new DataColumn("AMOUNT", typeof(int));
                DataColumn cl6 = new DataColumn("UNITS");
                DataColumn cl7 = new DataColumn("PRINT_AMOUNT");
                DataColumn cl8 = new DataColumn("NO_PRINT_AMOUNT");
                result.Columns.Add(cl1);
                result.Columns.Add(cl2);
                result.Columns.Add(cl3);
                result.Columns.Add(cl4);
                result.Columns.Add(cl5);
                result.Columns.Add(cl6);
                result.Columns.Add(cl7);
                result.Columns.Add(cl8);
                foreach (DataRow dr in date.Rows)
                {
                    if (this.rbAll.Checked)
                    {
                    }
                    else if (this.rbYes.Checked)
                    {
                        if (dr["ISPRINT"].ToString() != "1")
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (dr["ISPRINT"].ToString() != "0")
                        {
                            continue;
                        }
                    }
                    DataRow[] rows = result.Select(" PHARM_ID = '" + dr["PHARM_ID"].ToString() + "'");
                    if (rows != null && rows.Length > 0)
                    {
                        rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                        rows[0]["PRINT_AMOUNT"] = int.Parse(rows[0]["PRINT_AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString()) * int.Parse(dr["ISPRINT"].ToString());
                        if (int.Parse(dr["ISPRINT"].ToString()) == 0)
                        {
                            rows[0]["NO_PRINT_AMOUNT"] = int.Parse(rows[0]["NO_PRINT_AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                        }
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
                        newRow["PRINT_AMOUNT"] = int.Parse(dr["PHARM_AMOUNT"].ToString()) * int.Parse(dr["ISPRINT"].ToString());
                        if (int.Parse(dr["ISPRINT"].ToString()) == 0)
                        {
                            newRow["NO_PRINT_AMOUNT"] = int.Parse(dr["PHARM_AMOUNT"].ToString());
                        }
                        else
                        {
                            newRow["NO_PRINT_AMOUNT"] = 0;
                        }
                        result.Rows.Add(newRow);
                    }
                }
                if (result != null && result.Rows != null && result.Rows.Count > 0)
                {
                    result.DefaultView.Sort = " PHARM_NAME ,PHARM_SPEC ,PHARM_FACTION, UNITS";
                    //result.DefaultView.Sort = " AMOUNT DESC";
                    result = result.DefaultView.ToTable();
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 更新打印数
        /// </summary>
        private void PrintCount()
        {
            this.rbAll.Text = "全部(" + this.AllLabelAcount.ToString() + ")";
            this.rbYes.Text = "已打印(" + this.YESLabelAcount.ToString() + ")";
            this.rbNo.Text = "未打印(" + this.NOLabelAcount.ToString() + ")";
        }

        /// <summary>
        /// 打印瓶贴
        /// </summary>
        private void PrintLabel()
        {
            bool isPrint = true;
            DataTable selectData = (DataTable)this.gcLable.DataSource;
            if (selectData == null || selectData.Rows == null && selectData.Rows.Count == 0)
            {
                Message.Show("查询结果中没有未打印的瓶贴！");
                return;
            }
            DataTable noPrint = this.GetDataSource(selectData.Select(" ISPRINT = '0' "));
            if (noPrint == null || noPrint.Rows == null || noPrint.Rows.Count == 0)
            {
                Message.Show("查询结果中没有未打印的瓶贴！");
                return;
            }
            CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs queryPrintLabelViewEventArgs = this.GetFilter();
            queryPrintLabelViewEventArgs.groupIndexBatchid = this.GetLabellList(noPrint);
            queryPrintLabelViewEventArgs.labelCount = this.GetLabelCount(noPrint);
            if (Message.ShowQuery("确认打印查询结果中的(" + queryPrintLabelViewEventArgs.labelCount + ")张未打印的瓶贴？", Message.Button.OkCancel) == Message.Result.Ok)
            {
                if (this.rbNew.Checked && this.rbLong.Checked && this.rbOldDate.Checked)
                {
                    if (User.role == "2")
                    {
                        isPrint = false;
                    }
                    else
                    {
                        MessageBoxView messageBoxView = new MessageBoxView("当日新开医嘱打印执行日期为当日的瓶贴是否需要打印真实瓶贴？");
                        this.ShowAsWindow("警告", messageBoxView);
                        isPrint = messageBoxView.SelectValue;
                    }
                }
                CJia.PIVAS.App.UI.Label.SmallPrintLabelReport labelReport = new CJia.PIVAS.App.UI.Label.SmallPrintLabelReport();
                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                this.OnGenLabel(null, queryPrintLabelViewEventArgs);//批量插入瓶贴
                CJia.PIVAS.Views.Label.QueryPrintLabelViewEventArgs eventArgs = this.GetFilter();
                this.OnQueryLabelDetails(null, eventArgs);
                this.FilterPharm(this.FilterPrint(this.LabelDetail, false), false);

                this.GetNoPrintLabelId();
                this.OnQueryLabelDetailsInfo(null, queryPrintLabelViewEventArgs);//查询瓶贴详情
                DateTime date = Sysdate;
                for (int i = 0; i < this.NoPrintLabelIDList.Count; i++)
                {
                    string labelId = this.NoPrintLabelIDList[i];

                    DataTable pharmCount = this.OnLabelPharmCount(labelId) as DataTable;
                    if (pharmCount != null && pharmCount.Rows != null && pharmCount.Rows.Count > 0)
                    {
                        string str = "";
                        foreach (DataRow row in pharmCount.Rows)
                        {
                            str += "  " + row["PHARM_NAME"].ToString() + "(" + row["SPEC"].ToString() + ")  ";
                        }
                        MessageBoxView messageBoxView = new MessageBoxView("该瓶贴对应药品 " + str + " 库存不足！是否继续打印？");
                        this.ShowAsWindow("警告", messageBoxView);
                        if (messageBoxView.SelectValue)
                        {
                        }
                        else
                        {
                            continue;
                        }
                    }


                    queryPrintLabelViewEventArgs.LabelId = labelId;
                    this.OnUpdateBarCode(null, queryPrintLabelViewEventArgs);
                    DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId);
                    if (labelInfos != null && labelInfos.Length != 0)
                    {
                        string GroupIndex = labelInfos[0]["GROUP_INDEX"].ToString();
                        //string batchId = labelInfos[0]["BATCH_ID"].ToString();
                        //int batchNum = int.Parse( batchId.Substring(batchId.Length - 1, 1));//用于分开批次
                        if (this.SendPharm(GroupIndex, labelId, date.AddSeconds(i)))
                        {
                            this.OnUpdateLabelPrintStatus(labelId, date);
                            int allLabelCount = (labelInfos.Length - 1) / 4 + 1;
                            for (int j = 1; j <= allLabelCount; j++)
                            {
                                DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                                DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                                if (isPrint)
                                {
                                    labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["GEN_DATE"]);
                                    labelReport.LabelPrint();
                                }
                            }
                        }
                        else
                        {
                            this.OnDeleteLabel(labelId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取未打印的瓶贴组号以及批次
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DataTable GetLabellList(DataTable date)
        {
            DataTable result = new DataTable();
            DataColumn cl1 = new DataColumn("GROUP_INDEX");
            DataColumn cl2 = new DataColumn("BATCH_ID");
            DataColumn cl3 = new DataColumn("NEW_GROUP_INDEX_NO");
            DataColumn cl4 = new DataColumn("ISPRINT");
            result.Columns.Add(cl1);
            result.Columns.Add(cl2);
            result.Columns.Add(cl3);
            result.Columns.Add(cl4);
            foreach (DataRow row in date.Rows)
            {
                //string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "' and   NEW_GROUP_INDEX_NO = '" + row["NEW_GROUP_INDEX_NO"].ToString() + "'";
                string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "'";
                DataRow[] rows = result.Select(SelectSql);
                if (rows != null && rows.Length > 0)
                {
                    //rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                }
                else
                {
                    DataRow newRow = result.NewRow();
                    newRow["GROUP_INDEX"] = row["GROUP_INDEX"];
                    newRow["BATCH_ID"] = row["BATCH_ID"];
                    newRow["NEW_GROUP_INDEX_NO"] = row["NEW_GROUP_INDEX_NO"];
                    newRow["ISPRINT"] = row["ISPRINT"];
                    result.Rows.Add(newRow);
                }
            }
            return this.GetDataSource(result.Select(" ISPRINT = '0' "));
        }

        /// <summary>
        /// 获取未打印的瓶贴组号以及批次
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private int GetLabelCount(DataTable date)
        {
            DataTable result = new DataTable();
            DataColumn cl1 = new DataColumn("GROUP_INDEX");
            DataColumn cl2 = new DataColumn("BATCH_ID");
            DataColumn cl3 = new DataColumn("NEW_GROUP_INDEX_NO");
            DataColumn cl4 = new DataColumn("ISPRINT");
            result.Columns.Add(cl1);
            result.Columns.Add(cl2);
            result.Columns.Add(cl3);
            result.Columns.Add(cl4);
            foreach (DataRow row in date.Rows)
            {
                string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "' and   NEW_GROUP_INDEX_NO = '" + row["NEW_GROUP_INDEX_NO"].ToString() + "'";
                //string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "'";
                DataRow[] rows = result.Select(SelectSql);
                if (rows != null && rows.Length > 0)
                {
                    //rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                }
                else
                {
                    DataRow newRow = result.NewRow();
                    newRow["GROUP_INDEX"] = row["GROUP_INDEX"];
                    newRow["BATCH_ID"] = row["BATCH_ID"];
                    newRow["NEW_GROUP_INDEX_NO"] = row["NEW_GROUP_INDEX_NO"];
                    newRow["ISPRINT"] = row["ISPRINT"];
                    result.Rows.Add(newRow);
                }
            }
            DataTable dt = this.GetDataSource(result.Select(" ISPRINT = '0' "));
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        ///设置打印瓶贴数
        /// </summary>
        private void GetPrintAount(DataTable date)
        {
            DataTable result = new DataTable();
            DataColumn cl1 = new DataColumn("GROUP_INDEX");
            DataColumn cl2 = new DataColumn("BATCH_ID");
            DataColumn cl3 = new DataColumn("NEW_GROUP_INDEX_NO");
            DataColumn cl4 = new DataColumn("ISPRINT");
            result.Columns.Add(cl1);
            result.Columns.Add(cl2);
            result.Columns.Add(cl3);
            result.Columns.Add(cl4);
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                foreach (DataRow row in date.Rows)
                {
                    string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "' and   NEW_GROUP_INDEX_NO = '" + row["NEW_GROUP_INDEX_NO"].ToString() + "'";
                    DataRow[] rows = result.Select(SelectSql);
                    if (rows != null && rows.Length > 0)
                    {
                        //rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
                    }
                    else
                    {
                        DataRow newRow = result.NewRow();
                        newRow["GROUP_INDEX"] = row["GROUP_INDEX"];
                        newRow["BATCH_ID"] = row["BATCH_ID"];
                        newRow["NEW_GROUP_INDEX_NO"] = row["NEW_GROUP_INDEX_NO"];
                        newRow["ISPRINT"] = row["ISPRINT"];
                        result.Rows.Add(newRow);
                    }
                }
            }

            this.AllLabelAcount = int.Parse(result.Rows.Count.ToString());
            this.YESLabelAcount = int.Parse(result.Select(" ISPRINT = '1' ").Length.ToString());
            this.NOLabelAcount = int.Parse(result.Select(" ISPRINT = '0' ").Length.ToString());
        }

        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 获取需要的页数的药品数据
        /// </summary>
        /// <param name="nowCount"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] LabelDetails, int nowCount)
        {
            if (LabelDetails != null && LabelDetails.Length != 0)
            {
                DataTable result = LabelDetails[0].Table.Clone();
                for (int i = (nowCount - 1) * 4; i < nowCount * 4; i++)
                {
                    DataRow row = result.NewRow();
                    if (i < LabelDetails.Length)
                    {
                        row.ItemArray = LabelDetails[i].ItemArray;
                    }
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// DATA 加 row
        /// </summary>
        /// <param name="nowCount"></param>
        /// <returns></returns>
        private void DataAddRow(DataTable tabel, DataRow[] rows)
        {
            if (rows != null && rows.Length != 0)
            {
                foreach (DataRow row in rows)
                {
                    DataRow nowRow = tabel.NewRow();
                    nowRow.ItemArray = row.ItemArray;
                    tabel.Rows.Add(nowRow);
                }
            }
        }

        /// <summary>
        /// 获取选择的批次
        /// </summary>
        /// <returns></returns>
        private string GetSelectBatch()
        {
            StringBuilder selectBatch = new StringBuilder("");
            bool selectAll = true;
            if (CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        selectBatch.Append(a.Description.ToString() + ",");
                    }
                    else
                    {
                        selectAll = false;
                    }
                }
                if (selectAll)
                {
                    return "全部批次";
                }
                if (selectBatch.Length != 0)
                {
                    selectBatch.Remove(selectBatch.Length - 1, 1);
                    return selectBatch.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 冲药
        /// </summary>
        private bool SendPharm(string GroupIndex, string LabelId, DateTime date)
        {
            if ((bool)this.OnFeeTIME("1000501"))//查询当前是否需要扣除费用
            {
                int times = int.Parse(this.OnLabelIsFee(LabelId).ToString());
                if (times != 0)
                {
                    string flag = this.OnPharmFee(GroupIndex, date, times).ToString();
                    if (flag != "Successed")
                    {
                        if (CJia.PIVAS.Models.PIVASModel.GetParameters("1000000002") == "0")
                        {
                            if (Message.ShowQuery("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag + "！是否继续打印该瓶贴！", Message.Button.YesNo) == Message.Result.Yes)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            Message.Show("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag + "！无法继续打印该瓶贴！");
                            return false;
                        }
                    }
                    else
                    {
                        this.OnUpdateLabelExeStatus(LabelId);
                        return true;
                    }
                }
                else
                {
                    this.OnUpdateLabelExeStatus(LabelId);
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 初始化病人过滤窗体
        /// </summary>
        private void InitPatient()
        {
            DataTable labelData = this.LabelDetail;
            labelData.DefaultView.Sort = "ILLFIELD_NAME ASC ,BED_NAME ASC";
            labelData = labelData.DefaultView.ToTable();
            Dictionary<string, string> patientData = new Dictionary<string, string>();
            if (labelData != null && labelData.Rows != null && labelData.Rows.Count > 0)
            {
                foreach (DataRow row in labelData.Rows)
                {
                    bool have = false;
                    foreach (string value in patientData.Values)
                    {
                        if (value == row["INHOS_ID"].ToString())
                        {
                            have = true;
                        }
                    }
                    if (!have)
                    {
                        patientData.Add(row["ILLFIELD_NAME"].ToString() + " " + row["BED_ID"].ToString() + "床 " + row["PATIENT_NAME"].ToString(), row["INHOS_ID"].ToString());
                    }
                }
            }
            this.filterPatientView.BindData(patientData);
        }

        #endregion

        #region IQueryPrintLabelView 成员


        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryArrangeEvent;

        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryLabelDetailsInfo;

        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnQueryLabelCollect;

        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnModifFilterArrange;

        public event EventHandler<Views.Label.QueryPrintLabelViewEventArgs> OnUpdateBarCode;

        public event Tools.Delegate.ResOnePar OnLabelPharmCount;



        public void ExeBindingLabelCollect(DataTable result)
        {
            throw new NotImplementedException();
        }

        public void ExeBindingArrange(DataTable result)
        {
            throw new NotImplementedException();
        }

        public void ExeBindingAlllIffieldBachLabelCollect(DataTable result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取结果中未打印的瓶贴id
        /// </summary>
        public void GetNoPrintLabelId()
        {
            this.NoPrintLabelIDList = new List<string>();
            DataTable selectData = (DataTable)this.gcLable.DataSource;
            DataTable noPrintNoSort = this.GetDataSource(selectData.Select(" ISPRINT = '0' "));
            if (noPrintNoSort != null)
            {
                noPrintNoSort.DefaultView.Sort = "ILLFIELD_ID ASC ,BATCH_ID ASC";
                DataTable noPrint = noPrintNoSort.DefaultView.ToTable();
                if (noPrint != null && noPrint.Rows != null && noPrint.Rows.Count > 0)
                {
                    foreach (DataRow row in noPrint.Rows)
                    {
                        string labelId = row["LABEL_ID"].ToString();
                        bool haveLabel = false;
                        if (this.NoPrintLabelIDList.Count > 0)
                        {
                            foreach (string labelID in this.NoPrintLabelIDList)
                            {
                                if (labelID == labelId)
                                {
                                    haveLabel = true;
                                }
                            }
                        }
                        if (!haveLabel)
                        {
                            this.NoPrintLabelIDList.Add(labelId);
                        }
                    }
                }
            }
        }


        #endregion

        private void btnFilterPharm_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow("药品筛选", filterPharmView);
            this.GetPrintAount(this.LabelDetail);
            //this.FilterPrint(this.FilterPharm(this.LabelDetail, true), true);
            this.FilterPrint(this.FilterPharm(this.NewLabelDetail, true), true);

        }



    }
}
