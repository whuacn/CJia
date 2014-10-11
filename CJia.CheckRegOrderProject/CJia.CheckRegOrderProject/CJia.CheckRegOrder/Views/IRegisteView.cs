using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IRegisteView:CJia.Editors.IView
    {
        /// <summary>
        /// 所选正在排队病人Id
        /// </summary>
        long PatientIdByQueue
        {
            get;
        }
        /// <summary>
        /// 判断该选择病人是否有诊室号
        /// </summary>
        string IsExistClinic
        {
            get;
        }
        /// <summary>
        /// HIS中查询数据
        /// </summary>
        event EventHandler<Views.RegisteArgs> OnSelectHIS;
        /// <summary>
        /// 门诊登记事件
        /// </summary>
        event EventHandler<Views.RegisteArgs> OnClientRegiste;
        /// <summary>
        /// 检查登记事件
        /// </summary>
        event EventHandler<Views.RegisteArgs> OnCheckRegiste;
        /// <summary>
        /// 取消排队事件
        /// </summary>
        event EventHandler CancleQueue;
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="data">HIS中返回的数据</param>
        void ExeBindPatientInfo(DataTable data);
        /// <summary>
        /// 绑定病史中的下拉框
        /// </summary>
        /// <param name="data1">宫颈炎严重程度</param>
        /// <param name="data2">CIN</param>
        /// <param name="data3">宫颈瘤</param>
        /// <param name="data4">宫颈治疗</param>
        /// <param name="data5">白带</param>
        void ExeBindComboBox(DataTable data1,DataTable data2,DataTable data3,DataTable data4,DataTable data5);
        /// <summary>
        /// 重置
        /// </summary>
        void ExeReset();
        /// <summary>
        /// 绑定正在排队病人列表
        /// </summary>
        /// <param name="dtExistQueue"></param>
        void GetPatientByExistQueue(DataTable dtExistQueue);
    }
    /// <summary>
    /// 病史管理参数
    /// </summary>
    public class RegisteArgs : EventArgs
    {
        /// <summary>
        /// 输入框中的病人卡号
        /// </summary>
        public string PatientNO = "";
        /// <summary>
        /// 绑定后获得的病人卡号
        /// </summary>
        public string PatientNOFocus = "";
        /// <summary>
        /// 发票编号
        /// </summary>
        public string InvoiceNO = "";
        /// <summary>
        /// 病人接诊类型
        /// </summary>
        public string AdmissionsType = "";
        /// <summary>
        /// 病史类
        /// </summary>
        public PatientHistory patientHistory = null;
        /// <summary>
        /// 病人基本信息
        /// </summary>
        public DataTable PatientData;
    }
}
