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
                MessageBox.Show("没有要打印的瓶贴！");
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
                    for(int i = startPage; i <= stopPage; i++)
                    {
                        string labelId = this.LabelDetail.Rows[i-1]["LABEL_ID"].ToString();                
                        DataRow[] labelInfos = this.LabelDetailInfo.Select("LABEL_ID = " + labelId );
                        int allLabelCount = (labelInfos.Length - 1) / 4 + 1;
                        for(int j = 1; j <= allLabelCount; j++)
                        {
                            DataTable reportDataSource = this.GetDataSource(labelInfos, j);
                            DataTable barCode = (DataTable)this.OnGetLabelBarcode(labelId, j, allLabelCount);
                            labelReport.DataBind(reportDataSource, allLabelCount, j, barCode.Rows[0]["LABEL_BAR_ID"].ToString(), (DateTime)barCode.Rows[0]["GEN_DATE"]);
                            labelReport.LabelPrint();
                            this.OnUpdateLabelPrintStatus(labelId);
                        }
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

        #endregion

        #region IView 成员

        //查询摆药单事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryArrangeEvent;

        //查询瓶贴详情事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelDetails;

        //查询瓶贴详情事件 带拼贴详细信息 打印瓶贴用
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelDetailsInfo;

        //查询瓶贴汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryLabelCollect;

        //修改摆药单id列表过滤条件事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnModifFilterArrange;

        //查询所有病区所有瓶贴的瓶贴汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryAlllIffieldBachLabelCollect;

        //查询药品汇总事件
        public event EventHandler<Views.Label.QueryLabelViewEventArgs> OnQueryPharmCollect;

        //修改瓶贴打印状态
        public event Tools.Delegate.NoResOnePar OnUpdateLabelPrintStatus;

        //获取瓶贴条形码
        public event Tools.Delegate.ResThreePar OnGetLabelBarcode;

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
            pharmCollectReport.DataBind(result, this.dtpQueryTime.Value, this.SelectIffleld, this.SelectList);
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
                this.SelectIffleld = "全院汇总";
                this.SelectList = "全院汇总";
            }
            else if(selectColStr.IndexOf('{') != -1 && selectColStr.IndexOf('}') != -1)//全病区
            {
                string illfieldId = selectRow["ILLFIELD_ID"].ToString();
                var result = from row in AllArrange.AsEnumerable()
                             where illfieldId == row["ILLFIELD_ID"].ToString() && row["ARRANGE_ID"].ToString() != "全病区"
                             select row["ARRANGE_ID"];
                selectArrangeId = result.ToList();
                this.SelectIffleld = selectRow["ILLFIELD_NAME"].ToString();
                this.SelectList = "全病区汇总";
            }
            else
            {
                selectArrangeId.Add(selectRow["ARRANGE_ID"]);
                this.SelectIffleld = selectRow["ILLFIELD_NAME"].ToString();
                this.SelectList = "第" + selectRow["ARR_TYPE"].ToString() + "次摆药单";
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

        #endregion

    }
}
