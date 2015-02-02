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
    public partial class SendPharmSelect : Tools.View, Views.ISendPharmSelectView
    {

        protected override object CreatePresenter()
        {
            return new Presenters.SendPharmSelectPresenter(this);
        }

        public SendPharmSelect()
        {
            InitializeComponent();
            this.Init();
        }



        #region 属性

        /// <summary>
        /// 参数
        /// </summary>
        CJia.PIVAS.Views.SendPharmSelectEventArgs sendPharmSelectEventArgs = new Views.SendPharmSelectEventArgs();

        /// <summary>
        /// 冲药明细
        /// </summary>
        DataTable SendPharmDetail = new DataTable();

        /// <summary>
        /// 冲药汇总
        /// </summary>
        DataTable SendPharmCollect = new DataTable();

        /// <summary>
        /// 虫药病床
        /// </summary>
        DataTable SendPharmPatient = new DataTable();

        /// <summary>
        /// 病区过滤
        /// </summary>
        CJia.PIVAS.App.UI.Label.FilterIllfieldView filterIllfieldView = new Label.FilterIllfieldView();

        /// <summary>
        /// 选择的药品
        /// </summary>
        List<string> selectIllfield
        {
            get
            {
                return this.filterIllfieldView.selectIllfield;
            }
        }

        /// <summary>
        /// 批次过滤
        /// </summary>
        CJia.PIVAS.App.UI.Label.FilterBatchView filterBatchView = new Label.FilterBatchView();

        /// <summary>
        /// 选择的批次
        /// </summary>
        List<string> selectBatch
        {
            get
            {
                return filterBatchView.selectBatch;
            }
        }

        /// <summary>
        /// 药品过滤
        /// </summary>
        CJia.PIVAS.App.UI.Label.FilterPharmView filterPharmView = new Label.FilterPharmView();

        /// <summary>
        /// 选择的药品
        /// </summary>
        DataTable selectPharm
        {
            get
            {
                return filterPharmView.selectPharm;
            }
        }

        /// <summary>
        /// 病人过滤
        /// </summary>
        CJia.PIVAS.App.UI.Label.NewFilterPatientView newFilterPatientView = new Label.NewFilterPatientView();

        /// <summary>
        /// 选择的药品
        /// </summary>
        DataTable selectPatient
        {
            get
            {
                return newFilterPatientView.selectPatient;
            }
        }



        #endregion

        #region 界面事件

        private void cdPrintDateTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cdPrintDateTime.Checked)
            {
                this.dtpStartTime.Enabled = true;
                this.dtpEndTime.Enabled = true;
            }
            else
            {
                this.dtpStartTime.Enabled = false;
                this.dtpEndTime.Enabled = false;
            }
        }

        private void cdZXDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cdZXDate.Checked)
            {
                this.dtpZX.Enabled = true;
            }
            else
            {
                this.dtpZX.Enabled = false;
            }
        }

        private void cdListDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cdListDate.Checked)
            {
                this.dtpListDate.Enabled = true;
            }
            else
            {
                this.dtpListDate.Enabled = false;
            }
        }

        private void LongTemporary_CheckedChanged(object sender, EventArgs e)
        {
            this.rbAllLongTemporary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbAllLongTemporary.Font = new System.Drawing.Font("Tahoma", 30F);
            this.rbLong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbLong.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbTemporary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbTemporary.Font = new System.Drawing.Font("Tahoma", 15F);
            ((RadioButton)sender).Font = new System.Drawing.Font(((RadioButton)sender).Font.FontFamily, ((RadioButton)sender).Font.Size, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Red;

            if (this.rbTemporary.Checked)
            {
                //this.cbBatch.Enabled = false;
                this.btnFilterBatch.Enabled = false;
                this.rbALLGRDR.Enabled = false;
                this.rbGR.Enabled = false;
                this.rbDR.Enabled = false;
                this.rbDR.Checked = true;
            }
            else
            {
                //this.cbBatch.Enabled = true;
                this.btnFilterBatch.Enabled = true;
                this.rbALLGRDR.Enabled = true;
                this.rbGR.Enabled = true;
                this.rbDR.Enabled = true;
            }
        }


        private void Group_CheckedChanged(object sender, EventArgs e)
        {
            this.rbAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbAll.Font = new System.Drawing.Font("Tahoma", 30F);
            this.rbYesGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbYesGroup.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbNoGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbNoGroup.Font = new System.Drawing.Font("Tahoma", 15F);
            ((RadioButton)sender).Font = new System.Drawing.Font(((RadioButton)sender).Font.FontFamily, ((RadioButton)sender).Font.Size, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Blue;
        }


        private void rbALLGRDR_CheckedChanged(object sender, EventArgs e)
        {
            this.rbALLGRDR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbALLGRDR.Font = new System.Drawing.Font("Tahoma", 30F);
            this.rbGR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbGR.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rbDR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.rbDR.Font = new System.Drawing.Font("Tahoma", 15F);
            ((RadioButton)sender).Font = new System.Drawing.Font(((RadioButton)sender).Font.FontFamily, ((RadioButton)sender).Font.Size, System.Drawing.FontStyle.Bold);
            ((RadioButton)sender).ForeColor = System.Drawing.Color.Green;


            if (this.rbGR.Checked)
            {
                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                DateTime next = now.AddDays(1);
                this.dtpStartTime.DateTime = new DateTime(now.Year, now.Month, now.Day, 14, 00, 00);
                this.dtpEndTime.DateTime = new DateTime(next.Year, next.Month, next.Day, 14, 00, 00);
            }
            if (rbDR.Checked)
            {
                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                DateTime up = now.AddDays(-1);
                this.dtpStartTime.DateTime = new DateTime(up.Year, up.Month, up.Day, 11, 30, 00);
                this.dtpEndTime.DateTime = new DateTime(now.Year, now.Month, now.Day, 11, 30, 00);
            }
            if (rbALLGRDR.Checked)
            {

            }
        }

        //刷新事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GetFilter();
            this.OnSelectLabel(null, this.sendPharmSelectEventArgs);
            this.rbAllBarStatus.Checked = true;
            this.rbAllSend.Checked = true;
            this.SendPharmCollect = this.GetPharmCollect(this.SendPharmDetail);
            this.gcPharm.DataSource = this.SendPharmCollect;
            this.filterPharmView.BindData(this.SendPharmCollect);
            this.SendPharmPatient = this.InitPatient(this.SendPharmDetail);
            this.newFilterPatientView.BindData(this.SendPharmPatient);
            DataTable labelCount = this.GetLabelCount(this.SendPharmDetail);
            this.SetLabelStatusCount(labelCount);
            this.SetSendStatusCount(labelCount);
            //this.OnSelectPharmColloet(null, this.sendPharmSelectEventArgs);
        }

        //时间控制开始不能大于结束
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (CJia.PIVAS.User.IsAdmin != "1")
            {
                if ((this.dtpEndTime.DateTime - this.dtpStartTime.DateTime).TotalDays > 2)
                {
                    this.dtpEndTime.DateTime = this.dtpStartTime.DateTime.AddDays(2);
                }
            }
            //if(this.dtpStartTime.Value > this.dtpEndTime.Value)
            //{
            //    this.dtpStartTime.Value = new DateTime(this.dtpEndTime.Value.Year, this.dtpEndTime.Value.Month, this.dtpEndTime.Value.Day, 0, 0, 0);
            //}

        }
        //时间控制结束不能大于开始
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (CJia.PIVAS.User.IsAdmin != "1")
            {
                if ((this.dtpEndTime.DateTime - this.dtpStartTime.DateTime).TotalDays > 2)
                {
                    this.dtpEndTime.DateTime = this.dtpStartTime.DateTime.AddDays(2);
                }
            }
            //if(this.dtpEndTime.Value > this.dtpStartTime.Value)
            //{
            //    this.dtpEndTime.Value = new DateTime(this.dtpStartTime.Value.Year, this.dtpStartTime.Value.Month, this.dtpStartTime.Value.Day, 23, 59, 59);
            //}

        }

        //打印冲药汇总
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.GetFilter();
            CJia.PIVAS.App.UI.SendPharmCollectReport sendPharmCollectReport = new SendPharmCollectReport();
            string isGroup = "";
            if (this.rbAll.Checked)
            {
                isGroup = "";
            }
            else if (this.rbYesGroup.Checked)
            {
                isGroup = "配置 ";
            }
            else if (this.rbNoGroup.Checked)
            {
                isGroup = "单组 ";
            }
            string longTemporary = "";
            if (this.rbAllLongTemporary.Checked)
            {
                longTemporary = "";
            }
            else if (this.rbLong.Checked)
            {
                longTemporary = "长期 ";
            }
            else
            {
                longTemporary = "临时 ";
            }

            string allDrGr = "";
            if (this.rbALLGRDR.Checked)
            {
                allDrGr = "";
            }
            else if (this.rbGR.Checked)
            {
                allDrGr = "隔日 ";
            }
            else
            {
                allDrGr = "当日 ";
            }

            bool isDY = this.cdPrintDateTime.Checked;
            string dyStart = this.dtpStartTime.DateTime.ToString();
            string dyEnd = this.dtpEndTime.DateTime.ToString();
            bool isZX = this.cdZXDate.Checked;
            string zxDate = this.dtpZX.DateTime.ToString("yyyy/MM/dd");
            bool isKD = this.cdListDate.Checked;
            string kdDate = this.dtpListDate.DateTime.ToString("yyyy/MM/dd");


            string allLabelCount = "0";
            string allPharmCount = "0";
            bool isAll = true;
            if (((DataTable)this.gcLabel.DataSource) != null && ((DataTable)this.gcLabel.DataSource).Rows != null && ((DataTable)this.gcLabel.DataSource).Rows.Count > 0)
            {
                allLabelCount = this.GetLabelCount((DataTable)this.gcLabel.DataSource).Rows.Count.ToString();
                allPharmCount = this.GetPharmCount((DataTable)this.gcPharm.DataSource).ToString();
                if (((DataTable)this.gcLabel.DataSource).Rows.Count < this.SendPharmDetail.Rows.Count)
                {
                    isAll = false;
                }
            }
            string illfieldStr = "";

            int selectedIll = ckceIllfield.Properties.Items.GetCheckedValues().Count();
            int selectall = ckceIllfield.Properties.Items.Count;
            if (selectedIll == selectall)
            {
                illfieldStr = "<全部>";
            }
            else 
            {
                illfieldStr = ckceIllfield.Text;
            }

         
            //if (filterIllfieldView.isALL)
            //{
            //    illfieldStr = "全部";
            //}
            //else
            //{
            //    if (filterIllfieldView.selectIllfieldName != null && filterIllfieldView.selectIllfieldName.Count > 0)
            //    {
            //        foreach (string illfieldName in filterIllfieldView.selectIllfieldName)
            //        {
            //            illfieldStr += illfieldName.PadRight(8, '　');
            //        }
            //    }
            //}
            string batchStr = "";
            //if (filterBatchView.isAll)
            //{
            //    batchStr = "全部";
            //}
            //else
            //{
            //    if (filterBatchView.selectBatchName != null && filterBatchView.selectBatchName.Count > 0)
            //    {
            //        for (int i = 0; i < filterBatchView.selectBatchName.Count; i++)
            //        {
            //            batchStr += filterBatchView.selectBatchName[i] + "   ";
            //        }
            //    }
            //}
            int selectedBatch = ckceBatch.Properties.Items.GetCheckedValues().Count();
            int selectAllBatch = ckceBatch.Properties.Items.Count;
            if (selectedBatch == selectAllBatch)
            {
                batchStr = "<全部>";
            }
            else
            {
                batchStr = ckceBatch.Text;
            }

            sendPharmCollectReport.DataBindDataTable((DataTable)this.gcPharm.DataSource, illfieldStr, batchStr, isDY, dyStart, dyEnd, isZX, zxDate, isKD, kdDate, allPharmCount, allLabelCount, Sysdate.ToString(), isGroup, isAll, longTemporary, allDrGr);
        }

        //打印瓶贴汇总
        private void btnPharmDetail_Click(object sender, EventArgs e)
        {
            this.GetFilter();
            this.OnSelectLabelSum(null, this.sendPharmSelectEventArgs);
            DataTable pharmData = (DataTable)this.gcLabelSum.DataSource;
            string isGroup = "";
            if (this.rbAll.Checked)
            {
                isGroup = "";
            }
            else if (this.rbYesGroup.Checked)
            {
                isGroup = "配置 ";
            }
            else if (this.rbNoGroup.Checked)
            {
                isGroup = "单组 ";
            }
            string longTemporary = "";
            if (this.rbAllLongTemporary.Checked)
            {
                longTemporary = "";
            }
            else if (this.rbLong.Checked)
            {
                longTemporary = "长期 ";
            }
            else
            {
                longTemporary = "临时 ";
            }

            string allDrGr = "";
            if (this.rbALLGRDR.Checked)
            {
                allDrGr = "";
            }
            else if (this.rbGR.Checked)
            {
                allDrGr = "隔日 ";
            }
            else
            {
                allDrGr = "当日 ";
            }

            bool isDY = this.cdPrintDateTime.Checked;
            string dyStart = this.dtpStartTime.DateTime.ToString();
            string dyEnd = this.dtpEndTime.DateTime.ToString();
            bool isZX = this.cdZXDate.Checked;
            string zxDate = this.dtpZX.DateTime.ToString("yyyy/MM/dd");
            bool isKD = this.cdListDate.Checked;
            string kdDate = this.dtpListDate.DateTime.ToString("yyyy/MM/dd");


            CJia.PIVAS.App.UI.BatchIllfieldLabelCollectReport batchIllfieldLabelCollectReport = new BatchIllfieldLabelCollectReport();
            batchIllfieldLabelCollectReport.DataBindDataTable(pharmData, isDY, dyStart, dyEnd, isZX, zxDate, isKD, kdDate, Sysdate.ToString(), isGroup, longTemporary, allDrGr);

        }

        //打印冲药明细
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            this.GetFilter();
            //this.OnSelectLabel(null, this.sendPharmSelectEventArgs);
            //this.OnSelectPharmColloet(null, this.sendPharmSelectEventArgs);
            if (this.gcLabel.DataSource != null)
            {
                DataTable result = ((DataTable)this.gcLabel.DataSource).Copy();
                result.Columns.Add(new DataColumn("ILLFIELD_LABEL_COUNT", typeof(int))
                {
                    DefaultValue = 0
                });
                result.Columns.Add(new DataColumn("BATCH_LABEL_COUNT", typeof(int))
                {
                    DefaultValue = 0
                });
                result.Columns.Add(new DataColumn("PATIENT_LABEL_COUNT", typeof(int))
                {
                    DefaultValue = 0
                });
                if (result != null && result.Rows != null && result.Rows.Count > 0)
                {
                    List<string> labelBarIdList = new List<string>();
                    foreach (DataRow row in result.Rows)
                    {
                        string labelBarId = row["LABEL_BAR_ID"].ToString();
                        if (labelBarIdList.FindAll(t => t == labelBarId).Count == 0)
                        {
                            labelBarIdList.Add(labelBarId);
                            DataRow[] illfieldRows = result.Select(" ILLFIELD_ID = '" + row["ILLFIELD_ID"].ToString() + "'");
                            DataRow[] batchRows = result.Select(" ILLFIELD_ID = '" + row["ILLFIELD_ID"].ToString() + "' AND BATCH_ID = '" + row["BATCH_ID"].ToString() + "'");
                            DataRow[] patientRows = result.Select(" ILLFIELD_ID = '" + row["ILLFIELD_ID"].ToString() + "' AND BATCH_ID = '" + row["BATCH_ID"].ToString() + "' AND INHOS_ID = '" + row["INHOS_ID"].ToString() + "'");
                            foreach (DataRow illfieldRow in illfieldRows)
                            {
                                string illfieldLabelCount = illfieldRow["ILLFIELD_LABEL_COUNT"].ToString();
                                if (illfieldLabelCount == "")
                                {
                                    illfieldLabelCount = "0";
                                }
                                illfieldRow["ILLFIELD_LABEL_COUNT"] = Convert.ToInt32(illfieldLabelCount) + 1;
                            }
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
                }
                CJia.PIVAS.App.UI.SendPharmDetailReport sendPharmDetailReport = new SendPharmDetailReport();

                string isGroup = "";
                if (this.rbAll.Checked)
                {
                    isGroup = "";
                }
                else if (this.rbYesGroup.Checked)
                {
                    isGroup = "配置 ";
                }
                else if (this.rbNoGroup.Checked)
                {
                    isGroup = "单组 ";
                }
                string longTemporary = "";
                if (this.rbAllLongTemporary.Checked)
                {
                    longTemporary = "";
                }
                else if (this.rbLong.Checked)
                {
                    longTemporary = "长期 ";
                }
                else
                {
                    longTemporary = "临时 ";
                }

                string allDrGr = "";
                if (this.rbALLGRDR.Checked)
                {
                    allDrGr = "";
                }
                else if (this.rbGR.Checked)
                {
                    allDrGr = "隔日 ";
                }
                else
                {
                    allDrGr = "当日 ";
                }

                bool isDY = this.cdPrintDateTime.Checked;
                string dyStart = this.dtpStartTime.DateTime.ToString();
                string dyEnd = this.dtpEndTime.DateTime.ToString();
                bool isZX = this.cdZXDate.Checked;
                string zxDate = this.dtpZX.DateTime.ToString("yyyy/MM/dd");
                bool isKD = this.cdListDate.Checked;
                string kdDate = this.dtpListDate.DateTime.ToString("yyyy/MM/dd");

                sendPharmDetailReport.DataBind(result, isDY, dyStart, dyEnd, isZX, zxDate, isKD, kdDate, Sysdate.ToString(), isGroup, longTemporary, allDrGr);
            }
        }

        // 获取搜索数据
        void ccsPharm_GetData(object sender, Controls.CJiaSearchEventArgs e)
        {
            CJia.PIVAS.Views.SendPharmSelectEventArgs sendPharmSelectEventArgs = new Views.SendPharmSelectEventArgs();
            sendPharmSelectEventArgs.PharmKey = e.SearchValue;
            this.OnSelectPharm(null, sendPharmSelectEventArgs);
        }

        //赛选药品单击事件
        private void btnFilterPharm_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow("药品筛选", filterPharmView);
            DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
            this.gcLabel.DataSource = labelData;
            this.gvLabel.ExpandAllGroups();
            this.gcPharm.DataSource = this.GetPharmCollect(labelData);
            DataTable labelCount = this.GetLabelCount(labelData);
            this.SetLabelStatusCount(labelCount);
            this.SetSendStatusCount(labelCount);
        }

        //赛选病人单击事件
        private void btnFilterPatient_Click(object sender, System.EventArgs e)
        {
            this.ShowAsWindow("病床筛选", newFilterPatientView);
            DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
            this.gcLabel.DataSource = labelData;
            this.gvLabel.ExpandAllGroups();
            this.gcPharm.DataSource = this.GetPharmCollect(labelData);
            DataTable labelCount = this.GetLabelCount(labelData);
            this.SetLabelStatusCount(labelCount);
            this.SetSendStatusCount(labelCount);
        }


        private void btnFilterIllfield_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow("病区赛选", filterIllfieldView);
            //DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
            //this.gcLabel.DataSource = labelData;
            //this.gvLabel.ExpandAllGroups();
            //this.gcPharm.DataSource = this.GetPharmCollect(labelData);
            //DataTable labelCount = this.GetLabelCount(labelData);
            //this.SetLabelStatusCount(labelCount);
            //this.SetSendStatusCount(labelCount);
        }

        private void btnFilterBatch_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow("批次筛选", filterBatchView);
            //DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
            //this.gcLabel.DataSource = labelData;
            //this.gvLabel.ExpandAllGroups();
            //this.gcPharm.DataSource = this.GetPharmCollect(labelData);
            //DataTable labelCount = this.GetLabelCount(labelData);
            //this.SetLabelStatusCount(labelCount);
            //this.SetSendStatusCount(labelCount);
        }

        private void BarStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
                this.gcLabel.DataSource = labelData;
                this.gvLabel.ExpandAllGroups();
                this.gcPharm.DataSource = this.GetPharmCollect(labelData);
                DataTable labelCount = this.GetLabelCount(labelData);
                //this.SetLabelStatusCount(labelCount);
                this.SetSendStatusCount(labelCount);
            }
        }

        private void Send_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DataTable labelData = this.FilterPharmPatientLabelStatusSendStatus(this.SendPharmDetail);
                this.gcLabel.DataSource = labelData;
                this.gvLabel.ExpandAllGroups();
                this.gcPharm.DataSource = this.GetPharmCollect(labelData);
                //DataTable labelCount = this.GetLabelCount(this.SendPharmDetail);
                //this.SetLabelStatusCount(labelData);
                //this.SetSendStatusCount(labelData);
            }
        }

        #endregion

        #region ISendPharmView 成员

        //初始化病区
        public event EventHandler<Views.SendPharmSelectEventArgs> OnInitIffield;

        //初始化批次
        public event EventHandler<Views.SendPharmSelectEventArgs> OnInitBacth;

        //查询瓶贴
        public event EventHandler<Views.SendPharmSelectEventArgs> OnSelectLabel;

        //查询瓶贴汇总
        public event EventHandler<Views.SendPharmSelectEventArgs> OnSelectLabelSum;

        //查询药品汇总
        public event EventHandler<Views.SendPharmSelectEventArgs> OnSelectPharmColloet;

        //查询药品
        public event EventHandler<Views.SendPharmSelectEventArgs> OnSelectPharm;

        //初始化瓶贴信息
        public void ExeInitLabel(DataTable result)
        {
            DataTable data1 = new DataTable();
            if (result != null && result.Rows != null && result.Rows.Count > 0)
            {
                if (this.rbAllLongTemporary.Checked)
                {
                    data1 = result;
                }
                else if (this.rbLong.Checked)
                {
                    data1 = this.GetDataSource(result.Select(" LONG_TIME_STATUS = '1' "));
                }
                else
                {
                    data1 = this.GetDataSource(result.Select(" LONG_TIME_STATUS = '0' "));
                }
            }
            DataTable data2 = new DataTable();
            if (data1 != null && data1.Rows != null && data1.Rows.Count > 0)
            {
                if (this.rbAll.Checked)
                {
                    data2 = data1;
                }
                else if (this.rbYesGroup.Checked)
                {
                    data2 = this.GetDataSource(data1.Select(" IS_GROUP = '1' "));

                }
                else
                {
                    data2 = this.GetDataSource(data1.Select(" IS_GROUP = '0' "));
                }
            }
            this.SendPharmDetail = data2;
            this.gcLabel.DataSource = this.SendPharmDetail;
            this.repositoryItemLookUpEdit1.DataSource = this.SendPharmDetail;
            this.gvLabel.ExpandAllGroups();
        }

        //瓶贴汇总
        public void ExeInitLabelSum(DataTable result)
        {
            this.gcLabelSum.DataSource = result;
        }

        //初始化药品汇总信息
        public void ExeInitPharmColloet(DataTable result)
        {
            this.SendPharmCollect = result;
            this.gcPharm.DataSource = this.FilterPharm();
        }

        //初始化病区回调函数
        public void ExeInitIffield(DataTable result)
        {
            //DataRow dr = result.NewRow();
            //dr["OFFICE_NAME"] = "< 全部 >";
            //dr["OFFICE_ID"] = 0;
            //result.Rows.InsertAt(dr, 0);
            //this.cbIffield.DataSource = result;
            //this.cbIffield.DisplayMember = "OFFICE_NAME";
            //this.cbIffield.ValueMember = "OFFICE_ID";

            //Dictionary<string, string> IllifeldDic = new Dictionary<string, string>();
            //if (result != null && result.Rows != null && result.Rows.Count > 0)
            //{
            //    foreach (DataRow row in result.Rows)
            //    {
            //        IllifeldDic.Add(row["OFFICE_NAME"].ToString(), row["OFFICE_ID"].ToString());
            //    }
            //}
            //if (User.Role == "0")
            //{
            //    filterIllfieldView.BindOneIllfield(IllifeldDic, User.DeptId);
            //}
            //else
            //{
            //    filterIllfieldView.BindData(IllifeldDic);
            //}

            for (int i = 0; i < result.Rows.Count; i++)
            {
                ckceIllfield.Properties.Items.Add(result.Rows[i]["office_id"].ToString(), result.Rows[i]["office_name"].ToString(), CheckState.Checked, true);

            }
        }

        //初始化批次回调函数
        public void ExeInitBacth(DataTable result)
        {
            //result = this.GetDataSource(result.Select(" BATCH_ID <> 1000000005 "));
            //DataRow dr = result.NewRow();
            //dr["BATCH_NAME"] = "< 全部 >";
            //dr["BATCH_ID"] = 0;
            //result.Rows.InsertAt(dr, 0);
            //this.cbBatch.DataSource = result;
            //this.cbBatch.DisplayMember = "BATCH_NAME";
            //this.cbBatch.ValueMember = "BATCH_ID";


            //Dictionary<string, string> batchDic = new Dictionary<string, string>();
            //if (result != null && result.Rows != null && result.Rows.Count > 0)
            //{
            //    foreach (DataRow row in result.Rows)
            //    {
            //        batchDic.Add(row["BATCH_NAME"].ToString(), row["BATCH_ID"].ToString());
            //    }
            //}
            //filterBatchView.BindData(batchDic);

            for (int i = 0; i < result.Rows.Count; i++)
            {
                ckceBatch.Properties.Items.Add(result.Rows[i]["BATCH_ID"].ToString(), result.Rows[i]["BATCH_NAME"].ToString(), CheckState.Checked, true);

            }
        }

        // 查询药品回调函数
        public void ExeSelectPharm(DataTable result)
        {
            //this.ccsPharm.DataSource = result;
        }

        #endregion

        #region 补助方法

        /// <summary>
        /// 设置瓶贴打印状态数量
        /// </summary>
        /// <param name="date"></param>
        private void SetLabelStatusCount(DataTable date)
        {
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                int all = date.Rows.Count;
                this.rbAllBarStatus.Text = "全部(" + all.ToString() + ")";
                DataTable printLabel = this.GetDataSource(date.Select(" BAR_STATUS = 1000501 "));
                int printCount = printLabel.Rows.Count;
                this.rbPrint.Text = "已打印(" + printCount.ToString() + ")";
                DataTable inLabel = this.GetDataSource(date.Select(" BAR_STATUS = 1000601 "));
                int inLabalCount = inLabel.Rows.Count;
                this.rbInScanning.Text = "已人仓(" + inLabalCount.ToString() + ")";
                DataTable outLabel = this.GetDataSource(date.Select(" BAR_STATUS = 1000602 "));
                int outLabalCount = outLabel.Rows.Count;
                this.rbOutScanning.Text = "已出仓(" + outLabalCount.ToString() + ")";
            }
            else
            {
                this.rbAllBarStatus.Text = "全部(0)";
                this.rbPrint.Text = "已打印(0)";
                this.rbInScanning.Text = "已人仓(0)";
                this.rbOutScanning.Text = "已出仓(0)";
            }
        }


        /// <summary>
        /// 设置瓶贴计费数
        /// </summary>
        /// <param name="date"></param>
        private void SetSendStatusCount(DataTable date)
        {
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                int all = date.Rows.Count;
                this.rbAllSend.Text = "全部(" + all.ToString() + ")";
                DataTable YesLabel = this.GetDataSource(date.Select(" EXE_STATUS = '1' "));
                int yesCount = YesLabel.Rows.Count;
                this.rbYesSend.Text = "已计费(" + yesCount.ToString() + ")";
                DataTable NoLabel = this.GetDataSource(date.Select(" EXE_STATUS = '0' "));
                int NoCount = NoLabel.Rows.Count;
                this.rbNoSend.Text = "未计费(" + NoCount.ToString() + ")";
            }
            else
            {
                this.rbAllSend.Text = "全部(0)";
                this.rbYesSend.Text = "已计费(0)";
                this.rbNoSend.Text = "未计费(0)";
            }
        }

        private DataTable FilterPharmPatientLabelStatusSendStatus(DataTable label)
        {
            List<string> labelIds = new List<string>();
            DataTable labelDetail = this.SendPharmDetail;
            DataTable result = labelDetail.Clone();
            if (labelDetail != null && labelDetail.Rows != null && labelDetail.Rows.Count > 0)
            {
                string selectPharmStr = " 1 = 0 ";
                if (this.selectPharm != null && this.selectPharm.Rows != null && this.selectPharm.Rows.Count > 0)
                {
                    selectPharmStr = " PHARM_ID in (";
                    foreach (DataRow pharm in this.selectPharm.Rows)
                    {
                        selectPharmStr = selectPharmStr + "'" + pharm["PHARM_ID"] + "',";
                    }
                    selectPharmStr = selectPharmStr.Substring(0, selectPharmStr.Length - 1);
                    selectPharmStr = selectPharmStr + ") ";
                }
                string selectPatientStr = " 1 = 0 ";
                if (this.selectPatient != null && this.selectPatient.Rows != null && this.selectPatient.Rows.Count > 0)
                {
                    selectPatientStr = " INHOS_ID in (";
                    foreach (DataRow patient in this.selectPatient.Rows)
                    {
                        selectPatientStr = selectPatientStr + "'" + patient["INHOS_ID"] + "',";
                    }
                    selectPatientStr = selectPatientStr.Substring(0, selectPatientStr.Length - 1);
                    selectPatientStr = selectPatientStr + ") ";
                }
                string selectStr = selectPharmStr + " and " + selectPatientStr;
                result = this.GetDataSource(labelDetail.Select(selectStr));

                DataTable newResult1 = null;
                if (result != null && result.Rows != null && result.Rows.Count > 0)
                {
                    newResult1 = result.Clone();
                    if (this.rbAllBarStatus.Checked)
                    {
                        newResult1 = result;
                    }
                    else if (this.rbPrint.Checked)
                    {
                        newResult1 = this.GetDataSource(result.Select("  BAR_STATUS = 1000501  "));
                    }
                    else if (this.rbInScanning.Checked)
                    {
                        newResult1 = this.GetDataSource(result.Select("  BAR_STATUS = 1000601  "));
                    }
                    else
                    {
                        newResult1 = this.GetDataSource(result.Select("  BAR_STATUS = 1000602  "));
                    }
                }

                DataTable newResult2 = null;
                if (newResult1 != null && newResult1.Rows != null && newResult1.Rows.Count > 0)
                {
                    newResult2 = newResult1.Clone();
                    if (this.rbAllSend.Checked)
                    {
                        newResult2 = newResult1;
                    }
                    else if (this.rbYesSend.Checked)
                    {
                        newResult2 = this.GetDataSource(newResult1.Select("  EXE_STATUS = '1'  "));
                    }
                    else
                    {
                        newResult2 = this.GetDataSource(newResult1.Select("  EXE_STATUS = '0'  "));
                    }
                }

                return newResult2;
            }
            else
            {
                return null;
            }
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
        /// 初始化病人过滤窗体
        /// </summary>
        private DataTable InitPatient(DataTable date)
        {
            DataTable labelData = date;
            if (labelData != null && labelData.Rows != null && labelData.Rows.Count > 0)
            {
                labelData.DefaultView.Sort = "ILLFIELD_NAME ASC ,BED_NAME ASC";
                labelData = labelData.DefaultView.ToTable();
            }
            DataTable patient = new DataTable();
            DataColumn col1 = new DataColumn("INHOS_ID");
            DataColumn col2 = new DataColumn("ILLFIELD_NAME");
            DataColumn col3 = new DataColumn("BED_NAME");
            DataColumn col4 = new DataColumn("PATIENT_NAME");
            patient.Columns.Add(col1);
            patient.Columns.Add(col2);
            patient.Columns.Add(col3);
            patient.Columns.Add(col4);
            if (labelData != null && labelData.Rows != null && labelData.Rows.Count > 1)
            {
                foreach (DataRow row in labelData.Rows)
                {
                    bool have = false;
                    foreach (DataRow rpatientow in patient.Rows)
                    {
                        if (rpatientow["INHOS_ID"].ToString() == row["INHOS_ID"].ToString())
                        {
                            have = true;
                        }
                    }
                    if (!have)
                    {
                        DataRow newRow = patient.NewRow();
                        newRow["INHOS_ID"] = row["INHOS_ID"];
                        newRow["ILLFIELD_NAME"] = row["ILLFIELD_NAME"];
                        newRow["BED_NAME"] = row["BED_ID"];
                        newRow["PATIENT_NAME"] = row["PATIENT_NAME"];
                        patient.Rows.Add(newRow);
                    }
                }
            }
            return patient;
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        private void Init()
        {
            DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
            DateTime next = now.AddDays(1);
            this.dtpStartTime.DateTime = new DateTime(now.Year, now.Month, now.Day, 13, 00, 00);
            this.dtpEndTime.DateTime = new DateTime(next.Year, next.Month, next.Day, 13, 00, 00);
            this.dtpZX.DateTime = now;
            this.dtpListDate.DateTime = now;
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
            //this.ccsPharm.BindTextBox = this.txtPharm;
            //this.ccsPharm.TextCels = new string[] { "PHARM_NAME", "PHARM_SPEC", "PHARM_FACTIOR" };
            //this.ccsPharm.ValueCel = "PHARM_ID";
            //this.ccsPharm.GetData += ccsPharm_GetData;
            if (User.Role == "0")
            {
                this.cdListDate.Visible = false;
                this.dtpListDate.Visible = false;
                this.cdZXDate.Visible = false;
                this.dtpZX.Visible = false;
                this.labelControl2.Visible = false;
                this.btnFilterIllfield.Visible = false;
                this.labelControl3.Visible = false;
                this.btnFilterBatch.Visible = false;

                this.btnRefresh.Location = this.cdListDate.Location;
                this.btnPharmDetail.Location = new Point(this.btnRefresh.Location.X + this.btnRefresh.Width + 20, this.btnRefresh.Location.Y);
                this.btnPrintLabel.Location = new Point(this.btnPharmDetail.Location.X + this.btnPharmDetail.Width + 20, this.btnPharmDetail.Location.Y);
                this.simpleButton1.Location = new Point(this.btnPrintLabel.Location.X + this.btnPrintLabel.Width + 20, this.btnPrintLabel.Location.Y);
            }
        }

        /// <summary>
        /// 获取赛选条件
        /// </summary>
        private void GetFilter()
        {
            this.sendPharmSelectEventArgs.isPrintDate = this.cdPrintDateTime.Checked;
            this.sendPharmSelectEventArgs.startDate = this.dtpStartTime.DateTime;
            this.sendPharmSelectEventArgs.endDate = this.dtpEndTime.DateTime;
            //this.sendPharmSelectEventArgs.IffieldID = this.cbIffield.SelectedValue.ToString();
            //this.sendPharmSelectEventArgs.BacthID = this.cbBatch.SelectedValue.ToString();
            
            this.sendPharmSelectEventArgs.isZXDate = this.cdZXDate.Checked;
            this.sendPharmSelectEventArgs.zxTime = this.dtpZX.DateTime;
            this.sendPharmSelectEventArgs.isListDate = this.cdListDate.Checked;
            this.sendPharmSelectEventArgs.listDate = this.dtpListDate.DateTime;
            //this.sendPharmSelectEventArgs.IffieldDs = this.selectIllfield;
            //this.sendPharmSelectEventArgs.BatchIDs = this.selectBatch;
            //add by lp
            string strIllfield = "";
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            if (strIllfield == "")
            {
                this.sendPharmSelectEventArgs.IffieldDs = "''";
            }
            else
            {
                this.sendPharmSelectEventArgs.IffieldDs = strIllfield.Substring(0, strIllfield.Length - 1);
            }

            string strBatch = "";
            foreach (string illList in ckceBatch.Properties.Items.GetCheckedValues())
            {
                strBatch += illList + ",";
            }
            if (strBatch == "")
            {
                this.sendPharmSelectEventArgs.BatchIDs = "''";
            }
            else
            {
                this.sendPharmSelectEventArgs.BatchIDs = strBatch.Substring(0, strBatch.Length - 1);
            }
            //end
            string isGroup = "";
            if (this.rbAll.Checked)
            {
                isGroup = "ALL";
            }
            else if (this.rbYesGroup.Checked)
            {
                isGroup = "YES";
            }
            else if (this.rbNoGroup.Checked)
            {
                isGroup = "NO";
            }
            string allGrDr = "";
            if (this.rbALLGRDR.Checked)
            {
                allGrDr = "ALL";
            }
            if (this.rbGR.Checked)
            {
                allGrDr = "GR";
            }
            if (this.rbDR.Checked)
            {
                allGrDr = "DR";
            }
            string longTemporary = "";
            if (this.rbAllLongTemporary.Checked)
            {
                longTemporary = "ALL";
            }
            else if (this.rbLong.Checked)
            {
                longTemporary = "LONG";
            }
            else if (this.rbTemporary.Checked)
            {
                longTemporary = "TEMPORARY";
            }
            this.sendPharmSelectEventArgs.Group = isGroup;
            this.sendPharmSelectEventArgs.AllGrDr = allGrDr;
            this.sendPharmSelectEventArgs.longTemporary = longTemporary;
            //if(this.txtPharm.Tag != null)
            //{
            //    this.sendPharmSelectEventArgs.PharmId = this.txtPharm.Tag.ToString();
            //}
            //else
            //{
            //    this.sendPharmSelectEventArgs.PharmId = "0";
            //}
        }

        /// <summary>
        /// 刷新查询结果
        /// </summary>
        private void Refresh()
        {
            this.GetFilter();
            this.OnSelectLabel(null, sendPharmSelectEventArgs);
            this.OnSelectPharmColloet(null, sendPharmSelectEventArgs);
        }

        ///// <summary>
        ///// 根据是否成组过滤数据
        ///// </summary>
        ///// <returns></returns>
        //private DataTable FilterLabel()
        //{
        //    //if(this.rbAll.Checked)
        //    //{
        //    //    DataTable result = this.SendPharmDetail.Copy();
        //    //    if(result != null)
        //    //    {
        //    //        result.DefaultView.Sort = "bed_id asc";
        //    //        result = result.DefaultView.ToTable();
        //    //    }
        //    //    return result;
        //    //}
        //    //else if(this.rbYesGroup.Checked)
        //    //{
        //    //    DataTable result = this.GetDataSource(this.SendPharmDetail.Select(" isgroup = 1"));
        //    //    if(result != null)
        //    //    {
        //    //        result.DefaultView.Sort = "bed_id asc";
        //    //        result = result.DefaultView.ToTable();
        //    //    }
        //    //    return result;
        //    //}
        //    //else
        //    //{
        //    //    DataTable result = this.GetDataSource(this.SendPharmDetail.Select(" isgroup = 0"));
        //    //    if(result != null)
        //    //    {
        //    //        result.DefaultView.Sort = "bed_id asc";
        //    //        result = result.DefaultView.ToTable();
        //    //    }
        //    //    return result;
        //    //}
        //}

        /// <summary>
        /// 根据是否成组过滤数据
        /// </summary>
        /// <returns></returns>
        private DataTable FilterPharm()
        {
            if (this.rbAll.Checked)
            {
                return this.SendPharmCollect;
            }
            else if (this.rbYesGroup.Checked)
            {
                return this.GetDataSource(this.SendPharmCollect.Select(" isgroup = 1 "));
            }
            else
            {
                return this.GetDataSource(this.SendPharmCollect.Select(" isgroup = 0 "));
            }
        }

        /// <summary>
        /// 获取药品汇总
        /// </summary>
        /// <returns></returns>
        private DataTable GetPharmCollect(DataTable label)
        {
            DataTable date = label;
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                DataTable result = new DataTable("data");
                DataColumn cl1 = new DataColumn("PHARM_ID");
                DataColumn cl2 = new DataColumn("PHARM_NAME");
                DataColumn cl3 = new DataColumn("PHARM_SPEC");
                DataColumn cl4 = new DataColumn("PHARM_FACTION");
                DataColumn cl5 = new DataColumn("AMOUNT");
                DataColumn cl6 = new DataColumn("UNITS");
                DataColumn cl7 = new DataColumn("FLAG");
                result.Columns.Add(cl1);
                result.Columns.Add(cl2);
                result.Columns.Add(cl3);
                result.Columns.Add(cl4);
                result.Columns.Add(cl5);
                result.Columns.Add(cl6);
                result.Columns.Add(cl7);
                foreach (DataRow dr in date.Rows)
                {
                    DataRow[] rows = result.Select(" PHARM_ID = '" + dr["PHARM_ID"].ToString() + "'");
                    if (rows != null && rows.Length > 0)
                    {
                        rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
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
                        newRow["FLAG"] = dr["FLAG"];
                        result.Rows.Add(newRow);
                    }
                }
                //result.DefaultView.Sort = "PHARM_NAME,PHARM_SPEC,PHARM_FACTION,UNITS";
                //result = result.DefaultView.ToTable(); 
                //return result;
                return ScreeningDataTable(result, "", "PHARM_NAME");
            }
            return null;
        }
        public static DataTable ScreeningDataTable(DataTable dt, string wherecode, string orderby)
        {
            DataView dv = new DataView() { Table = dt, RowFilter = wherecode, Sort = orderby };
            return dv.ToTable();
        }
        ///// <summary>
        ///// 获取药品汇总
        ///// </summary>
        ///// <returns></returns>
        //private DataTable GetPharmOrderIllfieldCollect(DataTable label)
        //{
        //    DataTable date = label;
        //    if(date != null && date.Rows != null && date.Rows.Count > 0)
        //    {
        //        DataTable result = new DataTable();
        //        DataColumn cl1 = new DataColumn("PHARM_ID");
        //        DataColumn cl2 = new DataColumn("PHARM_NAME");
        //        DataColumn cl3 = new DataColumn("PHARM_SPEC");
        //        DataColumn cl4 = new DataColumn("PHARM_FACTION");
        //        DataColumn cl5 = new DataColumn("AMOUNT");
        //        DataColumn cl6 = new DataColumn("UNITS");
        //        DataColumn cl7 = new DataColumn("FLAG");
        //        DataColumn cl8 = new DataColumn("ILLFIELD_NAME");
        //        DataColumn cl9 = new DataColumn("BATCH_NAME");
        //        DataColumn cl10 = new DataColumn("BATCH_PHARM_COUNT");
        //        DataColumn cl11 = new DataColumn("ILLFIELD_PHARM_COUNT");
        //        DataColumn cl12 = new DataColumn("BATCH_LABEL_COUNT");
        //        DataColumn cl13 = new DataColumn("ILLFIELD_LABEL_COUNT");
        //        result.Columns.Add(cl1);
        //        result.Columns.Add(cl2);
        //        result.Columns.Add(cl3);
        //        result.Columns.Add(cl4);
        //        result.Columns.Add(cl5);
        //        result.Columns.Add(cl6);
        //        result.Columns.Add(cl7);
        //        result.Columns.Add(cl8);
        //        result.Columns.Add(cl9);
        //        result.Columns.Add(cl10);
        //        result.Columns.Add(cl11);
        //        result.Columns.Add(cl12);
        //        result.Columns.Add(cl13);
        //        List<string> labelListBatch = new List<string>();
        //        List<string> labelListBatchIllfield = new List<string>();
        //        foreach(DataRow dr in date.Rows)
        //        {
        //            DataRow[] rows = result.Select(" ILLFIELD_NAME = '" + dr["ILLFIELD_NAME"] + "' AND BATCH_NAME = '" + dr["BATCH_NAME"] + "' AND PHARM_ID = '" + dr["PHARM_ID"].ToString() + "'");
        //            //DataRow[] rows = result.Select(" BATCH_NAME = '" + dr["BATCH_NAME"] + "' AND PHARM_ID = '" + dr["PHARM_ID"].ToString() + "'");
        //            if(rows != null && rows.Length > 0)
        //            {
        //                rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
        //            }
        //            else
        //            {
        //                DataRow newRow = result.NewRow();
        //                newRow["PHARM_ID"] = dr["PHARM_ID"];
        //                newRow["PHARM_NAME"] = dr["PHARM_NAME"];
        //                newRow["PHARM_SPEC"] = dr["SPEC"];
        //                newRow["PHARM_FACTION"] = dr["PHARM_FACTION"];
        //                newRow["AMOUNT"] = dr["PHARM_AMOUNT"];
        //                newRow["UNITS"] = dr["AMOUNT_UNIT"];
        //                newRow["FLAG"] = dr["FLAG"];
        //                newRow["ILLFIELD_NAME"] = dr["ILLFIELD_NAME"];
        //                newRow["BATCH_NAME"] = dr["BATCH_NAME"];
        //                DataRow[] Batch = result.Select(" BATCH_NAME = '" + dr["BATCH_NAME"] + "'");
        //                if(Batch != null && Batch.Length > 0)
        //                {
        //                    newRow["BATCH_PHARM_COUNT"] = Batch[0]["BATCH_PHARM_COUNT"];
        //                    newRow["BATCH_LABEL_COUNT"] = Batch[0]["BATCH_LABEL_COUNT"];
        //                }
        //                else
        //                {
        //                    newRow["BATCH_PHARM_COUNT"] = 0;
        //                    newRow["BATCH_LABEL_COUNT"] = 0;
        //                }
        //                DataRow[] BatchIllfield = result.Select(" BATCH_NAME = '" + dr["BATCH_NAME"] + "' AND ILLFIELD_NAME = '" + dr["ILLFIELD_NAME"] + "'");
        //                if(BatchIllfield != null && BatchIllfield.Length > 0)
        //                {
        //                    newRow["ILLFIELD_PHARM_COUNT"] = BatchIllfield[0]["ILLFIELD_PHARM_COUNT"];
        //                    newRow["ILLFIELD_LABEL_COUNT"] = BatchIllfield[0]["ILLFIELD_LABEL_COUNT"];
        //                }
        //                else
        //                {
        //                    newRow["ILLFIELD_PHARM_COUNT"] = 0;
        //                    newRow["ILLFIELD_LABEL_COUNT"] = 0;
        //                }
        //                result.Rows.Add(newRow);
        //            }

        //            bool isHave = true;
        //            if(labelListBatch.FindAll((t) => t == dr["LABEL_ID"].ToString()).Count == 0)
        //            {
        //                isHave = false;
        //            }
        //            DataRow[] rowsBatch = result.Select(" BATCH_NAME = '" + dr["BATCH_NAME"] + "'");
        //            if(rowsBatch != null && rowsBatch.Length > 0)
        //            {
        //                for(int i = 0; i < rowsBatch.Length; i++)
        //                {
        //                    if(!isHave)
        //                    {
        //                        labelListBatch.Add(dr["LABEL_ID"].ToString());
        //                        rowsBatch[i]["BATCH_LABEL_COUNT"] = int.Parse(rowsBatch[i]["BATCH_LABEL_COUNT"].ToString()) + 1;
        //                    }
        //                    rowsBatch[i]["BATCH_PHARM_COUNT"] = int.Parse(rowsBatch[i]["BATCH_PHARM_COUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
        //                }
        //            }

        //            isHave = true;
        //            if(labelListBatchIllfield.FindAll((t) => t == dr["LABEL_ID"].ToString()).Count == 0)
        //            {
        //                isHave = false;
        //            }
        //            DataRow[] rowsBatchIllfield = result.Select(" BATCH_NAME = '" + dr["BATCH_NAME"] + "' AND ILLFIELD_NAME = '" + dr["ILLFIELD_NAME"] + "'");
        //            if(rowsBatchIllfield != null && rowsBatchIllfield.Length > 0)
        //            {
        //                for(int i = 0; i < rowsBatchIllfield.Length; i++)
        //                {
        //                    if(!isHave)
        //                    {
        //                        labelListBatchIllfield.Add(dr["LABEL_ID"].ToString());
        //                        rowsBatchIllfield[i]["ILLFIELD_LABEL_COUNT"] = int.Parse(rowsBatchIllfield[i]["ILLFIELD_LABEL_COUNT"].ToString()) + 1;
        //                    }
        //                    rowsBatchIllfield[i]["ILLFIELD_PHARM_COUNT"] = int.Parse(rowsBatchIllfield[i]["ILLFIELD_PHARM_COUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
        //                }
        //            }




        //        }
        //        return result;
        //    }
        //    return null;
        //}

        /// <summary>
        /// 获取药品汇总
        /// </summary>
        /// <returns></returns>
        private DataTable GetPharmOrderIllfieldCollect(DataTable label)
        {
            DataTable date = label;
            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                DataTable result = new DataTable();
                DataColumn cl1 = new DataColumn("ILLFIELD_NAME");
                DataColumn cl2 = new DataColumn("BATCH_LABEL_COUNT1");
                DataColumn cl3 = new DataColumn("BATCH_LABEL_COUNT2");
                DataColumn cl4 = new DataColumn("BATCH_LABEL_COUNT3");
                DataColumn cl5 = new DataColumn("BATCH_LABEL_COUNT4");
                DataColumn cl6 = new DataColumn("BATCH_LABEL_COUNT5");
                DataColumn cl7 = new DataColumn("BATCH_LABEL_COUNT6");
                DataColumn cl8 = new DataColumn("BATCH_LABEL_COUNTZ");
                DataColumn cl9 = new DataColumn("BATCH_LABEL_COUNTW");
                DataColumn cl10 = new DataColumn("BATCH_LABEL_COUNTB");
                DataColumn cl11 = new DataColumn("BATCH_LABEL_COUNTL");
                DataColumn cl12 = new DataColumn("ALL_BATCH_LABEL_COUNT");
                result.Columns.Add(cl1);
                result.Columns.Add(cl2);
                result.Columns.Add(cl3);
                result.Columns.Add(cl4);
                result.Columns.Add(cl5);
                result.Columns.Add(cl6);
                result.Columns.Add(cl7);
                result.Columns.Add(cl8);
                result.Columns.Add(cl9);
                result.Columns.Add(cl10);
                result.Columns.Add(cl11);
                result.Columns.Add(cl12);
                DataRow allIllfeildRow = result.NewRow();
                allIllfeildRow["ILLFIELD_NAME"] = "全部病区";
                allIllfeildRow["BATCH_LABEL_COUNT1"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNT2"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNT3"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNT4"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNT5"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNT6"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNTZ"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNTW"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNTB"] = 0;
                allIllfeildRow["BATCH_LABEL_COUNTL"] = 0;
                allIllfeildRow["ALL_BATCH_LABEL_COUNT"] = 0;
                List<string> labelListBatchIllfield = new List<string>();
                foreach (DataRow dr in date.Rows)
                {
                    DataRow[] rows = result.Select(" ILLFIELD_NAME = '" + dr["ILLFIELD_NAME"] + "'");
                    DataRow row;
                    if (rows != null && rows.Length > 0)
                    {
                        row = rows[0];
                    }
                    else
                    {
                        DataRow newRow = result.NewRow();
                        newRow["ILLFIELD_NAME"] = dr["ILLFIELD_NAME"];
                        newRow["BATCH_LABEL_COUNT1"] = 0;
                        newRow["BATCH_LABEL_COUNT2"] = 0;
                        newRow["BATCH_LABEL_COUNT3"] = 0;
                        newRow["BATCH_LABEL_COUNT4"] = 0;
                        newRow["BATCH_LABEL_COUNT5"] = 0;
                        newRow["BATCH_LABEL_COUNT6"] = 0;
                        newRow["BATCH_LABEL_COUNTZ"] = 0;
                        newRow["BATCH_LABEL_COUNTW"] = 0;
                        newRow["BATCH_LABEL_COUNTB"] = 0;
                        newRow["BATCH_LABEL_COUNTL"] = 0;
                        newRow["ALL_BATCH_LABEL_COUNT"] = 0;
                        result.Rows.Add(newRow);
                        row = newRow;
                    }
                    if (labelListBatchIllfield.FindAll((t) => t == dr["LABEL_ID"].ToString()).Count == 0)
                    {
                        switch (dr["BATCH_ID"].ToString())
                        {
                            case "1000000000":
                                row["BATCH_LABEL_COUNT1"] = Convert.ToInt32(row["BATCH_LABEL_COUNT1"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT1"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT1"]) + 1;
                                break;
                            case "1000000001":
                                row["BATCH_LABEL_COUNT2"] = Convert.ToInt32(row["BATCH_LABEL_COUNT2"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT2"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT2"]) + 1;
                                break;
                            case "1000000002":
                                row["BATCH_LABEL_COUNT3"] = Convert.ToInt32(row["BATCH_LABEL_COUNT3"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT3"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT3"]) + 1;
                                break;
                            case "1000000003":
                                row["BATCH_LABEL_COUNT4"] = Convert.ToInt32(row["BATCH_LABEL_COUNT4"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT4"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT4"]) + 1;
                                break;
                            case "1000000004":
                                row["BATCH_LABEL_COUNTB"] = Convert.ToInt32(row["BATCH_LABEL_COUNTB"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNTB"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNTB"]) + 1;
                                break;
                            case "1000000005":
                                row["BATCH_LABEL_COUNTL"] = Convert.ToInt32(row["BATCH_LABEL_COUNTL"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNTL"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNTL"]) + 1;
                                break;
                            case "1000000006":
                                row["BATCH_LABEL_COUNT5"] = Convert.ToInt32(row["BATCH_LABEL_COUNT5"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT5"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT5"]) + 1;
                                break;
                            case "1000000007":
                                row["BATCH_LABEL_COUNT6"] = Convert.ToInt32(row["BATCH_LABEL_COUNT6"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNT6"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNT6"]) + 1;
                                break;
                            case "2000000021":
                                row["BATCH_LABEL_COUNTZ"] = Convert.ToInt32(row["BATCH_LABEL_COUNTZ"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNTZ"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNTZ"]) + 1;
                                break;
                            case "2000000020":
                                row["BATCH_LABEL_COUNTW"] = Convert.ToInt32(row["BATCH_LABEL_COUNTW"]) + 1;
                                allIllfeildRow["BATCH_LABEL_COUNTW"] = Convert.ToInt32(allIllfeildRow["BATCH_LABEL_COUNTW"]) + 1;
                                break;
                        }
                        row["ALL_BATCH_LABEL_COUNT"] = Convert.ToInt32(row["ALL_BATCH_LABEL_COUNT"]) + 1;
                        allIllfeildRow["ALL_BATCH_LABEL_COUNT"] = Convert.ToInt32(allIllfeildRow["ALL_BATCH_LABEL_COUNT"]) + 1;
                        labelListBatchIllfield.Add(dr["LABEL_ID"].ToString());
                    }
                }
                result.Rows.Add(allIllfeildRow);
                return result;
            }
            return null;
        }

        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] rows)
        {
            DataTable result = new DataTable();
            if (rows != null && rows.Length != 0)
            {
                result = rows[0].Table.Clone();
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return result;
        }

        /// <summary>
        ///设置打印瓶贴数
        /// </summary>
        private DataTable GetLabelCount(DataTable date)
        {
            //DataTable result = new DataTable();
            ////DataColumn cl1 = new DataColumn("GROUP_INDEX");
            ////DataColumn cl2 = new DataColumn("BATCH_ID");
            ////DataColumn cl3 = new DataColumn("NEW_GROUP_INDEX_NO");
            //DataColumn cl4 = new DataColumn("BAR_STATUS");
            //DataColumn cl5 = new DataColumn("EXE_STATUS");
            //DataColumn cl6 = new DataColumn("LABEL_ID");
            ////result.Columns.Add(cl1);
            ////result.Columns.Add(cl2);
            ////result.Columns.Add(cl3);
            //result.Columns.Add(cl4);
            //result.Columns.Add(cl5);
            //result.Columns.Add(cl6);
            //if(date != null && date.Rows != null && date.Rows.Count > 0)
            //{
            //    foreach(DataRow row in date.Rows)
            //    {
            //        //string SelectSql = " GROUP_INDEX = '" + row["GROUP_INDEX"].ToString() + "' and   BATCH_ID = '" + row["BATCH_ID"].ToString() + "' and   NEW_GROUP_INDEX_NO = '" + row["NEW_GROUP_INDEX_NO"].ToString() + "'";
            //        string SelectSql = " LABEL_ID = '" +row["GROUP_INDEX"].ToString() +"' ";
            //        DataRow[] rows = result.Select(SelectSql);
            //        if(rows != null && rows.Length > 0)
            //        {
            //            //rows[0]["AMOUNT"] = int.Parse(rows[0]["AMOUNT"].ToString()) + int.Parse(dr["PHARM_AMOUNT"].ToString());
            //        }
            //        else
            //        {
            //            DataRow newRow = result.NewRow();
            //            //newRow["GROUP_INDEX"] = row["GROUP_INDEX"];
            //            //newRow["BATCH_ID"] = row["BATCH_ID"];
            //            //newRow["NEW_GROUP_INDEX_NO"] = row["NEW_GROUP_INDEX_NO"];
            //            newRow["BAR_STATUS"] = row["BAR_STATUS"];
            //            newRow["EXE_STATUS"] = row["EXE_STATUS"];
            //            newRow["LABEL_ID"] = row["LABEL_ID"];
            //            result.Rows.Add(newRow);
            //        }
            //    }
            //}
            //return result;



            if (date != null && date.Rows != null && date.Rows.Count > 0)
            {
                DataView dv = date.AsDataView();
                dv.Sort = " LABEL_ID DESC ";
                DataTable dt = dv.ToTable();
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["LABEL_ID"].ToString() == dt.Rows[i - 1]["LABEL_ID"].ToString())
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
                return dt;
            }
            return null;
        }

        /// <summary>
        ///设置打印瓶贴数
        /// </summary>
        private int GetPharmCount(DataTable data)
        {
            int allaCount = 0;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    allaCount += int.Parse(row["AMOUNT"].ToString());
                }
            }
            return allaCount;
        }

        #endregion












    }
}
