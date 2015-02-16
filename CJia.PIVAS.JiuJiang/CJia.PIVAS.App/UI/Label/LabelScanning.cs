using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace CJia.PIVAS.App.UI.Label
{
    public partial class LabelScanning : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.Label.ILabelScanningView
    {
        /// <summary>
        /// 生成瓶贴用户控件构造函数
        /// </summary>
        public LabelScanning()
        {
            InitializeComponent();
            this.Init();
            this.IimitsManagement();
        }

        /// <summary>
        /// 系统类型控制
        /// </summary>
        public void IimitsManagement()
        {
            if (User.role == "0")//护士
            {

                this.cbScanning.Items.Clear();
                this.cbScanning.Items.Add("接收扫描");
                this.cbScanning.SelectedItem = "接收扫描";
                this.cbScanning.Enabled = false;


                DataTable result = new DataTable();
                result.Columns.Add("OFFICE_NAME", typeof(string));
                result.Columns.Add("OFFICE_ID", typeof(string));
                DataRow dr = result.NewRow();
                dr["OFFICE_NAME"] = CJia.PIVAS.User.DeptName;
                dr["OFFICE_ID"] = CJia.PIVAS.User.DeptId;
                result.Rows.Add(dr);

                for (int i = 0; i < result.Rows.Count; i++)
                {
                    ckceIllfield.Properties.Items.Add(result.Rows[i]["office_id"].ToString(), result.Rows[i]["office_name"].ToString(), CheckState.Checked, true);
                }

                //this.cbIffield.DataSource = result;
                //this.cbIffield.DisplayMember = "OFFICE_NAME";
                //this.cbIffield.ValueMember = "OFFICE_ID";
                //this.cbIffield.Enabled = false;

                //this.panel1.Visible = false;

                this.btnNoGroupScanning.Visible = true;
                this.btnLabelPrint.Visible = false;


                this.btnPrintLabel.Visible = false;

                this.btnDelect.Visible = false;

                this.rbAllPrint.Visible = true;

                this.rbAllPrint.Checked = true;

                this.panel4.Location = new Point(222, this.panel4.Location.Y);


                this.rbYesPrint.Font = new System.Drawing.Font("Tahoma", 15F);
                this.rbYesPrint.ForeColor = System.Drawing.Color.Black;
                this.rbNoPrint.Font = new System.Drawing.Font("Tahoma", 15F);
                this.rbNoPrint.ForeColor = System.Drawing.Color.Black;
                this.rbAllPrint.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
                this.rbAllPrint.ForeColor = System.Drawing.Color.Blue;
            }
            if (User.role == "2")
            {
                this.rbLong.Checked = true;
                //this.rbLong.Enabled = false;
                //this.rbTemporary.Enabled = false;

                this.rbNew.Checked = true;
                this.rbNew.Enabled = false;
                this.rbOld.Enabled = false;

                this.rbYesPrint.Enabled = false;
                this.rbNoPrint.Enabled = false;
                this.rbAllPrint.Enabled = false;
                this.rbAllPrint.Visible = true;
                this.rbAllPrint.Checked = true;


                //this.cbIffield.Enabled = false;
                this.ckceIllfield.Enabled = false;
                //this.cbBatch.Enabled = false;
                this.ckceBatch.Enabled = false;
                this.cbScanning.Enabled = false;
                this.dtpStartTime.Value = Sysdate;
                this.dtpStartTime.Enabled = false;
                this.panel4.Location = new Point(222, this.panel4.Location.Y);
                this.btnNoGroupScanning.Enabled = true;

                this.groupControl1.Enabled = false;
                this.groupControl7.Enabled = false;
            }
            if (User.role == "1")
            {
                this.panel4.Location = new Point(222, this.panel4.Location.Y);
                this.rbAllPrint.Visible = true;
            }
            //ControlCheck();
        }

        //初始化方法
        private void Init()
        {
            this.cbScanning.SelectedItem = "入仓扫描";
            this.dtpStartTime.Value = Sysdate;
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
            this.txtSpeak.Text = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Speak");
        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.LabelScenningPresenter(this);
        }

        /// <summary>
        /// 瓶贴列表
        /// </summary>
        private DataTable LabelList = null;

        /// <summary>
        /// 单个条形码对应的瓶贴信息
        /// </summary>
        private DataTable BarCodeLabel = null;

        /// <summary>
        /// 当前瓶贴预览报表
        /// </summary>
        private CJia.PIVAS.App.UI.Label.SmallPrintLabelReport labelReport = new SmallPrintLabelReport();

        /// <summary>
        /// 上一个键盘事件是enter
        /// </summary>
        private bool oldKeyIsEnter = false;

        /// <summary>
        /// 现在预览的条形码
        /// </summary>
        private string nowBarCode;

        /// <summary>
        /// 医嘱状态
        /// </summary>
        private bool groupIndexStatus;

        /// <summary>
        /// 瓶贴数
        /// </summary>
        private int labelCount;

        /// <summary>
        /// 查询的瓶贴生成时间
        /// </summary>
        private string genTime
        {
            get
            {
                return this.dtpStartTime.Value.Year.ToString().PadLeft(4, '0') + "/" + this.dtpStartTime.Value.Month.ToString().PadLeft(2, '0') + "/" + this.dtpStartTime.Value.Day.ToString().PadLeft(2, '0');
            }
        }

        #region ILabelScanning 成员

        //初始化病区事件
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnInitIffield;

        //初始化批次事件
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnInitBacth;

        //根据条形码返回瓶贴信息
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnQueryBarCodeLabe;

        //查询瓶贴列表
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnQueryLabeList;

        //修改瓶贴状态
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnUpdateBarCode;

        //从新打印瓶贴
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnAnewPrintLabel;

        //查询瓶贴对应的医嘱有效状态
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnQueryLabelGroupIndex;

        //作废瓶贴
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnDelectPrindedLabel;

        //打印瓶贴明细
        public event EventHandler<Views.Label.LabelScanningEventArgs> OnPrindedLabelDetail;

        //打印瓶贴明细
        public void ExePrintLabelDetail(DataTable result)
        {
            if (result != null && result.Rows != null && result.Rows.Count > 0)
            {
                result.Columns.Add(new DataColumn("BATCH_LABEL_COUNT", typeof(int))
                {
                    DefaultValue = 0
                });
                result.Columns.Add(new DataColumn("PATIENT_LABEL_COUNT", typeof(int))
                {
                    DefaultValue = 0
                });
                List<string> labelBarIdList = new List<string>();
                foreach (DataRow row in result.Rows)
                {
                    string labelBarId = row["LABEL_BAR_ID"].ToString();
                    if (labelBarIdList.FindAll(t => t == labelBarId).Count == 0)
                    {
                        labelBarIdList.Add(labelBarId);
                        DataRow[] batchRows = result.Select(" BATCH_ID = '" + row["BATCH_ID"].ToString() + "'");
                        DataRow[] patientRows = result.Select(" BATCH_ID = '" + row["BATCH_ID"].ToString() + "' AND INHOS_ID = '" + row["INHOS_ID"].ToString() + "'");
                        foreach (DataRow batchRow in batchRows)
                        {
                            string batchLabelCount = batchRow["BATCH_LABEL_COUNT"].ToString();
                            if (batchLabelCount == "")
                            {
                                batchLabelCount = "0";
                            }
                            batchRow["BATCH_LABEL_COUNT"] = Convert.ToInt32(batchLabelCount) + 1;
                        }
                        foreach (DataRow patientRow in patientRows)
                        {
                            string patientLabelCount = patientRow["PATIENT_LABEL_COUNT"].ToString();
                            if (patientLabelCount == "")
                            {
                                patientLabelCount = "0";
                            }
                            patientRow["PATIENT_LABEL_COUNT"] = Convert.ToInt32(patientLabelCount) + 1;
                        }
                    }
                }
                CJia.PIVAS.App.UI.Label.LabelDetailReport labelDetailReport = new LabelDetailReport();
                string str = "";
                if (this.rbLong.Checked)
                {
                    str = "长期 ";
                }
                else
                {
                    str = "临时 ";
                }
                if (this.rbAllPrint.Checked)
                {
                    str += "";
                }
                else if (this.rbYesPrint.Checked)
                {
                    str += "配置 ";
                }
                else if (this.rbNoPrint.Checked)
                {
                    str += "单组 ";
                }

                labelDetailReport.DataBind(str, result, this.dtpStartTime.Value.ToShortDateString(), Sysdate.ToString(), labelBarIdList.Count);
            }
            else
            {
                Message.Show("没有瓶贴！");
            }
        }

        //修改瓶贴冲药状态
        public event Tools.Delegate.NoResOnePar OnUpdateLabelExeStatus;

        //获取扣费时间
        public event Tools.Delegate.ResOnePar OnFeeTIME;

        // 获取扣费时间
        public event CJia.PIVAS.Tools.Delegate.ResOnePar OnCancelFeeTIME;

        //扣费扣库存
        public event Tools.Delegate.ResThreePar OnPharmFee;

        // 退费退库存
        public event Tools.Delegate.ResThreePar OnCancelPharmFee;

        // 查询瓶贴计费次数
        public event Tools.Delegate.ResOnePar OnLabelIsFee;

        //查询瓶贴对应的医嘱有效状态对调方法
        public void ExeQueryLabelGroupIndex(bool result)
        {
            this.groupIndexStatus = result;
        }


        //根据条形码返回瓶贴回调函数
        public void ExeQueryBarCodeLabel(DataTable result)
        {
            if (this.pbLabelPreview.Image != null)
            {
                this.pbLabelPreview.Image.Dispose();
            }
            this.BarCodeLabel = result;
            if (result == null || result.Rows == null || result.Rows.Count == 0)
            {
                this.pbLabelPreview.Image = null;
            }
            else
            {
                int allLabelCount = (result.Rows.Count - 1) / 4 + 1;
                DataTable reportDataSource = this.GetDataSource(result, int.Parse(result.Rows[0]["LABEL_PAGE_NO"].ToString()));
                string labelBarCode = result.Rows[0]["LABEL_BAR_ID"].ToString();
                this.nowBarCode = labelBarCode;
                DateTime GenDate = (DateTime)result.Rows[0]["GEN_DATE"];
                this.labelReport.DataBind(reportDataSource, allLabelCount, int.Parse(result.Rows[0]["LABEL_PAGE_NO"].ToString()), labelBarCode, GenDate);
                this.pbLabelPreview.Image = this.labelReport.GenImage();
            }
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

        //瓶贴列表回调函数
        public void ExeQueryLabelList(DataTable result)
        {
            this.LabelList = result;
            this.gdcLabel.DataSource = this.GetLableList();
            this.gdvLabelCollect.ExpandAllGroups();
            this.RefresLabelCount();
        }

        #endregion

        #region 界面事件


        //打印瓶贴明细
        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs();
            labelScanningEventArgs.longTemporary = this.rbLong.Checked ? "1" : "0";
            if (this.rbYesPrint.Checked)
            {
                labelScanningEventArgs.LabelStype = "1";
            }
            else if (this.rbNoPrint.Checked)
            {
                labelScanningEventArgs.LabelStype = "0";
            }
            else
            {
                labelScanningEventArgs.LabelStype = "10";
            }
            if (this.rbNew.Checked)
            {
                labelScanningEventArgs.grOrDr = "0";
            }
            else
            {
                labelScanningEventArgs.grOrDr = "1";
            }
            labelScanningEventArgs.dataTime = this.dtpStartTime.Value;
            //labelScanningEventArgs.IffieldID = this.cbIffield.SelectedValue.ToString();
            //labelScanningEventArgs.BacthID = this.cbBatch.SelectedValue.ToString();
            //add by lp
            string strIllfield = "";
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            if (strIllfield == "")
            {
                labelScanningEventArgs.IffieldID = "''";
            }
            else
            {
                labelScanningEventArgs.IffieldID = strIllfield.Substring(0, strIllfield.Length - 1);
            }

            string strBatch = "";
            foreach (string illList in ckceBatch.Properties.Items.GetCheckedValues())
            {
                strBatch += illList + ",";
            }
            if (strBatch == "")
            {
                labelScanningEventArgs.BacthID = "''";
            }
            else
            {
                labelScanningEventArgs.BacthID = strBatch.Substring(0, strBatch.Length - 1);
            }

            //end
            this.OnPrindedLabelDetail(null, labelScanningEventArgs);
        }

        //刷新按钮单击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshLabelList();
        }

        //赛选条件改变事件
        private void Filter_ValueChanged(object sender, EventArgs e)
        {
        }

        //扫描未扫描单选框改变
        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            this.gdcLabel.DataSource = this.GetLableList();
            this.gdvLabelCollect.ExpandAllGroups();
        }

        //瓶贴列表表格绑定事件
        private void gdvLabelCollect_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string stutas = this.gdvLabelCollect.GetDataRow(e.RowHandle)["STATUS"].ToString();
                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    if (stutas == "1000501")
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                    else if (stutas == "1000601")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                    else if (stutas == "1000602")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                    else if (stutas == "1000605")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                }
                else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                {
                    if (stutas == "1000601")
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                    else if (stutas == "1000602")
                    {
                        e.Appearance.BackColor = Color.SlateBlue;
                    }
                    else if (stutas == "1000605")
                    {
                        e.Appearance.BackColor = Color.SlateBlue;
                    }
                }
                else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                {
                    if (stutas == "1000602")
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                    else if (stutas == "1000605")
                    {
                        e.Appearance.BackColor = Color.SlateBlue;
                    }
                }
            }
        }

        //瓶贴列表表格双击事件
        private void gdvLabelCollect_DoubleClick(object sender, EventArgs e)
        {
            DataRow selectRow = this.gdvLabelCollect.GetFocusedDataRow();
            //if(selectRow != null)
            //{
            //    CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
            //    {
            //        BarCode = selectRow["LABEL_BAR_ID"].ToString()
            //    };
            //    this.OnQueryBarCodeLabe(null, labelScanningEventArgs);
            //}
            if (selectRow != null)
            {
                this.txbBarCode.Text = selectRow["LABEL_BAR_ID"].ToString();
                this.txtPrintDarCode.Text = selectRow["LABEL_BAR_ID"].ToString();
                this.SelectLabel();
            }
        }

        //扫面条码框键盘事件
        private void txbBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ScenningBarCode();
                this.oldKeyIsEnter = true;
            }
            else
            {
                if (this.oldKeyIsEnter)
                {
                    this.txbBarCode.Text = "";
                }
                this.oldKeyIsEnter = false;
            }
        }

        //查询条形码键盘事件
        private void txtPrintDarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.SelectLabel();
                this.oldKeyIsEnter = true;
            }
            else
            {
                if (this.oldKeyIsEnter)
                {
                    this.txtPrintDarCode.Text = "";
                }
                this.oldKeyIsEnter = false;
            }
        }


        //扫描按钮单击事件
        private void btnScenning_Click(object sender, EventArgs e)
        {
            this.ScenningBarCode();
        }

        //瓶贴重新打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.pbLabelPreview.Image != null)
            {
                if (Message.ShowQuery("本操作将把该瓶贴作废！而且   会   从新打印一张一样的瓶贴！") == Message.Result.Ok)
                {
                    CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                    {
                        BarCode = this.nowBarCode
                    };
                    this.OnAnewPrintLabel(null, labelScanningEventArgs);
                    this.labelReport.LabelPrint();
                    this.RefreshLabelList();
                }
            }
            else
            {
                Message.Show("请先选择瓶贴！");
            }
        }

        //拼贴作废
        private void btnDelect_Click(object sender, EventArgs e)
        {
            if (this.pbLabelPreview.Image != null)
            {
                if (Message.ShowQuery("本操作将把该瓶贴作废！而且   不会   从新打印一张一样的瓶贴！") == Message.Result.Ok)
                {
                    string groupIndex = this.BarCodeLabel.Rows[0]["GROUP_INDEX"].ToString();
                    string labelId = this.BarCodeLabel.Rows[0]["LABEL_ID"].ToString();
                    if (this.CancelPharm(groupIndex, labelId, this.BarCodeLabel.Rows[0]["STATUS"].ToString()))
                    {
                        CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                        {
                            BarCode = this.nowBarCode
                        };
                        this.OnDelectPrindedLabel(null, labelScanningEventArgs);
                        this.pbLabelPreview.Image = null;
                        Message.Show("瓶贴作废成功！");
                    }
                    this.RefreshLabelList();
                }
            }
            else
            {
                Message.Show("请先选择瓶贴！");
            }

        }


        //语音提示信息修改
        private void txtSpeak_TextChanged(object sender, EventArgs e)
        {
            CJia.PIVAS.Tools.ConfigHelper.UpdateAppStrings("Speak", this.txtSpeak.Text);
        }

        //查询按钮单击事件
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.SelectLabel();
        }

        //直接扫描瓶贴
        private void btnNoGroupScanning_Click(object sender, EventArgs e)
        {
            if (User.role == "2")//简单药师
            {
                this.Print();
                this.cbScanning.SelectedItem = "出仓扫描";
                this.Print();
            }
            else
            {
                this.Print();
            }
        }

        private void Print()
        {
            this.RefreshLabelList();
            //DataTable noGroup = this.ConvertDataTable(this.LabelList.Select(" IS_GROUP = '0' "));
            DataTable noGroup = this.LabelList;
            if (noGroup != null && noGroup.Rows != null && noGroup.Rows.Count > 0)
            {
                DataTable noScanning = new DataTable();
                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    noScanning = this.ConvertDataTable(noGroup.Select(" STATUS =  1000501 "));
                }
                if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                {
                    noScanning = this.ConvertDataTable(noGroup.Select(" STATUS =  1000601 "));
                }
                this.cbSpeak.Checked = false;
                if (noScanning != null && noScanning.Rows != null && noScanning.Rows.Count > 0)
                {
                    foreach (DataRow row in noScanning.Rows)
                    {
                        this.txbBarCode.Text = row["LABEL_BAR_ID"].ToString();
                        this.ScenningBarCode();
                        //if(this.lblMessage.Text != "扫描成功")
                        //{
                        //    break;
                        //}
                    }
                }
                else
                {
                    Message.Show("无未扫描的瓶贴");
                }
            }
            else
            {
                Message.Show("无未扫描的瓶贴");
            }
            this.cbSpeak.Checked = true;
        }

        /// <summary>
        /// 配置与单组切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_CheckedChanged(object sender, EventArgs e)
        {
            //this.btnNoGroupScanning.Enabled = this.rbNoPrint.Checked;
            this.rbYesPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbYesPrint.ForeColor = System.Drawing.Color.Black;
            this.rbNoPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbNoPrint.ForeColor = System.Drawing.Color.Black;
            this.rbAllPrint.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbAllPrint.ForeColor = System.Drawing.Color.Black;
            ((RadioButton)sender).Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Blue;

            //ControlCheck();
        }

        /// <summary>
        /// 当日 隔日切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbOldNew_CheckedChanged(object sender, EventArgs e)
        {
            this.rbNew.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbNew.ForeColor = System.Drawing.Color.Black;
            this.rbOld.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbOld.ForeColor = System.Drawing.Color.Black;
            ((RadioButton)sender).Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Green;

            //ControlCheck();
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
                this.rbOld.Checked = true;
                this.rbNew.Checked = false;
                this.dtpStartTime.Value = Sysdate;
            }
            else
            {
                //this.cbBatch.Enabled = false;
                this.ckceBatch.Enabled = false;
                this.rbOld.Checked = false;
                this.rbNew.Checked = true;
                //this.cbBatch.SelectedValue = 0;
                this.dtpStartTime.Value = Sysdate;
            }

            //if(User.role == "2")
            //{
            //    this.rbNew.Checked = true;
            //    this.rbNew.Enabled = false;
            //    this.rbOld.Enabled = false;

            //    this.cbIffield.Enabled = false;
            //    this.cbBatch.Enabled = false;
            //    this.dtpStartTime.Value = Sysdate;
            //    this.dtpStartTime.Enabled = false;

            //}
            //ControlCheck();

        }

        #endregion

        #region 补助方法

        /// <summary>
        /// 刷新瓶贴数目统计方法
        /// </summary>
        private void RefresLabelCount()
        {
            if (this.LabelList != null && this.LabelList.Rows != null && this.LabelList.Rows.Count != 0)
            {
                DataTable result = null;
                this.rbAll.Text = "全部(" + this.LabelList.Rows.Count + ")";
                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000601,1000602,1000605) "));
                }
                else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000602,1000605)"));
                }
                else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000605)"));
                }

                if (result != null)
                {
                    this.rbYes.Text = "已扫描(" + result.Rows.Count + ")";
                }
                else
                {
                    this.rbYes.Text = "已扫描(0)";
                }

                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000501 "));
                }
                else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000601  "));
                }
                else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                {
                    result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000602 "));
                }
                if (result != null)
                {
                    this.rbNo.Text = "未扫描(" + result.Rows.Count + ")";
                }
                else
                {
                    this.rbNo.Text = "未扫描(0)";
                }
            }
            else
            {
                this.rbAll.Text = "全部(0)";
                this.rbYes.Text = "已扫描(0)";
                this.rbNo.Text = "未扫描(0)";
            }
        }

        /// <summary>
        ///刷新瓶贴列表方法
        /// </summary>
        private void RefreshLabelList()
        {
            HelperTools.GridViewLocationcs gridViewLocationcs = new HelperTools.GridViewLocationcs(this.gdvLabelCollect);
            gridViewLocationcs.GetLocation();
            CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
            {
                Date = this.genTime,
                //BacthID = this.cbBatch.SelectedValue.ToString(),
                //IffieldID = this.cbIffield.SelectedValue.ToString(),
                longTemporary = this.rbLong.Checked ? "1" : "0"
            };
            //add by lp
            string strIllfield = "";
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            if (strIllfield == "")
            {
                labelScanningEventArgs.IffieldID = "''";
            }
            else
            {
                labelScanningEventArgs.IffieldID = strIllfield.Substring(0, strIllfield.Length - 1);
            }

            string strBatch = "";
            string longTemporary = this.rbLong.Checked ? "1" : "0";
            if (longTemporary == "1")
            {
                foreach (string illList in ckceBatch.Properties.Items.GetCheckedValues())
                {
                    strBatch += illList + ",";
                }
                if (strBatch == "")
                {
                    labelScanningEventArgs.BacthID = "''";
                }
                else
                {
                    labelScanningEventArgs.BacthID = strBatch.Substring(0, strBatch.Length - 1);
                }
            }
            else
            {
                labelScanningEventArgs.BacthID = "1000000005";
            }
            //end

            if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
            {
                labelScanningEventArgs.ScenningType = "1000601";
            }
            else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
            {
                labelScanningEventArgs.ScenningType = "1000602";
            }
            else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
            {
                labelScanningEventArgs.ScenningType = "1000605";
            }
            //if(User.role == "0")//护士
            //{
            //    labelScanningEventArgs.LabelStype = "10";
            //}
            //else
            //{
            //    labelScanningEventArgs.LabelStype = this.rbYesPrint.Checked ? "1" : "0";
            //}
            if (this.rbYesPrint.Checked)
            {
                labelScanningEventArgs.LabelStype = "1";
            }
            else if (this.rbNoPrint.Checked)
            {
                labelScanningEventArgs.LabelStype = "0";
            }
            else
            {
                labelScanningEventArgs.LabelStype = "10";
            }
            if (this.rbNew.Checked)
            {
                labelScanningEventArgs.grOrDr = "0";
            }
            else
            {
                labelScanningEventArgs.grOrDr = "1";
            }



            this.OnQueryLabeList(null, labelScanningEventArgs);
            gridViewLocationcs.SetLocation();
        }

        /// <summary>
        /// datarow[] 转datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable ConvertDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0)
            {
                return null;
            }
            else
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
        }

        /// <summary>
        /// 根据选项过滤labellist
        /// </summary>
        /// <returns></returns>
        private DataTable GetLableList()
        {
            if (this.LabelList != null)
            {
                DataTable result = null;
                if (this.rbAll.Checked)
                {
                    result = this.LabelList;
                }
                else if (this.rbYes.Checked)
                {
                    if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000601,1000602,1000605) "));
                    }
                    else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000602,1000605)"));
                    }
                    else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000605"));
                    }
                }
                else if (this.rbNo.Checked)
                {
                    if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000501"));
                    }
                    else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000601"));
                    }
                    else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000602"));
                    }
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
        private DataTable GetDataSource(DataTable LabelDetails, int nowCount)
        {
            DataTable result = LabelDetails.Clone();
            for (int i = (nowCount - 1) * 4; i < nowCount * 4; i++)
            {
                DataRow row = result.NewRow();
                if (i < LabelDetails.Rows.Count)
                {
                    row.ItemArray = LabelDetails.Rows[i].ItemArray;
                }
                result.Rows.Add(row);
            }
            return result;
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
        /// 扫描条形码
        /// </summary>
        private void ScenningBarCode()
        {
            this.lblMessage.Text = "";
            this.lblMessage.BackColor = Color.Transparent;
            this.lblMessage.Refresh();
            string barCode = this.txbBarCode.Text.Trim();

            //add by lp
            //begin
            if (!MinLabelBarID(barCode))
            {
                return;
            }
            //end

            this.txtPrintDarCode.Text = barCode;
            if (barCode.Length != 10)
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "条形码长度有误";
            }
            else
            {
                CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                {
                    BarCode = barCode
                };
                this.OnQueryBarCodeLabe(null, labelScanningEventArgs);
                this.OnQueryLabelGroupIndex(null, labelScanningEventArgs);
                if (this.BarCodeLabel == null || this.BarCodeLabel.Rows == null || this.BarCodeLabel.Rows.Count == 0)
                {
                    this.lblMessage.BackColor = Color.LightGray;
                    this.lblMessage.ForeColor = Color.Red;
                    this.lblMessage.Text = "未找到对应的瓶贴";
                }
                else
                {
                    if (!this.groupIndexStatus)
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "医嘱已停用或未通过审核";


                        if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                        {
                            this.SpeakMessage("该瓶贴对应医嘱已停用是否继续扫描该瓶贴");
                            MessageBoxView messageBoxView = new MessageBoxView("该瓶贴对应医嘱已停用是否继续扫描该瓶贴？");
                            this.ShowAsWindow("警告", messageBoxView);
                            if (messageBoxView.SelectValue)
                            {
                                this.Scanning();
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        //if(Message.ShowQuery("该瓶贴对应医嘱已停用是否继续扫描该瓶贴？", Message.Button.YesNo) == Message.Result.Yes)
                        //{
                        //    this.Scanning();
                        //}
                        //else
                        //{
                        //    return;
                        //}
                    }
                    this.Scanning();
                }
            }
        }

        /// <summary>
        /// 扫描瓶贴
        /// </summary>
        private void Scanning()
        {
            string barCode = this.txbBarCode.Text.Trim();
            CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
            {
                BarCode = barCode
            };
            string illfieldID = this.BarCodeLabel.Rows[0]["ILLFIELD_ID"].ToString();
            string illFieldName = this.BarCodeLabel.Rows[0]["ILLFIELD"].ToString();
            string bacthID = this.BarCodeLabel.Rows[0]["BATCH_ID"].ToString();
            string batchName = this.BarCodeLabel.Rows[0]["BATCH_NAME"].ToString();
            string genDate = this.BarCodeLabel.Rows[0]["GEN_TIME"].ToString();
            string status = this.BarCodeLabel.Rows[0]["STATUS"].ToString();

            if (!this.ckceIllfield.Text.Contains(illFieldName))
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "不在选定的病区内";
            }
            else if (!this.ckceBatch.Text.Contains(batchName))
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "不在选定的批次内";
            }
            //if (false)
            //{
            //}
            else
            {
                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    if (status == "1000501")
                    {
                        string groupIndex = this.BarCodeLabel.Rows[0]["GROUP_INDEX"].ToString();
                        string labelId = this.BarCodeLabel.Rows[0]["LABEL_ID"].ToString();
                        if (this.SendPharm(groupIndex, labelId, "1000601"))
                        {
                            this.lblMessage.BackColor = Color.Green;
                            this.lblMessage.ForeColor = Color.White;
                            labelScanningEventArgs.BarCodeStatus = "1000601";
                            this.OnUpdateBarCode(null, labelScanningEventArgs);
                            this.lblMessage.Text = "扫描成功";
                        }
                        this.RefreshLabelList();
                    }
                    else if (status == "1000601")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "之前已入仓扫描";
                    }
                    else if (status == "1000602")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "之前已出仓扫描";
                    }
                    else if (status == "1000603")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "已作废";
                    }
                    else
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未知的状态";
                    }
                }
                else if (this.cbScanning.SelectedItem.ToString() == "出仓扫描")
                {
                    if (status == "1000501")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未入仓扫描";
                    }
                    else if (status == "1000601")
                    {
                        string groupIndex = this.BarCodeLabel.Rows[0]["GROUP_INDEX"].ToString();
                        string labelId = this.BarCodeLabel.Rows[0]["LABEL_ID"].ToString();
                        if (this.SendPharm(groupIndex, labelId, "1000602"))
                        {
                            this.lblMessage.BackColor = Color.SlateBlue;
                            this.lblMessage.ForeColor = Color.White;
                            labelScanningEventArgs.BarCodeStatus = "1000602";
                            this.OnUpdateBarCode(null, labelScanningEventArgs);
                            this.lblMessage.Text = "扫描成功";
                        }
                        this.RefreshLabelList();
                    }
                    else if (status == "1000602")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "之前已成功出仓扫描";
                    }
                    else if (status == "1000603")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "已作废";
                    }
                    else
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未知的状态";
                    }
                }
                else if (this.cbScanning.SelectedItem.ToString() == "接收扫描")
                {
                    if (status == "1000501")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未入仓扫描";
                    }
                    else if (status == "1000601")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未出仓扫描";
                    }
                    else if (status == "1000602")
                    {
                        string groupIndex = this.BarCodeLabel.Rows[0]["GROUP_INDEX"].ToString();
                        string labelId = this.BarCodeLabel.Rows[0]["LABEL_ID"].ToString();
                        if (this.SendPharm(groupIndex, labelId, "1000605"))
                        {
                            this.lblMessage.BackColor = Color.SlateBlue;
                            this.lblMessage.ForeColor = Color.White;
                            labelScanningEventArgs.BarCodeStatus = "1000605";
                            this.OnUpdateBarCode(null, labelScanningEventArgs);
                            this.lblMessage.Text = "扫描成功";
                        }
                        this.RefreshLabelList();
                    }
                    else if (status == "1000603")
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "之前已成功接收扫描";
                    }
                    else
                    {
                        this.lblMessage.BackColor = Color.LightGray;
                        this.lblMessage.ForeColor = Color.Red;
                        this.lblMessage.Text = "未知的状态";
                    }
                }
            }
            //if(this.cbScanning.SelectedItem.ToString() == "出仓扫描" && this.lblMessage.Text == "扫描成功")
            //{
            //    string groupIndex =  this.BarCodeLabel.Rows[0]["GROUP_INDEX"].ToString();
            //    string labelId = this.BarCodeLabel.Rows[0]["LABEL_ID"].ToString();
            //    this.SendPharm(groupIndex, labelId);
            //}
            if (this.cbSpeak.Checked)
            {
                if (this.lblMessage.Text == "扫描成功")
                {
                    this.SpeakMessage(this.txtSpeak.Text);
                }
                else
                {
                    this.SpeakMessage(this.lblMessage.Text);
                }
            }
        }


        /// <summary>
        /// 朗读语音提示信息
        /// </summary>
        /// <param name="text"></param>
        private void SpeakMessage(string text)
        {
            try
            {
                SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                SpVoice Voice = new SpVoice();
                Voice.Rate = 2;
                Voice.Speak(text, SpFlags);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 查询条形码对应的瓶贴
        /// </summary>
        private void SelectLabel()
        {
            this.lblMessage.Text = "";
            this.lblMessage.BackColor = Color.Transparent;
            this.lblMessage.Refresh();
            string barCode = this.txtPrintDarCode.Text.Trim();
            this.txbBarCode.Text = barCode;
            if (barCode.Length != 10)
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "条形码长度有误";
            }
            CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
            {
                BarCode = barCode
            };
            this.OnQueryBarCodeLabe(null, labelScanningEventArgs);
            if (this.BarCodeLabel == null || this.BarCodeLabel.Rows == null || this.BarCodeLabel.Rows.Count == 0)
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "未找到对应的瓶贴";
            }
            else
            {
                this.lblMessage.BackColor = Color.Green;
                this.lblMessage.ForeColor = Color.White;
                this.lblMessage.Text = "查询成功";
            }
            if (this.lblMessage.BackColor == Color.Green)
            {
                if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    this.lblMessage.BackColor = Color.Green;
                }
                else
                {
                    this.lblMessage.BackColor = Color.SlateBlue;
                }
            }
        }

        /// <summary>
        /// 扣费
        /// </summary>
        /// <param name="GroupIndex"></param>
        private bool SendPharm(string GroupIndex, string labelId, string status)
        {
            if ((bool)this.OnFeeTIME(status))//查询当前是否需要扣除费用
            {
                int times = int.Parse(this.OnLabelIsFee(labelId).ToString());
                if (times != 0)
                {
                    DateTime now = Sysdate;
                    string flag = this.OnPharmFee(GroupIndex, now, times).ToString();
                    if (flag != "Successed")
                    {
                        //Message.Show("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag);
                        //return false;
                        if (CJia.PIVAS.Models.PIVASModel.GetParameters("1000000002") == "0")
                        {
                            if (Message.ShowQuery("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag + "！是否继续扫描该瓶贴！", Message.Button.YesNo) == Message.Result.Yes)
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
                            Message.Show("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag + "！无法继续扫描该瓶贴！");
                            return false;
                        }
                    }
                    else
                    {
                        this.OnUpdateLabelExeStatus(labelId);
                        return true;
                    }
                }
                else
                {
                    this.OnUpdateLabelExeStatus(labelId);
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="GroupIndex"></param>
        /// <param name="labelId"></param>
        /// <param name="status"></param>
        private bool CancelPharm(string GroupIndex, string labelId, string status)
        {
            if ((bool)this.OnCancelFeeTIME(labelId))//查询当前是否能退费用
            {
                string flag = this.OnCancelPharmFee(GroupIndex, Sysdate, 1).ToString();
                if (flag != "Successed")
                {
                    Message.Show("退费时发生异常：" + flag);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 返回拆分瓶贴的第一张的条形码
        /// </summary>
        /// <param name="Label_bar_id"></param>
        private bool MinLabelBarID(string LabelBarID)
        {
            if (this.cbScanning.SelectedItem.ToString() == "入仓扫描")
            {
                string FirstLabelBarID;
                string FirstLabelStatus;
                string CurrentPage;
                string LabelPageSum;
                object[] parms = new object[] { LabelBarID };

                DataTable dt = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryFirstBarID, parms);
                string status = dt.Rows[0]["STATUS"].ToString();

                if (status == "1000601")
                {
                    this.lblMessage.BackColor = Color.LightGray;
                    this.lblMessage.ForeColor = Color.Red;
                    this.lblMessage.Text = "之前已入仓扫描";
                    if (this.cbSpeak.Checked)
                    {
                        if (this.lblMessage.Text == "扫描成功")
                        {
                            this.SpeakMessage(this.txtSpeak.Text);
                        }
                        else
                        {
                            this.SpeakMessage(this.lblMessage.Text);
                        }
                    }
                    return false;
                }


                //string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryFirstBarID, format.ToString(), labelTypeStr);

                FirstLabelBarID = dt.Rows[0]["FIRST_LABEL_BAR_ID"].ToString();
                FirstLabelStatus = dt.Rows[0]["FIRST_STATUS"].ToString();
                CurrentPage = dt.Rows[0]["PAGE_DETAIL"].ToString();
                LabelPageSum = dt.Rows[0]["LABEL_ALL_PAGE_NO"].ToString();
                if (LabelBarID != FirstLabelBarID && FirstLabelStatus == "1000501")
                {
                    MessageBox.Show("该瓶贴为拆分瓶贴的子页" + CurrentPage + "，请先扫描第一页，条码号为【" + FirstLabelBarID + "】", "警告");
                    return false;
                }//如果第一张瓶贴已扫描计费成功，则该瓶贴直接修改为成功扫描                 
                else if (LabelBarID != FirstLabelBarID && (FirstLabelStatus == "1000601" || FirstLabelStatus == "1000602"))
                {
                    MessageBox.Show("该瓶贴为拆分瓶贴的子页，第一页瓶贴已扫描，条码号为【" + FirstLabelBarID + "】", "提示信息");
                    string sql = "update GM_BARCODE set status=1000601 where LABEL_BAR_ID=?";
                    CJia.DefaultOleDb.Execute(sql, parms);
                    this.lblMessage.BackColor = Color.Green;
                    this.lblMessage.ForeColor = Color.White;
                    this.lblMessage.Text = "扫描成功";
                    if (this.cbSpeak.Checked)
                    {
                        if (this.lblMessage.Text == "扫描成功")
                        {
                            this.SpeakMessage(this.txtSpeak.Text);
                        }
                        else
                        {
                            this.SpeakMessage(this.lblMessage.Text);
                        }
                    }
                    this.RefreshLabelList();
                    return false;
                }
                else if (LabelBarID == FirstLabelBarID && int.Parse(LabelPageSum) > 1)
                {
                    MessageBox.Show("该瓶贴为拆分瓶贴的首页，共有拆分瓶贴【" + LabelPageSum + "】张", "提示信息");
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 控件控制
        private void ControlCheck()
        {
            if (this.rbNoPrint.Checked || this.rbLong.Checked && this.rbNew.Checked)
            {
                this.btnNoGroupScanning.Enabled = true;
            }
            else
            {
                this.btnNoGroupScanning.Enabled = false;
            }
        }
        #endregion


    }
}
