
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CJia.PIVAS.Views;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 退药处理表示层
    /// </summary>
    public partial class LabelAgainPrintView : Tools.View, CJia.PIVAS.Views.Label.ILabelAgainPrintView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public LabelAgainPrintView()
        {
            InitializeComponent();
            this.init();
            this.OnInitIffield(null, null);
            this.OnInitBacth(null, null);
        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.LabelAgainPrintPresenter(this);
        }


        #region 属性

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

        #endregion

        #region 界面事件

        // 根据时间查询事件
        private void btnSelectDate_Click(object sender, EventArgs e)
        {
            this.OnSelect(null, new Views.Label.LabelAgainPrintEventArgs()
            {
                startDate = this.cdtStart.DateTime,
                endDate = this.cdtEnd.DateTime,
                IllfieldId = this.cbIffield.SelectedValue.ToString(),
                BatchId = this.cbBatch.SelectedValue.ToString(),
                startBarId = this.txtStart.Text,
                endBarId = this.txtEnd.Text
            });
        }

        //// 根据瓶贴号查询事件
        //private void btnSelectBarId_Click(object sender, EventArgs e)
        //{
        //    this.OnSelect(null, new Views.Label.LabelAgainPrintEventArgs()
        //    {
        //        filterStyle = "SelectBarId",
        //        startBarId = this.txtStart.Text,
        //        endBarId = this.txtEnd.Text
        //    });
        //}

        // 全选
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DataTable data = this.gcCancel.DataSource as DataTable;
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["ISCHECK"] = true;
                }
            }
            this.gcCancel.DataSource = data;
        }

        // 全不选
        private void btnNoSelectAll_Click(object sender, EventArgs e)
        {
            DataTable data = this.gcCancel.DataSource as DataTable;
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["ISCHECK"] = false;
                }
            }
            this.gcCancel.DataSource = data;
        }

        // 反选
        private void btnNoSelect_Click(object sender, EventArgs e)
        {
            DataTable data = this.gcCancel.DataSource as DataTable;
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    string checkStr = data.Rows[i]["ISCHECK"].ToString();
                    if(checkStr == "" || checkStr == "False")
                    {
                        data.Rows[i]["ISCHECK"] = true;
                    }
                    else
                    {
                        data.Rows[i]["ISCHECK"] = false;
                    }
                }
            }
            this.gcCancel.DataSource = data;
        }

        /// <summary>
        /// 退药申请列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string value = "";
            string Index = this.gvBarCode.GetFocusedDataRow()["LABEL_BAR_ID"].ToString();
            value = this.gvBarCode.GetFocusedDataRow()["ISCHECK"].ToString();
            DataTable dt = gcCancel.DataSource as DataTable;
            foreach(DataRow dr in dt.Rows)
            {
                if(dr["LABEL_BAR_ID"].ToString() == Index)
                {
                    if(value == "" || value == "False")
                    {
                        dr["ISCHECK"] = true;
                    }
                    else
                    {
                        dr["ISCHECK"] = false;
                    }
                }
            }
            this.gcCancel.RefreshDataSource();
        }

        /// <summary>
        /// 重新打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            this.OnSelectPrintInfo(null, new Views.Label.LabelAgainPrintEventArgs()
            {
                printLabelList = this.GetCheckLabelBar()
            });
        }

        #endregion



        #region ILabelAgainPrintView 成员

        public event EventHandler<Views.Label.LabelAgainPrintEventArgs> OnSelect;

        public void ExeLabel(DataTable result)
        {
            this.gcCancel.DataSource = result;
            this.gvBarCode.ExpandAllGroups();
        }

        public event EventHandler<Views.Label.LabelAgainPrintEventArgs> OnSelectPrintInfo;

        public event EventHandler<SendPharmSelectEventArgs> OnInitIffield;

        public event EventHandler<SendPharmSelectEventArgs> OnInitBacth;

        /// <summary>
        /// 获取重新生成的瓶贴
        /// </summary>
        /// <param name="result"></param>
        public void ExePrintLabelInfo(DataTable result)
        {
            this.BarCodeLabel = result;
            if(result == null || result.Rows == null || result.Rows.Count == 0)
            {
            }
            else
            {
                int allLabelCount = (result.Rows.Count - 1) / Common.GetLabelCount() + 1;
                DataTable reportDataSource = this.GetDataSource(result, int.Parse(result.Rows[0]["LABEL_PAGE_NO"].ToString()));
                string labelBarCode = result.Rows[0]["LABEL_BAR_ID"].ToString();
                this.nowBarCode = labelBarCode;
                DateTime GenDate = (DateTime)result.Rows[0]["GEN_DATE"];
                this.labelReport.DataBind(reportDataSource, allLabelCount, int.Parse(result.Rows[0]["LABEL_PAGE_NO"].ToString()), labelBarCode, GenDate);
                this.labelReport.LabelPrint();
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
            result = this.GetDataSource(result.Select(" BATCH_ID <> 1000000005 "));
            result.DefaultView.Sort = " BATCH_NO ASC ";
            result = result.DefaultView.ToTable();
            DataRow dr = result.NewRow();
            dr["BATCH_NAME"] = "< 全部 >";
            dr["BATCH_ID"] = 0;
            result.Rows.InsertAt(dr, 0);
            this.cbBatch.DataSource = result;
            this.cbBatch.DisplayMember = "BATCH_NAME";
            this.cbBatch.ValueMember = "BATCH_ID";
        }

        #endregion


        #region 辅助方法

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
        /// 初始化方法
        /// </summary>
        private void init()
        {
            DateTime now = Sysdate;
            this.cdtStart.DateTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            this.cdtEnd.DateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        /// <summary>
        /// 获取选着的瓶贴
        /// </summary>
        /// <returns></returns>
        private List<string> GetCheckLabelBar()
        {
            List<string> LabelBarIdList = new List<string>();
            DataTable data = this.gcCancel.DataSource as DataTable;
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                data.DefaultView.Sort = "LABEL_BAR_ID ASC";
                DataTable dtTemp = data.DefaultView.ToTable();
                for(int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if(i > 0 && dtTemp.Rows[i]["LABEL_BAR_ID"].ToString() == dtTemp.Rows[i - 1]["LABEL_BAR_ID"].ToString())
                    {
                        continue;
                    }
                    if(dtTemp.Rows[i]["ISCHECK"].ToString() == "True")
                    {
                        LabelBarIdList.Add(dtTemp.Rows[i]["LABEL_BAR_ID"].ToString());
                    }
                }
            }
            return LabelBarIdList;
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
        #endregion

    }
}
