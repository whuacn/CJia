using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 冲药接口
    /// </summary>
    public interface IPharmEconomizeView : CJia.PIVAS.Tools.IView
    {

        event EventHandler<PharmEconomizeViewEventArgs> OnSelectFilterPharm;

        event EventHandler<PharmEconomizeViewEventArgs> OnSelectPharmEconomize;

        event EventHandler<PharmEconomizeViewEventArgs> OnSelectPharmEconomizeInput;

        event EventHandler<PharmEconomizeViewEventArgs> OnAddFilterPharm;

        event EventHandler<PharmEconomizeViewEventArgs> OnDeleteFilterPharm;

        event CJia.PIVAS.Tools.Delegate.ResTwoPar OnAddPharm;

        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitIffield;

        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

        void ExeSelectFilterPharm(DataTable result);

        void ExeSelectPharmEconomize(DataTable result);

        /// <summary>
        /// 节约入库 add lp
        /// </summary>
        /// <param name="result"></param>
        void ExeSelectPharmEconomizeInput(DataTable result);

        void ExeSelectAddPharm(DataTable detail,DataTable all);

    }
    /// <summary>
    /// 冲药参数类
    /// </summary>
    public class PharmEconomizeViewEventArgs : EventArgs
    {

        /// <summary>
        /// 瓶贴创建开始时间
        /// </summary>
        public DateTime startDate;

        /// <summary>
        /// 瓶贴创建开始结束时间
        /// </summary>
        public DateTime endDate;

        /// <summary>
        /// 药品id列表
        /// </summary>
        public List<string> pharmIds;

        /// <summary>
        /// 选择的病区
        /// </summary>
        public string illfitld;

        public string pharmId;

    }

}
