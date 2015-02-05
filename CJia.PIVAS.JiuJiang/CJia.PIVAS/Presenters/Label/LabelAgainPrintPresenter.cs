using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// 瓶贴过滤Presenter层
    /// </summary>
    public class LabelAgainPrintPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.LabelAgainPrintModel,CJia.PIVAS.Views.Label.ILabelAgainPrintView>
    {
        /// <summary>
        /// 瓶贴锅炉Presenter层构造函数
        /// </summary>
        /// <param name="view"></param>
        public LabelAgainPrintPresenter(CJia.PIVAS.Views.Label.ILabelAgainPrintView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnSelect += View_OnSelect;
            this.View.OnSelectPrintInfo += View_OnSelectPrintInfo;
        }



        #region View事件绑定方法

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

        // 查询瓶贴详细信息用于打印
        void View_OnSelectPrintInfo(object sender, Views.Label.LabelAgainPrintEventArgs e)
        {
            foreach( string LabelBarId in e.printLabelList)
            {
                this.View.ExePrintLabelInfo(this.Model.AnewPrintLabel(LabelBarId,CJia.PIVAS.User.UserId.ToString()));
            }
        }

        // 查询瓶贴信息
        void View_OnSelect(object sender, Views.Label.LabelAgainPrintEventArgs e)
        {
            //if(e.filterStyle == "SelectDate")
            //{
                DataTable data = this.Model.Select(e.startDate, e.endDate,e.IllfieldId,e.BatchId,e.startBarId,e.endBarId);
                if(data != null)
                {
                    DataColumn isChecked = new DataColumn("ISCHECK", typeof(System.Boolean));
                    data.Columns.Add(isChecked);
                }
                this.View.ExeLabel(data);
            //}
            //else
            //{
            //    DataTable data = this.Model.Select(e.startBarId, e.endBarId);
            //    if(data != null)
            //    {
            //        DataColumn isChecked = new DataColumn("ISCHECK", typeof(System.Boolean));
            //        data.Columns.Add(isChecked);
            //    }
            //    this.View.ExeLabel(data);
            //}
        }
        #endregion 

    }
}
