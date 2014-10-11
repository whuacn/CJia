using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        //初始化方法
        private void Init()
        {
            this.cbScanning.SelectedItem = "入仓扫描";
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
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
        private CJia.PIVAS.App.UI.Label.PrintLabelReport labelReport = new PrintLabelReport();

        /// <summary>
        /// 上一个键盘事件是enter
        /// </summary>
        private bool oldKeyIsEnter = false;

        /// <summary>
        /// 现在预览的条形码
        /// </summary>
        private string nowBarCode;

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


        //根据条形码返回瓶贴回调函数
        public void ExeQueryBarCodeLabel(DataTable result)
        {
            this.BarCodeLabel = result;
            if(result == null || result.Rows == null || result.Rows.Count == 0)
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

        //瓶贴列表回调函数
        public void ExeQueryLabelList(DataTable result)
        {
            this.LabelList = result;
            this.gdcLabel.DataSource = this.GetLableList();
            this.gdvLabelCollect.ExpandAllGroups();
        }

        #endregion

        #region 界面事件

        //刷新按钮单击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshLabelList();
        }

        //赛选条件改变事件
        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            //this.gdcLabel.DataSource = null;
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
            if(e.RowHandle >= 0)
            {
                string stutas = this.gdvLabelCollect.GetDataRow(e.RowHandle)["STATUS"].ToString();
                if(this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                {
                    if(stutas == "1000501")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if(stutas == "1000601")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                    else if(stutas == "1000602")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                }
                else
                {
                    if(stutas == "1000601")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if(stutas == "1000602")
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                }
            }
        }

        //瓶贴列表表格双击事件
        private void gdvLabelCollect_DoubleClick(object sender, EventArgs e)
        {
            DataRow selectRow = this.gdvLabelCollect.GetDataRow(this.gdvLabelCollect.FocusedRowHandle);
            if(selectRow != null)
            {
                CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                {
                    BarCode = selectRow["LABEL_BAR_ID"].ToString()
                };
                this.OnQueryBarCodeLabe(null, labelScanningEventArgs);
            }
            this.txbBarCode.Text = "";
        }

        //条码框键盘事件
        private void txbBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.ScenningBarCode();
                this.oldKeyIsEnter = true;
            }
            else
            {
                if(this.oldKeyIsEnter)
                {
                    this.txbBarCode.Text = "";
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
            if(this.pbLabelPreview.Image != null)
            {
                CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                {
                    BarCode = this.nowBarCode
                };
                this.OnAnewPrintLabel(null, labelScanningEventArgs);
                this.labelReport.LabelPrint();
            }
            else
            {
                MessageBox.Show("请先选择瓶贴！");
            }
        }

        #endregion

        #region 补助方法

        /// <summary>
        ///刷新瓶贴列表方法
        /// </summary>
        private void RefreshLabelList()
        {
            CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
            {
                Date = this.dtpQueryTime.Value.ToString("yyyy/MM/dd"),
                ScenningType = this.cbScanning.SelectedItem.ToString() == "入仓扫描" ? "0" : "1",
                BacthID = this.cbBatch.SelectedValue.ToString(),
                IffieldID = this.cbIffield.SelectedValue.ToString()
            };
            this.OnQueryLabeList(null, labelScanningEventArgs);
        }

        /// <summary>
        /// datarow[] 转datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable ConvertDataTable(DataRow[] rows)
        {
            if(rows == null || rows.Length == 0)
            {
                return null;
            }
            else
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
        }

        /// <summary>
        /// 根据选项过滤labellist
        /// </summary>
        /// <returns></returns>
        private DataTable GetLableList()
        {
            if(this.LabelList != null)
            {
                DataTable result = null;
                if(this.rbAll.Checked)
                {
                    result = this.LabelList;
                }
                else if(this.rbYes.Checked)
                {
                    if(this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS in (1000601,1000602) "));
                    }
                    else
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000602"));
                    }
                }
                else if(this.rbNo.Checked)
                {
                    if(this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000501"));
                    }
                    else
                    {
                        result = this.ConvertDataTable(this.LabelList.Select(" STATUS = 1000601"));
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
            for(int i = (nowCount - 1) * 4; i < nowCount * 4; i++)
            {
                DataRow row = result.NewRow();
                if(i < LabelDetails.Rows.Count)
                {
                    row.ItemArray = LabelDetails.Rows[i].ItemArray;
                }
                result.Rows.Add(row);
            }
            return result;
        }

        /// <summary>
        /// 扫描条形码
        /// </summary>
        private void ScenningBarCode()
        {
            this.lblMessage.Text = "";
            this.lblMessage.BackColor = Color.Transparent;
            this.lblMessage.Refresh();
            string barCode = this.txbBarCode.Text;
            if(barCode.Length != 10)
            {
                this.lblMessage.BackColor = Color.Red;
                this.lblMessage.Text = "条形码长度有误";
            }
            else
            {
                CJia.PIVAS.Views.Label.LabelScanningEventArgs labelScanningEventArgs = new Views.Label.LabelScanningEventArgs()
                {
                    BarCode = barCode
                };
                this.OnQueryBarCodeLabe(null, labelScanningEventArgs);
                if(this.BarCodeLabel == null || this.BarCodeLabel.Rows == null || this.BarCodeLabel.Rows.Count == 0)
                {
                    this.lblMessage.BackColor = Color.Red;
                    this.lblMessage.Text = "未找到条形码对应的瓶贴";
                }
                else
                {
                    string illfieldID = this.BarCodeLabel.Rows[0]["ILLFIELD_ID"].ToString();
                    string bacthID = this.BarCodeLabel.Rows[0]["BATCH_ID"].ToString();
                    string genDate = this.BarCodeLabel.Rows[0]["GEN_TIME"].ToString();
                    string status = this.BarCodeLabel.Rows[0]["STATUS"].ToString();
                    if(this.cbIffield.SelectedValue.ToString() != "0" && this.cbIffield.SelectedValue.ToString() != illfieldID)
                    {
                        this.lblMessage.BackColor = Color.Red;
                        this.lblMessage.Text = "瓶贴不在选定的病区内";
                    }
                    else if(this.cbBatch.SelectedValue.ToString() != "0" && this.cbBatch.SelectedValue.ToString() != bacthID)
                    {
                        this.lblMessage.BackColor = Color.Red;
                        this.lblMessage.Text = "瓶贴不在选定的批次内";
                    }
                    else if(this.dtpQueryTime.Value.ToString("yyyy/MM/dd") != genDate)
                    {
                        this.lblMessage.BackColor = Color.Red;
                        this.lblMessage.Text = "瓶贴不在选定的打印时间内";
                    }
                    else
                    {
                        if(this.cbScanning.SelectedItem.ToString() == "入仓扫描")
                        {
                            if(status == "1000501")
                            {
                                this.lblMessage.BackColor = Color.Green;
                                labelScanningEventArgs.BarCodeStatus = "1000601";
                                this.OnUpdateBarCode(null, labelScanningEventArgs);
                                this.lblMessage.Text = "瓶贴入仓扫描成功";
                                this.RefreshLabelList();
                            }
                            else if(status == "1000601")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴之前已成功入仓扫描";
                            }
                            else if(status == "1000602")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴之前已成功出仓扫描";
                            }
                            else if(status == "1000603")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴已经作废";
                            }
                            else
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "未知的瓶贴状态";
                            }
                        }
                        else
                        {
                            if(status == "1000501")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴未入仓扫描";
                            }
                            else if(status == "1000601")
                            {
                                this.lblMessage.BackColor = Color.Green;
                                labelScanningEventArgs.BarCodeStatus = "1000602";
                                this.OnUpdateBarCode(null, labelScanningEventArgs);
                                this.lblMessage.Text = "瓶贴出仓扫描成功";
                                this.RefreshLabelList();
                            }
                            else if(status == "1000602")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴之前已成功出仓扫描";
                            }
                            else if(status == "1000603")
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "瓶贴已经作废";
                            }
                            else
                            {
                                this.lblMessage.BackColor = Color.Red;
                                this.lblMessage.Text = "未知的瓶贴状态";
                            }
                        }
                    }
                }
            }
        }

        #endregion

    }
}
