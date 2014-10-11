using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views.Navigate
{
    public interface ICarPhotosView : CJia.Parking.Tools.IView
    {
        event EventHandler<CarPhotosArgs> OnQueryNextPageByLice;

        event EventHandler<CarPhotosArgs> OnQueyrNextPageByPark;

        event EventHandler<CarPhotosArgs> OnQueryNextPageByFast;

        event EventHandler<CarPhotosArgs> OnQueryNextPageByTime;

        void ExeShowPictrues(DataTable dt);
    }

    public class CarPhotosArgs : EventArgs
    {
        /// <summary>
        /// 查询第几个页面
        /// </summary>
        public int PageIndex;

        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicenecNo;

        /// <summary>
        /// 车位
        /// </summary>
        public string ParkNo;

        /// <summary>
        /// 时间查询sql拼凑
        /// </summary>
        public string TimeQuerySql;

        /// <summary>
        /// 时间查询参数
        /// </summary>
        public List<object> TimeQueryPar;

        /// <summary>
        /// 模糊查询代码
        /// </summary>
        public string fast1;

        public string fast2;

        public string fast3;

        public string fast4;

        public string fast5;

    }
}
