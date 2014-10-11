using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 发药统计Presenter层
    /// </summary>
    public class PharmSendStatSelectPresenter : Tools.Presenter<Models.PharmSendStatSelectModel, Views.IPharmSendStatSelectView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public PharmSendStatSelectPresenter(Views.IPharmSendStatSelectView view)
            : base(view)
        {
            view.Load += view_Load;
            view.OnStatPrint += view_OnPrint;
        }

        void view_OnPrint(object sender, Views.PharmSendStatSelectArgs e)
        {
            DataTable data = Model.GetPharmSendByCondition(e.OfficeID, e.BatchID, e.Start, e.End);
            View.ExeBindReport(data);
        }

        void view_Load(object sender, EventArgs e)
        {
            DataTable data1 = Model.GetOffice();
            DataTable data2 = Model.GetBatch();
            View.ExeInit(data1, data2);
        }
    }
}
