using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Views
{
    public interface ITemporaryFeeSetView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.TemproaryFeeSetArgs> OnInit;
        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.TemproaryFeeSetArgs> OnSave;
    }

    public class TemproaryFeeSetArgs : EventArgs
    {
        /// <summary>
        /// 免费时限
        /// </summary>
        public string FreeHour;

        /// <summary>
        /// 每多少小时收费
        /// </summary>
        public string HourSet;

        /// <summary>
        /// 每多少小时收费金额
        /// </summary>
        public string HourSetFee;

        /// <summary>
        /// 超过时限
        /// </summary>
        public string UpperHour;

        /// <summary>
        /// 超过时限收费金额
        /// </summary>
        public string UpperHourFee;

        /// <summary>
        /// 查询所临时停车收费设置的值
        /// </summary>
        public DataTable DataTableTem = null;
    }
}
