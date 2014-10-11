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
    public interface ISendPharmSelectView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitIffield;

        /// <summary>
        /// 初始化批次
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnInitBacth;

        /// <summary>
        /// 查询瓶贴
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnSelectLabel;

        /// <summary>
        /// 查询药品汇总
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnSelectPharmColloet;

        /// <summary>
        /// 查询药品
        /// </summary>
        event EventHandler<SendPharmSelectEventArgs> OnSelectPharm;

        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

        /// <summary>
        /// 初始化批次绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitBacth(DataTable result);

        /// <summary>
        /// 查询瓶贴绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitLabel(DataTable result);

        /// <summary>
        /// 查询药瓶汇总信息
        /// </summary>
        /// <param name="result"></param>
        void ExeInitPharmColloet(DataTable result);

        /// <summary>
        /// 查询药品
        /// </summary>
        /// <param name="result"></param>
        void ExeSelectPharm(DataTable result);
    }
    /// <summary>
    /// 冲药参数类
    /// </summary>
    public class SendPharmSelectEventArgs : EventArgs
    {
        /// <summary>
        /// 是否使用打印时间
        /// </summary>
        public bool isPrintDate;
        /// <summary>
        /// 冲药开始时间
        /// </summary>
        public DateTime startDate;

        /// <summary>
        /// 冲药结束时间
        /// </summary>
        public DateTime endDate;

        /// <summary>
        /// 是否使用执行时间
        /// </summary>
        public bool isZXDate;

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime zxTime;

        /// <summary>
        /// 是否使用开单日期
        /// </summary>
        public bool isListDate;

        /// <summary>
        /// 选择的开单日期
        /// </summary>
        public DateTime listDate;

        /// <summary>
        /// 病区id
        /// </summary>
        public string IffieldID;

        /// <summary>
        /// 病区id列表
        /// </summary>
        public List<string> IffieldDs;

        /// <summary>
        /// 批次id
        /// </summary>
        public string BacthID;

        /// <summary>
        /// 批次id列表
        /// </summary>
        public List<string> BatchIDs;

        /// <summary>
        /// 当日隔日选择  ALL所有 GR隔日 DR当日
        /// </summary>
        public string AllGrDr;

        /// <summary>
        /// 是否成组 ALL NO YES
        /// </summary>
        public string Group;

        /// <summary>
        /// 长期临时标志
        /// </summary>
        public string longTemporary;

        /// <summary>
        /// 药品查询key
        /// </summary>
        public string PharmKey;

        /// <summary>
        /// 药品id
        /// </summary>
        public string PharmId;

    }

}
