using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IPatientHistoryView : CJia.Editors.IView
    {
        /// <summary>
        /// 病人卡号查询事件
        /// </summary>
        event EventHandler<Views.PatientHistoryArgs> OnSelectByNO;
        /// <summary>
        /// 病人姓名查询事件
        /// </summary>
        event EventHandler<Views.PatientHistoryArgs> OnSelectByName;
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.PatientHistoryArgs> OnSelect;
        /// <summary>
        /// gcHistory点击事件
        /// </summary>
        event EventHandler<Views.PatientHistoryArgs> OnGCClick;
        /// <summary>
        /// 保存修改病史事件
        /// </summary>
        event EventHandler<Views.PatientHistoryArgs> OnSave;
        /// <summary>
        /// 病人卡号输入框获得焦点
        /// </summary>
        void TxtPatientNOFocus();
        /// <summary>
        /// 病人姓名输入框获得焦点
        /// </summary>
        void TxtPatientNameFocus();
        /// <summary>
        /// 重置
        /// </summary>
        void Reset();
        /// <summary>
        /// 绑定病史
        /// </summary>
        /// <param name="data"></param>
        void ExeBindHistory(DataTable data);
        /// <summary>
        /// 为编辑项绑定
        /// </summary>
        /// <param name="data"></param>
        void ExeBindEditHistory(DataTable data);
        /// <summary>
        /// 绑定病史中的下拉框
        /// </summary>
        /// <param name="data1">宫颈炎严重程度</param>
        /// <param name="data2">CIN</param>
        /// <param name="data3">宫颈瘤</param>
        /// <param name="data4">宫颈治疗</param>
        /// <param name="data5">白带</param>
        void ExeBindComboBox(DataTable data1, DataTable data2, DataTable data3, DataTable data4, DataTable data5);
    }
    /// <summary>
    /// 病史管理参数
    /// </summary>
    public class PatientHistoryArgs : EventArgs
    {
        /// <summary>
        /// 病人编号
        /// </summary>
        public int? PatientID = null;
        /// <summary>
        /// 病人卡号
        /// </summary>
        public string PatientNO = "";
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName = "";
        /// <summary>
        /// 病史类
        /// </summary>
        public PatientHistory patientHistory = null;
    }
}
