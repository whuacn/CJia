using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// 查询瓶贴Presenter层
    /// </summary>
    public class QueryPrintLabelPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.QueryPrintLabelModel, CJia.PIVAS.Views.Label.IQueryPrintLabelView>
    {
        /// <summary>
        /// 查询瓶贴Presenter层构造函数
        /// </summary>
        /// <param name="view"></param>
        public QueryPrintLabelPresenter(CJia.PIVAS.Views.Label.IQueryPrintLabelView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnInitUsage += View_OnInitUsage;
            //this.View.OnQueryArrangeEvent += View_QueryArrangeEvent;
            //this.View.OnModifFilterArrange += View_ModifFilterArrange;
            //this.View.OnQueryLabelCollect += View_QueryLabelCollect;
            this.View.OnQueryLabelDetails += View_QueryLabelDetails;
            this.View.OnQueryLabelDetailsInfo += View_QueryLabelDetailsInfo;

            this.View.OnUpdateLabelExeStatus += View_OnUpdateLabelExeStatus;
            //this.View.OnQueryAlllIffieldBachLabelCollect += View_QueryAlllIffieldBachLabelCollect;
            this.View.OnQueryPharmCollect += View_OnQueryPharmCollect;
            this.View.OnGetLabelBarcode += View_OnGetLabelBarcode;
            this.View.OnUpdateLabelPrintStatus += View_OnUpdateLabelPrintStatus;
            this.View.OnUpdateBarCode += View_OnUpdateBarCode;
            this.View.OnDeleteLabel += View_OnDeleteLabel;
            this.View.OnPharmFee += View_OnPharmFee;
            this.View.OnFeeTIME += View_OnFeeTIME;


            this.View.OnGenLabel += View_OnGenLabel;
            this.View.OnLabelIsFee += View_OnLabelIsFee;

            this.View.OnLabelPharmCount += View_OnLabelPharmCount;
        }









        /// <summary>
        /// 出事哈View层
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }

        #region 界面事件

        /// <summary>
        /// 检查该瓶贴会不会使药品库存不足
        /// </summary>
        /// <param name="labelId"></param>
        object View_OnLabelPharmCount(object labelId)
        {
            return this.Model.QueryLabelPharmCount(labelId.ToString());
        }

        //修改瓶贴冲药状态
        void View_OnUpdateLabelExeStatus(object labelId)
        {
            CJia.PIVAS.Models.PIVASModel.ExecuteLabelFee(labelId.ToString());
        }

        // 查询瓶贴的扣费次数
        object View_OnLabelIsFee(object labelId)
        {
            return this.Model.QueryLabelTimes(labelId.ToString());
        }

        //生成瓶贴
        void View_OnGenLabel(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            //this.Model.InserLabel(e.IllfieldId, e.batchid, e.printType);
            DataTable result = this.Model.InserLabel(e.selectDate, e.grOrDr, e.groupIndexBatchid);
            //this.View.ExeBindingLabelDetailsInfo(result);
        }

        //初始化批次事件绑定方法
        void View_OnInitBacth(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitBacth(Common.GetBatch());
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        //初始化给药途径事件绑定方法
        void View_OnInitUsage(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitUsage(Common.GetUsage());
        }

        //查询瓶贴详情
        void View_QueryLabelDetails(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            DataTable result = this.Model.QueryLabelDetail(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd,e.UsageId);
            this.View.ExeBindingLabelDetails(result);
        }

        //查询药品汇总信息
        void View_OnQueryPharmCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            //DataTable result = this.Model.QueryPharmCollect(e.IllfieldId, e.batchid, e.printType);
            DataTable result = this.Model.QueryPharmCollect(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd,e.UsageId);
            this.View.ExeBindingPharmCollect(result);
        }

        //public DataTable OnQueryPharmCollect(Views.Label.QueryPrintLabelViewEventArgs e)
        //{
        //    //DataTable result = this.Model.QueryPharmCollect(e.IllfieldId, e.batchid, e.printType);
        //    DataTable result = this.Model.QueryPharmCollect(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd);
        //    return result;
        //}

        //查询瓶贴详情信息 用于打印瓶贴
        void View_QueryLabelDetailsInfo(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            DataTable result = this.Model.QueryGenLabel(e.selectDate, e.grOrDr, e.IllfieldId, e.batchid, e.printType, e.useCheckData, e.CheckDataStart, e.CheckDataEnd);
            this.View.ExeBindingLabelDetailsInfo(result);
        }





        //获取扣费时间
        object View_OnFeeTIME(object feeTime)
        {
            return CJia.PIVAS.Models.PIVASModel.QueryFeeTime(feeTime.ToString());
        }

        //扣费扣库存
        object View_OnPharmFee(object groupIndex, object openDate, object count)
        {
            return CJia.PIVAS.Models.PIVASModel.ExecuteGroupIndexFee(groupIndex.ToString(), CJia.PIVAS.User.hisUserId.ToString(), (DateTime)openDate, (int)count, 0);
        }

        //作废瓶贴
        void View_OnDeleteLabel(object parameter1)
        {
            string labelId = parameter1.ToString();
            this.Model.DeleteLabel(labelId, CJia.PIVAS.User.UserId);
        }

        //修改条形码状态
        void View_OnUpdateBarCode(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            this.Model.UpdateBarCodeStatus(e.LabelId);
        }

        //把瓶贴信息插入条形码表并返回条形码id
        object View_OnGetLabelBarcode(object parameter1, object parameter2, object parameter3)
        {
            return this.Model.GetLabelBarcode(parameter1, parameter2, parameter3, CJia.PIVAS.User.UserId);
        }

        //修改瓶贴打印状态
        void View_OnUpdateLabelPrintStatus(object labelId, object date)
        {
            this.Model.UpdateLabelPrintStatus(labelId, (DateTime)date);
        }

        //查询所有病区批次的摆药单信息
        void View_QueryAlllIffieldBachLabelCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        PharmTypes.Add(a.Value);
                    }
                }
            }

            List<object> Bacths = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bacths.Add(a.Value);
                    }
                }
            }

            List<object> Bens = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bens.Add(a.Value);
                    }
                }
            }

            List<object> OrderBy = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach (string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if (a == "药品类型[升序]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if (a == "药品类型[倒序]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if (a == "瓶贴批次[升序]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if (a == "瓶贴批次[倒序]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if (a == "病区名称[升序]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if (a == "病区名称[倒序]")
                        OrderBy.Add(" spl.illfield_name desc ");
                }
            }
            OrderBy.Add(" spl.LABEL_ID asc ");
            DataTable result = this.Model.QueryAllIllfieldBacthLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingAlllIffieldBachLabelCollect(result);
        }

        //修改过滤条件
        void View_ModifFilterArrange(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            CJia.PIVAS.Tools.LabelFilter.ArrangeIds = e.SelectArrangeIdList;
            this.InitIffieldBen(this.Model.QuseryIffieldBed(e.SelectArrangeIdList));
        }

        //初始化时间绑定方法
        void View_Load(object sender, EventArgs e)
        {
            this.InitFilter();
            this.InitIffieldBen(null);
        }





        //查询瓶贴汇总
        void View_QueryLabelCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            DataTable result = this.Model.QueryLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens);
            this.View.ExeBindingLabelCollect(result);
        }

        //查询摆药单事件绑定方法
        void View_QueryArrangeEvent(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            CJia.PIVAS.Tools.LabelFilter.SelectDate = e.QueryTime;
            DataTable result = this.Model.QueryArrangeCollect(e.QueryTime);
            this.View.ExeBindingArrange(result);
        }

        #endregion

        #region 补助方法

        /// <summary>
        /// 获取药品类型过滤条件
        /// </summary>
        /// <returns></returns>
        public List<object> GetPharmTypeFilter()
        {
            List<object> PharmTypes = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        PharmTypes.Add(a.Value);
                    }
                }
            }
            return PharmTypes;
        }

        /// <summary>
        /// 获取批次过滤条件
        /// </summary>
        /// <returns></returns>
        public List<object> GetBacthsFilter()
        {
            List<object> Bacths = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bacths.Add(a.Value);
                    }
                }
            }
            return Bacths;
        }

        /// <summary>
        /// 获取床位过滤条件
        /// </summary>
        /// <returns></returns>
        public List<object> GetBensFilter()
        {
            List<object> Bens = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bens.Add(a.Value);
                    }
                }
            }
            return Bens;
        }

        /// <summary>
        /// 获取排序方式
        /// </summary>
        /// <returns></returns>
        public List<object> GetOrderByFilter()
        {
            List<object> OrderBy = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach (string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if (a == "药品类型[升序]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if (a == "药品类型[倒序]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if (a == "瓶贴批次[升序]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if (a == "瓶贴批次[倒序]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if (a == "病区名称[升序]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if (a == "病区名称[倒序]")
                        OrderBy.Add(" spl.illfield_name desc ");
                }
            }
            return OrderBy;
        }




        // 初始化过滤信息
        void InitFilter()
        {
            DataTable allPharmType = this.Model.QueryAllPharmType();
            DataTable allBacth = this.Model.QueryAllBacth();
            CJia.PIVAS.Tools.LabelFilter.IsInit = true;
            CJia.PIVAS.Tools.LabelFilter.ArrangeIds = new List<object>();
            CJia.PIVAS.Tools.LabelFilter.PharmType = new DevExpress.XtraEditors.CheckedListBoxControl();
            foreach (DataRow pharmType in allPharmType.Rows)
            {
                CJia.PIVAS.Tools.LabelFilter.PharmType.Items.Add(pharmType["CODE"].ToString(), pharmType["NAME"].ToString(), System.Windows.Forms.CheckState.Checked, true);
            }

            CJia.PIVAS.Tools.LabelFilter.LabelBacth = new DevExpress.XtraEditors.CheckedListBoxControl();
            foreach (DataRow batch in allBacth.Rows)
            {
                CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items.Add(batch["BATCH_ID"].ToString(), batch["BATCH_NAME"].ToString(), System.Windows.Forms.CheckState.Checked, true);
            }
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy = new DevExpress.XtraEditors.ListBoxControl();
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("药品类型[升序]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("药品类型[倒序]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("瓶贴批次[倒序]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("病区名称[倒序]");
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy = new DevExpress.XtraEditors.ListBoxControl();
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items.Add("病区名称[升序]");
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items.Add("瓶贴批次[升序]");
        }

        //初始化病房床位
        void InitIffieldBen(DataTable result)
        {
            CJia.PIVAS.Tools.LabelFilter.IllfileBens = new DevExpress.XtraEditors.CheckedListBoxControl();
            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    string value = "\'" + row["ILLFIELD_ID"].ToString() + "\'," + (row["BED_ID"].ToString() == "" ? "null" : row["BED_ID"].ToString());
                    string text = row["ILLFIELD_NAME"].ToString() + " " + (row["BED_NAME"].ToString() == "" ? "空病床" : row["BED_NAME"].ToString());
                    if (CJia.PIVAS.Tools.LabelFilter.IllfileBens.FindString(text) == -1)
                    {
                        CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items.Add(value, text, System.Windows.Forms.CheckState.Checked, true);
                    }
                }
            }
        }

        #endregion

    }
}