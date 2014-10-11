using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// 瓶贴过滤Presenter层
    /// </summary>
    public class FilterLabelPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.FilterLabelModel,CJia.PIVAS.Views.Label.IFilterLabelView>
    {
        /// <summary>
        /// 瓶贴锅炉Presenter层构造函数
        /// </summary>
        /// <param name="view"></param>
        public FilterLabelPresenter(CJia.PIVAS.Views.Label.IFilterLabelView view)
            : base(view)
        {
            this.View.OnInit += View_Init;
            this.View.OnModifFilter += View_ModifFilter;
        }

        /// <summary>
        /// 出事化View
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }

        #region View事件绑定方法

        //修改赛选条件
        void View_ModifFilter(object sender, CJia.PIVAS.Views.Label.FilterLabelEventArgs e)
        {
            DevExpress.XtraEditors.CheckedListBoxControl pharmTypes = e.PharmType;
            DevExpress.XtraEditors.CheckedListBoxControl batchs =e.LabelBatch;
            DevExpress.XtraEditors.CheckedListBoxControl beds = e.Bed;
            DevExpress.XtraEditors.ListBoxControl use = e.UserOrderBy;
            DevExpress.XtraEditors.ListBoxControl nouse = e.NoUserOrderBy;
            this.cope(CJia.PIVAS.Tools.LabelFilter.PharmType, pharmTypes);
            this.cope(CJia.PIVAS.Tools.LabelFilter.LabelBacth, batchs);
            this.cope(CJia.PIVAS.Tools.LabelFilter.IllfileBens, beds);
            this.copeList(CJia.PIVAS.Tools.LabelFilter.UseOrderBy, use);
            this.copeList(CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy, nouse);
            //this.View.ShowMessage("保存过滤条件与排序方式成功！");
        }

        //出事化事件绑定办法
        void View_Init(object sender, CJia.PIVAS.Views.Label.FilterLabelEventArgs e)
        {
            this.View.ExeBindingPharmTypes(CJia.PIVAS.Tools.LabelFilter.PharmType);
            this.View.ExeBindingBacths(CJia.PIVAS.Tools.LabelFilter.LabelBacth);
            this.View.ExeBindingIffieldBens(CJia.PIVAS.Tools.LabelFilter.IllfileBens);
            this.View.ExeBindingUseOrderBy(CJia.PIVAS.Tools.LabelFilter.UseOrderBy);
            this.View.ExeBindingNoUseOrderBy(CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy);
        }

        #endregion 

        #region 补助方法

        /// <summary>
        /// 将旧的控件复制到新的控件
        /// </summary>
        /// <param name="oldLBC"></param>
        /// <param name="newLBC"></param>
        private void cope(DevExpress.XtraEditors.CheckedListBoxControl oldLBC, DevExpress.XtraEditors.CheckedListBoxControl newLBC)
        {
            if(oldLBC == null)
            {
                oldLBC = new DevExpress.XtraEditors.CheckedListBoxControl();
            }
            oldLBC.Items.Clear();
            DevExpress.XtraEditors.CheckedListBoxControl newListBoxControl = newLBC as DevExpress.XtraEditors.CheckedListBoxControl;
            if(newListBoxControl != null)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in newListBoxControl.Items)
                {
                    oldLBC.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 将旧的控件复制到新的控件
        /// </summary>
        /// <param name="oldLBC"></param>
        /// <param name="newLBC"></param>
        private void copeList(DevExpress.XtraEditors.ListBoxControl oldLBC, DevExpress.XtraEditors.ListBoxControl newLBC)
        {
            oldLBC.Items.Clear();
            DevExpress.XtraEditors.ListBoxControl newListBoxControl = newLBC as DevExpress.XtraEditors.ListBoxControl;
            if(newListBoxControl != null)
            {
                foreach(string item in newListBoxControl.Items)
                {
                    oldLBC.Items.Add(item);
                }
            }
        }

        #endregion
    }
}
