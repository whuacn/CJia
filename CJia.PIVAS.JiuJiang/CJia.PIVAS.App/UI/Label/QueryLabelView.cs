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
    /// 查询瓶贴用户控件
    /// </summary>
    public partial class QueryLabelView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.Label.IQueryLabelView
    {
        /// <summary>
        /// 查询瓶贴构造函数
        /// </summary>
        public QueryLabelView()
        {
            InitializeComponent();
            this.dtpQueryTime.Value = CJia.PIVAS.Tools.Helper.Sysdate;
        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.QueryLabelPresenter(this);
        }

        #region 字段 属性

        //查询的瓶贴汇总
        private DataTable LabelCollect = null;

        //查询的瓶贴详情
        private DataTable LabelDetail = null;

        //查询的瓶贴详情信息
        private DataTable LabelDetailInfo = null;

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

        #endregion

        #region 界面事件

        //刷新按钮单机事件绑定方法
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.Views.Label.QueryLabelViewEventArgs eventArge = new Views.Label.QueryLabelViewEventArgs()
            {
                QueryTime = this.dtpQueryTime.Value
            };
            this.OnQueryArrangeEvent(null, eventArge);
        }

        //摆药单选着双击事件绑定方法
        private void gdcArrange_DoubleClick(object sender, EventArgs e)
        {
            DataRow selectRow = this.gdvArrange.GetFocusedDataRow();
            object selectCol = this.gdvArrange.GetFocusedValue();
            List<object> selectArrangeIdList = this.GetSelectArrangeIdList(selectRow, selectCol);
            CJia.PIVAS.Views.Label.QueryLabelViewEventArgs eventArgs = new Views.Label.QueryLabelViewEventArgs()
            {
                SelectArrangeIdList = selectArrangeIdList
            };
            this.OnModifFilterArrange(null, eventArgs);
            this.OnQueryLabelCollect(null, null);
            this.OnQueryLabelDetails(null, null);
        }

        //瓶贴过滤按钮单击事件绑定方法
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.AutoSize = true;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            CJia.PIVAS.App.UI.Label.FilterLabelView filter = new FilterLabelView();
            form.Controls.Add(filter);
            filter.Dock = DockStyle.Fill;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            this.OnQueryLabelCollect(null, null);
            this.OnQueryLabelDetails(null, null);
        }

        //打印瓶贴
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            if(this.LabelDetail == null || this.LabelDetail.Rows == null || this.LabelDetail.Rows.Count == 0)
            {
                Message.Show("没有要打印的瓶贴！");
            }
            else
            {
                Form form = new Form();
                form.Size = new System.Drawing.Size(300, 200);
                form.AutoSize = true;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                CJia.PIVAS.App.UI.Label.PrintLabelView printLabel = new PrintLabelView(this.LabelDetail);
                form.Controls.Add(printLabel);
                printLabel.Dock = DockStyle.Fill;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
                if(printLabel.IsPrint)
                {
                    int startPage = printLabel.StartNum;
                    int stopPage = printLabel.EndNum;
                    this.OnQueryLabelDetailsInfo(null, null);
                    CJia.PIVAS.App.UI.Label.PrintLabelReport labelReport = new CJia.PIVAS.App.UI.Label.PrintLabelReport();
                    labelReport.allLabel = stopPage - startPage + 1;
                    DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                    for(int i = startPage; i <= stopPage; i++)
                    {
                        string labelId = this.LabelDetail.Rows[i - 1]["LABEL_ID"].ToString();
                        CJia.PIVAS.Views.Label.QueryLabelViewEventArgs queryLabelViewEventArgs = new Views.Label.QueryLabelViewEventArgs()
                        {
                            LabelId = labelId
                        };
                        this.OnUpdateBarCode(null, queryLabelViewEventArgs);
                        DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId);
                        if(labelInfos != null && labelInfos.Length != 0)
                        {
                            string GroupIndex = this.LabelDetail.Rows[i - 1]["GROUP_INDEX"].ToString();
                            this.SendPharm(GroupIndex);
                        }
                        int allLabelCount = (labelInfos.Length - 1) / Common.GetLabelCount() + 1;
                        for(int j = 1; j <= allLabelCount; j++)
                        {
                            DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                            DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                            labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["CREATE_DATE"]);
                            labelReport.LabelPrint();
                            this.OnUpdateLabelPrintStatus(labelId);
                        }
                    }
                    if(labelReport.PringedLabel > 0)
                    {
                        Message.Show("成功打印" + (labelReport.allLabel - labelReport.PringedLabel) + "张瓶贴！忽略" + labelReport.PringedLabel + "张瓶贴！" + "因为这些瓶贴对应的医嘱未通过审核！");
                    }
                }
            }
        }

        //打印瓶贴汇总
        private void btnLabelCollect_Click(object sender, EventArgs e)
        {
            this.OnQueryAlllIffieldBachLabelCollect(null, null);
        }

        //打印药品汇总
        private void btnPharmCollect_Click(object sender, EventArgs e)
        {
            this.OnQueryPharmCollect(null, null);
        }

        //瓶贴作废单击事件
        private void delectLabel_Click(object sender, EventArgs e)
        {
            DataRow label = cardView1.GetFocusedDataRow();
            if(label != null)
            {
                this.OnDeleteLabel(label["LABEL_ID"]);
                this.OnQueryLabelCollect(null, null);
                this.OnQueryLabelDetails(null, null);
            }
        }

        //瓶贴打印
        private void printLabel_Click(object sender, EventArgs e)
        {
            this.OnQueryLabelDetailsInfo(null, null);
            CJia.PIVAS.App.UI.Label.PrintLabelReport labelReport = new CJia.PIVAS.App.UI.Label.PrintLabelReport();
            labelReport.allLabel = 1;
            DataRow label = cardView1.GetFocusedDataRow();
            string labelId = label["LABEL_ID"].ToString();
            CJia.PIVAS.Views.Label.QueryLabelViewEventArgs queryLabelViewEventArgs = new Views.Label.QueryLabelViewEventArgs()
            {
                LabelId = labelId
            };
            this.OnUpdateBarCode(null, queryLabelViewEventArgs);
            DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId);
            int allLabelCount = (labelInfos.Length - 1) / Common.GetLabelCount() + 1;
            for(int j = 1; j <= allLabelCount; j++)
            {
                DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["CREATE_DATE"]);
                labelReport.LabelPrint();
                this.OnUpdateLabelPrintStatus(labelId);
            }
            if(labelReport.PringedLabel > 0)
            {
                Message.Show("因为该瓶贴对应的医嘱停用或未通过审核！所以不能打印该瓶贴！");
            }
        }

        #endregion

        #region IView 成员

        //查询摆药单事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryArrangeEvent;

        //查询瓶贴详情事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelDetails;

        //查询瓶贴详情事件 带瓶贴详细信息 打印瓶贴用
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelDetailsInfo;

        //查询瓶贴汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelCollect;

        //修改摆药单id列表过滤条件事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnModifFilterArrange;

        //查询所有病区所有瓶贴的瓶贴汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        //查询药品汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryPharmCollect;

        //修改条形码状态
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnUpdateBarCode;

        //获取扣费时间
        public event Tools.Delegate.ResOnePar OnFeeTIME;

        //扣费扣库存
        public event Tools.Delegate.ResThreePar OnPharmFee;

        //修改瓶贴打印状态
        public event Tools.Delegate.NoResOnePar OnUpdateLabelPrintStatus;

        //获取瓶贴条形码
        public event Tools.Delegate.ResThreePar OnGetLabelBarcode;

        //删除瓶贴
        public event Tools.Delegate.NoResOnePar OnDeleteLabel;


        //绑定摆药单回调方法
        public void ExeBindingArrange(DataTable result)
        {
            this.gdcArrange.DataSource = result;
            this.gdvArrange.ExpandAllGroups();
        }

        //信息提示框 回调方法
        public void ShowMessage(string mes)
        {
            throw new NotImplementedException();
        }

        //绑定瓶贴详情回调方法
        public void ExeBindingLabelDetails(DataTable result)
        {
            this.gdcLabelDetail.DataSource = result;
            this.LabelDetail = result;
        }

        //绑定瓶贴详情回调方法
        public void ExeBindingLabelDetailsInfo(DataTable result)
        {
            this.LabelDetailInfo = result;
        }

        //绑定瓶贴汇总回调方法
        public void ExeBindingLabelCollect(DataTable result)
        {
            this.gdcLabelCollect.DataSource = result;
            this.gdvLabelCollect.ExpandAllGroups();
            this.LabelCollect = result;
        }

        //绑定所有病区批次瓶贴汇总回调方法
        public void ExeBindingAlllIffieldBachLabelCollect(DataTable result)
        {
            LabelCollectReport labelCollectReport = new LabelCollectReport();
            labelCollectReport.DataBind(result, this.dtpQueryTime.Value);
        }

        //绑定药品汇总回调方法
        public void ExeBindingPharmCollect(DataTable result)
        {
            PharmCollectReport pharmCollectReport = new PharmCollectReport();
            int labelCount = 0;
            if(this.LabelDetail != null && this.LabelDetail.Rows != null)
            {
                labelCount = this.LabelDetail.Rows.Count;
            }
            pharmCollectReport.DataBind(result, this.dtpQueryTime.Value, this.SelectIffleld, this.SelectBatch, this.SelectList, labelCount);
        }


        #endregion

        #region 补助方法

        /// <summary>
        ///获取选着的摆药单
        /// </summary>
        /// <param name="selectRow"></param>
        /// <param name="selectCol"></param>
        /// <returns></returns>
        private List<object> GetSelectArrangeIdList(DataRow selectRow, object selectCol)
        {
            string selectColStr = selectCol.ToString();
            List<object> selectArrangeId = new List<object>();
            DataTable AllArrange = (this.gdvArrange.DataSource as DataView).Table;
            if(selectColStr.IndexOf("全院{") == 0)//全院
            {
                var result = from row in AllArrange.AsEnumerable()
                             where row["ARRANGE_ID"].ToString() != "全病区" && row["ARRANGE_ID"].ToString() != "全院"
                             select row["ARRANGE_ID"];
                selectArrangeId = result.ToList();
                this.SelectIffleld = "全部病区";
                this.SelectList = "全部摆药单";
            }
            else if(selectColStr.IndexOf('{') != -1 && selectColStr.IndexOf('}') != -1)//全病区
            {
                string illfieldId = selectRow["ILLFIELD_ID"].ToString();
                var result = from row in AllArrange.AsEnumerable()
                             where illfieldId == row["ILLFIELD_ID"].ToString() && row["ARRANGE_ID"].ToString() != "全病区"
                             select row["ARRANGE_ID"];
                selectArrangeId = result.ToList();
                this.SelectIffleld = selectRow["ILLFIELD"].ToString();
                this.SelectList = "全部摆药单";
            }
            else
            {
                selectArrangeId.Add(selectRow["ARRANGE_ID"]);
                this.SelectIffleld = selectRow["ILLFIELD"].ToString();
                //this.SelectList = "第" + selectRow["ARR_TYPE"].ToString() + "次摆药单";
                this.SelectList = selectRow["ARRANGE_ID"].ToString();
            }
            List<object> ArrangeId = new List<object>();
            foreach(object arrangeId in selectArrangeId)
            {
                ArrangeId.Add(arrangeId.ToString());
            }
            return ArrangeId;
        }

        /// <summary>
        /// 获取需要的页数的药品数据
        /// </summary>
        /// <param name="nowCount"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] LabelDetails, int nowCount)
        {
            if(LabelDetails != null && LabelDetails.Length != 0)
            {
                DataTable result = LabelDetails[0].Table.Clone();
                for(int i = (nowCount - 1) * 4; i < nowCount * 4; i++)
                {
                    DataRow row = result.NewRow();
                    if(i < LabelDetails.Length)
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
        /// 获取选择的批次
        /// </summary>
        /// <returns></returns>
        private string GetSelectBatch()
        {
            StringBuilder selectBatch = new StringBuilder("");
            bool selectAll = true;
            if(CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        selectBatch.Append(a.Description.ToString() + ",");
                    }
                    else
                    {
                        selectAll = false;
                    }
                }
                if(selectAll)
                {
                    return "全部批次";
                }
                if(selectBatch.Length != 0)
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
        private void SendPharm(string GroupIndex)
        {
            if((bool)this.OnFeeTIME("0"))//查询当前是否需要扣除费用
            {
                if(this.dtpQueryTime.Value.ToShortDateString() == Sysdate.ToShortDateString())
                {
                    string flag = this.OnPharmFee(GroupIndex, Sysdate,1).ToString();
                    if(flag != "Successed")
                    {
                        Message.Show("医嘱\"" + GroupIndex + "\"扣除费用时发生异常：" + flag);
                    }
                }
            }

        }

        #endregion
    }
}
