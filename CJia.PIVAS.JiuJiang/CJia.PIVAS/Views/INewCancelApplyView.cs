using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    public interface INewCancelApplyView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        ///  查询申请退药列表信息，绑定GridControl
        /// </summary>
        /// <param name="dtCancelApply"></param>
        void ExeBindGridCancelApply(DataTable dtCancelApply);

        /// <summary>
        /// 绑定病区
        /// </summary>
        /// <param name="dtOfficeName"></param>
        void ExeBindOfficeName(DataTable dtOfficeName);

        /// <summary>
        /// 绑定根据条形码查询瓶贴信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindBarCode(DataTable data);

        /// <summary>
        /// 删除瓶贴返回方法
        /// </summary>
        /// <param name="mes"></param>
        void ExeDeleteReturn(string mes,bool isSucceess);

        /// <summary>
        /// 确定退药事件
        /// </summary>
        event EventHandler<NewCancelApplyArgs> OnOkCancel;

        /// <summary>
        /// 拒绝退药事件
        /// </summary>
        event EventHandler<NewCancelApplyArgs> OnRefuseApply;

        /// <summary>
        /// 预览退药事件,即查询申退单
        /// </summary>
        event EventHandler<NewCancelApplyArgs> OnCancelPreview;

        /// <summary>
        /// 查询
        /// </summary>
        event EventHandler<NewCancelApplyArgs> OnBtnSelect;

        /// <summary>
        /// 作废
        /// </summary>
        event EventHandler<NewCancelApplyArgs> OnBtnDelete;
    }


    public class NewCancelApplyArgs : EventArgs
    {
        /// <summary>
        /// 瓶贴Id
        /// </summary>
        public List<string> LabelID;

        /// <summary>
        /// 瓶贴Id
        /// </summary>
        public List<string> AdviceID;

        /// <summary>
        /// 所选预览查询时间
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// 所选病区
        /// </summary>
        public List<string> IllFieldId;

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCodeID;

        /// <summary>
        /// 条码列表
        /// </summary>
        public List<string> barCodeList;

        /// <summary>
        /// 按钮类型
        /// </summary>
        public string btnStyle;
    }
}
